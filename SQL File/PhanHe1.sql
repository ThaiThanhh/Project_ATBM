-- USER
--Them user
CREATE OR REPLACE PROCEDURE soytex.proc_add_user
(user_name IN VARCHAR2 , u_password IN VARCHAR2 )
authid current_user
IS
    tmp_query VARCHAR(150);
BEGIN
    tmp_query := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE ( tmp_query );
    
    tmp_query := 'create user ' || user_name || ' identified by ' || u_password;
    EXECUTE IMMEDIATE ( tmp_query );
    
    tmp_query := 'alter session set "_ORACLE_SCRIPT"=false';
    EXECUTE IMMEDIATE ( tmp_query );
END;
--Xoa User

create or replace NONEDITIONABLE PROCEDURE soytex.proc_drop_user
 (user_name IN VARCHAR2)
authid current_user
IS
    tmp_query VARCHAR(150);
BEGIN
    tmp_query := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE ( tmp_query );
    tmp_query := 'drop user ' || user_name;
    EXECUTE IMMEDIATE ( tmp_query );
    tmp_query := 'alter session set "_ORACLE_SCRIPT"=false';
    EXECUTE IMMEDIATE ( tmp_query );
END;
--Tim kiem user
/*CREATE OR REPLACE PROCEDURE SOYTEX.proc_search_user
 (user_name IN VARCHAR2)
IS
    p_user SYS_REFCURSOR;
BEGIN
    OPEN p_user FOR
        SELECT * FROM ALL_USERS WHERE INSTR(USERNAME, user_name)!=0 ;
    DBMS_SQL.RETURN_RESULT(p_user);
END;

--Thong tin quyen cua user
CREATE OR REPLACE PROCEDURE soytex.proc_privs_information
(user_name IN NVARCHAR2)IS
C1 SYS_REFCURSOR;
BEGIN
    OPEN C1 FOR
    select * from dba_tab_privs where grantee = ''|| user_name ||'';
    DBMS_SQL.RETURN_RESULT(C1);   
END;*/


--Cap quyen cho user
CREATE OR REPLACE PROCEDURE soytex.proc_grant_priv
(user_name IN NVARCHAR2,
p_table IN NVARCHAR2,
p_columns in nvarchar2,
priv in varchar,
grant_option in number)IS --1: co grant option; 0: khong co

tmp_query VARCHAR(150);
BEGIN
    if (p_columns ='all') then
        tmp_query := 'GRANT '||PRIV||' ON '||P_TABLE||' TO '|| user_name;
    else
        tmp_query := 'GRANT '||PRIV||' ('||P_COLUMNS||')'||' ON '||P_TABLE||' TO '|| user_name;
    end if;
    if (grant_option =1) then
        tmp_query := tmp_query || ' WITH GRANT OPTION';
    end if;
    EXECUTE IMMEDIATE ( tmp_query );
END;

--Cap role cho user
CREATE OR REPLACE PROCEDURE soytex.proc_grant_role
(user_name IN NVARCHAR2,
role IN NVARCHAR2)IS 

tmp_query VARCHAR(150);
BEGIN
    tmp_query := 'GRANT '||role||' TO '|| user_name;

    EXECUTE IMMEDIATE ( tmp_query );
END;

--Thu hoi quyen tu user
CREATE OR REPLACE PROCEDURE soytex.proc_revoke_privilege
(user_name IN NVARCHAR2,
p_table IN NVARCHAR2,
privilege IN NVARCHAR2)IS

tmp_query VARCHAR(150);
BEGIN
    tmp_query := 'REVOKE '||PRIVILEGE||' ON '||P_TABLE||' FROM '|| user_name;
    
    EXECUTE IMMEDIATE ( tmp_query );
END;

-- Revoke role
create or replace PROCEDURE soytex.proc_revoke_role
 (user_name IN VARCHAR2, role_name IN VARCHAR2)
IS
    tmp_query VARCHAR(150);
BEGIN
    tmp_query := 'revoke ' || role_name || ' from ' || user_name;
    EXECUTE IMMEDIATE ( tmp_query );
END;

-- ROLE
--Procedure xem quy?n c?a role trên các ??i t??ng d? li?u, hàm này tr? v? 1 con tr? tham chi?u ??n b?ng k?t qu? trong hàm
/*
create or replace procedure soytex.View_Role_Privileges(rlt_tab out sys_refcursor)
is
begin
    open rlt_tab for
        select ROLE_TAB_PRIVS.role as "Nhóm ng??i dùng", table_name as "Tên b?ng", column_name as "Tên c?t", privilege "Quy?n"
        from ROLE_TAB_PRIVS join DBA_ROLES on ROLE_TAB_PRIVS.role = DBA_ROLES.role
        where DBA_ROLES.oracle_maintained = 'N';
end;
*/

--ch?y th? hàm
--    variable rlt_tab refcursor;
--    execute View_Role_Privileges(:rlt_tab);
--    print rlt_tab;


--Procedure t?o role tên là role_name và _identity: ???c x? lý ? ph?n giao di?n
--  _identity = 'not identified' if no indentity else 'identified by ' || identity_mode(password, schema, externally, ...)
create or replace procedure soytex.Create_Role(role_name in varchar2, identity_mode in varchar2)
authid current_user
is
tmp_query VARCHAR(150);
begin
    tmp_query := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE ( tmp_query );
    
    execute immediate 'create role ' || role_name || ' ' || identity_mode;
    
    tmp_query := 'alter session set "_ORACLE_SCRIPT"=false';
    EXECUTE IMMEDIATE ( tmp_query );
end;
/

--VD n?u t?o role tên là 'c##role01' mà không có hình th?c ??nh danh
----execute Create_Role('c##role01', '');
----ho?c execute Create_Role('c##role01', 'not identified');
--VD2: n?u t?o role tên là 'c##role02; có hình th?c ??nh danh là m?t kh?u vs pass là 'abc@123'
----execute Create_Role('c##role02', 'identified by abc@123');

--Procedure ch?nh s?a role tên là role_name và _identity: ???c x? lý ? ph?n giao di?n
--  _identity = 'not identified' if no indentity else 'identified by ' || identity_mode(password, schema, ...)
--Note: Phép alter không có ??i tên cho role
create or replace procedure soytex.Alter_Role(role_name in varchar2, identity_mode in varchar2)
authid current_user
is
tmp_query VARCHAR(150);
begin
    tmp_query := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE ( tmp_query );
    
    execute immediate 'alter role ' || role_name || ' ' || identity_mode;
    
    tmp_query := 'alter session set "_ORACLE_SCRIPT"=false';
    EXECUTE IMMEDIATE ( tmp_query );
end;
/

--VD n?u trong h? th?ng có role 'c##role01', mu?n ??i sang hình th?c ??nh danh là h? ?i?u hành ho?c ph?n m?m bên th? 3
----execute Alter_Role('c##role01', 'identified externally');

--Procudure xóa 1 role có tên role_name
create or replace procedure soytex.Drop_Role(role_name in varchar2)
authid current_user
is
tmp_query VARCHAR(150);
begin
    tmp_query := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE ( tmp_query );
    
    execute immediate 'drop role ' || role_name;
    
    tmp_query := 'alter session set "_ORACLE_SCRIPT"=false';
    EXECUTE IMMEDIATE ( tmp_query );
end;
/

--cái này ??a ví d? là hi?u li?n không c?n gi?i thích nhi?u
----execute Drop_Role('c##role01');

--Procedure c?p quy?n priv_name trên ??i t??ng d? li?u obj cho role_name
create or replace procedure soytex.Grant_Privs_To_Role(role_name in varchar2, privs_name in varchar2, obj in varchar2)
is
begin
    execute immediate 'grant ' || privs_name || ' on ' || obj || ' to ' || role_name;
end;
/

--Gi? s? ta mu?n gán cho role 'c##role01' quy?n select trên b?ng 'TAB01'
----execute Grant_Privs_To_Role(role_name => 'c##role01', privs_name => 'select', obj => 'TAB01');

--N?u ta mu?n gán cho role 'c##role02' quy?n update trên c?t col1, col2 trên b?ng 'TAB02'
----execute Grant_Privs_To_Role(role_name => 'c##role02', privs_name => 'update(col1, col2)', obj => 'TAB02');

--Procedure tru?t quy?n priv_name trên ??i t??ng d? li?u obj ra kh?i role_name
create or replace procedure soytex.Revoke_Role_Privs(role_name in varchar2, priv_name in varchar2, obj in varchar2)
is
begin
    execute immediate 'revoke ' || priv_name || ' on ' || obj || ' from ' || role_name;
end;
/