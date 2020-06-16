using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Processing;
using Data.Reader;
using Data.Reader.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GroundStation = Data.Reader.Mapping.GroundStation;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        [HttpPost]
        public ActionResult<List<RawPacket>> Post()
        {
            if (!Request.HasFormContentType) 
                return BadRequest();
            
            
            Data.Models.GroundStation groundStationModel = null;
            Mesh tuMesh = null;
            Mesh crdMesh = null;
            Mesh mergedMesh = null;

            var list = new List<RawPacket>();
            foreach (IFormFile file in Request.Form.Files.Where(f=>f.Length>0).ToList())
            {
                
                var name = file.Name;
                using (var reader = file.OpenReadStream())
                {
                    switch (name)
                    {

                        case "info":
                            groundStationModel = new TextFileReader<Data.Models.GroundStation>(new GroundStation(), ":").Read(reader);
                            break;
                        case "tu":
                            tuMesh = new Mesh(new TextFileReader<IEnumerable<double[]>>(new ListValues<double>())
                                .Read(reader)); 
                            break;
                        case "crd":
                            crdMesh = new Mesh(new TextFileReader<IEnumerable<double[]>>(new ListValues<double>())
                                .Read(reader));
                            break;
                    }
                }
                    
            }

            if (crdMesh != null && tuMesh != null) 
                mergedMesh = crdMesh.MergeOnUniform(tuMesh, 10);

            if (groundStationModel != null && mergedMesh != null)
            {
                int index = 0;
                foreach (var data in mergedMesh.Data)
                {
                    GeoCoordinates cordinates = null;
                    if (index == 0)
                    {
                        cordinates = new GeoCoordinates(groundStationModel.Latitude
                            , groundStationModel.Longitude
                            , groundStationModel.Height);
                    }
                    else
                    {
                        cordinates =
                            new SphericalCoordinates(data[1], data[2], data[3]).ConvertTo(groundStationModel);
                    }

                    list.Add(new RawPacket()
                    {
                        DateTimeUtc = groundStationModel.Time.AddSeconds(data[0]),
                        Coordinates = cordinates,
                        Temperature = data[4],
                        Humidity = data[5],
                        Id = index
                    });
                    index++;
                }
            }

            return Ok(list);

        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }

    public class TestModel {
        public string Id { get; set; }
    }
}