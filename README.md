# HỆ THỐNG QUẢN LÝ CHẤM CÔNG VÀ TÍNH LƯƠNG NHÂN VIÊN

## Giới thiệu

Hệ thống quản lý chấm công và tính lương nhân viên được xây dựng bằng WinForms kết hợp ASP.NET Core Web API và SQL Server.

Đồ án được phát triển nhằm áp dụng các kiến thức:

- Mô hình 3 lớp (3-Layer Architecture)
- ADO.NET
- Entity Framework
- LINQ
- RESTful API
- SQL Server
- JSON
- Transaction
- Stored Procedure
- Trigger

Hệ thống hỗ trợ quản lý toàn bộ quy trình:

- Quản lý nhân viên
- Phân ca làm việc
- Chấm công
- Nghỉ phép
- Thưởng phạt
- Tính lương
- Chốt bảng lương

---

# Công nghệ sử dụng

## Frontend

- Windows Forms (.NET Framework 4.8)

## Backend

- ASP.NET Core Web API (.NET 8)

## Database

- Microsoft SQL Server

## Công nghệ truy xuất dữ liệu

- ADO.NET
- Entity Framework Core
- LINQ

## RESTful API

- JSON
- Swagger

---

# Kỹ thuật áp dụng

## ADO.NET

Sử dụng:

- SqlConnection
- SqlCommand
- SqlDataReader
- DataTable
- DataSet

## Entity Framework

Sử dụng:

- DbContext
- DbSet
- Database First
- Code First

## LINQ

Áp dụng:

- LINQ to Objects
- LINQ truy vấn dữ liệu

## SQL Server

Áp dụng:

- Stored Procedure
- Trigger
- View
- Function
- Transaction

## RESTful API

Áp dụng:

- HTTP Methods
- JSON Response
- Swagger API

---

# Phiên bản phần mềm sử dụng

| Thành phần | Phiên bản |
|---|---|
| Visual Studio | 2022 |
| .NET Framework | 4.8 |
| .NET | 8.0 |
| ASP.NET Core | 8.0 |
| SQL Server | SQL Server |
| SQL Server Management Studio | SSMS 19 |
| Newtonsoft.Json | 13.0.4 |
| Microsoft.Data.SqlClient | 7.0.1 |
| Swashbuckle.AspNetCore | 6.6.2 |

---

# Kiến trúc hệ thống

Hệ thống được xây dựng theo mô hình 3 lớp:

```text
Presentation Layer
        ↓
Business Logic Layer
        ↓
Data Access Layer
```

## 1. Presentation Layer

- Giao diện WinForms
- UserControl
- Form thao tác dữ liệu
- Hiển thị báo cáo
- Điều hướng chức năng

## 2. Business Logic Layer

- Xử lý nghiệp vụ
- Validation dữ liệu
- Tính toán lương
- Tính tăng ca
- Xử lý nghỉ phép
- Tổng hợp dữ liệu chấm công

## 3. Data Access Layer

- SQL Server
- ADO.NET
- Entity Framework
- LINQ
- RESTful API
- Transaction
- Stored Procedure
- Trigger

---

# Chức năng hệ thống

## 1. Quản lý nhân viên

- Thêm nhân viên
- Cập nhật thông tin nhân viên
- Xóa nhân viên
- Tìm kiếm nhân viên
- Quản lý thông tin cá nhân

## 2. Quản lý ca làm

- Thêm ca làm việc
- Cập nhật ca làm
- Xóa ca làm
- Quản lý thời gian bắt đầu/kết thúc
- Quản lý thời gian làm

## 3. Phân ca làm việc

- Phân ca cho nhân viên (thêm/xóa)
- Kiểm tra trùng lịch
- Xem lịch làm việc

## 4. Quản lý cấu hình lương

- Lương cơ bản
- Lương theo giờ
- Tiền tăng ca theo giờ
- Phụ cấp

## 5. Quản lý nghỉ phép năm

- Cấp ngày nghỉ phép năm
- Theo dõi số ngày nghỉ có phép
- Theo dõi số ngày nghỉ không phép

## 6. Chấm công

- Check-in
- Check-out
- Tính đi trễ
- Tính về sớm
- Tính số phút bị trừ
- Tính tăng ca
- Quản lý trạng thái chấm công (đúng giờ hoặc không)

## 7. Quản lý chấm công

- Chấm công vào ca làm
- Check-in
- Check-out
- Ghi nhận thời gian làm việc
- Tính số phút đi trễ
- Tính số phút về sớm
- Tính số phút tăng ca
- Tính số phút bị trừ
- Kiểm tra trạng thái đi làm
- Quản lý lịch sử chấm công
- Đồng bộ dữ liệu với bảng lương
- Thống kê công theo tháng

## 8. Quản lý nghỉ phép

- Tạo đơn nghỉ phép
- Duyệt có phép/không phép

## 9. Báo cáo chấm công

- Thống kê số ca làm được phân
- Thống kê số ca vắng
- Thống kê đi trễ

## 10. Quản lý bảng lương

- Tổng hợp dữ liệu công
- Tính lương theo tháng
- Tính tăng ca
- Tính thưởng phạt
- Chốt bảng lương
- Xem chi tiết hiệu suất làm
- Xem chi tiết bảng lương

## 11. Quản lý thưởng phạt

- Thêm thưởng
- Thêm phạt
- Cập nhật thưởng phạt
- Xóa thưởng phạt
- Tổng hợp vào bảng lương

---

# API Routes

```text
/api/NhanVien
/api/CaLam
/api/PhanCa
/api/ChamCong
/api/NghiPhep
/api/NghiPhepNam
/api/ThuongPhat
/api/CauHinhLuong
/api/BangLuongChot
```

---

# Các bảng dữ liệu chính

## nhan_vien

| Trường | Chức năng |
|---|---|
| id | Khóa chính nhân viên |
| ho_ten | Họ tên nhân viên |
| gioi_tinh | Giới tính |
| ngay_sinh | Ngày sinh |
| so_dien_thoai | Số điện thoại |
| dia_chi | Địa chỉ |
| trang_thai | Trạng thái làm việc |

---

## ca_lam

| Trường | Chức năng |
|---|---|
| id | Khóa chính ca làm |
| ten_ca | Tên ca làm |
| gio_bat_dau | Giờ bắt đầu |
| gio_ket_thuc | Giờ kết thúc |
| so_gio_lam | Tổng thời gian ca làm |

---

## phan_ca

| Trường | Chức năng |
|---|---|
| id | Khóa chính phân ca |
| nhan_vien_id | Nhân viên được phân ca |
| ca_lam_id | Ca làm được phân |
| ngay_lam | Ngày làm việc |
| trang_thai | Trạng thái phân ca |

---

## cham_cong

| Trường | Chức năng |
|---|---|
| id | Khóa chính chấm công |
| nhan_vien_id | Nhân viên chấm công |
| phan_ca_id | Ca làm tương ứng |
| check_in | Thời gian vào ca |
| check_out | Thời gian ra ca |
| phut_di_tre | Tổng phút đi trễ |
| phut_ve_som | Tổng phút về sớm |
| phut_tang_ca | Tổng phút tăng ca |
| phut_bi_tru | Tổng phút bị trừ |
| trang_thai | Trạng thái chấm công |

---

## nghi_phep

| Trường | Chức năng |
|---|---|
| id | Khóa chính nghỉ phép |
| nhan_vien_id | Nhân viên nghỉ |
| ngay_nghi | Ngày nghỉ |
| ly_do | Lý do nghỉ |
| co_phep | Trạng thái có phép/không phép |
| trang_thai_duyet | Trạng thái xét duyệt |

---

## nghi_phep_nam

| Trường | Chức năng |
|---|---|
| id | Khóa chính phép năm |
| nhan_vien_id | Nhân viên |
| tong_ngay_phep | Tổng ngày phép |
| da_su_dung | Số ngày đã dùng |
| con_lai | Số ngày còn lại |

---

## thuong_phat

| Trường | Chức năng |
|---|---|
| id | Khóa chính thưởng phạt |
| nhan_vien_id | Nhân viên áp dụng |
| loai | Thưởng hoặc phạt |
| so_tien | Số tiền |
| noi_dung | Nội dung |
| ngay_ap_dung | Thời gian áp dụng |

---

## cau_hinh_luong

| Trường | Chức năng |
|---|---|
| id | Khóa chính cấu hình |
| luong_co_ban | Lương cơ bản |
| luong_theo_gio | Lương theo giờ |
| luong_tang_ca | Lương tăng ca |
| phu_cap | Phụ cấp |
| muc_phat | Mức phạt |

---

## bang_luong_chot

| Trường | Chức năng |
|---|---|
| id | Khóa chính bảng lương |
| nhan_vien_id | Nhân viên |
| thang | Tháng lương |
| nam | Năm lương |
| tong_ca_duoc_phan | Tổng ca được phân |
| tong_ca_di_lam | Tổng ca đi làm |
| tong_ca_nghi | Tổng ca nghỉ |
| tong_phut_di_tre | Tổng phút đi trễ |
| tong_phut_ve_som | Tổng phút về sớm |
| tong_phut_bi_tru | Tổng phút bị trừ |
| tong_phut_tang_ca | Tổng phút tăng ca |
| luong_co_ban | Lương cơ bản |
| tong_thuong | Tổng tiền thưởng |
| tong_phat | Tổng tiền phạt |
| luong_thuc_nhan | Tổng lương thực nhận |

---

# Cấu trúc Project

```text
ChamCongSolution
│
├── QuanLyChamCong
│   │
│   ├── GUI
│   │   ├── FrmBangLuongChotChiTiet
│   │   ├── FrmCaLamEdit
│   │   ├── FrmCauHinhLuong
│   │   ├── FrmNghiPhepEdit
│   │   ├── FrmNghiPhepNamEdit
│   │   ├── FrmNhanVienEdit
│   │   ├── FrmQuanLyChamCongEdit
│   │   ├── FrmThuongPhatEdit
│   │   ├── UcBangLuongChot
│   │   ├── UcBaoCaoChamCong
│   │   ├── UcCaLam
│   │   ├── UcCauHinhLuong
│   │   ├── UcChamCong
│   │   ├── UcNghiPhep
│   │   ├── UcNghiPhepNam
│   │   ├── UcNhanVien
│   │   ├── UcPhanCa
│   │   ├── UcQuanLyChamCong
│   │   └── UcThuongPhat
│   │
│   ├── Models
│   │   ├── BangLuongChot.cs
│   │   ├── CaLam.cs
│   │   ├── CauHinhLuong.cs
│   │   ├── ChamCong.cs
│   │   ├── NghiPhep.cs
│   │   ├── NghiPhepNam.cs
│   │   ├── NhanVien.cs
│   │   ├── PhanCa.cs
│   │   └── ThuongPhat.cs
│   │
│   ├── Services
│   │   ├── BangLuongChotService.cs
│   │   ├── CaLamService.cs
│   │   ├── CauHinhLuongService.cs
│   │   ├── ChamCongService.cs
│   │   ├── NghiPhepNamService.cs
│   │   ├── NghiPhepService.cs
│   │   ├── NhanVienService.cs
│   │   ├── PhanCaService.cs
│   │   ├── QuanLyChamCongService.cs
│   │   └── ThuongPhatService.cs
│   │
│   ├── THEME
│   │   ├── AppColors.cs
│   │   ├── AppFonts.cs
│   │   ├── AppStyles.cs
│   │   ├── BaseForm.cs
│   │   ├── BaseUserControl.cs
│   │   ├── CustomMessageBox.cs
│   │   └── frmMessageBox.cs
│   │
│   └── Properties
│
├── QuanLyChamCong.API
│   │
│   ├── Controllers
│   │   ├── BangLuongChotController.cs
│   │   ├── CaLamController.cs
│   │   ├── CauHinhLuongController.cs
│   │   ├── ChamCongController.cs
│   │   ├── NghiPhepController.cs
│   │   ├── NghiPhepNamController.cs
│   │   ├── NhanVienController.cs
│   │   ├── PhanCaController.cs
│   │   └── ThuongPhatController.cs
│   │
│   ├── Models
│   │   ├── BangLuongChot.cs
│   │   ├── CaLam.cs
│   │   ├── CauHinhLuong.cs
│   │   ├── ChamCong.cs
│   │   ├── NghiPhep.cs
│   │   ├── NghiPhepNam.cs
│   │   ├── NhanVien.cs
│   │   ├── PhanCa.cs
│   │   └── ThuongPhat.cs
│   │
│   ├── Data
│   │   └── Db.cs
│   │
│   ├── Program.cs
│   ├── appsettings.json
│   └── Web.config
│
└── Database
    ├── SQL Scripts
    ├── Stored Procedures
    ├── Trigger
    ├── Views
    └── Functions
```
---

# Dữ liệu Demo

Hệ thống đã được tích hợp sẵn dữ liệu mẫu trong cơ sở dữ liệu nhằm hỗ trợ quá trình kiểm thử và trình bày đồ án.


- Mã vân tay được định dạng:

```text
IDFA0001
IDFA0002
IDFA0003
```

Trong đó:

- `ID` là mã định danh nhân viên
- `FA` là viết tắt của Fingerprint Authentication
- 4 chữ số cuối tương ứng với mã nhân viên

## Tài khoản quản trị mặc định

```text
Tên đăng nhập : admin
Mật khẩu      : 1231
```

## Dữ liệu mẫu bao gồm

- Danh sách nhân viên
- Ca làm việc
- Phân ca làm
- Chấm công
- Nghỉ phép
- Cấu hình lương
- Thưởng và phạt
- Bảng lương tổng hợp

---

# Luồng hoạt động hệ thống

```text
Người dùng thao tác trên WinForms
            ↓
WinForms gửi HTTP Request
            ↓
ASP.NET Core Web API tiếp nhận request
            ↓
Controller xử lý yêu cầu
            ↓
Service xử lý nghiệp vụ
            ↓
Truy vấn SQL Server
            ↓
Dữ liệu trả về dạng JSON
            ↓
WinForms hiển thị dữ liệu
```

---

# Hướng phát triển

- JWT Authentication
- Dashboard thống kê
- Export Excel/PDF
- Realtime Notification
- Mobile Application
- Face Recognition chấm công
- Firebase

---

# Github

```text
https://github.com/tranvantrihuu/QuanLyChamCongWinform
```

