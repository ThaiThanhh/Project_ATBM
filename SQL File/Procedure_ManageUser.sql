--Them user
CREATE OR REPLACE PROCEDURE proc_add_user
(user_name IN VARCHAR2 , u_password IN VARCHAR2 )
IS
    tmp_query VARCHAR(150);
BEGIN
    tmp_query := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE ( tmp_query );
    
    tmp_query := 'create user ' || user_name || ' identified by ' || u_password;
    EXECUTE IMMEDIATE ( tmp_query );
END;
--Xoa User

create or replace NONEDITIONABLE PROCEDURE proc_drop_user
 (user_name IN VARCHAR2)
IS
    tmp_query VARCHAR(150);
BEGIN
    tmp_query := 'alter session set "_ORACLE_SCRIPT"=true';
    EXECUTE IMMEDIATE ( tmp_query );
    tmp_query := 'drop user ' || user_name;
    EXECUTE IMMEDIATE ( tmp_query );
END;
--Tim kiem user
CREATE OR REPLACE PROCEDURE proc_search_user
 (user_name IN VARCHAR2)
IS
    p_user SYS_REFCURSOR;
BEGIN
    OPEN p_user FOR
    SELECT username, user_id, account_status, lock_date, expiry_date, created, authentication_type, 
    default_tablespace FROM dba_users WHERE INSTR(USERNAME, user_name) !=0 ;
    DBMS_SQL.RETURN_RESULT(p_user);
END;

--Thong tin quyen cua user
CREATE OR REPLACE PROCEDURE proc_privs_information
(user_name IN NVARCHAR2)IS
C1 SYS_REFCURSOR;
BEGIN
    OPEN C1 FOR
    select * from dba_tab_privs where grantee = ''|| user_name ||'';
    DBMS_SQL.RETURN_RESULT(C1);   
END;


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
-- Revoke role
create or replace PROCEDURE proc_revoke_role
 (user_name IN VARCHAR2, role_name IN VARCHAR2)
IS
    tmp_query VARCHAR(150);
BEGIN
    tmp_query := 'revoke ' || role_name || ' from ' || user_name;
    EXECUTE IMMEDIATE ( tmp_query );
END;
