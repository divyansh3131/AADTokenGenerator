using Microsoft.Identity.Client;
using System;
using System.Threading.Tasks;
namespace AADAuthentication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IConfidentialClientApplication app = ConfidentialClientApplicationBuilder
            .Create("18b712d3-b698-4868-adbb-540a5f105ed8")
            .WithClientSecret("client-secret")
            .WithAuthority(AadAuthorityAudience.AzureAdMyOrg)
            .WithTenantId("72f988bf-86f1-41af-91ab-2d7cd011db47")
            .Build();
            string[] scopes = new string[] { "dde76769-8f43-4a65-bdb4-dd26f55964f8/.default" }; //New-Relic app id
            try
            {
                Task<AuthenticationResult> result = app.AcquireTokenForClient(scopes)
    .ExecuteAsync();
                AuthenticationResult res = result.Result;
                Console.WriteLine("Token: " + res.AccessToken);

            }
            catch (MsalServiceException ex)
            {
            }
        }
    }
}
