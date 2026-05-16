using Newtonsoft.Json;
using QuanLyChamCong.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            using (HttpClient client =
                GetClient())
            {
                string json =
                    await client.GetStringAsync(
                        url
                    );

                return JsonConvert
                    .DeserializeObject
                    <List<CaLam>>(json);
            }
        }

        public async Task<bool> Add(
            CaLam ca
        )
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

                var response =
                    await client.PostAsync(
                        url,
                        content
                    );

                return response
                    .IsSuccessStatusCode;
            }
        }

        public async Task<bool> Update(
            CaLam ca
        )
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

                var response =
                    await client.PutAsync(
                        $"{url}/{ca.id}",
                        content
                    );

                return response
                    .IsSuccessStatusCode;
            }
        }

        public async Task<bool> Delete(
            int id
        )
        {
            using (HttpClient client =
                GetClient())
            {
                var response =
                    await client.DeleteAsync(
                        $"{url}/{id}"
                    );

                return response
                    .IsSuccessStatusCode;
            }
        }
    }
}