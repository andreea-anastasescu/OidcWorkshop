using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Claims;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Travel Adventure's customer (sp)mailing server.");
            Console.WriteLine("First it obtains an access token from an authorization server.");
            Console.WriteLine("Press key 'E' to obtain topExpeditions from Api - using the obtained access token ");

            string tokenEndpoint = "https://localhost:44333/core/connect/token";
            string resourceEndpoint = "http://localhost:8232/api/topExpeditions";

            var client = new TokenClient(tokenEndpoint, "MailingWorkerService", "secret");
            var result = client.RequestClientCredentialsAsync("api1").Result;
            Validate(result.AccessToken);


            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.E)
                {
                    CallApi(resourceEndpoint, result.AccessToken).Wait();
                }
                if (key.Key == ConsoleKey.Q)
                {
                    break;
                }
                
            }

        }

        private static bool Validate(string accessToken)
        {
            var client = new IntrospectionClient(
                "https://localhost:44333/core/connect/introspect",
                "api1",
                "secret");

            var request = new IntrospectionRequest
            {
                Token = accessToken
            };

            IntrospectionResponse result = client.SendAsync(request).Result;

            if (result.IsError)
            {
                Console.WriteLine(result.Error);
                return false;
            }
            else
            {
                if (result.IsActive)
                {
                    Console.WriteLine("The claims obtained from the token");
                    result.Claims.ToList().ForEach(c => Console.WriteLine("{0}: {1}",
                        c.Item1, c.Item2));

                    var exp = result.Claims.First(c => c.Item1.Equals("exp")).Item2;
                    Console.WriteLine("expires at:"+ EpochToDateTime(exp));

                    Console.WriteLine("Token: '"+accessToken+"'");

                    return true;
                }
                else
                {
                    Console.WriteLine("token is not active");

                    return false;
                }
            }
        }

        private static DateTime EpochToDateTime(string epoch)
        {
            int epochAsInt = int.Parse(epoch, CultureInfo.InvariantCulture);
            DateTime unixStarter = new DateTime(1970, 1,1,0,0,0);
            return unixStarter.AddSeconds(epochAsInt).ToLocalTime();
        }

        private static async Task CallApi(string resourceEndpoint, string accessToken)
        {
            var client = new HttpClient();
            client.SetBearerToken(accessToken);
            var response = await client.GetAsync(resourceEndpoint);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Unsucessfull call. Response Code: " + response.StatusCode);
                return;
            }

            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

    }
}
