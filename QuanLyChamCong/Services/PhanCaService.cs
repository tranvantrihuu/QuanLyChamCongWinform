using Newtonsoft.Json;
using QuanLyChamCong.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChamCong.Services
{
    public class PhanCaService
    {
        private readonly string baseUrl =
            "https://localhost:7133/api/PhanCa";

        private HttpClient GetClient()
        {
            HttpClientHandler handler =
                new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (a, b, c, d) => true;

            return new HttpClient(handler);
        }

        public async Task<List<PhanCa>> GetAll()
        {
            using (HttpClient client = GetClient())
            {
                var response =
                    await client.GetAsync(baseUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json =
                        await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject
                        <List<PhanCa>>(json);
                }

                return new List<PhanCa>();
            }
        }

        public async Task<bool> Add(PhanCa pc)
        {
            using (HttpClient client = GetClient())
            {
                string json =
                    JsonConvert.SerializeObject(pc);

                StringContent content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json");

                var response =
                    await client.PostAsync(
                        baseUrl,
                        content);

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Update(PhanCa pc)
        {
            using (HttpClient client = GetClient())
            {
                string json =
                    JsonConvert.SerializeObject(pc);

                StringContent content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json");

                var response =
                    await client.PutAsync(
                        $"{baseUrl}/{pc.id}",
                        content);

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (HttpClient client = GetClient())
            {
                var response =
                    await client.DeleteAsync(
                        $"{baseUrl}/{id}");

                return response.IsSuccessStatusCode;
            }
        }
    }
}