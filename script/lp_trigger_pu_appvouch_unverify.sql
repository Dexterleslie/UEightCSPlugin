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
				select @cPoCode=cCode from pu_appvouch where cdefine1=@cCode
				
				if @cPoCode is not null
				begin
					set @errMsg = 'LP«Îπ∫µ•['+@cCode+']±ª«Îπ∫µ•['+@cPoCode+']“˝”√£¨≤ªƒ‹πª∆˙…Û'
					raiserror(@errMsg,16,6)
				end
			end
		end	
		Set NoCount off
	end
go



