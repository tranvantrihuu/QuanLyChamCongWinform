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
    public class CauHinhLuongService
    {
        private readonly string url =
            "https://localhost:7133/api/CauHinhLuong";

        private HttpClient GetClient()
        {
            HttpClientHandler handler =
                new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (a, b, c, d) => true;

            return new HttpClient(handler);
        }

        public async Task<List<CauHinhLuong>>
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
                        return new List<CauHinhLuong>();
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject
                        <List<CauHinhLuong>>(json)
                        ?? new List<CauHinhLuong>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return new List<CauHinhLuong>();
            }
        }

        public async Task<bool>
            Add(CauHinhLuong model)
        {
            try
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
            Update(CauHinhLuong model)
        {
            try
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

                    HttpResponseMessage response =
                        await client.PutAsync(
                            $"{url}/{model.id}",
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
    }
}