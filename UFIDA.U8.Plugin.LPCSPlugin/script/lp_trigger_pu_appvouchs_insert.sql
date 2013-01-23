go
if exists ( select * from sysobjects where xtype = 'TR' and name = 'lp_trigger_pu_appvouchs_insert')
	drop trigger lp_trigger_pu_appvouchs_insert 
go
go
create trigger lp_trigger_pu_appvouchs_insert 
on lp_pu_appVouchs
instead of insert 
as
	begin
		set nocount on 
		declare @cSoAutoID varchar(255)
		declare @errMsg varchar(255)
		declare @cInvCode varchar(255)
		declare @cInvName varchar(255)
		declare @cSoCOde varchar(255)
		declare @fQuantity varchar(255)

		select @cSoAutoID=cSoAutoID from inserted
		if exists(select * from lp_pu_appVouchs where cSoAutoID=@cSoAutoID)
		begin
			select @cInvCode=cInvCode,@cSoCode=cSoCode,@fQuantity=fQuantity from inserted
			select @cInvName=cInvName from inventory where cInvCode=@cInvCode
			set @errMsg = '��⵽���۶���['+@cSoCode+'],�������['+@cInvCode+'],���['+@cInvName+'],����['+@fQuantity+']������,�����ظ�ҵ��'
			raiserror(@errMsg,16,6)
			--rollback transaction
		end
		else 
		begin
			declare @lpVouchsPk int
			--select @isnull(maxvalue,0)+1 maxvalue from UAP_TablePKIntMaxValue with(xlock) where tablename='lp_pu_appvouchs'
			insert into lp_pu_appvouchs(cInvCode,fQuantity,iTaxUnitPrice,
cDetailMemo,cSoCode,iUnitPrice,iMoney,iTax,iSum,iPerTaxRate,
iNatUnitPrice,iNatMoney,iNatTax,iQuotedPrice,cSoID,cSoAutoID,
dRequireDate,dArriveDate,lpVouchPK,lpVouchsPK,UAPRuntime_RowNo,
UAP_VoucherTransform_RowKey,RefMainID,RefRowID)
select cInvCode,fQuantity,iTaxUnitPrice,
cDetailMemo,cSoCode,iUnitPrice,iMoney,iTax,iSum,iPerTaxRate,
iNatUnitPrice,iNatMoney,iNatTax,iQuotedPrice,cSoID,cSoAutoID,
dRequireDate,dArriveDate,lpVouchPK,lpVouchsPK,UAPRuntime_RowNo,
UAP_VoucherTransform_RowKey,RefMainID,RefRowID from inserted
		end
		
		set nocount off
	end 
go
