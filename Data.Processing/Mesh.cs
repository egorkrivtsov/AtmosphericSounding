using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;
using MathNet.Numerics.Interpolation;

namespace Data.Processing
{
    public class Mesh
    {
        public IEnumerable<double[]> Data { get; private set; }

        public int XIndex { get; set; }

        public IEnumerable<double> XValues
        {
            get { return Data.Select(d => d[XIndex]); }
        }

        public IInterpolation[] GetInterpolations()
        {
            var result = new IInterpolation[YDimension];
            var iIndex = 0;
            for (int i = 0; i < YDimension+1; i++)
            {
                if (i != XIndex)
                {
                    result[iIndex] = Interpolate.Linear(XValues, Data.Select(d => d[i]));
                    iIndex++;
                }
            }

            return result;
        }

        public int YDimension { get; set; }

        public Mesh(IEnumerable<double[]> data, int xIndex)
        {
            Data = data;
            XIndex = xIndex;
            YDimension = Data.First().Length - 1;
        }

        public Mesh(IEnumerable<double[]> data): this(data,0)
        {
        }

        public Mesh CreateOnUniform(int meshStep)
        {
            List<double[]> newMesh = new List<double[]>();

            var interpolationsFunctions= this.GetInterpolations();
            double xValue = this.XValues.Min();
            while (xValue < XValues.Max())
            {
                var newMeshValues = new double[interpolationsFunctions.Length+1];
                newMeshValues[0] = xValue;

                var mergeMeshedIndex = 0;
               
                for (int i = 0; i < interpolationsFunctions.Length; i++)
                {
                    newMeshValues[mergeMeshedIndex] = interpolationsFunctions[i].Interpolate(xValue);
                    mergeMeshedIndex++;
                }

                newMesh.Add(newMeshValues);
                xValue += meshStep;
            }

            return new Mesh(newMesh, 0);
        }

        public Mesh MergeOnUniform(Mesh mesh, int meshStep)
        {
            //min /max for x value
            double maxXMergedValue = Math.Min(this.XValues.Max(), mesh.XValues.Max());
            double minMergedXValue = Math.Min(this.XValues.Min(), mesh.XValues.Min());
            //the resulting mesh
            List<double[]> mergeMesh = new List<double[]>();
            //the resulting dimension 
            int mergeMeshLength = this.YDimension + mesh.YDimension + 1;

            double mergedXValue = minMergedXValue;

            var interpolationsFunctionsMesh1 = GetInterpolations();
            var interpolationsFunctionsMesh2 = mesh.GetInterpolations();

            while (mergedXValue<maxXMergedValue)
            {
                var mergeXyValues = new double[mergeMeshLength];
                //key
                mergeXyValues[0] = mergedXValue;
                var mergeMeshedIndex = 1;

                for (int i = 0; i < interpolationsFunctionsMesh1.Length; i++)
                {
                    mergeXyValues[mergeMeshedIndex] = interpolationsFunctionsMesh1[i].Interpolate(mergedXValue);
                    mergeMeshedIndex++;
                }

                for (int i = 0; i < interpolationsFunctionsMesh2.Length; i++)
                {
                    mergeXyValues[mergeMeshedIndex] = interpolationsFunctionsMesh2[i].Interpolate(mergedXValue);
                    mergeMeshedIndex++;
                }
                mergeMesh.Add(mergeXyValues);
                mergedXValue += meshStep;
            }


            return new Mesh(mergeMesh,0);
        }
    }
}
