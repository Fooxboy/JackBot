using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.API;
using Jack.Interfaces;
using Jack.Helpers;
using System.Threading;
using Jack.Commands;

namespace Jack.Render
{
    public class Command
    {
        public void Execute(Update.NewMessage message)
        {
            if (message.ExtraFields.Attach.source_act != null)
            {
                if (message.ExtraFields.Attach.source_act == "chat_title_update")
                {
                    Commands.SaveTitleChat.TriggerEditChat(message);
                }
            }
            string[] arrayTextMessage = Split(message.ExtraFields.Text);
            string name = arrayTextMessage[0].ToLower();
            //TODO: Заменить регуляркой.
            if ((name == "джек") || (name == "jack") || (name == "джек,") || (name == "jack,"))
            {
                var user = new User(message.From);
                bool isUser = user.IsUser;
                if (isUser)
                {
                    if (!user.Ban)
                    {
                        ChoiseCommand(message, arrayTextMessage);
                    }
                }
                else
                {
                    user.New(Enums.Jack.Privileges.User);
                    ChoiseCommand(message, arrayTextMessage);
                }
            }
        }

        private void ChoiseCommand(Update.NewMessage message, string[] array)
        {
            if (array.Length != 1)
            {
                string command = array[1].ToLower();
                List<ICommand> commands = Bot.Commands;
                var result = false;
                foreach (var c in commands)
                {
                    if (c.CanExecute(command))
                    {
                        var model = new RunCommandThread
                        {
                            command = c,
                            arguments = array,
                            message = message
                        };
                        var ThreadCommand = new Thread(new ParameterizedThreadStart(RunRenderCommand));
                        ThreadCommand.Name = "Render Command";
                        ThreadCommand.Start(model);
                        result = true;
                        break;
                    }
                }
                if (!result)
                {
                    API.Message.Send(new Models.MessageSendParams
                    {
                        From = message.From,
                        PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                        Message = Files.Render.NoVoiceModule
                    });
                }
            }
            else
            {
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = Files.Render.NoCommand
                });
            }
        }

        private static void RunRenderCommand(object response)
        {
            var model = (RunCommandThread)response;
            var message = model.message;
            var array = model.arguments;
            model.command.Execute(message, array);
        }

        private string[] Split(string message)
        {
            string[] response = message.Split(' ');
            return response;
        }
    }

    public class RunCommandThread
    {
        public ICommand command { get; set; }
        public Update.NewMessage message { get; set; }
        public string[] arguments { get; set; }
    }
}
