-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th2 12, 2023 lúc 10:19 AM
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
-- Cơ sở dữ liệu: `qlcs1`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `album`
--

CREATE TABLE `album` (
  `MaAlBum` varchar(10) NOT NULL,
  `TenAlBum` varchar(50) DEFAULT NULL,
  `MaCaSi` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `album`
--

INSERT INTO `album` (`MaAlBum`, `TenAlBum`, `MaCaSi`) VALUES
('AB02', 'Chiều Buồn 1', 'CS01'),
('AB03', 'Tuoi Thanh Xuan1', 'CS01'),
('AB04', 'Tuoi Thanh Xuan2', 'CS03'),
('AB05', 'Tuoi Thanh Xuan3', 'CS01'),
('AB06', 'Al cua', 'CS01');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `baihat`
--

CREATE TABLE `baihat` (
  `MaBaiHat` varchar(10) NOT NULL,
  `TenBaiHat` varchar(50) DEFAULT NULL,
  `TheLoai` varchar(20) DEFAULT NULL,
  `MaAlBum` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `baihat`
--

INSERT INTO `baihat` (`MaBaiHat`, `TenBaiHat`, `TheLoai`, `MaAlBum`) VALUES
('BH01', 'Mưa Phi Trường', 'Bolero', 'AB02'),
('BH02', 'Cơn mua ngang qua', 'VPOP', 'AB02'),
('BH03', 'Hoa no khong mau', 'VPOP', 'AB03'),
('BH04', 'Dau Mua', 'VPOP', 'AB04');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `casi`
--

CREATE TABLE `casi` (
  `MaCaSi` varchar(10) NOT NULL,
  `TenCaSi` varchar(50) DEFAULT NULL,
  `NgaySinh` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `casi`
--

INSERT INTO `casi` (`MaCaSi`, `TenCaSi`, `NgaySinh`) VALUES
('CS01', 'Nguyễn Phi Tùng', '2021-11-01'),
('CS02 ', 'Lam Trường', '2021-10-01'),
('CS03', 'Phi Nhung', '2021-10-02'),
('CS04', 'Phuong Thanh', '2021-10-03'),
('CS05', 'Đoan Trang', '2021-10-04'),
('CS06', 'Hiền Thục', '2021-10-05'),
('CS07', 'Nguyễn Titi', '2022-10-30'),
('CS08', 'Nguyễn Phi Ngựa', '2000-07-20'),
('CS09', 'Lữ Bố', '2000-07-20'),
('CS11', 'Nguyễn  Tuấn  Vũ', '2022-11-14'),
('CS16', 'Ton Nu Tu Quyen', '2023-02-01'),
('CS17', 'Ton Nu Tu Quyen', '2023-02-09');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `album`
--
ALTER TABLE `album`
  ADD PRIMARY KEY (`MaAlBum`),
  ADD KEY `fk_album_casi` (`MaCaSi`);

--
-- Chỉ mục cho bảng `baihat`
--
ALTER TABLE `baihat`
  ADD PRIMARY KEY (`MaBaiHat`),
  ADD KEY `fk_baihat_album` (`MaAlBum`);

--
-- Chỉ mục cho bảng `casi`
--
ALTER TABLE `casi`
  ADD PRIMARY KEY (`MaCaSi`);

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `album`
--
ALTER TABLE `album`
  ADD CONSTRAINT `fk_album_casi` FOREIGN KEY (`MaCaSi`) REFERENCES `casi` (`MaCaSi`);

--
-- Các ràng buộc cho bảng `baihat`
--
ALTER TABLE `baihat`
  ADD CONSTRAINT `fk_baihat_album` FOREIGN KEY (`MaAlBum`) REFERENCES `album` (`MaAlBum`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
