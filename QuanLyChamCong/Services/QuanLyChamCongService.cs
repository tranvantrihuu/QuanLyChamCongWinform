using Newtonsoft.Json;
using QuanLyChamCong.Models;
using QuanLyChamCong.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.Services
{
    public class QuanLyChamCongService
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

        public async Task<List<VwDanhSachChamCong>>
        LocChamCong(
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
                    string api;

                    if (string.IsNullOrEmpty(nhanVienId))
                    {
                        api =
                            $"{url}/loc?" +
                            $"tuNgay={tuNgay:yyyy-MM-dd}" +
                            $"&denNgay={denNgay:yyyy-MM-dd}";
                    }
                    else
                    {
                        api =
                            $"{url}/loc?" +
                            $"nhanVienId={nhanVienId}" +
                            $"&tuNgay={tuNgay:yyyy-MM-dd}" +
                            $"&denNgay={denNgay:yyyy-MM-dd}";
                    }

                    HttpResponseMessage response =
                        await client.GetAsync(api);

                    if (!response.IsSuccessStatusCode)
                    {
                        return new List<VwDanhSachChamCong>();
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                    .DeserializeObject<
                        List<VwDanhSachChamCong>
                    >(json)
                    ?? new List<VwDanhSachChamCong>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return new List<VwDanhSachChamCong>();
            }
        }

        public async Task<VwDanhSachChamCong>
            GetById(int id)
        {
            try
            {
                using (HttpClient client =
                    GetClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(
                            $"{url}/{id}"
                        );

                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                    .DeserializeObject<VwDanhSachChamCong>(
                        json
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return null;
            }
        }

        public async Task<bool>
            Insert(ChamCong item)
        {
            try
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

                    HttpResponseMessage response =
                        await client.PostAsync(
                            url,
                            content
                        );

                    if (!response.IsSuccessStatusCode)
                    {
                        string err =
                            await response.Content
                            .ReadAsStringAsync();

                        MessageBox.Show(
                            "API ERROR:\n" + err
                        );
                    }

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
            Update(ChamCong item)
        {
            try
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

                    HttpResponseMessage response =
                        await client.PutAsync(
                            $"{url}/{item.id}",
                            content
                        );

                    if (!response.IsSuccessStatusCode)
                    {
                        string err =
                            await response.Content
                            .ReadAsStringAsync();

                        MessageBox.Show(
                            "API ERROR:\n" + err
                        );
                    }

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
       CheckIn(string nhanVienId)
        {
            try
            {
                using (HttpClient client =
                    GetClient())
                {
                    HttpResponseMessage response =
                        await client.PostAsync(
                            $"{url}/checkin/{nhanVienId}",
                            null
                        );

                    string result =
                        await response.Content
                        .ReadAsStringAsync();

                    result =
                        result
                        .Replace("\"", "")
                        .Trim()
                        .ToLower();

                    return result == "true";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return false;
            }
        }

        public async Task<bool>
            CheckOut(string nhanVienId)
        {
            try
            {
                using (HttpClient client =
                    GetClient())
                {
                    HttpResponseMessage response =
                        await client.PostAsync(
                            $"{url}/checkout/{nhanVienId}",
                            null
                        );

                    string result =
                        await response.Content
                        .ReadAsStringAsync();

                    result =
                        result
                        .Replace("\"", "")
                        .Trim()
                        .ToLower();

                    return result == "true";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return false;
            }

        }
    }
}