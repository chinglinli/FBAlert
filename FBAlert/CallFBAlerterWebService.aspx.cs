using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FBAlert
{
    public partial class CallFBAlerterWebService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //ServiceReference1.FBAlerterSoapClient AlertMessage = new ServiceReference1.FBAlerterSoapClient();
            //dd.FBAlert("", "MDDDDDDD",);
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.FBAlerterSoapClient AlertMessage = new ServiceReference1.FBAlerterSoapClient();
            AlertMessage.FBAlert(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text);
            Response.Write("<font color='Red'>已發送至Facebook Group</font>");

        }
    }
}