using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Facebook;


namespace FBAlert
{
    /// <summary>
    ///FBAlerter 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class FBAlerter : System.Web.Services.WebService
    {
        string FBToken = System.Configuration.ConfigurationManager.AppSettings["FBUserAccessToken"];
        string FBGroupID = System.Configuration.ConfigurationManager.AppSettings["FBGroupID"];

    
        [WebMethod]
        public string HelloFB()
        {
            return "Hello FB";
        }

        [WebMethod(Description = "發送AlertMessage To Facebook")]
        public string FBAlert(string System ,string MessageCata ,string AlertMessage ,string Priority)
        {
            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo kstZone = TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time");
            DateTime kstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, kstZone);

            string GroupID = "";
            //GroupID = "1814237745469656"; //FunpachiPK_Alert
            //GroupID = "652980441505762"; //Funpachi_Alert only Ian Lee
            //GroupID = "822468034542393"; //FTAlertGroup
            GroupID = FBGroupID; //FTAlertGroup

            //String strShowHRListadmin = System.Configuration.ConfigurationManager.AppSettings["HR-Leave-list-Admin"];
            // string strShowHRListadmin =  System.Web.Configuration.WebConfigurationManager.AppSettings["folder_new"];
            //var client = new FacebookClient("CAAP1OwwdkPMBAPk1TEreZA2LhOe82dryQfNWde3eHSJDq1nVtS7QhBvo7QFJAaYBo3srs36b8LL4oI9gfFEokLgiozeleVj32oGWaDZC2cpoqsbIMTVZBzXWFmBTkiz9pGtMyIGhqUa1SGoyIQHQaiPK20V4o8EVAQVpOrDZBKZCbaAXyu1RuAV12aHdSvYIZD");
            var client = new FacebookClient(FBToken);
            //client.Post("/1814237745469656/feed", new { message = "[訊息類別]:" + MessageCata + "\n" + "[訊息]:" + AlertMessage });
            //client.Post("/" + GroupID + "/feed", new { message = "[訊息類別]:" + MessageCata + "\n" + "[訊息]:" + AlertMessage + "\n" + "[時間]:" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") });
            //client.Post("/" + GroupID + "/feed", new { message = "[系統]:" + System + "\n" + "[訊息類別]:" + MessageCata + "\n" + "[訊息]:" + AlertMessage + "\n" + "[層級]:" + Priority + "\n" + "[時間]:" + kstTime.ToString() });
            client.Post("/" + GroupID + "/feed", new { message = "[時間]:" + kstTime.ToString() + "\n\n" + "[事件]:\n" + System + "\n\n" + "[訊息]:\n" + MessageCata + "\n\n"});
            return "已發送至Facebook!";
        }
    }
}




//using Facebook;
//        [TestMethod]
//public void Post_to_the_wall()
//{

//    var client = new FacebookClient(token);
//    dynamic parameters = new ExpandoObject();
//    parameters.message = "Check out this funny article";
//    parameters.link = "http://www.example.com/article.html";
//    parameters.picture = "http://www.example.com/article-thumbnail.jpg";
//    parameters.name = "Article Title";
//    parameters.caption = "Caption for the link";
//    parameters.description = "Longer description of the link";
//    parameters.actions = new
//    {
//        name = "View on Zombo",
//        link = "http://www.zombo.com",
//    };
//    parameters.privacy = new
//    {
//        value = "ALL_FRIENDS",
//    };

//    dynamic result = client.Post("me/feed", parameters);

//    // TODO: NOW, delete the post ???
//}