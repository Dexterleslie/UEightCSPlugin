go
if exists ( select * from sysobjects where xtype = 'P' and name = 'lp_proc_pull_appvouch')
	drop proc lp_proc_pull_appvouch 
go
go
	create proc lp_proc_pull_appvouch
	as
	begin 
		select 
convert(bit,0) as ѡ��,
ID,
csocode as ���۶�����,
saletype.cstcode as �������ͱ���,
cstname as ��������,
customer.ccuscode as �ͻ�����,
customer.ccusname as �ͻ�,
department.cdepcode as ���۲��ű���,
cdepname as ���۲���,
person.cpersoncode as ҵ��Ա����,
cpersonname as ҵ��Ա,
ddate as ��������,
cexch_name as ����,
iexchrate as ����,
itaxrate as ˰��,
convert(nchar,convert(money,ufts),2) as ufts
from so_somain somain
left join saletype saletype on somain.cstcode = saletype.cstcode
left join customer customer on somain.ccuscode = customer.ccuscode
left join department department on somain.cdepcode = department.cdepcode
left join person person on somain.cpersoncode = person.cpersoncode
where len(cVerifier)<>0
	end 
go