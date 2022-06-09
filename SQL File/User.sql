--Kết nối vào DBA
connect soytex/admin1 as sysdba;

alter session set '_ORACLE_SCRIPT' = true;

--Tạo các user nhân viên từ bảng NhanVien, lấy MaNV làm username, MK mặc định là 1
declare
    NV_list sys_refcursor;
    MaNV_str soytex.NhanVien.MaNV%type;
begin
    open NV_list for
        select MaNV from soytex.NhanVien;
    
    loop
        fetch NV_list into MaNV_str;
        exit when NV_list%notfound;

        execute immediate 'create user ' || MaNV_str || ' identified by 1';
    end loop;

    close NV_list;
end;

--Tạo các user bệnh nhân từ bảng BenhNhan, lấy MaBN làm username, MK mặc định là 1
declare
    BN_list sys_refcursor;
    MaBN_str soytex.BenhNhan.MaBN%type;
begin
    open BN_list for
        select MaBN from soytex.BenhNhan;
    
    loop
        fetch BN_list into MaBN_str;
        exit when BN_list%notfound;

        execute immediate 'create user ' || MaBN_str || ' identified by 1';
    end loop;

    close BN_list;
end;

alter session set '_ORACLE_SCRIPT' = false;