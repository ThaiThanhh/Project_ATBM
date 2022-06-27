-- PHAN QUYEN CHO DBA
GRANT CREATE SESSION TO DB_ADMIN;
GRANT DBA TO DB_ADMIN;

GRANT EXECUTE ON soytex.proc_add_user TO DB_ADMIN;
GRANT EXECUTE ON soytex.proc_drop_user TO DB_ADMIN;
GRANT EXECUTE ON soytex.proc_grant_priv TO DB_ADMIN;
GRANT EXECUTE ON soytex.proc_grant_role TO DB_ADMIN;
GRANT EXECUTE ON soytex.proc_revoke_privilege TO DB_ADMIN;
GRANT EXECUTE ON soytex.proc_revoke_role TO DB_ADMIN;

GRANT EXECUTE ON soytex.Create_Role TO DB_ADMIN;
GRANT EXECUTE ON soytex.Alter_Role TO DB_ADMIN;
GRANT EXECUTE ON soytex.Drop_Role TO DB_ADMIN;
GRANT EXECUTE ON soytex.Grant_Privs_To_Role TO DB_ADMIN;
GRANT EXECUTE ON soytex.Revoke_Role_Privs TO DB_ADMIN;

--PHAN QUYEN (DAC)
GRANT INSERT ON SOYTEX.HSBA TO CSYT;
GRANT SELECT, DELETE ON SOYTEX.HSBA TO CSYT;
GRANT SELECT,INSERT, DELETE ON SOYTEX.HSBA_DV TO CSYT;

GRANT SELECT ON SOYTEX.HSBA TO YSI_BACSI, NGHIENCUU;
GRANT SELECT ON SOYTEX.HSBA_DV TO YSI_BACSI;
GRANT SELECT ON SOYTEX.HSBA_DV TO NGHIENCUU;

GRANT SELECT, UPDATE ON SOYTEX.NHANVIEN TO NHANVIEN;
GRANT SELECT ON SOYTEX.BENHNHAN TO BENHNHAN, YSI_BACSI;
GRANT UPDATE ON SOYTEX.BENHNHAN TO BENHNHAN;
 
GRANT SELECT ON soytex.csyt TO THANHTRA;
GRANT SELECT ON soytex.nhanvien TO THANHTRA;
GRANT SELECT ON soytex.benhnhan TO THANHTRA;
GRANT SELECT ON soytex.hsba TO THANHTRA;
GRANT SELECT ON soytex.hsba_dv TO THANHTRA;

--VPD
--TC#3:
-- tai khoan cua csyt nao thi them, xoa hsba thuoc csyt do
CREATE OR REPLACE FUNCTION TC3_1_function(p_schema varchar2, p_obj varchar2)
RETURN NVARCHAR2
AS
    v_user VARCHAR2(15);
BEGIN
    v_user := SYS_CONTEXT('userenv', 'SESSION_USER');
    RETURN '(MACSYT in (select CSYT from SOYTEX.NHANVIEN WHERE MANV = ''' || v_user ||''')) AND(EXTRACT(DAY FROM Ngay) >= 5) AND (EXTRACT(DAY FROM Ngay) <= 27) AND (EXTRACT(MONTH FROM Ngay) = EXTRACT(MONTH FROM SYSDATE))';
END;

-- tai khoan cua csyt nao thi them, xoa hsba_dv thuoc csyt do
CREATE OR REPLACE FUNCTION TC3_3_function(p_schema varchar2, p_obj varchar2)
RETURN NVARCHAR2
AS
    v_user VARCHAR2(15);
BEGIN
    v_user := SYS_CONTEXT('userenv', 'SESSION_USER');
    RETURN '(MAHSBA in (select MAHSBA from SOYTEX.HSBA, SOYTEX.NhanVien WHERE CSYT = MaCSYT AND MaNV = ''' || v_user ||''')) AND (EXTRACT(DAY FROM Ngay) >= 5) AND (EXTRACT(DAY FROM Ngay) <= 27) AND (EXTRACT(MONTH FROM Ngay) = EXTRACT(MONTH FROM SYSDATE))';
END;

--cau a:
BEGIN
    DBMS_RLS.DROP_POLICY
    (
        object_schema => 'SOYTEX',
        object_name => 'HSBA_DV',
        policy_name => 'TC#3a'
    );
END;

BEGIN
    DBMS_RLS.ADD_POLICY
    (
        object_schema => 'SOYTEX',
        object_name => 'HSBA',
        policy_name => 'TC#3a',
        policy_function => 'TC3_1_function',
        statement_types => 'insert, delete',
        update_check => true
    );
END;
-- cau b:
BEGIN
    DBMS_RLS.ADD_POLICY
    (
        object_schema => 'SOYTEX',
        object_name => 'HSBA_DV',
        policy_name => 'TC#3b',
        policy_function => 'TC3_3_function',
        statement_types => 'insert, delete',
        update_check => true
    );
END;

-- TC#4 + TC#5:
CREATE OR REPLACE FUNCTION VIEW_HSBA(p_schema varchar2, p_obj varchar2)
RETURN NVARCHAR2
AS
    CURSOR CUR IS (SELECT granted_role
                    FROM dba_role_privs
                    WHERE grantee = SYS_CONTEXT('userenv', 'SESSION_USER'));
    usr NVARCHAR2(100);
    user_role NVARCHAR2(100);
Begin
    usr := SYS_CONTEXT('userenv', 'SESSION_USER');
    
    OPEN CUR;
    
    LOOP
        FETCH CUR INTO user_role;
        EXIT WHEN CUR%NOTFOUND;
            
        if (user_role = 'YSI_BACSI') then
            return 'MABS = '''|| usr ||'''';
            
        elsif (user_role = 'NGHIENCUU') then
            return '(MAKHOA in (select CHUYENKHOA from SOYTEX.NhanVien WHERE MaNV = ''' || usr ||''')) AND (MACSYT in (select CSYT from SOYTEX.NhanVien WHERE MaNV = ''' || usr ||'''))';
        
        elsif (user_role = 'CSYT') then
            RETURN '(MACSYT in (select CSYT from SOYTEX.NHANVIEN WHERE MANV = ''' || usr ||''')) AND(EXTRACT(DAY FROM Ngay) >= 5) AND (EXTRACT(DAY FROM Ngay) <= 27) AND (EXTRACT(MONTH FROM Ngay) = EXTRACT(MONTH FROM SYSDATE))';
            
        end if;
    END LOOP;
    
    CLOSE CUR;
    
    return '';
End;

begin
    dbms_rls.drop_policy
    (
        object_schema => 'SOYTEX',
        object_name => 'HSBA',
        policy_name => 'TC#4#5_PC1'
    );
end;

begin
    DBMS_RLS.add_policy
    (
        object_schema => 'SOYTEX',
        object_name => 'HSBA',
        policy_name => 'TC#4#5_PC1',
        policy_function => 'VIEW_HSBA',
        statement_types => 'select'
    );
end;

--
CREATE OR REPLACE FUNCTION VIEW_HSBA_DV(p_schema varchar2, p_obj varchar2)
RETURN NVARCHAR2
AS
    CURSOR CUR IS (SELECT granted_role
                    FROM dba_role_privs
                    WHERE grantee = SYS_CONTEXT('userenv', 'SESSION_USER'));
    usr NVARCHAR2(100);
    user_role NVARCHAR2(100);
Begin
    usr := SYS_CONTEXT('userenv', 'SESSION_USER');
    
    OPEN CUR;
    
    LOOP
        FETCH CUR INTO user_role;
        EXIT WHEN CUR%NOTFOUND;
            
        if (user_role = 'YSI_BACSI') then
            return 'MAHSBA in (select MAHSBA from SOYTEX.HSBA WHERE MABS = ''' || usr ||''')';
            
        elsif (user_role = 'NGHIENCUU') then
            return 'MAHSBA in (select MAHSBA from SOYTEX.HSBA, SOYTEX.NhanVien WHERE CSYT = MaCSYT AND MAKHOA = CHUYENKHOA AND MaNV = ''' || usr ||''')';
        
        elsif (user_role = 'CSYT') then
            RETURN '(MAHSBA in (select MAHSBA from SOYTEX.HSBA, SOYTEX.NhanVien WHERE CSYT = MaCSYT AND MaNV = ''' || usr ||''')) AND (EXTRACT(DAY FROM Ngay) >= 5) AND (EXTRACT(DAY FROM Ngay) <= 27) AND (EXTRACT(MONTH FROM Ngay) = EXTRACT(MONTH FROM SYSDATE))';
   
        end if;
    END LOOP;
    
    CLOSE CUR;
    
    return '';
End;

begin
    dbms_rls.drop_policy
    (
        object_schema => 'SOYTEX',
        object_name => 'HSBA_DV',
        policy_name => 'TC#4#5_PC2'
    );
end;

begin
    DBMS_RLS.add_policy
    (
        object_schema => 'SOYTEX',
        object_name => 'HSBA_DV',
        policy_name => 'TC#4#5_PC2',
        policy_function => 'VIEW_HSBA_DV',
        statement_types => 'select'
    );
end;

--TC#6
--NHAN VIEN XEM, CHINH SUA THONG TIN CA NHAN
CREATE OR REPLACE FUNCTION VIEW_NV(p_schema varchar2, p_obj varchar2)
RETURN NVARCHAR2
AS
    CURSOR CUR IS (SELECT granted_role
                    FROM dba_role_privs
                    WHERE grantee = SYS_CONTEXT('userenv', 'SESSION_USER'));
    usr NVARCHAR2(100);
    user_role NVARCHAR2(100);
Begin
    usr := SYS_CONTEXT('userenv', 'SESSION_USER');
    
    OPEN CUR;
    LOOP
        FETCH CUR INTO user_role;
        EXIT WHEN CUR%NOTFOUND;
            
        if (user_role = 'THANHTRA') then
            return '1 = 1';
        end if;
    END LOOP;
    
    CLOSE CUR;
    
    return 'MANV = '''|| usr ||'''';
End;

begin
    DBMS_RLS.add_policy
    (
        object_schema => 'SOYTEX',
        object_name => 'NHANVIEN',
        policy_name => 'TC#6_PC1',
        policy_function => 'VIEW_NV',
        statement_types => 'select, update',
        update_check => true
    );
end;

-- NHAN VIEN KHONG DUOC PHEP UPDATE MANV CUA MINH
CREATE OR REPLACE FUNCTION PROHIBIT_UPDATE_MANV(p_schema varchar2, p_obj varchar2)
RETURN NVARCHAR2
AS
    usr NVARCHAR2(100);
Begin
    return '0=1';
End;

begin
    DBMS_RLS.add_policy
    (
        object_schema => 'SOYTEX',
        object_name => 'NHANVIEN',
        policy_name => 'TC#6_PC2',
        policy_function => 'PROHIBIT_UPDATE_MANV',
        statement_types => 'update',
        sec_relevant_cols => 'MANV',
        update_check => true
    );
end;

-- BENH NHAN XEM, CHINH SUA THONG TIN CA NHAN
CREATE OR REPLACE FUNCTION VIEW_BN(p_schema varchar2, p_obj varchar2)
RETURN NVARCHAR2
AS
    CURSOR CUR IS (SELECT granted_role
                    FROM dba_role_privs
                    WHERE grantee = SYS_CONTEXT('userenv', 'SESSION_USER'));
    usr NVARCHAR2(100);
    user_role NVARCHAR2(100);
Begin
    usr := SYS_CONTEXT('userenv', 'SESSION_USER');
    
    OPEN CUR;
    
    LOOP
        FETCH CUR INTO user_role;
        EXIT WHEN CUR%NOTFOUND;
            
        if (user_role = 'BENHNHAN') then
            return 'MABN = '''|| usr ||'''';
            
        elsif (user_role = 'THANHTRA') then
            return '1=1';
        
        elsif (user_role = 'THANHTRA') then
            return 'MABN in (select MABN from SOYTEX.HSBA WHERE MABS = ''' || usr ||''')';
            
        end if;
        
    END LOOP;
    
    CLOSE CUR;
End;


begin
    DBMS_RLS.drop_policy
    (
        object_schema => 'SOYTEX',
        object_name => 'BENHNHAN',
        policy_name => 'TC#6_PC3'
    );
end;

begin
    DBMS_RLS.add_policy
    (
        object_schema => 'SOYTEX',
        object_name => 'BENHNHAN',
        policy_name => 'TC#6_PC3',
        policy_function => 'VIEW_BN',
        statement_types => 'select, update',
        update_check => true
    );
end;

CREATE OR REPLACE FUNCTION PROHIBIT_UPDATE_MABN(p_schema varchar2, p_obj varchar2)
RETURN NVARCHAR2
AS
    usr NVARCHAR2(100);
Begin
    return '0=1';
End;

begin
    DBMS_RLS.add_policy
    (
        object_schema => 'SOYTEX',
        object_name => 'BENHNHAN',
        policy_name => 'TC#6_PC4',
        policy_function => 'PROHIBIT_UPDATE_MABN',
        statement_types => 'update',
        sec_relevant_cols => 'MABN',
        update_check => true
    );
end;
