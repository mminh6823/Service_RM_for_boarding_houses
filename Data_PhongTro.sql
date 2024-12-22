INSERT INTO dayTro (tenDayTro, soLuongPhong) VALUES 
('Dãy A', 10),
('Dãy B', 15),
('Dãy C', 12);

INSERT INTO loaiPhong (tenLoaiPhong, gia, soNguoi) VALUES 
('Phòng đơn', 1500000, 1),
('Phòng đôi', 2500000, 2),
('Phòng gia đình', 4000000, 4);

INSERT INTO phong (tenPhong, IDLoaiPhong, conPhong, IDDayTro, SoNguoiDangO) VALUES 
('Phòng 101', 1, 1, 1, 1),
('Phòng 102', 2, 1, 1, 2),
('Phòng 103', 3, 0, 1, 4);

INSERT INTO nguoiThue (hoTen, gioiTinh, SDT, queQuan, ngaySinh, CMND_CCCD, Email, anhDaiDien, matTruocCCCD, matSauCMND) VALUES 
('Nguyễn Văn A', 1, '0912345678', 'Hà Nội', '1990-01-01', '012345678', 'a@gmail.com', 'anh_a.jpg', 'front_a.jpg', 'back_a.jpg'),
('Trần Thị B', 0, '0987654321', 'Hải Phòng', '1995-05-05', '123456789', 'b@gmail.com', 'anh_b.jpg', 'front_b.jpg', 'back_b.jpg'),
('Lê Văn C', 1, '0934567890', 'Đà Nẵng', '1992-03-10', '234567890', 'c@gmail.com', 'anh_c.jpg', 'front_c.jpg', 'back_c.jpg');

INSERT INTO thuePhong (IDPhong, IDNguoiThue, ngayThue, ngayTra, tienCoc) VALUES 
(1, 1, '2024-01-01', '2024-06-01', 1000000),
(2, 2, '2024-02-01', '2024-07-01', 2000000),
(3, 3, '2024-03-01', '2024-08-01', 3000000);

INSERT INTO hoaDon (IDThuePhong, ngayThanhToan, soTienThanhToan, trangThai, CMND_CCCD, tenPhong, loaiPhong, giaPhong, dienTieuThu, giaDien, nuocTieuThu, giaNuoc, DSdichVuSuDung, DSGiaDichVuSuDung) VALUES 
(1, '2024-02-01', 1600000, 1, '012345678', 'Phòng 101', 'Phòng đơn', 1500000, 50, 3000, 5, 15000, 'Nước uống', '20000'),
(2, '2024-03-01', 2700000, 1, '123456789', 'Phòng 102', 'Phòng đôi', 2500000, 40, 3000, 3, 15000, 'Internet', '100000'),
(3, '2024-04-01', 4300000, 1, '234567890', 'Phòng 103', 'Phòng gia đình', 4000000, 60, 3000, 10, 15000, 'Dịch vụ vệ sinh', '30000');

INSERT INTO dienNuoc (IDPhong, thoiGianHoaDon, dienTieuThu, giaDien, nuocTieuThu, giaNuoc) VALUES 
(1, '2024-02-01', 50, 3000, 5, 15000),
(2, '2024-03-01', 40, 3000, 3, 15000),
(3, '2024-04-01', 60, 3000, 10, 15000);

INSERT INTO dichVu (tenDichVu, giaDichVu) VALUES 
('Nước uống', 20000),
('Internet', 100000),
('Dịch vụ vệ sinh', 30000);

INSERT INTO dichVuSuDung (IDPhong, IDDichVu) VALUES 
(1, 1),
(2, 2),
(3, 3);
