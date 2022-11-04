using Microsoft.Identity.Client;
using SampleTokenGenerator;
using System;
using System.Threading.Tasks;
namespace AADAuthentication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IConfidentialClientApplication app = null;
            string[] scopes = null;
            string environment;
            do
            {
                Console.WriteLine("Choose environment - (1)Prod/(2)Non-prod(Canary, Dev)/(3)Exit program - ");
                environment = Console.ReadLine();
                if (environment.Trim().Equals(Constants.Production))
                {
                    app = ConfidentialClientApplicationBuilder
                    .Create("b084f5e3-4c0c-4df0-b9b7-f417f0824ba0")
                    .WithClientSecret("Pbp8Q~fmckHhapRjLoXf3v0UMolRO1U7iSf5TcFA")
                    .WithAuthority(AadAuthorityAudience.AzureAdMyOrg)
                    .WithTenantId("72f988bf-86f1-41af-91ab-2d7cd011db47")
                    .Build();

                    scopes = new string[] { "cf04114d-e2e9-46c4-a332-b4ff991702e9/.default" }; //New-Relic app id
                }
                else if (environment.Trim().Equals(Constants.NonProd))
                {
                    app = ConfidentialClientApplicationBuilder
                    .Create("18b712d3-b698-4868-adbb-540a5f105ed8")
                    .WithClientSecret("z5t8Q~br1Cb8HfpTQv9DpW5IJjQ4M9skTezqkb6W")
                    .WithAuthority(AadAuthorityAudience.AzureAdMyOrg)
                    .WithTenantId("72f988bf-86f1-41af-91ab-2d7cd011db47")
                    .Build();

                    scopes = new string[] { "dde76769-8f43-4a65-bdb4-dd26f55964f8/.default" }; //New-Relic app id
                }
                else if(environment.Trim().Equals(Constants.Exit))
                {
                    Console.WriteLine("Bye...!");
                    return;
                }
                else
                {
                    Console.WriteLine("Please try again!");
                }
            } while (int.Parse(environment.Trim()) > 3);
            try
            {
                Task<AuthenticationResult> result = app.AcquireTokenForClient(scopes)
    .ExecuteAsync();
                AuthenticationResult res = result.Result;
                Console.WriteLine("Token: " + res.AccessToken);

            }
            catch (MsalServiceException)
            {
            }
        }
    }
}
