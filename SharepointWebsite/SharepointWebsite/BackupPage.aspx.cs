//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace SharepointWebsite
//{
//    public partial class BackupPage : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {

//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using wc = System.Web.UI.WebControls;
using Microsoft.SharePoint.Client;
using System.Security;


namespace SharepointWebsite
{
    public partial class BackupPage : System.Web.UI.Page
    {
        public string DestSiteName, listname;

       
        protected void Page_Load(object sender, EventArgs e)
        {
            listname = Request.QueryString["ListName"];
            ListNameLabel.Text = listname;
        }

        protected void BackupButton_Click(object sender, EventArgs e)
        {
            DestSiteName = SiteNameTextBox.Text;
            listname = Request.QueryString["ListName"];
            // ClientContext ClientContextCredentials.isClX = new ClientContext("https://acuvatehyd.sharepoint.com/teams/FirstSite");
            ClientContext DestinationCC = new ClientContext("https://acuvatehyd.sharepoint.com/teams/" + DestSiteName);

            //string UserName = ClientContextCredentials.isClX.FormsAuthenticationLoginInfo.LoginName;
            //string Password = ClientContextCredentials.isClX.FormsAuthenticationLoginInfo.Password;

            SecureString securepwd = new SecureString();


            foreach (char c in ClientContextCredentials.Password)
            {
                securepwd.AppendChar(c);
            }

            DestinationCC.Credentials = new SharePointOnlineCredentials(ClientContextCredentials.UserName, securepwd);

            ListCollection listcollection = ClientContextCredentials.isClX.Web.Lists;         //getting list colectiom
            ClientContextCredentials.isClX.Load(listcollection);
            List SourceList = listcollection.GetByTitle(listname);
            ClientContextCredentials.isClX.Load(SourceList);
            ClientContextCredentials.isClX.ExecuteQuery();

            //------creating list in dest



            ListCreationInformation NewList = new ListCreationInformation();
            NewList.Title = SourceList.Title;
            NewList.TemplateType = SourceList.BaseTemplate;
            NewList.Description = SourceList.Description;
            List Destlist = DestinationCC.Web.Lists.Add(NewList);
            DestinationCC.Load(Destlist.Fields);
            DestinationCC.ExecuteQuery();

            //-----------adding list item

            ListItemCollection listitemcollection = SourceList.GetItems(CamlQuery.CreateAllItemsQuery());
            ClientContextCredentials.isClX.Load(listitemcollection);
            ClientContextCredentials.isClX.ExecuteQuery();

            foreach (ListItem li in listitemcollection)
            {
                ListItemCreationInformation NewListItem = new ListItemCreationInformation();
                List destlistitem = Destlist.ParentWeb.Lists.GetByTitle(NewList.Title);
                ListItem listItem = Destlist.AddItem(NewListItem);
                listItem["Title"] = li["Title"];
                listItem.Update();
                DestinationCC.ExecuteQuery();


            }
            Response.Redirect("~/SiteContents.aspx");

        }
    }
}