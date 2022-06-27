alter session set "_ORACLE_SCRIPT" = true;

drop user SOYTEX cascade;
create user SOYTEX identified by admin1;
grant DBA, connect to SOYTEX;

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
    Phai nvarchar2(3) check (Phai in ('Nam', N'Nữ')),
    NgaySinh date,
    CMND varchar2(12),
    QueQUan nvarchar2(200),
    SoDT varchar2(11),
    CSYT varchar2(15),
    VaiTro nvarchar2(12) check (VaiTro in ('Thanh tra', N'Co so y te', N'Y si/ Bac si', N'Nghien cuu')),
    ChuyenKhoa nvarchar2(50)
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

INSERT INTO SOYTEX.CSYT VALUES('CSYT001', 'Cơ sở y tế 1', 'Gia Lai', '0123456799');
INSERT INTO SOYTEX.CSYT VALUES('CSYT002', 'Cơ sở y tế 2', 'Bình Thuận', '0123456788');

INSERT INTO SOYTEX.NhanVien VALUES('NV001', 'Nguyễn Tuấn Anh', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Bình Thuận', '0123456789', 'CSYT001', 'Thanh tra', 'Đa khoa');
INSERT INTO SOYTEX.NhanVien VALUES('NV002', 'Nguyễn Hoàng Dũng', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Bình Định', '0123456789', 'CSYT001', 'Co so y te', 'Đa khoa');
INSERT INTO SOYTEX.NhanVien VALUES('NV003', 'Nguyễn Quang Minh', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Bình Định', '0123456789', 'CSYT001', 'Y si/ Bac si', 'Đa khoa');
INSERT INTO SOYTEX.NhanVien VALUES('NV004', 'Nguyễn Thanh Thúy', 'Nữ', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Bình Định', '0123456789', 'CSYT001', 'Nghien cuu', 'Đa khoa');
INSERT INTO SOYTEX.NhanVien VALUES('NV005', 'Nguyễn Quang Nhật', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Bình Thuận', '0123456789', 'CSYT002', 'Thanh tra', 'Đa khoa');
INSERT INTO SOYTEX.NhanVien VALUES('NV006', 'Nguyễn Thành Dũng', 'Nam', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Bình Định', '0123456789', 'CSYT002', 'Co so y te', 'Đa khoa');
INSERT INTO SOYTEX.NhanVien VALUES('NV007', 'Nguyễn Minh Thùy', 'Nữ', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Bình Định', '0123456789', 'CSYT002', 'Y si/ Bac si', 'Đa khoa');
INSERT INTO SOYTEX.NhanVien VALUES('NV008', 'Nguyễn Thúy Nga', 'Nữ', TO_DATE('17-06-1988','dd/mm/yyyy'), '123456789', 'Bình Định', '0123456789', 'CSYT002', 'Nghien cuu', 'Đa khoa');

INSERT INTO SOYTEX.BenhNhan VALUES('BN001', 'CSYT001', 'Nguyễn Quang An', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyễn Huệ', 'Quận 1', 'TP Hồ Chí Minh', 'Bị khùng', 'Không', 'Không');
INSERT INTO SOYTEX.BenhNhan VALUES('BN002', 'CSYT001', 'Nguyễn Thị Ngọc Mai', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyễn Huệ', 'Quận 1', 'TP Hồ Chí Minh', 'Bị khùng', 'Không', 'Không');
INSERT INTO SOYTEX.BenhNhan VALUES('BN003', 'CSYT002', 'Huỳnh Thái Thành', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyễn Huệ', 'Quận 1', 'TP Hồ Chí Minh', 'Bị khùng', 'Không', 'Không');
INSERT INTO SOYTEX.BenhNhan VALUES('BN004', 'CSYT002', 'Nguyễn Văn Đạt', '123456789', TO_DATE('17-06-2001','dd/mm/yyyy'), '10', 'Nguyễn Huệ', 'Quận 1', 'TP Hồ Chí Minh', 'Bị khùng', 'Không', 'Không');

INSERT INTO SOYTEX.HSBA VALUES('HSBA001', 'BN001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bị khùng', 'NV003', 'K001', 'CSYT001', 'Bị khùng');
INSERT INTO SOYTEX.HSBA VALUES('HSBA002', 'BN002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bị khùng', 'NV003', 'K001', 'CSYT001', 'Bị khùng');
INSERT INTO SOYTEX.HSBA VALUES('HSBA003', 'BN003', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bị khùng', 'NV007', 'K001', 'CSYT002', 'Bị khùng');
INSERT INTO SOYTEX.HSBA VALUES('HSBA004', 'BN004', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bị khùng', 'NV007', 'K001', 'CSYT002', 'Bị khùng');

INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA001', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV003', 'Bị khùng');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA002', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV003', 'Bị khùng');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA003', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV007', 'Bị khùng');
INSERT INTO SOYTEX.HSBA_DV VALUES('HSBA004', 'DV001', TO_DATE('17-06-2022','dd/mm/yyyy'), 'NV007', 'Bị khùng');

-- TC#3: Các nhân viên thuộc cơ sở y tế có quyền thêm hoặc xóa dữ liệu phát sinh từ chính cơ sở y tế mà nhân viên này trực thuộc, 
--  trong tháng hiện tại từ ngày 5 đến ngày 27 dương lịch hành tháng, liên quan các nghiệp vụ:
--      a. Thêm, xóa dòng trên hồ sơ bệnh án (HSBA)

-- Điều kiện
-- 5 <= date <= 27
-- cùng cơ sở y tế
CREATE OR REPLACE FUNCTION tc3_a_function(p_schema varchar2, p_obj varchar2)
RETURN NVARCHAR2
AS
    v_user VARCHAR2(15);
BEGIN
    v_user := SYS_CONTEXT('userenv', 'SESSION_USER');
    RETURN 'MAHSBA in (select MAHSBN from SOYTEX.HSBA, SOYTEX.NhanVien WHERE CSYT = MaCSYT AND EXTRACT(DAY FROM Ngay) >= 5 AND EXTRACT(DAY FROM Ngay) <= 27 AND MaNV = ''' || v_user ||''')';
END;

BEGIN
    DBMS_RLS.ADD_POLICY
    (
        object_schema => 'SOYTEX',
        object_name => 'HSBA',
        policy_name => 'View_edit_HSBA',
        policy_function => 'tc3_a_function',
        statement_types => 'insert, delete',
        update_check => true
    );
END;

--      b. Thêm, xóa dòng dịch vụ (HSBA_DV) liên quan 1 hồ sơ bệnh án

-- Điều kiện
-- 5 <= date <= 27
-- cùng cơ sở y tế
CREATE OR REPLACE FUNCTION tc3_b_function(p_schema varchar2, p_obj varchar2)
RETURN NVARCHAR2
AS
    v_user VARCHAR2(15);
BEGIN
    v_user := SYS_CONTEXT('userenv', 'SESSION_USER');
    RETURN 'MAHSBA in (select MAHSBN from SOYTEX.HSBA, SOYTEX.NhanVien WHERE CSYT = MaCSYT AND EXTRACT(DAY FROM Ngay) >= 5 AND EXTRACT(DAY FROM Ngay) <= 27 AND MaNV = ''' || v_user ||''')';
END;

BEGIN
    DBMS_RLS.ADD_POLICY
    (
        object_schema => 'SOYTEX',
        object_name => 'HSBA_DV',
        policy_name => 'View_edit_HSBADV',
        policy_function => 'tc3_b_function',
        statement_types => 'insert, delete',
        update_check => true
    );
END;

-- TC#5: Có 50 nhân viên ở vai trò "Nghiên cứu" ở mỗi cơ sở y tế, chỉ có thể xem các hồ sơ bệnh án (bảng HSBA và HSBA_DV)
--  được điều trị tại cùng cơ sở y tế (với nhân viên nghiên cứu đó), tại khoa giống chuyên khoa ghi trên bằng cấp của nhân viên nghiên cứu đó

-- Điều kiện SOYTEX.NhanVien
-- vai trò "Nghiên cứu" -- VaiTro
-- cùng cơ sở y tế -- CSYT
-- giống chuyên khoa ghi trên bằng cấp của nhân viên nghiên cứu đó -- ChuyenKhoa
CREATE OR REPLACE FUNCTION tc5_HSBA_function(p_schema varchar2, p_obj varchar2)
RETURN NVARCHAR2
AS
    v_user VARCHAR2(15);
BEGIN
    v_user := SYS_CONTEXT('userenv', 'SESSION_USER');
    RETURN 'MAHSBA in (select MAHSBN from SOYTEX.HSBA, SOYTEX.NhanVien WHERE CSYT = MaCSYT AND ChuyenKhoa = MaKhoa AND VaiTro = '''|| 'Nghiên cứu' || ''' AND MaNV = ''' || v_user ||''')';
END;

BEGIN
    DBMS_RLS.ADD_POLICY
    (
        object_schema => 'SOYTEX',
        object_name => 'HSBA',
        policy_name => 'View_HSBA',
        policy_function => 'tc5_HSBA_function',
        statement_types => 'select',
        update_check => true
    );
END;

CREATE OR REPLACE FUNCTION tc5_HSDV_function(p_schema varchar2, p_obj varchar2)
RETURN NVARCHAR2
AS
    v_user VARCHAR2(15);
    v_vaiTro NVARCHAR2(12);
    v_user_csyt VARCHAR2(15);
    v_chuyenKhoa NVARCHAR2(50);
    v_hsba VARCHAR2(15);
BEGIN
    v_user := SYS_CONTEXT('userenv', 'SESSION_USER');
    RETURN 'MAHSBA in (select MAHSBN from SOYTEX.HSBA, SOYTEX.NhanVien WHERE CSYT = MaCSYT AND ChuyenKhoa = MaKhoa AND VaiTro = '''|| 'Nghiên cứu' || ''' AND MaNV = ''' || v_user ||''')';
END;

BEGIN
    DBMS_RLS.ADD_POLICY
    (
        object_schema => 'SOYTEX',
        object_name => 'HSBA_DV',
        policy_name => 'View_HSDV',
        policy_function => 'tc5_HSDV_function',
        statement_types => 'select',
        update_check => true
    );
END;

-- Nháp
select MaHSBA from SOYTEX.HSBA WHERE EXTRACT(DAY FROM Ngay) >= 5 AND EXTRACT(DAY FROM Ngay) <= 27;
SELECT * FROM SOYTEX.HSBA;
SELECT * FROM USER_ROLE_PRIVS WHERE GRANTEE = 'CSYT';
delete from soytex.hsba where mahsba = 'HSBA005';

SELECT * FROM SOYTEX.HSBA;
INSERT INTO SOYTEX.HSBA VALUES('HSBA008', 'BN002', TO_DATE('17-06-2022','dd/mm/yyyy'), 'Bị khùng nặng', 'NV007', 'K001', 'CSYT001', 'Bị khùng');
DELETE FROM SOYTEX.HSBA
WHERE
    MAHSBA = 'HSBA008';
SELECT USER FROM DUAL;
