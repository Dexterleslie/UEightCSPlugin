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
convert(bit,1) as 选择,
ID,
autoid,
sodetail.csocode 销售订单号,
inv.cinvcode 存货编码,
inv.cinvname 存货,
inv.cInvStd 规格型号,
unit.ccomunitcode 主计量单位编码,
unit.ccomunitname 主计量单位,
dpredate 预发货日期,
iquantity 数量,
--iquotedprice 报价,
--itaxunitprice 原币含税单价,
--iunitprice 原币无税单价,
--imoney 原币无税金额,
--itax 原币税额,
--isum 原币价税合计,
--inatunitprice 本币无税单价,
--inatmoney 本币无税金额,
--inattax 本币税额,
--inatsum 本币价税合计,
sodetail.itaxrate 税率
from so_sodetails sodetail
left join inventory inv on sodetail.cinvcode = inv.cinvcode
left join computationunit unit on inv.ccomunitcode = unit.ccomunitcode
where csocode = @cSoCode and sodetail.autoid not in (select csoautoid from lp_pu_appvouchs)
	end 
go