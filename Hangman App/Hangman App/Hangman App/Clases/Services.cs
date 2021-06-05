using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Hangman_App.Entidades;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hangman_App.Clases
{
    public static class Services
    {
        public static List<SecretWord> GetSecretWordsService(int cantPalabras)
        {
            string url = $"http://10.0.2.2:5001/hangman/api/v1.0/match/{cantPalabras}";

            string resultado = GetPost(url);

            var model = JsonConvert.DeserializeObject<List<SecretWord>>(resultado.ToString());

            return model;
        }

        public static string GetPost(string url)
        {
            WebRequest request = WebRequest.Create(url);

            request.Method = "GET";

            var httpResponse = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
