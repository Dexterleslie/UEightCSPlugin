go
if exists ( select * from sysobjects where xtype = 'TR' and name = 'u8_trigger_so_somain_unverify')
	drop trigger u8_trigger_so_somain_unverify 
go
go
	create trigger u8_trigger_so_somain_unverify
	on so_somain
	after update 
	as 
	begin
	Set NoCount ON
	--判断是否审核
	   declare @testMsg nvarchar(1000)
		if update(cVerifier ) or update (dverifydate)
		begin
			declare @cVerifier nvarchar(100)
			declare @dVerifyDate nvarchar(100)
			declare @errMsg nvarchar(2000)
			declare @cCode varchar(255)
			
			select @cVerifier =cVerifier, @dVerifyDate = dverifydate,@cCode=cSoCode from inserted
			
		--弃审核
			if (@cVerifier is null or len(@cVerifier) =0) or (@dVerifyDate is null or len(@dVerifyDate) =0)
			begin
				
				declare @cLPCode varchar(255)
				declare @ID varchar(255)
				
				select distinct @ID=vouch.lpvouchpk,@cLPCode=vouch.cCode from lp_pu_appvouchs vouchs,lp_pu_appvouch vouch
				where  vouchs.lpvouchpk = vouch.lpvouchpk and cSoCode=@cCode 
				and len(vouch.cAuditor)<>0
				--select @ID=ID from pu_appvouch where cdefine1=@cCode
				--raiserror(@ID,16,6)
				--return
				if @cLPCode is not null
				begin
					set @errMsg = '销售订单['+@cCode+']被LP请购单['+@cLPCode+']引用，不能够弃审'
					raiserror(@errMsg,16,6)
				end
				/*else
				begin
					declare @okay1 bit
					declare @okay2 bit
					begin tran tran1 
					delete from lp_pu_appvouchs where lpvouchpk=@ID
					if @@error<>0
						set @okay1=0
					else 
						set @okay1=1
					delete from lp_pu_appvouch where lpvouchpk=@ID
					if @@error<>0
						set @okay2=0
					else 
						set @okay2=1
					if @okay1=1 and @okay2=1
						commit tran tran1
					else
						rollback tran tran1
					
				end*/
			end
		end	
		Set NoCount off
	end
go



