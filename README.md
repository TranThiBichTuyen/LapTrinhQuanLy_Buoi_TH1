# QuanLyBanHang

Ứng dụng **Quản Lý Bán Hàng** viết bằng **C# WinForms** sử dụng **Entity Framework Core** và **SQL Server**.

## Công nghệ sử dụng
- C# WinForms
- .NET
- Entity Framework Core 9.0.12
- SQL Server
- Visual Studio

## Cấu hình cơ sở dữ liệu
- Đã cập nhật `App.config` để kết nối tới SQL Server với:
  - `Trusted_Connection=True`
  - Sử dụng instance SQL Server cục bộ

## Các chức năng chính
- Quản lý Hãng Sản Xuất
- Quản lý Loại Sản Phẩm
- Quản lý Sản Phẩm
- Quản lý Khách Hàng
- Quản lý Nhân Viên
- Quản lý Hóa Đơn và Chi Tiết Hóa Đơn
- Thực hiện CRUD (Thêm / Sửa / Xóa / Xem)

## Các thay đổi chính
- Thêm các model:
  - `HangSanXuat`
  - `LoaiSanPham`
  - `SanPham`
  - `KhachHang`
  - `NhanVien`
  - `HoaDon`
  - `HoaDon_ChiTiet`
- Cập nhật `QLBHDbContext` với các `DbSet`
- Cập nhật giao diện:
  - `frmHangSanXuat`
  - `frmLoaiSanPham`
- Đổi form khởi động thành `frmHangSanXuat`
- Tạo và cập nhật Migration cho cơ sở dữ liệu
- Bổ sung Resource phục vụ giao diện và localization

## Hướng dẫn chạy project
1. Clone repository:
   ```bash
   git clone https://github.com/TranThiBichTuyen/QuanLyBanHang.git
