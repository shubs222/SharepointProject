﻿using Microsoft.SharePoint.Client;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Security;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

namespace SharepointWebsite
{
    public partial class EditPage : System.Web.UI.Page
    {
        string Listname;
        string Fieldname;
        
        protected void Page_Load(object sender, EventArgs e)

        {
            if (ClientContextCredentials.isClX != null && ClientContextCredentials.UserName != null && ClientContextCredentials.UserName != string.Empty)
            {
                Listname = Request.QueryString["ListName"];
                Fieldname = Request.QueryString["FieldName"];
                if (!IsPostBack)

                {


                    NameTextBox.Text = Fieldname;

                    NameLabel.Text = Listname;

                    List list = ClientContextCredentials.isClX.Web.Lists.GetByTitle(Listname);

                    Field field = list.Fields.GetByTitle(Fieldname);

                    ClientContextCredentials.isClX.Load(field);
                    ClientContextCredentials.isClX.ExecuteQuery();


                    string xx = field.TypeAsString;
                    TypeDropDownList.SelectedValue = field.TypeAsString;

                    DescriptionTextBox.Text = field.Description;

                }

            }
            else
            {
                Response.Redirect("~/LoginPage.aspx");
            }

          


        }





        protected void EditButton_Click(object sender, EventArgs e)

        {


            List oList = ClientContextCredentials.isClX.Web.Lists.GetByTitle(Listname);

           



            FieldCollection oFields = oList.Fields;



            ClientContextCredentials.isClX.Load(oFields);

            ClientContextCredentials.isClX.ExecuteQuery();



            Field oField = oFields.GetByInternalNameOrTitle(Fieldname);



            oField.Title = NameTextBox.Text;

            oField.TypeAsString = TypeDropDownList.SelectedValue.ToString();

            oField.Description = DescriptionTextBox.Text;





            oField.Update();



            ClientContextCredentials.isClX.ExecuteQuery();


            Response.Redirect("~/SiteContents.aspx");


        }
    }
}