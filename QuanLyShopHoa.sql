USE MASTER
GO 
CREATE DATABASE QuanLyShopHoa
USE QuanLyShopHoa
GO 
--BANG TAI KHOAN 
CREATE TABLE TAIKHOAN
(
	MAKH INT IDENTITY(1,1)NOT NULL,
	HOTEN NVARCHAR(50),
	TENDN NVARCHAR(50),
	MATKHAU NCHAR(50),
	SDT NCHAR(12),
	NGAYSINH DATETIME,
	EMAIL VARCHAR(50),
	DIACHI NVARCHAR(MAX),
	QUYEN BIT,
	CONSTRAINT PK_TAIKHOAN PRIMARY KEY(MAKH)
)
select * from TAIKHOAN
--INSERT 2 ADMIN
SET DATEFORMAT DMY
SET IDENTITY_INSERT [dbo].[TAIKHOAN] ON 
INSERT [dbo].[TAIKHOAN] ([MAKH], [HOTEN], [TENDN], [MATKHAU],[SDT],[NGAYSINH],[EMAIL],[DIACHI],[QUYEN]) VALUES(1,N'Thanh Vy','thanhvy','1','0901682813','11/02/2000','thanhvyela@gmail.com','hcm',1);
INSERT [dbo].[TAIKHOAN] ([MAKH], [HOTEN], [TENDN], [MATKHAU],[SDT],[NGAYSINH],[EMAIL],[DIACHI],[QUYEN]) VALUES(2,N'Thanh Mai','thanhmai','1',NULL,NULL,'thanhmaiela@gmail.com',NULL,1);
INSERT [dbo].[TAIKHOAN] ([MAKH], [HOTEN], [TENDN], [MATKHAU],[SDT],[NGAYSINH],[EMAIL],[DIACHI],[QUYEN]) VALUES(3,N'Hữu Thắng','huuthang','1','0901','05/10/2000','thangsoyoung2k@gmail.com','TP.HCM',0);
SET IDENTITY_INSERT [dbo].[TAIKHOAN] OFF
--BANG KHACH HANG

--BANG LOAIHOA
CREATE TABLE LOAIHOA
(
	MALOAI NCHAR(5) NOT NULL,
	TENLOAI NVARCHAR(50),
	CONSTRAINT PK_LOAIHOA PRIMARY KEY(MALOAI)
)
--BANG HOA THEO CHU DE
CREATE TABLE CHUDE 
(
	MACHUDE NCHAR(5) NOT NULL,
	TENCHUDE NVARCHAR(50),
	CONSTRAINT PK_CHUDE PRIMARY KEY(MACHUDE)
)
--BANG HOA
CREATE TABLE HOA
(
	MAHOA NCHAR(5) NOT NULL,
	TENHOA NVARCHAR(MAX),
	MALOAI NCHAR(5),
	GIA DECIMAL(18,0),
	MOTA NVARCHAR(MAX),
	ANH NVARCHAR(MAX),
	MACHUDE NCHAR(5),
	CONSTRAINT PK_HOA PRIMARY KEY (MAHOA),
	CONSTRAINT FK_HOA_LOAIHOA  FOREIGN KEY(MALOAI) REFERENCES LOAIHOA(MALOAI),
	CONSTRAINT FK_HOA_CHUDE FOREIGN KEY (MACHUDE) REFERENCES CHUDE(MACHUDE)
)

--
SELECT * FROM HOA

--BANG DON HANG
CREATE TABLE DONHANG
(
	MADONHANG INT IDENTITY(1,1),
	NGAYGIAO DATE,
	NGAYDAT DATE,
	DATHANHTOAN NVARCHAR(50),
	TINHTRANGGIAOHANG NVARCHAR(MAX),
	MAKH INT ,
	CONSTRAINT PK_DONHANG PRIMARY KEY (MADONHANG),
	CONSTRAINT FK_DONHANG_TAIKHOAN FOREIGN KEY(MAKH) REFERENCES TAIKHOAN(MAKH)
)
--BANG CTDONHANG
CREATE TABLE CTDONHANG
(
	MADONHANG INT,
	MAHOA NCHAR(5) NOT NULL,
	SOLUONG INT,
	DONGIA DECIMAL(18,0),
	CONSTRAINT PK_CTDONHANG PRIMARY KEY (MADONHANG,MAHOA),
	CONSTRAINT FK_CTDONHANG_DONHANG FOREIGN KEY(MADONHANG) REFERENCES DONHANG(MADONHANG),
	CONSTRAINT FK_CTDONHANG_HOA FOREIGN KEY(MAHOA) REFERENCES HOA(MAHOA)
)
------------------------------------------------------------------------------
SELECT * FROM TAIKHOAN
SELECT * FROM LOAIHOA
SELECT * FROM CHUDE
SELECT * FROM HOA
SELECT * FROM DONHANG
SELECT * FROM CTDONHANG
------------------------------------------------------------------------------

--INSERT BẢNG KHÁCH HÀNG
SET DATEFORMAT DMY

--BẢNG LOẠI HOA
INSERT INTO LOAIHOA VALUES('ML001',N'Hoa Hồng');
INSERT INTO LOAIHOA VALUES('ML002',N'Hoa Hướng Dương');
INSERT INTO LOAIHOA VALUES('ML003',N'Hộp Quà Hoa');
INSERT INTO LOAIHOA VALUES('ML004',N'Kệ Hoa');
INSERT INTO LOAIHOA VALUES('ML005',N'Giỏ Hoa');
INSERT INTO LOAIHOA VALUES('ML006',N'Hoa Nhí');

--BẢNG CHỦ ĐỀ
INSERT INTO CHUDE VALUES('CD001',N'Sinh nhật');
INSERT INTO CHUDE VALUES('CD002',N'Lãng mạn');
INSERT INTO CHUDE VALUES('CD003',N'Hoa cưới');
INSERT INTO CHUDE VALUES('CD004',N'Cảm ơn');
INSERT INTO CHUDE VALUES('CD005',N'Chúc mừng');
INSERT INTO CHUDE VALUES('CD006',N'Chia buồn');

--BẢNG HOA
--'ML001',N'Hoa Hồng' --CD002 Lãng mạn: 9
--'ML002',N'Hoa Hướng Dương' --CD005 Chúc mừng : 3
--'ML003',N'Hộp Quà Hoa'); --CD001 Sinh Nhật
--'ML004',N'Kệ Hoa'); --CD001 Sinh Nhật
--'ML005',N'Giỏ Hoa'); --CD002 Lãng mạn
--'ML006',N'Hoa Nhí'); -- Baby -- CD004 Cảm ơn
INSERT INTO HOA VALUES(N'MH001', N'Nụ Hồng Mong Manh', N'ML001', 500000, N'Bó hoa Hồng đỏ đầy lãng mạn là món quà hoàn hảo thay lời muốn nói gửi đến người thương cũa bạn vào Valentine hoặc ngày kỷ niệm, sinh nhật.', N'002.jpeg','CD002'); --CD002
INSERT INTO HOA VALUES(N'MH002', N'Nàng Thơ', N'ML001', 450000, N'Bó hoa sang trọng và thanh lịch với các loại hoa Hồng được gói xinh xắn.
Đây sẽ là món quà bất ngờ và hoàn hảo dành tặng người thương, gia đình hoặc bạn bè.', N'001.jpeg','CD002'); --CD002
INSERT INTO HOA VALUES(N'MH003', N'Tiểu Thư Băng Giá', N'ML006', 650000, N'Bó hoa ngọt ngào và thanh khiết với hoa Cẩm Tú Cầu được gói xinh xắn.
Đây sẽ là món quà bất ngờ và hoàn hảo dành tặng người thương, gia đình hoặc bạn bè.', N'003.jpeg','CD004'); --CD004
INSERT INTO HOA VALUES(N'MH004', N'Một Cú Lừa', N'ML001', 500000, N'Bó hoa hồng đỏ đơn giản được gói rất trẻ trung và thanh lịch là một trong những mẫu Best Seller của chúng tôi.
Là lựa chọn hoàn hảo cho ngày Valentine hoặc bất kỳ dịp đặc biệt nào.', N'004.jpeg','CD002'); --CD002
INSERT INTO HOA VALUES(N'MH005', N'Áng Vàng', N'ML002', 240000, N'Bó hoa hướng dương rực rỡ được gói bằng giấy kraft Gorgeous You làm tăng thêm phần sang trọng cho bó hoa. Đây sẽ là món quà bất ngờ và hoàn hảo dành tặng người thương, gia đình hoặc bạn bè.', N'005.jpeg','CD005');--CD005
INSERT INTO HOA VALUES(N'MH006', N'Hoàng Kim', N'ML002', 350000, N'Bó hoa được gói đẹp mắt và hiện đại với sự kết hợp của Hướng Dương và Salem tím xinh xắn là lựa chọn hoàn hảo cho ngày Valentine hoặc bất kỳ dịp đặc biệt nào.', N'006.jpeg','CD005');--CD005
INSERT INTO HOA VALUES(N'MH007', N'Dạ Yêu Linh', N'ML006', 200000, N'Đây sẽ là món quà bất ngờ và hoàn hảo dành tặng người thương, gia đình hoặc bạn bè.', N'009.jpeg','CD004');--CD004
INSERT INTO HOA VALUES(N'MH008', N'Từ Chối Nhẹ Nhàng Thôi', N'ML001', 800000, N'Bó hoa sang trọng và thanh khiết với hoa Hồng đỏ được gói xinh xắn.', N'010.jpeg','CD002'); --CD002
INSERT INTO HOA VALUES(N'MH009', N'Đỏ Đam Mê', N'ML003', 450000, N'Combo ngọt ngào từ Chocolate đến tông màu hồng của La Vie En Rose sẽ là món quà hoàn hảo cho bất kỳ dịp quan trọng nào!', N'011.jpeg','CD001'); --CD001
INSERT INTO HOA VALUES(N'MH010', N'Hồng Phấn Ngây Thơ', N'ML003', 450000, N'Combo ngọt ngào từ Chocolate đến tông màu hồng của La Vie En Rose sẽ là món quà hoàn hảo cho bất kỳ dịp quan trọng nào!', N'012.jpeg','CD001'); --CD001
INSERT INTO HOA VALUES(N'MH011', N'Chocolate 5 viên', N'ML003', 200000, N'Ferrero Rocher là dòng sản phẩm chocolate cao cấp đến từ Ý với hương vị đặc biệt, kết hợp hạt phỉ thơm béo, lớp bánh xốp giòn tan và chocolate hảo hạn phủ bên ngoài.', N'013.jpeg','CD001'); --CD001
INSERT INTO HOA VALUES(N'MH012', N'Chocolate 10 viên', N'ML003', 400000, N'Khoác lên mình lớp giấy gói màu vàng sang trọng, những viên chocolate Ferrero Rocher chính là lựa chọn hoàn hảo dành tặng cho những người thân yêu vào những dịp đặc biệt.', N'014.jpeg','CD001'); --CD001
INSERT INTO HOA VALUES(N'MH013', N'Trái Tim Sư Tử', N'ML002', 800000, N'Bó hoa là món quà đáng yêu với Hướng Dương vây quanh bởi vô vàn những bông hoa Baby bé li ti nhưng lại rất đỗi xinh xắn, cũng như vô vàn những điều nhỏ bé làm nên chuyện tình cảm tươi đẹp giữa bạn và người nhận vậy đó.', N'008.jpeg','CD005'); --CD005
INSERT INTO HOA VALUES(N'MH014', N'Chỉ Hai Ta Biết Thôi', N'ML006', 400000, N'Bông hoa nhí gửi nỗi niềm thương nhớ da diết', N'007.jpeg','CD004'); --CD004
INSERT INTO HOA VALUES(N'MH015', N'Vàng Lãng Mạn', N'ML003', 450000, N'Hộp quà hoa vàng sang trọng quí phái tặng cô giáo', N'015.jpeg','CD001'); --CD001
INSERT INTO HOA VALUES(N'MH016', N'Giấc Mơ Trưa', N'ML004', 800000, N'Rực rỡ như ánh nắng trưa hè giúp bạn sang chấn tâm lí nửa tỉnh nửa mơ', N'016.jpeg','CD001'); --CD001
INSERT INTO HOA VALUES(N'MH017', N'Chúc Mừng Sinh Nhật', N'ML004', 700000, N'Mừng ngày sinh nhật đáng yêu nhé ai lớp du pho re vờ', N'017.jpeg','CD001'); --CD001
INSERT INTO HOA VALUES(N'MH018', N'Em Bé', N'ML004', 500000, N'Để anh vẫn luôn gọi em là em bé,dẫu bốn mươi,sáu mươi,tám mươi anh vẫn luôn chung tình', N'018.jpeg','CD001'); --CD001
INSERT INTO HOA VALUES(N'MH019', N'Rực Rỡ', N'ML005', 300000, N'Giỏ hoa rực rỡ các sắc hoa đan xen tòng teng sương sa hột lựu', N'019.jpeg','CD002');--CD002
INSERT INTO HOA VALUES(N'MH020', N'Thanh Khiết', N'ML005', 360000, N'Thanh khiết như hồn sen nhưng sen rất mau hư nên đừng mua cái này để trưng nha', N'020.jpeg','CD002');--CD002
INSERT INTO HOA VALUES(N'MH021', N'Ngày Của Mẹ', N'ML004', 500000, N'Tôn vinh sự tần tảo và vun vén của mẹ,nhất là mẹ Hương luôn nhắc nhở ca sĩ Bích Phương lấy chồng', N'021.jpeg','CD001');--CD001
INSERT INTO HOA VALUES(N'MH022', N'Cam Nồng Cháy', N'ML003', 450000,N'Sắc cam nồng nàn là món quà tặng những bạn trai ngọt ngào', N'022.jpeg','CD001');--CD001
INSERT INTO HOA VALUES(N'MH023', N'Tri Ân', N'ML005', 450000, N'Tri ân những người đưa đò có công dẫn dắt lứa tuổi học sinh đến bến bờ tri thức như cô Nguyễn Hải Yến', N'023.jpeg','CD002');--CD002
INSERT INTO HOA VALUES(N'MH024', N'Thân Tặng Quốc Huy', N'ML005', 500000, N'Yêu thương bạn Quốc Huy mong bạn đừng có nhắn tin cái kiểu ok ok ông với mình nữa mình khó chịu lắm nhé ai lớp du chu cờ mo', N'024.jpeg','CD002');--CD002
INSERT INTO HOA VALUES(N'MH025', N'Nhớ Em', N'ML001', 4000000, N'Nhớ gì như nhớ người yêu,người yêu chưa có thì mua hoa tặng mẹ nha nha', N'029.jpeg','CD002');--CD002
INSERT INTO HOA VALUES(N'MH026', N'Ngọt Ngào', N'ML001', 3500000, N'Ngọt ngào như lời nói dối của người yêu cũ của bạn', N'030.jpeg','CD002');--CD002
--BẢNG HOA
--'ML001',N'Hoa Hồng' --CD002 Lãng mạn: 6
--'ML002',N'Hoa Hướng Dương' --CD005 Chúc mừng : 3
--'ML003',N'Hộp Quà Hoa'); --CD001 Sinh Nhật: 5
--'ML004',N'Kệ Hoa'); --CD001 Sinh Nhật: 3
--'ML005',N'Giỏ Hoa'); --CD002 Lãng mạn: 3
--'ML006',N'Hoa Nhí'); -- Baby -- CD004 Cảm ơn : 3
--3 Hoa cưới MALOAI:ML001 --CD003: 
INSERT INTO HOA VALUES(N'MH027',N'Bó Hoa Cinderella',N'ML001',479000,N'Bó hoa hồng nhã nhặn, tinh khiết và thanh lịch sẽ tô điểm thêm cho bạn trong ngày trọng đại của mình.',N'hoacuoi3.jpeg','CD003');
INSERT INTO HOA VALUES(N'MH028',N'Bó Hoa Cherish Bridal',N'ML001',789000,N'Bó hoa lạ mắt với bông bi màu tím sẽ là người bạn đồng hành trong ngày quan trọng của hai bạn.',N'hoacuoi1.jpeg','CD003');
INSERT INTO HOA VALUES(N'MH029',N'Bó Hoa Wholeheartedly Bridal',N'ML001',429000,N'Bó hoa hồng nhã nhặn, tinh khiết và thanh lịch sẽ tô điểm thêm cho bạn trong ngày trọng đại của mình.',N'hoacuoi2.jpeg','CD003');
--8 Hoa Chia Buồn MALOAI: ML004 --CD006
INSERT INTO HOA VALUES(N'MH030',N'Vòng Hoa Chia Buồn Eternity',N'ML004',3790000,N'Gửi lời chia sẻ tới người nhận với Vòng Hoa Chia Buồn Eternity.',N'chiabuon1.jpeg',N'CD006');
INSERT INTO HOA VALUES(N'MH031',N'Vòng Hoa Chia Buồn Condolences',N'ML004',800000,N'Gửi lời chia sẻ tới người nhận với Vòng Hoa Chia Buồn Condolences.',N'chiabuon2.jpeg',N'CD006');
INSERT INTO HOA VALUES(N'MH032',N'Vòng Hoa Chia Buồn Goodbye Salute',N'ML004',750000,N'Gửi lời chia sẻ tới người nhận với Vòng Hoa Chia Buồn Goodbye Salute.',N'chiabuon3.jpeg',N'CD006');
INSERT INTO HOA VALUES(N'MH033',N'Vòng Hoa Chia Buồn Heavenly',N'ML004',959000,N'Gửi lời chia sẻ tới người nhận với Vòng Hoa Chia Buồn Heavenly.',N'chiabuon4.jpeg',N'CD006');
INSERT INTO HOA VALUES(N'MH034',N'Vòng Hoa Chia Buồn SoftWhisper',N'ML004',790000,N'Gửi lời chia sẻ tới người nhận với Vòng Hoa Chia Buồn SoftWhisper.',N'chiabuon5.jpeg',N'CD006');
INSERT INTO HOA VALUES(N'MH035',N'Vòng Hoa Chia Buồn Graceful Paradise',N'ML004',860000,N'Gửi lời chia sẻ tới người nhận với Vòng Hoa Chia Buồn Graceful Paradise.',N'chiabuon6.jpeg',N'CD006');
INSERT INTO HOA VALUES(N'MH036',N'Vòng Hoa Chia Buồn Rest Paradise',N'ML004',900000,N'Gửi lời chia sẻ tới người nhận với Vòng Hoa Chia Buồn Rest Paradise.',N'chiabuon7.jpeg',N'CD006');
INSERT INTO HOA VALUES(N'MH037',N'Vòng Hoa Chia Buồn Hope',N'ML004',850000,N'Gửi lời chia sẻ tới người nhận với Vòng Hoa Chia Buồn Hope.',N'chiabuon8.jpeg',N'CD006');
--Them 3 hoa hoa chuc mung CD005
INSERT INTO HOA VALUES (N'MH038',N'Giỏ Hoa Enchanting Romance','ML005',550000,N'Giỏ hoa tông màu hồng pastel vừa trang nhã vừa ngọt ngào với sự kết hợp của các loại hoa như hoa hồng, hoa đồng tiền, hoa cát tường và hoa cẩm chướng.','chucmung1.jpeg','CD005');
INSERT INTO HOA VALUES (N'MH039',N'Combo All For You','ML001',830000,N'Lựa chọn hoàn hảo dành cho người bạn yêu thương với toàn điều ngọt ngào, lãng mạn. Sẵn sàng đốn tim người nhận chưa?','chucmung2.jpeg','CD005');
INSERT INTO HOA VALUES (N'MH040',N'Combo Adore You','ML005',620000,N'Lựa chọn hoàn hảo dành cho người bạn yêu thương với toàn điều ngọt ngào, đáng yêu. Sẵn sàng đốn tim người nhận chưa?','chucmung3.jpeg','CD005');
--BẢNG HOA
--'ML001',N'Hoa Hồng' --CD002 Lãng mạn: 6
--'ML002',N'Hoa Hướng Dương' --CD005 Chúc mừng : 3
--'ML003',N'Hộp Quà Hoa'); --CD001 Sinh Nhật: 5
--'ML004',N'Kệ Hoa'); --CD001 Sinh Nhật: 3
--'ML005',N'Giỏ Hoa'); --CD002 Lãng mạn: 3
--'ML006',N'Hoa Nhí'); -- Baby -- CD004 Cảm ơn : 3
-------------------------------------------------------//---------------------------------------------------------
Select * from HOA
-- Cần thêm --'ML002',N'Hoa Hướng Dương' --CD005 Chúc mừng : 4 bông
INSERT INTO HOA VALUES('MH041', N'My Beloved Sunnies', 'ML002', 649000, N'Giỏ hoa My Beloved Sunnies là sự kết hợp của những bông hoa hướng dương rực rỡ, đầy sức sống cùng với những nhánh đồng tiền trắng muốt, vừa tinh tế vừa nhã nhặn. Cả hai đều bung xoè như những bông mặt trời nhỏ vô cùng dễ thương.', N'huongduong1.jpeg','CD005');--CD005
INSERT INTO HOA VALUES('MH042', N'Wish You Health', 'ML002', 749000, N'Giỏ hoa trái cây nhập khẩu sang trọng và trang nhã là món quà bất ngờ và hoàn hảo dành tặng người thương, gia đình hoặc bạn bè.', N'huongduong2.jpeg','CD005');--CD005
INSERT INTO HOA VALUES('MH043', N'Mindful Soul', 'ML002', 299000, N'Bó hoa nhỏ nhắn đáng yêu với hoa Hướng Dương cùng Cẩm Tú Cầu được gói xinh xắn.', N'huongduong3.jpeg','CD005');--CD005
INSERT INTO HOA VALUES('MH044', N'Chào Buổi Sáng!', 'ML002', 350000, N'Bó hoa Hướng Dương mini xinh xắn sẽ là món quà nhỏ đáng yêu dành tặng bạn bè hay người thương của bạn.', N'huongduong4.jpeg','CD005');--CD005
-- Cần thêm --'ML006',N'Hoa Nhí'); -- Baby -- CD004 Cảm ơn : 4 bông
INSERT INTO HOA VALUES('MH045',N'My Juliet','ML006',329000,N'Bó hoa pastel được gói theo phong cách Hàn Quốc, mang màu sắc rất trẻ trung và thanh lịch. Sự kết hợp giữa Cẩm tú cầu và hoa Baby là một trong lựa chọn hoàn hảo cho ngày đặc biết hoặc bất kỳ dịp nào để dành tặng cho người mình yêu thương.','baby1.jpeg','CD004');
INSERT INTO HOA VALUES('MH046',N'Combo Cheerful Spring','ML006',709000,N'Với một thông điệp ngày bên em chính là ngày xuân trong lòng anh, cũng là ngày hạnh phúc nhất trong cuộc đời này.','baby2.jpeg','CD004');
INSERT INTO HOA VALUES('MH047',N'Love Me Tender','ML006',399000,N'Bó Hoa Love Me Tender mang phong cách Hàn Quốc nhẹ nhàng tươi tắn. Đây chắc chắn sẽ là món quà ngọt ngào và tinh tế dành tặng người thương, gia đình hoặc bạn bè thân yêu!','baby3.jpeg','CD004');
INSERT INTO HOA VALUES('MH048',N'Crystal Pearl','ML006',499000,N'Bó hoa nhẹ nhàng và thanh khiết với hoa Cẩm Tú Cầu đan xen với những đóa hoa Cúc Tana được gói xinh xắn bằng giấy Kraft. Đây sẽ là món quà xinh xắn và hoàn hảo dành tặng người thương, gia đình hoặc bạn bè.','baby4.jpeg','CD004');
-- Cần thêm -- ML001,N'Hoa cưới' hoặc hoa hồng thuộc--CD003: 4 bông
--INSERT INTO HOA VALUES('MH049',N'','',300000,N'','','');
--INSERT INTO HOA VALUES('MH050',N'','',300000,N'','','');
--INSERT INTO HOA VALUES('MH051',N'','',300000,N'','','');
--INSERT INTO HOA VALUES('MH052',N'','',300000,N'','','');
-- Cần thêm --'ML005',N'Giỏ Hoa'); -- Lãng mạn CD002: 4 bông
INSERT INTO HOA VALUES('MH049',N'Intimate Amber','ML005',789000,N'Những loại hoa màu đỏ kết hợp với giỏ hoa kim loại là món quà cổ điển, sang trọng cho bất kỳ ai bạn yêu mến. ','giohoa1.jpeg','CD002');
INSERT INTO HOA VALUES('MH050',N'Love Nest (99 Bông)','ML005',1799000,N'Chiếc tổ uyên ương ngọt ngào lãng mạn là món quà làm ai cũng cảm thấy mình thật đặc biệt trong tim đối phương! ','giohoa2.jpeg','CD002');
INSERT INTO HOA VALUES('MH051',N'Combo Beautiful Darling','ML005',989000,N'Lựa chọn hoàn hảo dành cho người bạn yêu thương với toàn điều ngọt ngào, đáng yêu. Sẵn sàng đốn tim người nhận chưa?','giohoa3.jpeg','CD002');
INSERT INTO HOA VALUES('MH052',N'Cupid Kisses','ML005',599000,N'Các loại hoa tông màu đỏ rực rỡ cắm hình trái tim kết hợp với hộp hoa gỗ vintage cổ điển, là món quà sang trọng thích hợp để tặng nhân dịp khai trương hoặc cho bất kỳ dịp đặc biệt.','giohoa4.jpeg','CD002');
-- Cần thêm --'ML004',N'Kệ Hoa'); -- Sinh Nhật CD001: 4 bông
INSERT INTO HOA VALUES('MH053',N'Triumph','ML004',2359000,N'Kệ hoa to, tươi tắn và sang trọng với hướng dương, và các loại hoa lan.','kehoa1.jpeg','CD001');
INSERT INTO HOA VALUES('MH054',N'Square Of Joy','ML004',3159000,N'Kệ hoa to, tươi tắn và sang trọng với sự kết hợp của các loại hoa màu vàng và tông giấy xanh dịu mắt.','kehoa2.jpeg','CD001');
INSERT INTO HOA VALUES('MH055',N'Blissful','ML004',2550000,N'Kệ hoa to, tươi tắn và sang trọng với sự kết hợp của nhiều loại hoa.','kehoa3.jpeg','CD001');
INSERT INTO HOA VALUES('MH056',N'Blooming Success','ML004',4579000,N'Kệ hoa to, tươi tắn và sang trọng với sự kết hợp của các loại hoa tông màu hồng.','kehoa4.jpeg','CD001');



--BẢNG ĐƠN HÀNG

--INSERT INTO DONHANG VALUES(1, NULL,NULL , NULL, NULL, 1);
--INSERT INTO DONHANG VALUES (2, NULL,NULL , NULL, NULL, NULL);
--BẢNG CHI TIẾT ĐẶT HÀNG

--INSERT INTO CTDONHANG VALUES(1, N'MH003', 2, 650000);
--INSERT INTO CTDONHANG VALUES(2, N'MH002', 3, NULL);
