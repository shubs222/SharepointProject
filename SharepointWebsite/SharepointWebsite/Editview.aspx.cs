using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.Client;

namespace SharepointWebsite
{
    public partial class Editview : System.Web.UI.Page
    {
        string listtitle;
        string ViewTitle;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ClientContextCredentials.isClX != null && ClientContextCredentials.UserName != null && ClientContextCredentials.UserName != string.Empty)
            {
                listtitle = Request.QueryString["ListName"];
                ViewTitle = Request.QueryString["ViewName"];

                List list = ClientContextCredentials.isClX.Web.Lists.GetByTitle(listtitle);
                Microsoft.SharePoint.Client.View view = list.Views.GetByTitle(ViewTitle);
                ClientContextCredentials.isClX.Load(view);
                ClientContextCredentials.isClX.ExecuteQuery();
                ViewFieldCollection Viewcoll = view.ViewFields;
                //Microsoft.SharePoint.Client.View editview = ClientContextCredentials.isClX.Web.Lists.GetByTitle(listtitle).Views.GetByTitle(ViewTitle);
                ClientContextCredentials.isClX.Load(Viewcoll);
                ClientContextCredentials.isClX.ExecuteQuery();
                //List l = ClientContextCredentials.isClX.Web.Lists.GetByTitle(listtitle);
                ClientContextCredentials.isClX.Load(list);
                ClientContextCredentials.isClX.ExecuteQuery();

                ViewTextBox.Text = ViewTitle;

                FieldCollection fc = list.Fields;
                //FieldCollection fc = ;

                ClientContextCredentials.isClX.Load(fc);
                ClientContextCredentials.isClX.ExecuteQuery();

                for (int count = 0; count < fc.Count; count++)
                {
                    FieldListBox.Items.Add(new System.Web.UI.WebControls.ListItem(fc[count].InternalName.ToString(), fc[count].InternalName.ToString()));

                    if (Viewcoll.Contains(fc[count].InternalName))
                    {
                        FieldListBox.Items[count].Selected = true;
                    }

                    //for (int fieldcount = 0; fieldcount < fc.Count; fieldcount++)
                    //{
                    //    if (fc[fieldcount].Title== FieldListBox.Items[count].Text)
                    //    {
                    //        FieldListBox.Items[count].Selected = true;
                    //    }
                    //}

                }
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx");
            }

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            listtitle = Request.QueryString["ListName"];
            ViewTitle = Request.QueryString["ViewName"];
            try
            {
                ViewOperations vo = new ViewOperations();

                bool isdeleted = vo.DeleteView(listtitle, ViewTitle);
                if (isdeleted)
                {
                    List list = ClientContextCredentials.isClX.Web.Lists.GetByTitle(listtitle);

                    ViewCreationInformation creationInfo = new ViewCreationInformation();

                    creationInfo.Title = ViewTextBox.Text;

                    List<string> SelectedValuesForCollectingUserId = new List<string>();
                    foreach (System.Web.UI.WebControls.ListItem item in FieldListBox.Items)
                    {
                        if (item.Selected)
                        {
                            SelectedValuesForCollectingUserId.Add(item.Value);
                        }
                    }

                    creationInfo.Title = ViewTextBox.Text;
                    creationInfo.RowLimit = 50;
                    //ViewFieldCollection vfc = 


                    // // Get all the view for the custom list
                    // //Microsoft.SharePoint.Client.ViewCollection viewColl = list.Views.GetByTitle();
                    // List<string> SelectedValuesForCollectingUserId = new List<string>();
                    //// Microsoft.SharePoint.Client.View myview = list.Views.GetByTitle(ViewTitle);
                    // //ClientContextCredentials.isClX.Load(myview);
                    // //ClientContextCredentials.isClX.ExecuteQuery();


                    // //ViewFieldCollection vfc = myview.ViewFields;
                    // //ClientContextCredentials.isClX.Load(vfc);
                    // ClientContextCredentials.isClX.ExecuteQuery();

                    // foreach (System.Web.UI.WebControls.ListItem item in FieldListBox.Items)
                    // {
                    //     if (item.Selected)
                    //     {
                    //         SelectedValuesForCollectingUserId.Add(item.Value);
                    //     }
                    //     if (fc.GetByInternalNameOrTitle(item.Value) != null)
                    //     {

                    //     }
                    // }



                    // ViewCreationInformation creationInfo = new ViewCreationInformation();

                    // string[] ary = SelectedValuesForCollectingUserId.ToArray();

                    // creationInfo.Title = ViewTextBox.Text;
                    // creationInfo.RowLimit = 50;


                    // creationInfo.ViewFields = SelectedValuesForCollectingUserId.ToArray();
                    // creationInfo.ViewTypeKind = ViewType.None;
                    // viewColl.Add(creationInfo);

                    // ClientContextCredentials.isClX.ExecuteQuery();

                    // Response.Redirect("~/SiteContents.aspx");

                    //List list = ClientContextCredentials.isClX.Web.Lists.GetByTitle(listtitle);

                    //// Get all the view for the custom list
                    //Microsoft.SharePoint.Client.ViewCollection viewColl = list.Views;
                    //List<string> SelectedValuesForCollectingUserId = new List<string>();
                    //foreach (System.Web.UI.WebControls.ListItem item in FieldListBox.Items)
                    //{
                    //    if (item.Selected)
                    //    {
                    //        SelectedValuesForCollectingUserId.Add(item.Value);
                    //    }
                    //}

                    //ViewCreationInformation creationInfo = new ViewCreationInformation();

                    //creationInfo.Title = ViewTextBox.Text;
                    //creationInfo.RowLimit = 50;
                    //creationInfo.ViewFields = SelectedValuesForCollectingUserId.ToArray();
                    //creationInfo.ViewTypeKind = ViewType.None;
                    //viewColl.Add(creationInfo);

                    //ClientContextCredentials.isClX.ExecuteQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exce :" + ex);
            }

            Response.Redirect("~/SiteContents.aspx");

        }
    }
}