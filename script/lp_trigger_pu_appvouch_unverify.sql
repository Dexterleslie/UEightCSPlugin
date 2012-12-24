go
if exists ( select * from sysobjects where xtype = 'TR' and name = 'lp_trigger_pu_appvouch_unverify')
	drop trigger lp_trigger_pu_appvouch_unverify 
go
go
	create trigger lp_trigger_pu_appvouch_unverify 
	on lp_pu_appVouch
	for update
	as 
	begin
		set nocount on 
		if update ( iVerifyState)
		begin
			/*�Ƶ����ɲɹ��빺���߼�*/
			declare @iVerifyState int 
			select 
			@iVerifyState = iVerifyState
			from inserted

			if @iVerifyState = 0
			begin
				raiserror('����',16,6)
				return 
			end
		end
		set nocount off 
	end
go