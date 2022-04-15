--Procedure xem quyền của role trên các đối tượng dữ liệu, hàm này trả về 1 con trỏ tham chiếu đến bảng kết quả trong hàm
create or replace procedure View_Role_Privileges(rlt_tab out sys_refcursor)
is
begin
    open rlt_tab for
        select ROLE_TAB_PRIVS.role as "Nhóm người dùng", table_name as "Tên bảng", column_name as "Tên cột", privilege "Quyền"
        from ROLE_TAB_PRIVS join DBA_ROLES on ROLE_TAB_PRIVS.role = DBA_ROLES.role
        where DBA_ROLES.oracle_maintained = 'N';
end;
/

--chạy thử hàm
    variable rlt_tab refcursor;
    execute View_Role_Privileges(:rlt_tab);
    print rlt_tab;


--Procedure tạo role tên là role_name và _identity: được xử lý ở phần giao diện
--  _identity = 'not identified' if no indentity else 'identified by ' || identity_mode(password, schema, externally, ...)
create or replace procedure Create_Role(role_name in varchar2, identity_mode in varchar2)
is
begin
    execute immediate 'create role ' || role_name || ' ' || identity_mode;
end;
/

--VD nếu tạo role tên là 'c##role01' mà không có hình thức định danh
execute Create_Role('c##role01', '');
--hoặc execute Create_Role('c##role01', 'not identified');
--VD2: nếu tạo role tên là 'c##role02; có hình thức định danh là mật khẩu vs pass là 'abc@123'
execute Create_Role('c##role02', 'identified by abc@123');

--Procedure chỉnh sửa role tên là role_name và _identity: được xử lý ở phần giao diện
--  _identity = 'not identified' if no indentity else 'identified by ' || identity_mode(password, schema, ...)
--Note: Phép alter không có đổi tên cho role
create or replace procedure Alter_Role(role_name in varchar2, identity_mode in varchar2)
is
begin
    execute immediate 'alter role ' || role_name || ' ' || identity_mode;
end;
/

--VD nếu trong hệ thống có role 'c##role01', muốn đổi sang hình thức định danh là hệ điều hành hoặc phần mềm bên thứ 3
execute Alter_Role('c##role01', 'identified externally');

--Procudure xóa 1 role có tên role_name
create or replace procedure Drop_Role(role_name in varchar2)
is
begin
    execute immediate 'drop role ' || role_name;
end;
/

--cái này đưa ví dụ là hiểu liền không cần giải thích nhiều
execute Drop_Role('c##role01');

--Procedure cấp quyền priv_name trên đối tượng dữ liệu obj cho role_name
create or replace procedure Grant_Privs_To_Role(role_name in varchar2, privs_name in varchar2, obj in varchar2)
is
begin
    execute immediate 'grant ' || privs_name || ' on ' || obj || ' to ' || role_name;
end;
/

--Giả sử ta muốn gán cho role 'c##role01' quyền select trên bảng 'TAB01'
execute Grant_Privs_To_Role(role_name => 'c##role01', privs_name => 'select', obj => 'TAB01');

--Nếu ta muốn gán cho role 'c##role02' quyền update trên cột col1, col2 trên bảng 'TAB02'
execute Grant_Privs_To_Role(role_name => 'c##role02', privs_name => 'update(col1, col2)', obj => 'TAB02');

--Procedure truất quyền priv_name trên đối tượng dữ liệu obj ra khỏi role_name
create or replace procedure Revoke_Role_Privs(role_name in varchar2, priv_name in varchar2, obj in varchar2)
is
begin
    execute immediate 'revoke ' || priv_name || ' on ' || obj || ' from ' || role_name;
end;
/

--Cái này tương tự vụ grant role thôi, ví dụ thì cũng tương tự cái kia