using Newtonsoft.Json;
using QuanLyChamCong.Models;
using QuanLyChamCong.Models.ViewModels;

using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.Services
{
    public class BangLuongChotService
    {
        private readonly string baseUrl =
            "https://localhost:7133/api/BangLuongChot";

        private HttpClient GetClient()
        {
            HttpClientHandler handler =
                new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (a, b, c, d) => true;

            return new HttpClient(handler);
        }

        /*
         * GET ALL
         */

        public async Task<List<VwBangLuongChot>>
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
                        return new List<VwBangLuongChot>();
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<List<VwBangLuongChot>>(json)
                        ?? new List<VwBangLuongChot>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return new List<VwBangLuongChot>();
            }
        }

        /*
         * GET DETAIL
         */

        public async Task<BangLuongChot>
            GetById(int id)
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(
                            $"{baseUrl}/{id}"
                        );

                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<BangLuongChot>(
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

        /*
         * INSERT
         */

        public async Task<bool>
            Insert(BangLuongChot model)
        {
            try
            {
                using (HttpClient client = GetClient())
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
                            baseUrl,
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

        /*
         * UPDATE
         */

        public async Task<bool>
            Update(BangLuongChot model)
        {
            try
            {
                using (HttpClient client = GetClient())
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
                            $"{baseUrl}/{model.id}",
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

        /*
         * DELETE
         */

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

        /*
         * LỌC THÁNG NĂM
         */

        public async Task<List<VwBangLuongChot>>
            GetByThangNam(
                int thang,
                int nam
            )
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(
                            $"{baseUrl}/loc?thang={thang}&nam={nam}"
                        );

                    if (!response.IsSuccessStatusCode)
                    {
                        return new List<VwBangLuongChot>();
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<List<VwBangLuongChot>>(json)
                        ?? new List<VwBangLuongChot>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return new List<VwBangLuongChot>();
            }
        }

        /*
         * THEO NHÂN VIÊN
         */

        public async Task<List<VwBangLuongChot>>
            GetByNhanVien(string nhanVienId)
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(
                            $"{baseUrl}/nhanvien/{nhanVienId}"
                        );

                    if (!response.IsSuccessStatusCode)
                    {
                        return new List<VwBangLuongChot>();
                    }

                    string json =
                        await response.Content
                        .ReadAsStringAsync();

                    return JsonConvert
                        .DeserializeObject<List<VwBangLuongChot>>(json)
                        ?? new List<VwBangLuongChot>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return new List<VwBangLuongChot>();
            }
        }

        /*
         * ĐÃ CHỐT LƯƠNG
         */

        public async Task<bool>
            DaChotLuong(
                int thang,
                int nam
            )
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(
                            $"{baseUrl}/DaChotLuong?thang={thang}&nam={nam}"
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

        /*
         * TÍNH BẢNG LƯƠNG
         */

        public async Task<bool>
            TinhBangLuong(
                int thang,
                int nam
            )
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    HttpResponseMessage response =
                        await client.PostAsync(
                            $"{baseUrl}/tinh-luong?thang={thang}&nam={nam}",
                            null
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