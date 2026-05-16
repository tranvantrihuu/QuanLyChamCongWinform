using Newtonsoft.Json;
using QuanLyChamCong.Models;

using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.Services
{
    public class CauHinhLuongService
    {
        private string url =
            "https://localhost:7133/api/CauHinhLuong";

        private HttpClient GetClient()
        {
            HttpClientHandler handler =
                new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (a, b, c, d) => true;

            return new HttpClient(handler);
        }

        public async Task<List<CauHinhLuong>> GetAll()
        {
            using (HttpClient client =
                GetClient())
            {
                string json =
                    await client.GetStringAsync(url);

                return JsonConvert.DeserializeObject
                    <List<CauHinhLuong>>(json);
            }
        }

        public async Task<bool> Add(
            CauHinhLuong model
        )
        {
            using (HttpClient client =
                GetClient())
            {
                string json =
                    JsonConvert.SerializeObject(model);

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
    CauHinhLuong model
)
        {
            using (HttpClient client =
                GetClient())
            {
                string json =
                    JsonConvert.SerializeObject(model);

                StringContent content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                HttpResponseMessage res =
                    await client.PutAsync(
                        url + "/" + model.id,
                        content
                    );

                string response =
                    await res.Content
                    .ReadAsStringAsync();

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
                        url + "/" + id
                    );

                return res.IsSuccessStatusCode;
            }
        }
    }
}