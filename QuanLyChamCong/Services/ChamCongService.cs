using Newtonsoft.Json;
using QuanLyChamCong.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.Services
{
    public class ChamCongService
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

        public async Task<List<dynamic>> BaoCaoTongHop(
            string nhanVienId,
            DateTime tuNgay,
            DateTime denNgay
        )
        {
            using (
                HttpClient client =
                    GetClient()
            )
            {
                string requestUrl =
                    $"{url}/BaoCaoTongHop?" +
                    $"nhanVienId={nhanVienId}" +
                    $"&tuNgay={tuNgay:yyyy-MM-dd}" +
                    $"&denNgay={denNgay:yyyy-MM-dd}";

                HttpResponseMessage response =
                    await client.GetAsync(
                        requestUrl
                    );

                string responseText =
                    await response.Content
                    .ReadAsStringAsync();

                

                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject
                    <List<dynamic>>(responseText);
            }
        }
    }
}