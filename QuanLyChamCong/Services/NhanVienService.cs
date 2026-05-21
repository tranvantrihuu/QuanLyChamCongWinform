using Newtonsoft.Json;
using QuanLyChamCong.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
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
            try
            {
                using (HttpClient client = GetClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        return new List<NhanVien>();
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<List<NhanVien>>(json)
                        ?? new List<NhanVien>();
                }
            }
            catch
            {
                return new List<NhanVien>();
            }
        }

        public async Task<NhanVien>
            GetNhanVien(string input)
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(
                            $"{url}/timkiem/{input}"
                        );

                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    if (json.StartsWith("["))
                    {
                        List<NhanVien> list =
                            JsonConvert.DeserializeObject
                            <List<NhanVien>>(json);

                        return list?
                            .FirstOrDefault();
                    }

                    return JsonConvert
                        .DeserializeObject<NhanVien>(json);
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool>
    KiemTraAdminByPin(string pin)
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(
                            $"{url}/adminpin/{pin}"
                        );

                    if (!response.IsSuccessStatusCode)
                    {
                        return false;
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<bool>(json);
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<NhanVien>>
            Search(string keyword)
        {
            try
            {
                List<NhanVien> ds =
                    await GetAll();

                return ds
                    .Where(x =>
                        (
                            !string.IsNullOrEmpty(x.ho_ten)
                            &&
                            x.ho_ten
                            .ToLower()
                            .Contains(keyword.ToLower())
                        )
                        ||
                        (
                            !string.IsNullOrEmpty(x.id)
                            &&
                            x.id
                            .ToLower()
                            .Contains(keyword.ToLower())
                        )
                    )
                    .ToList();
            }
            catch
            {
                return new List<NhanVien>();
            }
        }

        public async Task<bool>
            Insert(NhanVien nv)
        {
            try
            {
                using (HttpClient client = GetClient())
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

                    return response.IsSuccessStatusCode;
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

        public async Task<bool>
            Update(NhanVien nv)
        {
            try
            {
                using (HttpClient client = GetClient())
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
                return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.ToString());
                 return false;
            }

        }

        public async Task<bool>
            Delete(string id)
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    HttpResponseMessage response =
                        await client.DeleteAsync(
                            $"{url}/{id}"
                        );

                    return response.IsSuccessStatusCode;
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

        public async Task<bool>
            DoiPin(
                string id,
                string pinMoi
            )
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    var body =
                        new
                        {
                            pinMoi = pinMoi
                        };

                    string json =
                        JsonConvert
                        .SerializeObject(body);

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

                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}