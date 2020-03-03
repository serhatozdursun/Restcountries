using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Extensions;

namespace Restcountries.Services
{   
    
    public class Countries
    {
        public IRestResponse getCountryInfo(string isFullText) { 

            RestClient client = new RestClient("https://restcountries.eu");
            IRestRequest request = new RestRequest("/rest/v2/name/turkiye");
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("fullText", isFullText);
            return client.Execute(request);
        }
    }
}
