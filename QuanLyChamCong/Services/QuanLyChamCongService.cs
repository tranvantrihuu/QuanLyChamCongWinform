using Newtonsoft.Json;
using QuanLyChamCong.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChamCong.Services
{
    public class QuanLyChamCongService
    {
        private string url =
            "https://localhost:7133/api/ChamCong";

        private HttpClient GetClient()
        {
            HttpClientHandler handler =
                new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (a, b, c, d) => true;

            return new HttpClient(handler);
        }

        public async Task<List<ChamCong>> GetAll()
        {
            using (HttpClient client =
                GetClient())
            {
                string json =
                    await client.GetStringAsync(url);

                return JsonConvert.DeserializeObject
                    <List<ChamCong>>(json);
            }
        }

        public async Task<ChamCong> GetById(
            int id
        )
        {
            using (HttpClient client =
                GetClient())
            {
                string json =
                    await client.GetStringAsync(
                        $"{url}/{id}"
                    );

                return JsonConvert.DeserializeObject
                    <ChamCong>(json);
            }
        }

        public async Task<bool> Insert(
            ChamCong item
        )
        {
            using (HttpClient client =
                GetClient())
            {
                string json =
                    JsonConvert.SerializeObject(item);

                StringContent content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                HttpResponseMessage res =
                    await client.PostAsync(
                        url,
                        content
                    );

                return res.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Update(
            ChamCong item
        )
        {
            using (HttpClient client =
                GetClient())
            {
                string json =
                    JsonConvert.SerializeObject(item);

                StringContent content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                HttpResponseMessage res =
                    await client.PutAsync(
                        $"{url}/{item.id}",
                        content
                    );

                return res.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Delete(
            int id
        )
        {
            using (HttpClient client =
                GetClient())
            {
                HttpResponseMessage res =
                    await client.DeleteAsync(
                        $"{url}/{id}"
                    );

                return res.IsSuccessStatusCode;
            }
        }
        public async Task<bool> CheckIn(
    string nhanVienId
)
        {
            using (HttpClient client =
                GetClient())
            {
                var response =
                    await client.PostAsync(
                        $"{url}/checkin/{nhanVienId}",
                        null
                    );

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> CheckOut(
            string nhanVienId
        )
        {
            using (HttpClient client =
                GetClient())
            {
                var response =
                    await client.PostAsync(
                        $"{url}/checkout/{nhanVienId}",
                        null
                    );

                return response.IsSuccessStatusCode;
            }
        }
    }
}