//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using SmsIrRestful;

//public class UTLSmsIr
//{
//    public string GetToken()
//    {
//        TokenInformation tk = new TokenInformation();
//        String userApikey = tk.UserApikey();
//        String secretKey = tk.SecretKey();
//        return new Token().GetToken(userApikey, secretKey);
//    }

//    public void MessageSend()
//    {
//        var token = GetToken();

//        if (string.IsNullOrEmpty(token))
//            throw new Exception(@"{nameof(token) } is null");

//        var messageSendObject = new MessageSendObject()
//        {
//            Messages = new List<string> { "تست" }.ToArray(),
//            MobileNumbers = new List<string> { "09305635067" }.ToArray(),
//            LineNumber = "300021",
//            SendDateTime = null,
//            CanContinueInCaseOfError = true
//        };

//        MessageSendResponseObject messageSendResponseObject = new MessageSend().Send(token, messageSendObject);

//        if (messageSendResponseObject == null)
//            throw new Exception(@"{nameof(messageSendResponseObject) } is null");



//        if (messageSendResponseObject.IsSuccessful)
//        {


//        }
//        else
//        {

//        }

//    }




//    public void GetSentMessageByDate()
//    {

//        var token = GetToken();

//        if (string.IsNullOrEmpty(token))
//            throw new Exception(@"{nameof(token) } is null");

//        SentMessageResponseByDate sentMessageResponseByDate = new MessageSend().GetByDate(token, "1396/04/01", "1396/04/31", 10, 1);
//        if (sentMessageResponseByDate == null)
//            throw new Exception(@"{nameof(sentMessageResponseByDate) } is null");

//        if (sentMessageResponseByDate.IsSuccessful)
//        {

//        }
//        else
//        {

//        }

//    }




//    public void GetSentMessageById()
//    {
//        var token = GetToken();

//        if (string.IsNullOrEmpty(token))
//            throw new Exception(@"{nameof(token) } is null");

//        SentMessageResponseById messageSendResponseById = new MessageSend().GetById(token, 5643981);

//        if (messageSendResponseById.IsSuccessful)
//        {

//        }
//        else
//        {

//        }
//    }

//}