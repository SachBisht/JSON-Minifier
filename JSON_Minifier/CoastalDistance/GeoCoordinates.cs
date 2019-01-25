using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Runtime.Serialization;

namespace CoastalDistance
{
    class GeoCoordinates : Coordinate
    {
        public static void GetCoordinates()
        {

            Coordinate coordinate = new Coordinate();

            List<string> subCoordinates = new List<string>();
            var subSubCoordinates = new List<List<string>>();

            //For JSON READING
            using (StreamReader file = File.OpenText(@"D:\Southeast_Caribbean_1.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject obj = JObject.Load(reader);
                dynamic data = JObject.Parse(obj.ToString());
                for (int j = 0; j < data.features.Count; j++)
                {
                    for (int i = 0; i < data.features[j].geometry["coordinates"].Count;)
                    {
                        double latCoordinate = (double)(data.features[j].geometry["coordinates"][i][1]);
                        double longCoordinate = (double)(data.features[j].geometry["coordinates"][i][0]);
                        subCoordinates.Add(latCoordinate.ToString());
                        subCoordinates.Add(longCoordinate.ToString());
                        if(data.features[j].geometry["coordinates"].Count>20)
                        {
                            i = i + 5;
                        }
                        else
                        {
                            i = i + 2;
                        }
                    }

                }
                subSubCoordinates.Add(subCoordinates);
                coordinate.Coordinates = subSubCoordinates;

                BinaryFormatter formatter = new BinaryFormatter();
                StreamWriter sw = new StreamWriter(@"D:\path.json");
                JsonSerializer jsonSerializer = JsonSerializer.Create();
                jsonSerializer.Serialize(sw,coordinate.Coordinates);
                sw.Close();
                

                //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                //javaScriptSerializer.MaxJsonLength = 999999999;
                //string jsondata = javaScriptSerializer.Serialize(coordinate);
                //System.IO.File.WriteAllText(@"D:\path.json", jsondata);
                Console.WriteLine("Done!!");
            }
        }
    }

}

///Previous One
///
//public static void GetCoordinates()
//{

//    //FOR JSON WRITING

//    Coordinate coordinate = new Coordinate();

//    List<string> subCoordinates = new List<string>();
//    var subSubCoordinates = new List<List<string>>();

//    string json = "";

//    //For JSON READING
//    using (StreamReader file = File.OpenText(@"D:\SBisht\Coastline_Project\Info\Coastline_CoordinateValues.json"))
//    using (JsonTextReader reader = new JsonTextReader(file))
//    {
//        JObject obj = JObject.Load(reader);
//        dynamic data = JObject.Parse(obj.ToString());
//        string startsAs = "{\"Coordinates\":[";
//        subCoordinates.Add(startsAs);
//        for (int j = 0; j < data.geometries.Count; j++)
//        {
//            for (int i = 0; i < data.geometries[j].coordinates.Count; i++)
//            {
//                double latCoordinate = (double)(data.geometries[j].coordinates[i][1]);
//                double longCoordinate = (double)(data.geometries[j].coordinates[i][0]);

//                string temp = "[" + longCoordinate + "," + latCoordinate + "]";
//                subCoordinates.Add(temp);



//            }

//        }
//        string endsAs = "]}";
//        subCoordinates.Add(endsAs);
//        subSubCoordinates.Add(subCoordinates);
//        string jsondata = new JavaScriptSerializer().Serialize(coordinate);
//        json = JsonConvert.SerializeObject(subSubCoordinates.ToArray());
//        System.IO.File.WriteAllText(@"D:\path.json", json);
//        Console.WriteLine("Done!!");