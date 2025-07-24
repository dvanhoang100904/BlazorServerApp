CREATE DATABASE BlazorServerApp;
GO

USE BlazorServerApp;
GO

CREATE TABLE tbl_DM_Don_Vi_Tinh (
	Id INT IDENTITY PRIMARY KEY,
	Ten_Don_Vi_Tinh NVARCHAR(100) NOT NULL UNIQUE,
	Ghi_Chu NVARCHAR(255)
);
GO

CREATE TABLE tbl_DM_Loai_San_Pham (
	Id INT IDENTITY PRIMARY KEY,
	Ma_Loai_San_Pham NVARCHAR(50) NOT NULL UNIQUE,
	Ten_Loai_San_Pham NVARCHAR(100) NOT NULL UNIQUE,
	Ghi_Chu NVARCHAR(255)
);
GO

CREATE TABLE tbl_DM_San_Pham (
	Id INT IDENTITY PRIMARY KEY,
	Ma_San_Pham NVARCHAR(50) NOT NULL UNIQUE,
	Ten_San_Pham NVARCHAR(100) NOT NULL,
	Loai_San_Pham_ID INT NOT NULL,
	Don_Vi_Tinh_ID INT NOT NULL,
	Ghi_Chu NVARCHAR(255),

	CONSTRAINT FK_SanPham_LoaiSanPham 
	FOREIGN KEY (Loai_San_Pham_ID)
	REFERENCES tbl_DM_Loai_San_Pham(Id),

	CONSTRAINT FK_SanPham_DonViTinh 
	FOREIGN KEY (Don_Vi_Tinh_ID)
	REFERENCES tbl_DM_Don_Vi_Tinh(Id)
);
GO

CREATE TABLE tbl_DM_Nha_Cung_Cap (
	Id INT IDENTITY PRIMARY KEY,
	Ma_Nha_Cung_Cap NVARCHAR(50) NOT NULL UNIQUE,
	Ten_Nha_Cung_Cap NVARCHAR(100) NOT NULL UNIQUE,
	Ghi_Chu NVARCHAR(255)
)
GO

CREATE TABLE tbl_DM_Kho (
	Id INT IDENTITY PRIMARY KEY,
	Ten_Kho NVARCHAR(100) NOT NULL UNIQUE,
	Ghi_Chu NVARCHAR(255)
);
GO

CREATE TABLE tbl_DM_Kho_User (
	Id INT IDENTITY PRIMARY KEY,
	Ma_Dang_Nhap NVARCHAR(50) NOT NULL,
	Kho_ID INT NOT NULL,
	
	CONSTRAINT UQ_KhoUser 
	UNIQUE (Ma_Dang_Nhap, Kho_ID),

	CONSTRAINT FK_KhoUser_Kho
	FOREIGN KEY (Kho_ID)
	REFERENCES tbl_DM_Kho(Id)
);
GO

CREATE TABLE tbl_DM_Nhap_Kho (
	Id INT IDENTITY PRIMARY KEY,
	So_Phieu_Nhap_Kho NVARCHAR(100) NOT NULL UNIQUE,
	Kho_ID INT NOT NULL,
	Nha_Cung_Cap_ID INT NOT NULL,
	Ngay_Nhap_Kho DATE NOT NULL,
	Ghi_Chu NVARCHAR(255),

	CONSTRAINT FK_NhapKho_Kho
	FOREIGN KEY (Kho_ID)
	REFERENCES tbl_DM_Kho(Id),

	CONSTRAINT FK_NhapKho_NhaCungCap
	FOREIGN KEY (Nha_Cung_Cap_ID)
	REFERENCES tbl_DM_Nha_Cung_Cap(Id)
);
GO

CREATE TABLE tbl_DM_Nhap_Kho_Raw_Data (
	Id INT IDENTITY PRIMARY KEY,
	Nhap_Kho_ID INT NOT NULL,
	San_Pham_ID INT NOT NULL,
	So_Luong_Nhap INT NOT NULL,
	Don_Gia_Nhap FLOAT NOT NULL,

	CONSTRAINT FK_NhapKhoRawData_NhapKho
	FOREIGN KEY (Nhap_Kho_ID)
	REFERENCES tbl_DM_Nhap_Kho(Id),

	CONSTRAINT FK_NhapKhoRawData_SanPham
	FOREIGN KEY (San_Pham_ID)
	REFERENCES tbl_DM_San_Pham(Id)
);
GO

CREATE TABLE tbl_XNK_Nhap_Kho (
	Id INT IDENTITY PRIMARY KEY,
	So_Phieu_Nhap_Kho NVARCHAR(100) NOT NULL UNIQUE,
	Kho_ID INT NOT NULL,
	Nha_Cung_Cap_ID INT NOT NULL,
	Ngay_Nhap_Kho DATE NOT NULL,

	CONSTRAINT FK_XNKNhapKho_Kho
	FOREIGN KEY (Kho_ID)
	REFERENCES tbl_DM_Kho(Id),

	CONSTRAINT FK_XNKNhapKho_NhaCungCap
	FOREIGN KEY (Nha_Cung_Cap_ID)
	REFERENCES tbl_DM_Nha_Cung_Cap(Id)
);
GO

CREATE TABlE tbl_DM_Xuat_Kho (
	Id INT IDENTITY PRIMARY KEY,
	So_Phieu_Xuat_Kho NVARCHAR(100) NOT NULL UNIQUE,
	Kho_ID INT NOT NULL,
	Ngay_Xuat_Kho DATE NOT NULL,
	Ghi_Chu NVARCHAR(255),

	CONSTRAINT FK_XuatKho_Kho
	FOREIGN KEY (Kho_ID)
	REFERENCES tbl_DM_Kho(Id)
);
GO

CREATE TABLE tbl_DM_Xuat_Kho_Raw_Data (
	Id INT IDENTITY PRIMARY KEY,
	Xuat_Kho_ID INT NOT NULL,
	San_Pham_ID INT NOT NULL,
	So_Luong_Xuat INT NOT NULL,
	Don_Gia_Xuat FLOAT NOT NULL,

	CONSTRAINT FK_XuatKhoRawData_XuatKho
	FOREIGN KEY (Xuat_Kho_ID)
	REFERENCES tbl_DM_Xuat_Kho(Id),

	CONSTRAINT FK_XuatKhoRawData_SanPham
	FOREIGN KEY (San_Pham_ID)
	REFERENCES tbl_DM_San_Pham(Id)
);
GO

CREATE TABLE tbl_XNK_Xuat_Kho (
	Id INT IDENTITY PRIMARY KEY,
	So_Phieu_Xuat_Kho NVARCHAR(100) NOT NULL UNIQUE,
	Kho_ID INT NOT NULL,
	Ngay_Xuat_Kho DATE NOT NULL,

	CONSTRAINT FK_XNKXuatKho_Kho
	FOREIGN KEY (Kho_ID)
	REFERENCES tbl_DM_Kho(Id)

);
GO

INSERT INTO tbl_DM_Don_Vi_Tinh (Ten_Don_Vi_Tinh, Ghi_Chu)
VALUES
(N'Cái', N'Đơn vị tính phổ biến'),
(N'Hộp', N'Dùng cho sản phẩm đóng gói'),
(N'Kg', N'Tính theo khối lượng');
GO

INSERT INTO tbl_DM_Loai_San_Pham(Ma_Loai_San_Pham, Ten_Loai_San_Pham, Ghi_Chu)
VALUES
(N'LSP001', N'Thực phẩm', N'Thực phẩm đóng gói'),
(N'LSP002', N'Đồ gia dụng', N'Sản phẩm gia dụng hàng ngày'),
(N'LSP003', N'Nước uống', N'Nước khoáng, nước ngọt');
GO

INSERT INTO tbl_DM_San_Pham (Ma_San_Pham, Ten_San_Pham, Loai_San_Pham_ID, Don_Vi_Tinh_ID, Ghi_Chu)
VALUES
(N'SP001', N'Mì Hảo Hảo', 1, 1, N'Mì gói phổ biến'),
(N'SP002', N'Nồi cơm điện Sharp', 2, 1, N'Nồi cơm 1.8L'),
(N'SP003', N'Nước suối Aquafina 500ml', 3, 1, N'Chai nước suối');
GO

INSERT INTO tbl_DM_Nha_Cung_Cap (Ma_Nha_Cung_Cap, Ten_Nha_Cung_Cap, Ghi_Chu)
VALUES
(N'NCC001', N'Công ty CP Thực phẩm Á Châu', N'Chuyên cung cấp mì gói'),
(N'NCC002', N'Công ty Điện Máy Xanh', N'Cung cấp thiết bị điện'),
(N'NCC003', N'Công ty Nước Uống Việt Nam', N'Nước uống đóng chai');
GO

INSERT INTO tbl_DM_Kho (Ten_Kho, Ghi_Chu)
VALUES
(N'Kho Chính', N'Kho trung tâm'),
(N'Kho Chi Nhánh 1', N'Kho tại chi nhánh HN'),
(N'Kho Chi Nhánh 2', N'Kho tại chi nhánh SG');
GO

INSERT INTO tbl_DM_Kho_User (Ma_Dang_Nhap, Kho_ID)
VALUES
(N'hoang1', 1),
(N'hoang2', 2);
GO

INSERT INTO tbl_DM_Nhap_Kho (So_Phieu_Nhap_Kho, Kho_ID, Nha_Cung_Cap_ID, Ngay_Nhap_Kho, Ghi_Chu)
VALUES
(N'PN001', 1, 1, '2025-07-20', N'Nhập mì Hảo Hảo đợt 1'),
(N'PN002', 2, 3, '2025-07-21', N'Nhập nước suối đợt 1');
GO

INSERT INTO tbl_DM_Nhap_Kho_Raw_Data (Nhap_Kho_ID, San_Pham_ID, So_Luong_Nhap, Don_Gia_Nhap)
VALUES
(1, 1, 1000, 2500),
(2, 3, 500, 4000);
GO

INSERT INTO tbl_XNK_Nhap_Kho (So_Phieu_Nhap_Kho, Kho_ID, Nha_Cung_Cap_ID, Ngay_Nhap_Kho)
VALUES
(N'PN001', 1, 1, '2025-07-20'),
(N'PN002', 2, 3, '2025-07-21');
GO

INSERT INTO tbl_DM_Xuat_Kho (So_Phieu_Xuat_Kho, Kho_ID, Ngay_Xuat_Kho, Ghi_Chu)
VALUES
(N'PX001', 1, '2025-07-20', N'Xuất hàng đi chi nhánh'),
(N'PX002', 2, '2025-07-21', N'Xuất hàng cho khách');
GO

INSERT INTO tbl_DM_Xuat_Kho_Raw_Data (Xuat_Kho_ID, San_Pham_ID, So_Luong_Xuat, Don_Gia_Xuat)
VALUES
(1, 1, 200, 3000),
(2, 3, 100, 4500);
GO

INSERT INTO tbl_XNK_Xuat_Kho (So_Phieu_Xuat_Kho, Kho_ID, Ngay_Xuat_Kho)
VALUES
(N'PX001', 1, '2025-07-20'),
(N'PX002', 2, '2025-07-21');
GO


SELECT * 
FROM tbl_DM_Don_Vi_Tinh;

SELECT * 
FROM tbl_DM_Loai_San_Pham;

SELECT * 
FROM tbl_DM_San_Pham;

SELECT * 
FROM tbl_DM_Nha_Cung_Cap;

SELECT * 
FROM tbl_DM_Kho;

SELECT *
FROM tbl_DM_Kho_User;

SELECT * 
FROM tbl_DM_Nhap_Kho;

SELECT * 
FROM tbl_DM_Nhap_Kho_Raw_Data;

SELECT *
FROM tbl_XNK_Nhap_Kho;

SELECT *
FROM tbl_DM_Xuat_Kho;

SELECT *
FROM tbl_DM_Xuat_Kho_Raw_Data;

SELECT *
FROM tbl_XNK_Xuat_Kho;
GO