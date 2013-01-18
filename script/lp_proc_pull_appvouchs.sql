go
if exists ( select * from sysobjects where xtype = 'P' and name = 'lp_proc_pull_appvouchs')
	drop proc lp_proc_pull_appvouchs
go
go
	create proc lp_proc_pull_appvouchs
	@cSoCode varchar(255)
	as
	begin 
		select 
convert(bit,1) as ѡ��,
ID,
autoid,
sodetail.csocode ���۶�����,
inv.cinvcode �������,
inv.cinvname ���,
inv.cInvStd ����ͺ�,
unit.ccomunitcode ��������λ����,
unit.ccomunitname ��������λ,
dpredate Ԥ��������,
iquantity ����,
--iquotedprice ����,
--itaxunitprice ԭ�Һ�˰����,
--iunitprice ԭ����˰����,
--imoney ԭ����˰���,
--itax ԭ��˰��,
--isum ԭ�Ҽ�˰�ϼ�,
--inatunitprice ������˰����,
--inatmoney ������˰���,
--inattax ����˰��,
--inatsum ���Ҽ�˰�ϼ�,
sodetail.itaxrate ˰��
from so_sodetails sodetail
left join inventory inv on sodetail.cinvcode = inv.cinvcode
left join computationunit unit on inv.ccomunitcode = unit.ccomunitcode
where csocode = @cSoCode and sodetail.autoid not in (select csoautoid from lp_pu_appvouchs)
	end 
go