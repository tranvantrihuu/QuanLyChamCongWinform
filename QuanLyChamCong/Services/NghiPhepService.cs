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
    public class NghiPhepService
    {
        private readonly string baseUrl =
            "https://localhost:7133/api/NghiPhep";

        private HttpClient GetClient()
        {
            HttpClientHandler handler =
                new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (a, b, c, d) => true;

            return new HttpClient(handler);
        }

        public async Task<List<VwDanhSachNghiPhep>>
            GetAll()
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(baseUrl);

                    if (!response.IsSuccessStatusCode)
                    {
                        return new List<VwDanhSachNghiPhep>();
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<List<VwDanhSachNghiPhep>>(json)
                        ?? new List<VwDanhSachNghiPhep>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return new List<VwDanhSachNghiPhep>();
            }
        }

        public async Task<bool>
            Add(NghiPhep item)
        {
            try
            {
                using (HttpClient client = GetClient())
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
                            baseUrl,
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
            Update(NghiPhep item)
        {
            try
            {
                using (HttpClient client = GetClient())
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
                            $"{baseUrl}/{item.id}",
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

                    if (!response.IsSuccessStatusCode)
                    {
                        return false;
                    }

                    string jsonResult =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<bool>(
                            jsonResult
                        );
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
                using (HttpClient client = GetClient())
                {
                    HttpResponseMessage response =
                        await client.DeleteAsync(
                            $"{baseUrl}/{id}"
                        );

                    if (!response.IsSuccessStatusCode)
                    {
                        return false;
                    }

                    string jsonResult =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<bool>(
                            jsonResult
                        );
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