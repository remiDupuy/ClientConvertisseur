using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Model;
using Newtonsoft.Json;

namespace ClientConvertisseurV2.Service
{
    class WSService
    {

            private static WSService instance;

            private WSService() { }

            public static WSService Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new WSService();
                    }
                    return instance;
                }
            }


            static HttpClient client = new HttpClient();


            public async Task<List<Devise>> getAllDevisesAsync()
            {
                List<Devise> model = null;

                var task = await client.GetAsync("http://localhost:3459/api/Devise");
                var jsonString = await task.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<Devise>>(jsonString);
                return model;
            }

        }
    }

