using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Documents;

namespace HangmanApplication
{
    public static class DataProvider
    {
        public static string GetRandomWord()
        {
            string response;
            string uri = string.Format("https://random-word-api.herokuapp.com/word?number=1");

            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.Method = "GET";
            HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
            using (Stream stream = httpWebResponse.GetResponseStream())
            {
                StreamReader streamReader = new StreamReader(stream);
                response = streamReader.ReadToEnd();
                streamReader.Close();
            }

            return response.Trim('[', ']', '"').ToUpper();
        }
    }
}
