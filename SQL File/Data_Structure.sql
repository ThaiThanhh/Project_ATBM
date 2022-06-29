alter session set "_ORACLE_SCRIPT" = true;

drop user SOYTEX cascade;
create user SOYTEX identified by admin1;
grant DBA, RESOURCE, connect to SOYTEX;

connect SOYTEX/admin1;

drop table SOYTEX.CSYT cascade constraints;
drop table SOYTEX.NhanVien cascade constraints;
drop table SOYTEX.BenhNhan cascade constraints;
drop table SOYTEX.HSBA cascade constraints;
drop table SOYTEX.HSBA_DV cascade constraints;

create table SOYTEX.CSYT
(
    MaCSYT varchar2(15) primary key,
    TenCSYT nvarchar2(80),
    DCCSYT nvarchar2(200),
    SDTCSYT nvarchar2(11)
);

create table SOYTEX.NhanVien
(
    MaNV varchar2(15) primary key,
    HoTen nvarchar2(40),
    Phai nvarchar2(3) check (Phai in ('Nam', N'Nu')),
    NgaySinh date,
    CMND varchar2(12),
    QueQuan nvarchar2(200),
    SoDT varchar2(11),
    CSYT varchar2(15),
    VaiTro nvarchar2(12) check (VaiTro in (N'Thanh tra', N'Co so y te', N'Y si/ Bac si', N'Nghien cuu')),
    ChuyenKhoa varchar2(10)
);

create table SOYTEX.BenhNhan
(
    MaBN varchar2(15) primary key,
    MaCSYT varchar2(15),
    TenBN nvarchar2(40),
    CMND varchar2(12),
    NgaySinh date,
    SoNha varchar2(20),
    TenDuong nvarchar2(30),
    QuanHuyen nvarchar2(20),
    TinhTP nvarchar2(15),
    TienSuBenh nvarchar2(100),
    TienSuBenhGD nvarchar2(100),
    DiUngThuoc nvarchar2(150),

    constraint BN_FK foreign key (MaCSYT) references SOYTEX.CSYT(MaCSYT)
);

create table SOYTEX.HSBA
(
    MaHSBA varchar2(15) primary key,
    MaBN varchar2(15),
    Ngay date,
    ChanDoan nvarchar2(100),
    MaBS varchar2(15),
    MaKhoa varchar2(10),
    MaCSYT varchar2(15),
    KetLuan nvarchar2(100),

    constraint HSBA_FK1 foreign key (MaBN) references SOYTEX.BenhNhan(MaBN),
    constraint HSBA_FK2 foreign key (MaCSYT) references SOYTEX.CSYT(MaCSYT),
    constraint HSBA_FK3 foreign key (MaBS) references SOYTEX.NhanVien(MaNV)
);

create table SOYTEX.HSBA_DV
(
    MaHSBA varchar2(15),
    MaDV varchar2(10),
    Ngay date,
    MaKTV varchar2(10),
    KetQua nvarchar2(100),

    constraint HSBA_DV_PK primary key (MaHSBA, MaDV, Ngay),
    constraint HSBA_DV_FK foreign key (MaHSBA) references SOYTEX.HSBA(MaHSBA)
);

alter session set "_ORACLE_SCRIPT" = false;

INSERT INTO SOYTEX.CSYT VALUES('CSYT001', 'Co so y te 1', 'Ha Noi', '0123456789');
INSERT INTO SOYTEX.CSYT VALUES('CSYT002', 'Co so y te 2', 'TP Ho Chi Minh', '0123456789');
INSERT INTO SOYTEX.CSYT VALUES('CSYT003', 'Co so y te 3', 'Gia Lai', '0123456789');
INSERT INTO SOYTEX.CSYT VALUES('CSYT004', 'Co so y te 4', 'Binh Thuan', '0123456789');
INSERT INTO SOYTEX.CSYT VALUES('CSYT005', 'Co so y te 5', 'Vung Tau', '0123456789');
INSERT INTO SOYTEX.CSYT VALUES('CSYT006', 'Co so y te 6', 'Quang Ngai', '0123456789');
INSERT INTO SOYTEX.CSYT VALUES('CSYT007', 'Co so y te 7', 'Da Nang', '0123456789');
INSERT INTO SOYTEX.CSYT VALUES('CSYT008', 'Co so y te 8', 'Da Lat', '0123456789');
INSERT INTO SOYTEX.CSYT VALUES('CSYT009', 'Co so y te 9', 'TP Ho Chi Minh', '0123456789');
INSERT INTO SOYTEX.CSYT VALUES('CSYT010', 'Co so y te 10', 'Binh Thuan', '0123456789');

INSERT INTO SOYTEX.NhanVien VALUES('NV001', 'Nguyen Hoang Dung', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT001', N'Co so y te', NULL);
INSERT INTO SOYTEX.NhanVien VALUES('NV002', 'Nguyen Tuan Anh', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Thuan', '0123456789', 'CSYT001', N'Thanh tra', NULL);
INSERT INTO SOYTEX.NhanVien VALUES('NV003', 'Nguyen Quang Minh', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Thuan', '0123456789', 'CSYT001', N'Thanh tra', NULL);
INSERT INTO SOYTEX.NhanVien VALUES('NV004', 'Nguyen Kiem', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Thuan', '0123456789', 'CSYT001', N'Thanh tra', NULL);
INSERT INTO SOYTEX.NhanVien VALUES('NV005', 'Nguyen Tuan Tu', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT001', N'Y si/ Bac si', 'K001');
INSERT INTO SOYTEX.NhanVien VALUES('NV006', 'Nguyen Hoang Nhat', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT001', N'Y si/ Bac si', 'K001');
INSERT INTO SOYTEX.NhanVien VALUES('NV007', 'Nguyen Nhat Nam', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT001', N'Y si/ Bac si', 'K002');
INSERT INTO SOYTEX.NhanVien VALUES('NV008', 'Nguyen Quang Linh', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT001', N'Y si/ Bac si', 'K002');
INSERT INTO SOYTEX.NhanVien VALUES('NV009', 'Nguyen Tu Trinh', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT001', N'Y si/ Bac si', 'K003');
INSERT INTO SOYTEX.NhanVien VALUES('NV010', 'Nguyen Thuy Linh', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT001', N'Y si/ Bac si', 'K003');
INSERT INTO SOYTEX.NhanVien VALUES('NV011', 'Nguyen Thanh Hoang', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT001', N'Nghien cuu', 'K001');
INSERT INTO SOYTEX.NhanVien VALUES('NV012', 'Nguyen Thanh Thuy', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT001', N'Nghien cuu', 'K002');
INSERT INTO SOYTEX.NhanVien VALUES('NV013', 'Nguyen Nhat Huy', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT001', N'Nghien cuu', 'K003');
INSERT INTO SOYTEX.NhanVien VALUES('NV014', 'Nguyen Tam Dung', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT002', N'Co so y te', NULL);
INSERT INTO SOYTEX.NhanVien VALUES('NV015', 'Nguyen Lam Nhat', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Thuan', '0123456789', 'CSYT002', N'Thanh tra', NULL);
INSERT INTO SOYTEX.NhanVien VALUES('NV016', 'Nguyen Quang Tu', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Thuan', '0123456789', 'CSYT002', N'Thanh tra', NULL);
INSERT INTO SOYTEX.NhanVien VALUES('NV017', 'Nguyen Nhat Hoa', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Thuan', '0123456789', 'CSYT002', N'Thanh tra', NULL);
INSERT INTO SOYTEX.NhanVien VALUES('NV018', 'Nguyen Minh Tu', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT002', N'Y si/ Bac si', 'K001');
INSERT INTO SOYTEX.NhanVien VALUES('NV019', 'Nguyen Hoang Thuy', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT002', N'Y si/ Bac si', 'K001');
INSERT INTO SOYTEX.NhanVien VALUES('NV020', 'Nguyen Kieu Trinh', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT002', N'Y si/ Bac si', 'K002');
INSERT INTO SOYTEX.NhanVien VALUES('NV021', 'Nguyen Minh Lieu', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT002', N'Y si/ Bac si', 'K002');
INSERT INTO SOYTEX.NhanVien VALUES('NV022', 'Nguyen Thuy Trinh', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT002', N'Y si/ Bac si', 'K003');
INSERT INTO SOYTEX.NhanVien VALUES('NV023', 'Nguyen Minh Tu', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT002', N'Y si/ Bac si', 'K003');
INSERT INTO SOYTEX.NhanVien VALUES('NV024', 'Nguyen Thanh Nga', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT002', N'Nghien cuu', 'K001');
INSERT INTO SOYTEX.NhanVien VALUES('NV025', 'Nguyen Nga', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT002', N'Nghien cuu', 'K002');
INSERT INTO SOYTEX.NhanVien VALUES('NV026', 'Nguyen Thuy Tien', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT002', N'Nghien cuu', 'K003');

INSERT INTO SOYTEX.BenhNhan VALUES('BN001', 'CSYT001', 'Nguyen Quang An', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN002', 'CSYT001', 'Nguyen Thi Ngoc Mai', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN003', 'CSYT001', 'Huynh Thai Thanh', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN004', 'CSYT001', 'Nguyen Van Dat', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN005', 'CSYT001', 'Truong Tan Thanh', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN006', 'CSYT001', 'Nguyen Hoang Nhat', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN007', 'CSYT001', 'Nguyen Thai Thinh', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN008', 'CSYT001', 'Nguyen Van Lam', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN009', 'CSYT001', 'Huynh Nhat Quang', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN010', 'CSYT001', 'Nguyen Dat Dien', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN011', 'CSYT002', 'Huynh Thai Vu', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN012', 'CSYT002', 'Nguyen Van Vo', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN013', 'CSYT002', 'Truong Thai Thanh', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN014', 'CSYT002', 'Nguyen Quang Long', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN015', 'CSYT002', 'Huynh Cong Thanh', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN016', 'CSYT002', 'Nguyen Tan Truong', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN017', 'CSYT002', 'Huynh Quang Tam', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN018', 'CSYT002', 'Nguyen Ngo Dang', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN019', 'CSYT002', 'Huynh Lam Thanh', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN020', 'CSYT002', 'Nguyen Tan Thanh Dat', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi benh', 'Khong', 'Khong');

INSERT INTO SOYTEX.HSBA VALUES('HSBA001', 'BN001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV005', 'K001', 'CSYT001', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA002', 'BN002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV005', 'K001', 'CSYT001', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA003', 'BN003', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV005', 'K001', 'CSYT001', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA004', 'BN004', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV005', 'K001', 'CSYT001', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA005', 'BN005', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV007', 'K002', 'CSYT001', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA006', 'BN006', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV007', 'K002', 'CSYT001', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA007', 'BN007', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV007', 'K002', 'CSYT001', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA008', 'BN008', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV007', 'K002', 'CSYT001', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA009', 'BN009', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV009', 'K003', 'CSYT001', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA010', 'BN010', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV009', 'K003', 'CSYT001', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA011', 'BN011', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV018', 'K001', 'CSYT002', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA012', 'BN012', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV018', 'K001', 'CSYT002', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA013', 'BN013', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV018', 'K001', 'CSYT002', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA014', 'BN014', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV018', 'K001', 'CSYT002', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA015', 'BN015', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV020', 'K002', 'CSYT002', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA016', 'BN016', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV020', 'K002', 'CSYT002', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA017', 'BN017', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV020', 'K002', 'CSYT002', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA018', 'BN018', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV020', 'K002', 'CSYT002', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA019', 'BN019', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV022', 'K003', 'CSYT002', 'Bi benh');
INSERT INTO SOYTEX.HSBA VALUES('HSBA020', 'BN020', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi benh', 'NV022', 'K003', 'CSYT002', 'Bi benh');

INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA001', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV005', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA001', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV005', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA002', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV005', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA002', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV005', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA003', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV005', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA003', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV005', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA004', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV005', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA004', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV005', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA005', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV007', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA005', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV007', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA006', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV007', 'Bi benh');  
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA006', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV007', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA007', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV007', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA007', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV007', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA008', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV007', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA008', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV007', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA009', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV009', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA009', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV009', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA010', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV009', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA010', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV009', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA011', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV018', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA011', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV018', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA012', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV018', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA012', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV018', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA013', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV018', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA013', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV018', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA014', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV018', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA014', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV018', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA015', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV020', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA015', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV020', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA016', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV020', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA016', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV020', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA017', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV020', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA017', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV020', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA018', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV020', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA018', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV020', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA019', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV022', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA019', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV022', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA020', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV022', 'Bi benh');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA020', 'DV002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV022', 'Bi benh');
