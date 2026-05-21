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
    public class NghiPhepNamService
    {
        private readonly string baseUrl =
            "https://localhost:7133/api/NghiPhepNam";

        private HttpClient GetClient()
        {
            HttpClientHandler handler =
                new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (a, b, c, d) => true;

            return new HttpClient(handler);
        }

        public async Task<List<NghiPhepNam>>
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
                        return new List<NghiPhepNam>();
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<List<NghiPhepNam>>(json)
                        ?? new List<NghiPhepNam>();
                }
            }
            catch
            {
                return new List<NghiPhepNam>();
            }
        }

        public async Task<bool>
            Add(NghiPhepNam item)
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
            Update(NghiPhepNam item)
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
                using (HttpClient client = GetClient())
                {
                    HttpResponseMessage response =
                        await client.DeleteAsync(
                            $"{baseUrl}/{id}"
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