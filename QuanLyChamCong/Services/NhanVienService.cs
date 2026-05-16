using Newtonsoft.Json;
using QuanLyChamCong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.Services
{
    public class NhanVienService
    {
        private readonly string url =
            "https://localhost:7133/api/NhanVien";

        private HttpClient GetClient()
        {
            HttpClientHandler handler =
                new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (a, b, c, d) => true;

            return new HttpClient(handler);
        }

        public async Task<List<NhanVien>>
            GetAll()
        {
            using (HttpClient client =
                GetClient())
            {
                var response =
                    await client.GetAsync(url);

                if (
                    response.IsSuccessStatusCode
                )
                {
                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject
                        <List<NhanVien>>(json);
                }

                return new List<NhanVien>();
            }
        }

        public async Task<NhanVien>
            GetNhanVien(
            string input
        )
        {
            using (HttpClient client =
                GetClient())
            {
                var response =
                    await client.GetAsync(
                        $"{url}/timkiem/{input}"
                    );

                if (
                    !response
                    .IsSuccessStatusCode
                )
                {
                    return null;
                }

                string json =
                    await response.Content
                    .ReadAsStringAsync();

                return JsonConvert
                    .DeserializeObject
                    <NhanVien>(json);
            }
        }

        public async Task<NhanVien>
            KiemTraAdminByPin(
            string pin
        )
        {
            using (HttpClient client =
                GetClient())
            {
                var response =
                    await client.GetAsync(
                        $"{url}/adminpin/{pin}"
                    );

                if (
                    !response
                    .IsSuccessStatusCode
                )
                {
                    return null;
                }

                string json =
                    await response.Content
                    .ReadAsStringAsync();

                return JsonConvert
                    .DeserializeObject
                    <NhanVien>(json);
            }
        }


        public async Task<List<NhanVien>>
            Search(
            string keyword
        )
        {
            using (HttpClient client =
                GetClient())
            {
                var response =
                    await client.GetAsync(
                        $"{url}"
                    );

                if (!response.IsSuccessStatusCode)
                {
                    return new List<NhanVien>();
                }

                string json =
                    await response.Content
                    .ReadAsStringAsync();

                List<NhanVien> ds =
                    JsonConvert.DeserializeObject
                    <List<NhanVien>>(json);

                return ds
                    .Where(x =>
                        (
                            x.ho_ten != null
                            && x.ho_ten
                            .ToLower()
                            .Contains(
                                keyword.ToLower()
                            )
                        )
                        ||
                        (
                            x.id != null
                            && x.id
                            .ToLower()
                            .Contains(
                                keyword.ToLower()
                            )
                        )
                    )
                    .ToList();
            }
        }
        public async Task<bool> Insert(
            NhanVien nv
        )
        {
            try
            {
                using (HttpClient client =
                    GetClient())
                {
                    string json =
                        JsonConvert.SerializeObject(nv);

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

        public async Task<bool> Update(
            NhanVien nv
        )
        {
            try
            {
                using (HttpClient client =
                    GetClient())
                {
                    string json =
                        JsonConvert.SerializeObject(nv);

                    StringContent content =
                        new StringContent(
                            json,
                            Encoding.UTF8,
                            "application/json"
                        );

                    HttpResponseMessage response =
                        await client.PutAsync(
                            $"{url}/{nv.id}",
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

        public async Task<bool> Delete(
            string id
        )
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
        public async Task<bool> DoiPin(
            string id,
            string pinMoi
        )
        {
            try
            {
                using (
                    HttpClient client =
                        GetClient()
                )
                {
                    var body =
                        new
                        {
                            pinMoi = pinMoi
                        };

                    string json =
                        JsonConvert.SerializeObject(
                            body
                        );

                    StringContent content =
                        new StringContent(
                            json,
                            Encoding.UTF8,
                            "application/json"
                        );

                    HttpResponseMessage response =
                        await client.PutAsync(
                            $"{url}/doipin/{id}",
                            content
                        );

                    string responseText =
                        await response.Content
                        .ReadAsStringAsync();

                    MessageBox.Show(
                        "STATUS: "
                        + response.StatusCode
                        + "\n\n"
                        + responseText
                    );

                    return response
                        .IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString()
                );

                return false;
            }
        }
    }
}