using Golf_ResultsMVC_Api_Client.Models;
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
                client.BaseAddress = new Uri("http://localhost:55215/api/Golfer/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));
                

                // GET: api/Golfer/all
                HttpResponseMessage response = await client.GetAsync("all");
                if (response.IsSuccessStatusCode)
                {
                    var returnedGolfers = await response.Content.ReadAsAsync<IEnumerable<Golfer>>(); // add from Console line
                    Console.WriteLine("\n*** Complete Golfer List ***");
                    foreach (Golfer g in returnedGolfers)
                    {
                        Console.WriteLine(g);
                    }
                }

                // GET: api/Golfer/1
                response = await client.GetAsync("GetGolfer/1");
                if (response.IsSuccessStatusCode)
                {
                    var returnedGolfer = await response.Content.ReadAsAsync<Golfer>(); // add from Console line
                    Console.WriteLine("\n*** Golfer with ID of 1 is ***" + returnedGolfer);
                }


                // POST: api/Golfer/PostGolfer
                Golfer g1 = new Golfer() { Firstname = "Sergio", Surname = "Garcia"};
                response = client.PostAsJsonAsync("PostGolfer", g1).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nAdded Golfer: " + g1.FullName);
                }


                // PUT: api/Golfer/PutGolfer/2
                Golfer g2 = new Golfer() { ID= 2, Firstname = "Sergio", Surname = "Garcia" };
                response = client.PutAsJsonAsync("PutGolfer/2", g2).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nUpdated Golfer: " + g2.FullName);
                }


                // DELETE: api/Golfer/DeleteGolfer/2
                response = client.DeleteAsync("DeleteGolfer/2").Result;
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
                client.BaseAddress = new Uri("http://localhost:55215/api/Comp/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));

                //GET api/Comp/all
                HttpResponseMessage response = await client.GetAsync("all");
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
                response = await client.GetAsync("GetComp/1");
                if (response.IsSuccessStatusCode)
                {
                    var returnedComp = await response.Content.ReadAsAsync<Competition>(); // add from Console line
                    Console.WriteLine("\nGolf Comp with ID 1: " + returnedComp);
                }

                //POST api/Comp/PostComp
                Competition c1 = new Competition() {Name = "US Open" };
                response = client.PostAsJsonAsync("PostComp", c1).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nAdded Golf Comp: " + c1.Name);
                }

                //PUT api/Comp/PutComp/7
                Competition c2 = new Competition() {ID = 7, Name = "US Open" };
                response = client.PutAsJsonAsync("PutComp/7", c2).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nUpdated Golf Comp: " + c2.Name);
                }

                //DELETE api/Comp/DeleteComp/7
                response = client.DeleteAsync("DeleteComp/7").Result;
                //if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nDeleted Golf Comp: " + response.Content);
                 }
            }
        }


        static async Task GetsCompResultsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55215/api/CompResult/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));

                //GET api/CompResult/all
                HttpResponseMessage response = await client.GetAsync("all");
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
                response = await client.GetAsync("GetCompResultID/1");
                if (response.IsSuccessStatusCode)
                {
                    var returnedCompResult = await response.Content.ReadAsAsync<Comp_Result>(); // add from Console line
                    Console.WriteLine("\nComp Result with ID 1: " + returnedCompResult);
                }

                //GET api/CompResult/GetCompID/1
                response = await client.GetAsync("GetCompID/1");
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
                response = await client.GetAsync("GetCompResultPerSeason/1/2019");
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
                Comp_Result c1 = new Comp_Result() {CompetitionID=1, Season = 2020, StartDate=new DateTime(2020,01,01), EndDate = new DateTime(2020,01,05), GolferID=1, GolferScore="-5", Position = "3"};
                response = client.PostAsJsonAsync("PostComp_Result", c1).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nAdded Golf Comp Result: " + c1);
                }

                //PUT api/CompResult/PutComp_Result/1
                Comp_Result c2 = new Comp_Result() { CompetitionID = 1, Season = 2020, StartDate = new DateTime(2020, 01, 01), EndDate = new DateTime(2020, 01, 05), GolferID = 1, GolferScore = "-5", Position = "3" };
                response = client.PutAsJsonAsync("PutComp_Result/1", c2).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nUpdated Golf Comp Result: " + c2);
                }

                //DELETE api/CompResult/DeleteComp_Result/1
                response = client.DeleteAsync("DeleteComp_Result/1").Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nDeleted Golf Comp Result: " + response.Content );
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
