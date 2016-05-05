using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Reflection;

namespace TwitterConnector.WebAPI.Controllers
{
    public class KeyWordsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var ret = new KeyValuePair<string, string>("key", "value");
            //File.ReadAllText(Path.Combine(Assembly.GetExecutingAssembly().Location,"KeyWords.txt"));
            return Request.CreateResponse(HttpStatusCode.OK, ret);
        }
    }
}
