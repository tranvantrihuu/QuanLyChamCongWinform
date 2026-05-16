using Newtonsoft.Json;
using QuanLyChamCong.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyChamCong.Services
{
    public class BangLuongChotService
    {
        private readonly HttpClient _httpClient;

        private string baseUrl =
            "https://localhost:7133/api/BangLuongChot";

        public BangLuongChotService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<BangLuongChot>> GetAll()
        {
            try
            {
                HttpResponseMessage response =
                    await _httpClient.GetAsync(baseUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json =
                        await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<BangLuongChot>>(json);
                }
            }
            catch
            {
            }

            return new List<BangLuongChot>();
        }

        public async Task<BangLuongChot> GetById(int id)
        {
            try
            {
                HttpResponseMessage response =
                    await _httpClient.GetAsync(
                        $"{baseUrl}/{id}"
                    );

                if (response.IsSuccessStatusCode)
                {
                    string json =
                        await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<BangLuongChot>(json);
                }
            }
            catch
            {
            }

            return null;
        }

        public async Task<bool> Insert(BangLuongChot model)
        {
            try
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
                    await _httpClient.PostAsync(
                        baseUrl,
                        content
                    );

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(BangLuongChot model)
        {
            try
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
                    await _httpClient.PutAsync(
                        $"{baseUrl}/{model.id}",
                        content
                    );

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                HttpResponseMessage response =
                    await _httpClient.DeleteAsync(
                        $"{baseUrl}/{id}"
                    );

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<BangLuongChot>> GetByThangNam(
            int thang,
            int nam
        )
        {
            try
            {
                HttpResponseMessage response =
                    await _httpClient.GetAsync(
                        $"{baseUrl}/thangnam?thang={thang}&nam={nam}"
                    );

                if (response.IsSuccessStatusCode)
                {
                    string json =
                        await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<BangLuongChot>>(json);
                }
            }
            catch
            {
            }

            return new List<BangLuongChot>();
        }

        public async Task<List<BangLuongChot>> GetByNhanVien(
            string nhanVienId
        )
        {
            try
            {
                HttpResponseMessage response =
                    await _httpClient.GetAsync(
                        $"{baseUrl}/nhanvien/{nhanVienId}"
                    );

                if (response.IsSuccessStatusCode)
                {
                    string json =
                        await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<BangLuongChot>>(json);
                }
            }
            catch
            {
            }

            return new List<BangLuongChot>();
        }
        public async Task<bool>
    DaChotLuong(
        int thang,
        int nam
    )
        {
            try
            {
                HttpResponseMessage response =
                    await _httpClient.GetAsync(
                        $"{baseUrl}/DaChotLuong?thang={thang}&nam={nam}"
                    );

                if (response.IsSuccessStatusCode)
                {
                    string json =
                        await response.Content
                            .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<bool>(
                            json
                        );
                }
            }
            catch
            {
            }

            return false;
        }

        public async Task<DataTable>
    LayBangLuongDaChot(
        int thang,
        int nam
    )
        {
            try
            {
                HttpResponseMessage response =
                    await _httpClient.GetAsync(
                        $"{baseUrl}/LayBangLuongDaChot?thang={thang}&nam={nam}"
                    );

                if (response.IsSuccessStatusCode)
                {
                    string json =
                        await response.Content
                            .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<DataTable>(
                            json
                        );
                }
            }
            catch
            {
            }

            return new DataTable();
        }

        public async Task<DataTable>
    TinhLuongThang(
        int thang,
        int nam
    )
        {
            try
            {
                HttpResponseMessage response =
                    await _httpClient.GetAsync(
                        $"{baseUrl}/TinhLuongThang?thang={thang}&nam={nam}"
                    );

                if (response.IsSuccessStatusCode)
                {
                    string json =
                        await response.Content
                            .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<DataTable>(
                            json
                        );
                }
            }
            catch
            {
            }

            return new DataTable();
        }

        public async Task<bool>
        ChotLuong(
            BangLuongChot model
        )
        {
            try
            {
                string json =
                    JsonConvert.SerializeObject(
                        model
                    );

                StringContent content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                HttpResponseMessage response =
                    await _httpClient.PostAsync(
                        baseUrl,
                        content
                    );

                if (
                    response.IsSuccessStatusCode
                )
                {
                    return true;
                }

                string error =
                    await response.Content
                        .ReadAsStringAsync();

                throw new Exception(error);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    ex.Message
                );
            }
        }
    }
}