using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace retrospring_win_universal.Web
{
    abstract class JsonParser
    {
        private string parsedJson
        {
            get;
            set;
        }

        private JsonParser()
        {
            //private constructor on purpose
        }

        public void parseJson(string url, List<string> parameters = null)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string parameterStr = "";
            if (parameters != null)
            {
                parameterStr = "?";
                foreach (string curPar in parameters)
                {
                    parameterStr += curPar + "&";
                }
            }

            HttpResponseMessage response = client.GetAsync(parameterStr).Result;
        }
    }
}
