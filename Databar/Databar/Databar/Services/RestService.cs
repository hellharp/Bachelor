using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databar.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace Databar.Services
{
    public class RestService : IRestService
    {
        //http://www.example.com/api/resource/tablename/?param1=info1

            // List hele ai tabellen (på json format):
        // http://138.68.180.198:8080/restsql/res/databar_db.ai
            // Vis ai med id 1 (på json format):
        // http://138.68.180.198:8080/restsql/res/databar_db.ai/1?_output=application/json


        HttpClient client;

        public List<Product> Products { get; private set; }
        public List<AI> AIs { get; private set; }
        public List<BatchBlock> BlockedBatches { get; private set; }

        public RestService()
        {
            var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task DeleteAIAsync(string id)
        {
            //"http://138.68.180.198:8080/restsql/res/databar_db.{0}/{1}{2}"
            var uri = new Uri(string.Format(Constants.RestUrl, "ai", id, String.Empty));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				AI successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteBatchBlockAsync(string id)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "batchblock", id, String.Empty));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				BatchBlock successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteProductAsync(string id)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "product", id, String.Empty));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Product successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task<List<AI>> RefreshAIDataAsync()
        {
            AIs = new List<AI>();

            var uri = new Uri(string.Format(Constants.RestUrl, "ai", String.Empty, Constants.JSONoutput));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    AIs = JsonConvert.DeserializeObject<JsonWrapper>(content).AISet;
                }
                            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return AIs;
        }

        public async Task<List<BatchBlock>> RefreshBatchDataAsync()
        {
            BlockedBatches = new List<BatchBlock>();

            var uri = new Uri(string.Format(Constants.RestUrl, "batchblock", String.Empty, Constants.JSONoutput));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    BlockedBatches = JsonConvert.DeserializeObject<JsonWrapper>(content).BatchSet;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return BlockedBatches;
        }

        public async Task<List<Product>> RefreshProductDataAsync()
        {
            Products = new List<Product>();

            var uri = new Uri(string.Format(Constants.RestUrl, "products", String.Empty, Constants.JSONoutput));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Products = JsonConvert.DeserializeObject<JsonWrapper>(content).ProductSet;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Products;
        }

        public async Task SaveAIAsync(AI ai, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "ai", ai.AInumber.ToString(), String.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(ai);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				AI successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task SaveBatchBlockAsync(BatchBlock batch, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "batchblock", batch.BatchNr.ToString(), String.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(batch);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				BatchBlock successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task SaveProductAsync(Product prod, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "product", prod.GTIN.ToString(), String.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(prod);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Product successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }
    }
}
