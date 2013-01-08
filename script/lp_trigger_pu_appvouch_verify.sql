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

			declare @yearStr nvarchar(100)
			declare @monthStr nvarchar(100)
			declare @dayStr varchar(100)
			select @yearStr =  cast (datepart(year,getDate())as nvarchar)
			select @monthStr = REPLICATE('0',2-LEN(CAST( datepart(month , getdate()) as nvarchar)))+CAST( datepart(month , getdate()) as nvarchar)
			select @dayStr = REPLICATE('0',2-LEN(CAST( datepart(day , getdate()) as nvarchar)))+CAST( datepart(day , getdate()) as nvarchar)
			declare @dateStr varchar(255)
			--raiserror(@monthStr,16,6)
			--return
			set @dateStr = @yearStr+'-'+@monthStr+'-'+@dayStr
			
			--raiserror('ddd',16,6)
			--审核
			if len(@cVerifier)<>0 or len(@dverifydate) <>0
			begin
				--raiserror('ddd',16,6)
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
				if cast(@cNumber as int)>=10000
					set @cNumber=1
				--select (cNumber+1) From VoucherHistory with (NOLOCK)Where CardNumber='MO21' and cContent is NULL
				set @cMaxNumber = @cNumber
				set @cMaxNumber = REPLICATE('0',4-LEN(@cNumber))+@cNumber
				set @cMaxNumber=@yearStr+@monthStr+@cMaxNumber

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
				--raiserror(@cAccID,16,6)
				--return;
				exec sp_GetID @RemoteId=N'00',@cAcc_Id=@cAccID,@cVouchType=N'PuApp',@iAmount=1,@iFatherId=@p5 output,@iChildId=@p6 output
				
				--select @p5, @p6	
				--raiserror(@p5,16,6);
				
			begin tran tran1	
				declare @cExchName varchar(255)
				select @cExchName=cexch_name from foreigncurrency where cexch_code = @cExchCode

				if @cbustype=0
					set @cbustype='普通采购'
				insert into pu_appvouch(cCode,dDate,cDepCode,cPersonCode,
			cPTCode,cBusType,ivtid,ID,cDefine1,cmaker,iverifystateex,ibg_overflag,
			cbg_auditor,cbg_audittime)
			values(@cMaxNumber,@dateStr,@cDepCode,@cPersonCode,
			@cPTCode,@cBusType,8171,@p5,@cCode,'demo',0,null,null,null)
		if @@error <> 0 
			set @okay1 = 0
		/*插入销售订单子记录到生成订单*/
		declare @rowCounter int 
		set @rowCounter =1 
		declare cursor_fetch_sub cursor for 
			select cInvCode,fQuantity,iTaxUnitPrice,cDetailMemo,cSoCode,
			iMoney,iTax,iSum,iPerTaxRate,iNatUnitPrice,
			iNatMoney,iNatTax,iNatSum,iQuotedPrice,cSoID,cSoAutoID,lpvouchspk,
			dRequireDate,dArriveDate 
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
		declare @lpvouchspk varchar(255)
		declare @dRequireDate varchar(255)
		declare @dArriveDate varchar(255)
		 		 
		 fetch next from cursor_fetch_sub into @cInvCode,@fQuantity,@iTaxUnitPrice,
		@cDetailMemo,@cSoCode,@iMoney,@iTax,@iSum,@iPerTaxRate,
		@iNatUnitPrice,@iNatMoney,@iNatTax,@iNatSum,@iQuotedPrice,@cSoID,@cSoAutoID,
		@lpvouchspk,@dRequireDate,@dArriveDate
		 
		 while @@fetch_status =0
		 begin
					declare @p2_5 int
					set @p2_5=9414
					declare @p2_6 int
					set @p2_6=7253
					exec sp_GetID @RemoteId=N'00',@cAcc_Id=@cAccID,@cVouchType=N'PuApp',@iAmount=1,@iFatherId=@p2_5 output,@iChildId=@p2_6 output
					--select @p2_5, @p2_6
					
					/*insert into pu_appvouchs(ID,autoid,cInvCode,fQuantity,
					iPerTaxRate,cdefine22,drequirdate,btaxcost,iexchrate,ivouchrowno,
					cdefine26,cdefine27,cbg_itemcode,cbg_itemname,cbg_caliberkey1,cbg_caliberkeyname1,
					cbg_caliberkey2,cbg_caliberkeyname2,cbg_caliberkey3,cbg_caliberkeyname3,
					cbg_caliberkey4,cbg_caliberkeyname4,cbg_caliberkey5,cbg_caliberkeyname5,
					cbg_caliberkey6,cbg_caliberkeyname6,
					cbg_calibercode1,cbg_calibername1,cbg_calibercode2,cbg_calibername2,cbg_calibercode3,cbg_calibername3,
					cbg_calibercode4,cbg_calibername4,cbg_calibercode5,cbg_calibername5,
					cbg_calibercode6,cbg_calibername6,
					ibg_ctrl,cbg_auditopinion) 
					values(@p5,@p2_6,@cInvCode,@fQuantity,@iPerTaxRate,@lpvouchspk,@dateStr,
					1,1,@rowCounter,null,null,null,null,null,null,null,null,null,null,
					null,null,null,null,null,null,null,null,null,null,null,null,
					null,null,null,null,null,null,null,null)*/
					insert into pu_appvouchs(ID,autoid,cInvCode,fQuantity,
					iPerTaxRate,cdefine22,drequirdate,btaxcost,iexchrate,ivouchrowno,
					cdefine26,cdefine27,cbg_itemcode,cbg_itemname,cbg_caliberkey1,cbg_caliberkeyname1,
					cbg_caliberkey2,cbg_caliberkeyname2,cbg_caliberkey3,cbg_caliberkeyname3,
					cbg_caliberkey4,cbg_caliberkeyname4,cbg_caliberkey5,cbg_caliberkeyname5,
					cbg_caliberkey6,cbg_caliberkeyname6,
					cbg_calibercode1,cbg_calibername1,cbg_calibercode2,cbg_calibername2,cbg_calibercode3,cbg_calibername3,
					cbg_calibercode4,cbg_calibername4,cbg_calibercode5,cbg_calibername5,
					cbg_calibercode6,cbg_calibername6,
					ibg_ctrl,cbg_auditopinion,darrivedate) 
					values(@p5,@p2_6,@cInvCode,@fQuantity,@iPerTaxRate,@lpvouchspk,@dRequireDate,
					1,1,@rowCounter,null,null,null,null,null,null,null,null,null,null,
					null,null,null,null,null,null,null,null,null,null,null,null,
					null,null,null,null,null,null,null,null,@dArriveDate)

					fetch next from cursor_fetch_sub into @cInvCode,@fQuantity,@iTaxUnitPrice,
		@cDetailMemo,@cSoCode,@iMoney,@iTax,@iSum,@iPerTaxRate,
		@iNatUnitPrice,@iNatMoney,@iNatTax,@iNatSum,@iQuotedPrice,@cSoID,@cSoAutoID,
		@lpvouchspk,@dRequireDate,@dArriveDate

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
					 update VoucherHistory set cNumber = @cNumber Where CardNumber='27' and cContent is NULL
					 commit tran tran1
					 return ;
				end 
				rollback tran tran1
				return ;
				end
			end
		end
		set nocount off
	end 
go
