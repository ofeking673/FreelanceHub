using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Serializer;
using AlexProject.ViewModels;
using System.Net;

namespace WebApplication2.WebApp.WebControllers
{
    public class AdsController : Controller
    {

        public IActionResult StartPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAdHub(string theme ="None", int page = 0)
        {
            WebService<AdHub> client = new WebService<AdHub>()
            {
                Server = "https://localhost:7159/api",
                Controller = "Guest",
                Method = "getAds"
            };
            client.AddKeyValue("theme", theme);
            client.AddKeyValue("page", page.ToString());
            Console.WriteLine(client.getUrl());
            //http://localhost:7159/api/Guest/getAds?theme=None
            AdHub adHub = new AdHub();
            try
            {
                adHub = client.Get();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(adHub);
        }
    }
}
