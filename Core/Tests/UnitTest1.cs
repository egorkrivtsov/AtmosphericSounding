using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data.Models;
using Data.Processing;
using Data.Reader;
using Data.Reader.Interfaces;
using Data.Reader.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using GroundStation = Data.Reader.Mapping.GroundStation;


namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestParsingMarl()
        {
            

            var commonPath = $@"..\..\..\Data\marl.example";
            string gsPath = $"{commonPath}.info";
            string tuPath = $@"{commonPath}.tu";
            string crdPath = $@"{commonPath}.crd";


            var groundStationModel = new TextFileReader<Data.Models.GroundStation>(new GroundStation(), ":").Read(gsPath);
            var txtDataReader = new TextFileReader<IEnumerable<double[]>>(new ListValues<double>());
            var mergedMesh = new Mesh(txtDataReader.Read(crdPath))
                .MergeOnUniform(new Mesh(txtDataReader.Read(tuPath)), 10);

            var list = new List<RawPacket>();
            int index = 0;
            foreach (var data in mergedMesh.Data)
            {
                list.Add(new RawPacket()
                {
                    DateTimeUtc = groundStationModel.Time.AddSeconds(data[0]),
                    Coordinates = new SphericalCoordinates(data[1], data[2], data[3]).ConvertTo(groundStationModel),
                    Temperature = data[4],
                    Humidity = data[5],
                    Id = index
                });
                index++;
            }

            var dictValues = list.ToDictionary(l => l.Coordinates.Height, l => l.Temperature);

            var tropopause = new Tropopause(dictValues).Calculate();
            

            //using (StreamWriter sr = new StreamWriter("output.txt"))
            //{
            //    foreach (var dictValue in dictValues)
            //    {
            //        sr.WriteLine($"{dictValue.Key}\t{dictValue.Value}");
            //    }
            //}

            //using (StreamWriter sr = new StreamWriter("output1.txt"))
            //{
            //    foreach (var dictValue in data1)
            //    {
            //        sr.WriteLine($"{dictValue.Key}\t{dictValue.Value}");
            //    }
            //}

            
        }

        //public void Test111()
        //{
            //var services = new ServiceCollection();
            //services.AddTransient<ITxtLinesMapping<GroundStation>, GroundStationFileMapping>();
            //services.AddTransient<ITxtLinesMapping<IEnumerable<double[]>>, ListValuesMapping<double>>();

            //var serviceProvider = services.BuildServiceProvider();

            //matchRepository = serviceProvider.GetService<IMatchRepository>();

            // 1. File Reader text/binary
            // 2.

            //var gsMapping = serviceProvider.GetService<ITxtLinesMapping<GroundStation>>();
            //var lvMapping = serviceProvider.GetService<ITxtLinesMapping<IEnumerable<double[]>>>();


            //var myCart = ActivatorUtilities.CreateInstance<TextFileReader<GroundStation>>(serviceProvider);
        //}

        //[Fact]
        //[DotMemoryUnit(FailIfRunWithoutSupport = true)]
        //public void TestMemory()
        //{
        //    DotMemoryUnitTestOutput.SetOutputMethod(Console.WriteLine);
        //    var memoryCheckPoint = dotMemory.Check();
        //    TestParsingMarl();
        //    dotMemory.Check(memory =>
        //    {
        //        Console.WriteLine(memory
        //            .GetDifference(memoryCheckPoint)
        //            .GetNewObjects()
        //            .SizeInBytes);
        //    });
        //}

        /*
         *public List<RawPacket> Read()
        {
            Coordinates.ReadAllFromFile(CrdFilePath);
            SensorValues.ReadAllFromFile(TuFilePath);
            var result = new List<RawPacket>();

            var temperature = Interpolate.Linear(SensorValues.Keys, SensorValues[1]);
            var humidity = Interpolate.Linear(SensorValues.Keys, SensorValues[2]);

            

            var radialDistance = Interpolate.Linear(Coordinates.Keys, Coordinates[1]);
            var zenithDirection = Interpolate.Linear(Coordinates.Keys, Coordinates[2]);
            var azimuthAngle = Interpolate.Linear(Coordinates.Keys, Coordinates[3]);

            int index = 1;
            var max = Math.Min(Coordinates.Keys.Max(), SensorValues.Keys.Max());
            int step = 10;
            int time = 0;
            while (time<max)
            {
                var packet = new RawPacket
                {
                    Id = index,
                    Coordinates = new SphericalCoordinates(radialDistance.Interpolate(time), 
                        zenithDirection.Interpolate(time), 
                        azimuthAngle.Interpolate(time)),
                    Temperature = temperature.Interpolate(time),
                    Humidity = humidity.Interpolate(time)
                };
                result.Add(packet);
                index++;

                time += step;
            }

           

            return result;
        }
         */
    }
}
