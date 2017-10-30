using System;
using System.Collections.Generic;
using System.Text;
using Jack.Exception.LongPoll;


namespace Jack.LongPoll
{
    public static class GetModelLongPoll
    {
        public static ResponseModelLongPoll Start(string code, List<object> longPoll)
        {
            int new_code = Convert.ToInt32(code);
            switch(new_code)
            {
                case 4:
                    var model = new Models.LongPoll.Update.NewMessage();
                    model.MessageId = longPoll[1].ToString();
                    model.Flags = longPoll[2].ToString();
                    model.ExtraFields = GetModelExtraFields.Start(longPoll);
                    ResponseModelLongPoll response = new ResponseModelLongPoll();
                    response.Type = typeof(Models.LongPoll.Update.NewMessage);
                    response.Result = model;
                    return response;
                default:
                    throw new CodeNotFound();

            }
        }
    }

    public class ResponseModelLongPoll
    {
        public Type Type { get; set; }
        public object Result { get; set; }
    }
}
