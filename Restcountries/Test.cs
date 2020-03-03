using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Restcountries.CommonMethods;
using Restcountries.Services;
using RestSharp;

namespace Restcountries
{
    [TestFixture]
    [Parallelizable]
    public class Test : Methods
    {
        [Test]
        public void TestAltSpellings()
        {
            Countries countries = new Countries();
            var response = countries.getCountryInfo("true");
            Assert.IsTrue(response.IsSuccessful, "Response isn't success");

            var acceptedList = new List<string>()
            {
                "TR",
                "Turkiye",
                "Republic of Turkey",
                "Türkiye Cumhuriyeti"
            };
            var altSpellings = GetArrayFromResponse(response, "altSpellings");

            var firstNotSecond = acceptedList.Except(altSpellings).ToList();
            var secondNotFirst = altSpellings.Except(acceptedList).ToList();
            Assert.IsTrue(!firstNotSecond.Any());
            Assert.IsTrue(!secondNotFirst.Any());
        }

        [Test]
        public void TestNames()
        {
            Countries countries = new Countries();
            var response = countries.getCountryInfo("true");
            Assert.IsTrue(response.IsSuccessful, "Response isn't success");

            var acceptedNames = new List<string>()
            {
                "Turkey"
            };
            var names = GetStringFromResponse(response, "name");

            var firstNotSecond = acceptedNames.Except(names).ToList();
            var secondNotFirst = names.Except(acceptedNames).ToList();

            Assert.IsTrue(!firstNotSecond.Any());
            Assert.IsTrue(!secondNotFirst.Any());
        }

        [Test]
        public void TestCurrencies()
        {
            Countries countries = new Countries();
            var response = countries.getCountryInfo("true");
            Assert.IsTrue(response.IsSuccessful, "Response isn't success");

            JsonArray currenciesArray = new JsonArray();
            JObject rss = new JObject(
                            new JProperty("code", "TRY"),
                            new JProperty("name", "Turkish lira"),
                            new JProperty("symbol", null)
                                );
            currenciesArray.Add(rss);

            var currencies = GetDictionaryFomResponse(response, "currencies");


            for (int i = 0; i < currenciesArray.Count; i++)
            {
                Assert.AreEqual(currenciesArray[i], currencies[i]);
            }
        }

        [Test]
        public void TestArea()
        {
            Countries countries = new Countries();
            var response = countries.getCountryInfo("true");
            Assert.IsTrue(response.IsSuccessful, "Response isn't success");

            var acceptedArea = new List<double>()
            {
                783562.0
            };
            
            var area = GetDecimalPropertyFromResponse(response, "area");

            for (int i = 0; i < acceptedArea.Count; i++)
            {
                Assert.AreEqual(acceptedArea[i], area[i]);
            }
        }
    }
}
