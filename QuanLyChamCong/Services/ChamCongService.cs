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
        private readonly string url =
            "https://localhost:7133/api/ChamCong";

        private HttpClient GetClient()
        {
            HttpClientHandler handler =
                new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (a, b, c, d) => true;

            return new HttpClient(handler);
        }

        public async Task<List<BaoCaoChamCong>>
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
                        return new List<BaoCaoChamCong>();
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<List<BaoCaoChamCong>>(json)
                        ?? new List<BaoCaoChamCong>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return new List<BaoCaoChamCong>();
            }
        }

        public async Task<List<dynamic>>
            BaoCaoTongHop(
                string nhanVienId,
                DateTime tuNgay,
                DateTime denNgay
            )
        {
            try
            {
                using (HttpClient client =
                    GetClient())
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

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(
                            "API ERROR:\n" +
                            responseText
                        );

                        return new List<dynamic>();
                    }

                    return JsonConvert
                        .DeserializeObject<List<dynamic>>(
                            responseText
                        )
                        ?? new List<dynamic>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return new List<dynamic>();
            }
        }
    }
}