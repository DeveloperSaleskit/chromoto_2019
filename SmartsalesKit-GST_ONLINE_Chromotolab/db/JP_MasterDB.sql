SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetSourcePath]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 13th Feb 2011
-- Description:	Get Source Path for copy Exe
-- =============================================
Create PROCEDURE [dbo].[usp_GetSourcePath]
AS
BEGIN
	SET NOCOUNT ON;
	Select 
		Source_ReportPath,Source_ExePath,Destination_Path
	From SysSettings
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SysSettings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SysSettings](
	[Path_Data] [varchar](500) NULL,
	[Path_BackUp] [varchar](500) NOT NULL,
	[Source_ReportPath] [varchar](500) NULL,
	[Source_ExePath] [varchar](500) NULL,
	[Destination_Path] [varchar](500) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBTrans]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DBTrans](
	[DBTransID] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [smallint] NOT NULL,
	[RefID] [bigint] NULL,
	[FileName] [varchar](100) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_IGMS_DBTrans] PRIMARY KEY CLUSTERED 
(
	[DBTransID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DBTrans', N'COLUMN',N'DBTransID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'[1] Backup will be created under "D:\Account\Database\Backup" folder.
[2] Backup file name should be "<YYYYMMDDHHMISS>Account.BAK"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DBTrans', @level2type=N'COLUMN',@level2name=N'DBTransID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DBTrans', N'COLUMN',N'Type'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = Backup, 2= Restore' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DBTrans', @level2type=N'COLUMN',@level2name=N'Type'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DBTrans', N'COLUMN',N'RefID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'[1] Restoring databse require reference to Backup. i.e. what Backup has ben restored.
[2] "NULL" in case of Backup
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DBTrans', @level2type=N'COLUMN',@level2name=N'RefID'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_BackUp]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Manoj Savalia
-- Create date: 13th Feb 2011
-- Description:	Back up Database
 
-- =============================================
CREATE PROCEDURE [dbo].[usp_BackUp]
	@i_DBName varchar(200),	
@i_BackupType varchar(200),
@i_BackupPath varchar(200),
	@o_ErrorMesg varchar(100) output	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	/*DECLARE Variables*/
	DECLARE @l_Path_BackUp varchar(500)	
	DECLARE @l_BackUpFile varchar(100)
	DECLARE @l_TSQL varchar(1000)

	/*Set Database Name*/
	If @i_DBName = ''''
	Begin
		SET @i_DBName = ''JPERP_Hozefa_Jariwala'' 
	End
	/*GET Back Up Path from Sys Settings*/
if @i_BackupType=''Remote''
begin
	SELECT
		@l_Path_BackUp = SysSettings.Path_BackUp
	FROM
		SysSettings

end

if @i_BackupType=''Local''
begin
set @l_Path_BackUp = @i_BackupPath
end



 
	/*Derive Back File Name*/
	SET @l_BackUpFile = @i_DBName  + ''_'' + 	
					REPLACE(REPLACE(CONVERT(varchar,getdate(),113),'' '',''_''),'':'',''_'') + ''.BAK''
						
	/*Create Back up Statement*/
	SET @l_TSQL = 
		'' BACKUP DATABASE '' + @i_DBName +  
		'' TO DISK = '''''' + @l_Path_BackUp + @l_BackUpFile + '''''''' + 
		'' WITH  EXPIREDATE = ''''11/21/3001'''', NOFORMAT, NOINIT,  '' + 
		'' NAME = '''''' + @i_DBName + ''-Full Backup'''','' +
		'' SKIP, NOREWIND, NOUNLOAD,  STATS = 10''
 
 	--Select @l_TSQL
 	 EXECUTE (@l_TSQL)

	/*Record BackUp Transaction*/
	INSERT INTO DBTrans
		(
			[Type],
			[RefID],
			[FileName],
			[CreatedBy],
			[CreatedDate]
		)
	VALUES
		(
			1, /*Backup*/	
			NULL, /*Reference is not required while backup database*/
			@l_BackUpFile,
			1, /*Reference to The User who did Backup*/
			getdate()
		)

	SET @o_ErrorMesg = ''Database backup Successfully Executed..''
END

 







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Restore]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Manoj Savalia
-- Create date: 13th Feb 2011
-- Description:	Restore Database
-- =============================================
CREATE PROCEDURE [dbo].[usp_Restore]
--[usp_Restore]''12'',''CRM_FINAL'',''''
	@i_DBTransID bigint,
	@i_DBName varchar(20),
	@o_ErrorMesg varchar(100) output
	
AS
BEGIN
	 
	SET NOCOUNT ON;
	/*DECLARE Variables*/
	DECLARE @l_Path_BackUp varchar(500)	
	DECLARE @l_BackUpFile varchar(100)
	DECLARE @l_TSQL varchar(1000)
	/*GET Back File Name*/
	SELECT
		@l_BackUpFile = [DBTrans].[FileName]
	FROM
		[DBTrans]
	WHERE
		[DBTrans].[DBTransID] = @i_DBTransID
 
	/*Verification*/
	IF @l_BackUpFile IS NULL
		BEGIN
			SET @o_ErrorMesg = ''File not found, unable to restore database''
		END
	ELSE
		BEGIN
			/*GET Back Up Path from Sys Settings*/
			SELECT
				@l_Path_BackUp = SysSettings.Path_BackUp
			FROM
				SysSettings
			SET @l_TSQL = 
				'' RESTORE DATABASE '' + @i_DBName + ''  
				 FROM DISK = '''''' + @l_Path_BackUp + @l_BackUpFile + '''''''' + 
				'' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10 ''
			--Print @l_TSQL
			EXECUTE (@l_TSQL)
			/*Record BackUp Transaction*/
			INSERT INTO DBTrans
				(
					[Type],
					[RefID],
					[FileName],
					[CreatedBy],
					[CreatedDate]
				)
			VALUES
				(
					2, /*Restore*/	
					@i_DBTransID, /*Reference to BackUp Transaction*/
					NULL, /*NULL for Restore operation*/
					1, /*Reference to The User who did Backup*/
					getdate()
				)
			SET @o_ErrorMesg = ''Database Restore Operation Successfully Executed...''
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_DBInitialize]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 13th Feb 2011
-- Description:	Initialize the IGMS_Master Database 
-- Change History
-- Date			Name			Description
 
-- =============================================
CREATE PROCEDURE [dbo].[usp_DBInitialize]
	@isDelete bit = 0,
	@isReset bit = 0,
	@isInsert bit = 0
	/*
		-- SP Execution Statement
		-- You may change the value of the parameter and execute the SP
		DECLARE	@return_value int
		EXEC	@return_value = [dbo].[usp_DBInitialize]
				@isDelete = 1,
				@isReset = 1,
				@isInsert = 1
		SELECT	''Return Value'' = @return_value
	*/
AS
BEGIN
	IF @isDelete = 1
	BEGIN
		-- DBTrans  
		DELETE FROM DBTrans
		--SysSettings - 2009-07-15
		DELETE FROM SysSettings
	END
	IF @isReset = 1
	BEGIN
		-- DBTrans  - 2009-07-15
		DBCC CHECKIDENT(DBTrans, RESEED, 0)
	END
	IF @isInsert = 1
	BEGIN
		-- SysSettings - 2009-07-15
		INSERT INTO SysSettings (Path_Data, Path_BackUp) VALUES (''E:\Current Database\'', ''E:\Current Database\Backup\'')
	 
	END
END
 
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_BackupList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Manoj savalia
-- Create date: 13th Feb 2011
-- Description:	Display List Of Old Backup for Current Company
-- =============================================
CREATE PROCEDURE [dbo].[usp_BackupList]
	 
AS
BEGIN
	SET NOCOUNT ON;
		Select 
			ROW_NUMBER()OVER (ORDER BY CreatedDate ASC)as SrNo,
			DBTransID,
			FileName,
			CreatedDate 
		From 
			DBTrans
		Where Type = 1  
		Order By CreatedDate
END

' 
END
