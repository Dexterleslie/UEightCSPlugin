go
if exists ( select * from sysobjects where xtype = 'TR' and name = 'lp_trigger_pu_appvouch_verify')
	drop trigger lp_trigger_pu_appvouch_verify 
go
go
create trigger lp_trigger_pu_appvouch_verify 
on lp_pu_appVouch
for update 
as
	begin
		set nocount on 
		--raiserror('ddd',16,6)
		--判断是否审核
		if update(cAuditor ) or update (dAuditDate) --or update(cChangeVerifier)
		begin
			--raiserror( '00' ,16,6)
			declare @okay1 bit
			set @okay1 = 1
			declare @okay2 bit
			set @okay2 = 1
			--帐套ID
			declare @cAccID nvarchar(100) 
			select @cAccID = db_name();
			select @cAccID=substring(@cAccID,charindex('_',@cAccID)+1,3)
			--print @cAccID
			
			declare @cVerifier nvarchar(100)
			declare @dVerifyDate nvarchar(100)
			declare @cChanger nvarchar(100)
			select @cVerifier =cAuditor, @dVerifyDate = dAuditDate,@cChanger = cMender from inserted
			
			--审核
			if len(@cVerifier)<>0 or len(@dverifydate) <>0
			begin
				if @cChanger is null or len(@cChanger) =0
				begin
				--raiserror(@cAccID,16,6)
				declare @cCode varchar(255)
				declare @cDepCode varchar(255)
				declare @cCusCode varchar(255)
				declare @cPersonCode varchar(255)
				declare @cMemo varchar(255)
				declare @cBusType varchar(255)
				declare @cPTCode varchar(255)
				declare @cDate datetime
				declare @cVenCode varchar(255)
				declare @cExchCode varchar(255)
				declare @nFlat float 
				declare @iTaxRate float
				declare @lpvouchpk varchar(255)
				select @cCode=cCode,@cDepCode=cDepCode,@cCusCode=cCusCode,
				@cPersonCode=cPersonCode,@cMemo=cMemo,@cBusType=cBusType,
				@cPTCode=cPTCode,@cDate=dDate,@cVenCode=cVenCode,@cExchCode=cExchCode,
				@nFlat=nFlat,@iTaxRate=iTaxRate,@lpvouchpk=lpvouchpk from inserted

				--raiserror(@lpvouchpk ,16,6)
				
				declare @cMaxNumber nvarchar(100)
				/*生成生成订单编号*/
				declare @cNumber nvarchar(100)

				select @cNumber=(cNumber+1) From VoucherHistory with (NOLOCK)Where CardNumber='27' and cContent is NULL
				--select (cNumber+1) From VoucherHistory with (NOLOCK)Where CardNumber='MO21' and cContent is NULL
				set @cMaxNumber = @cNumber
				set @cCode = REPLICATE('0',10-LEN(@cNumber))+@cNumber

				if 1=1 --@cSTCode <> '06'
				begin
				
			    /*判断存货是否有BOM*/
			    --declare cursor_soDetails_exists cursor for select cInvCode from so_soDetails where cSoCode= @cSoCode
			    --open cursor_soDetails_exists 
					
			    --close cursor_soDetails_exists
			    --deallocate cursor_soDetails_exists
			    
				--select * from so_soMain
				
				/*生成订单ID*/
				declare @p5 int
				set @p5=4152
				declare @p6 int
				set @p6=4152
				exec sp_GetID @RemoteId=N'00',@cAcc_Id=@cAccID,@cVouchType=N'pu_appvouch',@iAmount=1,@iFatherId=@p5 output,@iChildId=@p6 output
				
				--select @p5, @p6	
				--raiserror(@p5,16,6);
				
			begin tran tran1	
				declare @cExchName varchar(255)
				select @cExchName=cexch_name from foreigncurrency where cexch_code = @cExchCode
				insert into pu_appvouch(cCode,dDate,cDepCode,cPersonCode,
			cPTCode,cBusType,ivtid,ID)
			values(@cCode,getdate(),@cDepCode,@cPersonCode,
			@cPTCode,@cBusType,8171,@p5)
		if @@error <> 0 
			set @okay1 = 0
		/*插入销售订单子记录到生成订单*/
		declare @rowCounter int 
		set @rowCounter =1 
		declare cursor_fetch_sub cursor for 
			select cInvCode,fQuantity,iTaxUnitPrice,cDetailMemo,cSoCode,
			iMoney,iTax,iSum,iPerTaxRate,iNatUnitPrice,
			iNatMoney,iNatTax,iNatSum,iQuotedPrice,cSoID,cSoAutoID 
			from lp_pu_appvouchs where lpvouchpk =@lpvouchpk
		open cursor_fetch_sub
 
		 declare @cInvCode varchar(255)
		declare @fQuantity float 
		declare @iTaxUnitPrice float
		declare @cDetailMemo varchar(255)
		declare @cSoCode varchar(255)
		declare @cInvStd varchar(255)
		declare @cComUnitCode varchar(255)
		declare @iUnitPrice float
		declare @iMoney float 
		declare @iTax float 
		declare @iSum float 
		declare @iPerTaxRate float 
		declare @iNatUnitPrice float
		declare @iNatMoney	float
		declare @iNatTax float
		declare @iNatSum float
		declare @iQuotedPrice float
		declare @cSoID varchar(255)
		declare @cSoAutoID varchar(255)
		 		 
		 fetch next from cursor_fetch_sub into @cInvCode,@fQuantity,@iTaxUnitPrice,
		@cDetailMemo,@cSoCode,@iMoney,@iTax,@iSum,@iPerTaxRate,
		@iNatUnitPrice,@iNatMoney,@iNatTax,@iNatSum,@iQuotedPrice,@cSoID,@cSoAutoID
		 
		 while @@fetch_status =0
		 begin
					declare @p2_5 int
					set @p2_5=9414
					declare @p2_6 int
					set @p2_6=7253
					exec sp_GetID @RemoteId=N'00',@cAcc_Id=@cAccID,@cVouchType=N'pu_appvouchs',@iAmount=1,@iFatherId=@p2_5 output,@iChildId=@p2_6 output
					--select @p2_5, @p2_6
					
					insert into pu_appvouchs(ID,autoid,cInvCode,fQuantity,
					iPerTaxRate) 
					values(@p5,@p2_6,@cInvCode,@fQuantity,@iPerTaxRate)

					fetch next from cursor_fetch_sub into @cInvCode,@fQuantity,@iTaxUnitPrice,
		@cDetailMemo,@cSoCode,@iMoney,@iTax,@iSum,@iPerTaxRate,
		@iNatUnitPrice,@iNatMoney,@iNatTax,@iNatSum,@iQuotedPrice,@cSoID,@cSoAutoID

					if @@error <> 0
						set @okay2=0
					
					set @rowCounter= @rowCounter+1
				end 
				
				close cursor_fetch_sub
				deallocate cursor_fetch_sub
		
				--if @okay1=1
				--	raiserror('ok',16,6)
 
				if @okay1=1 and @okay2=1
				begin
					 update VoucherHistory set cNumber = @cMaxNumber Where CardNumber='27' and cContent is NULL
					 commit tran tran1
					 return ;
				end 
				rollback tran tran1
				return ;
				end
					
			end
			end
		end
		set nocount off
	end 
go




go
	if exists ( select * from sysobjects where xtype = 'TR' and name = 'trigger_sotomomorder_after')
		drop trigger  trigger_sotomomorder_after
go
go	  
	create trigger trigger_sotomomorder_after
	on so_somain 
	after update 
	as 
	begin
	Set NoCount ON
	--判断是否审核
	   declare @testMsg nvarchar(1000)
		if update(cVerifier ) or update (dverifydate )
		begin
			declare @cVerifier nvarchar(100)
			declare @dVerifyDate nvarchar(100)
			declare @cSoCode nvarchar(100)
			declare @autoID nvarchar(100)
			declare @errMsg nvarchar(2000)
			
			select @cVerifier =cVerifier, @dVerifyDate = dVerifyDate,@cSoCode = cSoCode from inserted
			
			declare @cMoOrderCode nvarchar(100) --生产订单编码
			--set @testMsg = @cVerifier +' '+ @dVerifyDate
			--raiserror (@testMsg,16,6)
			--return ;
		--弃审核
			if (@cVerifier is null or len(@cVerifier) =0) or (@dVerifyDate is null or len(@dVerifyDate) =0)
			begin
				--set @testMsg = @cVerifier +'un'+ @dVerifyDate
				--raiserror (@testMsg,16,6)
				--return ;
				--select @cSoCode = cDefine1  from inserted
				--set @testMsg = @cSoCode
				--raiserror (@testMsg,16,6)
				/*判断生产订单是否审核*/
				--if exists (select * from mom_orderdetail where moid = 
				--(select top 1  moid from mom_order where Define1 = @cSoCode)
				--and (RelsDate  is not null or len(RelsDate ) <> 0)
				--)begin
				--	declare @errMsg nvarchar(2000)
				--	set @errMsg = '该销售订单被生产订单客户编号['+@cSoCode+']引用,不能弃审核'
				--	--set @errMsg = '销售订单[]被生成订单引用,不能弃审核'
				--	raiserror (@errMsg,16,6)
				--	return ;
				--end
				declare @flag bit 
				set @flag = 0
				declare cursor_1  cursor for select autoID from so_soDetails where cSoCode = @cSoCode
				
				open   cursor_1
				
				fetch next from cursor_1 into @autoID
				while @@fetch_status =0
				begin 
					if exists (select * from mom_orderdetail where OrderDId = @autoID
					and (RelsDate  is not null or len(RelsDate ) <> 0))
					--if exists(select * from mom_orderdetail where OrderDId = @autoID )
					begin
						set @flag = 1
						select @cMoOrderCode =moCode from mom_order od inner join mom_orderdetail ods on od.moid = ods.moid
						where OrderDId = @autoID
						set @errMsg = '销售订单['+@cSoCode+']被生产订单['+@cMoOrderCode+']引用，不能够弃审'
						raiserror(@errMsg,16,6);
					end
					fetch next from cursor_1 into @autoID
				end 
				
				close cursor_1
				deallocate cursor_1
				
				
				declare @moID nvarchar(100)
				select @moID = moid from mom_order where Define2 = @cSoCode
				--set @testMsg = @moId
				--raiserror (@testMsg,16,6)
				--set @testMsg = '8882'
				--raiserror (@testMsg,16,6)
				--begin tran tran1
				--declare @moid nvarchar(100)
				--set @moid = '4159'
				if @flag <>1
				begin
					delete from mom_morder where moid = @moid
					--select * from mom_morder where moid = 4159
					--delete select * from mom_moallocate where modid in ( select modid from mom_orderdetail where moid=4159)
					
					delete from mom_orderdetail where moid = @moid
					delete from mom_order where moid = @moid
				end
				--rollback tran  tran1
				
				/*判断销售订单是否生成销售发货计划*/
				declare @soCode nvarchar(100)
				select @soCode = cSoCode from inserted
				declare cursor_soDetails_disPlan  cursor for select autoID from so_soDetails where cSoCode = @soCode
				
				open   cursor_soDetails_disPlan
				
				fetch next from cursor_soDetails_disPlan into @autoID
				while @@fetch_status =0
				begin 
					if exists ( select * from js_dispatchlistplan_body where cSaleOrderAutoID=@autoID)
					begin
						/*销售发货计划编*/
						declare @cDisListPlanCode nvarchar(100)
						select	@cDisListPlanCode= cDispatchListPlanCode from 
						js_dispatchlistplan_header header
						inner join js_dispatchlistplan_body body on header.dispatchListPlanID = body.dispatchListPlanID
						where body.cSaleOrderAutoID = @autoID
						set @errMsg = '销售订单['+@soCode+']被发货计划['+@cDisListPlanCode+']引用，不能够弃审'
						raiserror (@errMsg,16,6)
						
					end
					
					fetch next from cursor_soDetails_disPlan into @autoID
				end 
				
				close cursor_soDetails_disPlan
				deallocate cursor_soDetails_disPlan
					
			end
		end	
		Set NoCount off
	end
go



