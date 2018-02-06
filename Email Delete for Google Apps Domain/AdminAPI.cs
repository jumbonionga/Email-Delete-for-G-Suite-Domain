using Google.Apis.Auth.OAuth2;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Email_Delete_for_Google_Apps_Domain;


namespace Email_Delete_for_Google_Apps_Domain
{
    class AdminAPI
    {
        // Statics definition
        static string ApplicationName = "Email Delete for Google Apps Domain";
        public static int usersize;
        static UsersResource.ListRequest userList;
        static DirectoryService dirService;
        public static DirectoryService request;
        public static IList<User> users;
        public static UserCredential credentials;
        static string[] Scopes = { DirectoryService.Scope.AdminDirectoryUserReadonly };
        
        public AdminAPI()
        {
            dirService = adminservice(); // Creating service
            request = Request(dirService); // creating request
        }

        private static DirectoryService adminservice()
        {
            //UserCredential credentials;
            using (var stream = new FileStream("OAuth_cred.json", FileMode.Open, FileAccess.Read)) // Use superadmin to authorize OAuth to retrieve users
            {
                credentials = GoogleWebAuthorizationBroker.AuthorizeAsync( 
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore("EDGAD")
                    ).Result;
            }
            var service = new DirectoryService(new BaseClientService.Initializer() // Create service
            {
                HttpClientInitializer = credentials,
                ApplicationName = ApplicationName
            });

            return service;
        }

        private static DirectoryService Request(DirectoryService service)
        {
            // Request creation
            userList = service.Users.List();
            userList.Customer = "my_customer";
            userList.OrderBy = UsersResource.ListRequest.OrderByEnum.Email;

            // Executing request
            users = userList.Execute().UsersValue;
            usersize = users.Count;

            return service;
        }

        public static guser[] fillusers(IList<User> service, guser[] list)
        {
            // Request creation
            var request = dirService.Users.List(); 
            request.Customer = "my_customer";
            request.OrderBy = UsersResource.ListRequest.OrderByEnum.Email;

            // Create temporal list to store the primary emails
            LinkedList<guser> templist = new LinkedList<guser>();

            // nextPage token starting definition
            string nextPage = "";

            // Retrieve users on the account
            while (nextPage != null)
            {
                request.PageToken = nextPage;
                var response = request.Execute(); // Execute request

                // Use service created and verify if there are users
                if (service != null && usersize > 0)
                {
                    foreach (var useritem in response.UsersValue)
                    {
                        templist.AddLast(new guser()); // create the user
                        templist.Last.Value.email = useritem.PrimaryEmail; // give the user's email the primary email
                    }
                }
                nextPage = response.NextPageToken; // retrieve the NextPageToken if available
            }
            return templist.ToArray<guser>(); // Return list
        }
    }
}
