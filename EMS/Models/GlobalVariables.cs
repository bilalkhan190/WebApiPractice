using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace EMS.Models
{
    public static class GlobalVariables
    {
        public static HttpClient httpClient = new HttpClient();

        static GlobalVariables()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44319/api/");
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}