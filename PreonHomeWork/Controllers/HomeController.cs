using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;


namespace PreonHomeWork.Controllers
{
    public class HomeController : Controller
    {   
        public IActionResult Index()
        {
            var cities = new Dictionary<int, string>();
            cities.Add(2343732, "Ankara");
            cities.Add(44418, "London");
            cities.Add(2487956, "San Francisco");
            cities.Add(2344116, "İstanbul");
            cities.Add(2459115, "New York");
            cities.Add(2442047, "Los Angeles");      
            return View(cities);        
        }   
        [HttpGet]
        public object GetWeather(string cityId,DateTime date)
        {
            try
            {
                string dateText="";
                if (date!=DateTime.MinValue)
                {
                    dateText = $"{date.Year}/{date.Month}/{date.Day}";
                }         
                if (cityId != null)
                {
                    WebRequest SiteyeBaglantiTalebi = HttpWebRequest.Create("https://www.metaweather.com/api/location/" + $"{cityId}"+"/"+$"{dateText}");
                    WebResponse GelenCevap = SiteyeBaglantiTalebi.GetResponse();
                    StreamReader CevapOku = new StreamReader(GelenCevap.GetResponseStream());
                    string KaynakKodlar = CevapOku.ReadToEnd();
                    var jsonveri = JsonConvert.DeserializeObject(KaynakKodlar);  
                    
                    return KaynakKodlar;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }




    }
}
