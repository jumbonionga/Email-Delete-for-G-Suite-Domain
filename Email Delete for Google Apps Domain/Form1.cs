using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Gmail.v1;
using System.Windows.Forms;

namespace Email_Delete_for_Google_Apps_Domain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            string messageid = MessageID.Text.ToString(); // Fetching Message ID
            Status.Text = "Retrieving users";
            AdminAPI adminresource = new AdminAPI(); // Retrieving users
            int size = AdminAPI.usersize; // How many users are there?
            guser[] userlist = new guser[size]; // Creating array to accomodate the users
            userlist = AdminAPI.fillusers(AdminAPI.users, userlist); // Adding information to the array
            Status.Text = "Users retrieved, retrieving email information";
            int i = 0;
            foreach (var item in userlist)
            {
                GmailAPI mailresource = new GmailAPI(item, messageid); // Fetching immutable ID for each user
            }

            Status.Text = "Email information retrieved. Performing deletion";
            
            if (userlist != null)
            {
                foreach (var listitem in userlist)
                {
                    if (listitem.immid != null)
                    {
                        GmailAPI delete = new GmailAPI();
                        delete.deleteemail(listitem); // Deleting email for each user
                    }
                    else
                    {
                    }
                    i++;
                }
            }

            Status.Text = "Email deleted. You can now close this application";
        }
    }
}
