using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using RestSharp.Extensions;

namespace Restcountries.CommonMethods
{
    public class Methods
    {
        public List<string> GetArrayFromResponse(IRestResponse restResponse, string propertyName)
        {

            var jArray = JArray.Parse(restResponse.Content);
            var result = new List<string>();
            foreach (var json in jArray)
            {
                JObject jobject = JObject.Parse(json.ToString());
                result.AddRange(jobject.GetValue(propertyName).ToObject<List<string>>());
            }
            return result;
        }

        public List<string> GetStringFromResponse(IRestResponse restResponse, string propertyName)
        {

            var jArray = JArray.Parse(restResponse.Content);
            var result = new List<string>();
            foreach (var json in jArray)
            {
                JObject jobject = JObject.Parse(json.ToString());
                result.Add(jobject.GetValue(propertyName).ToString());
            }
            return result;
        }

        public JsonArray GetDictionaryFomResponse(IRestResponse restResponse, string propertyName)
        {
            var jArray = JArray.Parse(restResponse.Content);
            foreach (var json in jArray)
            {
               JObject jobject = JObject.Parse(json.ToString());
               return jobject.GetValue(propertyName).ToObject<JsonArray>();
            }
            return null;
        }

        public List<double> GetDecimalPropertyFromResponse(IRestResponse restResponse, string propertyName)
        {
            var jArray = JArray.Parse(restResponse.Content);
            var areaList = new List<double>();
            foreach (var json in jArray)
            {
                JObject jobject = JObject.Parse(json.ToString());
                areaList.Add(Convert.ToDouble(jobject.GetValue(propertyName).ToString()));
            }
            return areaList;
        }
    }
}
