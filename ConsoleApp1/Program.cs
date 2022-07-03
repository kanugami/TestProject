using Atlassian.Jira;
using RestSharp;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
/// <summary>
/// NameSpacce Testing
/// </summary>
namespace ConsoleApp1
{
    /// <summary>
    /// Testing Class Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Testing Main Method
        /// </summary>
        /// <param name="args"></param>
        static async Task Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");

            //Console.WriteLine($"New Code {AuthorizationCodeGenerator.GenerateVerificationCode()}");
            //WebClient webClient = new WebClient();
            //webClient.


            await CallAPI();
            //var client = new RestClient("https://contisx.atlassian.net/rest/api/3/issuetype");
            ////client.Timeout = -1;
            //var request = new RestRequest(Method.Get.ToString());
            //request.AddHeader("Authorization", "Basic VGVzdEppcmFmOjczMm9ObGV2OXJQTDMzUFBXRjNSMTJCQQ==");
            //request.AddHeader("Cookie", "atlassian.xsrf.token=7ca91f6d-1e09-4bbd-900e-99e1c86fdb4e_beab90c0aa696b02b29ff469b35a3639bd58e7c4_lout");
            //var body = @"";
            //request.AddParameter("text/plain", body, ParameterType.RequestBody);
            //Task<RestResponse> response = client.ExecuteAsync(request);
            //Console.WriteLine(response.Result);
            Console.ReadLine();
        }

       private static async Task CallAPI()
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://contisx.atlassian.net/rest/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("kanu.gami@contis.com:732oNlev9rPL33PPWF3R12BA");
                string val = System.Convert.ToBase64String(plainTextBytes);
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + val);
                client.DefaultRequestHeaders.Add("X-Atlassian-Token", "no-check");

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue()
                //GET Method
                
                //HttpResponseMessage response = await client.GetAsync("api/3/issue/createmeta?projectKeys=CAR&expands=projects&issuetypeNames=Bug");
                HttpResponseMessage response = await client.GetAsync("api/3/issue/createmeta?projectKeys=CAR&expands=projects&issuetypeNames=Bug");

                if (response.IsSuccessStatusCode)
                {
                    string sResponse = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine("Id:{0}\tName:{1}", department.DepartmentId, department.DepartmentName);
                    Console.WriteLine("JIRA Response: {0}", sResponse);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
        }

    }
}
