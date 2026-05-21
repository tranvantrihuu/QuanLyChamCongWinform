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

            HttpClient client =
                new HttpClient(handler);

            client.Timeout =
                TimeSpan.FromSeconds(30);

            return client;
        }

        public async Task<List<PhanCa>>
            GetAll()
        {
            try
            {
                using (HttpClient client =
                    GetClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(
                            baseUrl
                        );

                    if (!response
                        .IsSuccessStatusCode)
                    {
                        return new List<PhanCa>();
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(json))
                    {
                        return new List<PhanCa>();
                    }

                    List<PhanCa> data =
                        JsonConvert.DeserializeObject
                        <List<PhanCa>>(json);

                    return data ??
                        new List<PhanCa>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    ex.Message
                );

                return new List<PhanCa>();
            }
        }

        public async Task<bool>
            Add(PhanCa pc)
        {
            try
            {
                using (HttpClient client =
                    GetClient())
                {
                    string json =
                        JsonConvert.SerializeObject(pc);

                    StringContent content =
                        new StringContent(
                            json,
                            Encoding.UTF8,
                            "application/json"
                        );

                    HttpResponseMessage response =
                        await client.PostAsync(
                            baseUrl,
                            content
                        );

                    return response
                        .IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    ex.Message
                );

                return false;
            }
        }

        public async Task<bool>
            Update(PhanCa pc)
        {
            try
            {
                using (HttpClient client =
                    GetClient())
                {
                    string json =
                        JsonConvert.SerializeObject(pc);

                    StringContent content =
                        new StringContent(
                            json,
                            Encoding.UTF8,
                            "application/json"
                        );

                    HttpResponseMessage response =
                        await client.PutAsync(
                            $"{baseUrl}/{pc.id}",
                            content
                        );

                    return response
                        .IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    ex.Message
                );

                return false;
            }
        }

        public async Task<bool>
            Delete(int id)
        {
            try
            {
                using (HttpClient client =
                    GetClient())
                {
                    HttpResponseMessage response =
                        await client.DeleteAsync(
                            $"{baseUrl}/{id}"
                        );

                    return response
                        .IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    ex.Message
                );

                return false;
            }
        }
    }
}