using Newtonsoft.Json;
using QuanLyChamCong.Models;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.Services
{
    public class CaLamService
    {
        private readonly string url =
            "https://localhost:7133/api/CaLam";

        private HttpClient GetClient()
        {
            HttpClientHandler handler =
                new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (a, b, c, d) => true;

            return new HttpClient(handler);
        }

        public async Task<List<CaLam>>
            GetAll()
        {
            try
            {
                using (HttpClient client =
                    GetClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        return new List<CaLam>();
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();
                    return JsonConvert
                        .DeserializeObject<List<CaLam>>(json)
                        ?? new List<CaLam>();
                }
            }
            catch
            {
                return new List<CaLam>();
            }
        }

        public async Task<bool>
            Add(CaLam ca)
        {
            try
            {
                using (HttpClient client =
                    GetClient())
                {
                    string json =
                        JsonConvert
                        .SerializeObject(ca);

                    StringContent content =
                        new StringContent(
                            json,
                            Encoding.UTF8,
                            "application/json"
                        );

                    HttpResponseMessage response =
                        await client.PostAsync(
                            url,
                            content
                        );

                    return response
                        .IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool>
            Update(CaLam ca)
        {
            try
            {
                using (HttpClient client =
                    GetClient())
                {
                    string json =
                        JsonConvert
                        .SerializeObject(ca);

                    StringContent content =
                        new StringContent(
                            json,
                            Encoding.UTF8,
                            "application/json"
                        );

                    HttpResponseMessage response =
                        await client.PutAsync(
                            $"{url}/{ca.id}",
                            content
                        );

                    return response
                        .IsSuccessStatusCode;
                }
            }
            catch
            {
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
                            $"{url}/{id}"
                        );

                    return response
                        .IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}