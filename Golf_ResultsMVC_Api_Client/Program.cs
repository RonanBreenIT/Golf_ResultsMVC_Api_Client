using Golf_ResultsMVC_Api_Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Golf_ResultsMVC_Api_Client
{
    class Program
    {
        static async Task GetsGolfersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                // Use to retrieve token for admin user. Otherwise can't call service.
                var tokenNo = "";
                Dictionary<string, string> tokenDetails = null;
                //HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:55215/"); // Local
                //client.BaseAddress = new Uri("https://golfresultsmvcnew.azurewebsites.net/"); // Azure (live)
                var login = new Dictionary<string, string>
                       {
                           {"grant_type", "password"},
                           {"username", "admin"},
                           {"password", "admin"},
                       };
                var response = client.PostAsync("Token", new FormUrlEncodedContent(login)).Result;
                if (response.IsSuccessStatusCode)
                {
                    tokenDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content.ReadAsStringAsync().Result);
                    if (tokenDetails != null && tokenDetails.Any())
                    {
                        tokenNo = tokenDetails.FirstOrDefault().Value;
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenNo);
                    }
                }
                
                //client.BaseAddress = new Uri("http://localhost:55215/api/Golfer/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenNo);


                // GET: api/Golfer/all
                response = await client.GetAsync("api/Golfer/all");
                if (response.IsSuccessStatusCode)
                {
                    var returnedGolfers = await response.Content.ReadAsAsync<IEnumerable<Golfer>>(); // add from Console line
                    Console.WriteLine("\n*** Complete Golfer List ***");
                    foreach (Golfer g in returnedGolfers)
                    {
                        Console.WriteLine(g);
                    }
                }

                // GET: api/Golfer/GetGolfer/1
                response = await client.GetAsync("api/Golfer/GetGolfer/1");
                if (response.IsSuccessStatusCode)
                {
                    var returnedGolfer = await response.Content.ReadAsAsync<Golfer>(); // add from Console line
                    Console.WriteLine("\n*** Golfer with ID of 1 is ***" + returnedGolfer);
                }


                // POST: api/Golfer/PostGolfer
                Golfer g1 = new Golfer() { Firstname = "Sergio", Surname = "Garcia"};
                response = client.PostAsJsonAsync("api/Golfer/PostGolfer", g1).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nAdded Golfer: " + g1.FullName);
                }


                // PUT: api/Golfer/PutGolfer/2
                Golfer g2 = new Golfer() { ID= 2, Firstname = "Sergio", Surname = "Garcia" };
                response = client.PutAsJsonAsync("api/Golfer/PutGolfer/2", g2).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nUpdated Golfer: " + g2.FullName);
                }


                // DELETE: api/Golfer/DeleteGolfer/2
                response = client.DeleteAsync("api/Golfer/DeleteGolfer/6").Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nDeleted Golfer: " + response.IsSuccessStatusCode);
                }
            }
        }

        static async Task GetsCompsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var tokenNo = "";
                Dictionary<string, string> tokenDetails = null;
                //HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:55215/");
                //client.BaseAddress = new Uri("https://golfresultsmvcnew.azurewebsites.net/"); // Azure (live)
                var login = new Dictionary<string, string>
                       {
                           {"grant_type", "password"},
                           {"username", "admin"},
                           {"password", "admin"},
                       };
                var response = client.PostAsync("Token", new FormUrlEncodedContent(login)).Result;
                if (response.IsSuccessStatusCode)
                {
                    tokenDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content.ReadAsStringAsync().Result);
                    if (tokenDetails != null && tokenDetails.Any())
                    {
                        tokenNo = tokenDetails.FirstOrDefault().Value;
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenNo);
                    }
                }

                //client.BaseAddress = new Uri("http://localhost:55215/api/Comp/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));

                //GET api/Comp/all
                response = await client.GetAsync("api/Comp/all");
                if (response.IsSuccessStatusCode)
                {
                    var returnedComps = await response.Content.ReadAsAsync<IEnumerable<Competition>>();
                    Console.WriteLine("\n*** Complete Comp List ****");
                    int i = 0;
                    foreach (Competition g in returnedComps)
                    {
                        i += 1;
                        Console.WriteLine(i + ". " + g);
                    }
                }

                //GET api/Comp/GetComp/1
                response = await client.GetAsync("api/Comp/GetComp/1");
                if (response.IsSuccessStatusCode)
                {
                    var returnedComp = await response.Content.ReadAsAsync<Competition>(); // add from Console line
                    Console.WriteLine("\nGolf Comp with ID 1: " + returnedComp);
                }

                //POST api/Comp/PostComp
                Competition c1 = new Competition() {Name = "US Open" };
                response = client.PostAsJsonAsync("api/Comp/PostComp", c1).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nAdded Golf Comp: " + c1.Name);
                }

                //PUT api/Comp/PutComp/7
                Competition c2 = new Competition() {ID = 7, Name = "US Open" };
                response = client.PutAsJsonAsync("api/Comp/PutComp/7", c2).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nUpdated Golf Comp: " + c2.Name);
                }

                //DELETE api/Comp/DeleteComp/7
                response = client.DeleteAsync("api/Comp/DeleteComp/7").Result;
                //if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nDeleted Golf Comp: " + response.IsSuccessStatusCode);
                 }
            }
        }


        static async Task GetsCompResultsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var tokenNo = "";
                Dictionary<string, string> tokenDetails = null;
                //HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:55215/");
                //client.BaseAddress = new Uri("https://golfresultsmvcnew.azurewebsites.net/"); // Azure (live)
                var login = new Dictionary<string, string>
                       {
                           {"grant_type", "password"},
                           {"username", "admin"},
                           {"password", "admin"},
                       };
                var response = client.PostAsync("Token", new FormUrlEncodedContent(login)).Result;
                if (response.IsSuccessStatusCode)
                {
                    tokenDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content.ReadAsStringAsync().Result);
                    if (tokenDetails != null && tokenDetails.Any())
                    {
                        tokenNo = tokenDetails.FirstOrDefault().Value;
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenNo);
                    }
                }

                //client.BaseAddress = new Uri("http://localhost:55215/api/CompResult/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));

                //GET api/CompResult/all
                response = await client.GetAsync("api/CompResult/all");
                if (response.IsSuccessStatusCode)
                {
                    var returnedCompResults = await response.Content.ReadAsAsync<IEnumerable<Comp_Result>>();
                    Console.WriteLine("\n*** Complete Comp List ****");
                    int i = 0;
                    foreach (Comp_Result g in returnedCompResults)
                    {
                        i += 1;
                        Console.WriteLine(i + ". " + g);
                    }
                }

                //GET api/CompResult/GetCompResultID/1
                response = await client.GetAsync("api/CompResult/GetCompResultID/1");
                if (response.IsSuccessStatusCode)
                {
                    var returnedCompResult = await response.Content.ReadAsAsync<Comp_Result>(); // add from Console line
                    Console.WriteLine("\nComp Result with ID 1: " + returnedCompResult);
                }

                //GET api/CompResult/GetCompID/1
                response = await client.GetAsync("api/CompResult/GetCompID/1");
                if (response.IsSuccessStatusCode)
                {
                    var returnedCompResult = await response.Content.ReadAsAsync<IEnumerable<Comp_Result>>(); // add from Console line
                    Console.WriteLine("\nGolf Results with Comp ID 1\n");
                    foreach (Comp_Result g in returnedCompResult)
                    {
                        Console.WriteLine(g);
                    }
                }

                //GET api/CompResult/GetCompResultPerSeason/1/2019
                response = await client.GetAsync("api/CompResult/GetCompResultPerSeason/1/2019");
                if (response.IsSuccessStatusCode)
                {
                    var returnedCompResult = await response.Content.ReadAsAsync<IEnumerable<Comp_Result>>(); // add from Console line
                    Console.WriteLine("\nGolf Results for Comp ID 1 for 2019 Season");
                    foreach (Comp_Result g in returnedCompResult)
                    {
                        Console.WriteLine(g);
                    }
                }

                //POST api/CompResult/PostComp
                Comp_Result c1 = new Comp_Result() {CompetitionID=1, Season = 2020, StartDate=new DateTime(2020,01,01), EndDate = new DateTime(2020,01,05), GolferID=11, GolferScore="+5", Position = "6"};
                response = client.PostAsJsonAsync("api/CompResult/PostComp_Result", c1).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nAdded Golf Comp Result: " + c1);
                }

                //PUT api/CompResult/PutComp_Result/1
                Comp_Result c2 = new Comp_Result() { CompResultID = 23, CompetitionID = 1, Season = 2020, StartDate = new DateTime(2020, 01, 01), EndDate = new DateTime(2020, 01, 05), GolferID = 11, GolferScore = "DNF", Position = "MC" };
                response = client.PutAsJsonAsync("api/CompResult/PutComp_Result/23", c2).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nUpdated Golf Comp Result: " + c2);
                }

                //DELETE api/CompResult/DeleteComp_Result/1
                response = client.DeleteAsync("api/CompResult/DeleteComp_Result/18").Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nDeleted Golf Comp Result: " + response.IsSuccessStatusCode);
                }
            }
        }

        static void Main()
        {
            GetsGolfersAsync().Wait();
            GetsCompsAsync().Wait();
            GetsCompResultsAsync().Wait();
            Console.ReadLine();
        }
    }
}
