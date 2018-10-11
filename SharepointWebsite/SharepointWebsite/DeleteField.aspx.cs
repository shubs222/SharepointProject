using Microsoft.SharePoint.Client;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Security;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;


namespace SharepointWebsite
{
    public partial class DeleteField : System.Web.UI.Page
    {
        string Listname;
        string Fieldname;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Listname = Request.QueryString["ListName"];
            Fieldname = Request.QueryString["FieldName"];
            List oList = ClientContextCredentials.isClX.Web.Lists.GetByTitle(Listname);

            FieldCollection oFields = oList.Fields;

            ClientContextCredentials.isClX.Load(oFields);

            ClientContextCredentials.isClX.ExecuteQuery();


            Field oField = oFields.GetByInternalNameOrTitle(Fieldname);

            oField.DeleteObject();

            ClientContextCredentials.isClX.ExecuteQuery();
            Response.Redirect("SiteContents.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteContents.aspx");
        }
    }
}