-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th2 12, 2023 lúc 06:37 PM
-- Phiên bản máy phục vụ: 10.4.27-MariaDB
-- Phiên bản PHP: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `cachlycovid19`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `cn_tc`
--

CREATE TABLE `cn_tc` (
  `MaCongNhan` varchar(5) NOT NULL,
  `MaTrieuChung` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `cn_tc`
--

INSERT INTO `cn_tc` (`MaCongNhan`, `MaTrieuChung`) VALUES
('CN01', 'TT01'),
('CN01', 'TT02'),
('CN01', 'TT03'),
('CN02', 'TT01'),
('CN02', 'TT03');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `congnhan`
--

CREATE TABLE `congnhan` (
  `MaCongNhan` varchar(5) NOT NULL,
  `TenCongNhan` varchar(100) NOT NULL,
  `GioiTinh` tinyint(1) NOT NULL,
  `NamSinh` int(11) NOT NULL,
  `NuocVe` varchar(50) NOT NULL,
  `MaDiemCachLy` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `congnhan`
--

INSERT INTO `congnhan` (`MaCongNhan`, `TenCongNhan`, `GioiTinh`, `NamSinh`, `NuocVe`, `MaDiemCachLy`) VALUES
('CN01', 'Nguyễn Văn Hiếu', 1, 2001, 'Anh', 'DCL01'),
('CN02', 'Hồng Cúc', 0, 1995, 'Nhật', 'DCL01'),
('CN03', 'Nguyễn Văn A', 1, 1987, 'Viet Nam', 'DCL03'),
('CN04', 'Trần Thị B', 2, 2003, 'Thai Lan', 'DCL02'),
('CN05', 'Ly Thanh Binh', 1, 2000, 'Viet Nam', 'DCL02'),
('CN06', 'Thai Van Tai', 1, 1897, 'Viet Nam', 'DCL01');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `diemcachly`
--

CREATE TABLE `diemcachly` (
  `MaDiemCachLy` varchar(5) NOT NULL,
  `TenDiemCachLy` varchar(100) NOT NULL,
  `DiaChi` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `diemcachly`
--

INSERT INTO `diemcachly` (`MaDiemCachLy`, `TenDiemCachLy`, `DiaChi`) VALUES
('DCL01', 'Biên Hòa', 'DC1'),
('DCL02', 'KTX Khu B', 'Bình Dương'),
('DCL03', 'Dĩ An', 'DC3');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `trieuchung`
--

CREATE TABLE `trieuchung` (
  `MaTrieuChung` varchar(5) NOT NULL,
  `TenTrieuChung` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `trieuchung`
--

INSERT INTO `trieuchung` (`MaTrieuChung`, `TenTrieuChung`) VALUES
('TT01', 'Sốt'),
('TT02', 'Ho'),
('TT03', 'Khó thở');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `cn_tc`
--
ALTER TABLE `cn_tc`
  ADD PRIMARY KEY (`MaCongNhan`,`MaTrieuChung`),
  ADD KEY `MaTrieuChung` (`MaTrieuChung`);

--
-- Chỉ mục cho bảng `congnhan`
--
ALTER TABLE `congnhan`
  ADD PRIMARY KEY (`MaCongNhan`),
  ADD KEY `MaDiemCachLy` (`MaDiemCachLy`);

--
-- Chỉ mục cho bảng `diemcachly`
--
ALTER TABLE `diemcachly`
  ADD PRIMARY KEY (`MaDiemCachLy`);

--
-- Chỉ mục cho bảng `trieuchung`
--
ALTER TABLE `trieuchung`
  ADD PRIMARY KEY (`MaTrieuChung`);

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `cn_tc`
--
ALTER TABLE `cn_tc`
  ADD CONSTRAINT `cn_tc_ibfk_1` FOREIGN KEY (`MaCongNhan`) REFERENCES `congnhan` (`MaCongNhan`),
  ADD CONSTRAINT `cn_tc_ibfk_2` FOREIGN KEY (`MaTrieuChung`) REFERENCES `trieuchung` (`MaTrieuChung`);

--
-- Các ràng buộc cho bảng `congnhan`
--
ALTER TABLE `congnhan`
  ADD CONSTRAINT `congnhan_ibfk_1` FOREIGN KEY (`MaDiemCachLy`) REFERENCES `diemcachly` (`MaDiemCachLy`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
