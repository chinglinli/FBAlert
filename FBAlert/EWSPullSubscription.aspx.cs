using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Exchange.WebServices;
using Microsoft.Exchange.WebServices.Data;
using System.Timers;

namespace FBAlert
{
    public partial class EWSPullSubscription : System.Web.UI.Page
    {
        public static ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
        public static List<PullSubscription> Subscriptions = new List<PullSubscription>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string mailbox = "ian.lee@gigamedia.com.tw";

            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
            service.Credentials = new WebCredentials("ian", "qwer!23", "giga");
            service.AutodiscoverUrl(mailbox);

            PullSubscription subscription =
            service.SubscribeToPullNotifications(
            new FolderId[] { WellKnownFolderName.Inbox }, 1440, "", EventType.NewMail);
            Subscriptions.Add(subscription);

            foreach (var pullSubscription in Subscriptions)
            {
                foreach (var itemEvent in pullSubscription.GetEvents().ItemEvents)
                {
                    Item item = Item.Bind(service, itemEvent.ItemId);
                    Response.Write(item.Subject);
                    if (item.Subject != "")
                    {
                        Response.Write(item.Subject);
                        //  item.Attachments do something
                        //  As in read it as a stream and write it 
                        //  to a file according to mime type and file extension
                    }
                }
            }
        }



        static void Exchanger_Elapsed(object sender, ElapsedEventArgs e)
        {

            foreach (var pullSubscription in Subscriptions)
            {
                foreach (var itemEvent in pullSubscription.GetEvents().ItemEvents)
                {
                    Item item = Item.Bind(service, itemEvent.ItemId);
                    if (item.Subject == "someString")
                    {
                        //  item.Attachments do something
                        //  As in read it as a stream and write it 
                        //  to a file according to mime type and file extension
                    }
                }
            }
        }


        //http://stackoverflow.com/questions/5654259/using-exchange-managed-api-ews-to-monitor-mailbox-attachments
        //Outlook信箱Pull Subscription
        private int PullMailBox(string account, string pass, string domain, string mailbox)
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
    }
}