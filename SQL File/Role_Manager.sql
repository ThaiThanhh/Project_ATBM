--Procedure xem quyền của role trên các đối tượng dữ liệu
create or replace procedure View_Role_Privileges
is
begin
    select ROLE_TAB_PRIVS.role as "Nhóm người dùng", table_name as "Tên bảng", column_name as "Tên cột", privilege "Quyền"
    from ROLE_TAB_PRIVS join DBA_ROLES on ROLE_TAB_PRIVS.role = DBA_ROLES.role
    where DBA_ROLES.oracle_maintained = 'N';
end;
/

--Procedure tạo role tên là role_name
create or replace procedure Create_Role(role_name in varchar2)
is
begin
    execute immediate 'create role ' || role_name;
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