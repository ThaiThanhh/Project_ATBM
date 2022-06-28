SELECT VALUE FROM V$OPTION WHERE PARAMETER = 'Unified Auditing';

---
/*CREATE AUDIT POLICY db_admin_audit_pol
PRIVILEGES CREATE USER, DROP USER, ALTER USER;

AUDIT POLICY db_admin_audit_pol BY DB_ADMIN;

DROP AUDIT POLICY db_admin_audit_pol;

NOAUDIT POLICY db_admin_audit_pol by DB_ADMIN;*/

-- STANDARD AUDIT
-- audit khi user them du lieu tren bang NHANVIEN
CREATE AUDIT POLICY insert_nhanvien_pol
ACTIONS INSERT ON SOYTEX.NHANVIEN;

AUDIT POLICY insert_nhanvien_pol;

-- audit khi user them du lieu tren bang BENHNHAN
CREATE AUDIT POLICY insert_benhnhan_pol
ACTIONS INSERT ON SOYTEX.BENHNHAN;

AUDIT POLICY insert_benhnhan_pol;

--
CREATE AUDIT POLICY delete_hsba_pol
ACTIONS DELETE ON SOYTEX.HSBA,
        DELETE ON SOYTEX.HSBA_DV;

AUDIT POLICY delete_hsba_pol;

--
BEGIN
 DBMS_FGA.DROP_POLICY(
    object_schema => 'SOYTEX',
    object_name => 'NHANVIEN',
    policy_name => 'audit_nhanvien'
    );
END;

BEGIN
    dbms_fga.add_policy (
        object_schema => 'SOYTEX',
        object_name => 'NHANVIEN',
        policy_name => 'audit_nhanvien',
        audit_column => 'VAITRO, CHUYENKHOA',
        statement_types => 'UPDATE'
        );
END;

--
BEGIN
 DBMS_FGA.DROP_POLICY(
    object_schema => 'SOYTEX',
    object_name => 'BENHNHAN',
    policy_name => 'audit_benhnhan'
    );
END;

BEGIN
    dbms_fga.add_policy (
        object_schema => 'SOYTEX',
        object_name => 'BENHNHAN',
        policy_name => 'audit_benhnhan',
        audit_column => 'TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC',
        statement_types => 'UPDATE'
        );
END;

-- Fine-Grained Audit
-- audit khi nguoi dung truy cap du lieu bang HSBA trong thang hien tai
BEGIN
 DBMS_FGA.DROP_POLICY(
    object_schema => 'SOYTEX',
    object_name => 'HSBA',
    policy_name => 'audit_select_hsba'
    );
END;

BEGIN
    dbms_fga.add_policy (
        object_schema => 'SOYTEX',
        object_name => 'HSBA',
        policy_name => 'audit_select_hsba',
        audit_condition => 'EXTRACT(MONTH FROM Ngay) = EXTRACT(MONTH FROM SYSDATE)',
        statement_types => 'SELECT'
        );
END;

-- xem thong tin policy
SELECT POLICY_NAME FROM DBA_AUDIT_POLICIES;

-- xem audit
SELECT AUDIT_TYPE, ACTION_NAME, DBUSERNAME, TARGET_USER, UNIFIED_AUDIT_POLICIES, FGA_POLICY_NAME, OBJECT_SCHEMA, OBJECT_NAME, SQL_TEXT, EVENT_TIMESTAMP
FROM UNIFIED_AUDIT_TRAIL
WHERE OBJECT_SCHEMA = 'SOYTEX';


