using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Net;

namespace MirkoBrute
{
    class WebRequests
    {
        public String response;
        //FIXME: Сделать TryLogIn async классом
        public static string TryLogIn(string login, string password)
        {
            var request = WebRequest.Create("https://mirkomir.com/script/login");
            request.Method = "POST";
            string data = "login="+login+"&pass="+password+"&remember=true";
            Byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
