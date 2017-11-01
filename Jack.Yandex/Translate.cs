using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;


namespace Jack.Yandex
{
    public class Translate
    {

        public string Start(string text, string language)
        {
            string json = Request(text, language);
            var model = JsonConvert.DeserializeObject<Models.Yandex.Translate>(json);
            int code = model.code;
            string response;
            switch (code)
            {
                case 200:
                    response = model.text[0];
                    break;
                case 401:
                    response = "Неправильный API ключ.";
                    break;
                case 402:
                    response = "API ключ был заблокирован.";
                    break;
                case 404:
                    response = "Привышено количество трафика на сегодня.";
                    break;
                case 413:
                    response = "Текст слишком большой.";
                    break;
                case 422:
                    response = "Внутренняя ошибка сервера. Текст не может быть переведён. Попробуйте позже.";
                    break;
                case 501:
                    response = "Язык был выбран не верно.";
                    break;
                default:
                    response = "Неизвестная ошибка перевода. Попробуйте позже.";
                    break;
            }

            return response;
        }

        private string Request(string text, string lang)
        {
            WebClient client = new WebClient();
            string token = "trnsl.1.1.20170920T160548Z.c18aab71890aa273.817c05a99b4f32d62bda3e04f3ab886d8c1f84f4";
            var url = $"https://translate.yandex.net/api/v1.5/tr.json/translate?key={token}&text={text}&lang={lang}&format=plain&options=0";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            return json;
        }
    }
}
