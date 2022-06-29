CREATE OR REPLACE PROCEDURE SOYTEX.proc_insert_HSBA(
	p_mahsba IN NVARCHAR2,
	p_patient IN NVARCHAR2,
	p_date IN NVARCHAR2,
	p_diagnose IN NVARCHAR2,
	p_doctor IN NVARCHAR2,
	p_major IN NVARCHAR2,
	p_csyt IN NVARCHAR2,
    p_result IN NVARCHAR2)
IS
    tmp_query VARCHAR(150);
BEGIN
    tmp_query := 'INSERT INTO SOYTEX.HSBA VALUES (''' || p_mahsba || ''',''' || p_patient || ''', TO_DATE('''|| p_date || ''', ' || '''DD/MM/YYYY''' || '), ''' || p_diagnose || ''', ''' || p_doctor || ''', ''' || p_major || ''', ''' || p_csyt || ''',''' || p_result || ''')';
    EXECUTE IMMEDIATE ( tmp_query );
END;

CREATE OR REPLACE PROCEDURE SOYTEX.proc_update_BenhNhan(
	p_csyt IN NVARCHAR2,
	p_patientName IN NVARCHAR2,
	p_id IN NVARCHAR2,
	p_dob IN NVARCHAR2,
	p_num IN VARCHAR2,
	p_street IN NVARCHAR2,
	p_district IN NVARCHAR2,
	p_city IN NVARCHAR2,
	p_medicalHistory IN NVARCHAR2,
	p_familyMedicalHistory IN NVARCHAR2,
    p_allergy IN NVARCHAR2)
IS
    tmp_query VARCHAR(500);
BEGIN
    tmp_query := 'UPDATE SOYTEX.BENHNHAN SET MaCSYT = ''' || p_csyt || ''', TenBN = '''|| p_patientName|| ''', CMND = ''' || p_id || ''', NgaySinh = TO_DATE('''|| p_dob || ''', ' || '''DD/MM/YYYY''' || '), SoNha = ''' || p_num || ''', TenDuong = ''' || p_street || ''', QuanHuyen = ''' || p_district || ''', TinhTP = ''' || p_city || ''', TienSuBenh = ''' || p_medicalHistory || ''', TienSuBenhGD = ''' || p_familyMedicalHistory || ''', DiUngThuoc = ''' || p_allergy || '''';
    
    EXECUTE IMMEDIATE ( tmp_query );
END;

CREATE OR REPLACE PROCEDURE SOYTEX.proc_update_NhanVien(
	p_HoTen IN NVARCHAR2,
	p_Phai IN NVARCHAR2,
	p_NgaySinh IN NVARCHAR2,
	p_CMND IN NVARCHAR2,
	p_QueQUan IN VARCHAR2,
	p_SoDT IN NVARCHAR2,
	p_CSYT IN NVARCHAR2,
	p_VaiTro IN NVARCHAR2,
	p_ChuyenKhoa IN NVARCHAR2)
IS
    tmp_query VARCHAR(500);
BEGIN
    tmp_query := 'UPDATE SOYTEX.NhanVien SET HoTen = ''' || p_HoTen || ''', Phai = '''|| p_Phai|| ''', NgaySinh = TO_DATE('''|| p_NgaySinh || ''', ' || '''DD/MM/YYYY''' || '), CMND = ''' || p_CMND || ''', QueQUan = ''' || p_QueQUan || ''', SoDT = ''' || p_SoDT || ''', CSYT = ''' || p_CSYT || ''', VaiTro = ''' || p_VaiTro || ''', ChuyenKhoa = ''' || p_ChuyenKhoa || '''';
    
    EXECUTE IMMEDIATE ( tmp_query );
END;

SELECT * FROM SOYTEX.HSBA;
SELECT * FROM SOYTEX.BenhNhan;

EXEC SOYTEX.proc_insert_HSBA('HSBA005', 'BN001', '12-JUN-22', 'CHO QUANG AN', 'NV003', 'K001', 'CSYT001', 'KHUNG'); 
EXEC SOYTEX.proc_update_BenhNhan('CSYT001', 'MAI XINH DEP', '123456789', '12-JUN-22', '1', 'Ngo Quyen', 'Quan 1', 'Tp Ho Chi Minh', 'BI KHUM', 'BI XINH XAN', 'Khong'); 
EXEC SOYTEX.proc_update_BenhNhan('MAI XINH DEP', 'NU', '123456789', '12-JUN-22', '1', 'Ngo Quyen', 'Quan 1', 'Tp Ho Chi Minh', 'BI KHUM', 'BI XINH XAN', 'Khong'); 
     
DELETE SOYTEX.HSBA WHERE MaHSBA = 'HSBA005'

