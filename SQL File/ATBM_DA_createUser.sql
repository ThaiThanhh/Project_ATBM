-- TAO ROLE CAC ROLE
alter session set "_ORACLE_SCRIPT"= true;
/*
-- Xoa role
DELETE ROLE NHANVIEN;
DELETE ROLE YSI_BACSI;
DELETE ROLE NGHIENCUU;
DELETE ROLE THANHTRA;
DELETE ROLE BENHNHAN;
DELETE ROLE CSYT;
*/

CREATE ROLE NHANVIEN;
CREATE ROLE YSI_BACSI;
CREATE ROLE NGHIENCUU;
CREATE ROLE THANHTRA;
CREATE ROLE BENHNHAN;
CREATE ROLE CSYT;
alter session set "_ORACLE_SCRIPT" = FALSE;

/*-- Xoa cac user co trong csdl (su dung khi can thiet)
create or replace procedure delete_user_NV
as
    CURSOR CUR IS (SELECT MANV
                    FROM SOYTEX.NHANVIEN);
    strSQL VARCHAR(2000);
    Usr VARCHAR2(30);
begin
    OPEN CUR;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE (strSQL);
    LOOP
        FETCH CUR INTO Usr;
        EXIT WHEN CUR%NOTFOUND;
        
        strSQL := 'DROP USER '||Usr||' CASCADE';
        EXECUTE IMMEDIATE (strSQL);
    END LOOP;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=FALSE';
    EXECUTE IMMEDIATE (strSQL);
end;
EXEC delete_user_NV;

create or replace procedure delete_user_BN
as
    CURSOR CUR IS (SELECT MABN
                    FROM SOYTEX.BENHNHAN);
    strSQL VARCHAR(2000);
    Usr VARCHAR2(30);
begin
    OPEN CUR;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE (strSQL);
    LOOP
        FETCH CUR INTO Usr;
        EXIT WHEN CUR%NOTFOUND;
        
        strSQL := 'DROP USER '||Usr||' CASCADE';
        EXECUTE IMMEDIATE (strSQL);
    END LOOP;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=FALSE';
    EXECUTE IMMEDIATE (strSQL);
end;
EXEC delete_user_BN;
*/

-- TAO USER CHO BENH NHAN
CREATE OR REPLACE PROCEDURE CreateUser_BN
AS
    CURSOR CUR IS (SELECT MABN
                    FROM SOYTEX.BENHNHAN
                    WHERE UPPER(MABN) NOT IN (SELECT USERNAME
                                        FROM ALL_USERS));
    strSQL VARCHAR(2000);
    Usr VARCHAR2(30);
BEGIN
    OPEN CUR;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE (strSQL);
    LOOP
        FETCH CUR INTO Usr;
        EXIT WHEN CUR%NOTFOUND;
        
        strSQL := 'CREATE USER '||Usr||' IDENTIFIED BY 1234';
        EXECUTE IMMEDIATE (strSQL);
        strSQL := 'GRANT CREATE SESSION TO '||Usr;
        EXECUTE IMMEDIATE (strSQL);
        strSQL := 'GRANT BENHNHAN TO '||Usr;
        EXECUTE IMMEDIATE (strSQL);
    END LOOP;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=FALSE';
    EXECUTE IMMEDIATE (strSQL);
END;

EXEC CreateUser_BN;

-- TAO USER CHO Y/ BAC SI
CREATE OR REPLACE PROCEDURE CreateUser_Ysi_Bacsi
AS
    CURSOR CUR IS (SELECT MANV
                    FROM SOYTEX.NHANVIEN
                    WHERE VAITRO = N'Y si/ Bac si'
                    AND UPPER(MANV) NOT IN (SELECT USERNAME
                                        FROM ALL_USERS));
    strSQL VARCHAR(2000);
    Usr VARCHAR2(30);
BEGIN
    OPEN CUR;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE (strSQL);
    LOOP
        FETCH CUR INTO Usr;
        EXIT WHEN CUR%NOTFOUND;
        
        strSQL := 'CREATE USER '||Usr||' IDENTIFIED BY 1234';
        EXECUTE IMMEDIATE (strSQL);
        strSQL := 'GRANT CREATE SESSION TO '||Usr;
        EXECUTE IMMEDIATE (strSQL);
        strSQL := 'GRANT NHANVIEN, YSI_BACSI TO '||Usr;
        EXECUTE IMMEDIATE (strSQL);
    END LOOP;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=FALSE';
    EXECUTE IMMEDIATE (strSQL);
END;

EXEC CreateUser_Ysi_Bacsi;

-- TAO USER CHO THANH TRA
CREATE OR REPLACE PROCEDURE CreateUser_ThanhTra
AS
    CURSOR CUR IS (SELECT MANV
                    FROM SOYTEX.NHANVIEN
                    WHERE VAITRO = N'Thanh tra'
                    AND UPPER(MANV) NOT IN (SELECT USERNAME
                                        FROM ALL_USERS));
    strSQL VARCHAR(2000);
    Usr VARCHAR2(30);
BEGIN
    OPEN CUR;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE (strSQL);
    LOOP
        FETCH CUR INTO Usr;
        EXIT WHEN CUR%NOTFOUND;
        
        strSQL := 'CREATE USER '||Usr||' IDENTIFIED BY 1234';
        EXECUTE IMMEDIATE (strSQL);
        strSQL := 'GRANT CREATE SESSION TO '||Usr;
        EXECUTE IMMEDIATE (strSQL);
        strSQL := 'GRANT NHANVIEN, THANHTRA TO '||Usr;
        EXECUTE IMMEDIATE (strSQL);
    END LOOP;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=FALSE';
    EXECUTE IMMEDIATE (strSQL);
END;

EXEC CreateUser_ThanhTra;

-- TAO USER CHO NGHIEN CUU
CREATE OR REPLACE PROCEDURE CreateUser_NghienCuu
AS
    CURSOR CUR IS (SELECT MANV
                    FROM SOYTEX.NHANVIEN
                    WHERE VAITRO = N'Nghien cuu'
                    AND UPPER(MANV) NOT IN (SELECT USERNAME
                                        FROM ALL_USERS));
    strSQL VARCHAR(2000);
    Usr VARCHAR2(30);
BEGIN
    OPEN CUR;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE (strSQL);
    LOOP
        FETCH CUR INTO Usr;
        EXIT WHEN CUR%NOTFOUND;
        
        strSQL := 'CREATE USER '||Usr||' IDENTIFIED BY 1234';
        EXECUTE IMMEDIATE (strSQL);
        strSQL := 'GRANT CREATE SESSION TO '||Usr;
        EXECUTE IMMEDIATE (strSQL);
        strSQL := 'GRANT NHANVIEN, NGHIENCUU TO '||Usr;
        EXECUTE IMMEDIATE (strSQL);
    END LOOP;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=FALSE';
    EXECUTE IMMEDIATE (strSQL);
END;

EXEC CreateUser_NghienCuu;

-- TAO USER CHO CSYT
CREATE OR REPLACE PROCEDURE CreateUser_CSYT
AS
    CURSOR CUR IS (SELECT MANV
                    FROM SOYTEX.NHANVIEN
                    WHERE VAITRO = N'Co so y te'
                    AND UPPER(MANV) NOT IN (SELECT USERNAME
                                        FROM ALL_USERS));
    strSQL VARCHAR(2000);
    Usr VARCHAR2(30);
BEGIN
    OPEN CUR;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE (strSQL);
    LOOP
        FETCH CUR INTO Usr;
        EXIT WHEN CUR%NOTFOUND;
        
        strSQL := 'CREATE USER '||Usr||' IDENTIFIED BY 1234';
        EXECUTE IMMEDIATE (strSQL);
        strSQL := 'GRANT CREATE SESSION TO '||Usr;
        EXECUTE IMMEDIATE (strSQL);
        strSQL := 'GRANT NHANVIEN, CSYT TO '||Usr;
        EXECUTE IMMEDIATE (strSQL);
    END LOOP;
    strSQL := 'alter session set "_ORACLE_SCRIPT"=FALSE';
    EXECUTE IMMEDIATE (strSQL);
END;

EXEC CreateUser_CSYT;










