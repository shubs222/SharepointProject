using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.Client;

namespace SharepointWebsite
{
    public partial class ViewAddEdit : System.Web.UI.Page
    {
        string Listname;
        string Fieldname;
        public ClientContext isCtx;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (ClientContextCredentials.isClX != null && ClientContextCredentials.UserName != null && ClientContextCredentials.UserName != string.Empty)
            {
                Listname = Request.QueryString["ListName"];
                Fieldname = Request.QueryString["FieldName"];

                isCtx = ClientContextCredentials.isClX;
                if (Listname != null && Listname != string.Empty)
                {

                    if (isCtx != null)
                    {
                        List l = isCtx.Web.Lists.GetByTitle(Listname);
                        isCtx.Load(l);
                        isCtx.ExecuteQuery();

                        FieldCollection fc = l.Fields;

                        isCtx.Load(fc);
                        isCtx.ExecuteQuery();

                        for (int count = 0; count < fc.Count; count++)
                        {
                            FieldListBox.Items.Add(new System.Web.UI.WebControls.ListItem(fc[count].InternalName.ToString(), fc[count].InternalName.ToString()));
                        }
                    }


                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx");
            }


        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Listname = Request.QueryString["ListName"];

            List list = ClientContextCredentials.isClX.Web.Lists.GetByTitle(Listname);

            // Get all the view for the custom list
            Microsoft.SharePoint.Client.ViewCollection viewColl = list.Views;
            List<string> SelectedValuesForCollectingUserId = new List<string>();
            foreach (System.Web.UI.WebControls.ListItem item in FieldListBox.Items)
            {
                if (item.Selected)
                {
                    SelectedValuesForCollectingUserId.Add(item.Value);
                }
            }

            //string[] viewFields = { "DocIcon", "LinkFilename", "_Author", "Modified", "Modified By" };

            ViewCreationInformation creationInfo = new ViewCreationInformation();

            creationInfo.Title = ViewTextBox.Text;
            creationInfo.RowLimit = 50;
            creationInfo.ViewFields = SelectedValuesForCollectingUserId.ToArray();
            creationInfo.ViewTypeKind = ViewType.None;
            viewColl.Add(creationInfo);

            ClientContextCredentials.isClX.ExecuteQuery();
            Response.Redirect("~/SiteContents.aspx");


        }

        public SecureString GetPassword(string passwd)
        {
            SecureString securePassword = new SecureString();

            if (passwd != null && passwd != string.Empty)
            {
                for (int i = 0; i < passwd.Length; i++)
                {
                    securePassword.AppendChar(passwd[i]);
                }
            }

            return securePassword;
        }
    }
}