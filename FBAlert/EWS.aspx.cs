using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Exchange.WebServices;
using Microsoft.Exchange.WebServices.Data;
using System.Threading;


namespace FBAlert
{
    public partial class EWS : System.Web.UI.Page
    {
        public FolderId target;

        public string account = System.Configuration.ConfigurationManager.AppSettings["account"];
        public string pw = System.Configuration.ConfigurationManager.AppSettings["pw"];
        public string domain = System.Configuration.ConfigurationManager.AppSettings["domain"];
        public string mailbox = System.Configuration.ConfigurationManager.AppSettings["mailbox"];


        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlConnectionString = System.Configuration.ConfigurationManager.AppSettings["FBUserAccessToken"];
            ////Ian--取得未讀郵件
            //string unreadMailCount = getEmailCount(Session["outlookid"].ToString(), Session["outlookpw"].ToString(), "giga", userinfo.GetMailAccount());
            //string mailbox = "ian.lee@gigamedia.com.tw";
            //int unreadMailCount = getEmailCount("ian", "qwer!23", "giga", mailbox);
            //int unreadMailCount = getEmailCount(account, pw, domain, mailbox);
            //Response.Write(unreadMailCount);

            IterateAndParseMails(account, pw, domain, mailbox);
            //IterateAndParseMails("ian", "qwer!23", "giga", mailbox);
            
        }


        //Outlook信箱未讀信件 
        private int getEmailCount(string account, string pass, string domain, string mailbox)
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
            service.Credentials = new WebCredentials(account, pass, domain);
            service.AutodiscoverUrl(mailbox);

            int unreadCount = 0;

            FolderView viewFolders = new FolderView(int.MaxValue);
            viewFolders.Traversal = FolderTraversal.Deep;
            viewFolders.PropertySet = new PropertySet(BasePropertySet.IdOnly);
            ItemView viewEmails = new ItemView(int.MaxValue);
            viewEmails.PropertySet = new PropertySet(BasePropertySet.IdOnly);
            SearchFilter unreadFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));

            FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, unreadFilter, viewEmails);
            unreadCount += findResults.TotalCount;

            FindFoldersResults inboxFolders = service.FindFolders(WellKnownFolderName.Inbox, viewFolders);

            foreach (Folder folder in inboxFolders.Folders)
            {
                findResults = service.FindItems(folder.Id, unreadFilter, viewEmails);
                unreadCount += findResults.TotalCount;
            }

            return unreadCount;
        }

       
        public void IterateAndParseMails(string account, string pass, string domain, string mailbox)
        {
            ServiceReference2.FBAlerterSoapClient AlertMessage = new ServiceReference2.FBAlerterSoapClient();
            //AlertMessage.FBAlert(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text);
            //Response.Write("<font color='Red'>已發送至Facebook Group</font>");


            ExchangeService exchangeService = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
            exchangeService.Credentials = new WebCredentials(account, pass, domain);
            exchangeService.AutodiscoverUrl(mailbox);

            FindItemsResults<Item> findJunkMails = exchangeService.FindItems(WellKnownFolderName.JunkEmail, new ItemView(int.MaxValue));

            FindItemsResults<Item> findInBoxMails = exchangeService.FindItems(WellKnownFolderName.Inbox, new ItemView(int.MaxValue));

            //Console.WriteLine("Moving junk mails to Inbox");


            //SetView
            FolderView view = new FolderView(100);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
            view.PropertySet.Add(FolderSchema.DisplayName);
            view.Traversal = FolderTraversal.Deep;
            FindFoldersResults findFolderResults = exchangeService.FindFolders(WellKnownFolderName.Inbox, view);
            //find specific folder
            //piblic FolderId target; 
            foreach (Folder f in findFolderResults)
            {
                //show folderId of the folder "XXX"
                if (f.DisplayName == "Sent2Facebook")
                    //Console.WriteLine(f.Id);
                    target = f.Id;
            }


            foreach (Item item in findInBoxMails.Items)    //DEV Mail進件 Outlook郵件規則先送JunkMails,呼叫Chrome ,POST FB&回送InBox
            //foreach (Item item in findInBoxMails.Items) //PRD
            {
                //HTML format
                //ExtendedPropertyDefinition HtmlBodyProperty = new ExtendedPropertyDefinition(0x1013, MapiPropertyType.Binary);
                //PropertySet propertySet = new PropertySet(BasePropertySet.FirstClassProperties, HtmlBodyProperty);

                //Plain-Text
                PropertySet propertySet = new PropertySet(BasePropertySet.FirstClassProperties);
                propertySet.RequestedBodyType = BodyType.Text;

                // Bind to the message by using the property set.
                EmailMessage message = EmailMessage.Bind(exchangeService, item.Id, propertySet);

                string subject = message.Subject;
                string body = message.Body.Text;
                AlertMessage.FBAlert(subject, body, "" , "");

                Response.Write("5秒...");
                Thread.Sleep(5000);  //間隔5秒 因避免被FB封鎖 若發訊間隔太近

                item.Move(WellKnownFolderName.Inbox);       //DEV
                item.Move(target); //發送後的Mail,移至Sent2Facebook  PRD
            }
            //Console.WriteLine("Fetching mails from Inbox");
            FindItemsResults<Item> findInboxMails = exchangeService.FindItems(WellKnownFolderName.Inbox, new ItemView(int.MaxValue));
            Response.Write("Okay");
            //WellKnownFolderName.
            //foreach (var item in findInboxMails)
            //{
            //    ExtendedPropertyDefinition HtmlBodyProperty = new ExtendedPropertyDefinition(0x1013, MapiPropertyType.Binary);

            //    PropertySet propertySet = new PropertySet(BasePropertySet.FirstClassProperties, HtmlBodyProperty);

            //    // Bind to the message by using the property set.
            //    EmailMessage message = EmailMessage.Bind(exchangeService, item.Id, propertySet);

            //    string subject = message.Subject;
            //    string body = message.Body.Text;
            //    AlertMessage.FBAlert(subject, subject, subject, subject);


            //    if (message.HasAttachments)
            //    {
            //        //Fetching the attachments

            //    }
            //}
        }

    }
}