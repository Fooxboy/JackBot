using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using System.IO;
using Newtonsoft.Json;
using Jack.Interfaces;
using Jack.Exception.Commands;

namespace Jack.Commands
{
    //TODO: Закончить работу с промокодами.
    public  class Promocode :ICommand
    {
        public string Name => "Промокод";
        public string Help => "помощь";
        public void Execute(Update.NewMessage message, string[] arguments)
        {
            throw new CommandIsNotWorked();

            if(arguments.Length >= 3)
            {
                string command = arguments[2];
                switch(command.ToLower())
                {
                    case "активировать":
                        break;
                    case "сгенерировать":
                        break;
                    case "создать":
                        break;
                    default:
                        break;
                }
            }
        }

        private static string Activate(string code, string from)
        {
            string text;
            string json;
            using (StreamReader sr = new StreamReader($"promocods.json", Encoding.Default))
            {
                json = sr.ReadToEnd();
            }
            var model = JsonConvert.DeserializeObject<Models.Promocods>(json);

            bool value;
            for(int i=0; model.Cods.Count < i; i++)
            {
                if(model.Cods[i].Code == code)
                {
                    value = true;
                    if(model.Cods[i].Type == Enums.Models.TypePromocode.Privileges)
                    {
                        Enums.Jack.Privileges zh = (Enums.Jack.Privileges)model.Cods[i].Value;
                    }else if(model.Cods[i].Type == Enums.Models.TypePromocode.Foxs)
                    {
                        //фоксы.
                    }
                }else
                {
                    value = false;
                }
            }

            return "";

        }

        private static string Generate(string[] arguments)
        {
            return "";

        }

        private static string Create()
        {
            File.Create("promocods.json");
            return "Complete!!!";
        }
    }
}
