alter pluggable database all open;
alter pluggable database pdb1 save state;

ALTER USER LBACSYS ACCOUNT UNLOCK IDENTIFIED BY 1234;

conn sys/5906341@//localhost:1521/ols_demo as sysdba;

EXEC LBACSYS.CONFIGURE_OLS;
EXEC LBACSYS.OLS_ENFORCEMENT.ENABLE_OLS;

SELECT STATUS FROM DBA_OLS_STATUS WHERE NAME = 'OLS_CONFIGURE_STATUS';
SELECT VALUE FROM V$OPTION WHERE PARAMETER = 'Oracle Label Security';

--Tao table
alter session set "_ORACLE_SCRIPT" = true;
drop user soytex cascade;
--drop user soytex cascade;
create user soytex identified by admin1;
grant DBA, connect, SELECT_CATALOG_ROLE to soytex;
ALTER USER soytex quota unlimited on USERS;

--
CONN lbacsys/1234@//localhost:1521/ols_demo;

--drop Policy
EXEC SA_SYSDBA.DROP_POLICY ('noti_ols_pol',true);
--Tao Policy
exec SA_SYSDBA.CREATE_POLICY (policy_name => 'noti_ols_pol', column_name => 'NOTI_OLS_COLUMN');
--Gan quyen cho user SoYTeX
grant noti_ols_pol_DBA to soytex;
grant execute on SA_COMPONENTS TO soytex;
grant execute on SA_LABEL_ADMIN TO soytex;
grant execute on SA_POLICY_ADMIN TO soytex;
grant execute on SA_USER_ADMIN TO soytex;
grant execute on CHAR_TO_LABEL TO soytex;

GRANT LBAC_DBA TO soytex;
GRANT EXECUTE ON sa_sysdba TO soytex;
GRANT EXECUTE ON to_lbac_data_label TO soytex;

--
connect soytex/admin1@//localhost:1521/ols_demo;

--Tao levels
Exec SA_COMPONENTS.CREATE_LEVEL(policy_name => 'noti_ols_pol', level_num => 10, short_name => 'BS', long_name => 'Bac_si');
Exec SA_COMPONENTS.CREATE_LEVEL(policy_name => 'noti_ols_pol', level_num => 20, short_name => 'GDCSYT', long_name => 'Giam_doc_co_so_y_te');
Exec SA_COMPONENTS.CREATE_LEVEL(policy_name => 'noti_ols_pol', level_num => 30, short_name => 'GDSYT', long_name => 'Giam_doc_so_y_te');

--Tao compartnent
Exec SA_COMPONENTS.CREATE_COMPARTMENT(policy_name => 'noti_ols_pol',comp_num =>40, short_name =>'DTNgT', long_name =>'Dieu_tri_ngoai_tru');
Exec SA_COMPONENTS.CREATE_COMPARTMENT(policy_name => 'noti_ols_pol',comp_num =>50, short_name => 'DTNT', long_name => 'Dieu_tri_noi_tru');
Exec SA_COMPONENTS.CREATE_COMPARTMENT(policy_name => 'noti_ols_pol',comp_num =>60, short_name =>'DTCS',long_name => 'Dieu_tri_chuyen_sau');

--Tao group
Exec SA_COMPONENTS.CREATE_GROUP(policy_name => 'noti_ols_pol',group_num => 140,short_name=> 'TT',long_name=> 'Trung_tam');
Exec SA_COMPONENTS.CREATE_GROUP(policy_name => 'noti_ols_pol',group_num => 120, short_name => 'CTT', long_name => 'Can_trung_tam');
Exec SA_COMPONENTS.CREATE_GROUP(policy_name => 'noti_ols_pol',group_num => 100, short_name => 'NT', long_name => 'Ngoai_thanh');

-----
EXECUTE SA_USER_ADMIN.SET_USER_PRIVS('noti_ols_pol','soytex','FULL,PROFILE_ACCESS');

--drop table soytex.THONGBAO;
create table soytex.THONGBAO
(
    MaThongBao varchar2(15) primary key,
    NoiDung nvarchar2(150),
    NgayGio nvarchar2(50),
    DiaDiem nvarchar2(150),
    TuyenDieuTri nvarchar2(50),
    Vung nvarchar2(50),
    CapBac nvarchar2(50)
);


insert into soytex.THONGBAO values('TB01', 'Noi dung 1', '10:00 27/05/2022', 'Binh Thanh', 'Dieu tri ngoai tru', 'Trung tam', 'Bac si');
insert into soytex.THONGBAO values('TB02', 'Noi dung 2', '10:00 27/05/2022', 'Binh Thanh', 'Dieu tri ngoai tru', 'Can trung tam', 'Bac si');
insert into soytex.THONGBAO values('TB03', 'Noi dung 3', '10:00 27/05/2022', 'Binh Thanh', 'Dieu tri ngoai tru', 'Ngoai thanh', 'Bac si');
insert into soytex.THONGBAO values('TB04', 'Noi dung 4', '10:00 27/05/2022', 'Binh Thanh', 'Dieu tri noi tru', 'Trung tam', 'Bac si');
insert into soytex.THONGBAO values('TB05', 'Noi dung 5', '10:00 27/05/2022', 'Binh Thanh', 'Dieu tri noi tru', 'Can trung tam', 'Bac si');
insert into soytex.THONGBAO values('TB06', 'Noi dung 6', '10:00 27/05/2022', 'Binh Thanh', 'Dieu tri noi tru', 'Ngoai thanh', 'Bac si');
insert into soytex.THONGBAO values('TB07', 'Noi dung 7', '10:00 27/05/2022', 'Binh Thanh', 'Dieu tri chuyen sau', 'Trung tam', 'Bac si');
insert into soytex.THONGBAO values('TB08', 'Noi dung 8', '10:00 27/05/2022', 'Binh Thanh', 'Dieu tri chuyen sau', 'Can trung tam', 'Bac si');
insert into soytex.THONGBAO values('TB09', 'Noi dung 9', '10:00 27/05/2022', 'Binh Thanh', 'Dieu tri chuyen sau', 'Ngoai thanh', 'GDCSYT');
insert into soytex.THONGBAO values('TB10', 'Noi dung 10', '10:00 27/05/2022', 'Binh Thanh', 'Dieu tri noi tru', 'Trung tam', 'GDCSYT');
insert into soytex.THONGBAO values('TB11', 'Noi dung 11', '10:00 27/05/2022', 'Binh Thanh', 'Dieu tri noi tru', 'Trung tam', 'GDSYT');

--Tao labels
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>300, label_value => 'BS:DTNgT:NT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>310, label_value => 'BS:DTNT:NT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>320, label_value => 'BS:DTCS:NT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>330, label_value => 'BS:DTNgT:CTT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>340, label_value => 'BS:DTNT:CTT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>350, label_value => 'BS:DTCS:CTT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>360, label_value => 'BS:DTNgT:TT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>370, label_value => 'BS:DTNT:TT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>380, label_value => 'BS:DTCS:TT');

execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>410, label_value => 'GDCSYT:DTNgT:NT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>420, label_value => 'GDCSYT:DTNgT:CTT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>430, label_value => 'GDCSYT:DTNgT:TT');

execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>440, label_value => 'GDCSYT:DTNT:NT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>450, label_value => 'GDCSYT:DTNT:CTT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>460, label_value => 'GDCSYT:DTNT:TT');

execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>470, label_value => 'GDCSYT:DTCS:NT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>480, label_value => 'GDCSYT:DTCS:CTT');
execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>490, label_value => 'GDCSYT:DTCS:TT');

execute SA_LABEL_ADMIN.CREATE_LABEL(policy_name =>'noti_ols_pol',label_tag =>500, label_value => 'GDSYT:DTNgT,DTNT,DTCS:NT,CTT,TT');

--Gan chinh sach cho table
Exec SA_POLICY_ADMIN.APPLY_TABLE_POLICY(policy_name=> 'noti_ols_pol',schema_name=> 'soytex',table_name=> 'THONGBAO', table_options  => 'READ_CONTROL');

--GAN NHAN CHO DONG DU LIEU
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'BS:DTNT:NT') where
    TuyenDieuTri = 'Dieu tri noi tru' and Vung = 'Ngoai thanh' and CapBac = 'Bac si';
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'BS:DTCS:NT') where
    TuyenDieuTri = 'Dieu tri chuyen sau' and Vung = 'Ngoai thanh' and CapBac = 'Bac si';
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'BS:DTNgT:NT') where
    TuyenDieuTri = 'Dieu tri ngoai tru' and Vung = 'Ngoai thanh' and CapBac = 'Bac si';
    
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'BS:DTNT:CTT') where
    TuyenDieuTri = 'Dieu tri noi tru' and Vung = 'Can trung tam' and CapBac = 'Bac si';
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'BS:DTCS:CTT') where
    TuyenDieuTri = 'Dieu tri chuyen sau' and Vung = 'Can trung tam' and CapBac = 'Bac si';
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'BS:DTNgT:CTT') where
    TuyenDieuTri = 'Dieu tri ngoai tru' and Vung = 'Can trung tam' and CapBac = 'Bac si';
    
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'BS:DTNT:TT') where
    TuyenDieuTri = 'Dieu tri noi tru' and Vung = 'Trung tam' and CapBac = 'Bac si';
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'BS:DTCS:TT') where
    TuyenDieuTri = 'Dieu tri chuyen sau' and Vung = 'Trung tam' and CapBac = 'Bac si';
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'BS:DTNgT:TT') where
    TuyenDieuTri = 'Dieu tri ngoai tru' and Vung = 'Trung tam' and CapBac = 'Bac si';
    
---
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'GDCSYT:DTNgT:NT') where
    TuyenDieuTri = 'Dieu tri ngoai tru' and Vung = 'Ngoai thanh' and CapBac = 'GDCSYT';
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'GDCSYT:DTNgT:CTT') where
    TuyenDieuTri = 'Dieu tri ngoai tru' and Vung = 'Can trung tam' and CapBac = 'GDCSYT' ;
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'GDCSYT:DTNgT:TT') where
    TuyenDieuTri = 'Dieu tri ngoai tru' and Vung = 'Trung tam' and CapBac = 'GDCSYT';
    
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'GDCSYT:DTNT:NT') where
    TuyenDieuTri = 'Dieu tri noi tru' and Vung = 'Ngoai thanh' and CapBac = 'GDCSYT';
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'GDCSYT:DTNT:CTT') where
    TuyenDieuTri = 'Dieu tri noi tru' and Vung = 'Can trung tam' and CapBac = 'GDCSYT' ;
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'GDCSYT:DTNT:TT') where
    TuyenDieuTri = 'Dieu tri noi tru' and Vung = 'Trung tam' and CapBac = 'GDCSYT';
    
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'GDCSYT:DTCS:NT') where
    TuyenDieuTri = 'Dieu tri chuyen sau' and Vung = 'Ngoai thanh' and CapBac = 'GDCSYT';
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'GDCSYT:DTCS:CTT') where
    TuyenDieuTri = 'Dieu tri chuyen sau' and Vung = 'Can trung tam' and CapBac = 'GDCSYT' ;
Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'GDCSYT:DTCS:TT') where
    TuyenDieuTri = 'Dieu tri chuyen sau' and Vung = 'Trung tam' and CapBac = 'GDCSYT';

Update soytex.THONGBAO SET noti_ols_column = char_to_label('noti_ols_pol', 'GDSYT:DTNgT,DTNT,DTCS:NT,CTT,TT') where CapBac = 'GDSYT';

--Tao user bac si, giam doc, so giam doc
create user BACSI_1 identified by 1;
create user BACSI_2 identified by 1;
create user BACSI_3 identified by 1;
create user GDCSYT_1 identified by 1;
create user GDCSYT_2 identified by 1;
CREATE USER GDSYT identified by 1;

GRANT CREATE SESSION TO BACSI_1, BACSI_2, BACSI_3, GDCSYT_1, GDCSYT_2, GDSYT;
GRANT SELECT ON soytex.THONGBAO TO BACSI_1, BACSI_2, BACSI_3, GDCSYT_1, GDCSYT_2, GDSYT;
--
EXEC SA_USER_ADMIN.SET_USER_LABELS ('noti_ols_pol','BACSI_1','BS:DTNT:TT');
EXEC SA_USER_ADMIN.SET_USER_LABELS ('noti_ols_pol','BACSI_2','BS:DTNgT:CTT');
EXEC SA_USER_ADMIN.SET_USER_LABELS ('noti_ols_pol','BACSI_3','BS:DTCS:TT');

EXEC SA_USER_ADMIN.SET_USER_LABELS ('noti_ols_pol','GDCSYT_1','GDCSYT:DTNgT:TT');
EXEC SA_USER_ADMIN.SET_USER_LABELS ('noti_ols_pol','GDCSYT_2','GDCSYT:DTCS:TT');

EXEC SA_USER_ADMIN.SET_USER_LABELS ('noti_ols_pol','GDSYT','GDSYT:DTNgT,DTNT,DTCS:NT,CTT,TT');

alter session set "_ORACLE_SCRIPT" = false;

conn BACSI_1/1@//localhost:1521/ols_demo;
select mathongbao from soytex.thongbao;
