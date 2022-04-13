--Procedure xem quyền của role trên các đối tượng dữ liệu
create or replace procedure View_Role_Privileges(rlt_tab out sys_refcursor)
is
begin
    open rlt_tab for
        select ROLE_TAB_PRIVS.role as "Nhóm người dùng", table_name as "Tên bảng", column_name as "Tên cột", privilege "Quyền"
        from ROLE_TAB_PRIVS join DBA_ROLES on ROLE_TAB_PRIVS.role = DBA_ROLES.role
        where DBA_ROLES.oracle_maintained = 'N';
end;
/

--Procedure tạo role tên là role_name và _identity: được xử lý ở phần giao diện
--  _identity = 'not identified' if no indentity else 'identified by ' || identity_mode(password, schema, externally, ...)
create or replace procedure Create_Role(role_name in varchar2, identity_mode in varchar2)
is
    role_name_existed exception;
    n_row_existed int;
begin
    select count(*) into n_row_existed
    from DBA_ROLES
    where role = role_name;
    
    if n_row_existed != 0 then 
        raise role_name_existed;
    end if;

    execute immediate 'create role ' || role_name || ' ' || identity_mode;
end;
/

--Procedure chỉnh sửa role tên là role_name và _identity: được xử lý ở phần giao diện
--  _identity = 'not identified' if no indentity else 'identified by ' || identity_mode(password, schema, ...)
--Note: Phép alter không có đổi tên cho role
create or replace procedure Alter_Role(role_name in varchar2, identity_mode in varchar2)
is
begin
    execute immediate 'alter role ' || role_name || ' ' || identity_mode;
end;
/

--Procudure xóa 1 role có tên role_name
create or replace procedure Drop_Role(role_name in varchar2)
is
begin
    execute immediate 'drop role ' || role_name;
end;
/

--Procedure cấp quyền priv_name trên đối tượng dữ liệu obj ra khỏi role_name
create or replace procedure Grant_Privs_To_Role(role_name in varchar2, privs_name in varchar2, obj in varchar2)
is
begin
    execute immediate 'grant ' || privs_name || ' on ' || obj || ' to ' || role_name;
end;
/

--Procedure truất quyền priv_name trên đối tượng dữ liệu obj ra khỏi role_name
create or replace procedure Revoke_Role_Privs(role_name in varchar2, priv_name in varchar2, obj in varchar2)
is
begin
    execute immediate 'revoke ' || priv_name || ' on ' || obj || ' from ' || role_name;
end;
/