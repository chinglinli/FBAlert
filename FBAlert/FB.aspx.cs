using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;

namespace FBAlert
{
  
    public partial class FB : System.Web.UI.Page
    {
        public string AlertMessage = "201503040003";
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertMessage = Request["AlertMessage"].ToString();

            var client = new FacebookClient("CAAP1OwwdkPMBAISznJTHEoog08V6Vv313ku1iZCn0hEsJUfqHvaLMcduAh73adf2MT6qTaNjTpCCSzBu33eQB3NnQtwCLrZCZBdF6ZB93eQ2lvblQn7conCcISUPS8bxobFQQdRC033TMzpmrQ68U60O8CbT4lxQAoQEobdJPMbNbr8NmKdlDWRH3YAHTZBdEFEfHytZATtwZDZD");
            client.Post("/1814237745469656/feed", new { message = "From aspx using Facebook C# SDK" });

        }
    }
}