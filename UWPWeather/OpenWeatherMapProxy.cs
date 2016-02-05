﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace UWPWeather
{
    public class OpenWeatherMapProxy
    {

        //Task<RootObject> once task is finished RootObject will be returned
        public async static Task<RootObject> GetWeather(double lat, double lon)
        {
            var http = new HttpClient();

            //var url = String.Format("http://api.openweathermap.org/data/2.5/weather?lat=58.3698&lon=26.7612&units=metric&appid=44db6a862fba0b067b1930da0d769e98");

            //bad call for test
            //var url = String.Format("http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units=metric", lat, lon);

            var url = String.Format("http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units=metric&appid=44db6a862fba0b067b1930da0d769e98", lat, lon);

            var response = await http.GetAsync(url);

            //string "result" will be returned as a response to http.GetAsync call
            var result = await response.Content.ReadAsStringAsync();

            //Sets up serializer that will prepare RootObject
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            //Vehicle to acquire string "result" 
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));

            //Rootobject to be returned after serialization of memory stream ms
            var data = (RootObject)serializer.ReadObject(ms);

            return data;

        }
    }

    [DataContract]
    public class Coord
    {
        [DataMember]
        public double lon { get; set; }
        [DataMember]
        public double lat { get; set; }
    }

    [DataContract]
    public class Weather
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string main { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string icon { get; set; }
    }

    [DataContract]
    public class Main
    {
        [DataMember]
        public double temp { get; set; }
        [DataMember]
        public double pressure { get; set; }
        [DataMember]
        public int humidity { get; set; }
        [DataMember]
        public double temp_min { get; set; }
        [DataMember]
        public double temp_max { get; set; }
        [DataMember]
        public double sea_level { get; set; }
        [DataMember]
        public double grnd_level { get; set; }
    }

    [DataContract]
    public class Wind
    {
        [DataMember]
        public double speed { get; set; }
        [DataMember]
        public int deg { get; set; }
    }

    //[DataContract]
    //public class Rain
    //{
    //    public double __invalid_name__3h { get; set; }
    //}

    [DataContract]
    public class Clouds
    {
        [DataMember]
        public int all { get; set; }
    }

    [DataContract]
    public class Sys
    {
        [DataMember]
        public double message { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public int sunrise { get; set; }
        [DataMember]
        public int sunset { get; set; }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public Coord coord { get; set; }
        [DataMember]
        public List<Weather> weather { get; set; }
        [DataMember]
        public string @base { get; set; }
        [DataMember]
        public Main main { get; set; }
        [DataMember]
        public Wind wind { get; set; }
        //[DataMember]
        //public Rain rain { get; set; }
        [DataMember]
        public Clouds clouds { get; set; }
        [DataMember]
        public int dt { get; set; }
        [DataMember]
        public Sys sys { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int cod { get; set; }
    }

}