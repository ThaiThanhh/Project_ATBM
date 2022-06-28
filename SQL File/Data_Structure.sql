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
    NgaySinh date check (NgaySinh < sysdate),
    CMND varchar2(12) unique,
    QueQuan nvarchar2(200),
    SoDT varchar2(11) unique,
    CSYT varchar2(15),
    VaiTro nvarchar2(12) check (VaiTro in (N'Thanh tra', N'Co so y te', N'Y si/ Bac si', N'Nghien cuu')),
    ChuyenKhoa varchar2(10)
);

create table SOYTEX.BenhNhan
(
    MaBN varchar2(15) primary key,
    MaCSYT varchar2(15),
    TenBN nvarchar2(40),
    CMND varchar2(12) unique,
    NgaySinh date check (NgaySinh < sysdate),
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
    Ngay date check (Ngay <= sysdate),
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
    Ngay date check (Ngay <= sysdate),
    MaKTV varchar2(10),
    KetQua nvarchar2(100),

    constraint HSBA_DV_PK primary key (MaHSBA, MaDV, Ngay),
    constraint HSBA_DV_FK foreign key (MaHSBA) references SOYTEX.HSBA(MaHSBA)
);

alter session set "_ORACLE_SCRIPT" = false;

INSERT INTO SOYTEX.CSYT VALUES('CSYT001', 'Co so y te 1', 'Gia Lai', '0123456799');
INSERT INTO SOYTEX.CSYT VALUES('CSYT002', 'Co so y te 2', 'Binh Thuan', '0123456788');

INSERT INTO SOYTEX.NhanVien VALUES('NV001', 'Nguyen Tuan Anh', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Thuan', '0123456789', 'CSYT001', N'Thanh tra', NULL);
INSERT INTO SOYTEX.NhanVien VALUES('NV002', 'Nguyen Hoang Dung', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT001', N'Co so y te', NULL);
INSERT INTO SOYTEX.NhanVien VALUES('NV003', 'Nguyen Quang Minh', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT001', N'Y si/ Bac si', 'K001');
INSERT INTO SOYTEX.NhanVien VALUES('NV004', 'Nguyen Thanh Thuy', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT001', N'Nghien cuu', 'K001');
INSERT INTO SOYTEX.NhanVien VALUES('NV005', 'Nguyen Quang Nhat', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Thuan', '0123456789', 'CSYT002', N'Thanh tra', NULL);
INSERT INTO SOYTEX.NhanVien VALUES('NV006', 'Nguyen Thanh Dung', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT002', N'Co so y te', NULL);
INSERT INTO SOYTEX.NhanVien VALUES('NV007', 'Nguyen Minh Thuy', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT002', N'Y si/ Bac si', 'K002');
INSERT INTO SOYTEX.NhanVien VALUES('NV008', 'Nguyen Thuy Nga', 'Nu', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Binh Dinh', '0123456789', 'CSYT002', N'Nghien cuu', 'K002');

INSERT INTO SOYTEX.BenhNhan VALUES('BN001', 'CSYT001', 'Nguyen Quang An', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi khung', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN002', 'CSYT001', 'Nguyen Thi Ngoc Mai', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi khung', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN003', 'CSYT002', 'Huynh Thai Thanh', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi khung', 'Khong', 'Khong');
INSERT INTO SOYTEX.BenhNhan VALUES('BN004', 'CSYT002', 'Nguyen Van Dat', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyen Hue', 'Quan 1', 'TP Ho Chi Minh', 'Bi khung', 'Khong', 'Khong');

INSERT INTO SOYTEX.HSBA VALUES('HSBA001', 'BN001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi khung', 'NV003', 'K001', 'CSYT001', 'Bi khung');
INSERT INTO SOYTEX.HSBA VALUES('HSBA002', 'BN002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi khung', 'NV003', 'K001', 'CSYT001', 'Bi khung');
INSERT INTO SOYTEX.HSBA VALUES('HSBA003', 'BN003', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi khung', 'NV007', 'K001', 'CSYT002', 'Bi khung');
INSERT INTO SOYTEX.HSBA VALUES('HSBA004', 'BN004', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bi khung', 'NV007', 'K001', 'CSYT002', 'Bi khung');

INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA001', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV003', 'Bi khung');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA002', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV003', 'Bi khung');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA003', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV007', 'Bi khung');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA004', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV007', 'Bi khung');



    

