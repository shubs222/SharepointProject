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
    public class ClientContextCredentials
    {

        public static ClientContext isClX = null;
        public static string UserName;
        public static string Password;
        public void ValidateCradentials(string username, string password, string SiteName)
        {
            try
            {
                SecureString SecurePassword = new SecureString();

                foreach (char c in password)
                {
                    SecurePassword.AppendChar(c);
                }
                using (isClX = new ClientContext("https://acuvatehyd.sharepoint.com/teams/" + SiteName))
                {

                    isClX.Credentials = new SharePointOnlineCredentials(username, SecurePassword);
                    isClX.ExecuteQuery();
                }

                UserName = username;
                Password = password;
            }
            catch (Exception)
            {
                throw;
            }
          

        }
    }
}