go
if exists ( select * from sysobjects where xtype = 'P' and name = 'lp_proc_pull_appvouch')
	drop proc lp_proc_pull_appvouch 
go
go
	create proc lp_proc_pull_appvouch
	as
	begin 
		select 
convert(bit,0) as 选择,
ID,
csocode as 销售订单号,
saletype.cstcode as 销售类型编码,
cstname as 销售类型,
customer.ccuscode as 客户编码,
customer.ccusname as 客户,
department.cdepcode as 销售部门编码,
cdepname as 销售部门,
person.cpersoncode as 业务员编码,
cpersonname as 业务员,
ddate as 单据日期,
cexch_name as 币种,
iexchrate as 汇率,
itaxrate as 税率,
convert(nchar,convert(money,ufts),2) as ufts
from so_somain somain
left join saletype saletype on somain.cstcode = saletype.cstcode
left join customer customer on somain.ccuscode = customer.ccuscode
left join department department on somain.cdepcode = department.cdepcode
left join person person on somain.cpersoncode = person.cpersoncode
where len(cVerifier)<>0
	end 
go