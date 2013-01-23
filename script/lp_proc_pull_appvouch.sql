go
if exists ( select * from sysobjects where xtype = 'P' and name = 'lp_proc_pull_appvouch')
	drop proc lp_proc_pull_appvouch 
go
go
	create proc lp_proc_pull_appvouch
	as
	begin  
		select cSoCode,count(cSoAutoID) cnt
		into #lp_proc_pull_appvouch_tmp1 
		from lp_pu_appvouchs
		group by cSoCode

		select so_sodetails.cSoCode,count(autoid) cnt 
		into #lp_proc_pull_appvouch_tmp2
		from so_sodetails,so_somain 
		where so_sodetails.csocode=so_somain.csocode 
		and len(so_somain.cVerifier)<>0
		group by so_sodetails.cSoCode

		select tmp2.csocode into #lp_proc_pull_appvouch_tmp3
		from #lp_proc_pull_appvouch_tmp2 tmp2
		left join #lp_proc_pull_appvouch_tmp1 tmp1 on tmp2.csocode=tmp1.csocode
		where tmp2.cnt-isnull(tmp1.cnt,0)>0

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
where len(cVerifier)<>0 and somain.csocode in(select csocode from #lp_proc_pull_appvouch_tmp3)
	end 
go