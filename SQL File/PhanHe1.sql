-- USER
--Them user
CREATE OR REPLACE PROCEDURE proc_add_user
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

create or replace NONEDITIONABLE PROCEDURE proc_drop_user
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
CREATE OR REPLACE PROCEDURE proc_grant_priv
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
CREATE OR REPLACE PROCEDURE proc_grant_role
(user_name IN NVARCHAR2,
role IN NVARCHAR2)IS 

tmp_query VARCHAR(150);
BEGIN
    tmp_query := 'GRANT '||role||' TO '|| user_name;

    EXECUTE IMMEDIATE ( tmp_query );
END;

--Thu hoi quyen tu user
CREATE OR REPLACE PROCEDURE proc_revoke_privilege
(user_name IN NVARCHAR2,
p_table IN NVARCHAR2,
privilege IN NVARCHAR2)IS

tmp_query VARCHAR(150);
BEGIN
    tmp_query := 'REVOKE '||PRIVILEGE||' ON '||P_TABLE||' FROM '|| user_name;
    
    EXECUTE IMMEDIATE ( tmp_query );
END;

-- Grant role
create or replace PROCEDURE proc_grant_role
 (user_name IN VARCHAR2, role_name IN VARCHAR2)
IS
    tmp_query VARCHAR(150);
BEGIN
    tmp_query := 'GRANT ' || role_name || ' TO ' || user_name;
    EXECUTE IMMEDIATE ( tmp_query );
END;

-- Revoke role
create or replace PROCEDURE proc_revoke_role
 (user_name IN VARCHAR2, role_name IN VARCHAR2)
IS
    tmp_query VARCHAR(150);
BEGIN
    tmp_query := 'revoke ' || role_name || ' from ' || user_name;
    EXECUTE IMMEDIATE ( tmp_query );
END;

-- ROLE
--Procedure xem quy?n c?a role tr�n c�c ??i t??ng d? li?u, h�m n�y tr? v? 1 con tr? tham chi?u ??n b?ng k?t qu? trong h�m
/*
create or replace procedure soytex.View_Role_Privileges(rlt_tab out sys_refcursor)
is
begin
    open rlt_tab for
        select ROLE_TAB_PRIVS.role as "Nh�m ng??i d�ng", table_name as "T�n b?ng", column_name as "T�n c?t", privilege "Quy?n"
        from ROLE_TAB_PRIVS join DBA_ROLES on ROLE_TAB_PRIVS.role = DBA_ROLES.role
        where DBA_ROLES.oracle_maintained = 'N';
end;
*/

--ch?y th? h�m
--    variable rlt_tab refcursor;
--    execute View_Role_Privileges(:rlt_tab);
--    print rlt_tab;


--Procedure t?o role t�n l� role_name v� _identity: ???c x? l� ? ph?n giao di?n
--  _identity = 'not identified' if no indentity else 'identified by ' || identity_mode(password, schema, externally, ...)
create or replace procedure Create_Role(role_name in varchar2, identity_mode in varchar2)
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

--VD n?u t?o role t�n l� 'c##role01' m� kh�ng c� h�nh th?c ??nh danh
----execute Create_Role('c##role01', '');
----ho?c execute Create_Role('c##role01', 'not identified');
--VD2: n?u t?o role t�n l� 'c##role02; c� h�nh th?c ??nh danh l� m?t kh?u vs pass l� 'abc@123'
----execute Create_Role('c##role02', 'identified by abc@123');

--Procedure ch?nh s?a role t�n l� role_name v� _identity: ???c x? l� ? ph?n giao di?n
--  _identity = 'not identified' if no indentity else 'identified by ' || identity_mode(password, schema, ...)
--Note: Ph�p alter kh�ng c� ??i t�n cho role
create or replace procedure Alter_Role(role_name in varchar2, identity_mode in varchar2)
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

--VD n?u trong h? th?ng c� role 'c##role01', mu?n ??i sang h�nh th?c ??nh danh l� h? ?i?u h�nh ho?c ph?n m?m b�n th? 3
----execute Alter_Role('c##role01', 'identified externally');

--Procudure x�a 1 role c� t�n role_name
create or replace procedure Drop_Role(role_name in varchar2)
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

--c�i n�y ??a v� d? l� hi?u li?n kh�ng c?n gi?i th�ch nhi?u
----execute Drop_Role('c##role01');

--Procedure c?p quy?n priv_name tr�n ??i t??ng d? li?u obj cho role_name
create or replace procedure Grant_Privs_To_Role(role_name in varchar2, privs_name in varchar2, obj in varchar2)
is
begin
    execute immediate 'grant ' || privs_name || ' on ' || obj || ' to ' || role_name;
end;
/

--Gi? s? ta mu?n g�n cho role 'c##role01' quy?n select tr�n b?ng 'TAB01'
----execute Grant_Privs_To_Role(role_name => 'c##role01', privs_name => 'select', obj => 'TAB01');

--N?u ta mu?n g�n cho role 'c##role02' quy?n update tr�n c?t col1, col2 tr�n b?ng 'TAB02'
----execute Grant_Privs_To_Role(role_name => 'c##role02', privs_name => 'update(col1, col2)', obj => 'TAB02');

--Procedure tru?t quy?n priv_name tr�n ??i t??ng d? li?u obj ra kh?i role_name
create or replace procedure Revoke_Role_Privs(role_name in varchar2, priv_name in varchar2, obj in varchar2)
is
begin
    execute immediate 'revoke ' || priv_name || ' on ' || obj || ' from ' || role_name;
end;
/