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
    /// <summary>
    /// Service for interacting with the REST-ful API of restSQL.
    /// </summary>
    /// <remarks>
    /// Adapted from Xamarin's TodoREST example.
    /// </remarks>
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

        /// <summary>
        /// Constructor for RestService, which is used for database operations.
        /// </summary>
        public RestService()
        {
            var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        /// <summary>
        /// Deletes an AI-object with the given ID from the database.
        /// </summary>
        /// <param name="id">AInumber of AI to be deleted.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Deletes a BatchBlock-object from the database with the given ID.
        /// </summary>
        /// <param name="id">BatchNr of BatchBlock to be deleted.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Deletes a Product-object with the given ID from the database.
        /// </summary>
        /// <param name="id">GTIN of Product to be deleted.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a list containing all AI-objects in the database.
        /// </summary>
        /// <returns>List of type AI, containing all AI-objects in database.</returns>
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

        /// <summary>
        /// Returns a list containing all BatchBlock-objects in the database.
        /// </summary>
        /// <returns>List of type BatchBlock, containing all BatchBlock-objects in database.</returns>
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

        /// <summary>
        /// Returns a list containing all Product-objects in the database.
        /// </summary>
        /// <returns>List of type Product, containing all Product-objects in database.</returns>
        public async Task<List<Product>> RefreshProductDataAsync()
        {
            Products = new List<Product>();

            var uri = new Uri(string.Format(Constants.RestUrl, "product", String.Empty, Constants.JSONoutput));

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

        /// <summary>
        /// Saves or updates an AI-object in the database.
        /// </summary>
        /// <param name="ai">AI-object to be saved or updated.</param>
        /// <param name="isNewItem">True = POST (save), False = PUT (update).</param>
        /// <returns></returns>
        public async Task SaveAIAsync(AI ai, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "ai", String.Empty, String.Empty));

            try
            {
                JsonAI jw = new JsonAI();
                jw.AISet.Add(ai);
                var json = JsonConvert.SerializeObject(jw);
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

        /// <summary>
        /// Saves or updates a BatchBlock-object in the database.
        /// </summary>
        /// <param name="batch">BatchBlock-object to be saved or updated.</param>
        /// <param name="isNewItem">True = POST (save), False = PUT (update).</param>
        /// <returns></returns>
        public async Task SaveBatchBlockAsync(BatchBlock batch, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "batchblock", String.Empty, String.Empty));

            try
            {
                JsonBatchBlock jw = new JsonBatchBlock();
                jw.BatchSet.Add(batch);
                var json = JsonConvert.SerializeObject(jw, new BooleanConverter());
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

        /// <summary>
        /// Saves or updates a Product-object in the database.
        /// </summary>
        /// <param name="prod">Product-object to be saved or updated.</param>
        /// <param name="isNewItem">True = POST (save), False = PUT (update).</param>
        /// <returns></returns>
        public async Task SaveProductAsync(Product prod, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "product", String.Empty, String.Empty));

            try
            {
                JsonProduct jw = new JsonProduct();
                jw.ProductSet.Add(prod);
                var json = JsonConvert.SerializeObject(jw);
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
