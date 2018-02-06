using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

// GOOGLE APIS
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;

namespace Email_Delete_for_Google_Apps_Domain
{
    class GmailAPI
    {
        // Start statics
        static string ApplicationName = "Email Delete for Google Apps Domain";
        static string serviceaccount = "google-apps-message-delete@gmailemaildelete-1256.iam.gserviceaccount.com";
        static string[] gmscopes = { GmailService.Scope.MailGoogleCom };

        // Create argument-less constructor
        public GmailAPI()
        {
        }

        // Create argumented constructor
        public GmailAPI(guser user, string rfc822msgid)
        {
            // Retrieve certificate for service account
            var certificate = new X509Certificate2("service_account.p12", "notasecret", X509KeyStorageFlags.Exportable);

            // create credential using service account
            var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceaccount)
            {
                User = user.email, // user to impersonate
                Scopes = gmscopes
            }.FromCertificate(certificate));

            // Create impersonated service 
            var service = new GmailService(new BaseClientService.Initializer()
            {
                ApplicationName = ApplicationName,
                HttpClientInitializer = credential
            });

            // Create request for immutable ID based on RFC 822 ID
            var request = service.Users.Messages.List(user.email);
            request.Q = ("rfc822msgid:" + rfc822msgid);

            // Execute requet
            var response = request.Execute();
            
            // Verify if there are usable results
            if (response.Messages != null)
            {
                user.immid = response.Messages[0].Id; // Populate the user's immutable ID field with the information
            }
            else user.immid = null; // else, keep the immutable ID as null
        }

        public void deleteemail(guser user)
        {
            // Retrieve certificate for service account
            var certificate = new X509Certificate2("service_account.p12", "notasecret", X509KeyStorageFlags.Exportable);

            var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceaccount)
            {
                User = user.email,
                Scopes = gmscopes
            }.FromCertificate(certificate));

            // Create impersonated service 
            var service = new GmailService(new BaseClientService.Initializer()
            {
                ApplicationName = ApplicationName,
                HttpClientInitializer = credential
            });

            // Create request for message deletion task
            var request = service.Users.Messages.Delete(user.email, user.immid);

            // Execute request
            var response = request.Execute();
        }
    }
}
