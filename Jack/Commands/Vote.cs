using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using System.IO;
using Jack.Models;


namespace Jack.Commands
{
    public static class Vote
    {
        public static void Start(Update.NewMessage message, string[] arguments)
        {
            string text = "Ошибка.";
            if(arguments.Length >= 3)
            {
                string command = arguments[2];
                if(arguments.Length >= 4)
                {
                    
                    switch (command.ToLower())
                    {
                        case "создать":
                            string comment = "";
                            for (int i = 3; arguments.Length < i; i++)
                            {
                                comment += $"{arguments[i]} ";
                            }
                            text = Create(message.From,comment, message.ExtraFields.PeerId);
                            break;
                        case "вариант":
                            string variant = "";
                            for (int i = 3; arguments.Length < i; i++)
                            {
                                variant += $"{arguments[i]} ";
                            }
                            text = AddAnswer(variant, message.ExtraFields.PeerId, message.From);
                            break;
                        case "за":
                            string value = arguments[3];
                            text = Behind(value, message.ExtraFields.PeerId);
                            break;
                        case "конец":
                            text = End(message.ExtraFields.PeerId, message.From);
                            break;
                        case "начало":
                            text = Start(message.ExtraFields.PeerId, message.From);
                            break;
                        case "сейчас":
                            text = Now(message.ExtraFields.PeerId);
                            break;
                        default:
                            text = Files.Commands.Vote.NotCommand;
                            break;
                    }
                }
                else
                {
                    text = Files.Commands.Vote.NoComment;
                }
            }else
            {
                    text = Files.Commands.Vote.NoCommand;
            }

            API.Message.Send(new Models.MessageSendParams
            {
                From = message.From,
                PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                Message = text
            });
        }

        private static string Create(string from, string comment, string peer_id)
        {
            string text;
            var user = new API.User(from);
            if(user.Privileges != Enums.Jack.Privileges.User)
            {
                long chatid = API.Convert.PeerIdToChatId(peer_id);
                if (!File.Exists($@"votes\{chatid}.json"))
                {
                    if (!Directory.Exists("votes"))
                    {
                        Directory.CreateDirectory("votes");
                    }
                    File.Create($@"votes\{chatid}.json");
                    var model = new VoteModel();
                    model.Name = comment;
                    model.From = from;
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    using (StreamWriter sw = new StreamWriter($@"votes\{chatid}.json", false, Encoding.Default))
                    {
                        sw.WriteLine(json);
                    }
                    text = Files.Commands.Vote.Complete;
                }
                else
                {
                    text = Files.Commands.Vote.VoteReady;
                }
            }else
            {
                text = Files.Commands.Vote.NoAccess;
            }
            return text;
        }

        private static string AddAnswer(string answer, string peer_id, string from)
        {
            string text;
            long chatid = API.Convert.PeerIdToChatId(peer_id);

            if(File.Exists($@"votes\{chatid}.json"))
            {
                string json;
                using (StreamReader sr = new StreamReader($@"votes\{chatid}.json", Encoding.Default))
                {
                    json = sr.ReadToEnd();
                }
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<VoteModel>(json);
                if(model.From == from)
                {
                    model.AnswersOptions.Add(answer);
                    model.Answers.Add(0);
                    string jsonNew = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    using (StreamWriter sw = new StreamWriter($@"votes\{chatid}.json", false, Encoding.Default))
                    {
                        sw.WriteLine(jsonNew);
                    }
                    text = Files.Commands.Vote.AddedAnswer;
                }else
                {
                    text = Files.Commands.Vote.NoCreator;
                }   
            }
            else
            {
                text = Files.Commands.Vote.NoVote;
            }
            return text;
        }

        public static string Behind(string answer, string peer_id)
        {
            string text;
            long chatid = API.Convert.PeerIdToChatId(peer_id);
            if (File.Exists($@"votes\{chatid}.json"))
            {
                string json;
                using (StreamReader sr = new StreamReader($@"votes\{chatid}.json", Encoding.Default))
                {
                    json = sr.ReadToEnd();
                }
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<VoteModel>(json);
                int variant = System.Convert.ToInt32(answer);
                model.Answers[variant]++;
                string jsonNew = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                using (StreamWriter sw = new StreamWriter($@"votes\{chatid}.json", false, Encoding.Default))
                {
                    sw.WriteLine(jsonNew);
                }
                text = Files.Commands.Vote.AddBehid;
            }
            else
            {
                text = Files.Commands.Vote.NoVote;
            }
            return text;
        }

        public static string End(string peer_id, string from)
        {
            string text;
            long chatid = API.Convert.PeerIdToChatId(peer_id);

            var user = new API.User(from);
            if(user.Privileges != Enums.Jack.Privileges.User)
            {
                if (File.Exists($@"votes\{chatid}.json"))
                {
                    string json;
                    using (StreamReader sr = new StreamReader($@"votes\{chatid}.json", Encoding.Default))
                    {
                        json = sr.ReadToEnd();
                    }
                    var model = Newtonsoft.Json.JsonConvert.DeserializeObject<VoteModel>(json);
                    File.Delete($@"votes\{chatid}.json");
                    text= Files.Commands.Vote.CompleteEnd(model);
                }
                else
                {
                    text = Files.Commands.Vote.NoVote;
                }
            }else
            {
                text = Files.Commands.Vote.NoAccess;

            }
            return text;
        }

        public static string Start(string peer_id, string from)
        {
            string text;
            long chatid = API.Convert.PeerIdToChatId(peer_id);

            var user = new API.User(from);
            if (user.Privileges != Enums.Jack.Privileges.User)
            {
                if (File.Exists($@"votes\{chatid}.json"))
                {

                    text = Files.Commands.Vote.CompleteStart;
                }
                else
                {
                    text = Files.Commands.Vote.NoVote;
                }
            }
            else
            {
                text = Files.Commands.Vote.NoAccess;

            }
            return text;
        }

        public static string Now(string peer_id)
        {
            string text;
            long chatid = API.Convert.PeerIdToChatId(peer_id);
            if (File.Exists($@"votes\{chatid}.json"))
            {
                string json;
                using (StreamReader sr = new StreamReader($@"votes\{chatid}.json", Encoding.Default))
                {
                    json = sr.ReadToEnd();
                }
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<VoteModel>(json);
                text = Files.Commands.Vote.CompleteNow(model);
            }
            else
            {
                text = Files.Commands.Vote.NoVote;
            }
            return text;
        }
    }
}
