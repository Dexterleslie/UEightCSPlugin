go
if exists ( select * from sysobjects where xtype = 'TR' and name = 'lp_trigger_pu_appvouch_unverify')
	drop trigger lp_trigger_pu_appvouch_unverify 
go
go
	create trigger lp_trigger_pu_appvouch_unverify
	on lp_pu_appvouch
	after update 
	as 
	begin
	Set NoCount ON
	--≈–∂œ «∑Ò…Û∫À
	   declare @testMsg nvarchar(1000)
		if update(cAuditor ) or update (dAuditDate)
		begin
			declare @cVerifier nvarchar(100)
			declare @dVerifyDate nvarchar(100)
			declare @errMsg nvarchar(2000)
			declare @cCode varchar(255)
			
			select @cVerifier =cAuditor, @dVerifyDate = dAuditDate,@cCode=cCode from inserted
			
		--∆˙…Û∫À
			if (@cVerifier is null or len(@cVerifier) =0) or (@dVerifyDate is null or len(@dVerifyDate) =0)
			begin
				
				declare @cPoCode varchar(255)
				declare @ID varchar(255)
				select @cPoCode=cCode from pu_appvouch where cdefine1=@cCode and len(cVerifier)<>0
				select @ID=ID from pu_appvouch where cdefine1=@cCode
				if @cPoCode is not null
				begin
					set @errMsg = 'LP«Îπ∫µ•['+@cCode+']±ª«Îπ∫µ•['+@cPoCode+']“˝”√£¨≤ªƒ‹πª∆˙…Û'
					raiserror(@errMsg,16,6)
				end
				else
				begin
					declare @okay1 bit
					declare @okay2 bit
					begin tran tran1 
					delete from pu_appvouchs where ID=@ID
					if @@error<>0
						set @okay1=0
					else 
						set @okay1=1
					delete from pu_appvouch where ID=@ID
					if @@error<>0
						set @okay2=0
					else 
						set @okay2=1
					if @okay1=1 and @okay2=1
						commit tran tran1
					else
						rollback tran tran1
					
				end
			end
		end	
		Set NoCount off
	end
go



