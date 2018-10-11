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

            if (ClientContextCredentials.isClX != null && ClientContextCredentials.UserName != null && ClientContextCredentials.UserName != string.Empty)
            {
                listname = Request.QueryString["ListName"];
                ListNameLabel.Text = listname;
           

            }
            else
            {
                Response.Redirect("~/LoginPage.aspx");
            }

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SiteContents.aspx");
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



            //List list = ClientContextCredentials.isClX.Web.Lists.GetByTitle(listname);
            //ClientContextCredentials.isClX.Load(list);
            //ClientContextCredentials.isClX.ExecuteQuery();


            //ListCreationInformation listCreation = new ListCreationInformation();
            //listCreation.Title = list.Title;
            //listCreation.TemplateType = list.BaseTemplate;
            //List listback = DestinationCC.Web.Lists.Add(listCreation);
            //DestinationCC.Load(listback.Fields);
            //listback.Update();

            //FieldCollection fc = list.Fields;
            //ClientContextCredentials.isClX.Load(fc);
            //ClientContextCredentials.isClX.ExecuteQuery();

            //FieldCollection fcnew = listback.Fields;
            //DestinationCC.Load(fcnew);

            //foreach (Field f in fc)
            //{

            //    if (!f.FromBaseType)
            //    {
            //        listback.Fields.Add(f);
            //        //Console.WriteLine("Added: " + f.Title);
            //    }

            //    else
            //    {

            //    }

            //}
            //ClientContextCredentials.isClX.ExecuteQuery();
            //foreach (Field newfi in fcnew)
            //{
            //    if (!newfi.FromBaseType)
            //    {
            //        //Console.WriteLine("New Fields: " + newfi.Title);
            //        listback.Fields.Add(newfi);

            //    }
            //}
            //DestinationCC.ExecuteQuery();


            //------creating list in dest



            ListCreationInformation NewList = new ListCreationInformation();
            NewList.Title = SourceList.Title;
            NewList.TemplateType = SourceList.BaseTemplate;
            NewList.Description = SourceList.Description;
            List Destlist = DestinationCC.Web.Lists.Add(NewList);
            DestinationCC.Load(Destlist.Fields);
            DestinationCC.ExecuteQuery();

            ////-----------adding list item

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
            //Response.Redirect("~/SiteContents.aspx");
            wc.HyperLink urllink = new wc.HyperLink();
            urllink.Text = DestinationCC.Url;
            urllink.NavigateUrl = DestinationCC.Url;
            UrlData.Controls.Add(urllink);
            /*********************************************************************************************
            List list = clientContext.Web.Lists.GetByTitle("Employee");
            clientContext.Load(list);
            clientContext.ExecuteQuery();
            ListCreationInformation listCreation = new ListCreationInformation();
            listCreation.Title = list.Title + "bbbacckupp111";
            listCreation.TemplateType = list.BaseTemplate;
            List listback = clientContext.Web.Lists.Add(listCreation);
            clientContext.Load(listback.Fields);
            listback.Update();

            FieldCollection fc = list.Fields;
            clientContext.Load(fc);
            clientContext.ExecuteQuery();
            //listCreation.Url = listCreation.Title;

            FieldCollection fcnew = listback.Fields;
            clientContext.Load(fc);

            //string[] customdata=new string[1000];
            //int count = 0;



            foreach (Field f in fc)
            {

                if (!f.FromBaseType)
                {
                    listback.Fields.Add(f);
                    Console.WriteLine("Added: " + f.Title);
                }

                else
                {

                }

            }
            Console.WriteLine("Previous list count{0},  new list count{1}", +fc.Count, fcnew.Count);

            clientContext.ExecuteQuery();
            foreach (Field newfi in fcnew)
            {
                if (!newfi.FromBaseType)
                {
                    Console.WriteLine("New Fields: " + newfi.Title);
                    listback.Fields.Add(newfi);

                }
            }
            clientContext.ExecuteQuery();


    ********************************************************************************************************************************/


        }
    }
}