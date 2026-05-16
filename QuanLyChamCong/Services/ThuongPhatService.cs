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
    public class ThuongPhatService
    {
        private readonly string baseUrl =
            "https://localhost:7133/api/ThuongPhat";

        private HttpClient GetClient()
        {
            HttpClientHandler handler =
                new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (a, b, c, d) => true;

            return new HttpClient(handler);
        }

        public async Task<List<ThuongPhat>> GetAll()
        {
            using (HttpClient client = GetClient())
            {
                var response =
                    await client.GetAsync(baseUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json =
                        await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject
                        <List<ThuongPhat>>(json);
                }

                return new List<ThuongPhat>();
            }
        }

        public async Task<bool> Add(
            ThuongPhat tp)
        {
            using (HttpClient client = GetClient())
            {
                string json =
                    JsonConvert.SerializeObject(tp);

                StringContent content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json");

                var response =
                    await client.PostAsync(
                        baseUrl,
                        content);

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Update(
    ThuongPhat tp)
        {
            using (HttpClient client = GetClient())
            {
                try
                {
                    string json =
                        JsonConvert.SerializeObject(tp);

                    StringContent content =
                        new StringContent(
                            json,
                            Encoding.UTF8,
                            "application/json");

                    var response =
                        await client.PutAsync(
                            $"{baseUrl}/{tp.id}",
                            content);

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
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.ToString()
                    );

                    return false;
                }
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (HttpClient client = GetClient())
            {
                var response =
                    await client.DeleteAsync(
                        $"{baseUrl}/{id}");

                return response.IsSuccessStatusCode;
            }
        }
    }
}