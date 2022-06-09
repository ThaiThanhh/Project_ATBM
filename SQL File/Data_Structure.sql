alter session set "_ORACLE_SCRIPT" = true;

--drop user soyte cascade;
create user soytex identified by admin1;
grant DBA, connect to soytex;

connect soytex/admin1 as sysdba;

-- drop table CSYT cascade constraints;
-- drop table NhanVien cascade constraints;
-- drop table BenhNhan cascade constraints;
-- drop table HSBA cascade constraints;
-- drop table HSBA_DV cascade constraints;

create table CSYT
(
    MaCSYT varchar2(15) primary key,
    TenCSYT nvarchar2(80),
    DCCSYT nvarchar2(200),
    SDTCSYT nvarchar2(11)
);

create table NhanVien
(
    MaNV varchar2(15) primary key,
    HoTen nvarchar2(40),
    Phai nvarchar2(3) check (Phai in ('Nam', N'Nữ')),
    NgaySinh date,
    CMND varchar2(12),
    QueQUan nvarchar2(200),
    SoDT varchar2(11),
    CSYT varchar2(15),
    VaiTro nvarchar2(12) check (VaiTro in ('Thanh tra', N'Cơ sở y tế', N'Y sĩ/ Bác sĩ', N'Nghiên cứu')),
    ChuyenKhoa nvarchar2(50)
);

create table BenhNhan
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

    constraint BN_FK foreign key (MaCSYT) references CSYT(MaCSYT)
);

create table HSBA
(
    MaHSBA varchar2(15) primary key,
    MaBN varchar2(15),
    Ngay date,
    ChanDoan nvarchar2(100),
    MaBS varchar2(15),
    MaKhoa varchar2(10),
    MaCSYT varchar2(15),
    KetLuan nvarchar2(100),

    constraint HSBA_FK1 foreign key (MaBN) references BenhNhan(MaBN),
    constraint HSBA_FK2 foreign key (MaCSYT) references CSYT(MaCSYT),
    constraint HSBA_FK3 foreign key (MaBS) references NhanVien(MaNV)
);

create table HSBA_DV
(
    MaHSBA varchar2(15),
    MaDV varchar2(10),
    Ngay date,
    MaKTV varchar2(10),
    KetQua nvarchar2(100),

    constraint HSBA_DV_PK primary key (MaHSBA, MaDV, Ngay),
    constraint HSBA_DV_FK foreign key (MaHSBA) references HSBA(MaHSBA)
);

alter session set "_ORACLE_SCRIPT" = false;