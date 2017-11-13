using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using xNet;


namespace Jack.API
{
    public class Upload
    {
        public static string Photo(string name, string url)
        {
            string text;

            using (var client = new HttpRequest())
            {
                client.AddFile("photo", "name");
            }
            return text;
        }
    }
}
