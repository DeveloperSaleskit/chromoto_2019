SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CustomerPayment_PendingSI_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 26th Jan 2011
-- Description:	Get Pending Receipt List
-- =============================================
CREATE PROCEDURE [dbo].[usp_CustomerPayment_PendingSI_List]
--[usp_CustomerPayment_PendingSI_List]''6''
	@i_CustomerID Bigint
AS
BEGIN
	SET NOCOUNT ON;

SELECT     SIID, 0.000 AS PaidAmount, (Round(NetAmount,0) - Round(PaidAmount,0)) AS PendingAmount, SalesCode, SalesDate, CustomerID
FROM         SalesInvoice
	Where SalesInvoice.CustomerID = @i_CustomerID And
		(NetAmount - PaidAmount)>0
	Order By SalesCode,SalesDate;


END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_CustomerReceipt]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author: Manoj Savalia
-- Create date: 26th Jan 2011
-- Description: Get Receipt List
-- =============================================
CREATE PROCEDURE [dbo].[rpt_CustomerReceipt]

AS
BEGIN
SET NOCOUNT ON;

--	SELECT SalesInvoice.SIID, 
--		Customer.Code as CustomerCode, 
--		Customer.Name as CustomerName, 
--		SalesInvoice.SalesCode, 
--		SalesInvoice.SalesDate, 
--		SalesInvoice.DueDays, 
--		SalesInvoice.DueDate, 
--		SalesInvoice.NetAmount, 
--		IsNull(SalesInvoice.PaidAmount,0.00) as PaidAmount, 
--		(SalesInvoice.NetAmount - SalesInvoice.PaidAmount) As PendingAmount 
--	FROM SalesInvoice 
--		LEFT Join Customer On Customer.CustomerID = SalesInvoice.CustomerID  
--	Order By SalesCode,SalesDate;


SELECT SalesInvoice.SIID, 
		LEAD.LEADNO as CustomerCode, 
		LEAD.CustomerName, 
		SalesInvoice.SalesCode, 
		SalesInvoice.SalesDate, 
		SalesInvoice.DueDays, 
		SalesInvoice.DueDate, 
		SalesInvoice.NetAmount, 
		IsNull(SalesInvoice.PaidAmount,0.00) as PaidAmount, 
		(SalesInvoice.NetAmount - SalesInvoice.PaidAmount) As PendingAmount 
	FROM SalesInvoice 
		LEFT JOIN LEAD ON LEAD.LEADID=SalesInvoice.CustomerID  
	Order By SalesCode,SalesDate;


END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Category_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Category_DDL]
AS
BEGIN
	SET NOCOUNT ON;

	Select Distinct Category From lead Where Category<>''''
	union
--	Select ''New Paper Advertise''
--	Union
--	Select ''Hoarding''
--	Union
--	Select ''Radio Adversie''
--	Union
--	Select ''Website''	
--	Union
--	Select ''Exhibition''
--	Union
--	Select ''Inter Net Advertise''
--	Union
--	Select ''Reference''
--	Union
	Select ''Other''

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GoodsTransaction]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GoodsTransaction](
	[GTID] [bigint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Desc] [varchar](max) NULL,
 CONSTRAINT [PK_GoodsTransaction] PRIMARY KEY CLUSTERED 
(
	[GTID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Lead_Id]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--select * from Lead
CREATE PROCEDURE [dbo].[usp_Lead_Id]
	-- Add the parameters for the stored procedure here
	@i_LeadNo nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT   Distinct  LeadId
FROM   dbo.Lead      
WHERE LeadNo=@i_LeadNo
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_GRN_edit]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_Item_GRN_edit]
	-- Add the parameters for the stored procedure here


	@i_SIID int=0,
	@i_ItemID int=0

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT     Item.Name AS ItemName, Gen_UOM.Name AS UOM, Item.Price, SalesInvoiceDetail.SIID, SalesInvoiceDetail.ItemID, SalesInvoiceDetail.ItemDesc, 
                      SalesInvoiceDetail.Qty, SalesInvoiceDetail.Rate, SalesInvoiceDetail.TaxClassID, SalesInvoiceDetail.Amount, SalesInvoiceDetail.ServiceRate, 
                      SalesInvoiceDetail.ServiceAmount, SalesInvoiceDetail.ExciseRate, SalesInvoiceDetail.ExciseAmount, SalesInvoiceDetail.CessRate, SalesInvoiceDetail.CessAmount, 
                      SalesInvoiceDetail.HCessRate, SalesInvoiceDetail.HCessAmount, SalesInvoiceDetail.CSTRate, SalesInvoiceDetail.CSTAmount, SalesInvoiceDetail.VATRate, 
                      SalesInvoiceDetail.VATAmount, SalesInvoiceDetail.AVATAmount, SalesInvoiceDetail.AVATRate, SalesInvoiceDetail.NetAmount,SalesInvoiceDetail.Discount,
		OrderBookingDetail.MoldNo,
		OrderBookingDetail.DQty,
		OrderBookingDetail.RQty,OrderBookingDetail.Qty as OBQty
FROM         Gen_UOM INNER JOIN
                      Item ON Gen_UOM.UOMID = Item.CUOMID INNER JOIN
                      SalesInvoiceDetail ON Item.ItemID = SalesInvoiceDetail.ItemID INNER JOIN
                      TaxClass ON SalesInvoiceDetail.TaxClassID = TaxClass.TaxClassID INNER JOIN
                      SalesInvoice ON SalesInvoiceDetail.SIID = SalesInvoice.SIID
						INNER JOIN OrderBooking ON OrderBooking.SIID=SalesInvoice.OrderBookingID
			INNER JOIN OrderBookingDetail ON OrderBookingDetail.SIID=OrderBooking.SIID
where SalesInvoiceDetail.SIID=@i_SIID and SalesInvoiceDetail.ItemID=@i_ItemID

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Services_TNC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Services_TNC](
	[SR_TNC_ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[TNC_Sub] [nvarchar](250) NULL,
	[TNC_Desc] [nvarchar](max) NULL,
 CONSTRAINT [PK_Services_TNC] PRIMARY KEY CLUSTERED 
(
	[SR_TNC_ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Quotation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Quotation](
	[QuotationId] [bigint] IDENTITY(1,1) NOT NULL,
	[LeadId] [bigint] NULL,
	[QDate] [datetime] NULL,
	[QPrice] [decimal](18, 0) NULL,
	[AdvAmount] [decimal](18, 0) NULL,
	[PaidAmount] [decimal](18, 0) NULL,
	[Remarks] [varchar](250) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[SIID] [bigint] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[ServiceAmount] [decimal](18, 2) NULL,
	[ExciseAmount] [decimal](18, 2) NULL,
	[CessAmount] [decimal](18, 2) NULL,
	[HCessAmount] [decimal](18, 2) NULL,
	[AmountAfterExcise] [decimal](18, 2) NULL,
	[CSTAmount] [decimal](18, 2) NULL,
	[VATAmount] [decimal](18, 2) NULL,
	[AVATAmount] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[NetAmount] [decimal](18, 2) NULL,
	[FYID] [bigint] NULL,
	[EmpID] [int] NULL,
	[Refno] [nvarchar](250) NULL,
	[TypeOfSale] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[FollowupDate] [datetime] NULL,
	[Reference] [nvarchar](255) NULL,
	[Remarks_Orignal] [nvarchar](max) NULL,
	[CC] [nvarchar](max) NULL,
	[BCC] [nvarchar](max) NULL,
	[FileName] [nvarchar](max) NULL,
	[Is_SendMail] [bit] NULL,
	[EmpAllToID] [int] NULL,
	[CompId] [bigint] NULL,
	[GodownID] [int] NULL,
 CONSTRAINT [PK_Quotation] PRIMARY KEY CLUSTERED 
(
	[QuotationId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sales_TNC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sales_TNC](
	[SIID_TNC_ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[TNC_Sub] [nvarchar](250) NULL,
	[TNC_Desc] [nvarchar](max) NULL,
 CONSTRAINT [PK_Sales_TNC] PRIMARY KEY CLUSTERED 
(
	[SIID_TNC_ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemGroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemGroup](
	[ItemGroupID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_ItemGroup] PRIMARY KEY CLUSTERED 
(
	[ItemGroupID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_City_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Delete record from City 
-- =============================================
Create PROCEDURE [dbo].[usp_City_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
			
	DELETE FROM Gen_City
		WHERE CityID = @i_RecID ;		


END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PO_Id]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_PO_Id]
	-- Add the parameters for the stored procedure here
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT   Distinct  PIID
FROM         PO
WHERE PurchaseCode=@i_Code
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_City_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select City record
-- =============================================
Create PROCEDURE [dbo].[usp_City_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		Name as CityName 
	FROM
		Gen_City
	WHERE
		CityID = @i_RecID 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gen_UOM]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Gen_UOM](
	[UOMID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Abbr] [varchar](5) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Gen_UOM] PRIMARY KEY CLUSTERED 
(
	[UOMID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SourceOfLead_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_SourceOfLead_DDL]
AS
BEGIN
	SET NOCOUNT ON;

	Select Distinct SourceOfLead From lead Where SourceOfLead<>''''
	union
	Select ''New Paper Advertise''
	Union
	Select ''Hoarding''
	Union
	Select ''Radio Adversie''
	Union
	Select ''Website''	
	Union
	Select ''Exhibition''
	Union
	Select ''Inter Net Advertise''
	Union
	Select ''Reference''
	Union
	Select ''Other''

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TypeOfCall]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TypeOfCall](
	[CallID] [int] IDENTITY(1,1) NOT NULL,
	[Call_Name] [nvarchar](150) NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_TypeOfCall] PRIMARY KEY CLUSTERED 
(
	[CallID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_City_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of City
-- =============================================
Create PROCEDURE [dbo].[usp_City_List]
	@i_StateID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 		
		CityID,
		Name as CityName
	FROM
		Gen_City
	WHERE
		StateID = @i_StateID
	ORDER BY
		Name
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PO_Rate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		PRIYANKA
-- Create date: 25/11/2014
-- Description:	SELECT LATEST RATE FROM PURCHASE
-- =============================================
create PROCEDURE [dbo].[usp_PO_Rate] 
	-- Add the parameters for the stored procedure here
	@i_ItemID bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select RATE 
from PODetail
WHERE PIID=(SELECT MAX(PIID) FROM PODetail WHERE ITEMID=@i_ItemID) and ITEMID=@i_ItemID
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemClass]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemClass](
	[ItemClassID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_ItemClass] PRIMARY KEY CLUSTERED 
(
	[ItemClassID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Lead_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Delete record from Lead 
-- =============================================
create PROCEDURE [dbo].[usp_Lead_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';

	DELETE FROM Lead
		WHERE LeadId = @i_RecID ;
				
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Purchase_Item_Edit]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 24th Jan 2011
-- Description:	Select record from PurchaseInvoice and PurchaseInvoiceDetail
-- change history:
-- =============================================
create PROCEDURE [dbo].[usp_Purchase_Item_Edit]
--[usp_Indent_SelectNew]''32'',''18''
	@i_PIID Bigint,
     @i_Item_Edit Bigint
AS
BEGIN
	
			SELECT     PODetail.Qty, PODetail.Rate, PODetail.Amount AS TotalAmount, PODetail.TaxClassID, PODetail.ExciseRate, PODetail.ExciseAmount, 
                      PODetail.CessRate AS ECessRate, PODetail.CessAmount AS ECessAmount, PODetail.HCessRate AS HECessRate, PODetail.HCessAmount AS HECessAmount, 
                      PODetail.AmountAfterExcise, PODetail.CSTRate, PODetail.CSTAmount, PODetail.VATRate, PODetail.VATAmount, PODetail.AVATRate, PODetail.AVATAmount, 
                      PODetail.NetAmount, PODetail.ServiceRate, PODetail.ServiceAmount, PODetail.DDate, Item.Name AS ItemName, Gen_UOM.Name AS UOM, 
                      TaxClass.Name AS TaxClass, ItemStock.QOH 
FROM         PODetail INNER JOIN
                      Item ON PODetail.ItemID = Item.ItemID INNER JOIN
                      Gen_UOM ON Item.CUOMID = Gen_UOM.UOMID INNER JOIN
                      TaxClass ON PODetail.TaxClassID = TaxClass.TaxClassID INNER JOIN
                      ItemStock ON Item.ItemID = ItemStock.ItemID
where PODetail.PIID=@i_PIID and PODetail.ItemID=@i_Item_Edit

End








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Lead_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Sp is used for bind Lead lov.
-- =============================================
CREATE PROCEDURE [dbo].[usp_Lead_LOV]
	 
AS
BEGIN
	 SET NOCOUNT ON;

    SELECT LeadID,
			LeadNo,
			CustomerName,
			LeadDate ,'''' as MobileNo,
			'''' as Email
	From 
		Lead --Where Lead.LeadID  not in (select LeadID from Quotation)
	Order By LeadNo,CustomerName





END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Purchase_Indent_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for bind Vendor lov.
-- =============================================
create PROCEDURE [dbo].[usp_Purchase_Indent_LOV]
	 @i_RecID int
AS
BEGIN
	 SET NOCOUNT ON;

--    SELECT     VendorID, Name AS VendorName, Fax
--FROM         Vendor
--ORDER BY VendorName
--SELECT PODetail.Qty, PODetail.Rate, TaxClass.Name AS TaxClass, PODetail.ExciseAmount, PODetail.CessAmount AS ECessAmount, 
--               PODetail.HCessAmount AS HECessAmount, PODetail.AmountAfterExcise, PODetail.CSTAmount, PODetail.VATAmount, PODetail.AVATAmount, 
--               PODetail.NetAmount, PODetail.ServiceAmount, PODetail.Amount AS TotalAmount, Item.Name AS ItemName, Gen_UOM.Name AS UOM, Item.ItemID, PO.VendorID, 
--               PODetail.TaxClassID, PODetail.ExciseRate, PODetail.CessRate as ECessRate, PODetail.HCessRate as HECessRate, PODetail.CSTRate, PODetail.VATRate, PODetail.AVATRate, 
--               PODetail.ServiceRate, PODetail.DDate
--FROM  PODetail INNER JOIN
--               Item ON PODetail.ItemID = Item.ItemID INNER JOIN
--               TaxClass ON PODetail.TaxClassID = TaxClass.TaxClassID INNER JOIN
--               Gen_UOM ON Item.CUOMID = Gen_UOM.UOMID INNER JOIN
--               PO ON PODetail.PIID = PO.PIID
--WHERE (PO.PIID = @i_RecID)



SELECT     PODetail.Qty, PODetail.Rate, TaxClass.Name AS TaxClass, PODetail.ExciseAmount, PODetail.CessAmount AS ECessAmount, 
                      PODetail.HCessAmount AS HECessAmount, PODetail.AmountAfterExcise, PODetail.CSTAmount, PODetail.VATAmount, PODetail.AVATAmount, PODetail.NetAmount, 
                      PODetail.ServiceAmount, PODetail.Amount AS TotalAmount, Item.Name AS ItemName, Gen_UOM.Name AS UOM, Item.ItemID, PO.VendorID, PODetail.TaxClassID, 
                      PODetail.ExciseRate, PODetail.CessRate AS ECessRate, PODetail.HCessRate AS HECessRate, PODetail.CSTRate, PODetail.VATRate, PODetail.AVATRate, 
                      PODetail.ServiceRate, PODetail.DDate, ''0.00'' AS ReceivedQty,PODetail.Qty as RemainingQty
FROM         PODetail LEFT OUTER JOIN
                      Item ON Item.ItemID = PODetail.ItemID LEFT OUTER JOIN
                      TaxClass ON TaxClass.TaxClassID = PODetail.TaxClassID LEFT OUTER JOIN
                      Gen_UOM ON Gen_UOM.UOMID = Item.CUOMID LEFT OUTER JOIN
                      PO ON PO.PIID = PODetail.PIID
WHERE (PO.PIID = @i_RecID)
END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PurchaseTNC_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_PurchaseTNC_Delete]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub nvarchar(250),
	@i_Code nvarchar(50),
	@i_TNC_Desc nvarchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

DELETE FROM Purchase_TNC WHERE Code=@i_Code AND TNC_Sub=@i_TNC_Sub AND TNC_Desc=@i_TNC_Desc

	

END








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PurchaseTNC_Delete_On_Close]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_PurchaseTNC_Delete_On_Close]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub nvarchar(250),
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

DELETE FROM Purchase_TNC WHERE Code=@i_Code AND TNC_Sub=@i_TNC_Sub 

	

END








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gen_Country]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Gen_Country](
	[CountryID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PurchaseTNC_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_PurchaseTNC_Insert]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub nvarchar(250),
	@i_Code nvarchar(50),
	@i_TNC_Desc nvarchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

	INSERT INTO Purchase_TNC
                      (Code,TNC_Sub,TNC_Desc)
VALUES     (@i_Code,@i_TNC_Sub,@i_TNC_Desc)

END








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sales_Service_Reminder]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sales_Service_Reminder](
	[SRID] [int] IDENTITY(1,1) NOT NULL,
	[SR_Code] [nvarchar](50) NULL,
	[SR_Date] [datetime] NULL,
	[SIID] [int] NULL,
	[SR_Done] [int] NULL,
	[ServiceId] [int] NULL,
 CONSTRAINT [PK_Sales_Service_Reminder] PRIMARY KEY CLUSTERED 
(
	[SRID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PurchaseTNC_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_PurchaseTNC_Select]
	-- Add the parameters for the stored procedure here
	
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT     TNC_Sub, TNC_Desc
FROM         Purchase_TNC
WHERE     (Code = @i_Code)

END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Godown]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Godown](
	[GodownID] [int] IDENTITY(1,1) NOT NULL,
	[Godown_name] [nvarchar](250) NULL,
	[Godown_addr] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[CityID] [int] NULL,
 CONSTRAINT [PK_Godown] PRIMARY KEY CLUSTERED 
(
	[GodownID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PO](
	[PIID] [bigint] IDENTITY(1,1) NOT NULL,
	[FYID] [bigint] NOT NULL,
	[PurchaseCode] [varchar](20) NULL,
	[PurchaseDate] [datetime] NULL,
	[VoucherNo] [varchar](20) NULL,
	[VoucherDate] [datetime] NULL,
	[VendorID] [bigint] NULL,
	[DueDays] [bigint] NULL CONSTRAINT [DF_PO_DueDays]  DEFAULT ((0)),
	[DueDate] [datetime] NULL,
	[TotalAmount] [decimal](18, 2) NULL CONSTRAINT [DF_PO_TotalAmount]  DEFAULT ((0.00)),
	[ExciseAmount] [decimal](18, 2) NULL CONSTRAINT [DF_PO_ExciseAmount]  DEFAULT ((0.00)),
	[CessAmount] [decimal](18, 2) NULL CONSTRAINT [DF_PO_CessAmount]  DEFAULT ((0.00)),
	[HCessAmount] [decimal](18, 2) NULL CONSTRAINT [DF_PO_HCessAmount]  DEFAULT ((0.00)),
	[AmountAfterExcise] [decimal](18, 2) NULL CONSTRAINT [DF_PO_AmountAfterExcise]  DEFAULT ((0.00)),
	[CSTAmount] [decimal](18, 2) NULL CONSTRAINT [DF_PO_CSTAmount]  DEFAULT ((0.00)),
	[VATAmount] [decimal](18, 2) NULL CONSTRAINT [DF_PO_VATAmount]  DEFAULT ((0.00)),
	[AVATAmount] [decimal](18, 2) NULL CONSTRAINT [DF_PO_AVATAmount]  DEFAULT ((0.00)),
	[Discount] [decimal](18, 2) NULL CONSTRAINT [DF_PO_Discount]  DEFAULT ((0.00)),
	[NetAmount] [decimal](18, 2) NULL CONSTRAINT [DF_PO_NetAmount]  DEFAULT ((0.00)),
	[Narration] [varchar](250) NULL,
	[PaidAmount] [decimal](18, 2) NULL CONSTRAINT [DF_PO_PaidAmount]  DEFAULT ((0.00)),
	[SrNo] [varchar](50) NULL,
	[ServiceAmount] [decimal](18, 2) NULL,
	[GodownID] [int] NULL,
	[BankName] [nvarchar](max) NULL,
	[ChequeNo] [nvarchar](max) NULL,
	[ChequeDate] [datetime] NULL,
	[CC] [nvarchar](max) NULL,
	[BCC] [nvarchar](max) NULL,
	[Is_SendMail] [bit] NULL,
	[CompId] [bigint] NULL,
 CONSTRAINT [PK_PO] PRIMARY KEY CLUSTERED 
(
	[PIID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ServiceDocList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ServiceDocList](
	[DocID] [bigint] IDENTITY(1,1) NOT NULL,
	[ServiceID] [bigint] NOT NULL,
	[DocName] [varchar](250) NOT NULL,
	[Remarks] [varchar](250) NULL,
 CONSTRAINT [PK_ServiceDocList] PRIMARY KEY CLUSTERED 
(
	[DocID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VersionInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VersionInfo](
	[VersionID] [bigint] IDENTITY(1,1) NOT NULL,
	[VersionNo] [varchar](50) NOT NULL,
	[IsCurrent] [smallint] NOT NULL,
 CONSTRAINT [PK_VersionInfo] PRIMARY KEY CLUSTERED 
(
	[VersionID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LeadStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LeadStatus](
	[LeadStatusID] [bigint] NOT NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LeadStatus] PRIMARY KEY CLUSTERED 
(
	[LeadStatusID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gen_ErrorMsg]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Gen_ErrorMsg](
	[ErrorNo] [bigint] NOT NULL,
	[ErrorMsg] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Gen_ErrorMsg] PRIMARY KEY CLUSTERED 
(
	[ErrorNo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaxClass]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TaxClass](
	[TaxClassID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](25) NOT NULL,
	[FromDate] [datetime] NOT NULL,
	[Excise] [decimal](12, 2) NULL,
	[EduCess] [decimal](12, 2) NULL,
	[HEduCess] [decimal](12, 2) NULL,
	[ServiceTax] [decimal](12, 2) NULL,
	[CST] [decimal](12, 2) NULL,
	[VAT] [decimal](12, 2) NULL,
	[AVAT] [decimal](12, 2) NULL,
	[IsTerminate] [bigint] NOT NULL CONSTRAINT [DF_TaxClass_IsTerminate]  DEFAULT ((0)),
	[TerminateDate] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_TaxClass] PRIMARY KEY CLUSTERED 
(
	[TaxClassID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'TaxClass', N'COLUMN',N'IsTerminate'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0-No,1-Yes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TaxClass', @level2type=N'COLUMN',@level2name=N'IsTerminate'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gen_User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Gen_User](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [tinyint] NOT NULL CONSTRAINT [DF_Gen_User_IsActive]  DEFAULT ((1)),
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[CompId] [bigint] NULL,
	[Company] [varchar](100) NULL,
	[User_Email] [nvarchar](50) NULL,
	[User_Password] [nvarchar](50) NULL,
	[User_ssl] [int] NULL,
	[User_Port] [int] NULL,
	[Company_Email] [nvarchar](50) NULL,
	[User_Host] [nvarchar](50) NULL,
	[User_NPassword] [nvarchar](50) NULL,
	[Mail_Send] [bit] NULL,
 CONSTRAINT [PK_Gen_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Gen_User', N'COLUMN',N'IsActive'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = Active, 0 = Not Active' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Gen_User', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Receipt]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Receipt](
	[ReceiptID] [bigint] IDENTITY(1,1) NOT NULL,
	[ReceiptCode] [varchar](20) NOT NULL,
	[ReceiptDate] [datetime] NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[Narration] [varchar](250) NULL,
	[NetAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_Receipt_NetAmount]  DEFAULT ((0.000)),
	[BankName] [varchar](150) NULL,
	[ChequeNo] [varchar](50) NULL,
	[ChequeDate] [datetime] NULL,
	[CompId] [bigint] NULL,
	[UserID] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[ReceiptID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TNC_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_TNC_Delete]
@i_RecID bigint,
	@o_ErrorMesg varchar(500) OUTPUT
AS
BEGIN
SET @o_ErrorMesg='''';
	SET NOCOUNT ON;

  Delete From TermsNConditions WHERE TNCID = @i_RecID;
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExceptionLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExceptionLog](
	[ExceptionID] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[ErrorMessage] [varchar](5000) NULL,
	[ModuleName] [varchar](250) NULL,
	[UserID] [bigint] NULL,
 CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED 
(
	[ExceptionID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LeadFollowUp]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LeadFollowUp](
	[LeadFollowUpId] [bigint] IDENTITY(1,1) NOT NULL,
	[LeadID] [bigint] NOT NULL,
	[NextFollowupDate] [datetime] NOT NULL,
	[FollowupBy] [bigint] NOT NULL,
	[Remarks] [varchar](max) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_LeadFollowUp] PRIMARY KEY CLUSTERED 
(
	[LeadFollowUpId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_LeadFollowUp_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Insert record in LeadFollowUp Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_LeadFollowUp_Insert]
	@i_LeadID Bigint,
	@i_NextFollowupDate DateTime,	
	@i_Remarks Varchar(250),
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
		
	Update Lead set NextFollowUpDate =@i_NextFollowupDate, LeadStatusID=2,Remarks=@i_Remarks where LeadID = @i_LeadID;

	INSERT INTO LeadFollowUp(LeadID,NextFollowupDate,FollowupBy,Remarks,CreatedBy,CreatedDate)
	VALUES(@i_LeadID,@i_NextFollowupDate,@i_UserID,@i_Remarks,@i_UserID,@l_Date)

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Temp_Item]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Temp_Item](
	[ITEM] [nvarchar](255) NULL,
	[OTHER_NAME] [nvarchar](255) NULL,
	[DESCRIPTION] [nvarchar](255) NULL,
	[UOM] [nvarchar](255) NULL,
	[PRICE] [nvarchar](255) NULL,
	[PRODUCT_CODE] [nvarchar](255) NULL,
	[HSN_CODE] [nvarchar](255) NULL,
	[F8] [nvarchar](255) NULL,
	[F9] [nvarchar](255) NULL,
	[F10] [nvarchar](255) NULL,
	[F11] [nvarchar](255) NULL,
	[F12] [nvarchar](255) NULL,
	[F13] [nvarchar](255) NULL,
	[F14] [nvarchar](255) NULL,
	[F15] [nvarchar](255) NULL,
	[F16] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SaleDocList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SaleDocList](
	[DocID] [bigint] IDENTITY(1,1) NOT NULL,
	[SaleID] [bigint] NOT NULL,
	[DocName] [varchar](250) NOT NULL,
	[Remarks] [varchar](250) NULL,
 CONSTRAINT [PK_SaleDocList] PRIMARY KEY CLUSTERED 
(
	[DocID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ContactDetail](
	[ContactID] [bigint] IDENTITY(1,1) NOT NULL,
	[ContactType] [smallint] NOT NULL CONSTRAINT [DF_ContactDetail_ContactType]  DEFAULT ((0)),
	[RefID] [bigint] NOT NULL,
	[ContactTitle] [varchar](10) NULL,
	[ContactName] [varchar](50) NOT NULL,
	[Designation] [varchar](50) NOT NULL,
	[Phone1] [varchar](20) NOT NULL,
	[Phone2] [varchar](20) NULL,
	[Mobile] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[DoB] [datetime] NULL,
	[DoA] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_ContactDetail] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ContactDetail', N'COLUMN',N'ContactType'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = Vendor, 1 = Customer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContactDetail', @level2type=N'COLUMN',@level2name=N'ContactType'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customer](
	[CustomerID] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountID] [bigint] NULL,
	[Code] [varchar](20) NULL,
	[Name] [varchar](100) NULL,
	[Address1] [varchar](100) NULL,
	[Address2] [varchar](100) NULL,
	[CityID] [bigint] NULL,
	[Pincode] [varchar](20) NULL,
	[Phone1] [varchar](20) NULL,
	[Phone2] [varchar](20) NULL,
	[Fax] [varchar](150) NULL,
	[Mobile] [varchar](20) NULL,
	[TinNo] [varchar](20) NULL,
	[CSTNo] [varchar](20) NULL,
	[PANo] [varchar](20) NULL,
	[EccNo] [varchar](20) NULL,
	[CreditDays] [int] NULL,
	[Range] [varchar](50) NULL,
	[Division] [varchar](50) NULL,
	[IsAccount] [bigint] NULL CONSTRAINT [DF_Customer_IsAccount]  DEFAULT ((0)),
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[NextFollowUpDate] [datetime] NULL,
	[LeadId] [int] NULL,
	[ContactPerson] [nvarchar](250) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ServiceDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ServiceDetails](
	[ServiceDetailID] [bigint] IDENTITY(1,1) NOT NULL,
	[SIID] [bigint] NULL,
	[ItemID] [bigint] NULL,
	[ItemDesc] [varchar](100) NULL,
	[Qty] [decimal](18, 3) NULL,
	[Rate] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
	[TaxClassID] [bigint] NULL,
	[ServiceRate] [decimal](5, 2) NULL,
	[ServiceAmount] [decimal](18, 2) NULL,
	[ExciseRate] [decimal](5, 2) NULL,
	[ExciseAmount] [decimal](18, 2) NULL,
	[CessRate] [decimal](5, 2) NULL,
	[CessAmount] [decimal](18, 2) NULL,
	[HCessRate] [decimal](5, 2) NULL,
	[HCessAmount] [decimal](18, 2) NULL,
	[AmountAfterExcise] [decimal](18, 2) NULL,
	[CSTRate] [decimal](5, 2) NULL,
	[CSTAmount] [decimal](5, 2) NULL,
	[VATRate] [decimal](5, 2) NULL,
	[VATAmount] [decimal](18, 2) NULL,
	[AVATRate] [decimal](5, 2) NULL,
	[AVATAmount] [decimal](18, 2) NULL,
	[NetAmount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ServiceDetails] PRIMARY KEY CLUSTERED 
(
	[ServiceDetailID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Get_Privilage_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		PRIYANKA JADAV
-- Create date: 24/02/2015
-- Description:	GET PRIVILAGE LIST BY USER
-- =============================================
create PROCEDURE [dbo].[usp_Get_Privilage_List]
	-- Add the parameters for the stored procedure here
	@i_RecID bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Gen_UserScope WHERE UserID=@i_RecID
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetPrivilege_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
 
-- Description:	Sp is used for gettling all privilege list.
-- =============================================

/* For Exceucte Manually 
	
	DECLARE	@return_value int

	EXEC	@return_value = [dbo].[usp_GetPrivilege_List]

	SELECT	''Return Value'' = @return_value

*/

create PROCEDURE [dbo].[usp_GetPrivilege_List]


AS
BEGIN
	SET NOCOUNT ON;
	WITH Privileges (Caption,PrivilegeID,ParentID,MainID,Level )
	AS
	(

		SELECT Caption,PrivilegeID,ParentID,PrivilegeID,1 AS Level
		FROM Gen_Privilege 
		WHERE Level=1
		UNION ALL

		SELECT gp.Caption,gp.PrivilegeID,gp.ParentID,gp.PrivilegeID,p.Level + 1
		FROM Gen_Privilege gp
			INNER JOIN Privileges AS p
			ON p.PrivilegeID = gp.ParentID
	)
	-- Statement that executes the CTE
	SELECT Caption,PrivilegeID,ParentID,
		Case Level 
				When 2 Then 0
				Else ParentID End as MainID,Level
	FROM Gen_Privilege Where Level<>1
 
END













' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetParentPrivilege_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		 
-- Create date:  
-- Description:	Sp is used for getting parent privilege list.
-- =============================================

/* For Excecute Manually
	
	DECLARE	@return_value int

	EXEC	@return_value = [dbo].[usp_GetParentPrivilege_List]
			@i_ParentID = 1

	SELECT	''Return Value'' = @return_value

*/

create PROCEDURE [dbo].[usp_GetParentPrivilege_List]
	@i_ParentID Bigint
AS
BEGIN
	SELECT	
		PrivilegeID
	FROM 	
		Gen_Privilege
	WHERE 
		ParentID = @i_ParentID;

END









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee](
	[EmpID] [bigint] IDENTITY(1,1) NOT NULL,
	[EmpName] [varchar](150) NOT NULL,
	[Address] [varchar](250) NULL,
	[PhoneNo] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[Department] [varchar](50) NULL,
	[Salary] [decimal](18, 0) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[CompId] [bigint] NULL,
	[Company] [varchar](100) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetSelectedPrivilegeList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
 
-- Description:	Sp is used for fetch inserted privilege list from
--              user scope table. 
-- =============================================

/* For Excecute Manually

	DECLARE	@return_value int

	EXEC	@return_value = [dbo].[usp_GetSelectedPrivilegeList]
			@i_UserID = 1

	SELECT	''Return Value'' = @return_value
*/


create PROCEDURE [dbo].[usp_GetSelectedPrivilegeList]
	@i_UserID Bigint
AS
BEGIN
		
		Select 
			PrivilegeID 
		From 
			Gen_UserScope
		Where 
			UserID = @i_UserID
	

END










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddressDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AddressDetail](
	[AddressDetID] [bigint] IDENTITY(1,1) NOT NULL,
	[AddressType] [smallint] NOT NULL CONSTRAINT [DF_Table_1_ContactType]  DEFAULT ((0)),
	[RefID] [bigint] NOT NULL,
	[Address1] [varchar](150) NOT NULL,
	[Address2] [varchar](150) NULL,
	[CityID] [bigint] NOT NULL,
	[Pincode] [varchar](20) NULL,
	[Phone1] [varchar](20) NOT NULL,
	[Phone2] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[Mobile] [varchar](20) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_AddressDetail] PRIMARY KEY CLUSTERED 
(
	[AddressDetID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AddressDetail', N'COLUMN',N'AddressType'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = Vendor, 1 = Customer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AddressDetail', @level2type=N'COLUMN',@level2name=N'AddressType'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create FUNCTION [dbo].[Split]
(
	@RowData varchar(max),
	@SplitOn nvarchar(5)
)  
RETURNS @RtnValue table 
(
	Id int identity(1,1),
	Data nvarchar(100)
) 
AS  
BEGIN 
	Declare @Cnt int
	Set @Cnt = 1

	While (Charindex(@SplitOn,@RowData)>0)
	Begin
		Insert Into @RtnValue (data)
		Select 
			Data = ltrim(rtrim(Substring(@RowData,1,Charindex(@SplitOn,@RowData)-1)))

		Set @RowData = Substring(@RowData,Charindex(@SplitOn,@RowData)+1,len(@RowData))
		Set @Cnt = @Cnt + 1
	End
	
	Insert Into @RtnValue (data)
	
		Select Convert (Bigint,ltrim(rtrim(@RowData))) as Data
	Return
END













' 
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Quotation_All_TNC_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Quotation_All_TNC_Insert]
	-- Add the parameters for the stored procedure here
	@i_Code nvarchar(50),
	@i_TNC_SUB nvarchar(150),
	@i_TNC_Desc nvarchar(255)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--delete from Quotation_TNC where Code=@i_Code
	INSERT INTO Quotation_TNC (Code,TNC_Sub,TNC_Desc) VALUES(@i_Code,@i_TNC_Sub,@i_TNC_Desc)
	
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gen_Privilege]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Gen_Privilege](
	[PrivilegeID] [bigint] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Caption] [varchar](100) NOT NULL,
	[ParentID] [bigint] NOT NULL,
	[Level] [tinyint] NOT NULL,
 CONSTRAINT [PK_Gen_Privilege] PRIMARY KEY CLUSTERED 
(
	[PrivilegeID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SysSettings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SysSettings](
	[Path_Data] [varchar](500) NOT NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Revised_old]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Revised_old] 
--	@i_RecID Bigint
  @i_PiNo nvarchar(50)

AS
BEGIN
	SET NOCOUNT ON;
Declare @i_Position bigint
Declare @i_Reverse bigint
Declare @l_MaxNo bigint;
Declare @l_FinalCode nvarchar(50);

if len(@i_PiNo)<= 11
begin 
select @i_PiNo= @i_PiNo + ''-R1'';
end
else if len(@i_PiNo)>11
begin
--select @l_MaxNo= ( select right(@i_PiNo,1));
set @i_Reverse = (select substring(reverse(@i_PiNo),0,(select charindex(''R'',reverse(@i_PiNo)))))
set @i_Position= convert(bigint,(select reverse(convert (nvarchar(10),@i_Reverse)))) 
set @l_MaxNo   = @i_Position  + 1;
select @i_PiNo= (select substring(@i_PiNo,0,12)+ ''-R''+ CAST(@l_MaxNo as nvarchar(50))) 
end

Select  @l_FinalCode  = @i_PiNo 
Select  isnull(@l_FinalCode,1);
end









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gen_UserScope]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Gen_UserScope](
	[UserPrivilegeID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NULL,
	[PrivilegeID] [bigint] NULL,
 CONSTRAINT [PK_Gen_UserScope] PRIMARY KEY CLUSTERED 
(
	[UserPrivilegeID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PODocList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PODocList](
	[QDocID] [bigint] IDENTITY(1,1) NOT NULL,
	[PIID] [bigint] NOT NULL,
	[DocName] [varchar](250) NOT NULL,
	[Remarks] [varchar](250) NULL,
 CONSTRAINT [PK_PODocList] PRIMARY KEY CLUSTERED 
(
	[QDocID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Email]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Email](
	[Email_ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[Subject] [nvarchar](max) NULL,
	[Header] [nvarchar](max) NULL,
	[Footer] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[CompId] [bigint] NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[Email_ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[test]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[test](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_test] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trgItemN]'))
EXEC dbo.sp_executesql @statement = N'create trigger [dbo].[trgItemN] on [dbo].[test]
After delete
as
declare @ID int;
declare @Name nvarchar(50);
select @ID=id from deleted;
select @Name=Name from deleted;


insert into test_BAK(ID,Name) values(@ID,@Name);

' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[test_BAK]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[test_BAK](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_test_BAK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_Sales_TNC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[rpt_Sales_TNC]
	-- Add the parameters for the stored procedure here
	@i_Code as nvarchar(50),
	@i_TNC_Sub as nvarchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT    TNC_Desc
FROM         Sales_TNC
WHERE Code=@i_Code AND TNC_Sub=@i_TNC_Sub
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QuotationDocList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[QuotationDocList](
	[QDocID] [bigint] IDENTITY(1,1) NOT NULL,
	[QuotationID] [bigint] NOT NULL,
	[DocName] [varchar](250) NOT NULL,
	[Remarks] [varchar](250) NULL,
 CONSTRAINT [PK_QuotationDocList] PRIMARY KEY CLUSTERED 
(
	[QDocID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_User_ActiveDeactive]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for active or deactive user.
-- =============================================
 
Create PROCEDURE [dbo].[usp_User_ActiveDeactive]
	@i_UserID Bigint,
	@i_ActivateID Bigint
AS
BEGIN

	UPDATE	
		Gen_User
	SET 	
		IsActive = @i_ActivateID
	WHERE	
		UserID = @i_UserID;

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PromoMail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PromoMail](
	[PromoMailID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Header] [nvarchar](max) NULL,
	[Footer] [nvarchar](max) NULL,
	[FileCount] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[CompId] [bigint] NULL,
 CONSTRAINT [PK_PromoMail] PRIMARY KEY CLUSTERED 
(
	[PromoMailID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QuotationPaymentDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[QuotationPaymentDetail](
	[QPaymentID] [bigint] IDENTITY(1,1) NOT NULL,
	[QuotationId] [bigint] NOT NULL,
	[NextDate] [datetime] NOT NULL,
	[Payment] [decimal](18, 0) NOT NULL,
	[Remarks] [varchar](250) NULL,
	[ReceivePayment] [decimal](18, 0) NULL,
 CONSTRAINT [PK_QuotationPaymentDetail] PRIMARY KEY CLUSTERED 
(
	[QPaymentID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_User_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for delete record from user table.
-- =============================================
 CREATE PROCEDURE [dbo].[usp_User_Delete]

	@i_RecID bigint,
	
	@o_ErrorMesg varchar(500) OUTPUT
	
AS
	SET @o_ErrorMesg='''';
BEGIN
	SET NOCOUNT ON;

	
	Delete From Gen_User WHERE UserID = @i_RecID

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UserList_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Sp is used for bind User List combo box.
-- =============================================
create PROCEDURE [dbo].[usp_UserList_DDL]
	
AS
BEGIN
 
	SET NOCOUNT ON;

    Select 
		UserID,
		Name as UserName
	From 
		Gen_User Where IsActive=1
	Order By 
		Name;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AccountType](
	[AccTypeID] [bigint] NOT NULL,
	[AcountType] [varchar](25) NOT NULL,
 CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED 
(
	[AccTypeID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_POVsGRN_Register]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Roshni Patel
-- Create date: 23rd Jan 2011
-- Description:	Report of Purchase Invoice
-- =============================================
CREATE PROCEDURE [dbo].[rpt_POVsGRN_Register]
	@i_FYID BIGINT 
AS
BEGIN
	SET NOCOUNT ON;
SELECT   PO.PIID,
         PO.PurchaseCode,
	     Vendor.Name AS VendorName,
		 Item.Code AS ItemCode,
		 Item.Name ItemDesc,
		 PODetail.Rate,
		 PODetail.Qty AS OQty,
		 0 AS DQty,
         0 AS Diff,
         0 AS OrdValue,
         0 AS SupplyValue,  
		 0 AS diff1  ,     
		 PurchaseInvoice.PurchaseCode AS GRNCode            
FROM     PO
         LEFT JOIN
         PurchaseInvoiceDetail
         LEFT JOIN
         PurchaseInvoice
         ON PurchaseInvoice.PIID=PurchaseInvoiceDetail.PIID 
         ON PurchaseInvoice.PGID=PO.PIID 
         LEFT JOIN
         Vendor
         ON Vendor.VendorID=PO.VendorID 
         LEFT JOIN
         Item
         ON Item.ItemID=PurchaseInvoiceDetail.ItemID 
         LEFT JOIN
         PODetail
         ON PODetail.PIID=PO.PIID 
WHERE    PO.FYID = @i_FYID

--	SELECT PO.PIID,
--		PO.PurchaseCode,
--		PO.PurchaseDate,
--		PO.VoucherNo,
--		PO.VoucherDate,
--		PO.VendorID,
--		Vendor.Code,		
--		Vendor.[Name] as VendorName,
--		PO.DueDays,
--		PO.DueDate,
--		PO.TotalAmount,
--		PO.ExciseAmount,
--		PO.CessAmount,
--		PO.HCessAmount,
--		PO.AmountAfterExcise,
--		PO.CSTAmount,
--		PO.VATAmount,
--		PO.AVATAmount,
--		PO.Discount,
--		PO.NetAmount,
--		PO.Narration
--  FROM PO
--		Inner Join Vendor On Vendor.VendorID = PO.VendorID
--	WHERE PO.FYID = @i_FYID
--	Order By PO.PurchaseDate,PO.PurchaseCode Desc

END





set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesInvoice]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SalesInvoice](
	[SIID] [bigint] IDENTITY(1,1) NOT NULL,
	[FYID] [bigint] NULL,
	[SalesCode] [varchar](20) NULL,
	[SalesDate] [datetime] NULL,
	[DCNO] [varchar](20) NULL,
	[DCDate] [datetime] NULL,
	[CustomerID] [bigint] NULL,
	[DueDays] [bigint] NULL CONSTRAINT [DF_SalesInvoice_DueDays]  DEFAULT ((0)),
	[DueDate] [datetime] NULL,
	[TotalAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoice_TotalAmount]  DEFAULT ((0.00)),
	[ServiceAmount] [decimal](18, 2) NULL,
	[ExciseAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoice_ExciseAmount]  DEFAULT ((0.00)),
	[CessAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoice_CessAmount]  DEFAULT ((0.00)),
	[HCessAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoice_HCessAmount]  DEFAULT ((0.00)),
	[AmountAfterExcise] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoice_AmountAfterExcise]  DEFAULT ((0.00)),
	[CSTAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoice_CSTAmount]  DEFAULT ((0.00)),
	[VATAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoice_VATAmount]  DEFAULT ((0.00)),
	[AVATAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoice_AVATAmount]  DEFAULT ((0.00)),
	[Discount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoice_Discount]  DEFAULT ((0.00)),
	[TotalDiscAmt] [decimal](18, 2) NULL,
	[NetAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoice_NetAmount]  DEFAULT ((0.00)),
	[Narration] [varchar](250) NULL,
	[PaidAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoice_PaidAmount]  DEFAULT ((0.00)),
	[SrNo] [varchar](50) NULL,
	[GoDownID] [int] NULL,
	[InstallationDate] [datetime] NULL,
	[ReminderDate] [datetime] NULL,
	[NoofServices] [int] NULL,
	[TypeOfSale] [nvarchar](50) NULL,
	[EmpID] [int] NULL,
	[ExtraCharges] [decimal](18, 2) NULL,
	[ExtraChargesType] [nvarchar](255) NULL,
	[TIN] [nvarchar](50) NULL,
	[RecDay] [int] NULL,
	[Type] [nvarchar](50) NULL,
	[ExtraReminder] [nvarchar](500) NULL,
	[dtExtraReminder] [datetime] NULL,
	[ShippingAdd] [nvarchar](100) NULL,
	[BONO] [nvarchar](250) NULL,
	[BODate] [datetime] NULL,
	[DNote] [nvarchar](250) NULL,
	[DNoteDate] [datetime] NULL,
	[SuRNo] [nvarchar](250) NULL,
	[DDNo] [nvarchar](250) NULL,
	[DT] [varchar](250) NULL,
	[D] [nvarchar](250) NULL,
	[DtI] [datetime] NULL,
	[TI] [nvarchar](50) NULL,
	[DtR] [datetime] NULL,
	[TR] [nvarchar](50) NULL,
	[CC] [nvarchar](max) NULL,
	[BCC] [nvarchar](max) NULL,
	[ExtraChargesType2] [nvarchar](255) NULL,
	[ExtraCharges2] [decimal](18, 2) NULL,
	[ExtraChargesType3] [nvarchar](255) NULL,
	[ExtraCharges3] [decimal](18, 2) NULL,
	[CustInvoiceNo] [nvarchar](50) NULL,
	[EmpAllToID] [int] NULL,
	[IsPaid] [bit] NULL,
	[CompId] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[UserID] [bigint] NULL,
 CONSTRAINT [PK_SalesInvoice] PRIMARY KEY CLUSTERED 
(
	[SIID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_Service_TNC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_Service_TNC]
	-- Add the parameters for the stored procedure here
	@i_Code as nvarchar(50),
	@i_TNC_Sub as nvarchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT    TNC_Desc
FROM         Services_TNC
WHERE Code=@i_Code AND TNC_Sub=@i_TNC_Sub
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_LeadFollowUp_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	List of LeadFollowUp
-- =============================================
CREATE PROCEDURE [dbo].[usp_LeadFollowUp_List]
--[usp_LeadFollowUp_List] ''25''
	 @i_LeadID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 			
		LeadFollowUpId,
		NextFollowupDate as FollowupDate,
		Gen_User.Name as FollowupByName,
		Remarks
  FROM LeadFollowUp
		Inner Join Gen_User ON Gen_User.UserID = LeadFollowUp.FollowupBy
	Where LeadID = @i_LeadID
	Order By NextFollowupDate
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ServicesTNC_Delete_On_Close]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ServicesTNC_Delete_On_Close]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub nvarchar(250),
	@i_Code nvarchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

DELETE FROM Services_TNC WHERE Code=@i_Code AND TNC_Sub=@i_TNC_Sub 

	

END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SalesTNC_Delete_On_Close]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SalesTNC_Delete_On_Close]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub nvarchar(250),
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

DELETE FROM Sales_TNC WHERE Code=@i_Code AND TNC_Sub=@i_TNC_Sub 

	

END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_QuotationTNC_Delete_On_Close]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_QuotationTNC_Delete_On_Close]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub nvarchar(250),
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

DELETE FROM Quotation_TNC WHERE Code=@i_Code AND TNC_Sub=@i_TNC_Sub 

	

END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerMain]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerMain](
	[CustomerID] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountID] [bigint] NULL,
	[CustomerCode] [varchar](20) NOT NULL,
	[CustomerName] [varchar](150) NULL,
	[Address] [varchar](150) NULL,
	[CityID] [bigint] NULL,
	[AreaID] [int] NULL,
	[Pincode] [varchar](50) NULL,
	[Phone1] [varchar](12) NULL,
	[MobileNo] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[Website] [nvarchar](250) NULL,
	[ContactPerson] [nvarchar](250) NULL,
	[EmpID] [int] NULL,
	[AllocatedToEmpID] [int] NULL,
	[Category] [nvarchar](50) NULL,
	[IsAccount] [bigint] NULL CONSTRAINT [DF_CustomerMain_IsAccount]  DEFAULT ((0)),
	[Specification] [varchar](250) NULL,
	[Remarks] [varchar](max) NULL,
	[CreditDays] [int] NULL,
	[Name1] [nvarchar](50) NULL,
	[Name2] [nvarchar](50) NULL,
	[Name3] [nvarchar](50) NULL,
	[Name4] [nvarchar](50) NULL,
	[Name5] [nvarchar](50) NULL,
	[Name6] [nvarchar](50) NULL,
	[Value1] [nvarchar](50) NULL,
	[Value2] [nvarchar](50) NULL,
	[Value3] [nvarchar](50) NULL,
	[Value4] [nvarchar](50) NULL,
	[Value5] [nvarchar](50) NULL,
	[Value6] [nvarchar](50) NULL,
	[CompId] [bigint] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_CustomerMain] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Import_Vendor_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_Import_Vendor_List]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TEMP_VENDOR
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Import_Lead_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Import_Lead_List]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TEMP_LEAD
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Import_Customer_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Import_Customer_List]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TEMP_CUSTOMER
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Import_Item_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_Import_Item_List]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TEMP_Item
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Country_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for bind country combo box.
-- =============================================
Create PROCEDURE [dbo].[usp_Country_DDL]
	
AS
BEGIN
 
	SET NOCOUNT ON;

    Select 
		CountryID,
		Name 
	From 
		Gen_Country
	Order By 
		Name;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Select_Max_Code_Vendor]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Select_Max_Code_Vendor] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MAX(VENDORID) FROM VENDOR

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Country_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select Country record
-- =============================================
Create PROCEDURE [dbo].[usp_Country_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		 Name as CountryName
	FROM
		Gen_Country
	WHERE
		CountryID = @i_RecID 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Select_Max_Code_Lead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Select_Max_Code_Lead] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MAX(LEADNO) FROM LEAD


END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Country_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Delete record from Country 
-- =============================================
 Create PROCEDURE [dbo].[usp_Country_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	
	DELETE FROM Gen_Country
		WHERE CountryID = @i_RecID ;
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Select_Max_Code]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Select_Max_Code] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MAX(CUSTOMERID) FROM CUSTOMER
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerFollowUp]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerFollowUp](
	[CustomerFollowUpId] [bigint] IDENTITY(1,1) NOT NULL,
	[LeadID] [bigint] NOT NULL,
	[NextFollowupDate] [datetime] NOT NULL,
	[FollowupBy] [bigint] NOT NULL,
	[Remarks] [varchar](max) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_CustomerFollowUp] PRIMARY KEY CLUSTERED 
(
	[CustomerFollowUpId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Select_Max_Code_Item]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Select_Max_Code_Item] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MAX(CODE) FROM ITEM
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PromoMailDocList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PromoMailDocList](
	[DocID] [bigint] IDENTITY(1,1) NOT NULL,
	[PromoMailID] [bigint] NULL,
	[DocName] [nvarchar](250) NULL,
	[Remarks] [nvarchar](250) NULL,
 CONSTRAINT [PK_PromoMailDocList] PRIMARY KEY CLUSTERED 
(
	[DocID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Select_CityID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Select_CityID]
	-- Add the parameters for the stored procedure here
	@i_City nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     CityID FROM Gen_City WHERE Name=@i_City
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CompanyInfo](
	[CompId] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyCode] [varchar](50) NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[BusinessLine] [varchar](50) NULL,
	[Address1] [varchar](150) NOT NULL,
	[Address2] [varchar](150) NULL,
	[CityName] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Pincode] [varchar](50) NULL,
	[Phone1] [varchar](15) NOT NULL,
	[Phone2] [varchar](15) NULL,
	[Mobile] [varchar](15) NULL,
	[Fax] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[ReportPath] [varchar](250) NULL,
	[DocPath] [varchar](250) NULL,
	[Con_Email] [nvarchar](50) NULL,
	[Con_Password] [nvarchar](50) NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[Host] [nvarchar](50) NULL,
	[Port] [int] NULL,
	[ssl] [int] NULL,
	[Logo] [nvarchar](max) NULL,
	[Header] [nvarchar](max) NULL,
	[Footer] [nvarchar](max) NULL,
	[Name1] [nvarchar](50) NULL,
	[Name2] [nvarchar](50) NULL,
	[Name3] [nvarchar](50) NULL,
	[Name4] [nvarchar](50) NULL,
	[Name5] [nvarchar](50) NULL,
	[Name6] [nvarchar](50) NULL,
	[Value1] [nvarchar](50) NULL,
	[Value2] [nvarchar](50) NULL,
	[Value3] [nvarchar](50) NULL,
	[Value4] [nvarchar](50) NULL,
	[Value5] [nvarchar](50) NULL,
	[Value6] [nvarchar](50) NULL,
	[Com_Profile] [nvarchar](max) NULL,
	[BackupDBName] [nvarchar](50) NULL,
 CONSTRAINT [PK_CompanyInfo] PRIMARY KEY CLUSTERED 
(
	[CompId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[insert_Demo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[insert_Demo]
(
	@name nvarchar(50)
)
as
begin
	insert into demotry(name) values(@name)
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[demotry]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[demotry](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_demotry] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TNCSub_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	List of TaxClass for Combo
-- =============================================
CREATE PROCEDURE [dbo].[usp_TNCSub_DDL]
	--@i_TNC_Sub varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT DISTINCT     TNC_Sub
FROM         TermsNConditions
--where TNC_Sub=@i_TNC_Sub
		


END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Vendor_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for bind Vendor lov.
-- =============================================
CREATE PROCEDURE [dbo].[usp_Vendor_LOV]
	 
AS
BEGIN
	 SET NOCOUNT ON;

    SELECT     VendorID, Name AS VendorName, Fax, Address1+ Address2 as Address, Mobile
FROM         Vendor
ORDER BY VendorName
--SELECT PO.PurchaseCode, PO.PurchaseDate, PO.VoucherNo, Vendor.Name AS VendorName, PO.VoucherDate, Godown.Godown_name AS GodownName, 
--               Vendor.VendorID
--FROM  PO INNER JOIN
--               Vendor ON PO.VendorID = Vendor.VendorID INNER JOIN
--               Godown ON PO.GodownID = Godown.GodownID

END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Temp_Lead]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Temp_Lead](
	[LEAD_DATE] [datetime] NULL,
	[CUSTOMER_NAME] [nvarchar](255) NULL,
	[ADDRESS] [nvarchar](255) NULL,
	[CITY] [nvarchar](255) NULL,
	[PINCODE] [nvarchar](255) NULL,
	[PHONE1] [nvarchar](255) NULL,
	[MOBILE] [nvarchar](255) NULL,
	[EMAIL] [nvarchar](255) NULL,
	[LNAME1] [nvarchar](255) NULL,
	[LNAME2] [nvarchar](255) NULL,
	[LVALUE1] [nvarchar](255) NULL,
	[LVALUE2] [nvarchar](255) NULL,
	[LDTNAME1] [nvarchar](255) NULL,
	[LDTNAME2] [nvarchar](255) NULL,
	[CONTACT_PERSON] [nvarchar](255) NULL,
	[SOURCE_OF_INQUIRY] [nvarchar](255) NULL,
	[INTERAST_LEVEL] [nvarchar](255) NULL,
	[NEXT_FOLLOWUP_DATE] [datetime] NULL,
	[CUSTOMER_BUDGET] [nvarchar](255) NULL,
	[SPECIFICATION] [nvarchar](255) NULL,
	[REMARKS] [nvarchar](255) NULL,
	[QUOTATION_SEND] [datetime] NULL,
	[WEBSITE] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Quotation_Contact]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Quotation_Contact](
	[Q_ContactD_ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[RefID] [bigint] NULL,
	[ContactType] [nvarchar](50) NULL,
	[ContactID] [bigint] NULL,
	[ContactTitle] [nvarchar](500) NULL,
	[ContactName] [nvarchar](500) NULL,
	[Designation] [nvarchar](500) NULL,
	[Phone1] [nvarchar](50) NULL,
	[Phone2] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DoB] [nvarchar](50) NULL,
	[DoA] [nvarchar](50) NULL,
	[CompId] [bigint] NULL,
 CONSTRAINT [PK_Quotation_Contact] PRIMARY KEY CLUSTERED 
(
	[Q_ContactD_ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Quotation_All_TNC_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [dbo].[usp_Quotation_All_TNC_Update]
	-- Add the parameters for the stored procedure here
	@i_Code nvarchar(50),
	@i_TNC_SUB nvarchar(150),
	@i_TNC_Desc nvarchar(255)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Quotation_TNC where Code=@i_Code
	INSERT INTO Quotation_TNC (Code,TNC_Sub,TNC_Desc) VALUES(@i_Code,@i_TNC_Sub,@i_TNC_Desc)
	
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Temp_Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Temp_Customer](
	[COMPANY] [nvarchar](255) NULL,
	[CONTACTPERSON] [nvarchar](255) NULL,
	[ADDRESS1] [nvarchar](255) NULL,
	[ADDRESS2] [nvarchar](255) NULL,
	[CITY] [nvarchar](255) NULL,
	[PINCODE] [nvarchar](255) NULL,
	[PHONE1] [nvarchar](255) NULL,
	[PHONE2] [nvarchar](255) NULL,
	[EMAIL] [nvarchar](255) NULL,
	[MOBILE] [nvarchar](255) NULL,
	[TINNO] [nvarchar](255) NULL,
	[CSTNO] [nvarchar](255) NULL,
	[PANO] [nvarchar](255) NULL,
	[ECCNO] [nvarchar](255) NULL,
	[RANGE] [nvarchar](255) NULL,
	[DIVISION] [nvarchar](255) NULL,
	[CREADITDAYS] [nvarchar](255) NULL,
	[TRANSDATE] [datetime] NULL,
	[CRAMOUNT] [nvarchar](255) NULL,
	[DBAMOUNT] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QuotationFollowup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[QuotationFollowup](
	[QuotationFollowupID] [int] IDENTITY(1,1) NOT NULL,
	[QuotationID] [int] NULL,
	[FollowupDate] [datetime] NULL,
	[FollowupBy] [int] NULL,
	[Remarks] [nvarchar](250) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_QuotationFollowup] PRIMARY KEY CLUSTERED 
(
	[QuotationFollowupID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Temp_Vendor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Temp_Vendor](
	[COMPANY] [nvarchar](255) NULL,
	[ADDRESS1] [nvarchar](255) NULL,
	[ADDRESS2] [nvarchar](255) NULL,
	[CITY] [nvarchar](255) NULL,
	[PINCODE] [nvarchar](255) NULL,
	[PHONE1] [nvarchar](255) NULL,
	[PHONE2] [nvarchar](255) NULL,
	[EMAIL] [nvarchar](255) NULL,
	[MOBILE] [nvarchar](255) NULL,
	[TINNO] [nvarchar](255) NULL,
	[CSTNO] [nvarchar](255) NULL,
	[PANO] [nvarchar](255) NULL,
	[ECCNO] [nvarchar](255) NULL,
	[RANGE] [nvarchar](255) NULL,
	[DIVISION] [nvarchar](255) NULL,
	[CREADITDAYS] [nvarchar](255) NULL,
	[TRANSDATE] [datetime] NULL,
	[CRAMOUNT] [nvarchar](255) NULL,
	[DBAMOUNT] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PromoMail_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Delete record from Employee 
-- =============================================
 CREATE PROCEDURE [dbo].[usp_PromoMail_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	
	DELETE FROM PromoMail
		WHERE PromoMailID = @i_RecID ;
		
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_State_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Delete record from State 
-- =============================================
Create PROCEDURE [dbo].[usp_State_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	
	DELETE FROM Gen_State
		WHERE StateID = @i_RecID ;
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QuotationDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[QuotationDetail](
	[QDetailID] [bigint] IDENTITY(1,1) NOT NULL,
	[SIID] [int] NULL,
	[ItemID] [int] NULL,
	[ItemDesc] [varchar](max) NULL,
	[Qty] [decimal](18, 3) NULL,
	[Rate] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
	[TaxClassID] [bigint] NULL,
	[ServiceRate] [decimal](5, 2) NULL,
	[ServiceAmount] [decimal](18, 2) NULL,
	[ExciseRate] [decimal](5, 2) NULL,
	[ExciseAmount] [decimal](18, 2) NULL,
	[CessRate] [decimal](5, 2) NULL,
	[CessAmount] [decimal](18, 2) NULL,
	[HCessRate] [decimal](5, 2) NULL,
	[HCessAmount] [decimal](18, 2) NULL,
	[AmountAfterExcise] [decimal](18, 2) NULL,
	[CSTRate] [decimal](5, 2) NULL,
	[CSTAmount] [decimal](18, 2) NULL,
	[VATRate] [decimal](5, 2) NULL,
	[VATAmount] [decimal](18, 2) NULL,
	[AVATRate] [decimal](5, 2) NULL,
	[AVATAmount] [decimal](18, 2) NULL,
	[NetAmount] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[GodownID] [int] NULL,
 CONSTRAINT [PK_QuotationDetail] PRIMARY KEY CLUSTERED 
(
	[QDetailID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_State_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select State record
-- =============================================
Create PROCEDURE [dbo].[usp_State_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		
		 Name as StateName 
	FROM
		Gen_State
	WHERE
		StateID = @i_RecID 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sale_Contact]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sale_Contact](
	[S_ContactD_ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[RefID] [bigint] NULL,
	[ContactType] [nvarchar](50) NULL,
	[ContactID] [bigint] NULL,
	[ContactTitle] [nvarchar](500) NULL,
	[ContactName] [nvarchar](500) NULL,
	[Designation] [nvarchar](500) NULL,
	[Phone1] [nvarchar](50) NULL,
	[Phone2] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DoB] [nvarchar](50) NULL,
	[DoA] [nvarchar](50) NULL,
	[CompId] [bigint] NULL,
 CONSTRAINT [PK_Sale_Contact] PRIMARY KEY CLUSTERED 
(
	[S_ContactD_ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_QuotationTNC_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_QuotationTNC_Delete]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub nvarchar(250),
	@i_Code nvarchar(50),
	@i_TNC_Desc nvarchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

DELETE FROM Quotation_TNC WHERE Code=@i_Code AND TNC_Sub=@i_TNC_Sub AND TNC_Desc=@i_TNC_Desc

	

END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_City_GetStateCountry]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Get State and Country from City
-- =============================================
 
Create PROCEDURE [dbo].[usp_City_GetStateCountry]
	@i_RecID bigint
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT
		Gen_State.Name as State, 
		Gen_Country.Name AS Country
	FROM
		Gen_City INNER JOIN
		Gen_State ON Gen_City.StateID = Gen_State.StateID INNER JOIN
		Gen_Country ON Gen_State.CountryID = Gen_Country.CountryID
	WHERE
		Gen_City.CityID = @i_RecID

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Revised]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Revised] 
--	@i_RecID Bigint
  @i_PiNo nvarchar(50)

AS
BEGIN
	SET NOCOUNT ON;
Declare @i_Position bigint
Declare @i_Reverse bigint
Declare @l_MaxNo bigint;
Declare @l_FinalCode nvarchar(50);

if len(@i_PiNo)<= 17
begin 
select @i_PiNo= @i_PiNo + ''-R1'';
end
else if len(@i_PiNo)>17
begin
--select @l_MaxNo= ( select right(@i_PiNo,1));
set @i_Reverse = (select substring(reverse(@i_PiNo),0,(select charindex(''R'',reverse(@i_PiNo)))))
set @i_Position= convert(bigint,(select reverse(convert (nvarchar(10),@i_Reverse)))) 
set @l_MaxNo   = @i_Position  + 1;
select @i_PiNo= (select substring(@i_PiNo,0,18)+ ''-R''+ CAST(@l_MaxNo as nvarchar(50))) 
end

Select  @l_FinalCode  = @i_PiNo 
Select  isnull(@l_FinalCode,1);
end



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Service_Contact]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Service_Contact](
	[SE_ContactD_ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[RefID] [bigint] NULL,
	[ContactType] [nvarchar](50) NULL,
	[ContactID] [bigint] NULL,
	[ContactTitle] [nvarchar](500) NULL,
	[ContactName] [nvarchar](500) NULL,
	[Designation] [nvarchar](500) NULL,
	[Phone1] [nvarchar](50) NULL,
	[Phone2] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DoB] [nvarchar](50) NULL,
	[DoA] [nvarchar](50) NULL,
	[CompId] [bigint] NULL,
 CONSTRAINT [PK_Service_Contact] PRIMARY KEY CLUSTERED 
(
	[SE_ContactD_ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_State_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of State
-- =============================================
Create PROCEDURE [dbo].[usp_State_List]
	@i_CountryID bigint	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		StateID,
		Name as StateName
	FROM
		Gen_State
	WHERE
		CountryID = @i_CountryID
	ORDER BY
		Name
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ServicesTNC_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_ServicesTNC_Delete]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub nvarchar(250),
	@i_Code nvarchar(50),
	@i_TNC_Desc nvarchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

DELETE FROM Services_TNC WHERE Code=@i_Code AND TNC_Sub=@i_TNC_Sub AND TNC_Desc=@i_TNC_Desc

	

END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_PO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author: Manoj Savalia
-- Create date: 24th Jan 2011
-- Description: Select record from PO and PODetail
-- change history:
-- =============================================

create PROCEDURE [dbo].[rpt_PO]
	@i_RecID Bigint
AS
BEGIN
	-- DECLARE @l_Date DATETIME;
	--
	-- SET @l_Date = (SELECT Convert(DateTime,(SELECT PurchaseDate FROM PO WHERE PIID = @i_RecID),5));

	--Select Record from IGMS_PO table
SELECT     PO.PurchaseCode, PO.PurchaseDate, PO.VoucherNo, PO.VoucherDate, PO.TotalAmount, PO.ExciseAmount, PO.CessAmount, PO.HCessAmount, PO.AmountAfterExcise, 
                      PO.CSTAmount, PO.VATAmount, PO.AVATAmount, PO.Discount, PO.NetAmount, PO.PaidAmount, PO.VendorID, Vendor.Code AS VendorCode, Vendor.Name AS Vendor, 
                      Vendor.Address1, Vendor.Address2, Vendor.Mobile AS Phone1, Vendor.Pincode, Gen_City.Name AS City, Gen_State.Name + '','' + Gen_Country.Name + '','' AS State, 
                      PO.Narration, PODetail.ItemID, PODetail.Qty, PODetail.Rate, PODetail.Amount, Item.Name + '' ('' + Item.Specification + '')'' AS ItemName, Gen_UOM.Name AS UOM, 
                      Vendor.TinNo, Vendor.CSTNo, Vendor.PANo, Vendor.EccNo, TaxClass.TaxClassID, TaxClass.Name AS TaxClass, PO.ServiceAmount as ServiceTax
FROM         PO INNER JOIN
                      PODetail ON PODetail.PIID = PO.PIID INNER JOIN
                      Item ON Item.ItemID = PODetail.ItemID INNER JOIN
                      Gen_UOM ON Gen_UOM.UOMID = Item.CUOMID INNER JOIN
                      Vendor ON Vendor.VendorID = PO.VendorID INNER JOIN
                      Gen_City ON Gen_City.CityID = Vendor.CityID INNER JOIN
                      Gen_State ON Gen_State.StateID = Gen_City.StateID INNER JOIN
                      Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID INNER JOIN
                      TaxClass ON PODetail.TaxClassID = TaxClass.TaxClassID
WHERE
		PO.PIID=@i_RecID 
 
End







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Item]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Item](
	[ItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemClassID] [bigint] NULL,
	[CategoryID] [bigint] NULL,
	[Code] [varchar](20) NULL,
	[Name] [varchar](max) NULL,
	[OtherName] [varchar](100) NULL,
	[Specification] [varchar](max) NULL,
	[CUOMID] [bigint] NULL,
	[Length] [decimal](12, 3) NULL,
	[Width] [decimal](12, 3) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[Moving] [int] NULL,
	[UsedIn] [nvarchar](250) NULL,
	[Price] [decimal](18, 2) NULL,
	[HSNCode] [nvarchar](150) NULL,
	[ProductCode] [nvarchar](150) NULL,
	[StockID] [bigint] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_PODetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Roshni Patel
-- Create date: 23rd Jan 2011
-- Description:	Detail Report of Purchase Invoice
-- =============================================
create PROCEDURE [dbo].[rpt_PODetail]
	@i_PIID BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT PO.PIID,
		PO.PurchaseCode,
		PO.PurchaseDate,
		PO.VoucherNo,
		PO.VoucherDate,
		PO.VendorID,
		Vendor.Code,		
		Vendor.[Name] as VendorName,
		PO.DueDays,
		PO.DueDate,
		PO.TotalAmount,
		PO.ExciseAmount,
		PO.CessAmount,
		PO.HCessAmount,
		PO.AmountAfterExcise,
		PO.CSTAmount,
		PO.VATAmount,
		PO.AVATAmount,
		PO.Discount,
		PO.NetAmount,
		PO.Narration,
		PODetail.ItemID,
		PODetail.Qty,	
		PODetail.Rate,
		PODetail.Amount,
		Item.Name as ItemName,
		Gen_UOM.Name As UOM,
		TaxClass.Name AS TaxClass,
		PODetail.ExciseRate,
		PODetail.ExciseAmount As DetExciseAmount,
		PODetail.CessRate,
		PODetail.CessAmount As DetCessAmount,
		PODetail.HCessRate,
		PODetail.HCessAmount AS DetHCessAmount,
		PODetail.AmountAfterExcise AS DetAmountAfterExcise,
		PODetail.CSTRate,
		PODetail.CSTAmount AS DetCSTAmount,
		PODetail.VATRate,
		PODetail.VATAmount AS DetVATAmount,
		PODetail.AVATRate,
		PODetail.AVATAmount AS DetAVATAmount,
		PODetail.NetAmount AS DetNEtAMount,
		PODetail.TaxClassID,
		PODetail.PIDetailID
  FROM PO
		Inner Join Vendor On Vendor.VendorID = PO.VendorID
		INNER JOIN PODetail on PODetail.PIID = PO.PIID
		INNER JOIN Item  ON Item.ItemID = PODetail.ItemID
		INNER JOIN Gen_UOM on Gen_UOM.UOMID = Item.CUOMID
		INNER JOIN TaxClass ON TaxClass.TaxClassID = PODetail.TaxClassID
	--WHERE TaxClass.TaxClassID in(2,3)	 --AND PO.PIID = @i_PIID

END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_Purchase_TNC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[rpt_Purchase_TNC]
	-- Add the parameters for the stored procedure here
	@i_Code as nvarchar(50),
	@i_TNC_Sub as nvarchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT    TNC_Desc
FROM         Purchase_TNC
WHERE Code=@i_Code AND TNC_Sub=@i_TNC_Sub
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountTransaction]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AccountTransaction](
	[TransactionTypeID] [bigint] NOT NULL,
	[TransactionType] [varchar](100) NOT NULL,
 CONSTRAINT [PK_AccountTransaction] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Quotation_TNC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Quotation_TNC](
	[Q_TNC_ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[TNC_Sub] [nvarchar](250) NULL,
	[TNC_Desc] [nvarchar](max) NULL,
	[TNCID] [int] NULL,
	[CompId] [bigint] NULL,
 CONSTRAINT [PK_Quotation_TNC] PRIMARY KEY CLUSTERED 
(
	[Q_TNC_ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FinancialYear]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FinancialYear](
	[FYID] [bigint] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_FinancialYear] PRIMARY KEY CLUSTERED 
(
	[FYID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Email_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Email_Delete]
@i_RecID bigint,
	@o_ErrorMesg varchar(500) OUTPUT
AS
BEGIN
SET @o_ErrorMesg='''';
	SET NOCOUNT ON;

  Delete From Email WHERE Email_ID = @i_RecID;
	
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TermsNConditions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TermsNConditions](
	[TNCID] [int] IDENTITY(1,1) NOT NULL,
	[TNC_Sub] [nvarchar](150) NULL,
	[TNC_Desc] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[CompId] [bigint] NULL,
 CONSTRAINT [PK_TermsNConditions] PRIMARY KEY CLUSTERED 
(
	[TNCID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_SalesInvoiceRegister]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Roshni Patel
-- Create date: 23rd Jan 2011
-- Description:	Report of Sales Invoice
-- =============================================
CREATE PROCEDURE [dbo].[rpt_SalesInvoiceRegister]
	@i_FYID BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT SalesInvoice.SIID,
		SalesInvoice.SalesCode,
		SalesInvoice.SalesDate,
		SalesInvoice.DCNo,
		SalesInvoice.DCDate,
		SalesInvoice.CustomerID,
		LEAD.LEADNO AS CODE,		
		LEAD.CUSTOMERNAME as CustomerName,
		SalesInvoice.DueDays,
		SalesInvoice.DueDate,
		SalesInvoice.TotalAmount,
		SalesInvoice.ExciseAmount,
		SalesInvoice.CessAmount,
		SalesInvoice.HCessAmount,
		SalesInvoice.AmountAfterExcise,
		SalesInvoice.CSTAmount,
		SalesInvoice.VATAmount,
		SalesInvoice.AVATAmount,
		SalesInvoice.Discount,
		SalesInvoice.NetAmount,
		SalesInvoice.Narration
  FROM SalesInvoice
		LEFT Join LEAD On LEAD.LEADID = SalesInvoice.CustomerID
	WHERE SalesInvoice.FYID = @i_FYID
	Order By SalesInvoice.SalesDate,SalesInvoice.SalesCode Desc

END





set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemStockDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemStockDetail](
	[StockDetailID] [bigint] IDENTITY(1,1) NOT NULL,
	[StockID] [bigint] NOT NULL,
	[GTID] [bigint] NOT NULL,
	[RefID] [bigint] NULL,
	[Date] [datetime] NOT NULL,
	[Description] [varchar](max) NULL,
	[Qty] [decimal](18, 3) NOT NULL,
 CONSTRAINT [PK_ItemStockDetail] PRIMARY KEY CLUSTERED 
(
	[StockDetailID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ItemStockDetail', N'COLUMN',N'RefID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'it could be null in case of ''opening stock"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ItemStockDetail', @level2type=N'COLUMN',@level2name=N'RefID'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemCategory](
	[CategoryID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ItemGroupID] [bigint] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_ItemCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vendor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Vendor](
	[VendorID] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountID] [bigint] NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address1] [varchar](100) NOT NULL,
	[Address2] [varchar](100) NULL,
	[CityID] [bigint] NOT NULL,
	[Pincode] [varchar](20) NOT NULL,
	[Phone1] [varchar](20) NOT NULL,
	[Phone2] [varchar](20) NULL,
	[Fax] [varchar](5000) NULL,
	[Mobile] [varchar](20) NULL,
	[TinNo] [varchar](20) NULL,
	[CSTNo] [varchar](20) NULL,
	[PANo] [varchar](20) NULL,
	[EccNo] [varchar](20) NULL,
	[CreditDays] [int] NULL,
	[Range] [varchar](50) NULL,
	[Division] [varchar](50) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gen_Area]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Gen_Area](
	[AreaID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CityID] [bigint] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Gen_Area] PRIMARY KEY CLUSTERED 
(
	[AreaID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gen_State]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Gen_State](
	[StateID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CountryID] [bigint] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Gen_State] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gen_City]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Gen_City](
	[CityID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[StateID] [bigint] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PODetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PODetail](
	[PIDetailID] [bigint] IDENTITY(1,1) NOT NULL,
	[PIID] [bigint] NOT NULL,
	[ItemID] [bigint] NOT NULL,
	[Qty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PODetail_Qty]  DEFAULT ((0.000)),
	[Rate] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PODetail_Rate]  DEFAULT ((0.00)),
	[Amount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PODetail_Amount]  DEFAULT ((0.00)),
	[TaxClassID] [bigint] NOT NULL,
	[ExciseRate] [decimal](5, 2) NOT NULL CONSTRAINT [DF_PODetail_ExciseRate]  DEFAULT ((0.00)),
	[ExciseAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PODetail_ExciseAmount]  DEFAULT ((0.00)),
	[CessRate] [decimal](5, 2) NOT NULL CONSTRAINT [DF_PODetail_CessRate]  DEFAULT ((0.00)),
	[CessAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PODetail_CessAmount]  DEFAULT ((0.00)),
	[HCessRate] [decimal](5, 2) NOT NULL CONSTRAINT [DF_PODetail_HCessRate]  DEFAULT ((0.00)),
	[HCessAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PODetail_HCessAmount]  DEFAULT ((0.00)),
	[AmountAfterExcise] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PODetail_AmountAfterExcise]  DEFAULT ((0.00)),
	[CSTRate] [decimal](5, 2) NOT NULL CONSTRAINT [DF_PODetail_CSTRate]  DEFAULT ((0.00)),
	[CSTAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PODetail_CSTAmount]  DEFAULT ((0.00)),
	[VATRate] [decimal](5, 2) NOT NULL CONSTRAINT [DF_PODetail_VATRate]  DEFAULT ((0.00)),
	[VATAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PODetail_VATAmount]  DEFAULT ((0.00)),
	[AVATRate] [decimal](5, 2) NOT NULL CONSTRAINT [DF_PODetail_AVATRate]  DEFAULT ((0.00)),
	[AVATAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PODetail_AVATAmount]  DEFAULT ((0.00)),
	[NetAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PODetail_NetAmount]  DEFAULT ((0.00)),
	[ServiceRate] [decimal](5, 2) NULL,
	[ServiceAmount] [decimal](18, 2) NULL,
	[DDate] [datetime] NULL,
 CONSTRAINT [PK_PODetail] PRIMARY KEY CLUSTERED 
(
	[PIDetailID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lead]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Lead](
	[LeadId] [bigint] IDENTITY(1,1) NOT NULL,
	[LeadNo] [varchar](20) NOT NULL,
	[LeadDate] [datetime] NULL,
	[CustomerName] [varchar](150) NULL,
	[Address] [varchar](150) NULL,
	[CityID] [bigint] NULL,
	[Pincode] [varchar](50) NULL,
	[Phone1] [varchar](12) NULL,
	[MobileNo] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[SourceOfLead] [varchar](50) NULL,
	[CustomerBudget] [decimal](18, 0) NULL,
	[InterestLevel] [varchar](20) NULL,
	[NextFollowUpDate] [datetime] NULL,
	[Specification] [varchar](250) NULL,
	[Remarks] [varchar](max) NULL,
	[LeadStatusID] [bigint] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[AccountID] [bigint] NULL,
	[Quotation_Send] [bit] NULL,
	[ContactPerson] [nvarchar](250) NULL,
	[AreaID] [int] NULL,
	[EmpID] [int] NULL,
	[Website] [nvarchar](250) NULL,
	[Name1] [nvarchar](50) NULL,
	[Name2] [nvarchar](50) NULL,
	[Name3] [nvarchar](50) NULL,
	[Name4] [nvarchar](50) NULL,
	[Name5] [nvarchar](50) NULL,
	[Name6] [nvarchar](50) NULL,
	[Value1] [nvarchar](50) NULL,
	[Value2] [nvarchar](50) NULL,
	[Value3] [nvarchar](50) NULL,
	[Value4] [nvarchar](50) NULL,
	[Value5] [nvarchar](50) NULL,
	[Value6] [nvarchar](50) NULL,
	[AllocatedToEmpID] [int] NULL,
	[Category] [nvarchar](50) NULL,
	[Inquiry_AutoResponse] [bit] NULL,
	[CompId] [bigint] NULL,
 CONSTRAINT [PK_Lead] PRIMARY KEY CLUSTERED 
(
	[LeadId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IndentDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[IndentDetail](
	[PIDetailID] [bigint] IDENTITY(1,1) NOT NULL,
	[PIID] [bigint] NOT NULL,
	[ItemID] [bigint] NOT NULL,
	[Qty] [decimal](18, 3) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_Qty]  DEFAULT ((0.000)),
	[Rate] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_Rate]  DEFAULT ((0.00)),
	[Amount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_Amount]  DEFAULT ((0.00)),
	[TaxClassID] [bigint] NOT NULL,
	[ExciseRate] [decimal](5, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_ExciseRate]  DEFAULT ((0.00)),
	[ExciseAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_ExciseAmount]  DEFAULT ((0.00)),
	[CessRate] [decimal](5, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_CessRate]  DEFAULT ((0.00)),
	[CessAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_CessAmount]  DEFAULT ((0.00)),
	[HCessRate] [decimal](5, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_HCessRate]  DEFAULT ((0.00)),
	[HCessAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_HCessAmount]  DEFAULT ((0.00)),
	[AmountAfterExcise] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_AmountAfterExcise]  DEFAULT ((0.00)),
	[CSTRate] [decimal](5, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_CSTRate]  DEFAULT ((0.00)),
	[CSTAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_CSTAmount]  DEFAULT ((0.00)),
	[VATRate] [decimal](5, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_VATRate]  DEFAULT ((0.00)),
	[VATAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_VATAmount]  DEFAULT ((0.00)),
	[AVATRate] [decimal](5, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_AVATRate]  DEFAULT ((0.00)),
	[AVATAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_AVATAmount]  DEFAULT ((0.00)),
	[NetAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoiceDetail_NetAmount]  DEFAULT ((0.00)),
	[ServiceRate] [decimal](5, 2) NULL,
	[ServiceAmount] [decimal](18, 2) NULL,
	[RemainingQty] [decimal](18, 3) NULL,
	[ReceivedQty] [decimal](18, 3) NULL,
	[DDate] [datetime] NULL,
 CONSTRAINT [PK_PurchaseInvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[PIDetailID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesInvoiceDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SalesInvoiceDetail](
	[SIDetailID] [bigint] IDENTITY(1,1) NOT NULL,
	[SIID] [bigint] NULL,
	[ItemID] [bigint] NULL,
	[ItemDesc] [varchar](max) NULL,
	[Qty] [decimal](18, 3) NULL CONSTRAINT [DF_SalesInvoiceDetail_Qty]  DEFAULT ((0.000)),
	[Rate] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_Rate]  DEFAULT ((0.00)),
	[Amount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_Amount]  DEFAULT ((0.00)),
	[TaxClassID] [bigint] NULL,
	[ServiceRate] [decimal](5, 2) NULL,
	[ServiceAmount] [decimal](18, 2) NULL,
	[ExciseRate] [decimal](5, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_ExciseRate]  DEFAULT ((0.00)),
	[ExciseAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_ExciseAmount]  DEFAULT ((0.00)),
	[CessRate] [decimal](5, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_CessRate]  DEFAULT ((0.00)),
	[CessAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_CessAmount]  DEFAULT ((0.00)),
	[HCessRate] [decimal](5, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_HCessRate]  DEFAULT ((0.00)),
	[HCessAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_HCessAmount]  DEFAULT ((0.00)),
	[AmountAfterExcise] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_AmountAfterExcise]  DEFAULT ((0.00)),
	[CSTRate] [decimal](5, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_CSTRate]  DEFAULT ((0.00)),
	[CSTAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_CSTAmount]  DEFAULT ((0.00)),
	[VATRate] [decimal](5, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_VATRate]  DEFAULT ((0.00)),
	[VATAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_VATAmount]  DEFAULT ((0.00)),
	[AVATRate] [decimal](5, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_AVATRate]  DEFAULT ((0.00)),
	[AVATAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_AVATAmount]  DEFAULT ((0.00)),
	[NetAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SalesInvoiceDetail_NetAmount]  DEFAULT ((0.00)),
	[Discount] [decimal](18, 2) NULL,
	[DiscountAmt] [decimal](18, 2) NULL,
	[GodownID] [int] NULL,
 CONSTRAINT [PK_SalesInvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[SIDetailID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReceiptDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReceiptDetail](
	[RecDetID] [bigint] IDENTITY(1,1) NOT NULL,
	[ReceiptID] [bigint] NOT NULL,
	[SIID] [bigint] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_ReceiptDetail_Amount]  DEFAULT ((0.000)),
 CONSTRAINT [PK_ReceiptDetail] PRIMARY KEY CLUSTERED 
(
	[RecDetID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PaymentDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PaymentDetail](
	[PayDetID] [bigint] IDENTITY(1,1) NOT NULL,
	[PaymentID] [bigint] NOT NULL,
	[PIID] [bigint] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PaymentDetail_Amount]  DEFAULT ((0.000)),
 CONSTRAINT [PK_PaymentDetail] PRIMARY KEY CLUSTERED 
(
	[PayDetID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ServiceModule]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ServiceModule](
	[ServiceId] [bigint] IDENTITY(1,1) NOT NULL,
	[RequestNo] [varchar](20) NOT NULL,
	[ServiceDate] [datetime] NULL,
	[CustomerID] [bigint] NULL,
	[CustomerName] [varchar](150) NULL,
	[Address] [varchar](500) NULL,
	[MobileNo] [varchar](20) NULL,
	[ProductName] [varchar](50) NULL,
	[ModelNumber] [varchar](50) NULL,
	[Problem] [varchar](500) NULL,
	[AttendedBy] [bigint] NULL,
	[JobComputed] [varchar](500) NULL,
	[Remarks] [varchar](500) NULL,
	[OtherRequirement] [varchar](500) NULL,
	[Charges] [decimal](18, 0) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[SIID] [bigint] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[ServiceAmount] [decimal](18, 2) NULL,
	[ExciseAmount] [decimal](18, 2) NULL,
	[CessAmount] [decimal](18, 2) NULL,
	[HCessAmount] [decimal](18, 2) NULL,
	[AmountAfterExcise] [decimal](18, 2) NULL,
	[CSTAmount] [decimal](18, 2) NULL,
	[VATAmount] [decimal](18, 2) NULL,
	[AVATAmount] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[NetAmount] [decimal](18, 2) NULL,
	[PaidAmount] [decimal](18, 2) NULL,
	[FYID] [bigint] NULL,
	[GodownID] [int] NULL,
	[CallID] [int] NULL,
	[TypeOfSale] [nvarchar](50) NULL,
	[EmpAllToID] [bigint] NULL,
	[Status] [nvarchar](50) NULL,
	[CompId] [bigint] NULL,
	[UserID] [bigint] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ledger]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Ledger](
	[LedgerID] [bigint] IDENTITY(1,1) NOT NULL,
	[FYID] [bigint] NOT NULL,
	[AccountID] [bigint] NOT NULL,
	[TransactionTypeID] [bigint] NOT NULL,
	[TransactionID] [bigint] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[CRAmount] [decimal](18, 3) NOT NULL,
	[DBAmount] [decimal](18, 3) NOT NULL,
	[Narration] [varchar](250) NULL,
 CONSTRAINT [PK_Ledger] PRIMARY KEY CLUSTERED 
(
	[LedgerID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OpeningBalance]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OpeningBalance](
	[OPBalID] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountID] [bigint] NOT NULL,
	[FYID] [bigint] NOT NULL,
	[CRAmount] [decimal](18, 3) NOT NULL CONSTRAINT [DF_FAS_OpeningBalance_CRAmount]  DEFAULT ((0)),
	[DBAmount] [decimal](18, 3) NOT NULL CONSTRAINT [DF_FAS_OpeningBalance_DBAmount]  DEFAULT ((0)),
 CONSTRAINT [PK_OpeningBalance] PRIMARY KEY CLUSTERED 
(
	[OPBalID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Payment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Payment](
	[PaymentID] [bigint] IDENTITY(1,1) NOT NULL,
	[PaymentCode] [varchar](20) NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[VendorID] [bigint] NOT NULL,
	[Narration] [varchar](250) NULL,
	[NetAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_Payment_NetAmount]  DEFAULT ((0.000)),
	[BankName] [varchar](150) NULL,
	[ChequeNo] [varchar](50) NULL,
	[ChequeDate] [datetime] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Indent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Indent](
	[PIID] [bigint] IDENTITY(1,1) NOT NULL,
	[FYID] [bigint] NOT NULL,
	[PurchaseCode] [varchar](20) NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[VoucherNo] [varchar](20) NULL,
	[VoucherDate] [datetime] NULL,
	[VendorID] [bigint] NOT NULL,
	[DueDays] [bigint] NOT NULL CONSTRAINT [DF_PurchaseInvoice_DueDays]  DEFAULT ((0)),
	[DueDate] [datetime] NOT NULL,
	[TotalAmount] [decimal](18, 2) NULL CONSTRAINT [DF_PurchaseInvoice_TotalAmount]  DEFAULT ((0.00)),
	[ExciseAmount] [decimal](18, 2) NULL CONSTRAINT [DF_Table_1_BrokerRate]  DEFAULT ((0.00)),
	[CessAmount] [decimal](18, 2) NULL CONSTRAINT [DF_Table_1_OtherCharges]  DEFAULT ((0.00)),
	[HCessAmount] [decimal](18, 2) NULL CONSTRAINT [DF_Table_1_CessAmount1]  DEFAULT ((0.00)),
	[AmountAfterExcise] [decimal](18, 2) NULL CONSTRAINT [DF_PurchaseInvoice_AmountAfterExcise]  DEFAULT ((0.00)),
	[CSTAmount] [decimal](18, 2) NULL CONSTRAINT [DF_Table_1_CessAmount1_1]  DEFAULT ((0.00)),
	[VATAmount] [decimal](18, 2) NULL CONSTRAINT [DF_Table_1_CSTAmount1]  DEFAULT ((0.00)),
	[AVATAmount] [decimal](18, 2) NULL CONSTRAINT [DF_Table_1_CSTAmount1_1]  DEFAULT ((0.00)),
	[Discount] [decimal](18, 2) NULL CONSTRAINT [DF_PurchaseInvoice_Discount]  DEFAULT ((0.00)),
	[NetAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoice_NetAmount]  DEFAULT ((0.00)),
	[Narration] [varchar](250) NULL,
	[PaidAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PurchaseInvoice_PaidAmount]  DEFAULT ((0.00)),
	[SrNo] [varchar](50) NULL,
	[ServiceAmount] [decimal](18, 2) NULL,
	[GodownID] [int] NULL,
	[PGID] [bigint] NULL,
	[AgainstCForm] [bit] NULL,
 CONSTRAINT [PK_PurchaseInvoice] PRIMARY KEY CLUSTERED 
(
	[PIID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Account](
	[AccountID] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountCode] [varchar](20) NOT NULL,
	[AccountName] [varchar](100) NOT NULL,
	[AccCreatedDate] [datetime] NOT NULL,
	[AccTypeID] [bigint] NOT NULL CONSTRAINT [DF_Account_AccTypeID]  DEFAULT ((1)),
 CONSTRAINT [PK_FAS_Account] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemAdjustment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemAdjustment](
	[AdjustmentID] [bigint] IDENTITY(1,1) NOT NULL,
	[FYID] [bigint] NOT NULL,
	[AdjustDate] [datetime] NOT NULL,
	[ItemID] [bigint] NOT NULL,
	[Qty] [decimal](18, 3) NOT NULL,
	[Narration] [varchar](200) NOT NULL,
	[IsConfirmed] [bit] NOT NULL CONSTRAINT [DF_ItemAdjustment_IsConfirmed]  DEFAULT ((0)),
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsAuthorised] [tinyint] NULL CONSTRAINT [DF_ItemAdjustment_IsAuthorised]  DEFAULT ((0)),
	[GodownID] [int] NULL,
 CONSTRAINT [PK_ItemAdjustment] PRIMARY KEY CLUSTERED 
(
	[AdjustmentID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ItemAdjustment', N'COLUMN',N'IsConfirmed'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' 0 = Not Confirmed (default)
 1 = Confirmed' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ItemAdjustment', @level2type=N'COLUMN',@level2name=N'IsConfirmed'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemDetail](
	[ItemDetailID] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemID] [bigint] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Rate] [decimal](12, 3) NOT NULL,
	[VAT] [decimal](12, 3) NOT NULL,
	[IsArchieve] [smallint] NOT NULL CONSTRAINT [DF_ItemDetail_IsArchive]  DEFAULT ((0)),
 CONSTRAINT [PK_ItemDetail] PRIMARY KEY CLUSTERED 
(
	[ItemDetailID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ItemDetail', N'COLUMN',N'IsArchieve'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Default 0, 0=No,1=Yes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ItemDetail', @level2type=N'COLUMN',@level2name=N'IsArchieve'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemStock]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemStock](
	[StockID] [bigint] IDENTITY(1,1) NOT NULL,
	[FYID] [bigint] NULL,
	[ItemID] [bigint] NULL,
	[QOH] [decimal](18, 3) NULL,
	[MinLevel] [decimal](18, 3) NULL CONSTRAINT [DF_ItemStock_MinLevel]  DEFAULT ((0.000)),
	[MaxLevel] [decimal](18, 3) NULL CONSTRAINT [DF_ItemStock_MaxLevel]  DEFAULT ((0.000)),
	[ReorderLvl] [decimal](18, 3) NULL,
	[Location] [varchar](100) NULL,
	[RackNo] [varchar](100) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[GodownID] [int] NULL,
 CONSTRAINT [PK_ItemStock] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expense]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Expense](
	[ExpenseID] [bigint] IDENTITY(1,1) NOT NULL,
	[FYID] [bigint] NOT NULL,
	[ExpNo] [varchar](20) NOT NULL,
	[ExpAccountID] [bigint] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Amount] [decimal](15, 3) NOT NULL,
	[Narration] [varchar](250) NULL,
 CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED 
(
	[ExpenseID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_DBInitialize]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Description:	The Procedure is useful to insert default records into tables
-- Change History:
-- Sr #	Date			Changed By		Change Note
-- Exec [proc_DBInitialize] 1,1
-- =============================================
--
--select * from Gen_Country
--select * from Gen_State
--select * from Gen_City
--select * from Gen_Area
--truncate table Gen_Country
--truncate table Gen_State
--truncate table Gen_City
--truncate table Gen_Area

CREATE PROCEDURE [dbo].[proc_DBInitialize] 
	@isDelete bit = 0,
	@isInsert bit = 0
AS
BEGIN
	IF @isDelete = 1
	BEGIN
		DECLARE @reseed int
		--Ledger
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Ledger'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Ledger, RESEED, @reseed)
		Delete from Ledger	

--		-- Bank 
--		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Bank'') > 1 THEN 0 ELSE 1 END
--		DBCC CHECKIDENT(Bank, RESEED, @reseed)
--		Delete from Bank

		-- Email 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Email'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Email, RESEED, @reseed)
		Delete from Email

--		-- Expense_Master 
--		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Expense_Master'') > 1 THEN 0 ELSE 1 END
--		DBCC CHECKIDENT(Expense_Master, RESEED, @reseed)
--		Delete from Expense_Master

		-- TypeOfCall 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''TypeOfCall'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(TypeOfCall, RESEED, @reseed)
		Delete from TypeOfCall

--		-- PODetail 
--		SELECT @reseed = CASE WHEN IDENT_CURRENT(''PODetail'') > 1 THEN 0 ELSE 1 END
--		DBCC CHECKIDENT(PODetail, RESEED, @reseed)
--		Delete from PODetail
--
--		-- PO 
--		SELECT @reseed = CASE WHEN IDENT_CURRENT(''PO'') > 1 THEN 0 ELSE 1 END
--		DBCC CHECKIDENT(PO, RESEED, @reseed)
--		Delete from PO


		-- ServiceDetails 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''ServiceDetails'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(ServiceDetails, RESEED, @reseed)
		Delete from ServiceDetails

		-- SaleDocList 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''SaleDocList'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(SaleDocList, RESEED, @reseed)
		Delete from SaleDocList

		-- Sales_Service_Reminder 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Sales_Service_Reminder'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Sales_Service_Reminder, RESEED, @reseed)
		Delete from Sales_Service_Reminder


		-- Quotation_TNC 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Quotation_TNC'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Quotation_TNC, RESEED, @reseed)
		Delete from Quotation_TNC

		-- QuotationPaymentDetail 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''QuotationPaymentDetail'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(QuotationPaymentDetail, RESEED, @reseed)
		Delete from QuotationPaymentDetail

		-- QuotationFollowup 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''QuotationFollowup'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(QuotationFollowup, RESEED, @reseed)
		Delete from QuotationFollowup

		-- QuotationDocList 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''QuotationDocList'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(QuotationDocList, RESEED, @reseed)
		Delete from QuotationDocList

		-- QuotationDetail 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''QuotationDetail'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(QuotationDetail, RESEED, @reseed)
		Delete from QuotationDetail

		-- Quotation 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Quotation'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Quotation, RESEED, @reseed)
		Delete from Quotation

		-- Sales_TNC 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Sales_TNC'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Sales_TNC, RESEED, @reseed)
		Delete from Sales_TNC
		
		-- Services_TNC 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Services_TNC'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Services_TNC, RESEED, @reseed)
		Delete from Services_TNC

		-- TermsNConditions
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''TermsNConditions'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(TermsNConditions, RESEED, @reseed)
		Delete from TermsNConditions

		-- ReceiptDetail
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''ReceiptDetail'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(ReceiptDetail, RESEED, @reseed)
		Delete from ReceiptDetail

		-- Receipt
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Receipt'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Receipt, RESEED, @reseed)
		Delete from Receipt

		-- PaymentDetail
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''PaymentDetail'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(PaymentDetail, RESEED, @reseed)
		Delete from PaymentDetail

		-- Payment
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Payment'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Payment, RESEED, @reseed)
		Delete from Payment

		--OpeningBalance
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''OpeningBalance'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(OpeningBalance, RESEED, @reseed)
		Delete from OpeningBalance	

		--Expense
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Expense'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Expense, RESEED, @reseed)
		Delete from Expense	

		-- SalesInvoiceDetail
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''SalesInvoiceDetail'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(SalesInvoiceDetail, RESEED, @reseed)
		Delete from SalesInvoiceDetail

		-- SalesInvoice
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''SalesInvoice'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(SalesInvoice, RESEED, @reseed)
		Delete from SalesInvoice

		-- PurchaseInvoiceDetail
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''PurchaseInvoiceDetail'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(PurchaseInvoiceDetail, RESEED, @reseed)
		Delete from PurchaseInvoiceDetail

		-- PurchaseInvoice
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''PurchaseInvoice'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(PurchaseInvoice, RESEED, @reseed)
		Delete from PurchaseInvoice

		-- ItemAdjustment
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''ItemAdjustment'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(ItemAdjustment, RESEED, @reseed)
		Delete from ItemAdjustment		
 
		-- ItemStockDetail
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''ItemStockDetail'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(ItemStockDetail, RESEED, @reseed)
		Delete from ItemStockDetail

		-- ItemStock 
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''ItemStock'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(ItemStock, RESEED, @reseed)
		Delete from ItemStock
   
		-- AddressDetail
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''AddressDetail'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(AddressDetail, RESEED, @reseed)
		Delete from AddressDetail

		-- ContactDetail
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''ContactDetail'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(ContactDetail, RESEED, @reseed)
		Delete from ContactDetail

		--ItemDetail
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''ItemDetail'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(ItemDetail, RESEED, @reseed)
		Delete from ItemDetail
		-- LeadFollowUp
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''LeadFollowUp'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(LeadFollowUp, RESEED, @reseed)
		Delete from LeadFollowUp

		-- Lead
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Lead'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Lead, RESEED, @reseed)
		Delete from Lead
		
		--ServiceModule
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''ServiceModule'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(ServiceModule, RESEED, @reseed)
		Delete from ServiceModule

		--Employee
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Employee'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Employee, RESEED, @reseed)
		Delete from Employee

		--TaxClass
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''TaxClass'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(TaxClass, RESEED, @reseed)
		Delete from TaxClass

		--Account
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Account'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Account, RESEED, @reseed)
		Delete from Account

		-- Vendor
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Vendor'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Vendor, RESEED, @reseed)
		Delete from Vendor

		-- Customer
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Customer'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Customer, RESEED, @reseed)
		Delete from Customer

		-- Item
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Item'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Item, RESEED, @reseed)
		Delete from Item

		--ItemCategory
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''ItemCategory'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(ItemCategory, RESEED, @reseed)
		Delete from ItemCategory

		--ItemClass
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''ItemClass'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(ItemClass, RESEED, @reseed)
		Delete from ItemClass

		--ItemGroup
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''ItemGroup'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(ItemGroup, RESEED, @reseed)
		Delete from ItemGroup

		--Gen_UOM
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Gen_UOM'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Gen_UOM, RESEED, @reseed)
		Delete from Gen_UOM
	
		--Gen_Area
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Gen_Area'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Gen_Area, RESEED, @reseed)
		Delete from Gen_Area
		
		-- Gen_City
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Gen_City'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Gen_City, RESEED, @reseed)
		Delete from Gen_City

		-- Gen_State
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Gen_State'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Gen_State, RESEED, @reseed)
		Delete from Gen_State
 
		-- Gen_Country
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Gen_Country'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Gen_Country, RESEED, @reseed)
		Delete from Gen_Country
 
		-- FinancialYear
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''FinancialYear'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(FinancialYear, RESEED, @reseed)
		Delete from FinancialYear

		-- Gen_User
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''Gen_User'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(Gen_User, RESEED, @reseed)
		Delete from Gen_User

		-- CompanyInfo
		SELECT @reseed = CASE WHEN IDENT_CURRENT(''CompanyInfo'') > 1 THEN 0 ELSE 1 END
		DBCC CHECKIDENT(CompanyInfo, RESEED, @reseed)
		Delete from CompanyInfo

		

		-- GoodsTransaction
		Delete From GoodsTransaction
		--ExceptionLog
		Delete from ExceptionLog
		--Gen_ErrorMsg
		Delete from Gen_ErrorMsg
		--VersionInfo
		Delete From VersionInfo
		--AccountTransaction
		Delete From AccountTransaction
		-- AccountType
		Delete From AccountType
		--LeadStatus
		Delete from LeadStatus
	End


	IF @IsInsert = 1
	BEGIN
		--: FinancialYear
	 
		SET IDENTITY_INSERT FinancialYear ON

		INSERT INTO FinancialYear (FYID, StartDate, EndDate, CreatedBy, CreatedDate) VALUES (1, ''2014-01-01'', ''2016-01-15'', 1, ''2016-01-15'')

		SET IDENTITY_INSERT FinancialYear OFF
	
	--: CompanyInfo
	 
		SET IDENTITY_INSERT CompanyInfo ON

		INSERT INTO CompanyInfo(CompId,CompanyCode,CompanyName,       Address1,                  Address2,    CityName, Pincode,     Phone1,       Phone2   ,      Mobile,           Fax,              Email,                    ReportPath,DocPath,Con_Email,Con_Password,ModifiedBy,ModifiedDate,Host,Port,ssl,Logo,Header,Footer,Name1,Name2,Name3,Name4,Name5,Name6,Value1,Value2,Value3,Value4,Value5,Value6,Com_Profile,BackupDBName)
						VALUES (1,''JP'',''JP Infoweb Solutions Pvt. Ltd.'','''','','',''VADODARA'',''390 016'','''','''','''','''','''',''E:\Current Project\JP Baroda\JPERP_NONAC\Reports\'','''',''abc@example.com'',''123456'',null,null,''smtp.gmail.com'',25,0,''D:\EXCHANGE\logo'',''D:\EXCHANGE\header'',''D:\EXCHANGE\footer'',''CST NO'',''VAT'',''PAN'',''SERVICE TAX'',''CO REG NO'',''OTHER NO'',''DSF85DFDF'',''654DFDF45F'',''AJDPA4578N'',''464841'',''ADF4554EDDSFER445646'',''FASFSDF27546456468'',''We are located at mangalkirti apt. fatehgunj'',''JP_MasterDB'')

		SET IDENTITY_INSERT CompanyInfo OFF
		 
	 	--: Gen_ErrorMsg
		 
		--Select ''Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(''+ Convert(varchar,ErrorNo) + '',''''''+ ErrorMsg +'''''')'' from Gen_ErrorMsg
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(101,''User name or password is wrong'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(102,''Please update your old version'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(103,''Old password is incorrect'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(104,''User is deactive'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(105,''Current record''''s status is changed'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(1001,''User name exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(3001,''Country name exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(4001,''State name exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(5001,''City name exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(6001,''Area name exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(7001,''Account Name is Already Exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(7002,''Account Code is Already Exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(7003,''Acount is associated with Ledger'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(7004,''Account is associated with Opening Balance'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(7005,''You can not delete this account'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(8001,''Item group name exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(8003,''Customer is associated with Ledger'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(8004,''Customer is associated with OpeningBalance'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(8005,''Bank is associated with Ledger'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(9001,''Item class name exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(10000,''There is some error in complete transaction'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(10001,''Item category name exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(11001,''UOM name exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(12001,''Tax class exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(13001,''Item code exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(13002,''Item name exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(14001,''Lead Code is Already Exist'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(20001,''Payment code exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(21001,''Receipt code exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(22001,''Expense code exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(23001,''Purchase code exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(24001,''Customer code exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(24002,''Customer name exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(24003,''Account Code is Already Exist'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(24004,''Account Name is Already Exist'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(25001,''Sales code exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(26001,''Vendor code exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(26002,''Vendor name exists'')
		Insert Into Gen_ErrorMsg(ErrorNo,ErrorMsg) values(35001,''Stock is exists'')
		

		--: VersionInfo
		SET IDENTITY_INSERT VersionInfo ON
		INSERT INTO VersionInfo (VersionID, VersionNo, IsCurrent) VALUES (1, ''1.0.0.1'', 1)
		SET IDENTITY_INSERT VersionInfo OFF

		--: Country
		 
		SET IDENTITY_INSERT Gen_Country ON
		INSERT INTO Gen_Country (CountryID, Name, CreatedBy, CreatedDate) VALUES (1, ''India'', 1, ''2014-01-15'')
		SET IDENTITY_INSERT Gen_Country OFF

		--: State
		 
		SET IDENTITY_INSERT Gen_State ON
		INSERT INTO Gen_State (StateID, Name, CountryID, CreatedBy, CreatedDate) VALUES (1, ''Gujarat'', 1, 1, ''2014-01-15'')
--
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Gujarat'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Andhra Pradesh'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Arunachal Pradesh'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Assam'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Bihar'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Chhattisgarh'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Goa'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Haryana'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Himachal Pradesh'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Jammu and Kashmir'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Jharkhand'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Karnataka'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Kerala'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Madhya Pradesh'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Maharashtra'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Manipur'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Meghalaya'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Mizoram'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Nagaland'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Odisha'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Punjab'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Rajasthan'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Sikkim'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Tamil Nadu'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Telangana'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Tripura'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Uttar Pradesh'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''Uttarakhand'', 1, 1, ''2014-01-15'')
--INSERT [dbo].[Gen_State] ([Name], CountryID, CreatedBy, CreatedDate) VALUES (N''West Bengal'', 1, 1, ''2014-01-15'')
		SET IDENTITY_INSERT Gen_State OFF

		--: City
		 
		SET IDENTITY_INSERT Gen_City ON
			
		INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (1, ''Ahmedabad'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (2, ''Vadodara'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (3, ''Anand'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (4, ''Surat'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (5, ''Nadiad'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (6, ''Vapi'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (7, ''Valsad'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (8, ''Ankleshwar'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (9, ''Bharuch'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (10, ''Rajkot'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (11, ''Bhavnagar'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (12, ''Surendranagar'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (13, ''Jamnagar'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (14, ''Dwarka'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (15, ''Okha'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (16, ''Maheshana'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (17, ''Dahej'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (18, ''Dahod'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (19, ''Halol'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (20, ''Kalol'', 1, 1, ''2014-01-15'')
INSERT INTO Gen_City (CityID, Name, StateID, CreatedBy, CreatedDate) VALUES (21, ''Rajpipla'', 1, 1, ''2014-01-15'')
--
----------------new
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ahmedabad'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Vadodara'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Surat'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Rajkot'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bhavnagar'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jamnagar'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Junagadh'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gandhinagar'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nadiad'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Morbi'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Surendranagar'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gandhidham'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Veraval'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Navsari'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bharuch'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Anand'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Porbandar'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Godhra'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Botad'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Sidhpur'', 7, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Visakhapatnam'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Vijayawada'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Guntur'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nellore'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kurnool'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Rajahmundry'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kakinada'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Tirupati'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kadapa'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Anantapur'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Vizianagaram'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Eluru'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ongole'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nandyal'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Adoni'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Tenali'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Proddatur'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chittoor'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Hindupur'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bhimavaram'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Madanapalle'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Srikakulam'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Narasaraopet'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Tadepalligudem'', 8, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Udalguri'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Karimganj'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Cachar'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kamrup'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kamrup Metro'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Karbi Anglong'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kokrajhar'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Golaghat'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Goalpara'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chirang'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dibrugarh'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Tinsukia'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Tinsukia'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Darrang'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dhubri'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dhemaji'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nagaon'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nalbari'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bongaigaon'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Barpeta'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Baksa'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Morigaon'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jorhat'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Lakhimpur'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Sivasagar'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''sonitpur'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Hailakandi'', 10, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Patna'', 11, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gaya'', 11, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bhagalpur'', 11, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Muzaffarpur'', 11, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Purnia'', 11, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bihar Sharif'', 11, 1, ''2014-01-15'')
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Arrah'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Begusarai'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Munger'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Saharsa'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Sasaram'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Hajipur'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dehri'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Siwan'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Motihari'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bagaha'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kishanganj'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jamalpur'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jehanabad'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Aurangabad'', 11)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Raipur'', 12)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Durg-Bhilainagar '', 12)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bilaspur'', 12)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Korba'', 12)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Rajnandgaon'', 12)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Raigarh'', 12)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jagdalpur'', 12)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ambikapur'', 12)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chirmiri'', 12)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dhamtari'', 12)
--GO
--print ''Processed 100 total records''
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mahasamund'', 12)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Panaji'', 13)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Margao'', 13)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Faridabad'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gurgaon'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Panipat'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ambala'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Yamunanagar'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Rohtak'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Hisar'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Karnal'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Sonipat'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Panchkula'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bhiwani'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Sirsa'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bahadurgarh'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jind'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Thanesar'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kaithal'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Rewari'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Palwal'', 14)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bilaspur'', 15)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chamba'', 15)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Hamirpur'', 15)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kangra'', 15)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kinnaur'', 15)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kullu'', 15)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Lahaul and Spiti'', 15)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mandi'', 15)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Shimla'', 15)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Sirmaur'', 15)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Solan'', 15)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Una'', 15)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Srinagar'', 16)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jammu'', 16)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Anantnag'', 16)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jamshedpur'', 17)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dhanbad'', 17)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ranchi'', 17)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bokaro Steel City'', 17)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Deoghar'', 17)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Phusro'', 17)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Hazaribagh'', 17)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Giridih'', 17)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ramgarh'', 17)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Medininagar'', 17)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chirkunda'', 17)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bengaluru'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mysore'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Hubli-Dharwar'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mangalore'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Belgaum'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gulbarga'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Davanagere'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bellary'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bijapur'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Shimoga'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Tumkur'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Raichur'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bidar'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Hospet'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Hassan'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gadag-Betigeri'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Udupi'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Robertson Pet'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bhadravati'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chitradurga'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kolar'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mandya'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chikmagalur'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gangawati'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bagalkot'', 18)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Thiruvananthapuram'', 19)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N'' Kochi'', 19)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N'' Kozhikode'', 19)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kollam'', 19)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Thrissur'', 19)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kannur'', 19)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Palakkad'', 19)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kanhangad'', 19)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kottayam'', 19)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Malappuram'', 19)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Vidisha'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ujjain'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Singrauli'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Shivpuri'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Seoni'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Sehore'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Satna'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Sagar'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Rewa'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ratlam'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Pithampur'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Neemuch'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nagda'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Murwara '', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Morena'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mandsaur'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Khargone'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Khandwa'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jabalpur'', 20)
--GO
--print ''Processed 200 total records''
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Itarsi'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Indore'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Hoshangabad'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gwalior'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Guna'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dewas'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Datia'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Damoh'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chhindwara'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chhatarpur'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Burhanpur'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bhopal'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bhind'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Betul'', 20)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mumbai'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Pune'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nagpur'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Thane'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Pimpri-Chinchwad'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nashik'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Aurangabad'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Amravati'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nanded'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kolhapur'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Sangli'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jalgaon'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Akola'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Latur'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dhule'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ahmednagar'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chandrapur'', 21)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bishnupur'', 22)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Churachandpur'', 22)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chandel'', 22)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Senapati'', 22)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Tamenglong'', 22)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Thoubal'', 22)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ukhrul'', 22)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Shillong'', 23)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Tura'', 23)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mawlai'', 23)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nongthymmai '', 23)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jowai'', 23)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Pynthorumkhrah'', 23)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nongstoin'', 23)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Aizawl '', 24)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Lunglei'', 24)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Champhai '', 24)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Saiha '', 24)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kolasib '', 24)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Serchhip'', 24)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dimapur'', 25)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kohima'', 25)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mokokchung'', 25)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Wokha '', 25)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Tuensang'', 25)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Zunheboto'', 25)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Agartala'', 32)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dharmanagar'', 32)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Udaipur'', 32)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kailasahar'', 32)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Belonia'', 32)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Teliamura'', 32)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Khowai'', 32)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bhubaneshwar'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Cuttack'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Rourkela'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Brahmapur'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Sambalpur'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Puri'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Balasore'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bhadrak'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Baripada'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jharsuguda'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bhawanipatna'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dhenkanal'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Barbil'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Angul'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jajpur'', 26)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ludhiana'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Amritsar'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jalandhar'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Patiala'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bathinda'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mohali'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Hoshiarpur '', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Batala'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Pathankot'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Moga'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Abohar'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Malerkotla'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Khanna'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Phagwara'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Muktasar'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Barnala'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Rajpura'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Firozpur'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kapurthala'', 27)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ajmer'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Alwar'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bharatpur'', 28)
--GO
--print ''Processed 300 total records''
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bikaner'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chittorgarh'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dholpur'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dungarpur'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Hanumangarh'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jaipur'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jaisalmer'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jalor'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Jodhpur'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kota'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nagaur'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Pratapgarh'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Sikar'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Sirohi'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Sri Ganganagar'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Udaipur'', 28)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gangtok?'', 29)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ghezing'', 29)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Legship'', 29)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mangan'', 29)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Pelling'', 29)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Yuksom'', 29)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chennai'', 30)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Coimbatore'', 30)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dharmapuri'', 30)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kanchipuram'', 30)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kanyakumari'', 30)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kodaikanal'', 30)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Madurai'', 30)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mahabalipuram'', 30)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nagore'', 30)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Palani'', 30)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Rameshwaram'', 30)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Yercaud'', 30)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Tiruttani'', 30)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Hyderabad'', 31)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Warangal'', 31)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nizamabad'', 31)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Karimnagar'', 31)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ramagundam'', 31)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Khammam'', 31)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mahbubnagar'', 31)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nalgonda'', 31)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Adilabad'', 31)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Suryapet'', 31)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Miryalaguda'', 31)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Agora'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Agra'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Aligarh'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Allahabad'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ayodhya'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Banaras'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bateshwar'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Chitrakoot'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ghaziabad'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gokul'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kanpur'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kaushambi'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Lucknow'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mathura'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Meerut'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Noida'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Piprahwa'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Vrindavan'', 33)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mussoorie'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gangotri'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Almora'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Badrinath'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dehradun'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gangotri'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gaumukh'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Gaurikund'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Haridwar'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kedarnath'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Lansdowne'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Mukteshwar'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Nainital'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Pithoragarh City'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Ranikhet'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Rishikesh'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Uttarkashi'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Yamunotri'', 34)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Bagnan'', 35)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Coopers Camp'', 35)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Dhuilya'', 35)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kajora'', 35)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kanyanagar'', 35)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kaugachhi'', 35)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Kolkata'', 35)
--INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Murshidabad'', 35)
------INSERT [dbo].Gen_City ([Name], StateID, CreatedBy, CreatedDate) VALUES (N''Siliguri'', 35)
--------------
	--: City
		 
		SET IDENTITY_INSERT Gen_City ON
 INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ahmedabad'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Vadodara'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Surat'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Rajkot'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bhavnagar'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jamnagar'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Junagadh'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gandhinagar'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nadiad'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Morbi'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Surendranagar'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gandhidham'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Veraval'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Navsari'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bharuch'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Anand'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Porbandar'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Godhra'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Botad'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Sidhpur'', 7)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Visakhapatnam'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Vijayawada'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Guntur'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nellore'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kurnool'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Rajahmundry'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kakinada'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Tirupati'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kadapa'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Anantapur'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Vizianagaram'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Eluru'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ongole'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nandyal'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Adoni'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Tenali'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Proddatur'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chittoor'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Hindupur'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bhimavaram'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Madanapalle'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Srikakulam'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Narasaraopet'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Tadepalligudem'', 8)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Udalguri'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Karimganj'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Cachar'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kamrup'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kamrup Metro'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Karbi Anglong'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kokrajhar'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Golaghat'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Goalpara'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chirang'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dibrugarh'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Tinsukia'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Darrang'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dhubri'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dhemaji'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nagaon'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nalbari'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bongaigaon'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Barpeta'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Baksa'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Morigaon'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jorhat'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Lakhimpur'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Sivasagar'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''sonitpur'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Hailakandi'', 10)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Patna'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gaya'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bhagalpur'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Muzaffarpur'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Purnia'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bihar Sharif'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Arrah'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Begusarai'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Munger'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Saharsa'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Sasaram'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Hajipur'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dehri'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Siwan'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Motihari'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bagaha'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kishanganj'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jamalpur'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jehanabad'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Aurangabad'', 11)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Raipur'', 12)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Durg-Bhilainagar '', 12)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bilaspur'', 12)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Korba'', 12)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Rajnandgaon'', 12)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Raigarh'', 12)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jagdalpur'', 12)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ambikapur'', 12)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chirmiri'', 12)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dhamtari'', 12)

print ''Processed 100 total records''
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mahasamund'', 12)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Panaji'', 13)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Margao'', 13)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Faridabad'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gurgaon'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Panipat'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ambala'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Yamunanagar'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Rohtak'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Hisar'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Karnal'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Sonipat'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Panchkula'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bhiwani'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Sirsa'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bahadurgarh'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jind'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Thanesar'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kaithal'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Rewari'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Palwal'', 14)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bilaspur'', 15)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chamba'', 15)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Hamirpur'', 15)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kangra'', 15)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kinnaur'', 15)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kullu'', 15)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Lahaul and Spiti'', 15)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mandi'', 15)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Shimla'', 15)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Sirmaur'', 15)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Solan'', 15)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Una'', 15)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Srinagar'', 16)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jammu'', 16)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Anantnag'', 16)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jamshedpur'', 17)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dhanbad'', 17)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ranchi'', 17)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bokaro Steel City'', 17)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Deoghar'', 17)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Phusro'', 17)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Hazaribagh'', 17)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Giridih'', 17)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ramgarh'', 17)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Medininagar'', 17)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chirkunda'', 17)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bengaluru'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mysore'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Hubli-Dharwar'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mangalore'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Belgaum'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gulbarga'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Davanagere'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bellary'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bijapur'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Shimoga'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Tumkur'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Raichur'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bidar'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Hospet'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Hassan'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gadag-Betigeri'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Udupi'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Robertson Pet'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bhadravati'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chitradurga'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kolar'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mandya'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chikmagalur'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gangawati'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bagalkot'', 18)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Thiruvananthapuram'', 19)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N'' Kochi'', 19)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N'' Kozhikode'', 19)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kollam'', 19)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Thrissur'', 19)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kannur'', 19)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Palakkad'', 19)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kanhangad'', 19)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kottayam'', 19)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Malappuram'', 19)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Vidisha'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ujjain'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Singrauli'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Shivpuri'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Seoni'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Sehore'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Satna'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Sagar'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Rewa'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ratlam'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Pithampur'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Neemuch'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nagda'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Murwara '', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Morena'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mandsaur'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Khargone'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Khandwa'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jabalpur'', 20)

print ''Processed 200 total records''
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Itarsi'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Indore'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Hoshangabad'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gwalior'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Guna'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dewas'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Datia'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Damoh'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chhindwara'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chhatarpur'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Burhanpur'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bhopal'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bhind'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Betul'', 20)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mumbai'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Pune'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nagpur'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Thane'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Pimpri-Chinchwad'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nashik'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Aurangabad'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Amravati'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nanded'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kolhapur'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Sangli'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jalgaon'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Akola'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Latur'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dhule'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ahmednagar'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chandrapur'', 21)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bishnupur'', 22)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Churachandpur'', 22)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chandel'', 22)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Senapati'', 22)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Tamenglong'', 22)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Thoubal'', 22)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ukhrul'', 22)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Shillong'', 23)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Tura'', 23)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mawlai'', 23)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nongthymmai '', 23)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jowai'', 23)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Pynthorumkhrah'', 23)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nongstoin'', 23)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Aizawl '', 24)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Lunglei'', 24)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Champhai '', 24)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Saiha '', 24)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kolasib '', 24)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Serchhip'', 24)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dimapur'', 25)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kohima'', 25)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mokokchung'', 25)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Wokha '', 25)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Tuensang'', 25)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Zunheboto'', 25)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Agartala'', 32)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dharmanagar'', 32)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Udaipur'', 32)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kailasahar'', 32)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Belonia'', 32)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Teliamura'', 32)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Khowai'', 32)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bhubaneshwar'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Cuttack'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Rourkela'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Brahmapur'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Sambalpur'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Puri'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Balasore'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bhadrak'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Baripada'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jharsuguda'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bhawanipatna'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dhenkanal'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Barbil'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Angul'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jajpur'', 26)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ludhiana'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Amritsar'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jalandhar'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Patiala'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bathinda'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mohali'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Hoshiarpur '', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Batala'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Pathankot'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Moga'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Abohar'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Malerkotla'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Khanna'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Phagwara'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Muktasar'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Barnala'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Rajpura'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Firozpur'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kapurthala'', 27)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ajmer'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Alwar'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bharatpur'', 28)

print ''Processed 300 total records''
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bikaner'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chittorgarh'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dholpur'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dungarpur'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Hanumangarh'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jaipur'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jaisalmer'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jalor'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Jodhpur'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kota'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nagaur'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Pratapgarh'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Sikar'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Sirohi'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Sri Ganganagar'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Udaipur'', 28)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gangtok?'', 29)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ghezing'', 29)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Legship'', 29)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mangan'', 29)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Pelling'', 29)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Yuksom'', 29)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chennai'', 30)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Coimbatore'', 30)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dharmapuri'', 30)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kanchipuram'', 30)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kanyakumari'', 30)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kodaikanal'', 30)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Madurai'', 30)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mahabalipuram'', 30)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nagore'', 30)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Palani'', 30)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Rameshwaram'', 30)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Yercaud'', 30)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Tiruttani'', 30)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Hyderabad'', 31)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Warangal'', 31)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nizamabad'', 31)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Karimnagar'', 31)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ramagundam'', 31)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Khammam'', 31)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mahbubnagar'', 31)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nalgonda'', 31)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Adilabad'', 31)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Suryapet'', 31)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Miryalaguda'', 31)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Agora'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Agra'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Aligarh'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Allahabad'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ayodhya'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Banaras'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bateshwar'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Chitrakoot'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ghaziabad'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gokul'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kanpur'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kaushambi'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Lucknow'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mathura'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Meerut'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Noida'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Piprahwa'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Vrindavan'', 33)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mussoorie'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gangotri'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Almora'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Badrinath'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dehradun'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gangotri'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gaumukh'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Gaurikund'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Haridwar'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kedarnath'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Lansdowne'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Mukteshwar'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Nainital'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Pithoragarh City'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Ranikhet'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Rishikesh'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Uttarkashi'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Yamunotri'', 34)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Bagnan'', 35)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Coopers Camp'', 35)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Dhuilya'', 35)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kajora'', 35)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kanyanagar'', 35)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kaugachhi'', 35)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Kolkata'', 35)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Murshidabad'', 35)
INSERT [dbo].Gen_City ([Name], [StateID]) VALUES (N''Siliguri'', 35)

------------
		SET IDENTITY_INSERT Gen_City OFF
		

		--: Area
		SET IDENTITY_INSERT Gen_Area ON
		INSERT INTO Gen_Area (AreaID, Name, CityID, CreatedBy, CreatedDate) VALUES (1, ''Ghatlodia'', 1, 1, ''2014-01-15'')
		SET IDENTITY_INSERT Gen_Area OFF

	 	--: User
		SET IDENTITY_INSERT Gen_User ON
		INSERT INTO Gen_User (UserID,  UserName, Password, Name, IsActive, CreatedBy, CreatedDate,CompId) VALUES (1,  ''sa'', ''admin'', ''Administrator'', 1, 1, ''2014-01-15'',1)
		SET IDENTITY_INSERT Gen_User OFF

	 
--		Select ''Insert Into GoodsTransaction(GTID,Name,[Desc]) Values(''+ Convert(varchar,GTID) +'',''''''+[Name] +'''''',''''''+[Desc]+'''''')'' from GoodsTransaction
		--: GoodsTransaction
		Insert Into GoodsTransaction(GTID,Name,[Desc]) Values(100,''Opening Stock'','''')
		Insert Into GoodsTransaction(GTID,Name,[Desc]) Values(200,''Purchase Invoice'','' '')
		Insert Into GoodsTransaction(GTID,Name,[Desc]) Values(300,''Sales Invoice'','' '')
		Insert Into GoodsTransaction(GTID,Name,[Desc]) Values(550,''Adjustment'','''')
	
		--Select ''Insert Into AccountTransaction(TransactionTypeID,TransactionType) Values(''+ Convert(varchar,TransactionTypeID) +'',''''''+TransactionType +'''''')'' from AccountTransaction
		--: AccountTransaction
		Insert Into AccountTransaction(TransactionTypeID,TransactionType) Values(1,''Opening Balance'')
		Insert Into AccountTransaction(TransactionTypeID,TransactionType) Values(2,''Purchase Invoice'')
		Insert Into AccountTransaction(TransactionTypeID,TransactionType) Values(3,''Sales Invoice'')
		Insert Into AccountTransaction(TransactionTypeID,TransactionType) Values(4,''Expense'')
		Insert Into AccountTransaction(TransactionTypeID,TransactionType) Values(5,''Payment'')
		Insert Into AccountTransaction(TransactionTypeID,TransactionType) Values(6,''Receipt'')
		Insert Into AccountTransaction(TransactionTypeID,TransactionType) Values(7,''Commission'')
		Insert Into AccountTransaction(TransactionTypeID,TransactionType) Values(8,''Service Sale'')


		--Select ''Insert Into AccountType(AccTypeID,AcountType) Values(''+ Convert(varchar,AccTypeID) +'',''''''+AcountType +'''''')'' from AccountType
		--: AccountType
		Insert Into AccountType(AccTypeID,AcountType) Values(1,''Base Account'')
		Insert Into AccountType(AccTypeID,AcountType) Values(2,''Supplier Account'')
		Insert Into AccountType(AccTypeID,AcountType) Values(3,''Customer Account'')
		Insert Into AccountType(AccTypeID,AcountType) Values(4,''Bank Account'')

		--: Account 
		-- Insert Cash Acount	
		SET IDENTITY_INSERT Account ON
			Insert Into Account(AccountID,AccountCode,AccountName,AccCreatedDate,AccTypeID)
						Values(1,''Acc-00001'',''COMPANY'',''2014-01-15'',1)
		SET IDENTITY_INSERT Account OFF
		----Insert Record in OpeningBalance
		Insert Into OpeningBalance (FYID,AccountID, CRAmount, DBAmount) Values(1,1, 0.00,0.00);
		---Insert Record in Ledger
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount)
						Values(1,1,       1,				  1,              ''2014-01-15'',		0.00, 0.00);
		-- Insert BASIC EXCISE DUTY Acount	
		SET IDENTITY_INSERT Account ON
			Insert Into Account(AccountID,AccountCode,AccountName,AccCreatedDate,AccTypeID)
						Values(2,''Acc-00002'',''BASIC EXCISE DUTY'',''2014-01-15'',1)
		SET IDENTITY_INSERT Account OFF
		----Insert Record in OpeningBalance
		Insert Into OpeningBalance (FYID,AccountID, CRAmount, DBAmount) Values(1,2, 0.00,0.00);
		---Insert Record in Ledger
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount)
						Values(1,2,       1,				  2,              ''2014-01-15'',		0.00, 0.00);
		-- Insert EDUCATION CESS on EXCISE Acount	
		SET IDENTITY_INSERT Account ON
			Insert Into Account(AccountID,AccountCode,AccountName,AccCreatedDate,AccTypeID)
						Values(3,''Acc-00003'',''EDUCATION CESS on EXCISE'',''2014-01-15'',1)
		SET IDENTITY_INSERT Account OFF
		----Insert Record in OpeningBalance
		Insert Into OpeningBalance (FYID,AccountID, CRAmount, DBAmount) Values(1,3, 0.00,0.00);
		---Insert Record in Ledger
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount)
						Values(1,3,       1,				  3,              ''2014-01-15'',		0.00, 0.00);
		-- Insert HIGHER EDUCATION CESS on EXCISE Acount	
		SET IDENTITY_INSERT Account ON
			Insert Into Account(AccountID,AccountCode,AccountName,AccCreatedDate,AccTypeID)
						Values(4,''Acc-00004'',''HIGHER EDUCATION CESS on EXCISE'',''2014-01-15'',1)
		SET IDENTITY_INSERT Account OFF
		----Insert Record in OpeningBalance
		Insert Into OpeningBalance (FYID,AccountID, CRAmount, DBAmount) Values(1,4, 0.00,0.00);
		---Insert Record in Ledger
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount)
						Values(1,4,       1,				  4,              ''2014-01-15'',		0.00, 0.00);
		-- Insert CST Acount	
		SET IDENTITY_INSERT Account ON
			Insert Into Account(AccountID,AccountCode,AccountName,AccCreatedDate,AccTypeID)
						Values(5,''Acc-00005'',''CST'',''2014-01-15'',1)
		SET IDENTITY_INSERT Account OFF
		----Insert Record in OpeningBalance
		Insert Into OpeningBalance (FYID,AccountID, CRAmount, DBAmount) Values(1,5, 0.00,0.00);
		---Insert Record in Ledger
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount)
						Values(1,5,       1,				  5,              ''2014-01-15'',		0.00, 0.00);
		-- Insert VAT Acount	
		SET IDENTITY_INSERT Account ON
			Insert Into Account(AccountID,AccountCode,AccountName,AccCreatedDate,AccTypeID)
						Values(6,''Acc-00006'',''VAT'',''2014-01-15'',1)
		SET IDENTITY_INSERT Account OFF
		----Insert Record in OpeningBalance
		Insert Into OpeningBalance (FYID,AccountID, CRAmount, DBAmount) Values(1,6, 0.00,0.00);
		---Insert Record in Ledger
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount)
						Values(1,6,       1,				  6,              ''2014-01-15'',		0.00, 0.00);
		-- Insert Additional VAT Acount	
		SET IDENTITY_INSERT Account ON
			Insert Into Account(AccountID,AccountCode,AccountName,AccCreatedDate,AccTypeID)
						Values(7,''Acc-00007'',''Additional VAT'',''2014-01-15'',1)
		SET IDENTITY_INSERT Account OFF
		----Insert Record in OpeningBalance
		Insert Into OpeningBalance (FYID,AccountID, CRAmount, DBAmount) Values(1,7, 0.00,0.00);
		---Insert Record in Ledger
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount)
						Values(1,7,       1,				  7,              ''2014-01-15'',		0.00, 0.00);
	
		-- Insert Commission Acount	
		SET IDENTITY_INSERT Account ON
			Insert Into Account(AccountID,AccountCode,AccountName,AccCreatedDate,AccTypeID)
						Values(8,''Acc-00008'',''Commission'',''2014-01-15'',1)
		SET IDENTITY_INSERT Account OFF
		----Insert Record in OpeningBalance
		Insert Into OpeningBalance (FYID,AccountID, CRAmount, DBAmount) Values(1,8, 0.00,0.00);
		---Insert Record in Ledger
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount)
						Values(1,8,       1,				  8,              ''2014-01-15'',		0.00, 0.00);
	
		-- Insert Expense Acount	
		SET IDENTITY_INSERT Account ON
			Insert Into Account(AccountID,AccountCode,AccountName,AccCreatedDate,AccTypeID)
						Values(9,''Acc-00009'',''Expense'',''2014-01-15'',1)
		SET IDENTITY_INSERT Account OFF
		----Insert Record in OpeningBalance
		Insert Into OpeningBalance (FYID,AccountID, CRAmount, DBAmount) Values(1,9, 0.00,0.00);
		---Insert Record in Ledger
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount)
						Values(1,9,       1,				  9,              ''2014-01-15'',		0.00, 0.00);


		-- Insert Service Account	
		SET IDENTITY_INSERT Account ON
			Insert Into Account(AccountID,AccountCode,AccountName,AccCreatedDate,AccTypeID)
						Values(10,''Acc-00010'',''Service Tax'',''2014-01-15'',1)
		SET IDENTITY_INSERT Account OFF
		----Insert Record in OpeningBalance
		Insert Into OpeningBalance (FYID,AccountID, CRAmount, DBAmount) Values(1,10, 0.00,0.00);
		---Insert Record in Ledger
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount)
						Values(1,10,       1,				  10,              ''2014-01-15'',		0.00, 0.00);

		-- Insert Bank Account	
		SET IDENTITY_INSERT Account ON
			Insert Into Account(AccountID,AccountCode,AccountName,AccCreatedDate,AccTypeID)
						Values(11,''Acc-00011'',''Bank'',''2014-01-15'',1)
		SET IDENTITY_INSERT Account OFF
		----Insert Record in OpeningBalance
		Insert Into OpeningBalance (FYID,AccountID, CRAmount, DBAmount) Values(1,11, 0.00,0.00);
		---Insert Record in Ledger
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount)
						Values(1,11,       1,				  11,              ''2014-01-15'',		0.00, 0.00);


		-- Set Auto Identity to 51th Record
		DBCC CHECKIDENT(Account, RESEED, 51)	
		-- End of Account Entry
		SET IDENTITY_INSERT TaxClass ON
			Insert Into TaxClass 
				(TaxClassID,Name,FromDate,Excise,EduCess,HEduCess,ServiceTAX,CST,VAT,AVAT,IsTerminate,CreatedBy,CreatedDate)
				Values(2,''ZERO TAX'',''2014-01-15'',0.00,0.00,0.00,0.00,0.00,0.00,0.00,0,1,''2014-01-15'')

			Insert Into TaxClass 
				(TaxClassID,Name,FromDate,Excise,EduCess,HEduCess,ServiceTAX,CST,VAT,AVAT,IsTerminate,CreatedBy,CreatedDate)
				Values(3,''SERVICE TAX 12.36'',''2014-01-15'',0.00,0.24,0.12,12.00,0.00,0.00,0.00,0,1,''2014-01-15'')

			Insert Into TaxClass 
				(TaxClassID,Name,FromDate,Excise,EduCess,HEduCess,ServiceTAX,CST,VAT,AVAT,IsTerminate,CreatedBy,CreatedDate)
				Values(4,''VAT 5'',''2014-01-15'',0.00,0.00,0.00,0.00,0.00,4.00,1.00,0,1,''2014-01-15'')

			Insert Into TaxClass 
				(TaxClassID,Name,FromDate,Excise,EduCess,HEduCess,ServiceTAX,CST,VAT,AVAT,IsTerminate,CreatedBy,CreatedDate)
				Values(5,''VAT 15'',''2014-01-15'',0.00,0.00,0.00,0.00,0.00,12.50,2.50,0,1,''2014-01-15'')
		SET IDENTITY_INSERT TaxClass OFF
		--:InquiryStatus
		PRINT ''Inserting LeadStatus ...''
		--Select ''Insert INTO LeadStatus(LeadStatusID,Status) Values (''+Convert(varchar,LeadStatusID) + '',''''''+Status+'''''')'' from LeadStatus
		Insert INTO LeadStatus(LeadStatusID,Status) Values (1,''Pending'')
		Insert INTO LeadStatus(LeadStatusID,Status) Values (2,''In Progress'')
		Insert INTO LeadStatus(LeadStatusID,Status) Values (3,''Sale'')
		Insert INTO LeadStatus(LeadStatusID,Status) Values (4,''Cancelled'') 	


		

		SET IDENTITY_INSERT GEN_UOM ON
			Insert Into GEN_UOM(UOMID,Name,Abbr,CreatedBy,CreatedDate)Values(1,''Meter'',''mtr'',1,''2014-04-01'')
			Insert Into GEN_UOM(UOMID,Name,Abbr,CreatedBy,CreatedDate)Values(2,''Kilogram'',''kg'',1,''2014-04-01'')
			Insert Into GEN_UOM(UOMID,Name,Abbr,CreatedBy,CreatedDate)Values(3,''Gram'',''gm'',1,''2014-04-01'')
			Insert Into GEN_UOM(UOMID,Name,Abbr,CreatedBy,CreatedDate)Values(4,''Liter'',''ltr'',1,''2014-04-01'')
			Insert Into GEN_UOM(UOMID,Name,Abbr,CreatedBy,CreatedDate)Values(5,''No'',''No'',1,''2014-04-01'')
			Insert Into GEN_UOM(UOMID,Name,Abbr,CreatedBy,CreatedDate)Values(6,''BAG'',''BAG'',1,''2014-04-01'')
			Insert Into GEN_UOM(UOMID,Name,Abbr,CreatedBy,CreatedDate)Values(7,''SQ FEET'',''SF'',1,''2014-04-01'')
			Insert Into GEN_UOM(UOMID,Name,Abbr,CreatedBy,CreatedDate)Values(8,''SQ METER'',''SM'',1,''2014-04-01'')
			Insert Into GEN_UOM(UOMID,Name,Abbr,CreatedBy,CreatedDate)Values(9,''METER CUBE'',''MC'',1,''2014-04-01'')
			Insert Into GEN_UOM(UOMID,Name,Abbr,CreatedBy,CreatedDate)Values(10,''TON'',''TON'',1,''2014-04-01'')
			Insert Into GEN_UOM(UOMID,Name,Abbr,CreatedBy,CreatedDate)Values(11,''TRUCK LOAD'',''TL'',1,''2014-04-01'')
			Insert Into GEN_UOM(UOMID,Name,Abbr,CreatedBy,CreatedDate)Values(12,''TRACTOR LOAD'',''TL'',1,''2014-04-01'')
			Insert Into GEN_UOM(UOMID,Name,Abbr,CreatedBy,CreatedDate)Values(13,''BRASS'',''BRASS'',1,''2014-04-01'')
			 
		SET IDENTITY_INSERT GEN_UOM OFF

		-- TNC
			-- TNC
		SET IDENTITY_INSERT TermsNConditions ON
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(1,''QUOTATION'',''VAT EXTRA'',1,''2014-04-01'')
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(2,''QUOTATION'',''TRANSPORATION WILL BE CHARGED AS ACTUAL'',1,''2014-04-01'')
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(3,''QUOTATION'',''PAYMENT TERMS:'',1,''2014-04-01'')
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(4,''QUOTATION'',''SUBJECTED TO VADODARA JURIDICTION'',1,''2014-04-01'')
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(5,''SALES'',''GOODS ONCE SOLD WILL NOT BE TAKEN BACK'',1,''2014-04-01'')
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(6,''SALES'',''WARRANTY TERMS'',1,''2014-04-01'')
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(7,''SALES'',''PAYMENT TERMS:'',1,''2014-04-01'')
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(8,''SALES'',''TRANSPORTATION CHARGES:'',1,''2014-04-01'')
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(9,''SALES'',''SUBJECTED TO VADODARA JURIDICTION'',1,''2014-04-01'')
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(10,''SALES'',''IN CASE OF DELAY OF PAYMENT 24% INTEREST WILL BE CHARGED'',1,''2014-04-01'')
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(11,''SERVICE'',''SERVAICE TAX'',1,''2014-04-01'')			
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(12,''SERVICE'',''TRANSPORTATION CHARGES:'',1,''2014-04-01'')			
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(13,''SERVICE'',''WARRANTY TERMS:'',1,''2014-04-01'')			
			Insert Into TermsNConditions(TNCID,TNC_Sub,TNC_Desc,CreatedBy,CreatedDate)Values(14,''SERVICE'',''SUBJECT TO VADODARA JURIDICTION'',1,''2014-04-01'')			
		SET IDENTITY_INSERT TermsNConditions OFF

		-- Email
		SET IDENTITY_INSERT Email ON
			Insert Into Email(Email_ID,Type,Subject,Header,Footer,CreatedBy,CreatedDate)
						Values(1,''Quotation'',''Quotation'',''Dear Sir,

Thank you very much for your kind interest in our products. Further to your inquiry please find the attached the quotation for above meantioned Subject.

Hope the details are inline with your requirements.

Waiting for your positive and early reply.'',''Rgds,
Nihar Nathwani
JP Infoweb solutions pvt ltd
Vadodara
9727733126'',1,''2014-04-01'')
			
			Insert Into Email(Email_ID,Type,Subject,Header,Footer,CreatedBy,CreatedDate)
						Values(2,''Sales'',''Sales details'',''Dear Sir,

Thank you so much for doing bussniess with us. Please find the details below.'',''Rgds,
Nihar Nathwani
JP Infoweb solutions pvt ltd
Vadodara
9727733126'',1,''2014-04-01'')
			Insert Into Email(Email_ID,Type,Subject,Header,Footer,CreatedBy,CreatedDate)
						Values(3,''Services'',''YOUR SERVICE REQUEST DETAILS'',''DEAR SIR,

THANK YOU VERY MUCH FOR YOUR SERVICE REGISTERY. FURTHER TO OUR INTERACTION PLEASE FIND THE DETAILS BELOW.'',''Rgds,
Nihar Nathwani
JP Infoweb solutions pvt ltd
Vadodara
9727733126'',1,''2014-04-01'')
			Insert Into Email(Email_ID,Type,Subject,Header,Footer,CreatedBy,CreatedDate)
						Values(4,''Payment Reminder'',''Payment Reminder'',''Dear Sir,

Thank you so much for your kind association with us. We value your organization as our client and looking forward for mutually benificial relationship.'',''Rgds,
Nihar Nathwani
JP Infoweb solutions pvt ltd
Vadodara
9727733126'',1,''2014-04-01'')			
			Insert Into Email(Email_ID,Type,Subject,Header,Footer,CreatedBy,CreatedDate)
						Values(5,''Reminder'',''Reminder Subject'',''Reminder Header'',''Rgds,
Nihar Nathwani
JP Infoweb solutions pvt ltd
Vadodara
9727733126'',1,''2014-04-01'')			
		SET IDENTITY_INSERT Email OFF

		
--SET IDENTITY_INSERT Gen_Privilege ON
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1001, N''Master'', N''Master'', 0, 1)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1101, N''Terms and Conditions'', N''Terms and Conditions'', 1001, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1102, N''Edit'', N''Edit'', 1101, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1201, N''Email '', N''Email '', 1001, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1202, N''Edit'', N''Edit'', 1201, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1203, N''Mail Detail'', N''Mail Detail'', 1201, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1301, N''Utility'', N''Utility'', 1001, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1401, N''Marketing'', N''Marketing'', 0, 1)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1501, N''Inquiry'', N''Inquiry'', 1401, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1502, N''New'', N''New'', 1501, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1503, N''Edit'', N''Edit'', 1501, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1504, N''Delete'', N''Delete'', 1501, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1505, N''FollowUp'', N''FollowUp'', 1501, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1506, N''Download'', N''Download'', 1501, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1507, N''Upload'', N''Upload'', 1501, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1508, N''Inquiry Register'', N''Inquiry Register'', 1501, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1601, N''Quotation'', N''Quotation'', 1401, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1602, N''New'', N''New'', 1601, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1603, N''Edit'', N''Edit'', 1601, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1604, N''Delete'', N''Delete'', 1601, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1605, N''Revised'', N''Revised'', 1601, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1606, N''Next FollowUp'', N''Next FollowUp'', 1601, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1607, N''Quotation'', N''Quotation'', 1601, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1701, N''Sales'', N''Sales'', 0, 1)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1801, N''Sales Invoice'', N''Sales Invoice'', 1701, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1802, N''New'', N''New'', 1801, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1803, N''Edit'', N''Edit'', 1801, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1804, N''Delete'', N''Delete'', 1801, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1805, N''Sales Invoice Register'', N''Sales Invoice Register'', 1801, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1806, N''Sales Invoice Detail Register'', N''Sales Invoice Detail Register'', 1801, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1807, N''Retail Invoice'', N''Retail Invoice'', 1801, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1808, N''Tax Invoice'', N''Tax Invoice'', 1801, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1809, N''Estimate'', N''Estimate'', 1801, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1810, N''Delivery Challan'', N''Delivery Challan'', 1801, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1811, N''Proforma Invoice'', N''Proforma Invoice'', 1801, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1901, N''Customer Payment'', N''Customer Payment'', 1701, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1902, N''New'', N''New'', 1901, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1903, N''Edit'', N''Edit'', 1901, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1904, N''Delete'', N''Delete'', 1901, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1905, N''Customer Payment Register'', N''Customer Payment Register'', 1901, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (1906, N''Customer Pending Payment Receipt'', N''Customer Pending Payment Receipt'', 1901, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2001, N''Company Detail'', N''Company Detail'', 1001, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2002, N''Edit'', N''Edit'', 2001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2101, N''Service Form'', N''Service Form'', 2001, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2102, N''New'', N''New'', 2101, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2103, N''Edit'', N''Edit'', 2101, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2104, N''Delete'', N''Delete'', 2101, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2105, N''Service Register'', N''Service Register'', 2101, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2106, N''Service Order'', N''Service Order'', 2101, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2107, N''Service Invoice'', N''Service Invocie'', 2101, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2201, N''Promotional Mail'', N''Promotional Mail'', 0, 1)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2301, N''Promotional'', N''Promotional'', 2201, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2302, N''New'', N''New'', 2301, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2303, N''Edit'', N''Edit'', 2301, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2304, N''Delete'', N''Delete'', 2301, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (2401, N''Transfer'', N''Transfer'', 0, 1)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (3001, N''Location'', N''Location'', 1001, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (3002, N''New'', N''New'', 3001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (3003, N''Edit'', N''Edit'', 3001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (3004, N''Delete'', N''Delete'', 3001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (3005, N''Location Register'', N''Location Register'', 3001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (4001, N''Employee'', N''Employee'', 1001, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (4002, N''New'', N''New'', 4001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (4003, N''Edit'', N''Edit'', 4001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (4004, N''Delete'', N''Delete'', 4001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (5001, N''UOM'', N''UOM'', 1001, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (5002, N''New'', N''New'', 5001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (5003, N''Edit'', N''Edit'', 5001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (5004, N''Delete'', N''Delete'', 5001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (5005, N''UOM Register'', N''UOM Register'', 5001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (6001, N''Item Register'', N''Item Register'', 1001, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (6002, N''New'', N''New'', 6001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (6003, N''Edit'', N''Edit'', 6001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (6004, N''Delete'', N''Delete'', 6001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (6005, N''Download'', N''Download'', 6001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (6006, N''Upload'', N''Upload'', 6001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (6007, N''Item Register'', N''Item Register'', 6001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (6008, N''Item Sales Report'', N''Item Sales Report'', 6001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (7001, N''Tax Class'', N''Tax Class'', 1001, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (7002, N''New'', N''New'', 7001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (7003, N''Edit'', N''Edit'', 7001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (7004, N''Delete'', N''Delete'', 7001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (8001, N''User'', N''User'', 1001, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (8002, N''New'', N''New'', 8001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (8003, N''Edit'', N''Edit'', 8001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (8004, N''Delete'', N''Delete'', 8001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (8005, N''Show'', N''Show'', 8001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (8006, N''Deactive'', N''Deactive'', 8001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (8007, N''User Register'', N''User Register'', 8001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (9001, N''Type of Service Call'', N''Type of Service Call'', 1001, 2)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (9002, N''New'', N''New'', 9001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (9003, N''Edit'', N''Edit'', 9001, 3)
--INSERT [dbo].[Gen_Privilege] ([PrivilegeID], [Name], [Caption], [ParentID], [Level]) VALUES (9004, N''Delete'', N''Delete'', 9001, 3)
--	SET IDENTITY_INSERT Gen_Privilege OFF	
	END
END

































' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SalesTNC_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SalesTNC_Select]
	-- Add the parameters for the stored procedure here
	
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT     TNC_Sub, TNC_Desc
FROM         Sales_TNC
WHERE     (Code = @i_Code)

END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SalesTNC_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SalesTNC_Insert]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub nvarchar(250),
	@i_Code nvarchar(50),
	@i_TNC_Desc nvarchar(Max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

	INSERT INTO Sales_TNC
                      (Code,TNC_Sub,TNC_Desc)
VALUES     (@i_Code,@i_TNC_Sub,@i_TNC_Desc)

END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SalesTNC_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SalesTNC_Delete]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub nvarchar(250),
	@i_Code nvarchar(50),
	@i_TNC_Desc nvarchar(Max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

DELETE FROM Sales_TNC WHERE Code=@i_Code AND TNC_Sub=@i_TNC_Sub AND TNC_Desc=@i_TNC_Desc

	

END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SalesInvoice_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 25th Jan 2011
-- Description:	Delete record from Sales Invoice And Detail
-- =============================================

CREATE PROCEDURE [dbo].[usp_SalesInvoice_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	-- Set Local Variable
	SET @o_ErrorMesg='''';
 
     
		-- Delete Stock	
		Update ItemStock
			Set ItemStock.QOH =  ItemStock.QOH -
				(Select IsNull(Sum(ItemStockDetail.Qty),0)
					From ItemStockDetail Where  ItemStockDetail.StockID = ItemStock.StockID 
						And ItemStockDetail.RefID = @i_RecID And ItemStockDetail.GTID=300)
		From ItemStockDetail as SDet
		Where  
			SDet.StockID = ItemStock.StockID And 
			SDet.RefID = @i_RecID And
			ItemStock.StockID IN (Select StockID From ItemStockDetail
				Where ItemStockDetail.RefID = @i_RecID And ItemStockDetail.GTID=300) 

--		 Delete Record from StockDistrictDetail Table
		DELETE FROM ItemStockDetail WHERE RefID = @i_RecID AND GTID = 300;
	 	 
		Delete From Ledger Where TransactionTypeID=3 And TransactionID = @i_RecID
		Delete From SaleDocList Where SaleID = @i_RecID;
		DELETE FROM Sales_TNC WHERE CODE=(SELECT SalesCode FROM SalesInvoice Where SIID = @i_RecID)
		Delete From SalesInvoiceDetail Where SIID = @i_RecID;
		Delete From SalesInvoice Where SIID = @i_RecID;
		Delete From Sales_Service_Reminder Where SIID = @i_RecID;


END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ServicesTNC_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ServicesTNC_Select]
	-- Add the parameters for the stored procedure here
	
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT     TNC_Sub, TNC_Desc
FROM         Services_TNC
WHERE     (Code = @i_Code)

END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ServicesTNC_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ServicesTNC_Insert]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub nvarchar(250),
	@i_Code nvarchar(50),
	@i_TNC_Desc nvarchar(Max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

	INSERT INTO Services_TNC
                      (Code,TNC_Sub,TNC_Desc)
VALUES     (@i_Code,@i_TNC_Sub,@i_TNC_Desc)

END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Reminder_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Roshni Patel
-- Create date: 23rd Jan 2011
-- Description:	Get Purchase Invoice List
-- =============================================
CREATE PROCEDURE [dbo].[usp_Reminder_List]
--[usp_Reminder_List]''1''
@i_CompId bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ''Quotation'' AS [TYPE],
			A.QUOTATIONID AS INVOICEID,
			A.CODE,
			A.FOLLOWUPDATE AS DATE,
			B.CUSTOMERNAME AS PARTY,
			B.CONTACTPERSON,
			B.PHONE1,
			B.LEADDATE,
			A.Remarks_Orignal AS REMARKS,
			'''' AS EMAIL
	FROM QUOTATION A
			LEFT JOIN LEAD B ON B.LEADID=A.LEADID
	WHERE A.FOLLOWUPDATE between GETDATE() and GETDATE()+2
			OR CONVERT(VARCHAR,A.FOLLOWUPDATE,103)= Convert(varchar,GETDATE(),103) and A.CompId=@i_CompId

	UNION ALL

	SELECT DISTINCT	''SERVICE'' AS TYPE,
		A.SIID AS INVOICEID,
		B.SALESCODE AS CODE,
		A.SR_DATE AS DATE,
		C.CUSTOMERNAME AS PARTY,
		C.CONTACTPERSON,
		C.PHONE1,
		C.LEADDATE,
		D.REMARKS AS REMARKS,
		'''' AS EMAIL
	FROM	SALES_SERVICE_REMINDER A 
		LEFT JOIN SALESINVOICE B ON B.SIID=A.SIID 		
		LEFT JOIN LEAD C ON C.LEADID=B.CUSTOMERID
		LEFT JOIN SERVICEMODULE D ON D.SERVICEID=B.SIID
	WHERE A.SR_DONE=0 and D.CompId=@i_CompId
	
	UNION ALL

	SELECT DISTINCT 
                      ''WARRANTY'' AS TYPE, B.SIID AS INVOICEID, A.SalesCode AS CODE, A.DCDate AS DATE, C.CustomerName AS PARTY, C.ContactPerson AS CONTACTPERSON, C.Phone1 AS PHONE1, GETDATE() 
                      AS LEADDATE, A.Narration AS REMARKS, '''' AS EMAIL
FROM         SalesInvoice AS A LEFT OUTER JOIN
                      Sales_Service_Reminder AS B ON B.SIID = A.SIID LEFT OUTER JOIN
                      Lead AS C ON C.LeadId = A.CustomerID
	Where A.DCDATE between GETDATE() and GETDATE() + 2 and A.CompId=@i_CompId
			OR CONVERT(VARCHAR,A.DCDATE,103) = CONVERT(VARCHAR, GETDATE(), 103)

		UNION ALL
	
	SELECT DISTINCT A.EXTRAREMINDER AS [TYPE],
			A.SIID AS INVOICEID,
			A.SalesCode AS CODE, 
			A.DTEXTRAREMINDER AS DATE,
			C.CUSTOMERNAME as PARTY,
			C.CONTACTPERSON AS CONTACTPERSON,
			C.PHONE1 AS PHONE1,
			GETDATE() AS LEADDATE,
			A.NARRATION AS REMARKS,
			c.Email AS EMAIL
	FROM SalesInvoice A 
		LEFT JOIN Sales_Service_Reminder B ON  B.SIID = A.SIID 
		LEFT JOIN LEAD C ON C.LEADID=A.CustomerID  
	Where CONVERT(VARCHAR,A.DTEXTRAREMINDER ,103) = CONVERT(VARCHAR, GETDATE(), 103) AND A.EXTRAREMINDER <> '''' and A.CompId=@i_CompId


----------------------------
UNION ALL
SELECT  DISTINCT   
	''Customer Followup'' AS [TYPE]	,
CustomerFollowUp.CustomerFollowUpId AS INVOICEID,
		Lead.LeadNo as CODE,
		 CustomerFollowUp.NextFollowupDate AS DATE,
			Lead.CustomerName as PARTY,
			Lead.CONTACTPERSON AS CONTACTPERSON,
			Lead.PHONE1 AS PHONE1,
			Lead.LEADDATE,
--			'''' as REMARKS,
CustomerFollowUp.Remarks as REMARKS,
			Lead.Email AS EMAIL
--		 Gen_User.Name AS FollowupByName, 
                      
			
FROM         CustomerFollowUp INNER JOIN
                      Gen_User ON Gen_User.UserID = CustomerFollowUp.FollowupBy INNER JOIN
                      Lead ON CustomerFollowUp.LeadID = Lead.LeadId
	Where CONVERT(VARCHAR,CustomerFollowUp.NextFollowupDate ,103) = CONVERT(VARCHAR, GETDATE(), 103) 
--and A.CompId=@i_CompId
--	Order By NextFollowupDate


END












' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_mailStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_mailStatus]
	-- Add the parameters for the stored procedure here
	@i_Is_SendMail bit,
	@i_Code varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update Quotation set Is_SendMail=@i_Is_SendMail where Code= @i_Code
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_Quotation_edit]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Item_Quotation_edit]
	-- Add the parameters for the stored procedure here


	@i_QuotationID int=0,
	@i_ItemID int=0,
	@i_GodownID int=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT     QuotationDetail.QDetailID, QuotationDetail.SIID, QuotationDetail.ItemID, QuotationDetail.ItemDesc, QuotationDetail.Qty, QuotationDetail.Rate, QuotationDetail.Amount, 
                      QuotationDetail.TaxClassID, QuotationDetail.ServiceRate, QuotationDetail.ServiceAmount, QuotationDetail.ExciseRate, QuotationDetail.ExciseAmount, 
                      QuotationDetail.CessRate, QuotationDetail.CessAmount, QuotationDetail.HCessRate, QuotationDetail.HCessAmount, QuotationDetail.AmountAfterExcise, 
                      QuotationDetail.CSTRate, QuotationDetail.CSTAmount, QuotationDetail.VATRate, QuotationDetail.VATAmount, QuotationDetail.AVATRate, QuotationDetail.AVATAmount, 
                      QuotationDetail.NetAmount, Item.Name AS ItemName, Gen_UOM.Name AS UOM, Item.Price,QuotationDetail.Discount,QuotationDetail.GodownID
FROM         QuotationDetail INNER JOIN
                      Quotation ON QuotationDetail.SIID = Quotation.QuotationId INNER JOIN
                      Item ON QuotationDetail.ItemID = Item.ItemID INNER JOIN
                      Gen_UOM ON Item.CUOMID = Gen_UOM.UOMID INNER JOIN
                      TaxClass ON QuotationDetail.TaxClassID = TaxClass.TaxClassID
WHERE     (Quotation.QuotationId = @i_QuotationID) AND (QuotationDetail.ItemID = @i_ItemID)
 AND (QuotationDetail.GodownID = @i_GodownID)
END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_QuotationFollowup_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_QuotationFollowup_Insert]
	-- Add the parameters for the stored procedure here
	@i_QuotationID Bigint,
	@i_FollowupDate DateTime,	
	@i_Remarks Varchar(250),
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
		
	Update Quotation set FollowUpDate =@i_FollowupDate where QuotationID = @i_QuotationID;

	INSERT INTO QuotationFollowUp(QuotationID,FollowupDate,FollowupBy,Remarks,CreatedBy,CreatedDate)
	VALUES(@i_QuotationID,@i_FollowupDate,@i_UserID,@i_Remarks,@i_UserID,@l_Date)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Check_Revised]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Check_Revised]
	-- Add the parameters for the stored procedure here
	@i_QuoCode nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @l_QuCount nvarchar(50)
	SET @l_QuCount =''''
	
	Set @l_QuCount  =  @i_QuoCode + ''%''

	Select Count(*) From Quotation Where Code Like @l_QuCount

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Quotation_Id]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Quotation_Id]
	-- Add the parameters for the stored procedure here
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT   Distinct  QuotationId
FROM         Quotation
WHERE Code=@i_Code
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Sale_Quotation]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Sale_Quotation]
	-- Add the parameters for the stored procedure here
	@i_RecID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     Quotation.QuotationId, QuotationDetail.ItemID, QuotationDetail.ItemDesc, QuotationDetail.Qty, QuotationDetail.Rate, QuotationDetail.Amount AS TotalAmount, 
                      QuotationDetail.TaxClassID, QuotationDetail.ServiceRate, QuotationDetail.ServiceAmount, QuotationDetail.ExciseRate, QuotationDetail.ExciseAmount, 
                      QuotationDetail.CessRate As ECessRate,
 QuotationDetail.CessAmount As ECessAmount, QuotationDetail.HCessRate  As HECessRate,
 QuotationDetail.HCessAmount AS HECessAmount, QuotationDetail.AmountAfterExcise, 
                      QuotationDetail.CSTRate, QuotationDetail.CSTAmount, QuotationDetail.VATRate, QuotationDetail.VATAmount, QuotationDetail.AVATRate, QuotationDetail.AVATAmount, 
                      Gen_UOM.Name AS UOM, QuotationDetail.NetAmount, Item.Name AS ItemName, Item.Code, TaxClass.Name,TaxClass.Name AS TaxClass,QuotationDetail.Discount,QuotationDetail.GodownID
FROM         Quotation INNER JOIN
                      QuotationDetail ON Quotation.QuotationId = QuotationDetail.SIID INNER JOIN
                      Item ON QuotationDetail.ItemID = Item.ItemID INNER JOIN
                      Gen_UOM ON Gen_UOM.UOMID = Item.CUOMID INNER JOIN
                      TaxClass ON QuotationDetail.TaxClassID = TaxClass.TaxClassID
WHERE     (Quotation.QuotationId = @i_RecID)

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_Quotation]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_Quotation]
	-- Add the parameters for the stored procedure here
	@i_RecID int,
    @i_CompId bigint

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     Quotation.QuotationId, Quotation.LeadId, Quotation.QDate, Quotation.QPrice, Quotation.AdvAmount, Quotation.PaidAmount, Quotation.Remarks AS Subject, 
                      Quotation.CreatedBy, Quotation.CreatedDate, Quotation.ModifiedBy, Quotation.ModifiedDate, Quotation.SIID, Quotation.TotalAmount, Quotation.ServiceAmount, 
                      Quotation.ExciseAmount, Quotation.CessAmount, Quotation.HCessAmount, Quotation.AmountAfterExcise, Quotation.CSTAmount, Quotation.VATAmount, 
                      Quotation.AVATAmount, Quotation.NetAmount, Quotation.FYID, Quotation.EmpID, Quotation.Refno, --QuotationDetail.ItemDesc, 
                    --                      Item.Name + '', '' + Item.Specification + '' ,'' + QuotationDetail.ItemDesc AS ItemName,
Item.Name + '','' as ItemName,
Item.Specification + '','' as ItemDesc,
QuotationDetail.ItemDesc as QItemDesc,QuotationDetail.Qty, QuotationDetail.Rate, TaxClass.Name AS TaxName, 
                      Lead.LeadNo, Lead.CustomerName,

 --Lead.Address + '' '' + Gen_City.Name + '' '' + Gen_Country.Name AS CustomerAddr,
Lead.Address + '','' + Gen_City.Name + '','' + Gen_State.Name AS CustomerAddr,
 Lead.LeadDate, Lead.Phone1, Lead.MobileNo, 
                      Lead.Email, QuotationDetail.Amount, Quotation.Refno AS Expr1, Gen_UOM.Name AS UOM, Quotation.Code, Lead.ContactPerson AS ContactName, Quotation.Reference,
                       QuotationDetail.Discount AS DisCount, QuotationDetail.NetAmount AS ItemNetAmount
FROM         Quotation LEFT OUTER JOIN
                      QuotationDetail ON QuotationDetail.SIID = Quotation.QuotationId LEFT OUTER JOIN
                      Item ON Item.ItemID = QuotationDetail.ItemID LEFT OUTER JOIN
                      TaxClass ON TaxClass.TaxClassID = QuotationDetail.TaxClassID LEFT OUTER JOIN
                      Lead ON Lead.LeadId = Quotation.LeadId LEFT OUTER JOIN
                      Gen_City ON Gen_City.CityID = Lead.CityID LEFT OUTER JOIN
                      Gen_State ON Gen_State.StateID = Gen_City.StateID LEFT OUTER JOIN
                      Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID LEFT OUTER JOIN
                      Gen_UOM ON Gen_UOM.UOMID = Item.CUOMID
WHERE     (Quotation.QuotationId = @i_RecID)  and Quotation.CompId=@i_CompId


END











' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Quotation_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Update record in Quotation Table
-- =============================================
--select * from Quotation
--update Quotation set FYID=1
CREATE PROCEDURE [dbo].[usp_Quotation_Update]
	@i_QuotationID Bigint ,
	@i_TotalAmount decimal(18,2),
	@i_ServiceAmount decimal(18,2),
	@i_ExciseAmount decimal(18,2),
	@i_CessAmount decimal(18,2),
	@i_HCessAmount decimal(18,2),
	@i_AmountAfterExcise decimal(18,2),
	@i_LeadId int,
	@i_QDate datetime,
	@i_QPrice decimal(18,0),
	@i_Remarks varchar(250),
	@i_UserID bigint,
	@i_Cnt Bigint,
	@i_SIID bigint,	
	@i_Refno nvarchar(250),	
	@i_CSTAmount decimal(18,2),
	@i_AdvAmount decimal(18,2),
	@i_VATAmount decimal(18,2),
	@i_AVATAmount decimal(18,2),
	@i_Discount decimal(18,2),
	@i_NetAmount decimal(18,2),
	@i_PaidAmount decimal(18,2),
	@i_TypeOfSale varchar(50),
	@i_FollowupDate datetime,
	@i_Reference nvarchar(255),
	@i_EmpID int,
	@i_Remarks_Orignal nvarchar(max),
	@i_CC varchar(MAX),
	@i_BCC varchar(MAX),
	@i_FYID bigint,
	@i_EmpAllToID int,
--	@i_FileName varchar(MAX),
	@i_Is_SendMail bit,
	@i_CompId bigint,
--@i_GodownID bigint,
	@i_XMLString xml
	--@o_ErrorMesg Varchar(200) OUTPUT

AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @l_varRec Bigint;
 	DECLARE @l_CustomerAccID Bigint
	DECLARE @l_LedNarration varchar(50)
 	DECLARE @l_Description varchar(100);
	DECLARE @l_NewID BIGINT
	-- Set Local Variable value..
	SET @l_varRec = 0;
	SET @l_Description  = ''''
	SET @l_CustomerAccID = 0
	SET @l_LedNarration =''''
	


	-- Variable for StockDetail
 
	--SET @o_ErrorMesg='''';

 
	
	-- Declare Local Variable
 	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable

 
	SET @l_Date=Convert(Datetime,getDate(),5);


	Delete From QuotationDocList Where QuotationID =@i_QuotationID; 

	Delete From QuotationPaymentDetail Where QuotationID = @i_QuotationID And IsNull(ReceivePayment,0)=0 

	Delete From QuotationDetail Where SIID = @i_SIID;

	UPDATE 
		Quotation
	SET				 
		LeadId = @i_LeadId,
		EmpID=@i_EmpID,
		QDate =@i_QDate, 
		QPrice =@i_QPrice,
	    AdvAmount =@i_AdvAmount ,
		Remarks =@i_Remarks,
		ModifiedBy = @i_UserID,
		ModifiedDate = @l_Date,
		SIID = @i_SIID,
		TotalAmount = @i_TotalAmount,   
		ServiceAmount = @i_ServiceAmount,
		ExciseAmount = @i_ExciseAmount,   
		CessAmount = @i_CessAmount,   
		HCessAmount = @i_HCessAmount,   
		AmountAfterExcise = @i_AmountAfterExcise,
		CSTAmount = @i_CSTAmount,   
		VATAmount = @i_VATAmount,   
		AVATAmount = @i_AVATAmount,   
		Discount = @i_Discount,
		NetAmount = @i_NetAmount,
		PaidAmount = @i_PaidAmount,
		Refno=@i_Refno,
		TypeOfSale=@i_TypeOfSale,
		FollowupDate=@i_FollowupDate,
		Reference=@i_Reference,
		Remarks_Orignal=@i_Remarks_Orignal,
		CC=@i_CC,
		BCC=@i_BCC,
		EmpAllToID=@i_EmpAllToID,
		FYID=@i_FYID,
		CompId=@i_CompId,
--		GodownID=@i_GodownID,
		--[FileName]=@i_FileName
		Is_SendMail=@i_Is_SendMail

	WHERE
		QuotationId = @i_QuotationId

		--	SET @l_NewID = Scope_Identity();
	--Set @o_ErrorMesg =Convert(varchar, @l_NewID);

					IF @i_Cnt > 0
				BEGIN		
					SELECT  x.d.value(''ItemID[1]'',''Bigint'') AS ItemID,
						x.d.value(''GodownID[1]'',''int'') AS GodownID,
						x.d.value(''ItemDesc[1]'',''varchar(max)'') AS ItemDesc,							
						x.d.value(''Qty[1]'',''Decimal(18,3)'') AS Qty,
						x.d.value(''Rate[1]'',''Decimal(18,2)'') AS Rate,
						x.d.value(''Amount[1]'',''Decimal(18,2)'') AS Amount,
						x.d.value(''TaxClassID[1]'',''Bigint'') AS TaxClassID,
						x.d.value(''ServiceRate[1]'',''Decimal(5,2)'') AS ServiceRate,						
						x.d.value(''ServiceAmount[1]'',''Decimal(18,2)'') AS ServiceAmount,
						x.d.value(''ExciseRate[1]'',''Decimal(5,2)'') AS ExciseRate,						
						x.d.value(''ExciseAmount[1]'',''Decimal(18,2)'') AS ExciseAmount,
						x.d.value(''EduCessRate[1]'',''Decimal(5,2)'') AS EduCessRate,						
						x.d.value(''EduCessAmount[1]'',''Decimal(18,2)'') AS EduCessAmount,
						x.d.value(''HEduCessRate[1]'',''Decimal(5,2)'') AS HEduCessRate,						
						x.d.value(''HEduCessAmount[1]'',''Decimal(18,2)'') AS HEduCessAmount,
						x.d.value(''AmountAfterExcise[1]'',''Decimal(18,2)'') AS AmountAfterExcise,						
						x.d.value(''CSTRate[1]'',''Decimal(5,2)'') AS CSTRate,
						x.d.value(''CSTAmount[1]'',''Decimal(18,2)'') AS CSTAmount,
						x.d.value(''VATRate[1]'',''Decimal(5,2)'') AS VATRate,	
						x.d.value(''VATAmount[1]'',''Decimal(18,2)'') AS VATAmount,
						x.d.value(''AVATRate[1]'',''Decimal(5,2)'') AS AVATRate,
						x.d.value(''AVATAmount[1]'',''Decimal(18,2)'') AS AVATAmount,
						x.d.value(''NetAmount[1]'',''Decimal(18,2)'') AS NetAmount,
						x.d.value(''Discount[1]'',''Decimal(18,2)'') AS Discount	
					INTO #tmpDetail				
					FROM 
						@i_XMLString.nodes(''/NewDataSet/Table'') x(d);

					INSERT INTO QuotationDetail (SIID,    ItemID,GodownID,   ItemDesc,     Qty,   Rate,  Amount,   TaxClassID,    ServiceRate,  ServiceAmount,   ExciseRate,   ExciseAmount,       CessRate,      CessAmount,     HCessRate,      HCessAmount,   AmountafterExcise,   CSTRate,   CSTAmount,   VATRate,   VATAmount,   AVATRate,   AVATAmount,   NetAmount,Discount)
											SELECT @i_SIID,T1.ItemID,T1.GodownID,T1.ItemDesc,T1.Qty,T1.Rate,T1.Amount,T1.TaxClassID,T1.ServiceRate,T1.ServiceAmount,T1.ExciseRate,T1.ExciseAmount,T1.EduCessRate,T1.EduCessAmount,T1.HEduCessRate,T1.HEduCessAmount,T1.AmountafterExcise,T1.CSTRate,T1.CSTAmount,T1.VATRate,T1.VATAmount,T1.AVATRate,T1.AVATAmount,T1.NetAmount,T1.Discount FROM #tmpDetail T1 


				End
--			 ELSE
--			  BEGIN
--					--SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 25001 );
--			  END	
END

 























' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Quotation_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	List of Quotation
-- =============================================
--select * from Quotation_Contact
CREATE PROCEDURE [dbo].[usp_Quotation_Select]
--[usp_Quotation_Select]''201''
	@i_RecID Bigint
--	@i_CompId bigint
AS
declare @i_Code as varchar(50)
BEGIN
	SET NOCOUNT ON;

SELECT     Quotation.QuotationId, Quotation.LeadId, Quotation.QDate, Quotation.QPrice, Quotation.PaidAmount, Quotation.Remarks, Quotation.SIID, Quotation.TotalAmount, Quotation.ServiceAmount, 
                      Quotation.ExciseAmount, Quotation.CessAmount, Quotation.HCessAmount, Quotation.AmountAfterExcise, Quotation.CSTAmount, Quotation.VATAmount, Quotation.AVATAmount, Quotation.Discount, 
                      Quotation.NetAmount, Quotation.FYID, Quotation.EmpID, Quotation.EmpAllToID, Quotation.Refno, Quotation.Code, Quotation.TypeOfSale, Lead.LeadNo, Lead.CustomerName, Lead.CreatedDate, 
                      Lead.LeadDate, Quotation.FollowupDate, Quotation.Reference, Lead.Phone1, Lead.ContactPerson, Lead.Address + '' ,'' + Gen_City.Name + '', '' + Gen_State.Name + '', '' + Gen_Country.Name AS Address,
                       Lead.Email, Quotation.Remarks_Orignal, Quotation.CC, Quotation.BCC, Lead.Category, Lead.AllocatedToEmpID, Lead.InterestLevel, Quotation.CompId, Quotation.Is_SendMail,Quotation.GodownID
FROM         Quotation LEFT OUTER JOIN
                      Lead ON Lead.LeadId = Quotation.LeadId LEFT OUTER JOIN
                      Gen_City ON Gen_City.CityID = Lead.CityID LEFT OUTER JOIN
                      Gen_State ON Gen_State.StateID = Gen_City.StateID LEFT OUTER JOIN
                      Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID
WHERE     (Quotation.QuotationId = @i_RecID)
-- and Quotation.CompId=@i_CompId
		

	Select QDocID,
		QuotationID,
		DocName,
		Remarks 
	From QuotationDocList
	Where QuotationID = @i_RecID ;
	
	Select  
		NextDate,
		Payment,
		Remarks
	From QuotationPaymentDetail
	Where QuotationID = @i_RecID ;


SELECT     Item.Name AS ItemName, Gen_UOM.Name AS UOM, QuotationDetail.SIID, QuotationDetail.ItemID, QuotationDetail.ItemDesc, QuotationDetail.Qty, QuotationDetail.Rate,
                       QuotationDetail.Amount AS TotalAmount, QuotationDetail.TaxClassID, QuotationDetail.ServiceRate, QuotationDetail.ServiceAmount, QuotationDetail.ExciseRate, 
                      QuotationDetail.ExciseAmount, QuotationDetail.CessRate AS ECessRate, QuotationDetail.CessAmount AS ECessAmount, QuotationDetail.HCessRate AS HECessRate, 
                      QuotationDetail.HCessAmount AS HECessAmount, QuotationDetail.AmountAfterExcise, QuotationDetail.CSTRate, QuotationDetail.CSTAmount, QuotationDetail.VATRate, 
                      QuotationDetail.VATAmount, QuotationDetail.AVATRate, QuotationDetail.AVATAmount, QuotationDetail.NetAmount, QuotationDetail.QDetailID,QuotationDetail.Discount,QuotationDetail.GodownID
FROM         Gen_UOM INNER JOIN
                      Item ON Gen_UOM.UOMID = Item.CUOMID INNER JOIN
                      QuotationDetail INNER JOIN
                      TaxClass ON QuotationDetail.TaxClassID = TaxClass.TaxClassID ON Item.ItemID = QuotationDetail.ItemID
WHERE     (QuotationDetail.SIID = @i_RecID)

select @i_Code=Code from Quotation where QuotationId = @i_RecID

SELECT     Code, RefID,ContactID, ContactType, ContactTitle, Designation, ContactName, Phone1, Phone2, Mobile, Email, DoB, DoA
FROM         Quotation_Contact where Code=@i_Code
END







































' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Automatic_Number_ID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:        Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:    Generate Auto No...
-- Changes 
-- sr#    Date      Chaned By      Description
-- =============================================
--select * from Quotation
CREATE PROCEDURE [dbo].[usp_Automatic_Number_ID] 
--[usp_Automatic_Number_ID] '''','''',''''
    @i_Module varchar(5),
	@i_YearCode Varchar(20),
	@i_FYID BIGINT,

	@i_CompId bigint

AS
BEGIN
    Declare @l_MaxNo bigint;
    DEclare @l_FinalCode varchar(20);
Declare @l_PromoMaxNo bigint;
--------------------------------------
	Declare @l_Year varchar(10); 
	--SET @l_Year=''14-15''
-- added by rooja---------
if(cast(Day(GETDATE()) as varchar(10))=''1'' and cast(Month(GETDATE()) as varchar(10))=''4'')

	--print ''1 april '';
	begin
	Declare @StartYear varchar(5);
	Declare @EndYear varchar(5);
	--Declare @l_Year varchar(10);
	--select @l_Year=''123'';

		set @StartYear=SUBSTRING(CAST(YEAR(GETDATE())  AS varchar(4)),3,2)
		SET @EndYear=SUBSTRING(CAST((YEAR(GETDATE())+1) AS varchar(4)),3,2)

		SET @l_Year=@StartYear+''-''+@EndYear
	print @StartYear
	print @l_Year;
	end
else
	begin
		if(cast(Month(GETDATE()) as varchar(10))<4)
			begin
			print ''less than 4''
			SET @StartYear=substring(cast((YEAR(GETDATE()) - 1) as varchar(4)),3,2)
				SET @EndYear=SUBSTRING(CAST((YEAR(GETDATE())) AS varchar(4)),3,2)

				SET @l_Year=@StartYear+''-''+@EndYear
			print @l_Year
			end
		else if(cast(Month(GETDATE()) as varchar(10))<=12 and cast(Month(GETDATE()) as varchar(10))>=4)
			begin
			print ''month greater than 4 and less than 12''

			set @StartYear=SUBSTRING(CAST(YEAR(GETDATE()) AS varchar(4)),3,2)
				SET @EndYear=SUBSTRING(CAST((YEAR(GETDATE())+1) AS varchar(4)),3,2)
			SET @l_Year=@StartYear+''-''+@EndYear
			print @l_Year
			end
	end
--------------------------------------------

declare @ComName varchar(100)
declare @Sub1 varchar(100)
declare @Sub2 varchar(100)
declare @car varchar(100)

select @ComName=CompanyName from CompanyInfo where CompId=@i_CompId 
--set @ComName=''Indian Gasket''
set @Sub1=@ComName
set @Sub2=@ComName

if CHARINDEX('' '',@ComName) > 0
begin
    PRINT ''SPACE IN STRING'' 
	set @Sub1=SUBSTRING(@ComName, 1, CHARINDEX('' '', @ComName) - 1)
set @Sub2=SUBSTRING(@ComName, CHARINDEX('' '', @ComName) + 1, 8000) 
set @car=LEFT(@Sub1, 1)+LEFT(@Sub2, 1)  
PRINT @car
end
ELSE
BEGIN 
PRINT ''NO SPACE''
	set @Sub1=@ComName
 set @car=LEFT(@Sub1, 2) 
PRINT @car
END

---------------------------------
	If @i_Module = ''Promo''
		BEGIN
			            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,PromoMailID)),0) from PromoMail where CompId=@i_CompId
						 set @l_MaxNo   = @l_MaxNo  + 1
						Select  @l_FinalCode  = @l_MaxNo
			
--            FROM Item
--            set @l_MaxNo   = @l_MaxNo  + 1
		END


    If @i_Module = ''ITEM''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((Code),5))),0)
            FROM Item
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
    ELSE If @i_Module = ''VEN''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((Code),5))),0)
            FROM Vendor 
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
    Else If @i_Module = ''CUST''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((Code),5))),0)
            from Customer
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
--select * from Lead
	Else  If @i_Module = ''INQ''
			BEGIN
				SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((LeadNo),5))),0)
				from Lead where CompId=@i_CompId
				set @l_MaxNo   = @l_MaxNo  + 1

				-- Genarete Code with MAX
					Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
		END 
     Else If @i_Module = ''ACC''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((AccountCode),5))),0)
            from Account
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
    Else If @i_Module = ''PI''
        BEGIN
--			IF @l_Year=''14-15''
--			BEGIN
--            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((PurchaseCode),5))),0)
--            FROM PurchaseInvoice WHERE FYID = @i_FYID
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--           -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
--			END
--			ELSE
			--BEGIN
				 SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((PurchaseCode),5))),0)
            FROM PurchaseInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((PurchaseCode),8))=''PI'' + ''/'' + @l_Year
            set @l_MaxNo   = @l_MaxNo  + 1
        
           -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''/'' + @l_Year + ''/''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
			--END
        END
	Else If @i_Module = ''RI''
        BEGIN
--			IF @l_Year=''14-15''
--			BEGIN
--            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((SalesCode),5))),0)
--            FROM SalesInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((SalesCode),2))=''RI''
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--            -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
--			END
--			ELSE
--			BEGIN
				 SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((SalesCode),5))),0)
            FROM SalesInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((SalesCode),8))=''RI''+ ''/'' + @l_Year and CompId=@i_CompId
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''/'' + @l_Year + ''/''  +  REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
			--END
        END
	Else If @i_Module = ''TI''
        BEGIN
--			IF @l_Year=''14-15''
--			BEGIN
--            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((SalesCode),5))),0)
--            FROM SalesInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((SalesCode),2))=''TI''
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--            -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5)) 
--			END
--			ELSE
--			BEGIN
				SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((SalesCode),5))),0)
            FROM SalesInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((SalesCode),8))=''TI''+ ''/'' + @l_Year and CompId=@i_CompId
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module+ ''/'' + @l_Year + ''/''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
			--END 
        END
		Else If @i_Module = ''ES''
        BEGIN
--			IF @l_Year=''14-15''
--			BEGIN
--            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((SalesCode),5))),0)
--            FROM SalesInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((SalesCode),2))=''ES''
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--            -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))
--			END
--			ELSE
--			BEGIN
				 SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((SalesCode),5))),0)
            FROM SalesInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((SalesCode),8))=''ES''+ ''/'' + @l_Year and CompId=@i_CompId
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''/'' + @l_Year + ''/''  +  REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))
			--END  
        END
		Else If @i_Module = ''SR''
        BEGIN
--			IF @l_Year=''14-15''
--			BEGIN
--            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((RequestNo),5))),0)
--            from ServiceModule
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--            -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
--			END
--			ELSE
--			BEGIN
				 SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((RequestNo),5))),0)
            from ServiceModule WHERE FYID = @i_FYID and Convert(Varchar(50),Left((RequestNo),8))=''SR''+ ''/'' + @l_Year and CompId=@i_CompId
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''/'' + @l_Year + ''/''  +  REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
			--END
        END
---------------------
--		Else If @i_Module Like ''%QU''
--        BEGIN
--            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((QuotationId),5))),0)
--            from Quotation
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--            -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5)) 
---------------------------------------
Else If @i_Module Like ''QU''
--SELECT left(code,8),* FROM Quotation where FYID=1 and Convert(Varchar(50),Left((Code),8))=''QU''+ ''/'' +''15-16''
--SELECT right(code,5),* FROM Quotation where FYID=1
--update Quotation set FYID=1
--update ServiceModule set FYID=1
        BEGIN
--			IF @l_Year=''14-15''
--			BEGIN
--				  SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((QuotationId),5))),0)
--            from Quotation
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--            -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5)) 
--			END
--			ELSE
--			BEGIN
	--select *,left(Code,11) from Quotation where right(Code,2) not like ''%R%'' and Convert(Varchar(50),Left((Code),11))=''MA/QU''+ ''/'' + ''15-16'' where FYID=1 and Code not like ''%R%'' and Convert(Varchar(50),Left((Code),8))=''QU''+ ''/'' + ''15-16''
--update Quotation set FYID=1
--select * from Quotation 
				 SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((Code),5))),0)
            from Quotation WHERE FYID = @i_FYID  and Convert(Varchar(50),Left((Code),11))=@car+''/''+''QU''+ ''/'' + @l_Year and right(Code,2) not like ''%R%'' and CompId=@i_CompId
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @car+''/''+@i_Module + ''/'' + @l_Year + ''/''  +  REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
			--END        
        END 
        --END
        Else If @i_Module = ''EXP''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((ExpNo),5))),0)
            FROM Expense WHERE FYID = @i_FYID
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
         
        Else If @i_Module = ''VPAY''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((PaymentCode),5))),0)
            from Payment
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
        Else If @i_Module = ''CPAY''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((ReceiptCode),5))),0)
            from Receipt
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END

Else If @i_Module = ''PO''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((PurchaseCode),5))),0)
            FROM PO WHERE FYID = @i_FYID
            set @l_MaxNo   = @l_MaxNo  + 1
        
           -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
Else If @i_Module = ''GRN''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((PurchaseCode),5))),0)
            FROM Indent WHERE FYID = @i_FYID
            set @l_MaxNo   = @l_MaxNo  + 1
        
           -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
     
    Select  isnull(@l_MaxNo,1);
    
END
















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Automatic_Number]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:        Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:    Generate Auto No...
-- Changes 
-- sr#    Date      Chaned By      Description
-- =============================================
--select * from Quotation
CREATE PROCEDURE [dbo].[usp_Automatic_Number] 
--[usp_Automatic_Number] '''','''',''''
    @i_Module varchar(5),
	@i_YearCode Varchar(20),
	@i_FYID BIGINT,

	@i_CompId bigint

AS
BEGIN
    Declare @l_MaxNo bigint;
    DEclare @l_FinalCode varchar(20);
Declare @l_PromoMaxNo bigint;
--------------------------------------
	Declare @l_Year varchar(10); 
	--SET @l_Year=''14-15''
-- added by rooja---------
if(cast(Day(GETDATE()) as varchar(10))=''1'' and cast(Month(GETDATE()) as varchar(10))=''4'')

	--print ''1 april '';
	begin
	Declare @StartYear varchar(5);
	Declare @EndYear varchar(5);
	--Declare @l_Year varchar(10);
	--select @l_Year=''123'';

		set @StartYear=SUBSTRING(CAST(YEAR(GETDATE())  AS varchar(4)),3,2)
		SET @EndYear=SUBSTRING(CAST((YEAR(GETDATE())+1) AS varchar(4)),3,2)

		SET @l_Year=@StartYear+''-''+@EndYear
	print @StartYear
	print @l_Year;
	end
else
	begin
		if(cast(Month(GETDATE()) as varchar(10))<4)
			begin
			print ''less than 4''
			SET @StartYear=substring(cast((YEAR(GETDATE()) - 1) as varchar(4)),3,2)
				SET @EndYear=SUBSTRING(CAST((YEAR(GETDATE())) AS varchar(4)),3,2)

				SET @l_Year=@StartYear+''-''+@EndYear
			print @l_Year
			end
		else if(cast(Month(GETDATE()) as varchar(10))<=12 and cast(Month(GETDATE()) as varchar(10))>=4)
			begin
			print ''month greater than 4 and less than 12''

			set @StartYear=SUBSTRING(CAST(YEAR(GETDATE()) AS varchar(4)),3,2)
				SET @EndYear=SUBSTRING(CAST((YEAR(GETDATE())+1) AS varchar(4)),3,2)
			SET @l_Year=@StartYear+''-''+@EndYear
			print @l_Year
			end
	end
--------------------------------------------

declare @ComName varchar(100)
declare @Sub1 varchar(100)
declare @Sub2 varchar(100)
declare @car varchar(100)

select @ComName=CompanyName from CompanyInfo where CompId=@i_CompId 
--set @ComName=''Indian Gasket''
set @Sub1=@ComName
set @Sub2=@ComName

if CHARINDEX('' '',@ComName) > 0
begin
    PRINT ''SPACE IN STRING'' 
	set @Sub1=SUBSTRING(@ComName, 1, CHARINDEX('' '', @ComName) - 1)
set @Sub2=SUBSTRING(@ComName, CHARINDEX('' '', @ComName) + 1, 8000) 
set @car=LEFT(@Sub1, 1)+LEFT(@Sub2, 1)  
PRINT @car
end
ELSE
BEGIN 
PRINT ''NO SPACE''
	set @Sub1=@ComName
 set @car=LEFT(@Sub1, 2) 
PRINT @car
END

---------------------------------
	If @i_Module = ''Promo''
		BEGIN
			            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,PromoMailID)),0) from PromoMail where CompId=@i_CompId
						 set @l_MaxNo   = @l_MaxNo  + 1
						Select  @l_FinalCode  = @l_MaxNo
			
--            FROM Item
--            set @l_MaxNo   = @l_MaxNo  + 1
		END


    If @i_Module = ''ITEM''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((Code),5))),0)
            FROM Item
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
    ELSE If @i_Module = ''VEN''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((Code),5))),0)
            FROM Vendor 
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
    Else If @i_Module = ''CUST''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((CustomerCode),5))),0)
            from CustomerMain
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
--select * from Lead
	Else  If @i_Module = ''INQ''
			BEGIN
				SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((LeadNo),5))),0)
				from Lead where CompId=@i_CompId
				set @l_MaxNo   = @l_MaxNo  + 1

				-- Genarete Code with MAX
					Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
		END 
     Else If @i_Module = ''ACC''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((AccountCode),5))),0)
            from Account
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
    Else If @i_Module = ''PI''
        BEGIN
--			IF @l_Year=''14-15''
--			BEGIN
--            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((PurchaseCode),5))),0)
--            FROM PurchaseInvoice WHERE FYID = @i_FYID
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--           -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
--			END
--			ELSE
			--BEGIN
				 SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((PurchaseCode),5))),0)
            FROM PurchaseInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((PurchaseCode),8))=''PI'' + ''/'' + @l_Year
            set @l_MaxNo   = @l_MaxNo  + 1
        
           -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''/'' + @l_Year + ''/''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
			--END
        END
	Else If @i_Module = ''RI''
        BEGIN
--			IF @l_Year=''14-15''
--			BEGIN
--            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((SalesCode),5))),0)
--            FROM SalesInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((SalesCode),2))=''RI''
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--            -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
--			END
--			ELSE
--			BEGIN
				 SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((SalesCode),5))),0)
            FROM SalesInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((SalesCode),8))=''RI''+ ''/'' + @l_Year and CompId=@i_CompId
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''/'' + @l_Year + ''/''  +  REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
			--END
        END
	Else If @i_Module = ''TI''
        BEGIN
--			IF @l_Year=''14-15''
--			BEGIN
--            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((SalesCode),5))),0)
--            FROM SalesInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((SalesCode),2))=''TI''
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--            -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5)) 
--			END
--			ELSE
--			BEGIN
				SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((SalesCode),5))),0)
            FROM SalesInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((SalesCode),8))=''TI''+ ''/'' + @l_Year and CompId=@i_CompId
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module+ ''/'' + @l_Year + ''/''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
			--END 
        END
		Else If @i_Module = ''ES''
        BEGIN
--			IF @l_Year=''14-15''
--			BEGIN
--            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((SalesCode),5))),0)
--            FROM SalesInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((SalesCode),2))=''ES''
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--            -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))
--			END
--			ELSE
--			BEGIN
				 SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((SalesCode),5))),0)
            FROM SalesInvoice WHERE FYID = @i_FYID and Convert(Varchar(50),Left((SalesCode),8))=''ES''+ ''/'' + @l_Year and CompId=@i_CompId
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''/'' + @l_Year + ''/''  +  REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))
			--END  
        END
		Else If @i_Module = ''SR''
        BEGIN
--			IF @l_Year=''14-15''
--			BEGIN
--            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((RequestNo),5))),0)
--            from ServiceModule
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--            -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
--			END
--			ELSE
--			BEGIN
				 SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((RequestNo),5))),0)
            from ServiceModule WHERE FYID = @i_FYID and Convert(Varchar(50),Left((RequestNo),8))=''SR''+ ''/'' + @l_Year and CompId=@i_CompId
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''/'' + @l_Year + ''/''  +  REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
			--END
        END
---------------------
--		Else If @i_Module Like ''%QU''
--        BEGIN
--            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((QuotationId),5))),0)
--            from Quotation
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--            -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5)) 
---------------------------------------
Else If @i_Module Like ''QU''
--SELECT left(code,8),* FROM Quotation where FYID=1 and Convert(Varchar(50),Left((Code),8))=''QU''+ ''/'' +''15-16''
--SELECT right(code,5),* FROM Quotation where FYID=1
--update Quotation set FYID=1
--update ServiceModule set FYID=1
        BEGIN
--			IF @l_Year=''14-15''
--			BEGIN
--				  SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((QuotationId),5))),0)
--            from Quotation
--            set @l_MaxNo   = @l_MaxNo  + 1
--        
--            -- Genarete Code with MAX
--                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5)) 
--			END
--			ELSE
--			BEGIN
	--select *,left(Code,11) from Quotation where right(Code,2) not like ''%R%'' and Convert(Varchar(50),Left((Code),11))=''MA/QU''+ ''/'' + ''15-16'' where FYID=1 and Code not like ''%R%'' and Convert(Varchar(50),Left((Code),8))=''QU''+ ''/'' + ''15-16''
--update Quotation set FYID=1
--select * from Quotation 
				 SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((Code),5))),0)
            from Quotation WHERE FYID = @i_FYID  and Convert(Varchar(50),Left((Code),11))=@car+''/''+''QU''+ ''/'' + @l_Year and right(Code,2) not like ''%R%'' and CompId=@i_CompId
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @car+''/''+@i_Module + ''/'' + @l_Year + ''/''  +  REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
			--END        
        END 
        --END
        Else If @i_Module = ''EXP''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((ExpNo),5))),0)
            FROM Expense WHERE FYID = @i_FYID
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
         
        Else If @i_Module = ''VPAY''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((PaymentCode),5))),0)
            from Payment
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
        Else If @i_Module = ''CPAY''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((ReceiptCode),5))),0)
            from Receipt
            set @l_MaxNo   = @l_MaxNo  + 1
        
            -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END

Else If @i_Module = ''PO''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((PurchaseCode),5))),0)
            FROM PO WHERE FYID = @i_FYID
            set @l_MaxNo   = @l_MaxNo  + 1
        
           -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
Else If @i_Module = ''GRN''
        BEGIN
            SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((PurchaseCode),5))),0)
            FROM Indent WHERE FYID = @i_FYID
            set @l_MaxNo   = @l_MaxNo  + 1
        
           -- Genarete Code with MAX
                Select  @l_FinalCode  = @i_Module + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
        END
     
    Select  isnull(@l_FinalCode,1);
    
END
















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Sale_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Sale_LOV]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here



SELECT    Lead.LeadId, Lead.LeadNo, Lead.LeadDate, Lead.CustomerName, Lead.Address,Lead.CityID, Lead.Pincode, Lead.Phone1, Lead.MobileNo, Lead.Email, Lead.SourceOfLead, Lead.CustomerBudget, Lead.InterestLevel, Lead.NextFollowUpDate, 
                      Lead.Specification, Lead.Remarks, Lead.LeadStatusID, Lead.CreatedBy, Lead.CreatedDate, Lead.ModifiedBy, Lead.ModifiedDate, Lead.AccountID, Lead.Quotation_Send, Customer.CustomerID
FROM         Customer INNER JOIN
                      Lead ON Customer.LeadId=Lead.LeadId
where Lead.LeadID  in (select LeadID from Quotation)
	Order By LeadNo,CustomerName






--	  SELECT  LeadId, LeadNo, LeadDate, CustomerName, Address, CityID, Pincode, Phone1, MobileNo, Email, SourceOfLead, CustomerBudget, InterestLevel, NextFollowUpDate, 
--                      Specification, Remarks, LeadStatusID, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, AccountID, Quotation_Send
--	From 
--		Lead Where Lead.LeadID   in (select LeadID from Quotation)
--	Order By LeadNo,CustomerName



END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Quotation_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Insert record in Quotation Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_Quotation_Insert]

	@i_LeadId Bigint,
	@i_EmpID int,
	@i_QDate datetime,
	@i_QPrice decimal(18,0),
	@i_AdvAmount decimal(18,0),
	@i_PaidAmount decimal(18,0),
	@i_Remarks varchar(250),
	@i_UserID bigint,
	@i_Cnt Bigint,
	@i_SIID bigint,	
	@i_Refno nvarchar(250),
	@i_TotalAmount decimal(18,2),
	@i_ServiceAmount decimal(18,2),
	@i_ExciseAmount decimal(18,2),
	@i_CessAmount decimal(18,2),
	@i_HCessAmount decimal(18,2),
	@i_AmountAfterExcise decimal(18,2),
	@i_CSTAmount decimal(18,2),
	@i_VATAmount decimal(18,2),
	@i_AVATAmount decimal(18,2),
	@i_Discount decimal(18,2),
	@i_NetAmount decimal(18,2),
	@i_TypeOfSale varchar(50),
	@i_Code varchar(50),
	@i_FollowupDate datetime,
	@i_XMLString xml,
	@i_Reference nvarchar(255),
	@i_Remarks_Orignal nvarchar(max),
	@i_CC varchar(MAX),
	@i_BCC varchar(MAX),
--	@i_Category nvarchar(50),
	@i_EmpAllToID int,
	@i_FYID bigint,
	@i_Is_SendMail bit,
	@i_CompId bigint,
	--@i_Status nvarchar(50),
	--@i_FileName varchar(MAX),
	--@i_Is_SendMail bit,
--	@i_GodownID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @l_varRec Bigint;
 	DECLARE @l_CustomerAccID Bigint
	DECLARE @l_LedNarration varchar(50)
	DECLARE @l_StockID Bigint
	DECLARE @l_NewDetID Bigint
	DECLARE @l_NewID BIGINT
	DECLARE @l_Description varchar(100);
	-- Set Local Variable value..
	SET @l_varRec = 0;
	SET @l_Description  = ''''
	SET @l_CustomerAccID = 0
	SET @l_LedNarration =''''
	SET @l_StockID = 0
	SET @l_NewDetID = 0
	-- Variable for StockDetail
 
	SET @o_ErrorMesg='''';
	SET @l_NewID = 0
 
	DECLARE	@l_Date Datetime;

	Set @o_ErrorMesg = '''';
	SET @l_Date=Convert(Datetime,getDate(),5);

--	SELECT @l_varRec = Count(SIID) From Quotation Where RequestNo = @i_RequestNo
-- 		IF @l_varRec = 0
-- 			BEGIN
--		Set @l_LedNarration  = ''Service Against '' + @i_RequestNo


	INSERT INTO Quotation(LeadId,  QDate, QPrice, AdvAmount,PaidAmount,Remarks,CreatedBy,CreatedDate,SIID ,TotalAmount, ServiceAmount,ExciseAmount,CessAmount,HCessAmount, AmountAfterExcise, CSTAmount,VATAmount, AVATAmount,Discount,NetAmount, Refno,TypeOfSale,Code,FollowupDate,Reference,EmpID,EmpAllToID,Remarks_Orignal,
CC,BCC,FYID,Is_SendMail,CompId)
				VALUES(@i_LeadId,@i_QDate,@i_QPrice,@i_AdvAmount,@i_PaidAmount, @i_Remarks,@i_UserID,@l_Date, @i_SIID , @i_TotalAmount,@i_ServiceAmount, @i_ExciseAmount,@i_CessAmount,@i_HCessAmount, @i_AmountAfterExcise,@i_CSTAmount,@i_VATAmount, @i_AVATAmount,@i_Discount,@i_NetAmount , @i_Refno,
@i_TypeOfSale,@i_Code,@i_FollowupDate,@i_Reference,@i_EmpID,@i_EmpAllToID,@i_Remarks_Orignal,
@i_CC,@i_BCC,@i_FYID,@i_Is_SendMail,@i_CompId)
	
update Lead set InterestLevel=''QUOTATION'' where LeadId=@i_LeadId

	SET @l_NewID = Scope_Identity();
	Set @o_ErrorMesg =Convert(varchar, @l_NewID);

 				-- Customer''s Ledger Effect				
					IF @i_Cnt > 0
				BEGIN		
					SELECT  

						x.d.value(''ItemID[1]'',''int'') AS ItemID,
						x.d.value(''GodownID[1]'',''int'') AS GodownID,
						x.d.value(''ItemDesc[1]'',''varchar(max)'') AS ItemDesc,							
						x.d.value(''Qty[1]'',''Decimal(18,3)'') AS Qty,
						x.d.value(''Rate[1]'',''Decimal(18,2)'') AS Rate,
						x.d.value(''Amount[1]'',''Decimal(18,2)'') AS Amount,
						x.d.value(''TaxClassID[1]'',''Bigint'') AS TaxClassID,
						x.d.value(''ServiceRate[1]'',''Decimal(5,2)'') AS ServiceRate,						
						x.d.value(''ServiceAmount[1]'',''Decimal(18,2)'') AS ServiceAmount,
						x.d.value(''ExciseRate[1]'',''Decimal(5,2)'') AS ExciseRate,						
						x.d.value(''ExciseAmount[1]'',''Decimal(18,2)'') AS ExciseAmount,
						x.d.value(''EduCessRate[1]'',''Decimal(5,2)'') AS EduCessRate,						
						x.d.value(''EduCessAmount[1]'',''Decimal(18,2)'') AS EduCessAmount,
						x.d.value(''HEduCessRate[1]'',''Decimal(5,2)'') AS HEduCessRate,						
						x.d.value(''HEduCessAmount[1]'',''Decimal(18,2)'') AS HEduCessAmount,
						x.d.value(''AmountAfterExcise[1]'',''Decimal(18,2)'') AS AmountAfterExcise,						
						x.d.value(''CSTRate[1]'',''Decimal(5,2)'') AS CSTRate,
						x.d.value(''CSTAmount[1]'',''Decimal(18,2)'') AS CSTAmount,
						x.d.value(''VATRate[1]'',''Decimal(5,2)'') AS VATRate,	
						x.d.value(''VATAmount[1]'',''Decimal(18,2)'') AS VATAmount,
						x.d.value(''AVATRate[1]'',''Decimal(5,2)'') AS AVATRate,
						x.d.value(''AVATAmount[1]'',''Decimal(18,2)'') AS AVATAmount,
						x.d.value(''NetAmount[1]'',''Decimal(18,2)'') AS NetAmount,	
						x.d.value(''Discount[1]'',''Decimal(18,2)'') AS Discount	
					INTO #tmpDetail				
					FROM 
						@i_XMLString.nodes(''/NewDataSet/Table'') x(d);

					INSERT INTO QuotationDetail (SIID,    ItemID,GodownID,   ItemDesc,     Qty,   Rate,  Amount,   TaxClassID,    ServiceRate,  ServiceAmount,   ExciseRate,   ExciseAmount,       CessRate,      CessAmount,     HCessRate,      HCessAmount,   AmountafterExcise,   CSTRate,   CSTAmount,   VATRate,   VATAmount,   AVATRate,   AVATAmount,   NetAmount,Discount)
											SELECT @l_NewID,T1.ItemID,T1.GodownID,T1.ItemDesc,T1.Qty,T1.Rate,T1.Amount,T1.TaxClassID,T1.ServiceRate,T1.ServiceAmount,T1.ExciseRate,T1.ExciseAmount,T1.EduCessRate,T1.EduCessAmount,T1.HEduCessRate,T1.HEduCessAmount,T1.AmountafterExcise,T1.CSTRate,T1.CSTAmount,T1.VATRate,T1.VATAmount,T1.AVATRate,T1.AVATAmount,T1.NetAmount,T1.Discount FROM #tmpDetail T1 



						END

		 ELSE
			  BEGIN
					SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 25001 );
			  END	


END




















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Quotation_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Description:	List of Quotation
-- =============================================
--select * from Quotation
--truncate table Quotation
--select * from Lead
CREATE PROCEDURE [dbo].[usp_Quotation_List]
--[usp_Quotation_List]''1'',''1''
@i_CompId bigint,
	@i_UserID bigint
AS
BEGIN
    SET NOCOUNT ON;

if @i_UserID = 1

begin
SELECT     Quotation.QuotationId, Quotation.QDate, Quotation.QPrice, Quotation.QPrice - Quotation.PaidAmount AS PendingAmount, Quotation.LeadId, Quotation.AdvAmount, 
                      Quotation.PaidAmount, Quotation.Remarks AS Remark, Quotation.CreatedBy, Quotation.CreatedDate, Quotation.ModifiedBy, Quotation.ModifiedDate, Quotation.SIID, 
                      Quotation.TotalAmount, Quotation.ServiceAmount, Quotation.ExciseAmount, Quotation.CessAmount, Quotation.HCessAmount, Quotation.AmountAfterExcise, 
                      Quotation.CSTAmount, Quotation.VATAmount, Quotation.AVATAmount, Quotation.Discount, Quotation.NetAmount, Quotation.FYID, Quotation.EmpID, Quotation.Refno, 
                      Quotation.TypeOfSale, Quotation.Code, Quotation.FollowupDate AS FollowupDate1, Quotation.Reference, Quotation.CC, Quotation.BCC, 
                      CASE WHEN Quotation.Is_SendMail = ''False'' THEN ''Not Sent'' ELSE ''Sent'' END AS Is_SendMail, Lead.CustomerName, Lead.LeadNo, Lead.CityID, Lead.Category, 
                      Lead.ContactPerson, Lead.Phone1, Lead.MobileNo AS Mobile, Lead.Email, Lead.InterestLevel AS Status, Lead.Category AS Expr1, Lead.AllocatedToEmpID, 
                      Employee.EmpName, Employee_1.EmpName AS EmpAllTo, Quotation.CompId, Gen_State.Name AS StateName, Gen_State.StateID, Lead.SourceOfLead
FROM         Quotation LEFT OUTER JOIN
                      Employee ON Employee.EmpID = Quotation.EmpID LEFT OUTER JOIN
                      Employee AS Employee_1 ON Quotation.EmpAllToID = Employee_1.EmpID LEFT OUTER JOIN
                      Gen_State LEFT OUTER JOIN
                      Gen_City ON Gen_City.StateID = Gen_State.StateID LEFT OUTER JOIN
                      Lead ON Lead.CityID = Gen_City.CityID ON Lead.LeadId = Quotation.LeadId where Quotation.CompId=@i_CompId
                --AND Lead.AllocatedToEmpID = Employee.EmpID
    ORDER BY Quotation.QDate
END
else
SELECT     Quotation.QuotationId, Quotation.QDate, Quotation.QPrice, Quotation.QPrice - Quotation.PaidAmount AS PendingAmount, Quotation.LeadId, Quotation.AdvAmount, 
                      Quotation.PaidAmount, Quotation.Remarks AS Remark, Quotation.CreatedBy, Quotation.CreatedDate, Quotation.ModifiedBy, Quotation.ModifiedDate, Quotation.SIID, 
                      Quotation.TotalAmount, Quotation.ServiceAmount, Quotation.ExciseAmount, Quotation.CessAmount, Quotation.HCessAmount, Quotation.AmountAfterExcise, 
                      Quotation.CSTAmount, Quotation.VATAmount, Quotation.AVATAmount, Quotation.Discount, Quotation.NetAmount, Quotation.FYID, Quotation.EmpID, Quotation.Refno, 
                      Quotation.TypeOfSale, Quotation.Code, Quotation.FollowupDate AS FollowupDate1, Quotation.Reference, Quotation.CC, Quotation.BCC, 
                      CASE WHEN Quotation.Is_SendMail = ''False'' THEN ''Not Sent'' ELSE ''Sent'' END AS Is_SendMail, Lead.CustomerName, Lead.LeadNo, Lead.CityID, Lead.Category, 
                      Lead.ContactPerson, Lead.Phone1, Lead.MobileNo AS Mobile, Lead.Email, Lead.InterestLevel AS Status, Lead.Category AS Expr1, Lead.AllocatedToEmpID, 
                      Employee.EmpName, Employee_1.EmpName AS EmpAllTo, Quotation.CompId, Gen_State.Name AS StateName, Gen_State.StateID, Lead.SourceOfLead
FROM         Quotation LEFT OUTER JOIN
                      Employee ON Employee.EmpID = Quotation.EmpID LEFT OUTER JOIN
                      Employee AS Employee_1 ON Quotation.EmpAllToID = Employee_1.EmpID LEFT OUTER JOIN
                      Gen_State LEFT OUTER JOIN
                      Gen_City ON Gen_City.StateID = Gen_State.StateID LEFT OUTER JOIN
                      Lead ON Lead.CityID = Gen_City.CityID ON Lead.LeadId = Quotation.LeadId where Quotation.CompId=@i_CompId and Quotation.CreatedBy = @i_UserID
                --AND Lead.AllocatedToEmpID = Employee.EmpID
    ORDER BY Quotation.QDate

end




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Customer_Quotation_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--select * from Lead
CREATE PROCEDURE [dbo].[usp_Customer_Quotation_LOV]
	-- Add the parameters for the stored procedure here
@i_CompId bigint	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT     Lead.LeadId AS CustomerID, CASE WHEN Quotation.Code <> '''' THEN Quotation.Code ELSE ''0'' END AS Code, Lead.LeadNo AS CustomerCode, Lead.CustomerName, Lead.Email AS EMAIL, 
                      Lead.LeadDate, Lead.Phone1, Lead.ContactPerson, Lead.Address, Lead.EmpID, Lead.Category, Lead.AllocatedToEmpID, 
                      CASE WHEN Quotation.Remarks <> '''' THEN Quotation.Remarks ELSE ''Not Send'' END AS Subject, CASE WHEN Quotation.QuotationID <> '''' THEN Quotation.QuotationID ELSE 0 END AS QuotationID, 
                      Lead.CompId
FROM         Lead LEFT OUTER JOIN
                      Gen_City ON Gen_City.CityID = Lead.CityID LEFT OUTER JOIN
                      Gen_State ON Gen_State.StateID = Gen_City.StateID LEFT OUTER JOIN
                      Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID LEFT OUTER JOIN
                      Quotation ON Quotation.LeadId = Lead.LeadId
WHERE     (Lead.CompId = @i_CompId)





END










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Quotation_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Delete record from Quotation 
-- =============================================
CREATE PROCEDURE [dbo].[usp_Quotation_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
declare @i_Code as varchar(50)
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
 
	BEGIN TRY  
	BEGIN TRAN	 		 	
			Delete from  QuotationFollowup Where QuotationID = @i_RecID;
			Delete from Quotation_TNC Where Code=(Select Distinct Code From Quotation Where QuotationID = @i_RecID);
			Delete from QuotationPaymentDetail Where QuotationID = @i_RecID;
--select * from Lead
--SELECT DISTINCT SalesInvoice.CustomerID
--FROM         SalesInvoice LEFT JOIN
--                      Lead ON Lead.LeadId = SalesInvoice.CustomerID

--update Lead set InterestLevel=''QUOTATION'' where LeadId=@i_LeadId
--SELECT     LeadId, InterestLevel
--FROM         Lead
--where Lead.InterestLevel=''SALE''
--if 
--begin
--
--end
			select @i_Code=Code from Quotation where QuotationId = @i_RecID

			Delete from Quotation_Contact where Code=@i_Code
			Delete from QuotationDocList Where QuotationID = @i_RecID;	
			Delete from QuotationDetail Where SIID = @i_RecID;
			Delete from Quotation Where QuotationID = @i_RecID;
		COMMIT TRAN
	END TRY
		BEGIN CATCH 
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );  
		ROLLBACK TRAN  
	END CATCH 	
			
END























' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Reminder_List_Old]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Roshni Patel
-- Create date: 23rd Jan 2011
-- Description:	Get Purchase Invoice List
-- =============================================
create PROCEDURE [dbo].[usp_Reminder_List_Old]


AS
BEGIN
	SET NOCOUNT ON;

	SELECT ''Quotation'' AS [TYPE],
			A.QUOTATIONID AS INVOICEID,
			A.CODE,
			A.FOLLOWUPDATE AS DATE,
			B.CUSTOMERNAME AS PARTY,
			B.CONTACTPERSON,
			B.PHONE1,
			B.LEADDATE,
			A.Remarks_Orignal AS REMARKS,
			'''' AS EMAIL
	FROM QUOTATION A
			LEFT JOIN LEAD B ON B.LEADID=A.LEADID
	WHERE A.FOLLOWUPDATE between GETDATE() and GETDATE()+2
			OR CONVERT(VARCHAR,A.FOLLOWUPDATE,103)= Convert(varchar,GETDATE(),103)

	UNION ALL

	SELECT DISTINCT	''SERVICE'' AS TYPE,
		A.SIID AS INVOICEID,
		B.SALESCODE AS CODE,
		A.SR_DATE AS DATE,
		C.CUSTOMERNAME AS PARTY,
		C.CONTACTPERSON,
		C.PHONE1,
		C.LEADDATE,
		D.REMARKS AS REMARKS,
		'''' AS EMAIL
	FROM	SALES_SERVICE_REMINDER A 
		LEFT JOIN SALESINVOICE B ON B.SIID=A.SIID 		
		LEFT JOIN LEAD C ON C.LEADID=B.CUSTOMERID
		LEFT JOIN SERVICEMODULE D ON D.SERVICEID=B.SIID
	WHERE A.SR_DONE=0
	
	UNION ALL

	SELECT DISTINCT ''WARRANTY'' AS [TYPE],
			B.SIID AS INVOICEID,
			A.SalesCode AS CODE, 
			A.DCDATE AS DATE,
			C.CUSTOMERNAME as PARTY,
			C.CONTACTPERSON AS CONTACTPERSON,
			C.PHONE1 AS PHONE1,
			GETDATE() AS LEADDATE,
			A.NARRATION AS REMARKS,
			'''' AS EMAIL
	FROM SalesInvoice A 
		LEFT JOIN Sales_Service_Reminder B ON  B.SIID = A.SIID 
		LEFT JOIN LEAD C ON C.LEADID=A.CustomerID  
	Where A.DCDATE between GETDATE() and GETDATE() + 2
			OR CONVERT(VARCHAR,A.DCDATE,103) = CONVERT(VARCHAR, GETDATE(), 103)

		UNION ALL
	
	SELECT DISTINCT A.EXTRAREMINDER AS [TYPE],
			A.SIID AS INVOICEID,
			A.SalesCode AS CODE, 
			A.DTEXTRAREMINDER AS DATE,
			C.CUSTOMERNAME as PARTY,
			C.CONTACTPERSON AS CONTACTPERSON,
			C.PHONE1 AS PHONE1,
			GETDATE() AS LEADDATE,
			A.NARRATION AS REMARKS,
			c.Email AS EMAIL
	FROM SalesInvoice A 
		LEFT JOIN Sales_Service_Reminder B ON  B.SIID = A.SIID 
		LEFT JOIN LEAD C ON C.LEADID=A.CustomerID  
	Where CONVERT(VARCHAR,A.DTEXTRAREMINDER ,103) = CONVERT(VARCHAR, GETDATE(), 103) AND A.EXTRAREMINDER <> ''''



END











' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemGroup_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Delete record from Item Group
-- =============================================
Create PROCEDURE [dbo].[usp_ItemGroup_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	
	DELETE FROM ItemGroup
		WHERE  ItemGroupID = @i_RecID ;
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemGroup_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Update record in Item Group
-- =============================================
Create PROCEDURE [dbo].[usp_ItemGroup_Update]
	@i_ItemGroupID Bigint,
	@i_ItemGroupName Varchar(50),
	@i_UserID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
		SELECT @l_varRec = Count(ItemGroupID) FROM ItemGroup WHERE Upper([Name]) = Upper(@i_ItemGroupName) AND ItemGroupID != @i_ItemGroupID ;
			IF @l_varRec=0
				BEGIN 
					UPDATE
						ItemGroup
					SET
						[Name]       =@i_ItemGroupName,
						ModifiedBy   =@i_UserID,
						ModifiedDate =@l_Date
					WHERE
						ItemGroupID  = @i_ItemGroupID
				END
		ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 8001 );
		END

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemCategory_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Get Item Category List
-- =============================================
Create PROCEDURE [dbo].[usp_ItemCategory_List]
	@i_ItemGroupID BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	
		Select 
			ItemCategory.CategoryID,
			ItemCategory.[Name] AS ItemCategory,
			ItemCategory.ItemGroupID,
			ItemGroup.[Name] AS ItemCategoryGroup
			
		From ItemCategory
			INNER JOIN ItemGroup ON ItemCategory.ItemGroupID = ItemGroup.ItemGroupID
		WHERE 
			ItemCategory.ItemGroupID = @i_ItemGroupID
		Order By ItemCategory
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemGroup_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert Record of Item Group
-- =============================================
Create PROCEDURE [dbo].[usp_ItemGroup_Insert]
	@i_Name		   Varchar(50),
	@i_UserID     Bigint,
	@o_ErrorMesg  varchar(500) OUTPUT
AS
BEGIN
	 --Declare Local Variables..
	Declare @l_VarRec Bigint;
	Declare @l_CreatedDate DateTime;
	Declare @l_ErrorNo BigInt;

	--Set Local Variable value..
	Set @l_VarRec=0;
	Set @o_ErrorMesg='''';
 
	SET NOCOUNT ON;

  	--Set Current Date
	Select @l_CreatedDate = Convert(DateTime,GetDate(),105);

	--Check Custom Field caption is Exists or Not..	
	Select @l_varRec = Count(ItemGroupID) from ItemGroup WHERE UPPER([Name]) = UPPER(@i_Name) ;
	If @l_varRec = 0
		Begin
	
			Insert Into ItemGroup
					(  [Name], CreatedBy,   CreatedDate)
			Values  (@i_Name, @i_UserID,@l_CreatedDate)

		End
	Else
		Begin
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 8001 );
		End

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemGroup_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select Item Group
-- =============================================
Create PROCEDURE [dbo].[usp_ItemGroup_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		
		[Name]
	FROM
		ItemGroup
	WHERE
		ItemGroupID = @i_RecID 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemGroup_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of Item Group for Combo
-- =============================================
Create PROCEDURE [dbo].[usp_ItemGroup_DDL]
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		ItemGroupID,
		[Name] as ItemGroupName
	FROM
		ItemGroup	
	ORDER BY
		ItemGroupName
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemGroup_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Get Item Group List
-- =============================================
Create PROCEDURE [dbo].[usp_ItemGroup_List]
AS
BEGIN
	SET NOCOUNT ON;
		Select 
			ItemGroup.ItemGroupID,
			ItemGroup.[Name] AS ItemGroup
		From ItemGroup
		Order By ItemGroup
	
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TypeOfCall_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_TypeOfCall_Select]
	-- Add the parameters for the stored procedure here
	@i_RecID Bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TYPEOFCALL WHERE CallID=@i_RecID;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TypeOfCall_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_TypeOfCall_Insert]
	-- Add the parameters for the stored procedure here
	@i_Call_Name varchar(150),
	@i_Desc    Varchar(255),
	@i_CreatedBy   Bigint,
	@o_ErrorMesg   varchar(500) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @l_TypeOfCallCount Bigint;
	Declare @l_CreatedDate DateTime;
	Declare @l_ErrorNo BigInt;

	--Set Local Variable value..
	Set @l_TypeOfCallCount=0;
	Set @o_ErrorMesg='''';
	Set @l_ErrorNo = 0;

  	--Set Current Date
	Select @l_CreatedDate = Convert(DateTime,GetDate(),105);

	BEGIN TRY  
	BEGIN TRAN

	--Check Department Name is Exists or Not..	
	Select  @l_TypeOfCallCount = Count(Call_Name) From TYPEOFCALL Where Upper(Call_Name) = Upper(@i_Call_Name);
	If @l_TypeOfCallCount = 0
		Begin
				--Insert Record in User Table
				Insert Into TYPEOFCALL(   Call_Name   ,Description  ,CreatedBy   ,CreatedDate ) 
 							Values  (@i_Call_Name,@i_Desc,@i_CreatedBy,@l_CreatedDate );
		End
	Else
		Begin
			SET @l_ErrorNo = 1001
		End

	If @l_ErrorNo=0
			Begin
				COMMIT TRAN
			End		
		Else
			Begin
				ROLLBACK TRAN  
			End 
			
END TRY
	BEGIN CATCH   
		SET @l_ErrorNo = 10000
		ROLLBACK TRAN  
	END CATCH 
	--SELECT @o_ErrorMesg = ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = @l_ErrorNo				
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TypeOfCall_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_TypeOfCall_List]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TypeOfCall;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ServiceModule_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	List of ServiceModule
-- =============================================
CREATE PROCEDURE [dbo].[usp_ServiceModule_List]
@i_CompId bigint,
@i_UserID bigint		
AS
BEGIN
	SET NOCOUNT ON;

if @i_UserID = 1
begin

SELECT     ServiceModule.ServiceId, ServiceModule.RequestNo, ServiceModule.ServiceDate,ServiceModule.CustomerID, ServiceModule.CustomerName, ServiceModule.Address, ServiceModule.MobileNo, ServiceModule.ProductName, 
                      ServiceModule.ModelNumber, ServiceModule.Problem, ServiceModule.AttendedBy, Employee.EmpName, ServiceModule.JobComputed, ServiceModule.Remarks, ServiceModule.OtherRequirement, 
                      ServiceModule.Charges, ServiceModule.GodownID, ServiceModule.CallID, TypeOfCall.Call_Name, ServiceModule.TypeOfSale, ServiceModule.Status, Employee_1.EmpName AS ServiceBy, 
                      ServiceModule.CompId
FROM         ServiceModule LEFT OUTER JOIN
                      Employee ON Employee.EmpID = ServiceModule.AttendedBy LEFT OUTER JOIN
                      TypeOfCall ON TypeOfCall.CallID = ServiceModule.CallID LEFT OUTER JOIN
                      Employee AS Employee_1 ON Employee_1.EmpID = ServiceModule.EmpAllToID where ServiceModule.CompId=@i_CompId
ORDER BY ServiceModule.RequestNo
		
END

else


SELECT     ServiceModule.ServiceId, ServiceModule.RequestNo, ServiceModule.ServiceDate, ServiceModule.CustomerName, ServiceModule.Address, ServiceModule.MobileNo, ServiceModule.ProductName, 
                      ServiceModule.ModelNumber, ServiceModule.Problem, ServiceModule.AttendedBy, Employee.EmpName, ServiceModule.JobComputed, ServiceModule.Remarks, ServiceModule.OtherRequirement, 
                      ServiceModule.Charges, ServiceModule.GodownID, ServiceModule.CallID, TypeOfCall.Call_Name, ServiceModule.TypeOfSale, ServiceModule.Status, Employee_1.EmpName AS ServiceBy, 
                      ServiceModule.CompId
FROM         ServiceModule LEFT OUTER JOIN
                      Employee ON Employee.EmpID = ServiceModule.AttendedBy LEFT OUTER JOIN
                      TypeOfCall ON TypeOfCall.CallID = ServiceModule.CallID LEFT OUTER JOIN
                      Employee AS Employee_1 ON Employee_1.EmpID = ServiceModule.EmpAllToID where ServiceModule.CompId=@i_CompId and ServiceModule.CreatedBy = @i_UserID
ORDER BY ServiceModule.RequestNo

end









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ServiceModule_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Select ServiceModule record
-- =============================================
--select * from ServiceModule
CREATE PROCEDURE [dbo].[usp_ServiceModule_Select]
--[usp_ServiceModule_Select]''27''
	@i_RecID Bigint 
AS
declare @i_Code as varchar(50)

BEGIN
	SET NOCOUNT ON;

--SELECT     ServiceModule.ServiceId, ServiceModule.RequestNo, ServiceModule.ServiceDate, ServiceModule.CustomerName, ServiceModule.Address, ServiceModule.MobileNo, 
--                      ServiceModule.ProductName, ServiceModule.ModelNumber, ServiceModule.Problem, ServiceModule.AttendedBy, ServiceModule.JobComputed, 
--                      ServiceModule.Remarks, ServiceModule.OtherRequirement, ServiceModule.Charges, ServiceModule.SIID,
---- CASE WHEN SalesInvoice.SalesDate IS NULL THEN Lead.LeadDate ELSE SalesInvoice.SalesDate END AS SalesDate,
--SalesInvoice.SrNo, ServiceModule.FYID, ServiceModule.PaidAmount, 
--                      ServiceModule.NetAmount, ServiceModule.Discount, ServiceModule.AVATAmount, ServiceModule.VATAmount, ServiceModule.CSTAmount, 
--                      ServiceModule.AmountAfterExcise, ServiceModule.HCessAmount, ServiceModule.CessAmount, ServiceModule.ExciseAmount, ServiceModule.ServiceAmount, 
--                      ServiceModule.TotalAmount, ServiceModule.GodownID, ServiceModule.CallID, TypeOfCall.Call_Name, ServiceModule.TypeOfSale, ServiceModule.Status, 
--                      Lead.Phone1, Lead.Email, Lead.ContactPerson, Lead.Category, Lead.AllocatedToEmpID, Lead.InterestLevel, ServiceModule.EmpAllToID
--FROM         TypeOfCall RIGHT OUTER JOIN
--                      SalesInvoice RIGHT OUTER JOIN
--                      Lead INNER JOIN
--                      ServiceModule ON Lead.LeadId = ServiceModule.SIID ON SalesInvoice.CustomerID = Lead.LeadId ON TypeOfCall.CallID = ServiceModule.CallID
--WHERE     (ServiceModule.ServiceId = @i_RecID)
--        and Lead.LeadId=ServiceModule.SIID

SELECT     ServiceModule.ServiceId, ServiceModule.RequestNo, ServiceModule.ServiceDate,ServiceModule.CustomerID, ServiceModule.CustomerName, ServiceModule.Address, ServiceModule.MobileNo, 
                      ServiceModule.ProductName, ServiceModule.ModelNumber, ServiceModule.Problem, ServiceModule.AttendedBy, ServiceModule.JobComputed, 
                      ServiceModule.Remarks, ServiceModule.OtherRequirement, ServiceModule.Charges, ServiceModule.SIID, SalesInvoice.SalesDate, SalesInvoice.SrNo, 
                      ServiceModule.FYID, ServiceModule.PaidAmount, ServiceModule.NetAmount, ServiceModule.Discount, ServiceModule.AVATAmount, ServiceModule.VATAmount, 
                      ServiceModule.CSTAmount, ServiceModule.AmountAfterExcise, ServiceModule.HCessAmount, ServiceModule.CessAmount, ServiceModule.ExciseAmount, 
                      ServiceModule.ServiceAmount, ServiceModule.TotalAmount, ServiceModule.GodownID, ServiceModule.CallID, TypeOfCall.Call_Name, ServiceModule.TypeOfSale, 
                      Lead.Phone1, Lead.Email, Lead.ContactPerson, ServiceModule.EmpAllToID, ServiceModule.Status
--,Lead.LeadID as CustomerID
FROM         Lead INNER JOIN
                      SalesInvoice ON Lead.LeadId = SalesInvoice.CustomerID CROSS JOIN
                      ServiceModule INNER JOIN
                      TypeOfCall ON ServiceModule.CallID = TypeOfCall.CallID
WHERE     (ServiceModule.ServiceId = @i_RecID)


SELECT     ServiceDetails.ItemID, TaxClass.Name, Item.Name AS ItemName, Gen_UOM.Name AS UOM, ServiceDetails.ItemDesc, ServiceDetails.Qty, ServiceDetails.Rate, 
                      ServiceDetails.Amount as TotalAmount, ServiceDetails.TaxClassID, ServiceDetails.ServiceRate, ServiceDetails.ServiceAmount, ServiceDetails.ExciseRate, 
                      ServiceDetails.ExciseAmount, ServiceDetails.CessRate  As ECessRate, ServiceDetails.CessAmount As ECessAmount, ServiceDetails.HCessRate As HECessRate, ServiceDetails.HCessAmount AS HECessAmount, 
                      ServiceDetails.AmountAfterExcise, ServiceDetails.CSTRate, ServiceDetails.CSTAmount, ServiceDetails.VATRate, ServiceDetails.VATAmount, ServiceDetails.AVATRate, 
                      ServiceDetails.AVATAmount, ServiceDetails.NetAmount
FROM         Gen_UOM INNER JOIN
                      Item ON Gen_UOM.UOMID = Item.CUOMID INNER JOIN
                      ServiceDetails INNER JOIN
                      TaxClass ON ServiceDetails.TaxClassID = TaxClass.TaxClassID ON Item.ItemID = ServiceDetails.ItemID
where ServiceDetails.SIID=@i_RecID


Select DocID,
		ServiceID,
		DocName,
		Remarks 
	From ServiceDocList
	Where ServiceID = @i_RecID 


SELECT     Sales_Service_Reminder.SR_Code, Sales_Service_Reminder.SR_Date, Sales_Service_Reminder.SIID, Sales_Service_Reminder.SRID, SalesInvoice.CustomerID, 
                      Employee.EmpName AS AttendedBy,ServiceModule.Problem, ServiceModule.OtherRequirement, Sales_Service_Reminder.SR_Done
FROM         Employee INNER JOIN
                      ServiceModule ON Employee.EmpID = ServiceModule.AttendedBy RIGHT OUTER JOIN
                      Sales_Service_Reminder LEFT OUTER JOIN
                      SalesInvoice ON Sales_Service_Reminder.SIID = SalesInvoice.SIID ON ServiceModule.ServiceId = Sales_Service_Reminder.ServiceId LEFT OUTER JOIN
                      Customer ON SalesInvoice.CustomerID = Customer.CustomerID
WHERE     (ServiceModule.ServiceId = @i_RecID)

--select * from SalesInvoice
select @i_Code=RequestNo from ServiceModule where ServiceModule.ServiceId = @i_RecID

SELECT     Code, RefID,ContactID, ContactType, ContactTitle, Designation, ContactName, Phone1, Phone2, Mobile, Email, DoB, DoA
FROM         Service_Contact where Code=@i_Code	

END


















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TypeOfCall_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_TypeOfCall_Update]
	-- Add the parameters for the stored procedure here
	@i_Call_Name varchar(150),
	@i_Desc   Varchar(255),
	@i_ModifiedBy Bigint,
	@i_CallID int,
	@o_ErrorMesg   varchar(500) OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 -- Insert statements for procedure here
	Declare @l_CallTypeCount Bigint;
	Declare @l_Date DateTime;
	Declare @l_ErrorNo BigINt;

	--Set Local Variable value..
	Set @l_CallTypeCount=0;
	Set @o_ErrorMesg='''';

	--Set Current Date
	Select @l_Date=Convert(DateTime,GetDate(),5);
	Declare @l_ACDate DateTime;
	Set @l_ErrorNo = 0;

	BEGIN TRY  
	BEGIN TRAN

		--Check User Name is Exists or Not..	
		Select @l_CallTypeCount=Count(CallID) From TYPEOFCALL Where Upper(Call_Name) = Upper(@i_Call_Name) AND CallID <> @i_CallID;
		If @l_CallTypeCount=0
			Begin

				--Update Record in Users Table
				Update 
					TYPEOFCALL
				Set 
					Call_Name = @i_Call_Name,
					Description = @i_Desc,
					ModifiedBy=@i_ModifiedBy,
					ModifiedDate=@l_Date
				Where 
					CallID = @i_CallID
	 
			End
		ELSE
			BEGIN
				SET @l_ErrorNo = 1001
			END

		If @l_ErrorNo=0
			Begin
				COMMIT TRAN
			End		
		Else
			Begin
				ROLLBACK TRAN  
			End 
			
	END TRY
	BEGIN CATCH   
		SET @l_ErrorNo = 10000
		ROLLBACK TRAN  
	END CATCH 

	IF @o_ErrorMesg = ''''
	BEGIN
		SELECT @o_ErrorMesg = ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = @l_ErrorNo				
	END
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TypeOfCall_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_TypeOfCall_Delete]
	-- Add the parameters for the stored procedure here
	@i_RecID bigint,
	@o_ErrorMesg varchar(500) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete From TYPEOFCALL WHERE CallID = @i_RecID;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_Service_Order]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		PRIYANKA
-- Create date: 29/11/2014
-- Description:	SP FOR REPORT SERVICE ORDER
-- =============================================
--select * from SERVICEMODULE
CREATE PROCEDURE [dbo].[rpt_Service_Order]
	-- Add the parameters for the stored procedure here
	@i_RecID Bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     A.ServiceId, A.RequestNo, A.ServiceDate, C.CustomerName, A.Address, C.Phone1 AS MobileNo, C.Email, A.Problem, E.Name AS SPARESUSED, A.OtherRequirement AS SOLUTIONS, 
                      A.NetAmount AS SPARECHARGES, A.Charges AS SERVICECHARGES, F.EmpName AS ATTENDEDBY, G.Call_Name AS CALLTYPE, A.Status, C.Remarks
FROM         ServiceModule AS A LEFT OUTER JOIN
                      SalesInvoice AS B ON B.SIID = A.SIID LEFT OUTER JOIN
                      Lead AS C ON C.LeadId = B.CustomerID LEFT OUTER JOIN
                      ServiceDetails AS D ON D.SIID = A.ServiceId LEFT OUTER JOIN
                      Item AS E ON E.ItemID = D.ItemID LEFT OUTER JOIN
                      Employee AS F ON F.EmpID = A.AttendedBy LEFT OUTER JOIN
                      TypeOfCall AS G ON G.CallID = A.CallID
	WHERE A.ServiceId=@i_RecID
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_IndentDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Roshni Patel
-- Create date: 23rd Jan 2011
-- Description:	Detail Report of Purchase Invoice
-- =============================================
create PROCEDURE [dbo].[rpt_IndentDetail]
	@i_PIID BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Indent.PIID,
		Indent.PurchaseCode,
		Indent.PurchaseDate,
		Indent.VoucherNo,
		Indent.VoucherDate,
		Indent.VendorID,
		Vendor.Code,		
		Vendor.[Name] as VendorName,
		Indent.DueDays,
		Indent.DueDate,
		Indent.TotalAmount,
		Indent.ExciseAmount,
		Indent.CessAmount,
		Indent.HCessAmount,
		Indent.AmountAfterExcise,
		Indent.CSTAmount,
		Indent.VATAmount,
		Indent.AVATAmount,
		Indent.Discount,
		Indent.NetAmount,
		Indent.Narration,
		IndentDetail.ItemID,
		IndentDetail.Qty,	
		IndentDetail.Rate,
		IndentDetail.Amount,
		Item.Name as ItemName,
		Gen_UOM.Name As UOM,
		TaxClass.Name AS TaxClass,
		IndentDetail.ExciseRate,
		IndentDetail.ExciseAmount As DetExciseAmount,
		IndentDetail.CessRate,
		IndentDetail.CessAmount As DetCessAmount,
		IndentDetail.HCessRate,
		IndentDetail.HCessAmount AS DetHCessAmount,
		IndentDetail.AmountAfterExcise AS DetAmountAfterExcise,
		IndentDetail.CSTRate,
		IndentDetail.CSTAmount AS DetCSTAmount,
		IndentDetail.VATRate,
		IndentDetail.VATAmount AS DetVATAmount,
		IndentDetail.AVATRate,
		IndentDetail.AVATAmount AS DetAVATAmount,
		IndentDetail.NetAmount AS DetNEtAMount,
		IndentDetail.TaxClassID,
		IndentDetail.PIDetailID
  FROM Indent
		Inner Join Vendor On Vendor.VendorID = Indent.VendorID
		INNER JOIN IndentDetail on IndentDetail.PIID = Indent.PIID
		INNER JOIN Item  ON Item.ItemID = IndentDetail.ItemID
		INNER JOIN Gen_UOM on Gen_UOM.UOMID = Item.CUOMID
		INNER JOIN TaxClass ON TaxClass.TaxClassID = IndentDetail.TaxClassID
	--WHERE TaxClass.TaxClassID in(2,3)	 --AND PurchaseInvoice.PIID = @i_PIID

END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemStock_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select ItemStock record
-- =============================================
CREATE PROCEDURE [dbo].[usp_ItemStock_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		ItemStock.ItemID,
		Item.Name as ItemName,
		Gen_UOM.Name AS UOM,
		ItemStockDetail.Date,
		ItemStock.QOH,
		ItemStock.MinLevel,
		ItemStock.MaxLevel,
		ItemStock.ReorderLvl,
		ItemStock.Location, 
		ItemStock.RackNo,
		ItemStock.GodownID
	FROM
		ItemStock 
		INNER JOIN ItemStockDetail ON ItemStock.StockID = ItemStockDetail.StockID 
		INNER JOIN Item ON ItemStock.ItemID = Item.ItemID 
		INNER JOIN Gen_UOM ON Item.CUOMID = Gen_UOM.UOMID 
		INNER JOIN FinancialYear ON ItemStock.FYID = FinancialYear.FYID
	WHERE
		ItemStock.StockID = @i_RecID 

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_Sale_edit]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Item_Sale_edit]
--[usp_Item_Sale_edit] ''24'',''7''
	-- Add the parameters for the stored procedure here


	@i_SIID int=0,
	@i_ItemID int=0,
	@i_GodownID int=0


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT     Item.Name AS ItemName, Gen_UOM.Name AS UOM, Item.Price, SalesInvoiceDetail.SIID, SalesInvoiceDetail.ItemID, SalesInvoiceDetail.ItemDesc, 
                      SalesInvoiceDetail.Qty, SalesInvoiceDetail.Rate, SalesInvoiceDetail.TaxClassID, SalesInvoiceDetail.Amount, SalesInvoiceDetail.ServiceRate, 
                      SalesInvoiceDetail.ServiceAmount, SalesInvoiceDetail.ExciseRate, SalesInvoiceDetail.ExciseAmount, SalesInvoiceDetail.CessRate, SalesInvoiceDetail.CessAmount, 
                      SalesInvoiceDetail.HCessRate, SalesInvoiceDetail.HCessAmount, SalesInvoiceDetail.CSTRate, SalesInvoiceDetail.CSTAmount, SalesInvoiceDetail.VATRate, 
                      SalesInvoiceDetail.VATAmount, SalesInvoiceDetail.AVATAmount, SalesInvoiceDetail.AVATRate, SalesInvoiceDetail.NetAmount,SalesInvoiceDetail.Discount,SalesInvoiceDetail.AmountAfterExcise,
CAST(SalesInvoiceDetail.Amount-((SalesInvoiceDetail.Amount*SalesInvoiceDetail.Discount)/100) AS DECIMAL(18,2)) as AmtAfterDisc,SalesInvoiceDetail.GodownID
FROM         Gen_UOM INNER JOIN
                      Item ON Gen_UOM.UOMID = Item.CUOMID INNER JOIN
                      SalesInvoiceDetail ON Item.ItemID = SalesInvoiceDetail.ItemID INNER JOIN
                      TaxClass ON SalesInvoiceDetail.TaxClassID = TaxClass.TaxClassID INNER JOIN
                      SalesInvoice ON SalesInvoiceDetail.SIID = SalesInvoice.SIID
where SalesInvoiceDetail.SIID=@i_SIID and SalesInvoiceDetail.ItemID=@i_ItemID and SalesInvoiceDetail.GodownID=@i_GodownID

END








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_Indent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author: Manoj Savalia
-- Create date: 24th Jan 2011
-- Description: Select record from PurchaseInvoice and PurchaseInvoiceDetail
-- change history:
-- =============================================

create PROCEDURE [dbo].[rpt_Indent]
	@i_RecID Bigint
AS
BEGIN
	-- DECLARE @l_Date DATETIME;
	--
	-- SET @l_Date = (SELECT Convert(DateTime,(SELECT PurchaseDate FROM PurchaseInvoice WHERE PIID = @i_RecID),5));

	--Select Record from IGMS_PurchaseInvoice table
	SELECT 
		Indent.PurchaseCode,
		Indent.PurchaseDate,
		Indent.VoucherNo,
		Indent.VoucherDate,
		Indent.TotalAmount,
		Indent.ExciseAmount,
		Indent.CessAmount,
		Indent.HCessAmount,
		Indent.AmountAfterExcise,
		Indent.CSTAmount,
		Indent.VATAmount,
		Indent.AVATAmount,
		Indent.Discount,
		Indent.NetAmount,
		Indent.PaidAmount,
		Indent.VendorID,
		vendor.Code As VendorCode,
		Vendor.Name as Vendor,
		Vendor.Address1,
		Vendor.Address2,
		Vendor.Mobile as Phone1,
		Vendor.PinCode,
		Gen_City.Name As City,
		Gen_State.Name + '','' + Gen_Country.Name + '','' As State,
		Indent.Narration,
		IndentDetail.ItemID,
		IndentDetail.ReceivedQty as Qty,
		IndentDetail.Rate,
		IndentDetail.Amount,
		Item.Name as ItemName,
		Gen_UOM.Name As UOM
	FROM Indent
		LEFT JOIN IndentDetail on IndentDetail.PIID = Indent.PIID
		LEFT JOIN Item  ON Item.ItemID = IndentDetail.ItemID
		LEFT JOIN Gen_UOM on Gen_UOM.UOMID = Item.CUOMID
		LEFT JOIN Vendor on Vendor.VendorID=Indent.VendorID
		LEFT JOIN Gen_City on Gen_City.CityID = Vendor.CItyID
		LEFT JOIN Gen_State on Gen_State.StateID = Gen_City.StateID
		LEFT JOIN Gen_Country on Gen_Country.CountryID = Gen_State.CountryID
	WHERE
		Indent.PIID=@i_RecID 
 
End






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SalesInvoice_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 24th Jan 2011
-- Description:	Select record from SalesInvoice and SalesInvoiceDetail
-- change history:
-- =============================================

CREATE PROCEDURE [dbo].[usp_SalesInvoice_Select]
	@i_RecID Bigint
AS
declare @i_Code as varchar(50)
BEGIN
	
	DECLARE @l_Date DATETIME;

	SET @l_Date = (SELECT Convert(DateTime,(SELECT SalesDate FROM SalesInvoice WHERE SIID = @i_RecID),5));

	--Select Record from IGMS_SalesInvoice table
SELECT     SalesInvoice.SalesCode, SalesInvoice.SalesDate, SalesInvoice.DCNO, SalesInvoice.DCDate, SalesInvoice.DueDays, SalesInvoice.DueDate, 
                      SalesInvoice.PaidAmount, SalesInvoice.Narration, SalesInvoice.CustomerID, FinancialYear.StartDate, FinancialYear.EndDate, SalesInvoice.Discount, 
                      SalesInvoice.SrNo, SalesInvoice.GoDownID, SalesInvoice.InstallationDate, SalesInvoice.ReminderDate, SalesInvoice.NoofServices, SalesInvoice.TypeOfSale, 
                      SalesInvoice.EmpID, Lead.CustomerName, Lead.Address + '' '' + Gen_City.Name + '' '' + Gen_State.Name + '' '' + Gen_Country.Name AS Address, Lead.Pincode, 
                      Lead.Phone1,Lead.MobileNo as Mobile, Lead.Email, Lead.ContactPerson, SalesInvoice.ExtraCharges, SalesInvoice.ExtraChargesType, SalesInvoice.NetAmount, SalesInvoice.TIN, 
                      SalesInvoice.RecDay, SalesInvoice.Type, SalesInvoice.ShippingAdd, SalesInvoice.BONo, SalesInvoice.BODate, SalesInvoice.DNote, SalesInvoice.DNoteDate, 
                      SalesInvoice.SuRNo, SalesInvoice.DDNo, SalesInvoice.DT, SalesInvoice.D, SalesInvoice.DtI, SalesInvoice.TI, SalesInvoice.DtR, SalesInvoice.TR,
SalesInvoice.CC,SalesInvoice.BCC,SalesInvoice.CustInvoiceNo,
SalesInvoice.ExtraCharges2, SalesInvoice.ExtraChargesType2,
SalesInvoice.ExtraCharges3, SalesInvoice.ExtraChargesType3,
SalesInvoice.ExtraReminder,SalesInvoice.dtExtraReminder,
Lead.Category,Lead.AllocatedToEmpID,Lead.InterestLevel,SalesInvoice.IsPaid,ISNULL(SalesInvoice.TotalDiscAmt,0) as TotalDiscAmt, SalesInvoice.EmpAllToID 
FROM         SalesInvoice LEFT  JOIN
                      FinancialYear ON SalesInvoice.FYID = FinancialYear.FYID LEFT  JOIN
                      Lead ON SalesInvoice.CustomerID = Lead.LeadId LEFT  JOIN
                      Gen_City ON Lead.CityID = Gen_City.CityID LEFT  JOIN
                      Gen_State ON Gen_City.StateID = Gen_State.StateID LEFT  JOIN
                      Gen_Country ON Gen_State.CountryID = Gen_Country.CountryID
WHERE     (SalesInvoice.SIID = @i_RecID)
 
	--Select Record from SalesInvoiceDetail
	SELECT
		SalesInvoiceDetail.ItemID,
		SalesInvoiceDetail.Qty,	
		SalesInvoiceDetail.Rate,
		SalesInvoiceDetail.Amount AS TotalAmount,
		Item.Name as ItemName,
		SalesInvoiceDetail.ItemDesc,
		Gen_UOM.Name As UOM,
		TaxClass.Name AS TaxClass,
		SalesInvoiceDetail.ServiceRate,
		SalesInvoiceDetail.ServiceAmount,	
		SalesInvoiceDetail.ExciseRate,
		SalesInvoiceDetail.ExciseAmount,
		SalesInvoiceDetail.CessRate As ECessRate,
		SalesInvoiceDetail.CessAmount As ECessAmount,
		SalesInvoiceDetail.HCessRate As HECessRate,
		SalesInvoiceDetail.HCessAmount AS HECessAmount,
		SalesInvoiceDetail.AmountAfterExcise,
		SalesInvoiceDetail.CSTRate,
		SalesInvoiceDetail.CSTAmount,
		SalesInvoiceDetail.VATRate,
		SalesInvoiceDetail.VATAmount,
		SalesInvoiceDetail.AVATRate,
		SalesInvoiceDetail.AVATAmount,
		SalesInvoiceDetail.NetAmount,
		SalesInvoiceDetail.TaxClassID,
		SalesInvoiceDetail.SIDetailID,
		SalesInvoiceDetail.Discount,
		SalesInvoiceDetail.GodownID
		FROM	
			SalesInvoiceDetail
			LEFT JOIN TaxClass ON TaxClass.TaxClassID = SalesInvoiceDetail.TaxClassID
			LEFT JOIN Item  ON Item.ItemID = SalesInvoiceDetail.ItemID
			LEFT JOIN Gen_UOM ON Gen_UOM.UOMID = Item.CUOMID
		WHERE	
			SalesInvoiceDetail.SIID = @i_RecID		



Select DocID,
		SaleID,
		DocName,
		Remarks 
	From SaleDocList
	Where SaleID = @i_RecID 

SELECT     SR_Code, SR_Date, SIID, SR_Done
FROM         Sales_Service_Reminder
Where SIID = @i_RecID 

--select * from SalesInvoice
select @i_Code=SalesCode from SalesInvoice where SalesInvoice.SIID = @i_RecID

SELECT     Code, RefID,ContactID, ContactType, ContactTitle, Designation, ContactName, Phone1, Phone2, Mobile, Email, DoB, DoA
FROM         Sale_Contact where Code=@i_Code		
			
End




























' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PO_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 24th Jan 2011
-- Description:	Select record from PurchaseInvoice and PurchaseInvoiceDetail
-- change history:
-- =============================================

CREATE PROCEDURE [dbo].[usp_PO_Select]
	@i_RecID Bigint
AS
BEGIN
	
	DECLARE @l_Date DATETIME;

	SET @l_Date = (SELECT Convert(DateTime,(SELECT PurchaseDate FROM PO WHERE PIID = @i_RecID),5));

	--Select Record from IGMS_PurchaseInvoice table
	SELECT 
		PO.PurchaseCode,
		PO.PurchaseDate,
		PO.VoucherNo,
		PO.VoucherDate,
		PO.DueDays,
		PO.DueDate,
		PO.PaidAmount,
		PO.VendorID,
		Vendor.Name as VendorName,
		PO.Narration,
		FinancialYear.StartDate,
		FinancialYear.EndDate,
		PO.Discount,
		PO.SrNo,
		PO.GodownID,
		PO.CC,
		PO.BCC,
		PO.Is_SendMail,
		PO.CompId,
		Vendor.Fax as Email
	FROM
		PO
			LEFT JOIN Vendor on Vendor.VendorID=PO.VendorID
			LEFT jOIN FinancialYear ON PO.FYID = FinancialYear.FYID
	WHERE
		 PO.PIID=@i_RecID 

Select QDocID,
		PIID,
		DocName,
		Remarks 
	From PODocList
	Where PIID = @i_RecID ;

 
	--Select Record from PODetail
	SELECT PODetail.ItemID, PODetail.Qty, PODetail.Rate, PODetail.Amount AS TotalAmount, Item.Name AS ItemName, Gen_UOM.Name AS UOM, 
               TaxClass.Name AS TaxClass, PODetail.ServiceRate, PODetail.ServiceAmount, PODetail.ExciseRate, PODetail.ExciseAmount, PODetail.CessRate AS ECessRate, 
               PODetail.CessAmount AS ECessAmount, PODetail.HCessRate AS HECessRate, PODetail.HCessAmount AS HECessAmount, PODetail.AmountAfterExcise, 
               PODetail.CSTRate, PODetail.CSTAmount, PODetail.VATRate, PODetail.VATAmount, PODetail.AVATRate, PODetail.AVATAmount, PODetail.NetAmount, 
               PODetail.TaxClassID, PODetail.PIDetailID, PODetail.DDate
FROM  PODetail INNER JOIN
               TaxClass ON TaxClass.TaxClassID = PODetail.TaxClassID INNER JOIN
               Item ON Item.ItemID = PODetail.ItemID INNER JOIN
               Gen_UOM ON Gen_UOM.UOMID = Item.CUOMID
		WHERE	
			PODetail.PIID = @i_RecID				
			
End









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_ChallanCumTaxInvoice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author: Manoj Savalia
-- Create date: 24th Jan 2011
-- Description: Select record from SalesInvoice and SalesInvoiceDetail
-- change history:
-- =============================================

CREATE PROCEDURE [dbo].[rpt_ChallanCumTaxInvoice]
	@i_RecID Bigint
AS
BEGIN
	
SELECT     SalesInvoice.SalesCode, 
SalesInvoice.SalesDate, 
SalesInvoice.DCNO, 
SalesInvoice.DCDate,
SalesInvoice.TotalAmount, 
SalesInvoice.ServiceAmount, 
SalesInvoice.ExciseAmount, 
SalesInvoice.CessAmount, 
SalesInvoice.HCessAmount,
SalesInvoice.AmountAfterExcise, 
SalesInvoice.CSTAmount, 
SalesInvoice.VATAmount, 
SalesInvoice.AVATAmount, 
SalesInvoice.Discount, 
SalesInvoice.NetAmount,
SalesInvoice.PaidAmount, 
SalesInvoice.CustomerID, 
SalesInvoice.Narration, 
SalesInvoiceDetail.ItemID, 
TaxClass.Name + ''%'' AS TaxClass, 
SalesInvoiceDetail.Qty, 
SalesInvoiceDetail.Rate, 
SalesInvoiceDetail.Amount,
Item.Name + '', '' + Item.Specification +'' , ''+ SalesInvoiceDetail.ItemDesc AS ItemName, 
SalesInvoice.ExtraCharges,
SalesInvoice.ExtraChargesType,
--   CASE WHEN SalesInvoiceDetail.ItemDesc <> '''' THEN Item.Name + '':-'' + SalesInvoiceDetail.ItemDesc ELSE Item.Name + END AS ItemName, 
Gen_UOM.Name AS UOM, 
Lead.CustomerName AS CUSTOMER, 
Lead.Address AS ADDRESS1,
Gen_City.Name AS City,
Gen_State.Name + '','' + Gen_Country.Name + '','' AS State, 
Lead.Pincode, 
Lead.Phone1,
SalesInvoice.TIN as TinNo,
SalesInvoiceDetail.Discount as Dis,
SalesInvoice.ShippingAdd,
SalesInvoice.BONo,
SalesInvoice.BODate,
SalesInvoice.DNote,
SalesInvoice.DNoteDate,
SalesInvoice.SuRNo,
SalesInvoice.DDNo,
SalesInvoice.DT,
SalesInvoice.D,
SalesInvoice.DtI,
SalesInvoice.TI,
SalesInvoice.DtR,
SalesInvoice.TR,
SalesInvoice.DueDays,
SalesInvoiceDetail.ServiceRate,
SalesInvoiceDetail.ExciseRate,
SalesInvoiceDetail.CessRate,
SalesInvoiceDetail.HCessRate,
SalesInvoiceDetail.CSTRate,
SalesInvoiceDetail.VATRate,
SalesInvoiceDetail.AVATRate
FROM         Gen_UOM RIGHT OUTER JOIN
                      Item RIGHT OUTER JOIN
                      SalesInvoiceDetail RIGHT OUTER JOIN
                      SalesInvoice INNER JOIN
                      Lead INNER JOIN
                      Gen_City ON Lead.CityID = Gen_City.CityID ON SalesInvoice.CustomerID = Lead.LeadId LEFT OUTER JOIN
                      Gen_State ON Gen_City.StateID = Gen_State.StateID LEFT OUTER JOIN
                      Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID ON SalesInvoiceDetail.SIID = SalesInvoice.SIID LEFT OUTER JOIN
                      TaxClass ON TaxClass.TaxClassID = SalesInvoiceDetail.TaxClassID ON Item.ItemID = SalesInvoiceDetail.ItemID ON Gen_UOM.UOMID = Item.CUOMID
WHERE     (SalesInvoice.SIID = @i_RecID)



End








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Indent_SelectNew]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 24th Jan 2011
-- Description:	Select record from Indent and IndentDetail
-- change history:
-- =============================================
CREATE PROCEDURE [dbo].[usp_Indent_SelectNew]
--[usp_Indent_SelectNew]''32'',''18''
	@i_RecID Bigint,
     @i_ItemID Bigint
AS
BEGIN
SELECT     IndentDetail.ItemID, IndentDetail.Qty, IndentDetail.Rate, IndentDetail.Amount AS TotalAmount, Item.Name AS ItemName, 
                      Gen_UOM.Name AS UOM, TaxClass.Name AS TaxClass, IndentDetail.ServiceRate, IndentDetail.ServiceAmount, 
                      IndentDetail.ExciseRate, IndentDetail.ExciseAmount, IndentDetail.CessRate AS ECessRate, 
                      IndentDetail.CessAmount AS ECessAmount, IndentDetail.HCessRate AS HECessRate, IndentDetail.HCessAmount AS HECessAmount, 
                      IndentDetail.AmountAfterExcise, IndentDetail.CSTRate, IndentDetail.CSTAmount, IndentDetail.VATRate, 
                      IndentDetail.VATAmount, IndentDetail.AVATRate, IndentDetail.AVATAmount, IndentDetail.NetAmount, 
                      IndentDetail.TaxClassID, IndentDetail.PIDetailID, IndentDetail.ReceivedQty, IndentDetail.PIID, 
                      IndentDetail.RemainingQty, IndentDetail.DDate
FROM         IndentDetail LEFT OUTER JOIN
                      TaxClass ON TaxClass.TaxClassID = IndentDetail.TaxClassID LEFT OUTER JOIN
                      Item ON Item.ItemID = IndentDetail.ItemID LEFT OUTER JOIN
                      Gen_UOM ON Gen_UOM.UOMID = Item.CUOMID
		WHERE	
			IndentDetail.PIID = @i_RecID and IndentDetail.ItemID= @i_ItemID		
			
End








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Indent_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 24th Jan 2011
-- Description:	Select record from PurchaseInvoice and PurchaseInvoiceDetail
-- change history:
-- =============================================
--select * from IndentDetail
--select * from ItemRegister
--select * from ItemStock
CREATE PROCEDURE [dbo].[usp_Indent_Select]
--[usp_Indent_Select]''10''
	@i_RecID Bigint
AS
BEGIN
	
	DECLARE @l_Date DATETIME;

	SET @l_Date = (SELECT Convert(DateTime,(SELECT PurchaseDate FROM Indent WHERE PIID = @i_RecID),5));

	--Select Record from IGMS_PurchaseInvoice table
	SELECT 
		Indent.PurchaseCode,
		Indent.PurchaseDate,
		Indent.VoucherNo,
		Indent.VoucherDate,
		Indent.DueDays,
		Indent.DueDate,
		Indent.PaidAmount,
		Indent.VendorID,
		Vendor.Name as VendorName,
		Vendor.CreditDays,
		Indent.Narration,
		FinancialYear.StartDate,
		FinancialYear.EndDate,
		Indent.Discount,
		Indent.SrNo,
		Indent.GodownID,
        Indent.PGID,
		Indent.AgainstCForm
	FROM
		Indent
			INNER JOIN Vendor on Vendor.VendorID=Indent.VendorID
			INNER jOIN FinancialYear ON Indent.FYID = FinancialYear.FYID
	WHERE
		 Indent.PIID=@i_RecID 
 
	--Select * from IndentDetail
SELECT     IndentDetail.ItemID, IndentDetail.Qty, IndentDetail.Rate, IndentDetail.Amount AS TotalAmount, Item.Name AS ItemName, Gen_UOM.Name AS UOM, 
                      TaxClass.Name AS TaxClass, IndentDetail.ServiceRate, IndentDetail.ServiceAmount, IndentDetail.ExciseRate, IndentDetail.ExciseAmount, 
                      IndentDetail.CessRate AS ECessRate, IndentDetail.CessAmount AS ECessAmount, IndentDetail.HCessRate AS HECessRate, 
                      IndentDetail.HCessAmount AS HECessAmount, IndentDetail.AmountAfterExcise, IndentDetail.CSTRate, IndentDetail.CSTAmount, IndentDetail.VATRate, 
                      IndentDetail.VATAmount, IndentDetail.AVATRate, IndentDetail.AVATAmount, IndentDetail.NetAmount, IndentDetail.TaxClassID, IndentDetail.PIDetailID, 
                      IndentDetail.ReceivedQty, ItemStock.QOH AS RemainingQty, IndentDetail.DDate
FROM         IndentDetail LEFT JOIN
                      TaxClass ON TaxClass.TaxClassID = IndentDetail.TaxClassID LEFT JOIN
                      Item ON Item.ItemID = IndentDetail.ItemID LEFT JOIN
                      Gen_UOM ON Gen_UOM.UOMID = Item.CUOMID LEFT JOIN
                      ItemStock ON ItemStock.ItemID=Item.ItemID  LEFT JOIN
                      Indent ON Indent.PIID=IndentDetail.PIID 
		WHERE	
			IndentDetail.PIID = @i_RecID				
			
End










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_ServiceInvoice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author: Manoj Savalia
-- Create date: 24th Jan 2011
-- Description: Select record from SalesInvoice and SalesInvoiceDetail
-- change history:
-- =============================================

CREATE PROCEDURE [dbo].[rpt_ServiceInvoice]
	@i_RecID Bigint
AS
BEGIN
		--Select Record from IGMS_SalesInvoice table

	SELECT	ServiceModule.RequestNo, 
			ServiceModule.ServiceDate, 
			Lead.LeadNo, 
			ServiceModule.CustomerName, 
			Lead.Address, 
			Gen_City.Name AS CITY, 
			Lead.Pincode, 
			Lead.Phone1, 
			Gen_State.Name AS STATE, 
			Item.Name + '', '' + Item.Specification +'' , ''+ ServiceDetails.ItemDesc AS ITEMNAME, 
			ServiceDetails.Qty, 
			Gen_UOM.Name AS UOM, 
			ServiceDetails.Rate, 
			ServiceDetails.Amount, 
			ServiceDetails.ServiceRate, 
			ServiceDetails.ServiceAmount, 
			ServiceDetails.ExciseRate, 
			ServiceDetails.ExciseAmount, 
			ServiceDetails.CessRate, 
			ServiceDetails.CessAmount, 
			ServiceDetails.HCessRate, 
			ServiceDetails.HCessAmount, 
			ServiceDetails.AmountAfterExcise, 
			ServiceDetails.CSTRate, 
			ServiceDetails.CSTAmount, 
			ServiceDetails.VATRate, 
			ServiceDetails.VATAmount, 
			ServiceDetails.AVATRate, 
			ServiceDetails.AVATAmount, 
			ServiceDetails.NetAmount,
			TaxClass.Name + '' %'' AS TaxClass
	FROM		ServiceModule 
		INNER JOIN	Lead			ON ServiceModule.CustomerName = Lead.CustomerName 
		INNER JOIN	Gen_City		ON Lead.CityID = Gen_City.CityID 
		INNER JOIN	Gen_State		ON Gen_City.StateID = Gen_State.StateID 
		INNER JOIN	ServiceDetails	ON ServiceModule.ServiceId = ServiceDetails.SIID 
		INNER JOIN	Item			ON ServiceDetails.ItemID = Item.ItemID 
		INNER JOIN	Gen_UOM			ON Item.CUOMID = Gen_UOM.UOMID
		LEFT JOIN	TaxClass		ON TaxClass.TaxClassID=ServiceDetails.TaxClassID
	WHERE		(ServiceModule.ServiceId = @i_RecID)

UNION

	SELECT 	ServiceModule.RequestNo, 
			ServiceModule.ServiceDate, 
			Lead.LeadNo, 
			ServiceModule.CustomerName, 
			Lead.Address, 
			Gen_City.Name AS CITY, 
			Lead.Pincode, 
			Lead.Phone1, 
			Gen_State.Name AS STATE, 
			''SERVICE CHARGES'' AS ITEMNAME, 
			0 AS Qty, 
			'''' AS UOM, 
			0 AS Rate, 
			ServiceModule.CHARGES AS Amount, 
			ServiceDetails.ServiceRate, 
			ServiceDetails.ServiceAmount, 
			ServiceDetails.ExciseRate, 
			ServiceDetails.ExciseAmount, 
			ServiceDetails.CessRate, 
			ServiceDetails.CessAmount, 
			ServiceDetails.HCessRate, 
			ServiceDetails.HCessAmount, 
			ServiceDetails.AmountAfterExcise, 
			ServiceDetails.CSTRate, 
			ServiceDetails.CSTAmount, 
			ServiceDetails.VATRate, 
			ServiceDetails.VATAmount, 
			ServiceDetails.AVATRate, 
			ServiceDetails.AVATAmount, 
			ServiceDetails.NetAmount,
			'' ''AS TaxClass
	FROM		ServiceModule 
		INNER JOIN	Lead			ON ServiceModule.CustomerName = Lead.CustomerName 
		INNER JOIN	Gen_City		ON Lead.CityID = Gen_City.CityID 
		INNER JOIN	Gen_State		ON Gen_City.StateID = Gen_State.StateID 
		INNER JOIN	ServiceDetails	ON ServiceModule.ServiceId = ServiceDetails.SIID 
		INNER JOIN	Item			ON ServiceDetails.ItemID = Item.ItemID 
		INNER JOIN	Gen_UOM			ON Item.CUOMID = Gen_UOM.UOMID
	WHERE		(ServiceModule.ServiceId = @i_RecID) AND ServiceModule.CHARGES>0



End









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_SalesInvoice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author: Manoj Savalia
-- Create date: 24th Jan 2011
-- Description: Select record from SalesInvoice and SalesInvoiceDetail
-- change history:
-- =============================================
--select * from SalesInvoiceDetail
--501-C,Mangalkirti appt.,Next to sevenseas mall,Nr Udupi restauratnt,Fatehgunj.,Gujarat,Vadodara
CREATE PROCEDURE [dbo].[rpt_SalesInvoice]
--[rpt_SalesInvoice] ''73''
	@i_RecID Bigint
AS
BEGIN
SELECT     SalesInvoice.SalesCode, SalesInvoice.SalesDate, SalesInvoice.DCNO, SalesInvoice.DCDate, SalesInvoice.TotalAmount, SalesInvoice.ServiceAmount, 
                      SalesInvoice.ExciseAmount, SalesInvoice.CessAmount, SalesInvoice.HCessAmount, SalesInvoice.AmountAfterExcise, SalesInvoice.CSTAmount, 
                      SalesInvoice.VATAmount, SalesInvoice.AVATAmount, SalesInvoice.Discount, SalesInvoice.NetAmount, SalesInvoice.PaidAmount, SalesInvoice.CustomerID, 
                      SalesInvoice.Narration, SalesInvoice.BONO, SalesInvoice.BODate, SalesInvoiceDetail.ItemID, TaxClass.Name + ''%'' AS TaxClass, 
                      SalesInvoiceDetail.Qty, SalesInvoiceDetail.Rate, SalesInvoiceDetail.Amount, Gen_UOM.Name AS UOM, Lead.CustomerName AS CUSTOMER, 
                      Lead.Address + '','' + Gen_City.Name + '','' + Gen_State.Name AS ADDRESS1, Gen_City.Name AS City, Gen_State.Name + '','' + Gen_Country.Name + '','' AS State, 
                      Lead.Pincode, Lead.Phone1, Lead.Name1, Lead.Name2, Lead.Name3, Lead.Name4, Lead.Name5, Lead.Name6, Lead.Value1, Lead.Value2, Lead.Value3, Lead.Value4, 
                      Lead.Value5, Lead.Value6, Item.Name AS ItemName, Item.Specification + '','' AS ItemSpec, SalesInvoiceDetail.ItemDesc AS ItemSSpec, Item.HSNCode, 
                      SalesInvoice.ExtraCharges, SalesInvoice.ExtraChargesType, SalesInvoice.ExtraChargesType2 AS ExChargesType2, SalesInvoice.ExtraCharges2 AS ExCharges2, 
                      SalesInvoice.ExtraChargesType3 AS ExChargesType3, SalesInvoice.ExtraCharges3 AS ExCharges3, SalesInvoice.CustInvoiceNo, SalesInvoice.TIN AS TinNo, 
                      SalesInvoiceDetail.Discount AS Dis, SalesInvoiceDetail.Amount * SalesInvoiceDetail.Discount / 100 AS DiscountAmt, Lead.MobileNo, Lead.Email,
SalesInvoice.BONO as PONo, 
SalesInvoice.BODate as PODate, 
SalesInvoice.DDNo as LRNo, 
SalesInvoice.DT as TransportName,
SalesInvoice.D as Destination, 
SalesInvoice.SuRNo as RoadPerNo, 
SalesInvoice.DNoteDate as LRDate, 
SalesInvoice.ShippingAdd

FROM         Gen_UOM RIGHT OUTER JOIN
                      Item RIGHT OUTER JOIN
                      SalesInvoiceDetail RIGHT OUTER JOIN
                      SalesInvoice LEFT OUTER JOIN
                      Lead LEFT OUTER JOIN
                      Gen_City ON Gen_City.CityID = Lead.CityID ON SalesInvoice.CustomerID = Lead.LeadId LEFT OUTER JOIN
                      Gen_State ON Gen_City.StateID = Gen_State.StateID LEFT OUTER JOIN
                      Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID ON SalesInvoiceDetail.SIID = SalesInvoice.SIID LEFT OUTER JOIN
                      TaxClass ON TaxClass.TaxClassID = SalesInvoiceDetail.TaxClassID ON Item.ItemID = SalesInvoiceDetail.ItemID ON Gen_UOM.UOMID = Item.CUOMID
WHERE     (SalesInvoice.SIID = @i_RecID)


End

















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Select_UOMID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Select_UOMID]
	-- Add the parameters for the stored procedure here
	@i_UOM nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     UOMID FROM Gen_UOM WHERE Name=@i_UOM

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_salesinvoicereg_new]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_salesinvoicereg_new]
	-- Add the parameters for the stored procedure here
	@i_FYID BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 SELECT 
		SalesInvoice.SalesCode,
		SalesInvoice.SalesDate,
		SalesInvoice.DCNo,
		Salesinvoice.SrNo,
		SalesInvoice.DCDate,
		SalesInvoice.TotalAmount,
		SalesInvoice.ServiceAmount,
		SalesInvoice.ExciseAmount,
		SalesInvoice.CessAmount,
		SalesInvoice.HCessAmount,
		SalesInvoice.AmountAfterExcise,
		SalesInvoice.CSTAmount,
		SalesInvoice.VATAmount,
		SalesInvoice.AVATAmount,
		SalesInvoice.Discount,
		SalesInvoice.NetAmount,
		SalesInvoice.PaidAmount,
		SalesInvoice.CustomerID,
		Customer.Code As CustomerCode,
		Customer.Name as Customer,
		Customer.Name as CustomerName,
		Customer.Address1,
		Customer.Address2,
		Customer.Phone1,
		Customer.PinCode,
		Gen_City.Name As City,
		Gen_State.Name + '','' + Gen_Country.Name + '','' As State,
		SalesInvoice.Narration,
		SalesInvoiceDetail.ItemID,
		TaxClass.Name + ''%'' AS TaxClass,
		SalesInvoiceDetail.Qty,
		SalesInvoiceDetail.Rate,
		SalesInvoiceDetail.Amount,
		CASE WHEN SalesInvoiceDetail.ItemDesc <>'''' THEN  Item.Name + '':-''+SalesInvoiceDetail.ItemDesc
		ELSE Item.Name END AS ItemName,
		Gen_UOM.Name As UOM
	FROM SalesInvoice
		INNER JOIN SalesInvoiceDetail on SalesInvoiceDetail.SIID = SalesInvoice.SIID
		INNER JOIN TaxClass ON TaxClass.TaxClassID = SalesInvoiceDetail.TaxClassID
		INNER JOIN Item  ON Item.ItemID = SalesInvoiceDetail.ItemID
		INNER JOIN Gen_UOM on Gen_UOM.UOMID = Item.CUOMID
		INNER JOIN Customer on Customer.CustomerID=SalesInvoice.CustomerID
		INNER JOIN Gen_City on Gen_City.CityID = Customer.CItyID
		INNER JOIN Gen_State on Gen_State.StateID = Gen_City.StateID
		INNER JOIN Gen_Country on Gen_Country.CountryID = Gen_State.CountryID	
	WHERE SalesInvoice.FYID = @i_FYID
	Order By SalesInvoice.SalesDate,SalesInvoice.SalesCode Desc
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_Rate_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List Of Item UpdatePrice List
-- =============================================
Create PROCEDURE [dbo].[usp_Item_Rate_List]
 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		CASE When ItemDetail.ItemID IS NULL
			THEN Convert(bit,0)
		ELSE Convert(bit,ItemDetail.ItemID)
		End as IsSelect,
		Item.ItemID,
		Item.Name,
		Case When ItemDetail.Rate  IS NULL
			Then 0 
		Else 
			ItemDetail.Rate 
		End as Rate,

		Case When ItemDetail.VAT  IS NULL
			Then 0 
		Else 
			ItemDetail.VAT
		End as VatRate,

		Gen_UOM.UOMID,
		Item.ItemClassID,
		Item.CategoryID
	From
		Item 
			LEFT JOIN ItemDetail  on (ItemDetail.ItemID  = Item.ItemID  AND ItemDetail.IsArchieve = 0)
			INNER JOIN ItemCategory ON Item.CategoryID = ItemCategory.CategoryID 
			INNER JOIN ItemClass ON Item.ItemClassID = ItemClass.ItemClassID
			INNER JOIN Gen_UOM ON Item.CUOMID = Gen_UOM.UOMID
	ORDER BY
		Item.Name
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Indent_New_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for bind Vendor lov.
-- =============================================
CREATE PROCEDURE [dbo].[usp_Indent_New_LOV]
--[usp_Indent_New_LOV]''68'',''23''
	 @i_RecID int,
     @i_ItemID bigint
AS
BEGIN
declare @i_Qty bigint
declare @i_ReceivedQty bigint
	 SET NOCOUNT ON;

set @i_Qty=(SELECT     min(IndentDetail.RemainingQty)
FROM         IndentDetail LEFT JOIN
                      Indent ON Indent.PIID= IndentDetail.PIID 
WHERE     (Indent.PGID = @i_RecID))  
 
set @i_ReceivedQty=(SELECT     (min(IndentDetail.RemainingQty - IndentDetail.ReceivedQty))
FROM         IndentDetail LEFT JOIN
                      Indent ON Indent.PIID= IndentDetail.PIID 
WHERE     (Indent.PGID = @i_RecID) and  IndentDetail.ItemID=@i_ItemID)
--SELECT    PurchaseInvoiceDetail.ReceivedQty
--FROM         PurchaseInvoiceDetail LEFT JOIN
--                      PurchaseInvoice ON PurchaseInvoice.PIID= PurchaseInvoiceDetail.PIID 
--WHERE     (PurchaseInvoice.PGID = 65) and PurchaseInvoiceDetail.PIDetailID=(SELECT     MAX(PurchaseInvoiceDetail.PIDetailID) AS Expr1
--FROM         PurchaseInvoiceDetail LEFT JOIN
--                      PurchaseInvoice ON PurchaseInvoice.PIID = PurchaseInvoiceDetail.PIID 
--WHERE     (PurchaseInvoice.PIID = PurchaseInvoiceDetail.PIID)) )


SELECT     PODetail.Qty, PODetail.Rate, PODetail.Amount as TotalAmount, PODetail.TaxClassID, PODetail.ExciseRate, PODetail.ExciseAmount, PODetail.CessRate as ECessRate, PODetail.CessAmount as ECessAmount, 
                      PODetail.HCessRate as HECessRate, PODetail.HCessAmount as HECessAmount, PODetail.AmountAfterExcise, PODetail.CSTRate, PODetail.CSTAmount, PODetail.VATRate, PODetail.VATAmount, 
                      PODetail.AVATRate, PODetail.AVATAmount, PODetail.NetAmount, PODetail.ServiceRate, PODetail.ServiceAmount, PODetail.DDate, Item.Name AS ItemName, 
                      Gen_UOM.Name AS UOM, TaxClass.Name AS TaxClass,''0.00'' as ReceivedQty,case when @i_ReceivedQty is null then PODetail.Qty else @i_ReceivedQty end as RemainingQty
FROM         TaxClass LEFT OUTER JOIN
                      Item LEFT OUTER JOIN
                      PO LEFT OUTER JOIN
                      PODetail ON PODetail.PIID = PO.PIID ON Item.ItemID = PODetail.ItemID ON TaxClass.TaxClassID = PODetail.TaxClassID LEFT OUTER JOIN
                      Gen_UOM ON Gen_UOM.UOMID = Item.CUOMID
WHERE     (PODetail.PIID = @i_RecID) AND (PODetail.ItemID = @i_ItemID)	
--PurchaseInvoice.PGID = PODetail.PIID and 

END








--SELECT    PurchaseInvoiceDetail.ReceivedQty
--FROM         PurchaseInvoiceDetail INNER JOIN
--                      PurchaseInvoice ON PurchaseInvoiceDetail.PIID = PurchaseInvoice.PIID AND PurchaseInvoiceDetail.PIID = PurchaseInvoice.PIID
--GROUP BY PurchaseInvoiceDetail.ReceivedQty)
-- MAX(CONVERT(bigint, PurchaseInvoiceDetail.PIDetailID)) AS Expr1,




--SELECT    PurchaseInvoiceDetail.ReceivedQty
--FROM         PurchaseInvoiceDetail where PurchaseInvoiceDetail.PIDetailID =(select max(PurchaseInvoiceDetail.PIDetailID) from PurchaseInvoiceDetail where PurchaseInvoiceDetail.ItemID= @i_ItemID)
--)














--Perfectly Running
--SELECT     (min(PurchaseInvoiceDetail.RemainingQty - PurchaseInvoiceDetail.ReceivedQty))
--FROM         PurchaseInvoiceDetail LEFT JOIN
--                      PurchaseInvoice ON PurchaseInvoice.PIID= PurchaseInvoiceDetail.PIID 
--WHERE     (PurchaseInvoice.PGID = @i_RecID)

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemStock_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of Stock od Selected department
-- =============================================
CREATE PROCEDURE [dbo].[usp_ItemStock_List]
 	@i_FYID Bigint
AS
BEGIN	
	SET NOCOUNT ON;

 SELECT     ItemStock.StockID, ItemStock.ItemID, Item.Code AS ItemCode, Item.Name AS ItemName, Gen_UOM.Name AS UOM, ItemStock.QOH, ItemStock.MinLevel, ItemStock.MaxLevel, ItemStock.ReorderLvl, 
                      ItemStock.Location, ItemStock.RackNo, ItemStock.GodownID, Godown.Godown_name, Item.Price, Item.ProductCode
FROM         ItemStock LEFT OUTER JOIN
                      Item ON Item.ItemID = ItemStock.ItemID LEFT OUTER JOIN
                      Gen_UOM ON Gen_UOM.UOMID = Item.CUOMID LEFT OUTER JOIN
                      Godown ON Godown.GodownID = ItemStock.GodownID
WHERE     (ItemStock.FYID = @i_FYID)
ORDER BY ItemCode
	
END








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:        Manoj Savalia
-- Create date: 21-1-2011
-- Description:    Sp is used for get Item LOV
-- =============================================
--select * from Godown
--select * from ItemStock
CREATE PROCEDURE [dbo].[usp_Item_LOV]
--[usp_Item_LOV]''1'',''1''
    @i_FYID Bigint,
	@i_GodownID bigint
	
	
AS
BEGIN
     
    If @i_FYID=0
		Begin
			SELECT	Item.ItemID, 
					Item.Code AS ItemCode, 
					Item.Name AS ItemName,  
					Gen_UOM.Name AS UOM, 
					Item.Price,
					Item.Specification
			FROM	Item 
				LEFT JOIN	Gen_UOM	ON Gen_UOM.UOMID = Item.CUOMID
			ORDER BY	ItemName
		End
    Else
		Begin
		SELECT     Item.ItemID, Item.Code AS ItemCode, Item.Name AS ItemName, Gen_UOM.Name AS UOM, ISNULL(ItemStock.QOH, 0.000) AS QOH, Item.Price, Item.ProductCode,Item.Specification
FROM         Item LEFT OUTER JOIN
                      ItemStock ON ItemStock.ItemID = Item.ItemID AND ItemStock.FYID = @i_FYID LEFT OUTER JOIN
                      Gen_UOM ON Gen_UOM.UOMID = Item.CUOMID
			WHERE	ItemStock.GODOWNID=@i_GodownID
			ORDER BY	ItemName
		End
	END

















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_SalesInvoiceDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Roshni Patel
-- Create date: 23rd Jan 2011
-- Description:	Detail Report of Sales Invoice
-- =============================================
CREATE PROCEDURE [dbo].[rpt_SalesInvoiceDetail]
	@i_SIID BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT     SalesInvoice.SIID, SalesInvoice.SalesCode, SalesInvoice.SalesDate, SalesInvoice.DCNO, SalesInvoice.DCDate, SalesInvoice.CustomerID, SalesInvoice.DueDays, 
                      SalesInvoice.DueDate, SalesInvoice.TotalAmount, SalesInvoice.ExciseAmount, SalesInvoice.CessAmount, SalesInvoice.HCessAmount, 
                      SalesInvoice.AmountAfterExcise, SalesInvoice.CSTAmount, SalesInvoice.VATAmount, SalesInvoice.AVATAmount, SalesInvoice.Discount, SalesInvoice.NetAmount, 
                      SalesInvoice.Narration, SalesInvoiceDetail.ItemID, SalesInvoiceDetail.Qty, SalesInvoiceDetail.Rate, SalesInvoiceDetail.Amount, Item.Name AS ItemName, 
                      Gen_UOM.Name AS UOM, TaxClass.Name AS TaxClass, SalesInvoiceDetail.ExciseRate, SalesInvoiceDetail.ExciseAmount AS DetExciseAmount, 
                      SalesInvoiceDetail.CessRate, SalesInvoiceDetail.CessAmount AS DetCessAmount, SalesInvoiceDetail.HCessRate, 
                      SalesInvoiceDetail.HCessAmount AS DetHCessAmount, SalesInvoiceDetail.AmountAfterExcise AS DetAmountAfterExcise, SalesInvoiceDetail.CSTRate, 
                      SalesInvoiceDetail.CSTAmount AS DetCSTAmount, SalesInvoiceDetail.VATRate, SalesInvoiceDetail.VATAmount AS DetVATAmount, SalesInvoiceDetail.AVATRate, 
                      SalesInvoiceDetail.AVATAmount AS DetAVATAmount, SalesInvoiceDetail.NetAmount AS DetNEtAMount, SalesInvoiceDetail.TaxClassID, SalesInvoiceDetail.SIDetailID, 
                      Lead.LeadId, Lead.LeadNo AS CustomerCode, Lead.CustomerName as CustomerName
FROM         SalesInvoice INNER JOIN
                      Lead ON SalesInvoice.CustomerID = Lead.LeadId LEFT OUTER JOIN
                      SalesInvoiceDetail ON SalesInvoiceDetail.SIID = SalesInvoice.SIID LEFT OUTER JOIN
                      Item ON Item.ItemID = SalesInvoiceDetail.ItemID LEFT OUTER JOIN
                      Gen_UOM ON Gen_UOM.UOMID = Item.CUOMID LEFT OUTER JOIN
                      TaxClass ON TaxClass.TaxClassID = SalesInvoiceDetail.TaxClassID
	--WHERE SalesInvoice.SIID = @i_SIID
--WHERE TaxClass.TaxClassID in(2,3)	
Order By SalesInvoice.SalesDate

END





set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UOM_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Delete record from ItemClass 
-- =============================================
Create PROCEDURE [dbo].[usp_UOM_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	
		DELETE FROM Gen_UOM
				WHERE  UOMID = @i_RecID ;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UOM_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select UOM
-- =============================================
 
Create PROCEDURE [dbo].[usp_UOM_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		
		[Name],
		Abbr
	FROM
		Gen_UOM
	WHERE
		UOMID = @i_RecID 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_StockItemLOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Get Items to create stock
-- =============================================

/* For Execute Manually

DECLARE	@return_value int

EXEC	@return_value = [dbo].[usp_Item_StockItemLOV]
	 

SELECT	''Return Value'' = @return_value

*/

CREATE PROCEDURE [dbo].[usp_Item_StockItemLOV]	
	 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT     Item.ItemID, Item.Code AS ItemCode, Item.Name AS ItemName, Gen_UOM.Name AS UOM, Item.ProductCode
FROM         Item LEFT OUTER JOIN
                      Gen_UOM ON Item.CUOMID = Gen_UOM.UOMID--WHERE
		--Item.ItemID NOT IN (Select ItemID From ItemStock) 
	ORDER BY
		Item.Name
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Get Item List
-- =============================================
CREATE PROCEDURE [dbo].[usp_Item_DDL]  

AS
BEGIN
	 
	SELECT
		Item.ItemID,
		Item.Name,
		Gen_UOM.Name as UOMName,
		Item.Moving
	From
		Item Inner Join
		Gen_UOM On Item.CUOMID  = Gen_UOM.UOMID	 
	ORDER BY
		Item.Name 

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UOM_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record into UOM
-- =============================================
Create PROCEDURE [dbo].[usp_UOM_Insert]
	@i_UOMName varchar(50),
	@i_Abbr varchar(5),
	@i_UserID BIGINT,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	SELECT @l_varRec = Count(UOMID) FROM Gen_UOM WHERE Upper([Name]) = Upper(@i_UOMName);
	IF @l_varRec=0
		BEGIN 
			INSERT INTO Gen_UOM ([Name],    Abbr   ,CreatedBy,CreatedDate)
					       VALUES(@i_UOMName,@i_Abbr,@i_UserID,@l_Date)
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 11001 );
		END
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UOM_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Update Record of UOM
-- =============================================
CREATE PROCEDURE [dbo].[usp_UOM_Update]
	@i_UOMID      Bigint,
	@i_UOMName	  Varchar(50),
	@i_Abbr		  Varchar(5),
	@i_UserID     Bigint,
	@o_ErrorMesg  varchar(500) OUTPUT
AS

	 --Declare Local Variables..
	Declare @l_VarRec Bigint;
	Declare @l_CreatedDate DateTime;
	Declare @l_ErrorNo BigInt;

	--Set Local Variable value..
	Set @l_VarRec=0;
	Set @o_ErrorMesg='''';

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  	--Set Current Date
	Select @l_CreatedDate = Convert(DateTime,GetDate(),105);

	--Check Custom Field caption is Exists or Not..	
	Select @l_varRec = Count(UOMID) from Gen_UOM WHERE UPPER([Name]) = UPPER(@i_UOMName) AND UOMID != @i_UOMID;
	If @l_varRec = 0
		Begin
	
			UPDATE 
				Gen_UOM
			SET
				[Name]       = @i_UOMName,
				Abbr         = @i_Abbr,
				ModifiedBy   = @i_UserID,
				ModifiedDate = @l_CreatedDate
			WHERE
				UOMID = @i_UOMID	 
		End
	Else
		Begin
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 11001 );
		End

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List Of Item Register
-- =============================================
CREATE PROCEDURE [dbo].[usp_Item_List]  
@i_UserID bigint
AS
BEGIN
	SET NOCOUNT ON;

if @i_UserID = 1
begin

	SELECT
		Item.ItemID,
		Item.Code as iCode,
		Item.Name,
		Gen_UOM.UOMID,
		Gen_UOM.Name as UOM,
		Item.Specification,
		Item.Price,
		Item.HSNCode,
		Item.ProductCode
	From
		Item 
			LEFT JOIN Gen_UOM ON Gen_UOM.UOMID=Item.CUOMID 
	ORDER BY
		 Item.Code 
END
else

SELECT
		Item.ItemID,
		Item.Code as iCode,
		Item.Name,
		Gen_UOM.UOMID,
		Gen_UOM.Name as UOM,
		Item.Specification,
		Item.Price,
		Item.HSNCode,
		Item.ProductCode
	From
		Item 
			LEFT JOIN Gen_UOM ON Gen_UOM.UOMID=Item.CUOMID where Item.CreatedBy = @i_UserID
	ORDER BY
		 Item.Code 

end






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UOM_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Get UOM DDL
-- =============================================
Create PROCEDURE [dbo].[usp_UOM_DDL]

AS
BEGIN
	SET NOCOUNT ON;

	Select 
		UOMID,
		Name
	From 
		Gen_UOM
	Order By 
		Name

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UOM_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Get UOM List
-- =============================================
CREATE PROCEDURE [dbo].[usp_UOM_List]

@i_UserID bigint

AS
BEGIN
	SET NOCOUNT ON;
if @i_UserID = 1
begin


	SELECT
		Gen_UOM.UOMID,
		Gen_UOM.[Name] AS UOM,
		Gen_UOM.Abbr	
	FROM Gen_UOM
		
	ORDER BY UOM

END

else
SELECT


		Gen_UOM.UOMID,
		Gen_UOM.[Name] AS UOM,
		Gen_UOM.Abbr	
	FROM Gen_UOM WHERE CreatedBy = @i_UserID
		
	ORDER BY UOM

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Customer_LOV_Service]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for bind Customer lov.
-- =============================================
--update ServiceModule set FYID=1
CREATE PROCEDURE [dbo].[usp_Customer_LOV_Service]
@i_CompId bigint
AS
BEGIN
	SET NOCOUNT ON;

SELECT     SalesInvoice.SIID, SalesInvoice.SalesDate, SalesInvoice.SalesCode AS Code, Lead.LeadID as CustomerID,Lead.CustomerName, Lead.Email, Lead.Phone1, Lead.ContactPerson, SalesInvoice.ReminderDate, 
                      Lead.Address + '' '' + Gen_City.Name + '' '' + Gen_State.Name + '' '' + Gen_Country.Name + '' '' + Gen_Country.Name AS Address, Lead.EmpID, Lead.Category, Lead.AllocatedToEmpID, 
                      SalesInvoice.CompId
FROM         SalesInvoice LEFT OUTER JOIN
                      Lead ON Lead.LeadId = SalesInvoice.CustomerID LEFT OUTER JOIN
                      Gen_City ON Gen_City.CityID = Lead.CityID LEFT OUTER JOIN
                      Gen_State ON Gen_State.StateID = Gen_City.StateID LEFT OUTER JOIN
                      Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID where SalesInvoice.CompId=@i_CompId 
UNION

SELECT     Lead.LeadId AS SIID, Lead.LeadDate AS SalesDate, Lead.LeadNo AS Code,Lead.LeadID as CustomerID, Lead.CustomerName, Lead.Email, Lead.Phone1, Lead.ContactPerson, Lead.NextFollowUpDate AS ReminderDate, 
                      Lead.Address + '' '' + Gen_City.Name + '' '' + Gen_State.Name + '' '' + Gen_Country.Name + '' '' + Gen_Country.Name AS Address, Lead.EmpID, Lead.Category, Lead.AllocatedToEmpID, 
                      Lead.CompId
FROM         Lead LEFT OUTER JOIN
                      Gen_City ON Gen_City.CityID = Lead.CityID LEFT OUTER JOIN
                      Gen_State ON Gen_State.StateID = Gen_City.StateID LEFT OUTER JOIN
                      Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID where Lead.CompId=@i_CompId 
END












' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SalesInvoice_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 25th Jan 2011
-- Description:	Get Sales Invoice List
-- =============================================
--select * from SalesInvoice
--truncate table SalesInvoice
CREATE PROCEDURE [dbo].[usp_SalesInvoice_List]
--[usp_SalesInvoice_List] ''1'',''1'',''1''
@i_FYID BIGINT,
@I_CompId bigint,
@i_UserID bigint	
AS
BEGIN
    SET NOCOUNT ON;

if @i_UserID = 1

begin
 SELECT     SalesInvoice.SIID, SalesInvoice.SalesCode, SalesInvoice.SalesDate, SalesInvoice.CustomerID, SalesInvoice.DueDays, SalesInvoice.DueDate, 
                      SalesInvoice.TotalAmount, SalesInvoice.NetAmount, SalesInvoice.PaidAmount, SalesInvoice.NetAmount - SalesInvoice.PaidAmount AS PendingAmount, 
                      SalesInvoice.Narration, SalesInvoice.SrNo, SalesInvoice.GoDownID, SalesInvoice.InstallationDate, SalesInvoice.ReminderDate, SalesInvoice.NoofServices, 
                      SalesInvoice.TypeOfSale, SalesInvoice.ExtraCharges, SalesInvoice.ExtraChargesType, SalesInvoice.EmpID, SalesInvoice.TIN, SalesInvoice.Type, SalesInvoice.CC, 
                      SalesInvoice.BCC, SalesInvoice.CustInvoiceNo, SalesInvoice.ExtraCharges2, SalesInvoice.ExtraChargesType2, SalesInvoice.ExtraCharges3, 
                      SalesInvoice.ExtraChargesType3, SalesInvoice.ExtraReminder, SalesInvoice.dtExtraReminder, SalesInvoice.InstallationDate AS Expr1, 
                      SalesInvoice.ReminderDate AS Expr2, SalesInvoice.DCDate, SalesInvoice.NoofServices AS Expr3, Lead.CustomerName, Lead.LeadNo AS Code, Lead.CityID, 
                      Lead.Category, Lead.ContactPerson, Lead.Phone1, Lead.MobileNo AS Mobile, Lead.Email, Lead.InterestLevel AS Status, Lead.AllocatedToEmpID, 
                      Employee_1.EmpName, SalesInvoice.EmpAllToID, Employee.EmpName AS EmpAllTo, SalesInvoice.IsPaid, ISNULL(SalesInvoice.TotalDiscAmt, 0) AS TotalDiscAmt, 
                      SalesInvoice.CompId, Gen_State.Name as StateName
FROM         Employee AS Employee_1 RIGHT OUTER JOIN
                      Gen_State INNER JOIN
                      Gen_City ON Gen_State.StateID = Gen_City.StateID INNER JOIN
                      Lead ON Gen_City.CityID = Lead.CityID RIGHT OUTER JOIN
                      SalesInvoice ON Lead.LeadId = SalesInvoice.CustomerID LEFT OUTER JOIN
                      Employee ON Employee.EmpID = SalesInvoice.EmpAllToID ON Employee_1.EmpID = SalesInvoice.EmpID
WHERE     (SalesInvoice.FYID = @i_FYID) and SalesInvoice.CompId=@i_CompId
    ORDER BY SalesInvoice.SalesDate, SalesInvoice.SalesCode DESC;
END
else

SELECT     SalesInvoice.SIID, SalesInvoice.SalesCode, SalesInvoice.SalesDate, SalesInvoice.CustomerID, SalesInvoice.DueDays, SalesInvoice.DueDate, 
                      SalesInvoice.TotalAmount, SalesInvoice.NetAmount, SalesInvoice.PaidAmount, SalesInvoice.NetAmount - SalesInvoice.PaidAmount AS PendingAmount, 
                      SalesInvoice.Narration, SalesInvoice.SrNo, SalesInvoice.GoDownID, SalesInvoice.InstallationDate, SalesInvoice.ReminderDate, SalesInvoice.NoofServices, 
                      SalesInvoice.TypeOfSale, SalesInvoice.ExtraCharges, SalesInvoice.ExtraChargesType, SalesInvoice.EmpID, SalesInvoice.TIN, SalesInvoice.Type, SalesInvoice.CC, 
                      SalesInvoice.BCC, SalesInvoice.CustInvoiceNo, SalesInvoice.ExtraCharges2, SalesInvoice.ExtraChargesType2, SalesInvoice.ExtraCharges3, 
                      SalesInvoice.ExtraChargesType3, SalesInvoice.ExtraReminder, SalesInvoice.dtExtraReminder
                     , SalesInvoice.DCDate, SalesInvoice.NoofServices AS Expr3, Lead.CustomerName, Lead.LeadNo AS Code, Lead.CityID, 
                      Lead.Category, Lead.ContactPerson, Lead.Phone1, Lead.MobileNo AS Mobile, Lead.Email, Lead.InterestLevel AS Status, Lead.AllocatedToEmpID, 
                      Employee_1.EmpName, SalesInvoice.EmpAllToID, Employee.EmpName AS EmpAllTo, SalesInvoice.IsPaid, ISNULL(SalesInvoice.TotalDiscAmt, 0) AS TotalDiscAmt, 
                      SalesInvoice.CompId, Gen_State.Name as StateName
FROM         Employee AS Employee_1 RIGHT OUTER JOIN
                      Gen_State INNER JOIN
                      Gen_City ON Gen_State.StateID = Gen_City.StateID INNER JOIN
                      Lead ON Gen_City.CityID = Lead.CityID RIGHT OUTER JOIN
                      SalesInvoice ON Lead.LeadId = SalesInvoice.CustomerID LEFT OUTER JOIN
                      Employee ON Employee.EmpID = SalesInvoice.EmpAllToID ON Employee_1.EmpID = SalesInvoice.EmpID
WHERE     (SalesInvoice.FYID = @i_FYID) and SalesInvoice.CompId=@i_CompId and SalesInvoice.CreatedBy = @i_UserID
    ORDER BY SalesInvoice.SalesDate, SalesInvoice.SalesCode DESC;
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Customer_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for bind Customer lov.
-- =============================================
CREATE PROCEDURE [dbo].[usp_Customer_LOV]
@i_CompId bigint
AS
BEGIN
    SET NOCOUNT ON;
    SELECT     Lead.LeadId AS CustomerID, Lead.LeadNo AS CustomerCode, Lead.CustomerName, Lead.Email AS EMAIL, Lead.LeadDate, Lead.Phone1, Lead.ContactPerson, 
                      Lead.Address + '' ,'' + Gen_City.Name + '', '' + Gen_State.Name + '', '' + Gen_Country.Name AS Address, Lead.EmpID, Lead.Category, Lead.AllocatedToEmpID, Lead.CompId
FROM         Lead LEFT OUTER JOIN
                      Gen_City ON Gen_City.CityID = Lead.CityID LEFT OUTER JOIN
                      Gen_State ON Gen_State.StateID = Gen_City.StateID LEFT OUTER JOIN
                      Gen_Country ON Gen_State.CountryID = Gen_Country.CountryID where Lead.CompId=@i_CompId
    ORDER BY Lead.CustomerName;
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Vendor_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select Vendor record
-- =============================================
CREATE PROCEDURE [dbo].[usp_Vendor_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		Vendor.Code,
		Vendor.Name as Company,
		Vendor.Address1,
		Vendor.Address2,
		Vendor.CityID,
		Gen_State.Name AS State, 
		Gen_Country.Name AS Country,
		Vendor.Pincode,
		Vendor.Phone1,
		Vendor.Phone2,
		Vendor.Fax,
		Vendor.Mobile,
		Vendor.TinNo,
		Vendor.CSTNo,
		Vendor.PANo,
		Vendor.EccNo,
		Vendor.CreditDays,
		Vendor.Range,
		Vendor.Division	,	
		Ledger.TransactionDate,
		OpeningBalance.CRAmount,
		OpeningBalance.DBAmount		
	FROM     OpeningBalance
		LEFT JOIN Ledger ON (OpeningBalance.AccountID = Ledger.AccountID AND Ledger.TransactionTypeID = 1) 
		LEFT JOIN Account ON Ledger.AccountID = Account.AccountID 
		LEFT Join Vendor ON  Vendor.AccountID =  Account.AccountID  LEFT Join
		Gen_City ON Vendor.CityID = Gen_City.CityID LEFT JOIN
		Gen_State ON Gen_State.StateID=Gen_City.StateID  LEFT JOIN
		Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID
	WHERE
		Vendor.VendorID = @i_RecID 

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Customer_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of Customer
-- =============================================
CREATE PROCEDURE [dbo].[usp_Customer_List]	

AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		Customer.CustomerID,		
		Customer.Code,
		Customer.Name as Company,
		Customer.Address1 + ''  '' + Customer.Address2 as Address, 
		Customer.CityID,
		Gen_City.Name AS City,
		Gen_State.Name AS State,
		Gen_Country.Name as Country,		
		Customer.Pincode,
		Customer.Phone1,
		Customer.Fax,
		Customer.Mobile,	 
		ContactDetail.ContactName,		
		Customer.TinNo,
		Customer.CSTNo,
		Customer.PANo,
		Customer.LeadId,
		Customer.EccNo,
		Customer.NextFollowUpDate
	FROM         
		Customer LEFT JOIN    
		Gen_City ON Gen_City.CityID=Customer.CityID  LEFT JOIN
        Gen_State ON Gen_State.StateID=Gen_City.StateID  LEFT JOIN
        Gen_Country ON Gen_Country.CountryID =Gen_State.CountryID LEFT JOIN
		ContactDetail ON  ContactDetail.RefID = Customer.CustomerID AND ContactDetail.ContactType = 1
	WHERE		
		(
		( ContactDetail.ContactID =
				(SELECT     MIN(ContactID) AS ContactID
					FROM           ContactDetail AS ASIGMS_Contact_2
					WHERE      (RefID =  Customer.CustomerID) AND (ContactType =1))) OR
				  (NOT ( Customer.CustomerID IN
					(SELECT     RefID
						FROM           ContactDetail AS ASIGMS_Contact
						WHERE      (ContactType = 1)))))
	ORDER BY
		 Customer.Code

		
		
END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Customer_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select Customer record
-- =============================================
--select * from Customer
CREATE PROCEDURE [dbo].[usp_Customer_Select]
--[usp_Customer_Select]''10''
	@i_RecID Bigint

AS
BEGIN
	SET NOCOUNT ON;

--		SELECT
--		Customer.Code,
--		Customer.Name as Company,
--		Customer.Address1,
--		Customer.Address2,
--		Customer.CityID,
--		Gen_CIty.Name As City,
--		Gen_State.Name AS State, 
--		Gen_Country.Name AS Country,
--		Customer.Pincode,
--		Customer.Phone1,
--		Customer.Phone2,
--		Customer.Fax,
--		Customer.Mobile,
--		Customer.TinNo,
--		Customer.CSTNo,
--		Customer.PANo,
--		Customer.EccNo,
--		Customer.CreditDays,
--		Customer.Range,
--		Customer.Division,	
--		Customer.IsAccount,
--		Customer.LeadId,
--		Ledger.TransactionDate,
--		OpeningBalance.CRAmount,
--		OpeningBalance.DBAmount	,
--		Customer.ContactPerson	
--	FROM     OpeningBalance
--		LEFT JOIN Ledger ON (OpeningBalance.AccountID = Ledger.AccountID AND Ledger.TransactionTypeID = 1) 
--		LEFT JOIN Account ON Ledger.AccountID = Account.AccountID 
--		LEFT Join Customer ON  Customer.AccountID =  Account.AccountID INNER JOIN
--		Gen_City ON Customer.CityID = Gen_City.CityID INNER JOIN
--		Gen_State ON Gen_City.StateID = Gen_State.StateID INNER JOIN
--		Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID
--	WHERE
--		Customer.CustomerID = @i_RecID 
--end
--
--if @i_Mode=''NoAccount''
--begin
	SELECT     Customer.Code,
			   Customer.Name AS Company,
			   Customer.Address1,
				 Customer.Address2,
					 Customer.CityID,
				 Gen_City.Name AS City,
			 Gen_State.Name AS State, 
			Gen_Country.Name AS Country,
			 Customer.Pincode,
			 Customer.Phone1,
			 Customer.Phone2,
				 Customer.Fax,
				 Customer.Mobile, 
					Customer.TinNo,
					 Customer.CSTNo, 
						  Customer.PANo,
						 Customer.EccNo, 
					Customer.CreditDays,
					Customer.Range, 
					Customer.Division,
					 Customer.IsAccount,
					 Customer.LeadId, 
					Customer.ContactPerson
	FROM         Gen_City LEFT JOIN
						  Customer ON Customer.CityID=Gen_City.CityID  LEFT JOIN
						  Gen_State ON Gen_State.StateID = Gen_City.StateID LEFT JOIN
						  Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID
		WHERE
			Customer.CustomerID = @i_RecID
--end






END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Vendor_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of Vendor
-- =============================================
CREATE PROCEDURE [dbo].[usp_Vendor_List]	

AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		Vendor.VendorID,		
		Vendor.Code,
		Vendor.Name as Company,
		Vendor.Address1 + ''  '' + Vendor.Address2 as Address, 
		Vendor.CityID,
		Gen_City.Name AS City,
		Gen_State.Name AS State,
		Gen_Country.Name as Country,		
		Vendor.Pincode,
		Vendor.Phone1,
		Vendor.Fax,
		Vendor.Mobile,	 
		ContactDetail.ContactName,		
		Vendor.TinNo,
		Vendor.CSTNo,
		Vendor.PANo,
		Vendor.EccNo
	FROM         
		Vendor LEFT JOIN    
		Gen_City ON Gen_City.CityID =Vendor.CityID LEFT JOIN
        Gen_State ON Gen_State.StateID=Gen_City.StateID  LEFT JOIN
        Gen_Country ON  Gen_Country.CountryID=Gen_State.CountryID  LEFT JOIN
		ContactDetail ON  ContactDetail.RefID = Vendor.VendorID AND ContactDetail.ContactType = 0
	WHERE		
		(
		( ContactDetail.ContactID =
				(SELECT     MIN(ContactID) AS ContactID
					FROM           ContactDetail AS ASIGMS_Contact_2
					WHERE      (RefID =  Vendor.VendorID) AND (ContactType = 0))) OR
				  (NOT ( Vendor.VendorID IN
					(SELECT     RefID
						FROM           ContactDetail AS ASIGMS_Contact
						WHERE      (ContactType = 0)))))
	ORDER BY
		 Vendor.Code

		
		
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CustomerMain_Select_Account]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Select Lead record
-- =============================================
--select * from cUSTOMERMAIN
create PROCEDURE [dbo].[usp_CustomerMain_Select_Account]
--[usp_CustomerMain_Select]''30''
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;
SELECT CustomerMain.CustomerID,
       CustomerMain.CustomerCode,
       CustomerMain.CustomerName,
       CustomerMain.Address,
       CustomerMain.CityID,
       Gen_City.Name AS City,
       Gen_State.Name AS State,
       Gen_Country.Name AS Country,
       CustomerMain.Pincode,
       CustomerMain.Phone1,
       CustomerMain.MobileNo,
       CustomerMain.Email,
       CustomerMain.Name1,
       CustomerMain.Name2,
       CustomerMain.Name3,
       CustomerMain.Name4,
       CustomerMain.Name5,
       CustomerMain.Name6,
       CustomerMain.Value1,
       CustomerMain.Value2,
       CustomerMain.Value3,
       CustomerMain.Value4,
       CustomerMain.Value5,
       CustomerMain.Value6,
       CustomerMain.Specification,
       CustomerMain.Remarks,
       CustomerMain.ContactPerson,
       CustomerMain.Website,
       CustomerMain.AreaID,
       CustomerMain.Category,
       CustomerMain.AccountID,
       CustomerMain.CreditDays,
       CustomerMain.IsAccount,
       Ledger.TransactionDate,
       OpeningBalance.CRAmount,
       OpeningBalance.DBAmount
FROM   Gen_State
       LEFT OUTER JOIN
       Gen_City
       ON Gen_City.StateID = Gen_State.StateID
       LEFT OUTER JOIN
       Gen_Country
       ON Gen_Country.CountryID = Gen_State.CountryID
       LEFT OUTER JOIN
       CustomerMain
       LEFT OUTER JOIN
       Account
       ON Account.AccountID = CustomerMain.AccountID
       RIGHT OUTER JOIN
       Ledger
       ON Account.AccountID = Ledger.AccountID
       LEFT OUTER JOIN
       OpeningBalance
       ON OpeningBalance.AccountID = Account.AccountID
          AND OpeningBalance.AccountID = Ledger.AccountID
          AND Ledger.TransactionTypeID = 1
       ON CustomerMain.CityID = Gen_City.CityID
				
	Where CustomerMain.CustomerID =  @i_RecID 

------------------------------

--		SELECT
--		Customer.Code,
--		Customer.Name as Company,
--		Customer.Address1,
--		Customer.Address2,
--		Customer.CityID,
--		Gen_CIty.Name As City,
--		Gen_State.Name AS State, 
--		Gen_Country.Name AS Country,
--		Customer.Pincode,
--		Customer.Phone1,
--		Customer.Phone2,
--		Customer.Fax,
--		Customer.Mobile,
--		Customer.TinNo,
--		Customer.CSTNo,
--		Customer.PANo,
--		Customer.EccNo,
--		Customer.CreditDays,
--		Customer.Range,
--		Customer.Division,	
--		Customer.IsAccount,
--		Customer.LeadId,
--		Ledger.TransactionDate,
--		OpeningBalance.CRAmount,
--		OpeningBalance.DBAmount	,
--		Customer.ContactPerson	
--	FROM     OpeningBalance
--		LEFT JOIN Ledger ON (OpeningBalance.AccountID = Ledger.AccountID AND Ledger.TransactionTypeID = 1) 
--		LEFT JOIN Account ON Ledger.AccountID = Account.AccountID 
--		LEFT Join Customer ON  Customer.AccountID =  Account.AccountID INNER JOIN
--		Gen_City ON Customer.CityID = Gen_City.CityID INNER JOIN
--		Gen_State ON Gen_City.StateID = Gen_State.StateID INNER JOIN
--		Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID
--	WHERE
--		Customer.CustomerID = @i_RecID 

END













' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Customer_LOV_Payment]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for bind Customer lov.
-- =============================================
--update ServiceModule set FYID=1
--select * from Lead
--select * from CustomerMain
--update SalesInvoice set IsPaid=''0'' where SIID=''4''
CREATE PROCEDURE [dbo].[usp_Customer_LOV_Payment]
@i_CompId bigint


AS
BEGIN
	SET NOCOUNT ON;

SELECT     SalesInvoice.SIID, SalesInvoice.SalesDate, SalesInvoice.SalesCode AS Code
, Lead.LeadId AS CustomerID
, Lead.AccountID,
 Lead.CustomerName, Lead.Email, Lead.Phone1, Lead.ContactPerson, 
                      SalesInvoice.ReminderDate, Lead.Address + '' '' + Gen_City.Name + '' '' + Gen_State.Name + '' '' + Gen_Country.Name + '' '' + Gen_Country.Name AS Address, Lead.EmpID, Lead.Category, 
                      Lead.AllocatedToEmpID, SalesInvoice.CompId
FROM				  SalesInvoice LEFT OUTER JOIN
                      Lead ON Lead.LeadId = SalesInvoice.CustomerID LEFT OUTER JOIN
                      Gen_City ON Gen_City.CityID = Lead.CityID LEFT OUTER JOIN
                      Gen_State ON Gen_State.StateID = Gen_City.StateID LEFT OUTER JOIN
                      Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID
WHERE  
--SalesInvoice.IsPaid=''0''and 
SalesInvoice.CompId=@i_CompId 

--select * from SalesInvoice
--UNION
--
--SELECT	LEAD.LEADID AS SIID,
--		LEAD.LEADDATE AS SalesDate,
--		Lead.LeadNo as Code,
--		LEAD.CUSTOMERNAME,
--		LEAD.EMAIL,
--		LEAD.PHONE1,
--		LEAD.CONTACTPERSON,
--		LEAD.NEXTFOLLOWUPDATE AS ReminderDate,
--		Lead.Address + '' ''+  Gen_City.Name + '' '' +Gen_State.Name +'' ''+Gen_Country.Name +'' '' + Gen_Country.Name as Address ,
--Lead.EmpID ,Lead.Category,Lead.AllocatedToEmpID
--FROM LEAD
--LEFT JOIN Gen_City ON Gen_City.CityID = Lead.CityID
--LEFT JOIN Gen_State ON Gen_State.StateID = Gen_City.StateID 
--LEFT JOIN Gen_Country ON Gen_Country.CountryID=Gen_State.CountryID 
END















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_City_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of City for Combo
-- =============================================
CREATE PROCEDURE [dbo].[usp_City_DDL]
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		CityID,
		Name as CityName
	FROM
		Gen_City 
	ORDER BY
		CityName
		
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Customer_Lead_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for bind Customer lov.
-- =============================================
--select * from Customer
CREATE PROCEDURE [dbo].[usp_Customer_Lead_LOV]
--@i_CompId bigint
AS
BEGIN
    SET NOCOUNT ON;
--    SELECT     Lead.LeadId AS CustomerID, Lead.LeadNo AS CustomerCode, Lead.CustomerName, Lead.Email AS EMAIL, Lead.LeadDate, Lead.Phone1, Lead.ContactPerson, 
--                      Lead.Address + '' ,'' + Gen_City.Name + '', '' + Gen_State.Name + '', '' + Gen_Country.Name AS Address, Lead.EmpID, Lead.Category, Lead.AllocatedToEmpID, Lead.CompId
--FROM         Lead LEFT OUTER JOIN
--                      Gen_City ON Gen_City.CityID = Lead.CityID LEFT OUTER JOIN
--                      Gen_State ON Gen_State.StateID = Gen_City.StateID LEFT OUTER JOIN
--                      Gen_Country ON Gen_State.CountryID = Gen_Country.CountryID where Lead.CompId=@i_CompId
--    ORDER BY Lead.CustomerName;

SELECT     CustomerMain.CustomerID, ISNULL(CustomerMain.AccountID, 0) AS AccountID, CustomerMain.CustomerCode, CustomerMain.CustomerName, CustomerMain.Address, 
                      CustomerMain.CityID, CustomerMain.Pincode, CustomerMain.Phone1, CustomerMain.MobileNo, CustomerMain.Email, CustomerMain.Website, 
                      CustomerMain.ContactPerson, CustomerMain.EmpID, CustomerMain.AllocatedToEmpID, CustomerMain.Category, CustomerMain.IsAccount, 
                      CustomerMain.Specification, CustomerMain.Remarks, CustomerMain.Name1, CustomerMain.CreditDays, CustomerMain.Name2, CustomerMain.Name3, 
                      CustomerMain.Name4, CustomerMain.Name5, CustomerMain.Name6, CustomerMain.Value1, CustomerMain.Value2, CustomerMain.Value3, CustomerMain.Value4, 
                      CustomerMain.Value5, CustomerMain.Value6, CustomerMain.CompId, CustomerMain.AreaID
FROM         CustomerMain INNER JOIN
                      Gen_City ON CustomerMain.CityID = Gen_City.CityID LEFT OUTER JOIN
                      Gen_State ON Gen_State.StateID = Gen_City.StateID LEFT OUTER JOIN
                      Gen_Country ON Gen_State.CountryID = Gen_Country.CountryID
--where Lead.CompId=@i_CompId
    ORDER BY CustomerMain.CustomerName;
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Customer_Select_Account]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select Customer record
-- =============================================
--select * from Customer
create PROCEDURE [dbo].[usp_Customer_Select_Account]
--[usp_Customer_Select]''10''
	@i_RecID Bigint

AS
BEGIN
	SET NOCOUNT ON;

		SELECT
		Customer.Code,
		Customer.Name as Company,
		Customer.Address1,
		Customer.Address2,
		Customer.CityID,
		Gen_CIty.Name As City,
		Gen_State.Name AS State, 
		Gen_Country.Name AS Country,
		Customer.Pincode,
		Customer.Phone1,
		Customer.Phone2,
		Customer.Fax,
		Customer.Mobile,
		Customer.TinNo,
		Customer.CSTNo,
		Customer.PANo,
		Customer.EccNo,
		Customer.CreditDays,
		Customer.Range,
		Customer.Division,	
		Customer.IsAccount,
		Customer.LeadId,
		Ledger.TransactionDate,
		OpeningBalance.CRAmount,
		OpeningBalance.DBAmount	,
		Customer.ContactPerson	
	FROM     OpeningBalance
		LEFT JOIN Ledger ON (OpeningBalance.AccountID = Ledger.AccountID AND Ledger.TransactionTypeID = 1) 
		LEFT JOIN Account ON Ledger.AccountID = Account.AccountID 
		LEFT Join Customer ON  Customer.AccountID =  Account.AccountID INNER JOIN
		Gen_City ON Customer.CityID = Gen_City.CityID INNER JOIN
		Gen_State ON Gen_City.StateID = Gen_State.StateID INNER JOIN
		Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID
	WHERE
		Customer.CustomerID = @i_RecID 
--end
--
--if @i_Mode=''NoAccount''
--begin
--	SELECT     Customer.Code,
--			   Customer.Name AS Company,
--			   Customer.Address1,
--				 Customer.Address2,
--					 Customer.CityID,
--				 Gen_City.Name AS City,
--			 Gen_State.Name AS State, 
--			Gen_Country.Name AS Country,
--			 Customer.Pincode,
--			 Customer.Phone1,
--			 Customer.Phone2,
--				 Customer.Fax,
--				 Customer.Mobile, 
--					Customer.TinNo,
--					 Customer.CSTNo, 
--						  Customer.PANo,
--						 Customer.EccNo, 
--					Customer.CreditDays,
--					Customer.Range, 
--					Customer.Division,
--					 Customer.IsAccount,
--					 Customer.LeadId, 
--					Customer.ContactPerson
--	FROM         Gen_City INNER JOIN
--						  Customer ON Gen_City.CityID = Customer.CityID INNER JOIN
--						  Gen_State ON Gen_City.StateID = Gen_State.StateID INNER JOIN
--						  Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID
--		WHERE
--			Customer.CustomerID = @i_RecID
--end






END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CustomerMain_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Select Lead record
-- =============================================
--select * from cUSTOMERMAIN
CREATE PROCEDURE [dbo].[usp_CustomerMain_Select]
--[usp_CustomerMain_Select]''30''
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;
SELECT CustomerMain.CustomerID,
       CustomerMain.CustomerCode,
       CustomerMain.CustomerName,
       CustomerMain.Address,
       CustomerMain.CityID,
       Gen_City.Name AS City,
       Gen_State.Name AS State,
       Gen_Country.Name AS Country,
       CustomerMain.Pincode,
       CustomerMain.Phone1,
       CustomerMain.MobileNo,
       CustomerMain.Email,
       CustomerMain.Name1,
       CustomerMain.Name2,
       CustomerMain.Name3,
       CustomerMain.Name4,
       CustomerMain.Name5,
       CustomerMain.Name6,
       CustomerMain.Value1,
       CustomerMain.Value2,
       CustomerMain.Value3,
       CustomerMain.Value4,
       CustomerMain.Value5,
       CustomerMain.Value6,
       CustomerMain.Specification,
       CustomerMain.Remarks,
       CustomerMain.ContactPerson,
       CustomerMain.Website,
       CustomerMain.AreaID,
       CustomerMain.Category,
       CustomerMain.AccountID,
       CustomerMain.CreditDays,
       CustomerMain.IsAccount
--       Ledger.TransactionDate,
--       OpeningBalance.CRAmount,
--       OpeningBalance.DBAmount
FROM   Gen_State
       LEFT OUTER JOIN
       Gen_City
       ON Gen_City.StateID = Gen_State.StateID
       LEFT OUTER JOIN
       Gen_Country
       ON Gen_Country.CountryID = Gen_State.CountryID
       LEFT OUTER JOIN
       CustomerMain
--       LEFT OUTER JOIN
--       Account
--       ON Account.AccountID = CustomerMain.AccountID
--       RIGHT OUTER JOIN
--       Ledger
--       ON Account.AccountID = Ledger.AccountID
--       LEFT OUTER JOIN
--       OpeningBalance
--       ON OpeningBalance.AccountID = Account.AccountID
--          AND OpeningBalance.AccountID = Ledger.AccountID
--          AND Ledger.TransactionTypeID = 1
       ON CustomerMain.CityID = Gen_City.CityID
				
	Where CustomerMain.CustomerID =  @i_RecID 

------------------------------

--		SELECT
--		Customer.Code,
--		Customer.Name as Company,
--		Customer.Address1,
--		Customer.Address2,
--		Customer.CityID,
--		Gen_CIty.Name As City,
--		Gen_State.Name AS State, 
--		Gen_Country.Name AS Country,
--		Customer.Pincode,
--		Customer.Phone1,
--		Customer.Phone2,
--		Customer.Fax,
--		Customer.Mobile,
--		Customer.TinNo,
--		Customer.CSTNo,
--		Customer.PANo,
--		Customer.EccNo,
--		Customer.CreditDays,
--		Customer.Range,
--		Customer.Division,	
--		Customer.IsAccount,
--		Customer.LeadId,
--		Ledger.TransactionDate,
--		OpeningBalance.CRAmount,
--		OpeningBalance.DBAmount	,
--		Customer.ContactPerson	
--	FROM     OpeningBalance
--		LEFT JOIN Ledger ON (OpeningBalance.AccountID = Ledger.AccountID AND Ledger.TransactionTypeID = 1) 
--		LEFT JOIN Account ON Ledger.AccountID = Account.AccountID 
--		LEFT Join Customer ON  Customer.AccountID =  Account.AccountID INNER JOIN
--		Gen_City ON Customer.CityID = Gen_City.CityID INNER JOIN
--		Gen_State ON Gen_City.StateID = Gen_State.StateID INNER JOIN
--		Gen_Country ON Gen_Country.CountryID = Gen_State.CountryID
--	WHERE
--		Customer.CustomerID = @i_RecID 

END













' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Area_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of Area
-- =============================================
CREATE PROCEDURE [dbo].[usp_Area_List]
	@i_CityID bigint	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		AreaID,
		Name as AreaName
	FROM
		Gen_Area
	WHERE
		CityID = @i_CityID
	ORDER BY
		Name

	SELECT     Gen_State.StateID, Gen_State.Name AS StateName
FROM         Gen_State INNER JOIN
                      Gen_Country ON Gen_State.CountryID = Gen_Country.CountryID INNER JOIN
                      Gen_City ON Gen_State.StateID = Gen_City.StateID
	where
		Gen_City.CityID=@i_CityID
		ORDER BY
		Gen_State.Name
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemClass_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Get Item Class List
-- =============================================
Create PROCEDURE [dbo].[usp_ItemClass_List]
AS
BEGIN
	SET NOCOUNT ON;
		SELECT 
			ItemClass.ItemClassID,
			ItemClass.[Name] AS ItemClass,
			ItemClass.Description
		FROM 
			ItemClass
		ORDER BY ItemClass
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemClass_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert Record of Item Class
-- =============================================
Create PROCEDURE [dbo].[usp_ItemClass_Insert]
	@i_Name		   Varchar(50),
	@i_Description Varchar(50),
	@i_UserID     Bigint,
	@o_ErrorMesg  varchar(500) OUTPUT
AS
BEGIN

	 --Declare Local Variables..
	Declare @l_VarRec Bigint;
	Declare @l_CreatedDate DateTime;
	Declare @l_ErrorNo BigInt;

	--Set Local Variable value..
	Set @l_VarRec=0;
	Set @o_ErrorMesg='''';

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  	--Set Current Date
	Select @l_CreatedDate = Convert(DateTime,GetDate(),105);

	--Check Custom Field caption is Exists or Not..	
	Select @l_varRec = Count(ItemClassID) from ItemClass WHERE UPPER([Name]) = UPPER(@i_Name) ;
	If @l_varRec = 0
		Begin
	
			Insert Into ItemClass
					(     [Name], Description , CreatedBy,   CreatedDate)
			Values  ( @i_Name,@i_Description,@i_UserID,@l_CreatedDate)

		End
	Else
		Begin
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 9001 );
		End

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemClass_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select Item Class
-- =============================================
Create PROCEDURE [dbo].[usp_ItemClass_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		
		[Name],
		Description
	FROM
		ItemClass
	WHERE
		ItemClassID = @i_RecID 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemClass_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Delete record from ItemClass 
-- =============================================
Create PROCEDURE [dbo].[usp_ItemClass_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	
	DELETE FROM ItemClass
		WHERE ItemClassID = @i_RecID ;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemClass_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Update record in Item Class
-- =============================================
Create PROCEDURE [dbo].[usp_ItemClass_Update]
	@i_ItemClassID Bigint,
	@i_ItemClassName Varchar(50),
	@i_Description Varchar(50),
	@i_UserID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
		SELECT @l_varRec = Count(ItemClassID) FROM ItemClass WHERE Upper([Name]) = Upper(@i_ItemClassName) AND ItemClassID != @i_ItemClassID;
			IF @l_varRec=0
				BEGIN 
					UPDATE
						ItemClass
					SET
						[Name]=@i_ItemClassName,
						Description = @i_Description,
						ModifiedBy=@i_UserID,
						ModifiedDate=@l_Date
					WHERE
						ItemClassID=@i_ItemClassID
				END
		ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 9001 );
		END

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemClass_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Get Item Class DDL
-- =============================================
Create PROCEDURE [dbo].[usp_ItemClass_DDL]
AS
BEGIN
	SET NOCOUNT ON;

	Select 
		ItemClassID,
		Name
	From 
		ItemClass
	Order By 
		Name


END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Select_ClassID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Select_ClassID]
	-- Add the parameters for the stored procedure here
	@i_Class nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     ItemClassID FROM ItemClass WHERE Name=@i_Class

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Indent_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for bind Vendor lov.
-- =============================================
CREATE PROCEDURE [dbo].[usp_Indent_LOV]
	 
AS
BEGIN
	 SET NOCOUNT ON;

--    SELECT     VendorID, Name AS VendorName, Fax
--FROM         Vendor
--ORDER BY VendorName
SELECT DISTINCT 
                      PO.PurchaseCode, PO.PurchaseDate, PO.VoucherNo, Vendor.Name AS VendorName, PO.VoucherDate, Godown.Godown_name AS GodownName, Vendor.VendorID, Vendor.CreditDays,
                      PO.PIID
FROM         PO LEFT JOIN
                      Vendor ON Vendor.VendorID = PO.VendorID LEFT JOIN
                      Godown ON Godown.GodownID =  PO.GodownID  LEFT JOIN
                      PODetail ON PODetail.PIID = PO.PIID 
END









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Godown_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Godown_Update]	
	-- Add the parameters for the stored procedure here
@i_Godown_name varchar(50),
	@i_Godown_addr    Varchar(50),
	@i_CityID int,
	@i_ModifiedBy Bigint,
	@i_GodownID int,
	@o_ErrorMesg   varchar(500) OUTPUT


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @l_GodownCount Bigint;
	Declare @l_Date DateTime;
	Declare @l_ErrorNo BigINt;
	--Set Local Variable value..
	Set @l_GodownCount=0;
	Set @o_ErrorMesg='''';
	--Set Current Date
	Select @l_Date=Convert(DateTime,GetDate(),5);
	Declare @l_ACDate DateTime;
	Set @l_ErrorNo = 0;

	BEGIN TRY  
	BEGIN TRAN

		--Check User Name is Exists or Not..	
		Select @l_GodownCount=Count(GodownID) From Godown Where Upper(Godown_name) = Upper(@i_Godown_name) AND GodownID <> @i_GodownID;
		If @l_GodownCount=0
			Begin

				--Update Record in Users Table
				Update 
					Godown
				Set 
					Godown_name = @i_Godown_name,
					Godown_addr = @i_Godown_addr,
					CityID=@i_CityID,
					ModifiedBy=@i_ModifiedBy,
					ModifiedDate=@l_Date
				Where 
					GodownID = @i_GodownID
	 
			End
		ELSE
			BEGIN
				SET @l_ErrorNo = 1001
			END

		If @l_ErrorNo=0
			Begin
				COMMIT TRAN
			End		
		Else
			Begin
				ROLLBACK TRAN  
			End 
			
	END TRY
	BEGIN CATCH   
		SET @l_ErrorNo = 10000
		ROLLBACK TRAN  
	END CATCH 

	IF @o_ErrorMesg = ''''
	BEGIN
		SELECT @o_ErrorMesg = ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = @l_ErrorNo				
	END

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Godown_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Godown_Select]
	-- Add the parameters for the stored procedure here
	@i_RecID Bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from Godown where GodownID=@i_RecID
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Godown_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Godown_DDL]
	-- Add the parameters for the stored procedure here
	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	select * from Godown order by Godown_name



END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Godown_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Godown_Delete]
@i_RecID bigint,
	@o_ErrorMesg varchar(500) OUTPUT
AS
BEGIN
SET @o_ErrorMesg='''';
	SET NOCOUNT ON;

  Delete From Godown WHERE GodownID = @i_RecID;
	
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Godown_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Godown_List]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     Godown.GodownID, Godown.Godown_name, Godown.Godown_addr, Godown.CreatedBy, Godown.CreatedDate, Godown.ModifiedBy, Godown.ModifiedDate, 
                      Godown.CityID, Gen_City.Name as CityName
FROM         Godown INNER JOIN
                      Gen_City ON Godown.CityID = Gen_City.CityID
ORDER BY Godown.Godown_name
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Godown_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Godown_Insert]	
	-- Add the parameters for the stored procedure here
	@i_Godown_name varchar(50),
	@i_Godown_addr    Varchar(50),
	@i_CreatedBy   Bigint,
	@i_CityID int,
	@o_ErrorMesg   varchar(500) OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @l_godownCount Bigint;
	Declare @l_CreatedDate DateTime;
	Declare @l_ErrorNo BigInt;

	--Set Local Variable value..
	Set @l_GodownCount=0;
	Set @o_ErrorMesg='''';
	Set @l_ErrorNo = 0;

  	--Set Current Date
	Select @l_CreatedDate = Convert(DateTime,GetDate(),105);

	BEGIN TRY  
	BEGIN TRAN

	--Check User Name is Exists or Not..	
	Select  @l_GodownCount = Count(Godown_name) From Godown Where Upper(Godown_name) = Upper(@i_Godown_name);
	If @l_GodownCount = 0
		Begin
				--Insert Record in User Table
				Insert Into Godown(   Godown_name   ,Godown_addr  ,CreatedBy   ,CreatedDate , CityID) 
 							Values  (@i_Godown_name,@i_Godown_addr,@i_CreatedBy,@l_CreatedDate , @i_CityID);
		End
	Else
		Begin
			SET @l_ErrorNo = 1001
		End

	If @l_ErrorNo=0
			Begin
				COMMIT TRAN
			End		
		Else
			Begin
				ROLLBACK TRAN  
			End 
			
END TRY
	BEGIN CATCH   
		SET @l_ErrorNo = 10000
		ROLLBACK TRAN  
	END CATCH 
	SELECT @o_ErrorMesg = ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = @l_ErrorNo				
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemAdjustment_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of ItemAdjustment
-- =============================================
CREATE PROCEDURE [dbo].[usp_ItemAdjustment_List]
	@i_FYID Bigint
AS
BEGIN
	SET NOCOUNT ON;

SELECT     ItemAdjustment.AdjustmentID, ItemAdjustment.AdjustDate, ItemAdjustment.ItemID, Item.Code AS ItemCode, Item.Name AS ItemName, ItemAdjustment.Qty, 
                      ItemAdjustment.GodownID, CASE ItemAdjustment.IsConfirmed WHEN 0 THEN ''Not Confirmed'' WHEN 1 THEN ''Confirmed'' END AS Status, Godown.Godown_name
FROM         ItemAdjustment INNER JOIN
                      Item ON ItemAdjustment.ItemID = Item.ItemID INNER JOIN
                      Godown ON ItemAdjustment.GodownID = Godown.GodownID
WHERE     (ItemAdjustment.FYID = @i_FYID) OR
                      (ItemAdjustment.IsConfirmed = 0)
ORDER BY ItemAdjustment.AdjustDate DESC, ItemCode
		
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Country_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of Country
-- =============================================
CREATE PROCEDURE [dbo].[usp_Country_List]

@i_UserID bigint
	
AS
BEGIN
	SET NOCOUNT ON;

if @i_UserID = 1
begin
	SELECT
		CountryID,
		Name as CountryName
	FROM
		Gen_Country
	ORDER BY
		Name
		
END
else
begin

SELECT
		CountryID,
		Name as CountryName
	FROM
		Gen_Country  where CreatedBy = @i_UserID
	ORDER BY
		Name

end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Update_Reminder_Flag]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Update_Reminder_Flag]
	-- Add the parameters for the stored procedure here
	
	@i_SRID bigint,
	@i_SIID bigint,
	@i_ServiceId varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Update Reminder Flag
	UPDATE    Sales_Service_Reminder
SET              SR_Done = 1,ServiceId=@i_ServiceId
WHERE	SRID=@i_SRID AND SIID=@i_SIID
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ServiceModule_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Delete record from ServiceModule 
-- =============================================
--select * from Sales_Service_Reminder
 CREATE PROCEDURE [dbo].[usp_ServiceModule_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';

DELETE FROM Services_TNC WHERE Code=(SELECT RequestNo FROM ServiceModule WHERE ServiceId = @i_RecID )
	
DELETE FROM ServiceDocList WHERE ServiceID=@i_RecID

DELETE FROM ServiceDetails WHERE SIID=@i_RecID
--added by rooja
DELETE FROM Sales_Service_Reminder WHERE SIID=@i_RecID

DELETE FROM ServiceModule WHERE ServiceId = @i_RecID ;
		
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Reminder_For_Service]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--select * from Sales_Service_Reminder
--select * from SalesInvoice
--select * from ServiceModule
CREATE PROCEDURE [dbo].[usp_Reminder_For_Service]
--[usp_Reminder_For_Service] ''NONAC SERTVICES'',''4''
	-- Add the parameters for the stored procedure here

	@i_Name varchar(50),
	@i_SIID bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @l_varRec bigint;


	SELECT @l_varRec = CustomerID FROM Customer WHERE Upper(Name) = Upper(@i_Name) ;

    -- Insert statements for procedure here

SELECT     a.SR_Code, a.SR_Date, a.SIID, a.SRID, c.CustomerID, d.EmpName AS attendedby, b.Problem, b.OtherRequirement, a.SR_Done,
                      Lead.CustomerName AS CustomerName
FROM         Lead LEFT JOIN
                      SalesInvoice AS c ON c.CustomerID = Lead.LeadId RIGHT OUTER JOIN
                      Sales_Service_Reminder AS a LEFT OUTER JOIN
                      ServiceModule AS b ON b.ServiceId = a.ServiceId ON c.SIID = a.SIID LEFT OUTER JOIN
                      Employee AS d ON b.AttendedBy = d.EmpID
WHERE     (Lead.CustomerName = @i_Name ) AND (a.SIID = @i_SIID)



--	SELECT     Sales_Service_Reminder.SR_Code, Sales_Service_Reminder.SR_Date, Sales_Service_Reminder.SIID, Sales_Service_Reminder.SRID, SalesInvoice.CustomerID, 
--                      CASE WHEN SR_Done = 1 THEN Customer.Name ELSE '''' END AS AttendedBy, CASE WHEN SR_Done = 1 THEN ServiceModule.Problem ELSE '''' END AS Problem, 
--                      CASE WHEN SR_Done = 1 THEN ServiceModule.OtherRequirement ELSE '''' END AS OtherRequirement, Sales_Service_Reminder.SR_Done
--FROM         Sales_Service_Reminder INNER JOIN
--                      SalesInvoice ON Sales_Service_Reminder.SIID = SalesInvoice.SIID LEFT OUTER JOIN
--                      ServiceModule ON ServiceModule.SIID = Sales_Service_Reminder.SIID LEFT OUTER JOIN
--                      Customer ON Customer.CustomerID = ServiceModule.AttendedBy
--WHERE     (SalesInvoice.TypeOfSale = @i_TypeOfSale) AND (SalesInvoice.CustomerID = @l_varRec) AND (Sales_Service_Reminder.SIID = @i_SIID)
END









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Reminder_Service_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Reminder_Service_Select]
	-- Add the parameters for the stored procedure here
	@i_Name varchar(50),
	@i_SIID bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DECLARE @l_varRec bigint;

	SELECT @l_varRec = CustomerID FROM Customer WHERE Upper(Name) = Upper(@i_Name) ;

    -- Insert statements for procedure here
	select a.SR_Code,a.SR_Date,a.SIID,a.SRID,c.Customerid,d.empname as attendedby,b.problem,b.OtherRequirement,a.SR_Done 
from sales_service_reminder a
left join servicemodule b on b.serviceid=a.serviceid
left join salesinvoice c on c.SIID=a.SIID
left join Employee d on d.EmpID=b.attendedby
LEFT JOIN LEAD E ON E.LEADID=C.CUSTOMERID 
where E.CUSTOMERNAME=@i_Name and a.siid=@i_SIID
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_State_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of City for Combo
-- =============================================
CREATE PROCEDURE [dbo].[usp_State_DDL]
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		StateID,
		Name as StateName
	FROM
		Gen_State 
	ORDER BY
		StateName
		
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_PORegister]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Roshni Patel
-- Create date: 23rd Jan 2011
-- Description:	Report of Purchase Invoice
-- =============================================
CREATE PROCEDURE [dbo].[rpt_PORegister]
--[rpt_PORegister]''1''
	@i_FYID BIGINT 
AS
BEGIN
	SET NOCOUNT ON;
SELECT   PO.PIID,
         PO.PurchaseCode,
	     Vendor.Name AS VendorName,
		 Item.Code AS ItemCode,
		 Item.Name ItemDesc,
		 PODetail.Rate,
		 PODetail.Qty AS OQty,
		 0 AS DQty,
         0 AS Diff,
         0 AS OrdValue,
         0 AS SupplyValue,  
		 0 AS diff1  ,     
		 Indent.PurchaseCode AS GRNCode            
FROM     PO
         LEFT JOIN
         IndentDetail
         LEFT JOIN
         Indent
         ON Indent.PIID=IndentDetail.PIID 
         ON Indent.PGID=PO.PIID 
         LEFT JOIN
         Vendor
         ON Vendor.VendorID=PO.VendorID 
         LEFT JOIN
         Item
         ON Item.ItemID=IndentDetail.ItemID 
         LEFT JOIN
         PODetail
         ON PODetail.PIID=PO.PIID 
WHERE    PO.FYID = @i_FYID
--ORDER BY PO.PurchaseDate, PO.PurchaseCode DESC;

----------------------
--         PO.PurchaseDate,
--         PO.VoucherNo,
--         PO.VoucherDate,
--         Vendor.Code,
--         PO.DueDays,
--         PO.DueDate,
--         PO.TotalAmount,
--         PO.ExciseAmount,
--         PO.CessAmount,
--         PO.HCessAmount,
--         PO.AmountAfterExcise,
--         PO.CSTAmount,
--         PO.VATAmount,
--         PO.AVATAmount,
--         PO.Discount,
--         PO.NetAmount,
--         PO.Narration,
--         PurchaseInvoiceDetail.PIDetailID,
--         PurchaseInvoiceDetail.ItemID,
--         PurchaseInvoiceDetail.Qty,
--        
--         PurchaseInvoiceDetail.Amount,
--         PurchaseInvoiceDetail.ReceivedQty,
--         PurchaseInvoiceDetail.PIID AS GRNID,
--         PurchaseInvoiceDetail.RemainingQty,       
        
         


--SELECT     PO.PIID, PO.PurchaseCode, PO.PurchaseDate, PO.VoucherNo, PO.VoucherDate, Vendor.Name AS VendorName, Vendor.Code, PO.DueDays, PO.DueDate, 
--                      PO.TotalAmount, PO.ExciseAmount, PO.CessAmount, PO.HCessAmount, PO.AmountAfterExcise, PO.CSTAmount, PO.VATAmount, PO.AVATAmount, PO.Discount, 
--                      PO.NetAmount, PO.Narration, PurchaseInvoiceDetail.PIDetailID, PurchaseInvoiceDetail.ItemID, PurchaseInvoiceDetail.Qty, PurchaseInvoiceDetail.Rate, 
--                      PurchaseInvoiceDetail.Amount, PurchaseInvoiceDetail.ReceivedQty, PurchaseInvoiceDetail.PIID AS GRNID, PurchaseInvoiceDetail.RemainingQty, 
--                      PurchaseInvoice.PurchaseCode AS GRNCode, Item.Code AS ItemCode, 0 AS DQty, 0 AS Diff, 0 AS OrdValue, 0 AS SupplyValue, 0 AS diff, PODetail.Qty AS POQty
--FROM         PO INNER JOIN
--                      PurchaseInvoiceDetail INNER JOIN
--                      PurchaseInvoice ON PurchaseInvoiceDetail.PIID = PurchaseInvoice.PIID ON PO.PIID = PurchaseInvoice.PGID INNER JOIN
--                      Vendor ON PO.VendorID = Vendor.VendorID INNER JOIN
--                      Item ON PurchaseInvoiceDetail.ItemID = Item.ItemID INNER JOIN
--                      PODetail ON PO.PIID = PODetail.PIID
--WHERE PO.FYID = @i_FYID
--Order By PO.PurchaseDate,PO.PurchaseCode Desc

-----------------------------------------
--	SELECT PO.PIID,
--		PO.PurchaseCode,
--		PO.PurchaseDate,
--		PO.VoucherNo,
--		PO.VoucherDate,
--		PO.VendorID,
--		Vendor.Code,		
--		Vendor.[Name] as VendorName,
--		PO.DueDays,
--		PO.DueDate,
--		PO.TotalAmount,
--		PO.ExciseAmount,
--		PO.CessAmount,
--		PO.HCessAmount,
--		PO.AmountAfterExcise,
--		PO.CSTAmount,
--		PO.VATAmount,
--		PO.AVATAmount,
--		PO.Discount,
--		PO.NetAmount,
--		PO.Narration
--  FROM PO
--		Inner Join Vendor On Vendor.VendorID = PO.VendorID
--	WHERE PO.FYID = @i_FYID
--	Order By PO.PurchaseDate,PO.PurchaseCode Desc

END





set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PO_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 24th Jan 2011
-- Description:	Delete record from Purchase Invoice And Detail
-- =============================================

CREATE PROCEDURE [dbo].[usp_PO_Delete]
--[usp_PO_Delete]''2'',''1'',''''
	@i_RecID Bigint,
	@i_GodownID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	-- Set Local Variable
	SET @o_ErrorMesg='''';
 
     
		-- Delete Stock	
		Update ItemStock
			Set ItemStock.QOH =  ItemStock.QOH -
				(Select IsNull(Sum(ItemStockDetail.Qty),0)
					From ItemStockDetail Where  ItemStockDetail.StockID = ItemStock.StockID 
						And ItemStockDetail.RefID = @i_RecID And ItemStockDetail.GTID=200 AND ItemStock.GodownID=@i_GodownID )
		From ItemStockDetail as SDet
		Where  
			SDet.StockID = ItemStock.StockID And 
			SDet.RefID = @i_RecID And
			ItemStock.StockID IN (Select StockID From ItemStockDetail
				Where ItemStockDetail.RefID = @i_RecID And ItemStockDetail.GTID=200)  AND ItemStock.GodownID=@i_GodownID

		-- Delete Record from StockDistrictDetail Table
		DELETE FROM ItemStockDetail WHERE RefID = @i_RecID AND GTID = 200;
	 	 
		Delete From Ledger Where TransactionTypeID=2 And TransactionID = @i_RecID

		Delete From PODetail Where PIID = @i_RecID;
		Delete From PO Where PIID = @i_RecID;




END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PO_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	Insert record of Purchase Invoice and Purchase Invoice Detail
-- =============================================

CREATE PROCEDURE [dbo].[usp_PO_Insert]
	@i_PurchaseCode Varchar(20),
	@i_FYID Bigint,
	@i_PurchaseDate DateTime,
	@i_SrNo Varchar(50),
	@i_VoucherNo Varchar(20),
	@i_VoucherDate DATETIME,
	@i_VendorID Bigint,
	@i_GodownID int,
	@i_DueDays Bigint,
	@i_DueDate DateTime,
	@i_TotalAmount Decimal(18,2),
	@i_ServiceAmount  Decimal(18,2),
	@i_ExciseAmount  Decimal(18,2),	
	@i_CessAmount Decimal(18,2),
	@i_HCessAmount Decimal(18,2),
	@i_AmountAfterExcise Decimal(18,2),
	@i_CSTAmount Decimal(18,2),
	@i_VATAmount Decimal(18,2),
	@i_AVATAmount Decimal(18,2),
	@i_Discount  Decimal(18,2),
	@i_NetAmount  Decimal(18,2),
	@i_PaidAmount  Decimal(18,2),
	@i_Narration Varchar(250),
	@i_XMLString xml,
	@i_Cnt Bigint,
	@i_UserID BIGINT,
	@i_CC varchar(MAX),
	@i_BCC varchar(MAX),
	@i_Is_SendMail bit,
	@i_CompId bigint,
	@o_ErrorMesg Varchar(200) OUTPUT

AS
BEGIN
 	SET NOCOUNT ON;

   -- Declare Local Variables...
	DECLARE @l_varRec Bigint;
 	DECLARE @l_VendorAccID Bigint
	DECLARE @l_LedNarration varchar(50)
	DECLARE @l_StockID Bigint
	DECLARE @l_NewDetID Bigint
	DECLARE @l_NewID BIGINT
	DECLARE @l_Description varchar(100);
	DECLARE @l_BankID bigint;
	-- Set Local Variable value..
	SET @l_varRec = 0;
	SET @l_Description  = ''''
	SET @l_VendorAccID = 0
	SET @l_LedNarration =''''
	SET @l_StockID = 0
	SET @l_NewDetID = 0
	SET @l_BankID=0
	-- Variable for StockDetail
 
	SET @o_ErrorMesg='''';
	SET @l_NewID = 0
 


--	BEGIN TRY  
--	BEGIN TRAN
-- 
 	SELECT @l_varRec = Count(PIID) From PO Where PurchaseCode = @i_PurchaseCode
 		IF @l_varRec = 0
 			BEGIN
 				Set @l_LedNarration  = ''Purchase Against '' + @i_PurchaseCode
 	
 				--Insert Record into Purchase invoice Table...
 				Insert Into PO(  FYID,   PurchaseCode,   PurchaseDate,   SrNo ,  VoucherNo ,   VoucherDate,   VendorID ,    DueDays,    DueDate,    TotalAmount,ServiceAmount,   ExciseAmount ,   CessAmount,   HCessAmount,   AmountAfterExcise ,   CSTAmount,   VATAmount,   AVATAmount  ,    Discount,    NetAmount,    Narration,   PaidAmount , GodownID,CC,BCC,Is_SendMail,CompId)
 		     						Values(@i_FYID,@i_PurchaseCode,@i_PurchaseDate,@i_SrNo,@i_VoucherNo ,@i_VoucherDate,@i_VendorID , @i_DueDays, @i_DueDate, @i_TotalAmount,@i_ServiceAmount,@i_ExciseAmount ,@i_CessAmount,@i_HCessAmount,@i_AmountAfterExcise ,@i_CSTAmount,@i_VATAmount,@i_AVATAmount  , @i_Discount,@i_NetAmount, @i_Narration,@i_PaidAmount , @i_GodownID,@i_CC,@i_BCC,@i_Is_SendMail,@i_CompId)
				SET @l_NewID = Scope_Identity();
				Set @o_ErrorMesg=convert(varchar, @l_NewID)
--
-- 				-- Vendor''s Ledger Effect
--				Select @l_VendorAccID = AccountID From Vendor Where VendorID = @i_VendorID
--				---Insert Record in Ledger
--				Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
--							Values(@l_VendorAccID,@i_FYID, 2,  @l_NewID, @i_PurchaseDate,0.000,@i_NetAmount,@l_LedNarration );
--
--
--				Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
--							Values(@l_VendorAccID,@i_FYID, 2,				   @l_NewID, @i_PurchaseDate,@i_PaidAmount,0.000,@l_LedNarration );
--
--
--				SELECT @l_BankID = AccountID From Account Where AccountName = @i_BankName
--				---Insert Record in Ledger For Bank
--				Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
--							Values(11,@i_FYID, 2,				   @l_NewID, @i_PurchaseDate,0.000,@i_NetAmount,@l_LedNarration );
--
--				---Insert Record in Ledger For Particular Bank
--				Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
--							Values(@l_BankID,@i_FYID, 2,				   @l_NewID, @i_PurchaseDate,0.000,@i_NetAmount,@l_LedNarration );
--
--
--				-- Insert Record for Service Tax Amount
--				If @i_ServiceAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(10,    @i_FYID,       2,				     @l_NewID,   @i_PurchaseDate,0.00,@i_ServiceAmount,@l_LedNarration);
--				End
--				-- Insert Record for Basic Excise Amount
--				If @i_ExciseAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(2,         @i_FYID,  2,				     @l_NewID,   @i_PurchaseDate,@i_ExciseAmount,0.00,@l_LedNarration);
--				End
--				-- Insert Record for Cess On Excise Amount
--				If @i_CessAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(3,        @i_FYID,   2,				     @l_NewID,   @i_PurchaseDate,@i_CessAmount,0.00,@l_LedNarration);
--				End
--				-- Insert Record for H Cess On Excise Amount
--				If @i_HCessAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(4,         @i_FYID,  2,				     @l_NewID,   @i_PurchaseDate,@i_HCessAmount,0.00,@l_LedNarration);
--				End
--				-- Insert Record for CST On Excise Amount
--				If @i_CSTAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(5,        @i_FYID,   2,				     @l_NewID,   @i_PurchaseDate,@i_CSTAmount,0.00,@l_LedNarration);
--				End
--				-- Insert Record for VAT On Excise Amount
--				If @i_VATAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(6,        @i_FYID,   2,				     @l_NewID,   @i_PurchaseDate,@i_VATAmount,0.00,@l_LedNarration);
--				End
--				-- Insert Record for AVAT On Excise Amount
--				If @i_AVATAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(7,        @i_FYID,   2,				     @l_NewID,   @i_PurchaseDate,@i_AVATAmount,0.00,@l_LedNarration);
--				End
--
--
--			---Insert Record in Ledger For Cash
--				Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--							Values(	1,		@i_FYID,	2,				     @l_NewID,   @i_PurchaseDate,0.00,@i_PaidAmount,@l_LedNarration);
--
 
				---Procedure For Insert Record into Purchase Invoice Detail Table...
				IF @i_Cnt > 0
				BEGIN		
					SELECT  x.d.value(''ItemID[1]'',''Bigint'') AS ItemID,							
						x.d.value(''Qty[1]'',''Decimal(18,3)'') AS Qty,
						x.d.value(''Rate[1]'',''Decimal(18,2)'') AS Rate,
						x.d.value(''Amount[1]'',''Decimal(18,2)'') AS Amount,
						x.d.value(''TaxClassID[1]'',''Bigint'') AS TaxClassID,
						x.d.value(''ServiceAmount[1]'',''Decimal(18,2)'') AS ServiceAmount,
						x.d.value(''ServiceRate[1]'',''Decimal(5,2)'') AS ServiceRate,	
						x.d.value(''ExciseRate[1]'',''Decimal(5,2)'') AS ExciseRate,						
						x.d.value(''ExciseAmount[1]'',''Decimal(18,2)'') AS ExciseAmount,
						x.d.value(''EduCessRate[1]'',''Decimal(5,2)'') AS EduCessRate,						
						x.d.value(''EduCessAmount[1]'',''Decimal(18,2)'') AS EduCessAmount,
						x.d.value(''HEduCessRate[1]'',''Decimal(5,2)'') AS HEduCessRate,						
						x.d.value(''HEduCessAmount[1]'',''Decimal(18,2)'') AS HEduCessAmount,
						x.d.value(''AmountAfterExcise[1]'',''Decimal(18,2)'') AS AmountAfterExcise,											x.d.value(''CSTRate[1]'',''Decimal(5,2)'') AS CSTRate,
						x.d.value(''CSTAmount[1]'',''Decimal(18,2)'') AS CSTAmount,
						x.d.value(''VATRate[1]'',''Decimal(5,2)'') AS VATRate,	
						x.d.value(''VATAmount[1]'',''Decimal(18,2)'') AS VATAmount,
						x.d.value(''AVATRate[1]'',''Decimal(5,2)'') AS AVATRate,
						x.d.value(''AVATAmount[1]'',''Decimal(18,2)'') AS AVATAmount,
						x.d.value(''NetAmount[1]'',''Decimal(18,2)'') AS NetAmount	,
                        x.d.value(''DDate[1]'',''datetime'') AS DDate	
					INTO #tmpDetail				
					FROM 
						@i_XMLString.nodes(''/NewDataSet/Table'') x(d);

					INSERT INTO PODetail (PIID,   ItemID,   Qty,   Rate,  Amount,   TaxClassID,  ServiceRate,  ServiceAmount,   ExciseRate,   ExciseAmount,   CessRate,   CessAmount,   HCessRate,   HCessAmount,   AmountAfterExcise,   CSTRate,   CSTAmount,   VATRate,   VATAmount,   AVATRate,   AVATAmount,   NetAmount,DDate)
											SELECT @l_NewID,T1.ItemID,T1.Qty,T1.Rate,T1.Amount,T1.TaxClassID,T1.ServiceRate,T1.ServiceAmount,T1.ExciseRate,T1.ExciseAmount,T1.EduCessRate,T1.EduCessAmount,T1.HEduCessRate,T1.HEduCessAmount,T1.AmountAfterExcise,T1.CSTRate,T1.CSTAmount,T1.VATRate,T1.VATAmount,T1.AVATRate,T1.AVATAmount,T1.NetAmount,T1.DDate FROM #tmpDetail T1 

--				SET @l_Description = ''Against Purchase Invoice : '' + @i_PurchaseCode; 
--				Insert Into ItemStock(FYID,      ItemID,    QOH, MinLevel, MaxLevel, ReorderLvl, CreatedBy, CreatedDate , GodownID)
-- 							Select @i_FYID,#tmpDetail.ItemID, 0, 0, 0, 0, @i_UserID, @i_PurchaseDate , @i_GodownID
--							From #tmpDetail Where #tmpDetail.ItemID Not In(
--								Select ItemStock.ItemID From ItemStock WHERE ItemStock.FYID = @i_FYID)
--				
--				-- Insert record in StockDistrictDetail
--				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
--					Select ItemStock.StockID, 100,ItemStock.StockID, @i_PurchaseDate, ''Opening Stock'',0.000
--						From #tmpDetail 
--							Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
--							Where ItemStock.QOH = 0 And ItemStock.FYID = @i_FYID
--								And ItemStock.StockID Not In (Select StockID from ItemStockDetail Where 
--									ItemStockDetail.StockID = ItemStock.StockID And ItemStockDetail.GTID=100)
--
--				-- Insert record in StockDistrictDetail
--				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
--						Select ItemStock.StockID, 200,@l_NewID, @i_PurchaseDate, @l_Description,  #tmpDetail.Qty
--							From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
--							Where ItemStock.FYID = @i_FYID
--		 				
--				-- Update Stock
--				Update ItemStock 
--					Set ItemStock.QOH = ItemStock.QOH +
--						(Select Sum(#tmpDetail.Qty) From #tmpDetail Where ItemStock.ItemID = #tmpDetail.ItemID )
--				From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
--				Where 
--					ItemStock.FYID = @i_FYID and GodownID=@i_GodownID
-- 
 				END
			  END
		  ELSE
			  BEGIN
					SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 23001 );
			  END			
		
--	COMMIT TRAN
--	END TRY
--		BEGIN CATCH 
--			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );  
--		ROLLBACK TRAN  
--	END CATCH 	

END














' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PO_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	Get Purchase Invoice List
-- =============================================
CREATE PROCEDURE [dbo].[usp_PO_List]
--[usp_PO_List]''1''
	@i_FYID BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT PO.PIID,
		PO.PurchaseCode,
		PO.PurchaseDate,
		PO.VendorID,
		Vendor.Code,		
		Vendor.[Name] as VendorName,
		PO.DueDays,
		PO.GodownID,
		PO.DueDate,
		PO.TotalAmount,
		PO.NetAmount,
		PO.Narration,
		PO.SrNo,
		PO.CC,
		PO.BCC, 
        CASE WHEN PO.Is_SendMail = ''False'' THEN ''Not Sent'' ELSE ''Sent'' END AS Is_SendMail
  FROM PO
		Inner Join Vendor On Vendor.VendorID = PO.VendorID
	WHERE PO.FYID = @i_FYID
	Order By PO.PurchaseDate,PO.PurchaseCode Desc

END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PO_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 24th jan 2011
-- Description:	Update record of Purchase Invoice and Purchase Invoice Detail
-- =============================================
CREATE PROCEDURE [dbo].[usp_PO_Update]
	@i_PIID Bigint,
	@i_PurchaseCode Varchar(20),
	@i_FYID Bigint,
	@i_PurchaseDate DateTime,
	@i_SrNo Varchar(50),
	@i_VoucherNo Varchar(20),
	@i_VoucherDate DATETIME,
	@i_VendorID Bigint,
	@i_DueDays Bigint,
	@i_DueDate DateTime,
	@i_TotalAmount Decimal(18,2),
	@i_ServiceAmount  Decimal(18,2),	
	@i_ExciseAmount  Decimal(18,2),	
	@i_CessAmount Decimal(18,2),
	@i_HCessAmount Decimal(18,2),
	@i_AmountAfterExcise Decimal(18,2),
	@i_CSTAmount Decimal(18,2),
	@i_VATAmount Decimal(18,2),
	@i_AVATAmount Decimal(18,2),
	@i_Discount DECIMAL(18,2),
	@i_NetAmount  Decimal(18,2),
	@i_PaidAmount  Decimal(18,2),
	@i_Narration Varchar(250),
	@i_XMLString xml,
	@i_Cnt Bigint,
	@i_UserID BIGINT,
	@i_GodownID int,
	@i_CC varchar(MAX),
	@i_BCC varchar(MAX),
	@i_Is_SendMail bit,
	@i_CompId bigint,
	@o_ErrorMesg Varchar(200) OUTPUT

AS
BEGIN
	SET NOCOUNT ON;

    -- Declare Local Variables...
	DECLARE @l_varRec Bigint;
 	DECLARE @l_VendorAccID Bigint
	DECLARE @l_LedNarration varchar(50)
	DECLARE @l_BankID bigint
 
	DECLARE @l_Description varchar(100);
	-- Set Local Variable value..
	SET @l_varRec = 0;
	SET @l_Description  = ''''
	SET @l_VendorAccID = 0
	SET @l_LedNarration =''''
	SET @l_BankID=0
 
	-- Variable for StockDetail
 
	SET @o_ErrorMesg='''';
 


	BEGIN TRY  
	BEGIN TRAN
 
 	SELECT @l_varRec = Count(PIID) From PO Where PurchaseCode = @i_PurchaseCode AND PIID <> @i_PIID
 		IF @l_varRec = 0
 			BEGIN
-- 				Set @l_LedNarration  = ''Purchase Against '' + @i_PurchaseCode
-- 					-- Delete Stock	
--				Update ItemStock
--					Set ItemStock.QOH =  ItemStock.QOH -
--						(Select IsNull(Sum(ItemStockDetail.Qty),0)
--							From ItemStockDetail Where  ItemStockDetail.StockID = ItemStock.StockID 
--								And ItemStockDetail.RefID = @i_PIID And ItemStockDetail.GTID=200 AND ItemStock.GODOWNID=@i_GodownID)
--				From ItemStockDetail as SDet
--				Where  
--					SDet.StockID = ItemStock.StockID And 
--					SDet.RefID = @i_PIID And
--					ItemStock.StockID IN (Select StockID From ItemStockDetail
--						Where ItemStockDetail.RefID = @i_PIID And ItemStockDetail.GTID=200) AND ItemStock.GODOWNID=@i_GodownID
--
--				-- Delete Record from StockDistrictDetail Table
--				DELETE FROM ItemStockDetail WHERE RefID = @i_PIID AND GTID = 200;
--			 	 
--				Delete From Ledger Where TransactionTypeID=2 And TransactionID = @i_PIID

				Delete From PODocList Where PIID =@i_PIID; 
				Delete From PODetail Where PIID = @i_PIID;

 			 -- Update Record IN PurchaseInvoice		
				UPDATE
					PO
				SET
					PurchaseCode = @i_PurchaseCode, 
					PurchaseDate=@i_PurchaseDate,   
					SrNo = @i_SrNo ,
					FYID=@i_FYID,
					VendorID=@i_VendorID,  
					VoucherNo = @i_VoucherNo ,   
					VoucherDate = @i_VoucherDate,   
					DueDate = @i_DueDate,
					DueDays = @i_DueDays,
					TotalAmount = @i_TotalAmount,   
					ServiceAmount = @i_ServiceAmount,
					ExciseAmount = @i_ExciseAmount,   
					CessAmount = @i_CessAmount,   
					HCessAmount = @i_HCessAmount,   
					AmountAfterExcise = @i_AmountAfterExcise,
					CSTAmount = @i_CSTAmount,   
					VATAmount = @i_VATAmount,   
					AVATAmount = @i_AVATAmount,   
					Discount = @i_Discount,
					NetAmount = @i_NetAmount,
					PaidAmount = @i_PaidAmount,
					Narration=@i_Narration,
					GodownID=@i_GodownID,
					CC=@i_CC,
					BCC=@i_BCC,		
					CompId=@i_CompId,
					Is_SendMail=@i_Is_SendMail
				WHERE
					PIID = @i_PIID

-- 				-- Vendor''s Ledger Effect
--				Select @l_VendorAccID = AccountID From Vendor Where VendorID = @i_VendorID
--				---Insert Record in Ledger
--				Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
--							Values(@l_VendorAccID,@i_FYID, 2,				   @i_PIID, @i_PurchaseDate,0.000,@i_NetAmount,@l_LedNarration );
--
--				Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
--							Values(@l_VendorAccID,@i_FYID, 2,				   @i_PIID, @i_PurchaseDate,@i_PaidAmount,0.000,@l_LedNarration );
--
--				---Insert Record in Ledger For Bank
--				Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
--							Values(11,@i_FYID, 2,				   @i_PIID, @i_PurchaseDate,0.000,@i_NetAmount,@l_LedNarration );	
--
--
--				SELECT @l_BankID = AccountID From Account Where AccountName = @i_BankName
--				---Insert Record in Ledger For Particular Bank
--					Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
--							Values(@l_BankID,@i_FYID, 2,				   @i_PIID, @i_PurchaseDate,0.000,@i_NetAmount,@l_LedNarration );
--	
--				-- Insert Record for Basic Excise Amount
--				If @i_ServiceAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID, FYID,TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(10,           @i_FYID,2,				     @i_PIID,   @i_PurchaseDate,0.00,@i_ServiceAmount,@l_LedNarration);
--				End
--				-- Insert Record for Basic Excise Amount
--				If @i_ExciseAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(2,   @i_FYID,        2,				     @i_PIID,   @i_PurchaseDate,@i_ExciseAmount,0.00,@l_LedNarration);
--				End
--				-- Insert Record for Cess On Excise Amount
--				If @i_CessAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID,FYID ,TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(3,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_CessAmount,0.00,@l_LedNarration);
--				End
--				-- Insert Record for H Cess On Excise Amount
--				If @i_HCessAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(4,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_HCessAmount,0.00,@l_LedNarration);
--				End
--				-- Insert Record for CST On Excise Amount
--				If @i_CSTAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(5,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_CSTAmount,0.00,@l_LedNarration);
--				End
--				-- Insert Record for VAT On Excise Amount
--				If @i_VATAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(6,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_VATAmount,0.00,@l_LedNarration);
--				End
--				-- Insert Record for AVAT On Excise Amount
--				If @i_AVATAmount>0
--				Begin
--					---Insert Record in Ledger
--					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--								Values(7,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_AVATAmount,0.00,@l_LedNarration);
--				End
--
--
--			---Insert Record in Ledger For Cash
--				Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--							Values(	1,		@i_FYID,	2,				     @i_PIID,   @i_PurchaseDate,0.00,@i_PaidAmount,@l_LedNarration);
--
 
				---Procedure For Insert Record into Purchase Invoice Detail Table...
				IF @i_Cnt > 0
				BEGIN		
					SELECT  x.d.value(''ItemID[1]'',''Bigint'') AS ItemID,							
						x.d.value(''Qty[1]'',''Decimal(18,3)'') AS Qty,
						x.d.value(''Rate[1]'',''Decimal(18,2)'') AS Rate,
						x.d.value(''Amount[1]'',''Decimal(18,2)'') AS Amount,
						x.d.value(''TaxClassID[1]'',''Bigint'') AS TaxClassID,
						x.d.value(''ServiceRate[1]'',''Decimal(5,2)'') AS ServiceRate,						
						x.d.value(''ServiceAmount[1]'',''Decimal(18,2)'') AS ServiceAmount,
						x.d.value(''ExciseRate[1]'',''Decimal(5,2)'') AS ExciseRate,						
						x.d.value(''ExciseAmount[1]'',''Decimal(18,2)'') AS ExciseAmount,
						x.d.value(''EduCessRate[1]'',''Decimal(5,2)'') AS EduCessRate,						
						x.d.value(''EduCessAmount[1]'',''Decimal(18,2)'') AS EduCessAmount,
						x.d.value(''HEduCessRate[1]'',''Decimal(5,2)'') AS HEduCessRate,						
						x.d.value(''HEduCessAmount[1]'',''Decimal(18,2)'') AS HEduCessAmount,
						x.d.value(''AmountAfterExcise[1]'',''Decimal(18,2)'') AS AmountAfterExcise,						
						x.d.value(''CSTRate[1]'',''Decimal(5,2)'') AS CSTRate,
						x.d.value(''CSTAmount[1]'',''Decimal(18,2)'') AS CSTAmount,
						x.d.value(''VATRate[1]'',''Decimal(5,2)'') AS VATRate,	
						x.d.value(''VATAmount[1]'',''Decimal(18,2)'') AS VATAmount,
						x.d.value(''AVATRate[1]'',''Decimal(5,2)'') AS AVATRate,
						x.d.value(''AVATAmount[1]'',''Decimal(18,2)'') AS AVATAmount,
						x.d.value(''NetAmount[1]'',''Decimal(18,2)'') AS NetAmount	,
                        x.d.value(''DDate[1]'',''datetime'') AS DDate	
					INTO #tmpDetail				
					FROM 
						@i_XMLString.nodes(''/NewDataSet/Table'') x(d);

					INSERT INTO PODetail (PIID,   ItemID,   Qty,   Rate,  Amount,   TaxClassID,ServiceRate,   ServiceAmount,     ExciseRate,  ExciseAmount,      CessRate,      CessAmount,   HCessRate,   HCessAmount,   AmountAfterExcise,   CSTRate,   CSTAmount,   VATRate,   VATAmount,   AVATRate,   AVATAmount,   NetAmount,DDate)
											SELECT @i_PIID,T1.ItemID,T1.Qty,T1.Rate,T1.Amount,T1.TaxClassID,T1.ServiceRate,T1.ServiceAmount,T1.ExciseRate,T1.ExciseAmount,T1.EduCessRate,T1.EduCessAmount,T1.HEduCessRate,T1.HEduCessAmount,T1.AmountAfterExcise,T1.CSTRate,T1.CSTAmount,T1.VATRate,T1.VATAmount,T1.AVATRate,T1.AVATAmount,T1.NetAmount,T1.DDate FROM #tmpDetail T1 

--				SET @l_Description = ''Against Purchase Invoice : '' + @i_PurchaseCode; 
--				Insert Into ItemStock(FYID,      ItemID,    QOH, MinLevel, MaxLevel, ReorderLvl, CreatedBy, CreatedDate , GodownID)
-- 							Select @i_FYID,#tmpDetail.ItemID, 0, 0, 0, 0, @i_UserID, @i_PurchaseDate , @i_GodownID
--							From #tmpDetail Where #tmpDetail.ItemID Not In(
--								Select ItemStock.ItemID From ItemStock WHERE ItemStock.FYID = @i_FYID)
--				
--				-- Insert record in StockDistrictDetail
--				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
--					Select ItemStock.StockID, 100,ItemStock.StockID, @i_PurchaseDate, ''Opening Stock'',0.000
--						From #tmpDetail 
--							Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
--							Where ItemStock.QOH = 0 And ItemStock.FYID = @i_FYID
--								And ItemStock.StockID Not In (Select StockID from ItemStockDetail Where 
--									ItemStockDetail.StockID = ItemStock.StockID And ItemStockDetail.GTID=100)
--
--				-- Insert record in StockDistrictDetail
--				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
--						Select ItemStock.StockID, 200,@i_PIID, @i_PurchaseDate, @l_Description,  #tmpDetail.Qty
--							From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
--							Where ItemStock.FYID = @i_FYID
--		 				
--				-- Update Stock
--				Update ItemStock 
--					Set ItemStock.QOH = ItemStock.QOH +
--						(Select Sum(#tmpDetail.Qty) From #tmpDetail Where ItemStock.ItemID = #tmpDetail.ItemID )
--				From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
--				Where 
--					ItemStock.FYID = @i_FYID  and GodownID=@i_GodownID
 				END
			  END
		  ELSE
			  BEGIN
					SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 23001 );
			  END		
		
	COMMIT TRAN
	END TRY
		BEGIN CATCH 
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );  
		ROLLBACK TRAN  
	END CATCH 
END










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ServiceModule_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Update record in ServiceModule table
-- =============================================
 
CREATE PROCEDURE [dbo].[usp_ServiceModule_Update]
	@i_ServiceId	bigint,
	@i_RequestNo	varchar(20),
	@i_ServiceDate	datetime,
	@i_CustomerID	bigint,
	@i_CustomerName	varchar(150),
	@i_Address	varchar(500),
	@i_MobileNo	varchar(20),
	@i_ModelNumber	varchar(50),
	@i_Problem	varchar(500),
	@i_AttendedBy	bigint,
	@i_JobComputed	varchar(500),
	@i_Remarks	varchar(500),
	@i_OtherRequirement	varchar(500),
	@i_Charges	decimal(18,0),
	@i_SIID Bigint,
	@i_UserID bigint,
	@i_Cnt Bigint,
	@i_FYID Bigint,
	@i_GodownID int,
	@i_CallID int,
	@i_TotalAmount decimal(18,2),
	@i_ServiceAmount decimal(18,2),
	@i_ExciseAmount decimal(18,2),
	@i_CessAmount decimal(18,2),
	@i_HCessAmount decimal(18,2),
	@i_AmountAfterExcise decimal(18,2),
	@i_CSTAmount decimal(18,2),
	@i_VATAmount decimal(18,2),
	@i_AVATAmount decimal(18,2),
	@i_Discount decimal(18,2),
	@i_NetAmount decimal(18,2),
	@i_PaidAmount decimal(18,2),
	@i_XMLString xml,
	@i_TypeOfSale varchar(50),
	@i_EmpAllToID bigint,
	@i_Status nvarchar(50),
	@i_CompId bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @l_varRec Bigint;
 	DECLARE @l_CustomerAccID Bigint
	DECLARE @l_LedNarration varchar(50)
 	DECLARE @l_Description varchar(100);
	-- Set Local Variable value..
	SET @l_varRec = 0;
	SET @l_Description  = ''''
	SET @l_CustomerAccID = 0
	SET @l_LedNarration =''''
	
	-- Variable for StockDetail
	SET @l_varRec = 0;
	SET @l_Description  = ''''
	SET @l_CustomerAccID = 0
	SET @l_LedNarration =''''


	-- Variable for StockDetail
 
	SET @o_ErrorMesg='''';

 
	SET @o_ErrorMesg='''';

	-- Declare Local Variable
 	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable

 
	SET @l_Date=Convert(Datetime,getDate(),5);

	SELECT Count(ServiceID) from ServiceModule Where RequestNo = @i_RequestNo And ServiceID <> @i_ServiceId
 		IF @l_varRec = 0
 			BEGIN
 				Set @l_LedNarration  = ''Service Against '' + @i_RequestNo
 					-- Delete Stock	
				Update ItemStock
					Set ItemStock.QOH =  ItemStock.QOH +
						(Select IsNull(Sum(ItemStockDetail.Qty),0)
							From ItemStockDetail Where  ItemStockDetail.StockID = ItemStock.StockID 
								And ItemStockDetail.RefID = @i_ServiceId And ItemStockDetail.GTID=300)
				From ItemStockDetail as SDet
				Where  
					SDet.StockID = ItemStock.StockID And 
					SDet.RefID = @i_ServiceId And
				
					ItemStock.StockID IN (Select StockID From ItemStockDetail
						Where ItemStockDetail.RefID = @i_ServiceId And ItemStockDetail.GTID=300) 

				-- Delete Record from StockDistrictDetail Table
				DELETE FROM ItemStockDetail WHERE RefID = @i_ServiceId AND GTID = 300;
			 	 
				Delete From ServiceDocList  Where ServiceID = @i_ServiceId;
				Delete From ServiceDetails Where SIID = @i_ServiceId;


	UPDATE 
		ServiceModule
	SET				 
		RequestNo = @i_RequestNo, 
		ServiceDate = @i_ServiceDate,
		CustomerID=@i_CustomerID,
		CustomerName = @i_CustomerName,
		Address = @i_Address,
		MobileNo = @i_MobileNo,
		
		ModelNumber = @i_ModelNumber,
		Problem = @i_Problem,
		AttendedBy = @i_AttendedBy,
		JobComputed = @i_JobComputed,
		Remarks = @i_Remarks,
		OtherRequirement = @i_OtherRequirement,
		Charges = @i_Charges,
		ModifiedBy = @i_UserID,
		ModifiedDate = @l_Date,
		SIID = @i_SIID,
		TotalAmount = @i_TotalAmount,   
		ServiceAmount = @i_ServiceAmount,
		ExciseAmount = @i_ExciseAmount,   
		CessAmount = @i_CessAmount,   
		HCessAmount = @i_HCessAmount,   
		AmountAfterExcise = @i_AmountAfterExcise,
		CSTAmount = @i_CSTAmount,   
		VATAmount = @i_VATAmount,   
		AVATAmount = @i_AVATAmount,   
		Discount = @i_Discount,
		NetAmount = @i_NetAmount,
		PaidAmount = @i_PaidAmount,
		GodownID=@i_GodownID,
		CallID=@i_CallID,
		TypeOfSale=@i_TypeOfSale,
		EmpAllToID=@i_EmpAllToID,
		Status=@i_Status,
		FYID=@i_FYID,
		CompId=@i_CompId
	WHERE
		ServiceId = @i_ServiceId 

		


					IF @i_Cnt > 0
				BEGIN		
					SELECT  x.d.value(''ItemID[1]'',''Bigint'') AS ItemID,
						x.d.value(''ItemDesc[1]'',''varchar(100)'') AS ItemDesc,							
						x.d.value(''Qty[1]'',''Decimal(18,3)'') AS Qty,
						x.d.value(''Rate[1]'',''Decimal(18,2)'') AS Rate,
						x.d.value(''Amount[1]'',''Decimal(18,2)'') AS Amount,
						x.d.value(''TaxClassID[1]'',''Bigint'') AS TaxClassID,
						x.d.value(''ServiceRate[1]'',''Decimal(5,2)'') AS ServiceRate,						
						x.d.value(''ServiceAmount[1]'',''Decimal(18,2)'') AS ServiceAmount,
						x.d.value(''ExciseRate[1]'',''Decimal(5,2)'') AS ExciseRate,						
						x.d.value(''ExciseAmount[1]'',''Decimal(18,2)'') AS ExciseAmount,
						x.d.value(''EduCessRate[1]'',''Decimal(5,2)'') AS EduCessRate,						
						x.d.value(''EduCessAmount[1]'',''Decimal(18,2)'') AS EduCessAmount,
						x.d.value(''HEduCessRate[1]'',''Decimal(5,2)'') AS HEduCessRate,						
						x.d.value(''HEduCessAmount[1]'',''Decimal(18,2)'') AS HEduCessAmount,
						x.d.value(''AmountAfterExcise[1]'',''Decimal(18,2)'') AS AmountAfterExcise,						
						x.d.value(''CSTRate[1]'',''Decimal(5,2)'') AS CSTRate,
						x.d.value(''CSTAmount[1]'',''Decimal(18,2)'') AS CSTAmount,
						x.d.value(''VATRate[1]'',''Decimal(5,2)'') AS VATRate,	
						x.d.value(''VATAmount[1]'',''Decimal(18,2)'') AS VATAmount,
						x.d.value(''AVATRate[1]'',''Decimal(5,2)'') AS AVATRate,
						x.d.value(''AVATAmount[1]'',''Decimal(18,2)'') AS AVATAmount,
						x.d.value(''NetAmount[1]'',''Decimal(18,2)'') AS NetAmount	
					INTO #tmpDetail				
					FROM 
						@i_XMLString.nodes(''/NewDataSet/Table'') x(d);

					INSERT INTO ServiceDetails (SIID,    ItemID,   ItemDesc,     Qty,   Rate,  Amount,   TaxClassID,    ServiceRate,  ServiceAmount,   ExciseRate,   ExciseAmount,       CessRate,      CessAmount,     HCessRate,      HCessAmount,   AmountafterExcise,   CSTRate,   CSTAmount,   VATRate,   VATAmount,   AVATRate,   AVATAmount,   NetAmount)
											SELECT @i_ServiceId,T1.ItemID,T1.ItemDesc,T1.Qty,T1.Rate,T1.Amount,T1.TaxClassID,T1.ServiceRate,T1.ServiceAmount,T1.ExciseRate,T1.ExciseAmount,T1.EduCessRate,T1.EduCessAmount,T1.HEduCessRate,T1.HEduCessAmount,T1.AmountafterExcise,T1.CSTRate,T1.CSTAmount,T1.VATRate,T1.VATAmount,T1.AVATRate,T1.AVATAmount,T1.NetAmount FROM #tmpDetail T1 


					SET @l_Description = ''Against Sales Invoice : '' + @i_RequestNo; 
				Insert Into ItemStock(FYID,      ItemID,    QOH, MinLevel, MaxLevel, ReorderLvl, CreatedBy, CreatedDate , GodownID)
 							Select @i_FYID,#tmpDetail.ItemID, 0, 0, 0, 0, @i_UserID, @i_ServiceDate, @i_GodownID
							From #tmpDetail Where #tmpDetail.ItemID Not In(
								Select ItemStock.ItemID From ItemStock WHERE ItemStock.FYID = @i_FYID)
				
				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
					Select ItemStock.StockID, 100,ItemStock.StockID, @i_ServiceDate, ''Opening Stock'',0.000
						From #tmpDetail 
							Inner Join ItemStock On #tmpDetail.ItemID = ItemStock.ItemID
							Where ItemStock.QOH = 0 And ItemStock.FYID = @i_FYID
								And ItemStock.StockID Not In (Select StockID from ItemStockDetail Where 
									ItemStockDetail.StockID = ItemStock.StockID And ItemStockDetail.GTID=100)

				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
						Select ItemStock.StockID, 300,@i_SIID, @i_ServiceDate, @l_Description, ((-1) * #tmpDetail.Qty)
							From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
							Where ItemStock.FYID = @i_FYID
		 				
				-- Update Stock
				Update ItemStock 
					Set ItemStock.QOH = ItemStock.QOH -
						(Select Sum(#tmpDetail.Qty) From #tmpDetail Where ItemStock.ItemID = #tmpDetail.ItemID )
				From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
				Where 
					ItemStock.FYID = @i_FYID and ItemStock.GodownID=@i_AttendedBy

End
End



END















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ServiceDocList_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ServiceDocList_List] 
	-- Add the parameters for the stored procedure here
	@i_RecID Bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM ServiceDocList WHERE ServiceID=@i_RecID
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ServiceDocList_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Insert record in ServiceDocList Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_ServiceDocList_Insert]
	@i_ServiceID Bigint,
	@i_DocName Varchar(250),
	@i_Remarks Varchar(250)
AS
BEGIN
	SET NOCOUNT ON;

		Delete From servicedoclist where ServiceID=@i_ServiceID

	INSERT INTO ServiceDocList ( ServiceID,DocName,Remarks)
			       VALUES(@i_ServiceID,@i_DocName,@i_Remarks)

END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SignIn]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	User Sign In
-- =============================================
CREATE PROCEDURE [dbo].[usp_SignIn] 
	@i_UserName varchar(25),
	@i_Password varchar(25),
	@i_Version varchar(25),
	@i_FYID Bigint,
	@i_CompId bigint,
	@o_ErrorMesg VArchar(500) Output	
	
AS
BEGIN
	Declare @l_VerCount Bigint;
	Declare @l_CurrentCount bigint;
	Declare @l_varRec Bigint;
	Declare @l_UserID Bigint;
	Declare @l_LoginDate Datetime;
	Declare @l_ErrorNo BigInt;
	Declare @l_errMsg varchar(250)
	Declare @l_FYStartDate DateTime
	Declare @l_FYEndDate DateTime
 

	Select @l_FYStartDate = StartDate,@l_FYEndDate = EndDate From FinancialYear Where FYID = @i_FYID;

	SELECT 	@l_LoginDate=Convert(DateTime,GetDate(),5);
	Set @l_CurrentCount=0;
	set @l_VerCount=0;
	Set @l_varRec = 0;
	Set @l_ErrorNo = 0;
	
	Set @l_errMsg  = ''''
	Set @l_UserID = 0;
	set @o_ErrorMesg = '''';


	Select @l_VerCount= Count(VersionId) From VersionInfo Where VersionNo=@i_Version ;
	If @l_VerCount = 0
	Begin
		Update VersionInfo
		Set IsCurrent=0;
		-- Insert New Version Record
		INSERT INTO  VersionInfo(VersionNo,IsCurrent) Values(@i_Version,1);

		Select @l_varRec = Count(UserID) From Gen_User Where IsActive = 1 And Upper(UserName) = Upper(@i_UserName) AND Upper(Password )= upper(@i_Password) and CompId=@i_CompId;

		If @l_varRec = 0 
		Begin
			Select @l_varRec = Count(UserID) From Gen_User Where IsActive = 0 And Upper(UserName) = Upper(@i_UserName) AND Upper(Password )= upper(@i_Password)and CompId=@i_CompId  ;
			if @l_varRec=1
			Begin
				SET @l_ErrorNo = 104
			End
			Else
			Begin
				SET @l_ErrorNo = 101
				--Set @o_ErrorMesg = ''UserName Or Password Is Wrong'';	
			End
		End
		Else
		Begin
			Select 
				Gen_User.UserID,
				Gen_User.UserName,
				Gen_User.Name as DispName,
				@l_FYStartDate as StartDate,
				@l_FYEndDate as EndDate,
				Gen_User.CompId 
			From Gen_User
			Where
				Gen_User.IsActive=1 AND 
				Upper(Gen_User.UserName) = Upper(@i_UserName) AND 
				Upper(Gen_User.Password)= Upper(@i_Password)and Gen_User.CompId= @i_CompId   ; 
  
		End	
	End
	Else
	Begin
		Select @l_CurrentCount = Count(VersionId) From VersionInfo Where VersionNo = @i_Version And IsCurrent=1;
		If @l_CurrentCount > 0
		Begin
			Select @l_varRec = Count(UserID) From Gen_User Where IsActive = 1 And Upper(UserName) = Upper(@i_UserName) AND Upper(Password )= upper(@i_Password) and CompId=@i_CompId ;
			If @l_varRec = 0 
			Begin
				Select @l_varRec = Count(UserID) From Gen_User Where IsActive = 0 And Upper(UserName) = Upper(@i_UserName) AND Upper(Password )= upper(@i_Password) and CompId=@i_CompId ;
				if @l_varRec=1
				Begin
					SET @l_ErrorNo = 104
				End
				Else
				Begin
					SET @l_ErrorNo = 101
					--Set @o_ErrorMesg = ''UserName Or Password Is Wrong'';	
				End	
			End
			Else
			Begin
				Select 
					Gen_User.UserID,
					Gen_User.UserName,
					Gen_User.Name as DispName,
					@l_FYStartDate as StartDate,
					@l_FYEndDate as EndDate,
					Gen_User.CompId
				From Gen_User
				Where
					Gen_User.IsActive=1 AND 
					Upper(Gen_User.UserName) = Upper(@i_UserName) AND 
					Upper(Gen_User.Password)= Upper(@i_Password)and Gen_User.CompId= @i_CompId ; 
			 
			End
		End	
		Else
		Begin
			--Set @o_ErrorMesg=''Please Update Your Old Version '';
			SET @l_ErrorNo = 102
		End
	End
							
	SELECT @l_errMsg  = ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = @l_ErrorNo
	Set @o_ErrorMesg  = @l_errMsg 
	
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Lead_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Description:	List of Lead
-- =============================================
--select * from Lead
CREATE PROCEDURE [dbo].[usp_Lead_List]
--[usp_Lead_List]''1'',''1''
@i_CompId bigint,
@i_UserID bigint	
AS
--@i_UserID bigint	
BEGIN
    SET NOCOUNT ON;


if @i_UserID = 1

begin
   SELECT     Lead.LeadId, Lead.LeadNo, Lead.LeadNo + '' '' + Lead.CustomerName AS LeadName, Lead.LeadDate, Lead.CustomerName, Lead.ContactPerson, Lead.Phone1, Lead.MobileNo AS Mobile, 
                      Lead.Email, Lead.Specification, Lead.Category, Lead.SourceOfLead, Lead.Remarks, Lead.EmpID, Employee.EmpName, Lead.AllocatedToEmpID, Employee.EmpName AS EmpAllTo, Lead.Name1, 
                      Lead.Name2, Lead.Name3, Lead.Name4, Lead.Name5, Lead.Name6, Lead.Value1, Lead.Value2, Lead.Value3, Lead.Value4, Lead.Value5, Lead.Value6, Lead.CustomerBudget, 
                      Lead.InterestLevel AS LeadStatus, Lead.NextFollowUpDate, Gen_User.Name AS LeadBy, Lead.Inquiry_AutoResponse, Lead.CityID, Lead.CompId,Lead.AccountID
FROM         Lead left JOIN
                      LeadStatus ON LeadStatus.LeadStatusID = Lead.LeadStatusID left JOIN
                      Gen_User ON Gen_User.UserID = Lead.CreatedBy LEFT  JOIN
                      Employee ON Employee.EmpID = Lead.EmpID  AND Employee.EmpID= Lead.AllocatedToEmpID  where Lead.CompId=@i_CompId
    --LEFT JOIN
    --Employee ON Lead.AllocatedToEmpID = Employee.EmpID	
    ORDER BY Lead.LeadNo DESC, Lead.LeadDate;
END
else

SELECT     Lead.LeadId, Lead.LeadNo, Lead.LeadNo + '' '' + Lead.CustomerName AS LeadName, Lead.LeadDate, Lead.CustomerName, Lead.ContactPerson, Lead.Phone1, Lead.MobileNo AS Mobile, 
                      Lead.Email, Lead.Specification, Lead.Category, Lead.SourceOfLead, Lead.Remarks, Lead.EmpID, Employee.EmpName, Lead.AllocatedToEmpID, Employee.EmpName AS EmpAllTo, Lead.Name1, 
                      Lead.Name2, Lead.Name3, Lead.Name4, Lead.Name5, Lead.Name6, Lead.Value1, Lead.Value2, Lead.Value3, Lead.Value4, Lead.Value5, Lead.Value6, Lead.CustomerBudget, 
                      Lead.InterestLevel AS LeadStatus, Lead.NextFollowUpDate, Gen_User.Name AS LeadBy, Lead.Inquiry_AutoResponse, Lead.CityID, Lead.CompId
FROM         Lead left JOIN
                      LeadStatus ON LeadStatus.LeadStatusID = Lead.LeadStatusID left JOIN
                      Gen_User ON Gen_User.UserID = Lead.CreatedBy LEFT  JOIN
                      Employee ON Employee.EmpID = Lead.EmpID  AND Employee.EmpID= Lead.AllocatedToEmpID  where Lead.CompId=@i_CompId and  Lead.CreatedBy = @i_UserID
    --LEFT JOIN
    --Employee ON Lead.AllocatedToEmpID = Employee.EmpID	
    ORDER BY Lead.LeadNo DESC, Lead.LeadDate;

end




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TodaysLead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- =============================================
create PROCEDURE [dbo].[usp_TodaysLead]
	@i_UserID Bigint
AS
BEGIN
	SET NOCOUNT ON;

		SELECT  Lead.LeadId,
			Lead.LeadNo,
			LeadFollowUp.NextFollowupDate,
			Lead.CustomerName,
			LeadFollowUp.Remarks
		 FROM LeadFollowUp Inner Join Lead ON LeadFollowUp.LeadID = Lead.LeadID
			 
				Inner Join LeadStatus On LeadStatus.LeadStatusID=Lead.LeadStatusID
		Where Lead.CreatedBy = @i_UserID  
			 And convert(varchar, LeadFollowUp.NextFollowupDate,105)=convert(varchar,getdate(),105)

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_LeadStatus_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Sp is used for bind LeadStatus combo box.
-- =============================================
create PROCEDURE [dbo].[usp_LeadStatus_DDL]
	
AS
BEGIN
 
	SET NOCOUNT ON;

    Select 
		LeadStatusID,Status
	From 
		LeadStatus
	Order By 
		Status;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Lead_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Update record in Lead table
-- =============================================
CREATE PROCEDURE [dbo].[usp_Lead_Update]
	@i_LeadID bigint,
	@i_LeadDate datetime,	
	@i_CustomerName Varchar(150),
	@i_Address varchar(150),
	@i_CityID Bigint,
	@i_Pincode varchar(12),
	@i_Phone1 varchar(12),
	@i_MobileNo varchar(20),
	@i_Email varchar(50),
	@i_SourceOfLead varchar(50),
	@i_CustomerBudget decimal(18,0),
	@i_InterestLevel varchar(20),
	@i_NextFollowUpDate datetime,
	@i_Specification varchar(250),
	@i_Remarks varchar(MAX),
	@i_LeadStatusID bigint,
	@i_UserID bigint,
	--@i_Quotation_Send bit,
	@i_Website nvarchar(250),
	@i_AreaID int,
	@i_EmpID int,
	@i_ContactPerson nvarchar(50),
	@i_Name1 nvarchar(50),
	@i_Name2 nvarchar(50),
	@i_Name3 nvarchar(50),
	@i_Name4 nvarchar(50),
	@i_Name5 nvarchar(50),
	@i_Name6 nvarchar(50),
	@i_Value1 nvarchar(50),
	@i_Value2 nvarchar(50),
	@i_Value3 nvarchar(50),
	@i_Value4 nvarchar(50),
	@i_Value5 nvarchar(50),
	@i_Value6 nvarchar(50),
	@i_Category varchar(50),
	@i_AllocatedToEmpID int,
	@i_Inquiry_AutoResponse bit,
	@i_CompId bigint,
	@i_AccountID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
 
	UPDATE Lead
	   SET 
		  LeadDate = @i_LeadDate, 
		  CustomerName=  @i_CustomerName,
		  Address = @i_Address,
  		  CityID = @i_CityID,
		  Pincode = @i_Pincode,
		  Phone1 = @i_Phone1,
		  MobileNo = @i_MobileNo,
		  Email = @i_Email,
		  SourceOfLead = @i_SourceOfLead, 
		  CustomerBudget = @i_CustomerBudget,
		  InterestLevel = @i_InterestLevel, 
		  NextFollowUpDate = @i_NextFollowUpDate, 
		  Specification = @i_Specification, 
		  Remarks = @i_Remarks,
		  LeadStatusID = @i_LeadStatusID, 
		  ModifiedBy = @i_UserID,
		  ModifiedDate =  @l_Date,
		  --Quotation_Send=@i_Quotation_Send,
			ContactPerson=@i_ContactPerson,
		AreaID =@i_AreaID,
		EmpID=@i_EmpID, 
		Website=@i_Website,
		Name1=@i_Name1,
		Name2=@i_Name2,
		Name3=@i_Name3,
		Name4=@i_Name4,
		Name5=@i_Name5,
		Name6=@i_Name6,
		Value1=@i_Value1,
		Value2=@i_Value2,
		Value3=@i_Value3,
		Value4=@i_Value4,
		Value5=@i_Value5,
		Value6=@i_Value6,
		Category=@i_Category,
		AllocatedToEmpID=@i_AllocatedToEmpID,
		CompId=@i_CompId,
		AccountID=@i_AccountID,
		Inquiry_AutoResponse=@i_Inquiry_AutoResponse

	 WHERE LeadID = @i_LeadID

END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Lead_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Select Lead record
-- =============================================
--select * from Lead
CREATE PROCEDURE [dbo].[usp_Lead_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT LeadId,	
			LeadNo,
			LeadDate,
			CustomerName,
			Address,
			CityID,
			Pincode,
			Phone1,
			MobileNo,
			Email,
			Name1,
			Name2,
			Name3,
			Name4,
			Name5,
			Name6,
			Value1,
			Value2,
			Value3,
			Value4,
			Value5,
			Value6,
			SourceOfLead,	
			CustomerBudget,
			InterestLevel,
			NextFollowUpDate,
			Specification,
			Remarks,
			LeadStatusID,
			--Quotation_Send,
			ContactPerson,
			Website,
			AreaID,
			EmpID,
			AllocatedToEmpID,
			Category,
			AccountID,
			Inquiry_AutoResponse
	FROM Lead	 
	Where Lead.LeadID =  @i_RecID 

END








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Invoice_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Roshni Patel
-- Create date: 23rd Jan 2011
-- Description:	Get Purchase Invoice List
-- =============================================
CREATE PROCEDURE [dbo].[usp_Invoice_List]

@i_CompId bigint
AS
BEGIN
	SET NOCOUNT ON;

-- SELECT ''Lead'' As [Type],
--		Lead.LeadId AS InvoiceID,
--		Lead.LeadNo As Code,
--		Lead.NextFollowUpDate As Date,
--		Lead.CustomerName as Party,
--		Lead.ContactPerson,
--		Lead.Phone1,
--		Lead.Specification,
--		Lead.Remarks
----		'''' as DueDays,
----		'''' as DueDate,
----		'''' as NetAmount
--	  FROM Lead
--		Where Lead.NextFollowUpDate between GETDATE() and GETDATE()+2
--  or CONVERT(VARCHAR,Lead.NextFollowUpDate,103)= Convert(varchar,GETDATE(),103)
--

-----------------------------

 SELECT     ''Lead'' AS Type, LeadId AS InvoiceID, LeadNo AS Code, NextFollowUpDate AS Date, CustomerName AS Party, ContactPerson, Phone1, Specification, Remarks, CompId
FROM         Lead
		Where Lead.NextFollowUpDate between GETDATE() and GETDATE()+2
  or CONVERT(VARCHAR,Lead.NextFollowUpDate,103)= Convert(varchar,GETDATE(),103) and Lead.CompId=@i_CompId



END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CustomerReceipt_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 26th Jan 2011
-- Description:	Insert record of Receipt and Receipt Detail
-- =============================================
--select * from Customer
--select * from Lead
CREATE PROCEDURE [dbo].[usp_CustomerReceipt_Insert]
--custID=70
	@i_FYID Bigint,
	@i_ReceiptCode Varchar(20),
	@i_ReceiptDate DateTime,
	@i_CustomerID Bigint,
	@i_NetAmount Decimal(15,3),
	@i_Narration Varchar(250),
	@i_BankName	varchar(150),
	@i_ChequeNo	varchar(50),
	@i_ChequeDate Datetime= null,
	@i_XMLString xml,
	@i_Cnt Bigint,
	@i_CompId bigint,
	@i_UserID BIGINT,
	@i_AccountID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT

AS
BEGIN
 	SET NOCOUNT ON;

   -- Declare Local Variables...
	Declare @l_varRec Bigint;
	Declare @l_CustomerAccID Bigint
	Declare @l_LedNarration varchar(50)
	Declare @l_NewDetID Bigint
	Declare @l_NewID Bigint
	-- Set Local Variable value..
	Set @l_varRec = 0;
	Set @o_ErrorMesg='''';
	Set @l_NewID=0;	
	Set @l_CustomerAccID = 0
	Set @l_LedNarration =''''
	Set @l_NewDetID = 0
	
	-- Variable for StockDetail
	DECLARE @l_SIID Bigint;
	Declare @l_PaidAmount decimal(15,3)
DECLARE	@l_Date Datetime;

	SET @l_SIID = 0;
	Set @l_PaidAmount = 0.000;

SET @l_Date=Convert(Datetime,getDate(),5);
	
	 
--	BEGIN TRY  
--	BEGIN TRAN

--		SELECT @l_varRec = Count(ReceiptID) From Receipt Where ReceiptCode = @i_ReceiptCode
--		IF @l_varRec = 0
--			BEGIN

				Set @l_LedNarration  = ''Receipt Against '' + @i_ReceiptCode
			
	
				--Insert Record into Payment Table...
					Insert Into Receipt(ReceiptCode, ReceiptDate, CustomerID, Narration,NetAmount,BankName,ChequeNo,ChequeDate,CompId,CreatedBy,CreatedDate)
		     					Values(@i_ReceiptCode,@i_ReceiptDate,@i_CustomerID,@i_Narration,@i_NetAmount,@i_BankName,@i_ChequeNo,@i_ChequeDate,@i_CompId,@i_UserID,@l_Date)
					SET @l_NewID = Scope_Identity();		
		

					---Procedure For Insert Record into Sales Invoice Detail Table...
					While @i_Cnt>0
					BEGIN									
						SELECT  @l_SIID = x.d.value(''SIID[1]'',''Bigint'') ,
								@l_PaidAmount = x.d.value(''PaidAmount[1]'',''Decimal(15,3)'')															
						FROM @i_XMLString.nodes(''/NewDataSet/Table[position()=sql:variable("@i_Cnt")]'') x(d);

						--Statement For Insert Record into Purchase Invoice Detail Table
						Insert Into ReceiptDetail( ReceiptID,   SIID,    Amount)
									         Values(@l_NewID,@l_SIID,@l_PaidAmount)
						Set @l_NewDetID = Scope_Identity(); 
						 
						Update SalesInvoice 
						Set
							PaidAmount = PaidAmount + @l_PaidAmount
--							IsPaid=''True''
						Where SIID = @l_SIID;

						Set @i_Cnt = @i_Cnt - 1;
					END

--Select @l_CustomerAccID = AccountID From Customer Where CustomerID = @i_CustomerID
			Select @l_CustomerAccID = AccountID From Lead Where AccountID = @i_AccountID
			--Select AccountID From Lead Where AccountID = 19

					---Insert Record in Ledger
					Insert Into Ledger (  FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(@i_FYID,@l_CustomerAccID, 6,@l_NewID, @i_ReceiptDate ,0.000,@i_NetAmount ,@l_LedNarration );
		 
					---Insert Record in Ledger
					Insert Into Ledger (   FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values( @i_FYID,   1,       6,				     @l_NewID,         @i_ReceiptDate ,@i_NetAmount,0.00,@l_LedNarration);

			  END
--		  ELSE
--			  BEGIN
--				SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=21001 );
--			  END			
		
--	COMMIT TRAN
--	END TRY
--		BEGIN CATCH 
--			SET @ErrorNo = 100     
--		ROLLBACK TRAN  
--	END CATCH 	

--END










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CustomerReceipt_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 26th Jan 2011
-- Description:	Update record of Receipt and Receipt Detail
-- =============================================
CREATE PROCEDURE [dbo].[usp_CustomerReceipt_Update]
	@i_ReceiptID Bigint,
	@i_FYID Bigint,
	@i_ReceiptCode Varchar(20),
	@i_ReceiptDate DateTime,
	@i_CustomerID Bigint,
	@i_NetAmount Decimal(15,3),
	@i_Narration Varchar(250),
	@i_BankName	varchar(150),
	@i_ChequeNo	varchar(50),
	@i_ChequeDate Datetime= null,
	@i_XMLString xml,
	@i_Cnt Bigint,
	@i_CompId bigint,
	@i_UserID BIGINT,
	@i_AccountID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
 	SET NOCOUNT ON;

   -- Declare Local Variables...
	Declare @l_varRec Bigint;
	Declare @l_CustomerAccID Bigint
	Declare @l_LedNarration varchar(50)
	Declare @l_NewDetID Bigint

	-- Set Local Variable value..
	Set @l_varRec = 0;
	Set @o_ErrorMesg='''';
	Set @l_CustomerAccID = 0
	Set @l_LedNarration =''''
	Set @l_NewDetID = 0
	
	-- Variable for StockDetail
	DECLARE @l_SIID Bigint;
	Declare @l_PaidAmount decimal(15,3)
	DECLARE	@l_Date Datetime;

	SET @l_SIID = 0;
	Set @l_PaidAmount = 0.000



SET @l_Date=Convert(Datetime,getDate(),5);

	 
--	BEGIN TRY  
--	BEGIN TRAN

		SELECT @l_varRec = Count(ReceiptID) From Receipt Where ReceiptCode = @i_ReceiptCode And ReceiptID <> @i_ReceiptID
		IF @l_varRec = 0
			BEGIN

				Set @l_LedNarration  = ''Payment Against '' + @i_ReceiptCode
	
				--Insert Record into Payment Table...
					Update Receipt
					Set ReceiptDate = @i_ReceiptDate, 
						Narration = @i_Narration,
						NetAmount = @i_NetAmount,
						BankName=@i_BankName,ChequeNo=@i_ChequeNo,
						ChequeDate=@i_ChequeDate,
						CompId=@i_CompId,
						ModifiedBy = @i_UserID,
						ModifiedDate = @l_Date
					Where ReceiptID = @i_ReceiptID and CompId=@i_CompId
			
					Delete From Ledger Where TransactionTypeID = 6 And TransactionID = @i_ReceiptID
					Update SalesInvoice 
					Set
						SalesInvoice.PaidAmount = SalesInvoice.PaidAmount - ReceiptDetail.Amount,
						IsPaid=''False''
					From ReceiptDetail
					Where ReceiptDetail.SIID = SalesInvoice.SIID And 
						ReceiptDetail.ReceiptID = @i_ReceiptID
							
				
					Delete From ReceiptDetail Where ReceiptID = @i_ReceiptID;					
					Set @l_CustomerAccID = 0
					--Select @l_CustomerAccID = AccountID From Customer Where CustomerID = @i_CustomerID
					Select @l_CustomerAccID = AccountID From Lead Where AccountID = @i_AccountID
					---Insert Record in Ledger
					If @l_CustomerAccID > 0	
					Begin
						Insert Into Ledger (  FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
									Values(@i_FYID,@l_CustomerAccID, 6,				     @i_ReceiptID, @i_ReceiptDate ,@i_NetAmount,0.000,@l_LedNarration );
					End
					---Insert Record in Ledger
					Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(@i_FYID,    1,       6,				     @i_ReceiptID,         @i_ReceiptDate ,@i_NetAmount,0.00,@l_LedNarration);


					While @i_Cnt>0
					BEGIN
						Set @l_SIID = 0									
						SELECT  @l_SIID = x.d.value(''SIID[1]'',''Bigint'') ,
								@l_PaidAmount = x.d.value(''PaidAmount[1]'',''Decimal(15,3)'')								
						FROM @i_XMLString.nodes(''/NewDataSet/Table[position()=sql:variable("@i_Cnt")]'') x(d);

						--Statement For Insert Record into Purchase Invoice Detail Table
						Insert Into ReceiptDetail( ReceiptID,   SIID,    Amount)
									         Values(@i_ReceiptID,@l_SIID,@l_PaidAmount)
						Set @l_NewDetID = Scope_Identity(); 
						 
						Update SalesInvoice 
						Set
							PaidAmount = PaidAmount + @l_PaidAmount
						Where SIID = @l_SIID;

						Set @i_Cnt = @i_Cnt - 1;
					END
			  END
		  ELSE
			  BEGIN
						SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=21001 );
			  END					
--	COMMIT TRAN
--	END TRY
--		BEGIN CATCH 
--			SET @ErrorNo = 100     
--		ROLLBACK TRAN  
--	END CATCH 	

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Lead_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Insert record in Lead Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_Lead_Insert]
	@i_LeadNo varchar(20),
	@i_LeadDate datetime,
	@i_CustomerName Varchar(150),
	@i_Address varchar(150),
	@i_CityID Bigint,
	@i_Pincode varchar(12),
	@i_MobileNo varchar(20),
	@i_Email varchar(50),
	@i_Phone1 varchar(12),
	@i_SourceOfLead varchar(50),
	@i_CustomerBudget decimal(18,0),
	@i_InterestLevel varchar(20),
	@i_NextFollowUpDate datetime,
	@i_Specification varchar(250),
	@i_Remarks varchar(MAX),
	@i_LeadStatusID bigint,
	@i_UserID bigint,
	--@i_Quotation_Send bit,
	@i_ContactPerson nvarchar(250),
	@i_AreaID int,
	@i_EmpID int,
	@i_Website nvarchar(50),
	@i_Name1 nvarchar(50),
	@i_Name2 nvarchar(50),
	@i_Name3 nvarchar(50),
	@i_Name4 nvarchar(50),
	@i_Name5 nvarchar(50),
	@i_Name6 nvarchar(50),
	@i_Value1 nvarchar(50),
	@i_Value2 nvarchar(50),
	@i_Value3 nvarchar(50),
	@i_Value4 nvarchar(50),
	@i_Value5 nvarchar(50),
	@i_Value6 nvarchar(50),
	@i_Category varchar(50),
	@i_AllocatedToEmpID int,
	@i_Inquiry_AutoResponse bit,
	@i_CompId bigint,
	@i_AccountID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
--	SELECT @l_varRec = Count(LeadID) FROM Lead WHERE Upper(LeadNo) = Upper(@i_LeadNo);
--	IF @l_varRec=0
--		BEGIN 
			INSERT INTO Lead( LeadNo,   LeadDate,   CustomerName,   Address,   CityID,   Pincode,   Phone1,    MobileNo,   Email,Name1,Name2,Name3,Name4,Name5,Name6,Value1,Value2,Value3,Value4,Value5,Value6,SourceOfLead,   CustomerBudget,   InterestLevel,   NextFollowUpDate,   Specification,   Remarks,   LeadStatusID,CreatedBy,CreatedDate , ContactPerson ,AreaID ,EmpID, Website,Category,AllocatedToEmpID,Inquiry_AutoResponse,CompId,AccountID)
					VALUES(@i_LeadNo,@i_LeadDate,@i_CustomerName,@i_Address,@i_CityID,@i_Pincode,@i_Phone1,@i_MobileNo,@i_Email,@i_Name1,@i_Name2,@i_Name3,@i_Name4,@i_Name5,@i_Name6,@i_Value1,@i_Value2,@i_Value3,@i_Value4,@i_Value5,@i_Value6,@i_SourceOfLead,@i_CustomerBudget,@i_InterestLevel,@i_NextFollowUpDate,@i_Specification,@i_Remarks,@i_LeadStatusID,@i_UserID,@l_Date  , @i_ContactPerson , @i_AreaID , @i_EmpID , @i_Website,@i_Category,@i_AllocatedToEmpID,@i_Inquiry_AutoResponse,@i_CompId,@i_AccountID)
--		END
--	ELSE
--		BEGIN
--			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 14001 );
--		END

END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CustomerFollowUp_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Insert record in LeadFollowUp Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_CustomerFollowUp_Insert]
	@i_LeadID Bigint,
	@i_NextFollowupDate DateTime,	
	@i_Remarks Varchar(250),
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
		
	Update Lead set NextFollowUpDate =@i_NextFollowupDate, LeadStatusID=2,Remarks=@i_Remarks where LeadID = @i_LeadID;

	INSERT INTO CustomerFollowUp(LeadID,NextFollowupDate,FollowupBy,Remarks,CreatedBy,CreatedDate)
	VALUES(@i_LeadID,@i_NextFollowupDate,@i_UserID,@i_Remarks,@i_UserID,@l_Date)

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CustomerFollowUp_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Description:	List of Lead
-- =============================================
--select * from Lead
CREATE PROCEDURE [dbo].[usp_CustomerFollowUp_List]
--[usp_CustomerFollowup_List]''1'',''1''
@i_CompId bigint,
@i_UserID bigint	
AS
--@i_UserID bigint	
BEGIN
    SET NOCOUNT ON;


declare @LeadID as int
declare @LeadNo as varchar(50)
declare @LeadDate as datetime
declare @NextFollowUpDate as datetime
declare @CustomerName as varchar(50)
declare @ContactPerson as varchar(50)
declare @Phone as varchar(50)
declare @Mobile as varchar(50)
declare @Email as varchar(50)
declare @cnt as int;
set @cnt=0;

if @i_UserID = 1

begin

if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = ''#temp3'')
    drop table #temp3;

create table #temp3(LeadId int,LeadNo varchar(50),LeadDate datetime,NextFollowUpDate datetime,CustomerName varchar(50),ContactPerson varchar(50),Email varchar(50),Mobile varchar(50),Phone varchar(50))
---------------------------------------------

  ----------------------cursor starts------------

DECLARE @getSaleLeadID CURSOR
	SET @getSaleLeadID = CURSOR FOR	

	SELECT DISTINCT SalesInvoice.CustomerID
FROM         SalesInvoice LEFT OUTER JOIN
                      Lead ON Lead.LeadId = SalesInvoice.CustomerID where  Lead.CustomerName is not null and  Lead.CompId=@i_CompId
OPEN @getSaleLeadID
FETCH NEXT 
FROM @getSaleLeadID into @LeadID
	WHILE @@FETCH_STATUS = 0
		BEGIN
		
		-------------code to do
--set @cnt=@cnt+1;
--print @cnt

			--select * from Lead where LeadID=@LeadID

			select @LeadID=LeadId,
					@LeadNo=LeadNo,
					@LeadDate=LeadDate,
					@NextFollowUpDate=NextFollowUpDate,
					@CustomerName=CustomerName,
					@ContactPerson=ContactPerson,
					@Phone=Phone1, 
                      @Mobile=MobileNo,
					@Email=Email
			 from Lead where LeadID=@LeadID
			--select * from 
insert into #temp3 values(@LeadID,@LeadNo,@LeadDate,@NextFollowUpDate,@CustomerName,@ContactPerson,@Email,@Mobile,@Phone)
			FETCH NEXT
			FROM @getSaleLeadID INTO @LeadID
		END
select * from #temp3
CLOSE @getSaleLeadID
DEALLOCATE @getSaleLeadID
----------------------cursor ends------------
END


--else
if @i_UserID != 1
begin
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = ''#temp4'')
    drop table #temp4;

create table #temp4(LeadId int,LeadNo varchar(50),LeadDate datetime,NextFollowUpDate datetime,CustomerName varchar(50),ContactPerson varchar(50),Email varchar(50),Mobile varchar(50),Phone varchar(50))
---------------------------------------------

----------------------cursor starts------------

DECLARE @getSaleLeadUID CURSOR
	SET @getSaleLeadUID = CURSOR FOR	

	SELECT DISTINCT SalesInvoice.CustomerID
FROM         SalesInvoice LEFT OUTER JOIN
                      Lead ON Lead.LeadId = SalesInvoice.CustomerID where  Lead.CustomerName is not null and  Lead.CompId=@i_CompId and  Lead.CreatedBy = @i_UserID
OPEN @getSaleLeadUID
FETCH NEXT 
FROM @getSaleLeadUID into @LeadID
	WHILE @@FETCH_STATUS = 0
		BEGIN
		
		-------------code to do
--set @cnt=@cnt+1;
--print @cnt

			--select * from Lead where LeadID=@LeadID

			select @LeadID=LeadId,
					@LeadNo=LeadNo,
					@LeadDate=LeadDate,
					@NextFollowUpDate=NextFollowUpDate,
					@CustomerName=CustomerName,
					@ContactPerson=ContactPerson,
					@Phone=Phone1, 
                      @Mobile=MobileNo,
					@Email=Email
			 from Lead where LeadID=@LeadID
			--select * from 
insert into #temp4 values(@LeadID,@LeadNo,@LeadDate,@NextFollowUpDate,@CustomerName,@ContactPerson,@Email,@Mobile,@Phone)
			FETCH NEXT
			FROM @getSaleLeadUID INTO @LeadID
		END
select * from #temp4
CLOSE @getSaleLeadUID
DEALLOCATE @getSaleLeadUID
----------------------cursor ends------------
end
end



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PromoMailLead_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Description:	List of PromoMail
-- =============================================
CREATE PROCEDURE [dbo].[usp_PromoMailLead_List]
	--@i_UserID bigint
@i_CompId bigint	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT LeadId, CustomerName,Phone1 as Mobile,Email,Category,CompId
FROM  Lead where CompId=@i_CompId
END










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CustomerReceipt_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 26th Jan 2011
-- Description:	Get Receipt List
-- =============================================
--select * from dbo.ReceiptDetail
CREATE PROCEDURE [dbo].[usp_CustomerReceipt_List]
@i_CompId bigint,
@i_UserID bigint	
AS
BEGIN
	SET NOCOUNT ON;
--	SELECT Receipt.ReceiptID, 
--Receipt.ReceiptCode, 
--Receipt.ReceiptDate, 
--Receipt.CustomerID,
--Receipt.NetAmount, 
--Receipt.Narration, 
--Lead.CustomerName, 
--Lead.LeadNo as CustomerCode,
--SalesInvoice.NetAmount, 
--IsNull(SalesInvoice.PaidAmount,0.00) as PaidAmount, 
--(SalesInvoice.NetAmount - SalesInvoice.PaidAmount) As PendingAmount ,
--SalesInvoice.SIID,
--SalesInvoice.DueDays, 
--SalesInvoice.DueDate,
--SalesInvoice.SalesCode, 
--SalesInvoice.SalesDate
--FROM         Receipt LEFT JOIN
--                      Lead ON Lead.LeadId = Receipt.CustomerID
--Left Join SalesInvoice on SalesInvoice.CustomerId= Lead.LeadId
--ORDER BY Receipt.ReceiptDate, Receipt.ReceiptCode DESC
---------------------
SELECT     Receipt.ReceiptID, Receipt.ReceiptCode, Receipt.ReceiptDate, Receipt.CustomerID, Receipt.NetAmount AS RNetAmount, Receipt.Narration, Lead.CustomerName, Lead.LeadNo AS CustomerCode, 
                      SalesInvoice.NetAmount, ISNULL(SalesInvoice.PaidAmount, 0.00) AS PaidAmount, SalesInvoice.NetAmount - SalesInvoice.PaidAmount AS PendingAmount, SalesInvoice.SIID, SalesInvoice.DueDays, 
                      SalesInvoice.DueDate, SalesInvoice.SalesCode, SalesInvoice.SalesDate, Receipt.CompId
FROM         Receipt INNER JOIN
                      ReceiptDetail ON Receipt.ReceiptID = ReceiptDetail.ReceiptID LEFT JOIN
                      SalesInvoice ON SalesInvoice.SIID = ReceiptDetail.SIID LEFT JOIN
                      Lead ON Lead.LeadId = Receipt.CustomerID AND SalesInvoice.CustomerID = Lead.LeadId
WHERE Receipt.ReceiptCode is not null and Receipt.CompId=@i_CompId and Receipt.CreatedBy = @i_UserID
ORDER BY Receipt.ReceiptDate, Receipt.ReceiptCode DESC

END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Customer_ReceiptPendingList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:        Manoj Savalia
-- Create date: 03-06-2010
-- Description:    Get Customer Payment List
-- =============================================
CREATE PROCEDURE [dbo].[usp_Customer_ReceiptPendingList]
    
@i_CompId bigint

AS
BEGIN
    SET NOCOUNT ON;

SELECT     SalesInvoice.SalesCode, SalesInvoice.NetAmount - SalesInvoice.PaidAmount AS PendingAmount, SalesInvoice.NetAmount, SalesInvoice.PaidAmount, Lead.LeadNo AS CustomerCode, 
                      Lead.CustomerName, Lead.Phone1 AS Mobile, Lead.Email, Lead.ContactPerson, SalesInvoice.SalesDate + SalesInvoice.DueDays AS DueDate, SalesInvoice.RecDay, SalesInvoice.DueDays, 
                      SalesInvoice.CompId
FROM         SalesInvoice INNER JOIN
                      Lead ON SalesInvoice.CustomerID = Lead.LeadId
WHERE     (SalesInvoice.NetAmount > SalesInvoice.PaidAmount) and SalesInvoice.CompId=@i_CompId
ORDER BY SalesInvoice.CustomerID, SalesInvoice.SalesDate, SalesInvoice.SalesCode

END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Indent_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	Insert record of Purchase Invoice and Purchase Invoice Detail
-- =============================================

CREATE PROCEDURE [dbo].[usp_Indent_Insert]
	@i_PurchaseCode Varchar(20),
	@i_FYID Bigint,
	@i_PurchaseDate DateTime,
	@i_SrNo Varchar(50),
	@i_VoucherNo Varchar(20),
	@i_VoucherDate DATETIME,
	@i_VendorID Bigint,
	@i_GodownID int,
	@i_DueDays Bigint,
	@i_DueDate DateTime,
	@i_TotalAmount Decimal(18,2),
	@i_ServiceAmount  Decimal(18,2),
	@i_ExciseAmount  Decimal(18,2),	
	@i_CessAmount Decimal(18,2),
	@i_HCessAmount Decimal(18,2),
	@i_AmountAfterExcise Decimal(18,2),
	@i_CSTAmount Decimal(18,2),
	@i_VATAmount Decimal(18,2),
	@i_AVATAmount Decimal(18,2),
	@i_Discount  Decimal(18,2),
	@i_NetAmount  Decimal(18,2),
	@i_PaidAmount  Decimal(18,2),
	@i_Narration Varchar(250),
	@i_XMLString xml,
	@i_Cnt Bigint,
    @i_PGID bigint,
	@i_UserID BIGINT,
	@i_AgainstCForm bit,
	@o_ErrorMesg Varchar(200) OUTPUT

AS
BEGIN
 	SET NOCOUNT ON;

   -- Declare Local Variables...
	DECLARE @l_varRec Bigint;
 	DECLARE @l_VendorAccID Bigint
	DECLARE @l_LedNarration varchar(50)
	DECLARE @l_StockID Bigint
	DECLARE @l_NewDetID Bigint
	DECLARE @l_NewID BIGINT
	DECLARE @l_Description varchar(100);
	-- Set Local Variable value..
	SET @l_varRec = 0;
	SET @l_Description  = ''''
	SET @l_VendorAccID = 0
	SET @l_LedNarration =''''
	SET @l_StockID = 0
	SET @l_NewDetID = 0
	-- Variable for StockDetail
 
	SET @o_ErrorMesg='''';
	SET @l_NewID = 0
 


	BEGIN TRY  
	BEGIN TRAN
 
 	SELECT @l_varRec = Count(PIID) From Indent Where PurchaseCode = @i_PurchaseCode
 		IF @l_varRec = 0
 			BEGIN
 				Set @l_LedNarration  = ''Purchase Against '' + @i_PurchaseCode
 	
 				--Insert Record into Purchase invoice Table...
 				Insert Into Indent(  FYID,   PurchaseCode,   PurchaseDate,   SrNo ,  VoucherNo ,   VoucherDate,   VendorID ,    DueDays,    DueDate,    TotalAmount,ServiceAmount,   ExciseAmount ,   CessAmount,   HCessAmount,   AmountAfterExcise ,   CSTAmount,   VATAmount,   AVATAmount  ,    Discount,    NetAmount,    Narration,   PaidAmount , GodownID,PGID,AgainstCForm)
 		     						Values(@i_FYID,@i_PurchaseCode,@i_PurchaseDate,@i_SrNo,@i_VoucherNo ,@i_VoucherDate,@i_VendorID , @i_DueDays, @i_DueDate, @i_TotalAmount,@i_ServiceAmount,@i_ExciseAmount ,@i_CessAmount,@i_HCessAmount,@i_AmountAfterExcise ,@i_CSTAmount,@i_VATAmount,@i_AVATAmount  , @i_Discount,@i_NetAmount, @i_Narration,@i_PaidAmount , @i_GodownID,@i_PGID,@i_AgainstCForm)
				SET @l_NewID = Scope_Identity();

 				-- Vendor''s Ledger Effect
				Select @l_VendorAccID = AccountID From Vendor Where VendorID = @i_VendorID
				---Insert Record in Ledger
				Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
							Values(@l_VendorAccID,@i_FYID, 2,				   @l_NewID, @i_PurchaseDate,0.000,@i_NetAmount,@l_LedNarration );

				Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
							Values(@l_VendorAccID,@i_FYID, 2,				   @l_NewID, @i_PurchaseDate,@i_PaidAmount,0.000,@l_LedNarration );
				-- Insert Record for Service Tax Amount
				If @i_ServiceAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(10,    @i_FYID,       2,				     @l_NewID,   @i_PurchaseDate,0.00,@i_ServiceAmount,@l_LedNarration);
				End
				-- Insert Record for Basic Excise Amount
				If @i_ExciseAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(2,         @i_FYID,  2,				     @l_NewID,   @i_PurchaseDate,@i_ExciseAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for Cess On Excise Amount
				If @i_CessAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(3,        @i_FYID,   2,				     @l_NewID,   @i_PurchaseDate,@i_CessAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for H Cess On Excise Amount
				If @i_HCessAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(4,         @i_FYID,  2,				     @l_NewID,   @i_PurchaseDate,@i_HCessAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for CST On Excise Amount
				If @i_CSTAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(5,        @i_FYID,   2,				     @l_NewID,   @i_PurchaseDate,@i_CSTAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for VAT On Excise Amount
				If @i_VATAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(6,        @i_FYID,   2,				     @l_NewID,   @i_PurchaseDate,@i_VATAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for AVAT On Excise Amount
				If @i_AVATAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(7,        @i_FYID,   2,				     @l_NewID,   @i_PurchaseDate,@i_AVATAmount,0.00,@l_LedNarration);
				End


			---Insert Record in Ledger For Cash
				Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
							Values(	1,		@i_FYID,	2,				     @l_NewID,   @i_PurchaseDate,0.00,@i_PaidAmount,@l_LedNarration);

 
				---Procedure For Insert Record into Purchase Invoice Detail Table...
				IF @i_Cnt > 0
				BEGIN		
					SELECT  x.d.value(''ItemID[1]'',''Bigint'') AS ItemID,							
						x.d.value(''Qty[1]'',''Decimal(18,3)'') AS Qty,
						x.d.value(''Rate[1]'',''Decimal(18,2)'') AS Rate,
						x.d.value(''Amount[1]'',''Decimal(18,2)'') AS Amount,
						x.d.value(''TaxClassID[1]'',''Bigint'') AS TaxClassID,
						x.d.value(''ServiceAmount[1]'',''Decimal(18,2)'') AS ServiceAmount,
						x.d.value(''ServiceRate[1]'',''Decimal(5,2)'') AS ServiceRate,	
						x.d.value(''ExciseRate[1]'',''Decimal(5,2)'') AS ExciseRate,						
						x.d.value(''ExciseAmount[1]'',''Decimal(18,2)'') AS ExciseAmount,
						x.d.value(''EduCessRate[1]'',''Decimal(5,2)'') AS EduCessRate,						
						x.d.value(''EduCessAmount[1]'',''Decimal(18,2)'') AS EduCessAmount,
						x.d.value(''HEduCessRate[1]'',''Decimal(5,2)'') AS HEduCessRate,						
						x.d.value(''HEduCessAmount[1]'',''Decimal(18,2)'') AS HEduCessAmount,
						x.d.value(''AmountAfterExcise[1]'',''Decimal(18,2)'') AS AmountAfterExcise,						
						x.d.value(''CSTRate[1]'',''Decimal(5,2)'') AS CSTRate,
						x.d.value(''CSTAmount[1]'',''Decimal(18,2)'') AS CSTAmount,
						x.d.value(''VATRate[1]'',''Decimal(5,2)'') AS VATRate,	
						x.d.value(''VATAmount[1]'',''Decimal(18,2)'') AS VATAmount,
						x.d.value(''AVATRate[1]'',''Decimal(5,2)'') AS AVATRate,
						x.d.value(''AVATAmount[1]'',''Decimal(18,2)'') AS AVATAmount,
						x.d.value(''NetAmount[1]'',''Decimal(18,2)'') AS NetAmount,
						x.d.value(''RemainingQty[1]'',''Decimal(18,3)'') AS RemainingQty,
						x.d.value(''ReceivedQty[1]'',''Decimal(18,3)'') AS ReceivedQty,
                        x.d.value(''DDate[1]'',''datetime'') AS DDate	
					INTO #tmpDetail				
					FROM 
						@i_XMLString.nodes(''/NewDataSet/Table'') x(d);

					INSERT INTO IndentDetail (PIID,   ItemID,   Qty,   Rate,  Amount,   TaxClassID,  ServiceRate,  ServiceAmount,   ExciseRate,   ExciseAmount,   CessRate,   CessAmount,   HCessRate,   HCessAmount,   AmountAfterExcise,   CSTRate,   CSTAmount,   VATRate,   VATAmount,   AVATRate,   AVATAmount,   NetAmount,RemainingQty,ReceivedQty,DDate)
											SELECT @l_NewID,T1.ItemID,T1.Qty,T1.Rate,T1.Amount,T1.TaxClassID,T1.ServiceRate,T1.ServiceAmount,T1.ExciseRate,T1.ExciseAmount,T1.EduCessRate,T1.EduCessAmount,T1.HEduCessRate,T1.HEduCessAmount,T1.AmountAfterExcise,T1.CSTRate,T1.CSTAmount,T1.VATRate,T1.VATAmount,T1.AVATRate,T1.AVATAmount,T1.NetAmount,T1.RemainingQty,T1.ReceivedQty,T1.DDate FROM #tmpDetail T1 

				SET @l_Description = ''Against Purchase Invoice : '' + @i_PurchaseCode; 
				Insert Into ItemStock(FYID,      ItemID,    QOH, MinLevel, MaxLevel, ReorderLvl, CreatedBy, CreatedDate , GodownID)
 							Select @i_FYID,#tmpDetail.ItemID, 0, 0, 0, 0, @i_UserID, @i_PurchaseDate , @i_GodownID
							From #tmpDetail Where #tmpDetail.ItemID Not In(
								Select ItemStock.ItemID From ItemStock WHERE ItemStock.FYID = @i_FYID)
				
				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
					Select ItemStock.StockID, 100,ItemStock.StockID, @i_PurchaseDate, ''Opening Stock'',0.000
						From #tmpDetail 
							Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
							Where ItemStock.QOH = 0 And ItemStock.FYID = @i_FYID
								And ItemStock.StockID Not In (Select StockID from ItemStockDetail Where 
									ItemStockDetail.StockID = ItemStock.StockID And ItemStockDetail.GTID=100)

				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
						Select ItemStock.StockID, 200,@l_NewID, @i_PurchaseDate, @l_Description,  #tmpDetail.ReceivedQty
							From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
							Where ItemStock.FYID = @i_FYID
		 				
				-- Update Stock
				Update ItemStock 
					Set ItemStock.QOH = ItemStock.QOH +
						(Select Sum(#tmpDetail.ReceivedQty) From #tmpDetail Where ItemStock.ItemID = #tmpDetail.ItemID )
				From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
				Where 
					ItemStock.FYID = @i_FYID
-- and GodownID=@i_GodownID
 
 				END
			  END
		  ELSE
			  BEGIN
					SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 23001 );
			  END			
		
	COMMIT TRAN
	END TRY
		BEGIN CATCH 
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );  
		ROLLBACK TRAN  
	END CATCH 	

END










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SContactDetail_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record into Contact table
-- =============================================
create PROCEDURE [dbo].[usp_SContactDetail_Insert]
	@i_Code nvarchar(50),
	@i_RefID bigint,
	@i_ContactType tinyint,	
	@i_ContactData Xml,
	@i_Cnt Bigint,
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN	
	SET NOCOUNT ON;

    -- Declare Local Variable	
	DECLARE	@l_Date Datetime;
	Declare @l_ContactID bigint;
	Declare @l_ContactTitle varchar(10);
	Declare @l_ContactName varchar(50);
	Declare @l_Designation varchar(50);
	Declare @l_Phone1 varchar(20);
	Declare @l_Phone2 varchar(20);
	Declare @l_Mobile varchar(20);
	Declare @l_Email varchar(50);
	Declare @l_DOB datetime;
	Declare @l_DOA datetime;
	Declare @l_tmpCnt Bigint;

	-- Set Local Variable
	SET @o_ErrorMesg='''';
	Set @l_tmpCnt = 1;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	BEGIN TRY  
	BEGIN TRAN

		-- Delete Old record
--		DELETE FROM Quotation_Contact WHERE ContactType = @i_ContactType AND RefID = @i_RefID and Code=@i_Code;

		-- Insert record into Contact Table
		While @i_Cnt >= @l_tmpCnt
		Begin		
			
			SELECT  
					@l_ContactID = x.d.value(''ContactID[1]'',''bigint''),
					@l_ContactTitle = x.d.value(''ContactTitle[1]'',''varchar(10)''),
					@l_ContactName = x.d.value(''ContactName[1]'',''varchar(50)''),
					@l_Designation = x.d.value(''Designation[1]'',''varchar(50)''),
					@l_Phone1 = x.d.value(''Phone1[1]'',''varchar(20)''),
					@l_Phone2 = x.d.value(''Phone2[1]'',''varchar(20)''),
					@l_Mobile = x.d.value(''Mobile[1]'',''varchar(20)''),
					@l_Email = x.d.value(''Email[1]'',''varchar(50)''),
					@l_DOB = x.d.value(''DOB[1]'',''datetime''),
					@l_DOA = x.d.value(''DOA[1]'',''datetime'')
						
			FROM @i_ContactData.nodes(''/NewDataSet/Table[position()=sql:variable("@l_tmpCnt")]'') x(d);

			IF @l_DOB = '''' 
			Begin
				SET @l_DOB = NULL;
			End

			IF @l_DOA = '''' 
			Begin
				SET @l_DOA = NULL;
			End
	
			INSERT INTO Sale_Contact(   ContactID,Code,ContactType,   RefID,   ContactTitle,   ContactName,   Designation,   Phone1,   Phone2,   Mobile,   Email,   DOB,   DOA)
							VALUES	(@l_ContactID,@i_Code,@i_ContactType,@i_RefID,@l_ContactTitle,@l_ContactName,@l_Designation,@l_Phone1,@l_Phone2,@l_Mobile,@l_Email,@l_DOB,@l_DOA);								

			Set @l_tmpCnt = @l_tmpCnt + 1;

		End		

		
	COMMIT TRAN
	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
	ROLLBACK TRAN  
	END CATCH 

END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SEContactDetail_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record into Contact table
-- =============================================
create PROCEDURE [dbo].[usp_SEContactDetail_Insert]
	@i_Code nvarchar(50),
	@i_RefID bigint,
	@i_ContactType tinyint,	
	@i_ContactData Xml,
	@i_Cnt Bigint,
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN	
	SET NOCOUNT ON;

    -- Declare Local Variable	
	DECLARE	@l_Date Datetime;
	Declare @l_ContactID bigint;
	Declare @l_ContactTitle varchar(10);
	Declare @l_ContactName varchar(50);
	Declare @l_Designation varchar(50);
	Declare @l_Phone1 varchar(20);
	Declare @l_Phone2 varchar(20);
	Declare @l_Mobile varchar(20);
	Declare @l_Email varchar(50);
	Declare @l_DOB datetime;
	Declare @l_DOA datetime;
	Declare @l_tmpCnt Bigint;

	-- Set Local Variable
	SET @o_ErrorMesg='''';
	Set @l_tmpCnt = 1;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	BEGIN TRY  
	BEGIN TRAN

		-- Delete Old record
--		DELETE FROM Quotation_Contact WHERE ContactType = @i_ContactType AND RefID = @i_RefID and Code=@i_Code;

		-- Insert record into Contact Table
		While @i_Cnt >= @l_tmpCnt
		Begin		
			
			SELECT  
					@l_ContactID = x.d.value(''ContactID[1]'',''bigint''),
					@l_ContactTitle = x.d.value(''ContactTitle[1]'',''varchar(10)''),
					@l_ContactName = x.d.value(''ContactName[1]'',''varchar(50)''),
					@l_Designation = x.d.value(''Designation[1]'',''varchar(50)''),
					@l_Phone1 = x.d.value(''Phone1[1]'',''varchar(20)''),
					@l_Phone2 = x.d.value(''Phone2[1]'',''varchar(20)''),
					@l_Mobile = x.d.value(''Mobile[1]'',''varchar(20)''),
					@l_Email = x.d.value(''Email[1]'',''varchar(50)''),
					@l_DOB = x.d.value(''DOB[1]'',''datetime''),
					@l_DOA = x.d.value(''DOA[1]'',''datetime'')
						
			FROM @i_ContactData.nodes(''/NewDataSet/Table[position()=sql:variable("@l_tmpCnt")]'') x(d);

			IF @l_DOB = '''' 
			Begin
				SET @l_DOB = NULL;
			End

			IF @l_DOA = '''' 
			Begin
				SET @l_DOA = NULL;
			End
	
			INSERT INTO Service_Contact(   ContactID,Code,ContactType,   RefID,   ContactTitle,   ContactName,   Designation,   Phone1,   Phone2,   Mobile,   Email,   DOB,   DOA)
							VALUES	(@l_ContactID,@i_Code,@i_ContactType,@i_RefID,@l_ContactTitle,@l_ContactName,@l_Designation,@l_Phone1,@l_Phone2,@l_Mobile,@l_Email,@l_DOB,@l_DOA);								

			Set @l_tmpCnt = @l_tmpCnt + 1;

		End		

		
	COMMIT TRAN
	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
	ROLLBACK TRAN  
	END CATCH 

END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SContactDetail_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record into Contact table
-- =============================================
create PROCEDURE [dbo].[usp_SContactDetail_Update]
	@i_Code nvarchar(50),
	@i_RefID bigint,
	@i_ContactType tinyint,	
	@i_ContactData Xml,
	@i_Cnt Bigint,
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN	
	SET NOCOUNT ON;

    -- Declare Local Variable	
	DECLARE	@l_Date Datetime;
	Declare @l_ContactID bigint;
	Declare @l_ContactTitle varchar(10);
	Declare @l_ContactName varchar(50);
	Declare @l_Designation varchar(50);
	Declare @l_Phone1 varchar(20);
	Declare @l_Phone2 varchar(20);
	Declare @l_Mobile varchar(20);
	Declare @l_Email varchar(50);
	Declare @l_DOB datetime;
	Declare @l_DOA datetime;
	Declare @l_tmpCnt Bigint;

	-- Set Local Variable
	SET @o_ErrorMesg='''';
	Set @l_tmpCnt = 1;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	BEGIN TRY  
	BEGIN TRAN

		-- Delete Old record
		DELETE FROM Sale_Contact WHERE ContactType = @i_ContactType AND RefID = @i_RefID and Code=@i_Code;

		-- Insert record into Contact Table
		While @i_Cnt >= @l_tmpCnt
		Begin		
			
			SELECT  
					@l_ContactID = x.d.value(''ContactID[1]'',''bigint''),
					@l_ContactTitle = x.d.value(''ContactTitle[1]'',''varchar(10)''),
					@l_ContactName = x.d.value(''ContactName[1]'',''varchar(50)''),
					@l_Designation = x.d.value(''Designation[1]'',''varchar(50)''),
					@l_Phone1 = x.d.value(''Phone1[1]'',''varchar(20)''),
					@l_Phone2 = x.d.value(''Phone2[1]'',''varchar(20)''),
					@l_Mobile = x.d.value(''Mobile[1]'',''varchar(20)''),
					@l_Email = x.d.value(''Email[1]'',''varchar(50)''),
					@l_DOB = x.d.value(''DOB[1]'',''datetime''),
					@l_DOA = x.d.value(''DOA[1]'',''datetime'')
						
			FROM @i_ContactData.nodes(''/NewDataSet/Table[position()=sql:variable("@l_tmpCnt")]'') x(d);

			IF @l_DOB = '''' 
			Begin
				SET @l_DOB = NULL;
			End

			IF @l_DOA = '''' 
			Begin
				SET @l_DOA = NULL;
			End
	
			INSERT INTO Sale_Contact(   ContactID,Code,ContactType,   RefID,   ContactTitle,   ContactName,   Designation,   Phone1,   Phone2,   Mobile,   Email,   DOB,   DOA)
							VALUES	(@l_ContactID,@i_Code,@i_ContactType,@i_RefID,@l_ContactTitle,@l_ContactName,@l_Designation,@l_Phone1,@l_Phone2,@l_Mobile,@l_Email,@l_DOB,@l_DOA);								

			Set @l_tmpCnt = @l_tmpCnt + 1;

		End		

		
	COMMIT TRAN
	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
	ROLLBACK TRAN  
	END CATCH 

END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SEContactDetail_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record into Contact table
-- =============================================
create PROCEDURE [dbo].[usp_SEContactDetail_Update]
	@i_Code nvarchar(50),
	@i_RefID bigint,
	@i_ContactType tinyint,	
	@i_ContactData Xml,
	@i_Cnt Bigint,
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN	
	SET NOCOUNT ON;

    -- Declare Local Variable	
	DECLARE	@l_Date Datetime;
	Declare @l_ContactID bigint;
	Declare @l_ContactTitle varchar(10);
	Declare @l_ContactName varchar(50);
	Declare @l_Designation varchar(50);
	Declare @l_Phone1 varchar(20);
	Declare @l_Phone2 varchar(20);
	Declare @l_Mobile varchar(20);
	Declare @l_Email varchar(50);
	Declare @l_DOB datetime;
	Declare @l_DOA datetime;
	Declare @l_tmpCnt Bigint;

	-- Set Local Variable
	SET @o_ErrorMesg='''';
	Set @l_tmpCnt = 1;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	BEGIN TRY  
	BEGIN TRAN

		-- Delete Old record
		DELETE FROM Service_Contact WHERE ContactType = @i_ContactType AND RefID = @i_RefID and Code=@i_Code;

		-- Insert record into Contact Table
		While @i_Cnt >= @l_tmpCnt
		Begin		
			
			SELECT  
					@l_ContactID = x.d.value(''ContactID[1]'',''bigint''),
					@l_ContactTitle = x.d.value(''ContactTitle[1]'',''varchar(10)''),
					@l_ContactName = x.d.value(''ContactName[1]'',''varchar(50)''),
					@l_Designation = x.d.value(''Designation[1]'',''varchar(50)''),
					@l_Phone1 = x.d.value(''Phone1[1]'',''varchar(20)''),
					@l_Phone2 = x.d.value(''Phone2[1]'',''varchar(20)''),
					@l_Mobile = x.d.value(''Mobile[1]'',''varchar(20)''),
					@l_Email = x.d.value(''Email[1]'',''varchar(50)''),
					@l_DOB = x.d.value(''DOB[1]'',''datetime''),
					@l_DOA = x.d.value(''DOA[1]'',''datetime'')
						
			FROM @i_ContactData.nodes(''/NewDataSet/Table[position()=sql:variable("@l_tmpCnt")]'') x(d);

			IF @l_DOB = '''' 
			Begin
				SET @l_DOB = NULL;
			End

			IF @l_DOA = '''' 
			Begin
				SET @l_DOA = NULL;
			End
	
			INSERT INTO Service_Contact(   ContactID,Code,ContactType,   RefID,   ContactTitle,   ContactName,   Designation,   Phone1,   Phone2,   Mobile,   Email,   DOB,   DOA)
							VALUES	(@l_ContactID,@i_Code,@i_ContactType,@i_RefID,@l_ContactTitle,@l_ContactName,@l_Designation,@l_Phone1,@l_Phone2,@l_Mobile,@l_Email,@l_DOB,@l_DOA);								

			Set @l_tmpCnt = @l_tmpCnt + 1;

		End		

		
	COMMIT TRAN
	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
	ROLLBACK TRAN  
	END CATCH 

END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_QContactDetail_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record into Contact table
-- =============================================
CREATE PROCEDURE [dbo].[usp_QContactDetail_Update]
	@i_Code nvarchar(50),
	@i_RefID bigint,
	@i_ContactType tinyint,	
	@i_ContactData Xml,
	@i_Cnt Bigint,
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN	
	SET NOCOUNT ON;

    -- Declare Local Variable	
	DECLARE	@l_Date Datetime;
	Declare @l_ContactID bigint;
	Declare @l_ContactTitle varchar(10);
	Declare @l_ContactName varchar(50);
	Declare @l_Designation varchar(50);
	Declare @l_Phone1 varchar(20);
	Declare @l_Phone2 varchar(20);
	Declare @l_Mobile varchar(20);
	Declare @l_Email varchar(50);
	Declare @l_DOB datetime;
	Declare @l_DOA datetime;
	Declare @l_tmpCnt Bigint;

	-- Set Local Variable
	SET @o_ErrorMesg='''';
	Set @l_tmpCnt = 1;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	BEGIN TRY  
	BEGIN TRAN

		-- Delete Old record
		DELETE FROM Quotation_Contact WHERE ContactType = @i_ContactType AND RefID = @i_RefID and Code=@i_Code;

		-- Insert record into Contact Table
		While @i_Cnt >= @l_tmpCnt
		Begin		
			
			SELECT  
					@l_ContactID = x.d.value(''ContactID[1]'',''bigint''),
					@l_ContactTitle = x.d.value(''ContactTitle[1]'',''varchar(10)''),
					@l_ContactName = x.d.value(''ContactName[1]'',''varchar(50)''),
					@l_Designation = x.d.value(''Designation[1]'',''varchar(50)''),
					@l_Phone1 = x.d.value(''Phone1[1]'',''varchar(20)''),
					@l_Phone2 = x.d.value(''Phone2[1]'',''varchar(20)''),
					@l_Mobile = x.d.value(''Mobile[1]'',''varchar(20)''),
					@l_Email = x.d.value(''Email[1]'',''varchar(50)''),
					@l_DOB = x.d.value(''DOB[1]'',''datetime''),
					@l_DOA = x.d.value(''DOA[1]'',''datetime'')
						
			FROM @i_ContactData.nodes(''/NewDataSet/Table[position()=sql:variable("@l_tmpCnt")]'') x(d);

			IF @l_DOB = '''' 
			Begin
				SET @l_DOB = NULL;
			End

			IF @l_DOA = '''' 
			Begin
				SET @l_DOA = NULL;
			End
	
			INSERT INTO Quotation_Contact(   ContactID,Code,ContactType,   RefID,   ContactTitle,   ContactName,   Designation,   Phone1,   Phone2,   Mobile,   Email,   DOB,   DOA)
							VALUES	(@l_ContactID,@i_Code,@i_ContactType,@i_RefID,@l_ContactTitle,@l_ContactName,@l_Designation,@l_Phone1,@l_Phone2,@l_Mobile,@l_Email,@l_DOB,@l_DOA);								

			Set @l_tmpCnt = @l_tmpCnt + 1;

		End		

		
	COMMIT TRAN
	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
	ROLLBACK TRAN  
	END CATCH 

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_State_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Update record in State table
-- =============================================
Create PROCEDURE [dbo].[usp_State_Update]
	@i_StateID bigint,
	@i_CountryID bigint,
	@i_StateName Varchar(50),
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);

	SELECT @l_varRec = Count(StateID) FROM Gen_State WHERE Upper(Name) = Upper(@i_StateName) AND StateID <> @i_StateID ;
	
	IF @l_varRec=0
		BEGIN 
			UPDATE 
				Gen_State 
			SET
				Name = @i_StateName,
				CountryID = @i_CountryID,
				ModifiedBy = @i_UserID,
				ModifiedDate = @l_Date
			WHERE
				StateID = @i_StateID
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=4001 );			
		END
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_State_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record in State Table
-- =============================================
 Create PROCEDURE [dbo].[usp_State_Insert]
	@i_CountryID Bigint,
	@i_StateName Varchar(50),
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	SELECT @l_varRec = Count(StateID) FROM Gen_State WHERE Upper(Name) = Upper(@i_StateName);
	IF @l_varRec=0
		BEGIN 
			INSERT INTO Gen_State (        Name,   CountryID,CreatedBy,CreatedDate)
					        VALUES(@i_StateName,@i_CountryID,@i_UserID,@l_Date)
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 4001 );
		END

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_QContactDetail_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record into Contact table
-- =============================================
CREATE PROCEDURE [dbo].[usp_QContactDetail_Insert]
	@i_Code nvarchar(50),
	@i_RefID bigint,
	@i_ContactType tinyint,	
	@i_ContactData Xml,
	@i_Cnt Bigint,
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN	
	SET NOCOUNT ON;

    -- Declare Local Variable	
	DECLARE	@l_Date Datetime;
	Declare @l_ContactID bigint;
	Declare @l_ContactTitle varchar(10);
	Declare @l_ContactName varchar(50);
	Declare @l_Designation varchar(50);
	Declare @l_Phone1 varchar(20);
	Declare @l_Phone2 varchar(20);
	Declare @l_Mobile varchar(20);
	Declare @l_Email varchar(50);
	Declare @l_DOB datetime;
	Declare @l_DOA datetime;
	Declare @l_tmpCnt Bigint;

	-- Set Local Variable
	SET @o_ErrorMesg='''';
	Set @l_tmpCnt = 1;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	BEGIN TRY  
	BEGIN TRAN

		-- Delete Old record
--		DELETE FROM Quotation_Contact WHERE ContactType = @i_ContactType AND RefID = @i_RefID and Code=@i_Code;

		-- Insert record into Contact Table
		While @i_Cnt >= @l_tmpCnt
		Begin		
			
			SELECT  
					@l_ContactID = x.d.value(''ContactID[1]'',''bigint''),
					@l_ContactTitle = x.d.value(''ContactTitle[1]'',''varchar(10)''),
					@l_ContactName = x.d.value(''ContactName[1]'',''varchar(50)''),
					@l_Designation = x.d.value(''Designation[1]'',''varchar(50)''),
					@l_Phone1 = x.d.value(''Phone1[1]'',''varchar(20)''),
					@l_Phone2 = x.d.value(''Phone2[1]'',''varchar(20)''),
					@l_Mobile = x.d.value(''Mobile[1]'',''varchar(20)''),
					@l_Email = x.d.value(''Email[1]'',''varchar(50)''),
					@l_DOB = x.d.value(''DOB[1]'',''datetime''),
					@l_DOA = x.d.value(''DOA[1]'',''datetime'')
						
			FROM @i_ContactData.nodes(''/NewDataSet/Table[position()=sql:variable("@l_tmpCnt")]'') x(d);

			IF @l_DOB = '''' 
			Begin
				SET @l_DOB = NULL;
			End

			IF @l_DOA = '''' 
			Begin
				SET @l_DOA = NULL;
			End
	
			INSERT INTO Quotation_Contact(   ContactID,Code,ContactType,   RefID,   ContactTitle,   ContactName,   Designation,   Phone1,   Phone2,   Mobile,   Email,   DOB,   DOA)
							VALUES	(@l_ContactID,@i_Code,@i_ContactType,@i_RefID,@l_ContactTitle,@l_ContactName,@l_Designation,@l_Phone1,@l_Phone2,@l_Mobile,@l_Email,@l_DOB,@l_DOA);								

			Set @l_tmpCnt = @l_tmpCnt + 1;

		End		

		
	COMMIT TRAN
	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
	ROLLBACK TRAN  
	END CATCH 

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Vendor_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Update record in Vendor Table
-- =============================================
 CREATE PROCEDURE [dbo].[usp_Vendor_Update]
	@i_Code varchar(20),
	@i_VendorID Bigint,
	@i_Name Varchar(100),
	@i_Address1 Varchar(100),
	@i_Address2 Varchar(100),
	@i_CityID Bigint,
	@i_Pincode varchar(20),
	@i_Phone1 varchar(20),
	@i_Phone2 varchar(20),
	@i_Fax varchar(500),
	@i_Mobile varchar(20),
	@i_TinNo varchar(20),
	@i_CSTNo varchar(20),
	@i_PANo varchar(20),
	@i_EccNo varchar(20),
	@i_CreditDays int,
	@i_Range Varchar(50),
	@i_Division Varchar(50),
	@i_TransactionDate Datetime,
	@i_CRAmount Decimal(18,2),
	@i_DBAmount Decimal(18,2),	
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	SELECT @l_varRec = Count(VendorID) FROM Vendor WHERE Upper(Name) = Upper(@i_Name) AND VendorID <> @i_VendorID;
	IF @l_varRec=0
		BEGIN
			
					UPDATE Vendor
						SET
							Name = @i_Name,
							Address1 = @i_Address1,
							Address2 =@i_Address2,
							CityID = @i_CityID,
							Pincode = @i_Pincode,
							Phone1 = @i_Phone1,
							Phone2 = @i_Phone2,
							Fax = @i_Fax,
							Mobile = @i_Mobile,
							TinNo = @i_TinNo,
							CSTNo = @i_CSTNo,
							PANo = @i_PANo,
							EccNo = @i_EccNo,
							CreditDays = @i_CreditDays,
							Range = @i_Range,
							Division = @i_Division,
							ModifiedBy = @i_UserID,
							ModifiedDate = @l_Date
					WHERE
						VendorID = @i_VendorID;
				
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 26002 );
		END
		
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ContactDetail_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record into Contact table
-- =============================================
CREATE PROCEDURE [dbo].[usp_ContactDetail_Insert]
	@i_ContactType tinyint,
	@i_RefID bigint,
	@i_ContactData Xml,
	@i_Cnt Bigint,
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN	
	SET NOCOUNT ON;

    -- Declare Local Variable	
	DECLARE	@l_Date Datetime;
	
	Declare @l_ContactTitle varchar(10);
	Declare @l_ContactName varchar(50);
	Declare @l_Designation varchar(50);
	Declare @l_Phone1 varchar(20);
	Declare @l_Phone2 varchar(20);
	Declare @l_Mobile varchar(20);
	Declare @l_Email varchar(50);
	Declare @l_DOB datetime;
	Declare @l_DOA datetime;
	Declare @l_tmpCnt Bigint;

	-- Set Local Variable
	SET @o_ErrorMesg='''';
	Set @l_tmpCnt = 1;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	BEGIN TRY  
	BEGIN TRAN

		-- Delete Old record
		DELETE FROM ContactDetail WHERE ContactType = @i_ContactType AND RefID = @i_RefID;

		-- Insert record into Contact Table
		While @i_Cnt >= @l_tmpCnt
		Begin		
			
			SELECT  @l_ContactTitle = x.d.value(''ContactTitle[1]'',''varchar(10)''),
					@l_ContactName = x.d.value(''ContactName[1]'',''varchar(50)''),
					@l_Designation = x.d.value(''Designation[1]'',''varchar(50)''),
					@l_Phone1 = x.d.value(''Phone1[1]'',''varchar(20)''),
					@l_Phone2 = x.d.value(''Phone2[1]'',''varchar(20)''),
					@l_Mobile = x.d.value(''Mobile[1]'',''varchar(20)''),
					@l_Email = x.d.value(''Email[1]'',''varchar(50)''),
					@l_DOB = x.d.value(''DOB[1]'',''datetime''),
					@l_DOA = x.d.value(''DOA[1]'',''datetime'')
						
			FROM @i_ContactData.nodes(''/NewDataSet/Table[position()=sql:variable("@l_tmpCnt")]'') x(d);

			IF @l_DOB = '''' 
			Begin
				SET @l_DOB = NULL;
			End

			IF @l_DOA = '''' 
			Begin
				SET @l_DOA = NULL;
			End
	
			INSERT INTO ContactDetail(   ContactType,   RefID,   ContactTitle,   ContactName,   Designation,   Phone1,   Phone2,   Mobile,   Email,   DOB,   DOA,CreatedBy,CreatedDate)
							VALUES	(@i_ContactType,@i_RefID,@l_ContactTitle,@l_ContactName,@l_Designation,@l_Phone1,@l_Phone2,@l_Mobile,@l_Email,@l_DOB,@l_DOA,@i_UserID,@l_Date);								

			Set @l_tmpCnt = @l_tmpCnt + 1;

		End		

		
	COMMIT TRAN
	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
	ROLLBACK TRAN  
	END CATCH 

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Country_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record in Country Table
-- =============================================
Create PROCEDURE [dbo].[usp_Country_Insert]
	@i_CountryName Varchar(50),
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT 
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	SELECT @l_varRec = Count(CountryID) FROM Gen_Country WHERE Upper([Name]) = Upper(@i_CountryName);
	IF @l_varRec=0
		BEGIN 
			INSERT INTO 
				Gen_Country
					([Name], CreatedBy,CreatedDate)
			 VALUES (@i_CountryName,@i_UserID,@l_Date)
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 3001 );
		END

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_User_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for insert record into user table.
-- =============================================
 CREATE PROCEDURE [dbo].[usp_User_Insert]	
	@i_UserName varchar(20),
	@i_Password varchar(20),
	@i_Name     Varchar(50),
	@i_CreatedBy   Bigint,
	@i_CompId bigint,
	@i_Company varchar(100),
	@i_User_Email nvarchar(50),
	@i_User_Password nvarchar(50),
	@i_User_NPassword nvarchar(50),
	@i_User_ssl int,
	@i_User_Port int,
	@i_User_Host nvarchar(50),
	@i_Company_Email nvarchar(50),
	@i_Mail_Send bit,
	@i_strPrivilegeList varchar(max),
	@o_ErrorMesg   varchar(500) OUTPUT

AS
BEGIN	 

	SET NOCOUNT ON;
	--Declare Local Variables..
	Declare @l_UserCount Bigint;
	Declare @l_CreatedDate DateTime;
	Declare @l_ErrorNo BigInt;
Declare @l_NewID Bigint;
Set @l_NewID = 0;
	--Set Local Variable value..
	Set @l_UserCount=0;
	Set @o_ErrorMesg='''';
	Set @l_ErrorNo = 0;

  	--Set Current Date
	Select @l_CreatedDate = Convert(DateTime,GetDate(),105);

--	BEGIN TRY  
--	BEGIN TRAN

	--Check User Name is Exists or Not..	
	Select  @l_UserCount = Count(UserName) From Gen_User Where Upper(UserName) = Upper(@i_UserName);
	If @l_UserCount = 0
		Begin
				--Insert Record in User Table
				Insert Into Gen_User(   UserName   ,Password   ,[Name] ,CreatedBy   ,CreatedDate,CompId,Company,User_Email,User_Password,User_NPassword,User_ssl,User_Port,Company_Email,User_Host,Mail_Send) 
 							Values  (@i_UserName,@i_Password,@i_Name,@i_CreatedBy,@l_CreatedDate,@i_CompId,@i_Company,@i_User_Email,@i_User_Password,@i_User_NPassword,@i_User_ssl,@i_User_Port,@i_Company_Email,@i_User_Host,@i_Mail_Send);

Set @l_NewID = @@Identity;
				If @i_strPrivilegeList <> ''''
					Begin
						Create Table #tmpPrivilegeID
						(PrivilegeID Bigint)

						Insert Into #tmpPrivilegeID
						Select Data  from Split(@i_strPrivilegeList,'','')
						
						Insert Into Gen_UserScope  (UserID,PrivilegeID)
										    Select @l_NewID,PrivilegeID from #tmpPrivilegeID
					End
		End
	Else
		Begin
			SET @l_ErrorNo = 1001
		End

--	If @l_ErrorNo=0
--			Begin
--				COMMIT TRAN
--			End		
--		Else
--			Begin
--				ROLLBACK TRAN  
--			End 
--			
--END TRY
--	BEGIN CATCH   
--		SET @l_ErrorNo = 10000
--		ROLLBACK TRAN  
--	END CATCH 
	SELECT @o_ErrorMesg = ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = @l_ErrorNo				
  
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TNC_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record into Contact table
-- =============================================
CREATE PROCEDURE [dbo].[usp_TNC_Insert]
	@i_TNC_Sub varchar(50),
	
	@i_CreatedBy   Bigint,
	@i_ContactData Xml,
	@i_Cnt Bigint,
	@o_ErrorMesg   varchar(500) OUTPUT		

AS
BEGIN	
	SET NOCOUNT ON;

    -- Declare Local Variable	
	DECLARE	@l_Date Datetime;
	Declare @l_Description varchar(Max);
	Declare @l_tmpCnt Bigint;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	Set @l_tmpCnt = 1;
	

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	BEGIN TRY  
	BEGIN TRAN

		-- Delete Old record
		DELETE FROM TermsNConditions WHERE TNC_Sub = @i_TNC_Sub ;

		-- Insert record into Contact Table
		While @i_Cnt >= @l_tmpCnt
		Begin		
			
			SELECT  @l_Description = x.d.value(''TNC_Desc[1]'',''nvarchar(Max)'')					
						
			FROM @i_ContactData.nodes(''/NewDataSet/Table[position()=sql:variable("@l_tmpCnt")]'') x(d);

			
	
			INSERT INTO TermsNConditions(   TNC_Sub   ,TNC_Desc  ,CreatedBy   ,CreatedDate )
							VALUES	(@i_TNC_Sub,@l_Description,@i_CreatedBy,@l_Date );								

			Set @l_tmpCnt = @l_tmpCnt + 1;

		End		

		
	COMMIT TRAN
	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
	ROLLBACK TRAN  
	END CATCH 

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Update record in Item Table
-- =============================================

CREATE PROCEDURE [dbo].[usp_Item_Update]
	@i_ItemID Bigint,
	@i_Code Varchar(50),
	@i_ItemName Varchar(MAX),
	@i_OtherName Varchar(100),
	@i_Specification Varchar(MAX),
	@i_Price decimal(18,2),
	@i_CUOMID Bigint,
	@i_HSNCode nvarchar(150),
	@i_ProductCode nvarchar(150),
	@i_UserID Bigint,

	@i_StockID Bigint,	
	@i_QOH Decimal(18,3) ,
	@i_ReOrderLvl Decimal(18,3) , 
	@i_Location Varchar(100), 
	@i_RackNo varchar(100),
	@i_GodownID int,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	DECLARE @l_ParentID Bigint;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;
	SET @l_ParentID=0;

DECLARE @l_Qty Decimal(18,3);
	SET @l_Qty = 0;

	SET @l_Date=Convert(Datetime,getDate(),5);
	SELECT @l_varRec = Count(ItemID) FROM Item WHERE Upper(Name) = Upper(@i_ItemName) AND ItemID <> @i_ItemID;
	IF @l_varRec=0
		BEGIN 
			Update Item 
			Set 
			 
				Code = @i_Code,     
				Name = @i_ItemName,     
				OtherName = @i_OtherName,   
				Specification = @i_Specification,   
				CUomID = @i_CUOMID,   
				Price=@i_Price,
				ModifiedBy = @i_UserID,
				ModifiedDate = @l_Date,
				HSNCode=@i_HSNCode,
				ProductCode=@i_ProductCode

--				QOH = QOH - @l_Qty + @i_QOH,
--				
--				ReOrderLvl = @i_ReOrderLvl,
--				Location = @i_Location,
--				RackNo = @i_RackNo,
--				ModifiedBy = @i_UserID,
--				ModifiedDate = @l_Date,
--				GodownID=@i_GodownID

			Where ItemID = @i_ItemID

--			SELECT @l_Qty = Qty From  ItemStockDetail WHERE	StockID = @i_StockID AND GTID = 100;
--
--			update ItemStock set 
--				QOH = QOH - @l_Qty + @i_QOH,				
--				ReOrderLvl = @i_ReOrderLvl,
--				Location = @i_Location,
--				RackNo = @i_RackNo,
--				ModifiedBy = @i_UserID,
--				ModifiedDate = @l_Date,
--				GodownID=@i_GodownID
--			where StockID=@i_StockID

		END
	ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 13002 );
		END

END








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TNC_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_TNC_Update]	
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub varchar(50),
	@i_TNC_Desc    Varchar(Max),
	@i_ModifiedBy Bigint,
	@i_TNCID int,
	@o_ErrorMesg   varchar(500) OUTPUT


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @l_TNCCount Bigint;
	Declare @l_Date DateTime;
	Declare @l_ErrorNo BigINt;
	--Set Local Variable value..
	Set @l_TNCCount=0;
	Set @o_ErrorMesg='''';
	--Set Current Date
	Select @l_Date=Convert(DateTime,GetDate(),5);
	Declare @l_ACDate DateTime;
	Set @l_ErrorNo = 0;

	BEGIN TRY  
	BEGIN TRAN

		--Check User Name is Exists or Not..	
		Select @l_TNCCount=Count(TNCID) From TermsNConditions Where Upper(TNC_Desc) = Upper(@i_TNC_Desc) AND Upper(TNC_Sub) = Upper(@i_TNC_Sub)
			 AND TNCID <> @i_TNCID;
		If @l_TNCCount=0
			Begin

				--Update Record in Users Table
				Update 
					TermsNConditions
				Set 
					TNC_Sub = @i_TNC_Sub,
					TNC_Desc = @i_TNC_Desc,
					ModifiedBy=@i_ModifiedBy,
					ModifiedDate=@l_Date
				Where 
					TNCID = @i_TNCID
	 
			End
		ELSE
			BEGIN
				SET @l_ErrorNo = 1001
			END

		If @l_ErrorNo=0
			Begin
				COMMIT TRAN
			End		
		Else
			Begin
				ROLLBACK TRAN  
			End 
			
	END TRY
	BEGIN CATCH   
		SET @l_ErrorNo = 10000
		ROLLBACK TRAN  
	END CATCH 

	IF @o_ErrorMesg = ''''
	BEGIN
		SELECT @o_ErrorMesg = ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = @l_ErrorNo				
	END

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemStock_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Delete record from ItemStock 
-- =============================================
CREATE PROCEDURE [dbo].[usp_ItemStock_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	--Declare Local Variables
	 
	Declare @l_ItemID Bigint;
	Declare @l_StoreType smallint;

	-- Set Local Variable
	SET @o_ErrorMesg='''';
 
	SET @l_ItemID = 0;
	SET @l_StoreType = 0;

	BEGIN TRY  
	BEGIN TRAN

		SELECT @l_ItemID = ItemID FROM ItemStock 
					WHERE StockID = @i_RecID;

		DELETE FROM ItemAdjustment
			WHERE AdjustmentID IN (Select AdjustmentID From ItemAdjustment WHERE ItemID = @l_ItemID );

		DELETE FROM ItemStockDetail
			WHERE StockID = @i_RecID;

		DELETE FROM ItemStock
			WHERE StockID = @i_RecID ;
				
		
	COMMIT TRAN
	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
	ROLLBACK TRAN  
	END CATCH 
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemStock_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Update record in ItemStock table
-- =============================================
CREATE PROCEDURE [dbo].[usp_ItemStock_Update]
	@i_StockID Bigint,	
	@i_ItemID Bigint,
	@i_QOH Decimal(18,3) ,
	@i_MinLevel Decimal(18,3) , 
	@i_MaxLevel Decimal(18,3) , 
	@i_ReOrderLvl Decimal(18,3) , 
	@i_Location Varchar(100), 
	@i_RackNo varchar(100),	
	@i_Date Datetime,
	@i_UserID bigint,
	@i_GodownID int,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;
	DECLARE @l_Qty Decimal(18,3);
	SET @l_Qty = 0;
	SET @l_Date=Convert(Datetime,getDate(),5);
	BEGIN TRY  
	BEGIN TRAN
		
		 
--		SELECT @l_varRec = Count(StockID) FROM ItemStock WHERE ItemID = @i_ItemID AND StockID <> @i_StockID;
		IF @l_varRec=0
			BEGIN 
				
			SELECT @l_Qty = Qty From  ItemStockDetail WHERE	StockID = @i_StockID AND GTID = 100;

		--Update record into stock table
		UPDATE ItemStock
			SET ItemID = @i_ItemID,
				QOH = QOH - @l_Qty + @i_QOH,
				MinLevel = @i_MinLevel,
				MaxLevel = @i_MaxLevel,
				ReOrderLvl = @i_ReOrderLvl,
				Location = @i_Location,
				RackNo = @i_RackNo,
				ModifiedBy = @i_UserID,
				ModifiedDate = @l_Date,
				GodownID=@i_GodownID
		WHERE
			StockID = @i_StockID;

			--Update record into Stockdetail table
			UPDATE ItemStockDetail
				SET Date = @i_Date,
					Qty = @i_QOH
			WHERE
				StockID = @i_StockID AND GTID = 100;

			END
		ELSE
			BEGIN
				SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 35001 );
			END

	COMMIT TRAN
	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg= (SELECT ErrorMessage FROM ErrorMessage WHERE ErrorNo = 10000);
	ROLLBACK TRAN  
	END CATCH 

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemAdjustment_Confirm]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Confirm Item Adjustmnet
-- =============================================
CREATE PROCEDURE [dbo].[usp_ItemAdjustment_Confirm]
	@i_AdjustmentID Bigint,	
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN	
	SET NOCOUNT ON;
	--Declare Local varaible
	Declare @l_Date Datetime;
 
	Declare @l_ItemID Bigint;
	Declare @l_Qty decimal(18,3);
	Declare @l_StockID Bigint;
	Declare @l_Narration varchar(200);
	Declare @l_FYID Bigint;
	Declare @l_GodownId int;
	--Set Local varaible
	SET @o_ErrorMesg='''';
	 
	SET @l_ItemID = 0;
	SET @l_Qty =0;
	SET @l_StockID = 0;
	SET @l_Narration = '''';
	SET @l_FYID = 0;
	SET @l_GodownId=0;	

	BEGIN TRY  
	BEGIN TRAN
		SELECT @l_FYID = FYID FROM ItemAdjustment WHERE AdjustmentID = @i_AdjustmentID ;

		SELECT @l_Date = AdjustDate, @l_Qty = Qty,@l_ItemID = ItemID,@l_GodownId=GodownId FROM ItemAdjustment WHERE AdjustmentID = @i_AdjustmentID;
		
		SELECT @l_StockID = StockID FROM ItemStock Where  ItemID = @l_ItemID and GodownId=@l_GodownId;

		-- Update ItemAdjustment for Confirmation
		UPDATE ItemAdjustment
			SET
				IsConfirmed = 1
			WHERE
				AdjustmentID = @i_AdjustmentID;
		
		-- UPDATE Stocks Table
		UPDATE	ItemStock
			SET	QOH = QOH + @l_Qty
			WHERE	StockID = @l_StockID;

		SET @l_Narration = ''Stock Adjusted on ''  + Convert(varchar,@l_Date,103)
		--  INSERT Stock Detail Record
		INSERT INTO ItemStockDetail (   StockID,GTID,          RefID,   Date, Description,   Qty)
				                  VALUES (@l_StockID,  550,@i_AdjustmentID,@l_Date,@l_Narration,@l_Qty)


	COMMIT TRAN
	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
	ROLLBACK TRAN  
	END CATCH 

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TaxClass_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	Sp is used for update record for tax class.
-- =============================================
 
Create PROCEDURE [dbo].[usp_TaxClass_Update]
	@i_TaxClassID Bigint,
	@i_TaxClass   Varchar(20),
	@i_FromDate	  DateTime,
	@i_Excise     Decimal(12,2),
	@i_VAT        Decimal(12,2),
	@i_ServiceTax Decimal(12,2),
	@i_EduCess    Decimal(12,2),
	@i_HEduCess   Decimal(12,2),
	@i_CST		  Decimal(12,2),
	@i_AVAT		  Decimal(12,2),
	@i_ModifiedBy Bigint,	
	@o_ErrorMesg  Varchar(500) OUTPUT  
AS
BEGIN	
	Declare @l_ModifiedDate DateTime;
	Declare @l_TaxClassCount bigint;
	Set @l_TaxClassCount = 0;

	Set @o_ErrorMesg = '''';
 
	SET NOCOUNT ON;

	Select @l_ModifiedDate = Convert(DateTime,GetDate(),105);

	Select @l_TaxClassCount = Count(TaxClassID) From TaxClass Where UPPER(Name) = UPPER(@i_TaxClass) And TaxClassID <> @i_TaxClassID And IsTerminate = 0;

	If @l_TaxClassCount = 0 
		Begin	

			Update
				TaxClass
			Set	
				Name = @i_TaxClass,
				FromDate     = @i_FromDate,
				Excise		 = @i_Excise,
				VAT          = @i_VAT,
				CST          = @i_CST,
				AVAT         = @i_AVAT,
				ServiceTax   = @i_ServiceTax,
				EduCess      = @i_EduCess,
				HEduCess     = @i_HEduCess,
				ModifiedBy   = @i_ModifiedBy,
				ModifiedDate = @l_ModifiedDate
			Where
				TaxClassID = @i_TaxClassID;			 	            
	
		End
	Else
		Begin
			SET @o_ErrorMesg= (SELECT ErrorMsg FROM GEN_ErrorMsg WHERE ErrorNo=12001);
		End 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Vendor_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record in Vendor Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_Vendor_Insert]	
	@i_FYID BIGINT,
	@i_Code varchar(20),
	@i_Name Varchar(100),
	@i_Address1 Varchar(100),
	@i_Address2 Varchar(100),
	@i_CityID Bigint,
	@i_Pincode varchar(20),
	@i_Phone1 varchar(20),
	@i_Phone2 varchar(20),
	@i_Fax varchar(500),
	@i_Mobile varchar(20),
	@i_TinNo varchar(20),
	@i_CSTNo varchar(20),
	@i_PANo varchar(20),
	@i_EccNo varchar(20),
	@i_CreditDays int,
	@i_Range Varchar(50),
	@i_Division Varchar(50),
	@i_TransactionDate Datetime,
	@i_CRAmount Decimal(18,2),
	@i_DBAmount Decimal(18,2),	
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	Declare @l_AccountID Bigint
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;
	Set @l_AccountID = 0
	SET @l_Date=Convert(Datetime,getDate(),5);
	
	SELECT @l_varRec = Count(VendorID) FROM Vendor WHERE Upper(Code) = Upper(@i_Code) ;
	IF @l_varRec=0
		BEGIN
			SELECT @l_varRec = Count(VendorID) FROM Vendor WHERE Upper(Name) = Upper(@i_Name) ;
			IF @l_varRec=0
				BEGIN
					Select @l_varRec = Count(AccountID) From Account Where AccountCode = @i_Code;
					If @l_varRec = 0 
					Begin
						Select @l_varRec = Count(AccountID) From Account Where AccountName = @i_Name;
						If @l_varRec = 0 
						Begin
							Insert Into Account (AccountCode, AccountName, AccCreatedDate,AccTypeID )
											Values (@i_Code, @i_Name,@i_TransactionDate,2);
									Set @l_AccountID = Scope_Identity();
					
								Insert Into OpeningBalance (  FYID,AccountID, CRAmount, DBAmount)
													Values(@i_FYID,@l_AccountID ,@i_CRAmount,@i_DBAmount);
							Insert Into Ledger (  FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
										Values(@i_FYID,@l_AccountID,   1,			  @l_AccountID, @i_TransactionDate, @i_CRAmount, @i_DBAmount,''Opening Balance'');

							INSERT INTO Vendor( AccountID,  Code,   Name,   Address1,   Address2,   CityID,   Pincode,   Phone1,   Phone2,   Fax,   Mobile,   TinNo,   CSTNo,   PANo,   EccNo,   CreditDays,   Range,   Division,   CreatedBy,CreatedDate)
											 VALUES(@l_AccountID,@i_Code,@i_Name,@i_Address1,@i_Address2,@i_CityID,@i_Pincode,@i_Phone1,@i_Phone2,@i_Fax,@i_Mobile,@i_TinNo,@i_CSTNo,@i_PANo,@i_EccNo,@i_CreditDays,@i_Range,@i_Division,@i_UserID,@l_Date)
						End
						Else
						Begin
							-- Account Name is Already Exist..
							SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 24004 );
						End	
					End
					Else
					Begin
						-- Account Code is Already Exist.
						SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 24003 );
					End
				END
			ELSE
				BEGIN
					SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 26002 );
				END
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 26001 );
		END

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Employee_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Update record in Employee table
-- =============================================
 
CREATE PROCEDURE [dbo].[usp_Employee_Update]
	@i_EmpId	bigint,
	@i_EmpName	varchar(150),
	@i_Address	varchar(250),
	@i_PhoneNo	varchar(20),
	@i_Email	varchar(50),
	@i_Department	varchar(50),
	@i_Salary Decimal(18,2),
	@i_UserID bigint,
	
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);

	SELECT @l_varRec = Count(EmpId) FROM Employee WHERE Upper(EmpName) = Upper(@i_EmpName) AND EmpId <> @i_EmpId;
	
	IF @l_varRec=0
		BEGIN 
			UPDATE 
				Employee
			SET				 
				EmpName=@i_EmpName,
				Address=@i_Address,
				PhoneNo=@i_PhoneNo,
				Email=@i_Email,
				Department=@i_Department,
				Salary = @i_Salary,
				ModifiedBy = @i_UserID,
				ModifiedDate = @l_Date
				
			WHERE
				EmpId = @i_EmpId
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 36001 );			
		END
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Employee_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Insert record in Employee Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_Employee_Insert]	 
	@i_EmpName	varchar(150),
	@i_Address	varchar(250),
	@i_PhoneNo	varchar(20),
	@i_Email	varchar(50),
	@i_Department	varchar(50),
	@i_Salary Decimal(18,0),
	@i_UserID bigint,
	
	
	@o_ErrorMesg Varchar(200) OUTPUT 
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	SELECT @l_varRec = Count(EmpId) FROM Employee WHERE Upper(EmpName) = Upper(@i_EmpName);
	IF @l_varRec=0
		BEGIN 
			INSERT INTO 
				Employee
					(   EmpName,   Address,   PhoneNo,   Email,   Department,Salary,CreatedBy,CreatedDate)
			 VALUES (@i_EmpName,@i_Address,@i_PhoneNo,@i_Email,@i_Department,@i_Salary,@i_UserID,@l_Date)
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 36001 );
		END

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TaxClass_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	Sp is used for insert record for tax class.
-- =============================================
Create PROCEDURE [dbo].[usp_TaxClass_Insert]

	@i_TaxClass   Varchar(20),
	@i_FromDate	  DateTime,
	@i_Excise     Decimal(12,2),
	@i_VAT		  Decimal(12,2),
	@i_ServiceTax Decimal(12,2),
	@i_EduCess    Decimal(12,2),
	@i_HEduCess   Decimal(12,2),
	@i_CST		  Decimal(12,2),
	@i_AVAT		  Decimal(12,2),
	@i_CreatedBy  Bigint,
	@o_ErrorMesg  Varchar(500) OUTPUT 
 
AS

BEGIN
	Declare @l_CreatedDate DateTime;
	Declare @l_TaxClassCount bigint;
	Set @l_TaxClassCount = 0;

	Set @o_ErrorMesg = '''';

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	Select @l_CreatedDate = Convert(DateTime,GetDate(),105);

	Select @l_TaxClassCount = Count(TaxClassID) From TaxClass Where UPPER(Name) = UPPER(@i_TaxClass) And IsTerminate = 0; 

	If @l_TaxClassCount = 0 
		Begin	
			Insert Into TaxClass
					(        Name,FromDate   ,    Excise,    VAT,    CST,    AVAT,    ServiceTax   ,EduCess   ,HEduCess   ,CreatedBy   ,CreatedDate)
			Values  (@i_TaxClass ,@i_FromDate, @i_Excise, @i_VAT, @i_CST, @i_AVAT, @i_ServiceTax,@i_EduCess,@i_HEduCess,@i_CreatedBy,@l_CreatedDate);
		End
	Else
		Begin
			SET @o_ErrorMesg= (SELECT ErrorMsg FROM GEN_ErrorMsg WHERE ErrorNo=12001);
		End 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Email_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Email_Update]	
	-- Add the parameters for the stored procedure here
	@i_Type nvarchar(50),
	@i_Subject nVarchar(MAX),
	@i_Header nvarchar(MAX),
	@i_Footer nvarchar(MAX),
	@i_ModifiedBy Bigint,
	@i_Email_ID int,
	@i_CompId bigint,
	@o_ErrorMesg   varchar(500) OUTPUT


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @l_EmailCount Bigint;
	Declare @l_Date DateTime;
	Declare @l_ErrorNo BigINt;
	--Set Local Variable value..
	Set @l_EmailCount=0;
	Set @o_ErrorMesg='''';
	--Set Current Date
	Select @l_Date=Convert(DateTime,GetDate(),5);
	Declare @l_ACDate DateTime;
	Set @l_ErrorNo = 0;

	BEGIN TRY  
	BEGIN TRAN

		--Check User Name is Exists or Not..	
--		Select @l_GodownCount=Count(GodownID) From Godown Where Upper(Godown_name) = Upper(@i_Godown_name) AND GodownID <> @i_GodownID;
--		If @l_GodownCount=0
--			Begin

				--Update Record in Users Table
				Update 
					Email
				Set 
					Type = @i_Type,
					Subject = @i_Subject,
					Header=@i_Header,
					Footer=@i_Footer,
					ModifiedBy=@i_ModifiedBy,
					ModifiedDate=@l_Date,
					CompId=@i_CompId
				Where 
					Email_ID = @i_Email_ID
	 
--			End
--		ELSE
--			BEGIN
--				SET @l_ErrorNo = 1001
--			END

		If @l_ErrorNo=0
			Begin
				COMMIT TRAN
			End		
		Else
			Begin
				ROLLBACK TRAN  
			End 
			
	END TRY
	BEGIN CATCH   
		SET @l_ErrorNo = 10000
		ROLLBACK TRAN  
	END CATCH 

	IF @o_ErrorMesg = ''''
	BEGIN
		SELECT @o_ErrorMesg = ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = @l_ErrorNo				
	END

END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_User_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for update record for user.
-- =============================================
 CREATE PROCEDURE [dbo].[usp_User_Update]
	@i_UserID  Bigint,
	@i_UserName varchar(20),
	@i_Password varchar(20),
	@i_Name     Varchar(50),
	@i_ModifiedBy Bigint,
	@i_CompId bigint,
	@i_Company varchar(100),
	@i_User_Email nvarchar(50),
	@i_User_Password nvarchar(50),
	@i_User_NPassword nvarchar(50),
	@i_User_ssl int,
	@i_User_Port int,
	@i_User_Host nvarchar(50),
	@i_Company_Email nvarchar(50),
	@i_Mail_Send bit,
	@i_strPrivilegeList varchar(max),
	@o_ErrorMesg varchar(500) Output

AS
BEGIN
 	 --Declare Local Variables..
	Declare @l_UserCount Bigint;
	Declare @l_Date DateTime;
	Declare @l_ErrorNo BigINt;
	--Set Local Variable value..
	Set @l_UserCount=0;
	Set @o_ErrorMesg='''';
	--Set Current Date
	Select @l_Date=Convert(DateTime,GetDate(),5);
	Declare @l_ACDate DateTime;
	Set @l_ErrorNo = 0;

	BEGIN TRY  
	BEGIN TRAN

		--Check User Name is Exists or Not..	
		Select @l_UserCount=Count(UserID) From Gen_User Where Upper(UserName) = Upper(@i_UserName) AND UserID <> @i_UserID;
		If @l_UserCount=0
			Begin

				--Update Record in Users Table
				Update 
					Gen_User
				Set 
					UserName = @i_UserName,
					Password = @i_Password,
					[Name]	 = @i_Name, 
					ModifiedBy=@i_ModifiedBy,
					ModifiedDate=@l_Date,
					Company = @i_Company,
					CompId=@i_CompId,
					User_Email=@i_User_Email,
					User_Password=@i_User_Password,
					User_NPassword=@i_User_NPassword,
					User_ssl=@i_User_ssl,
					User_Port=@i_User_Port,
					User_Host=@i_User_Host,
					Company_Email=@i_Company_Email,
					Mail_Send=@i_Mail_Send 
					
				Where 
					UserID = @i_UserID

Delete From Gen_UserScope Where UserID = @i_UserID

				If @i_strPrivilegeList <> ''''
				Begin
					Create Table #tmpPrivilegeID
					(PrivilegeID Bigint)

					Insert Into #tmpPrivilegeID
						Select Data  from Split(@i_strPrivilegeList,'','')
						
					Insert Into  Gen_UserScope(UserID,PrivilegeID)
									   Select @i_UserID,PrivilegeID from #tmpPrivilegeID
				End

	 
			End
		ELSE
			BEGIN
				SET @l_ErrorNo = 1001
			END

		If @l_ErrorNo=0
			Begin
				COMMIT TRAN
			End		
		Else
			Begin
				ROLLBACK TRAN  
			End 
			
	END TRY
	BEGIN CATCH   
		SET @l_ErrorNo = 10000
		ROLLBACK TRAN  
	END CATCH 

	IF @o_ErrorMesg = ''''
	BEGIN
		SELECT @o_ErrorMesg = ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = @l_ErrorNo				
	END

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Email_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Email_Insert]	
	-- Add the parameters for the stored procedure here
	@i_Type varchar(50),
	@i_Subject    Varchar(MAX),
	@i_Header    Varchar(MAX),
	@i_Footer    Varchar(MAX),
	@i_CreatedBy   Bigint,
	@i_CompId bigint,
	@o_ErrorMesg   varchar(500) OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @l_EmailCount Bigint;
	Declare @l_CreatedDate DateTime;
	Declare @l_ErrorNo BigInt;

	--Set Local Variable value..
	Set @l_EmailCount=0;
	Set @o_ErrorMesg='''';
	Set @l_ErrorNo = 0;

  	--Set Current Date
	Select @l_CreatedDate = Convert(DateTime,GetDate(),105);

	BEGIN TRY  
	BEGIN TRAN

	--Check User Name is Exists or Not..	
	--Select  @l_EmailCount = Count(Subject) From Godown Where Upper(Godown_name) = Upper(@i_Godown_name);
	--If @l_GodownCount = 0
	--	Begin
				--Insert Record in User Table
				Insert Into Email(   Type   ,Subject ,Header ,Footer,CreatedBy   ,CreatedDate,CompId ) 
 							Values  (@i_Type,@i_Subject,@i_Header,@i_Footer,@i_CreatedBy,@l_CreatedDate,@i_CompId );
	--	End
	--Else
	--	Begin
	--		SET @l_ErrorNo = 1001
	--	End

	If @l_ErrorNo=0
			Begin
				COMMIT TRAN
			End		
		Else
			Begin
				ROLLBACK TRAN  
			End 
			
END TRY
	BEGIN CATCH   
		SET @l_ErrorNo = 10000
		ROLLBACK TRAN  
	END CATCH 
	SELECT @o_ErrorMesg = ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = @l_ErrorNo				
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PurchaseInvoice_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 24th jan 2011
-- Description:	Update record of Purchase Invoice and Purchase Invoice Detail
-- =============================================
CREATE PROCEDURE [dbo].[usp_PurchaseInvoice_Update]
	@i_PIID Bigint,
	@i_PurchaseCode Varchar(20),
	@i_FYID Bigint,
	@i_PurchaseDate DateTime,
	@i_SrNo Varchar(50),
	@i_VoucherNo Varchar(20),
	@i_VoucherDate DATETIME,
	@i_VendorID Bigint,
	@i_DueDays Bigint,
	@i_DueDate DateTime,
	@i_TotalAmount Decimal(18,2),
	@i_ServiceAmount  Decimal(18,2),	
	@i_ExciseAmount  Decimal(18,2),	
	@i_CessAmount Decimal(18,2),
	@i_HCessAmount Decimal(18,2),
	@i_AmountAfterExcise Decimal(18,2),
	@i_CSTAmount Decimal(18,2),
	@i_VATAmount Decimal(18,2),
	@i_AVATAmount Decimal(18,2),
	@i_Discount DECIMAL(18,2),
	@i_NetAmount  Decimal(18,2),
	@i_PaidAmount  Decimal(18,2),
	@i_Narration Varchar(250),
	@i_XMLString xml,
	@i_Cnt Bigint,
	@i_UserID BIGINT,
	@i_GodownID int,
	@o_ErrorMesg Varchar(200) OUTPUT

AS
BEGIN
	SET NOCOUNT ON;

    -- Declare Local Variables...
	DECLARE @l_varRec Bigint;
 	DECLARE @l_VendorAccID Bigint
	DECLARE @l_LedNarration varchar(50)
	 
 
	DECLARE @l_Description varchar(100);
	-- Set Local Variable value..
	SET @l_varRec = 0;
	SET @l_Description  = ''''
	SET @l_VendorAccID = 0
	SET @l_LedNarration =''''
 
 
	-- Variable for StockDetail
 
	SET @o_ErrorMesg='''';
 


	BEGIN TRY  
	BEGIN TRAN
 
 	SELECT @l_varRec = Count(PIID) From PurchaseInvoice Where PurchaseCode = @i_PurchaseCode AND PIID <> @i_PIID
 		IF @l_varRec = 0
 			BEGIN
 				Set @l_LedNarration  = ''Purchase Against '' + @i_PurchaseCode
 					-- Delete Stock	
				Update ItemStock
					Set ItemStock.QOH =  ItemStock.QOH -
						(Select IsNull(Sum(ItemStockDetail.Qty),0)
							From ItemStockDetail Where  ItemStockDetail.StockID = ItemStock.StockID 
								And ItemStockDetail.RefID = @i_PIID And ItemStockDetail.GTID=200)
				From ItemStockDetail as SDet
				Where  
					SDet.StockID = ItemStock.StockID And 
					SDet.RefID = @i_PIID And
					ItemStock.StockID IN (Select StockID From ItemStockDetail
						Where ItemStockDetail.RefID = @i_PIID And ItemStockDetail.GTID=200) 

				-- Delete Record from StockDistrictDetail Table
				DELETE FROM ItemStockDetail WHERE RefID = @i_PIID AND GTID = 200;
			 	 
				Delete From Ledger Where TransactionTypeID=2 And TransactionID = @i_PIID

				Delete From PurchaseInvoiceDetail Where PIID = @i_PIID;

 			 -- Update Record IN PurchaseInvoice		
				UPDATE
					PurchaseInvoice
				SET
					PurchaseCode = @i_PurchaseCode, 
					PurchaseDate=@i_PurchaseDate,   
					SrNo = @i_SrNo ,
					FYID=@i_FYID,
					VendorID=@i_VendorID,  
					VoucherNo = @i_VoucherNo ,   
					VoucherDate = @i_VoucherDate,   
					DueDate = @i_DueDate,
					DueDays = @i_DueDays,
					TotalAmount = @i_TotalAmount,   
					ServiceAmount = @i_ServiceAmount,
					ExciseAmount = @i_ExciseAmount,   
					CessAmount = @i_CessAmount,   
					HCessAmount = @i_HCessAmount,   
					AmountAfterExcise = @i_AmountAfterExcise,
					CSTAmount = @i_CSTAmount,   
					VATAmount = @i_VATAmount,   
					AVATAmount = @i_AVATAmount,   
					Discount = @i_Discount,
					NetAmount = @i_NetAmount,
					PaidAmount = @i_PaidAmount,
					Narration=@i_Narration,
					GodownID=@i_GodownID
				WHERE
					PIID = @i_PIID

 				-- Vendor''s Ledger Effect
				Select @l_VendorAccID = AccountID From Vendor Where VendorID = @i_VendorID
				---Insert Record in Ledger
				Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
							Values(@l_VendorAccID,@i_FYID, 2,				   @i_PIID, @i_PurchaseDate,0.000,@i_NetAmount,@l_LedNarration );

				Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
							Values(@l_VendorAccID,@i_FYID, 2,				   @i_PIID, @i_PurchaseDate,@i_PaidAmount,0.000,@l_LedNarration );
				-- Insert Record for Basic Excise Amount
				If @i_ServiceAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID, FYID,TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(10,           @i_FYID,2,				     @i_PIID,   @i_PurchaseDate,0.00,@i_ServiceAmount,@l_LedNarration);
				End
				-- Insert Record for Basic Excise Amount
				If @i_ExciseAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(2,   @i_FYID,        2,				     @i_PIID,   @i_PurchaseDate,@i_ExciseAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for Cess On Excise Amount
				If @i_CessAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID ,TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(3,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_CessAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for H Cess On Excise Amount
				If @i_HCessAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(4,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_HCessAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for CST On Excise Amount
				If @i_CSTAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(5,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_CSTAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for VAT On Excise Amount
				If @i_VATAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(6,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_VATAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for AVAT On Excise Amount
				If @i_AVATAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(7,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_AVATAmount,0.00,@l_LedNarration);
				End


			---Insert Record in Ledger For Cash
				Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
							Values(	1,		@i_FYID,	2,				     @i_PIID,   @i_PurchaseDate,0.00,@i_PaidAmount,@l_LedNarration);

 
				---Procedure For Insert Record into Purchase Invoice Detail Table...
				IF @i_Cnt > 0
				BEGIN		
					SELECT  x.d.value(''ItemID[1]'',''Bigint'') AS ItemID,							
						x.d.value(''Qty[1]'',''Decimal(18,3)'') AS Qty,
						x.d.value(''Rate[1]'',''Decimal(18,2)'') AS Rate,
						x.d.value(''Amount[1]'',''Decimal(18,2)'') AS Amount,
						x.d.value(''TaxClassID[1]'',''Bigint'') AS TaxClassID,
						x.d.value(''ServiceRate[1]'',''Decimal(5,2)'') AS ServiceRate,						
						x.d.value(''ServiceAmount[1]'',''Decimal(18,2)'') AS ServiceAmount,
						x.d.value(''ExciseRate[1]'',''Decimal(5,2)'') AS ExciseRate,						
						x.d.value(''ExciseAmount[1]'',''Decimal(18,2)'') AS ExciseAmount,
						x.d.value(''EduCessRate[1]'',''Decimal(5,2)'') AS EduCessRate,						
						x.d.value(''EduCessAmount[1]'',''Decimal(18,2)'') AS EduCessAmount,
						x.d.value(''HEduCessRate[1]'',''Decimal(5,2)'') AS HEduCessRate,						
						x.d.value(''HEduCessAmount[1]'',''Decimal(18,2)'') AS HEduCessAmount,
						x.d.value(''AmountAfterExcise[1]'',''Decimal(18,2)'') AS AmountAfterExcise,						
						x.d.value(''CSTRate[1]'',''Decimal(5,2)'') AS CSTRate,
						x.d.value(''CSTAmount[1]'',''Decimal(18,2)'') AS CSTAmount,
						x.d.value(''VATRate[1]'',''Decimal(5,2)'') AS VATRate,	
						x.d.value(''VATAmount[1]'',''Decimal(18,2)'') AS VATAmount,
						x.d.value(''AVATRate[1]'',''Decimal(5,2)'') AS AVATRate,
						x.d.value(''AVATAmount[1]'',''Decimal(18,2)'') AS AVATAmount,
						x.d.value(''NetAmount[1]'',''Decimal(18,2)'') AS NetAmount	
					INTO #tmpDetail				
					FROM 
						@i_XMLString.nodes(''/NewDataSet/Table'') x(d);

					INSERT INTO PurchaseInvoiceDetail (PIID,   ItemID,   Qty,   Rate,  Amount,   TaxClassID,ServiceRate,   ServiceAmount,     ExciseRate,  ExciseAmount,      CessRate,      CessAmount,   HCessRate,   HCessAmount,   AmountAfterExcise,   CSTRate,   CSTAmount,   VATRate,   VATAmount,   AVATRate,   AVATAmount,   NetAmount)
											SELECT @i_PIID,T1.ItemID,T1.Qty,T1.Rate,T1.Amount,T1.TaxClassID,T1.ServiceRate,T1.ServiceAmount,T1.ExciseRate,T1.ExciseAmount,T1.EduCessRate,T1.EduCessAmount,T1.HEduCessRate,T1.HEduCessAmount,T1.AmountAfterExcise,T1.CSTRate,T1.CSTAmount,T1.VATRate,T1.VATAmount,T1.AVATRate,T1.AVATAmount,T1.NetAmount FROM #tmpDetail T1 

				SET @l_Description = ''Against Purchase Invoice : '' + @i_PurchaseCode; 
				Insert Into ItemStock(FYID,      ItemID,    QOH, MinLevel, MaxLevel, ReorderLvl, CreatedBy, CreatedDate , GodownID)
 							Select @i_FYID,#tmpDetail.ItemID, 0, 0, 0, 0, @i_UserID, @i_PurchaseDate , @i_GodownID
							From #tmpDetail Where #tmpDetail.ItemID Not In(
								Select ItemStock.ItemID From ItemStock WHERE ItemStock.FYID = @i_FYID)
				
				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
					Select ItemStock.StockID, 100,ItemStock.StockID, @i_PurchaseDate, ''Opening Stock'',0.000
						From #tmpDetail 
							Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
							Where ItemStock.QOH = 0 And ItemStock.FYID = @i_FYID
								And ItemStock.StockID Not In (Select StockID from ItemStockDetail Where 
									ItemStockDetail.StockID = ItemStock.StockID And ItemStockDetail.GTID=100)

				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
						Select ItemStock.StockID, 200,@i_PIID, @i_PurchaseDate, @l_Description,  #tmpDetail.Qty
							From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
							Where ItemStock.FYID = @i_FYID
		 				
				-- Update Stock
				Update ItemStock 
					Set ItemStock.QOH = ItemStock.QOH +
						(Select Sum(#tmpDetail.Qty) From #tmpDetail Where ItemStock.ItemID = #tmpDetail.ItemID )
				From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
				Where 
					ItemStock.FYID = @i_FYID  and GodownID=@i_GodownID
 				END
			  END
		  ELSE
			  BEGIN
					SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 23001 );
			  END		
		
	COMMIT TRAN
	END TRY
		BEGIN CATCH 
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );  
		ROLLBACK TRAN  
	END CATCH 
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Customer_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record in Customer Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_Customer_Insert]	
	@i_FYID BIGINT,
	@i_AccountID bigint,
	@i_CustomerCode varchar(20),
	@i_CustomerName Varchar(100),
	@i_Address Varchar(150),
	@i_CityID Bigint,
	@i_AreaID int,
	@i_Pincode varchar(20),
	@i_Phone1 varchar(20),
	@i_MobileNo varchar(20),
	@i_Email varchar(150),
	@i_Website nvarchar(50),
	@i_ContactPerson nvarchar(250),
--	@i_EmpID int,
--	@i_AllocatedToEmpID int,
	@i_Category varchar(50),
	@i_IsAccount Bigint,
	@i_Specification varchar(250),
	@i_Remarks varchar(MAX),
	@i_CreditDays int,
	@i_Name1 nvarchar(50),
	@i_Name2 nvarchar(50),
	@i_Name3 nvarchar(50),
	@i_Name4 nvarchar(50),
	@i_Name5 nvarchar(50),
	@i_Name6 nvarchar(50),
	@i_Value1 nvarchar(50),
	@i_Value2 nvarchar(50),
	@i_Value3 nvarchar(50),
	@i_Value4 nvarchar(50),
	@i_Value5 nvarchar(50),
	@i_Value6 nvarchar(50),
	@i_CompId bigint,	
	@i_TransactionDate Datetime,
	@i_CRAmount Decimal(18,2),
	@i_DBAmount Decimal(18,2),		
	@i_UserID bigint,
--	@i_LeadId int,	
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	Declare @l_AccountID Bigint
	declare @l_CustomerID bigint
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;
	Set @l_AccountID = 0

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	SELECT @l_varRec = Count(CustomerID) FROM CustomerMain WHERE Upper(CustomerCode) = Upper(@i_CustomerCode) ;
	IF @l_varRec=0
		BEGIN
			SELECT @l_varRec = Count(CustomerID) FROM CustomerMain WHERE Upper(CustomerName) = Upper(@i_CustomerName) ;
			IF @l_varRec=0
				BEGIN
					If @i_IsAccount = 1
					Begin
						Select @l_varRec = Count(AccountID) From Account Where AccountCode = @i_CustomerCode;
						If @l_varRec = 0 
						Begin
							Select @l_varRec = Count(AccountID) From Account Where AccountName = @i_CustomerName;
							If @l_varRec = 0 
							Begin
									Insert Into Account (AccountCode, AccountName, AccCreatedDate,AccTypeID )
												Values (@i_CustomerCode, @i_CustomerName,@i_TransactionDate,3);
										Set @l_AccountID = Scope_Identity();
						
									Insert Into OpeningBalance (  FYID,AccountID, CRAmount, DBAmount)
														Values(@i_FYID,@l_AccountID ,@i_CRAmount,@i_DBAmount);
								
							Insert Into Ledger (  FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
										Values(@i_FYID,@l_AccountID,   1,				  @l_AccountID, @i_TransactionDate, @i_CRAmount, @i_DBAmount,''Opening Balance'');
							End
							Else
							Begin
								-- Account Name is Already Exist..
								SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 24004 );
							End	
						End
						Else
						Begin
							-- Account Code is Already Exist.
							SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 24003 );
						End
					END	
					Else
					Begin
						Set @l_AccountID = NULL
					End

					INSERT INTO CustomerMain( AccountID,   CustomerCode,   CustomerName,   Address,CityID,AreaID,   Pincode,   Phone1,   MobileNo, Email,   Website,ContactPerson, Category,IsAccount,Specification,Remarks,   CreditDays,Name1,Name2,Name3,Name4,Name5,Name6,Value1,Value2,Value3,Value4,Value5,Value6,CompId, CreatedBy,CreatedDate)
					VALUES
					(@l_AccountID,@i_CustomerCode,@i_CustomerName,@i_Address,@i_CityID,@i_AreaID,@i_Pincode,
					@i_Phone1,@i_MobileNo,@i_Email,@i_Website,@i_ContactPerson, @i_Category,
					@i_IsAccount,@i_Specification,@i_Remarks,@i_CreditDays,@i_Name1,@i_Name2,@i_Name3,@i_Name4,@i_Name5,@i_Name6,@i_Value1,@i_Value2,@i_Value3,@i_Value4,@i_Value5,@i_Value6,@i_CompId,@i_UserID,@l_Date)

Set @l_CustomerID = Scope_Identity();

--update 

			End
			ELSE
				BEGIN
					SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 24002 );
				END
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 24001 );
		END

END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Indent_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 24th jan 2011
-- Description:	Update record of Purchase Invoice and Purchase Invoice Detail
-- =============================================
CREATE PROCEDURE [dbo].[usp_Indent_Update]
	@i_PIID Bigint,
	@i_PurchaseCode Varchar(20),
	@i_FYID Bigint,
	@i_PurchaseDate DateTime,
	@i_SrNo Varchar(50),
	@i_VoucherNo Varchar(20),
	@i_VoucherDate DATETIME,
	@i_VendorID Bigint,
	@i_DueDays Bigint,
	@i_DueDate DateTime,
	@i_TotalAmount Decimal(18,2),
	@i_ServiceAmount  Decimal(18,2),	
	@i_ExciseAmount  Decimal(18,2),	
	@i_CessAmount Decimal(18,2),
	@i_HCessAmount Decimal(18,2),
	@i_AmountAfterExcise Decimal(18,2),
	@i_CSTAmount Decimal(18,2),
	@i_VATAmount Decimal(18,2),
	@i_AVATAmount Decimal(18,2),
	@i_Discount DECIMAL(18,2),
	@i_NetAmount  Decimal(18,2),
	@i_PaidAmount  Decimal(18,2),
	@i_Narration Varchar(250),
	@i_XMLString xml,
	@i_Cnt Bigint,
	@i_UserID BIGINT,
	@i_GodownID int,
    @i_tempQty Decimal(18,2),
	@i_PGID bigint,
	@i_AgainstCForm bit,
	@o_ErrorMesg Varchar(200) OUTPUT

AS
BEGIN
	SET NOCOUNT ON;

    -- Declare Local Variables...
	DECLARE @l_varRec Bigint;
 	DECLARE @l_VendorAccID Bigint
	DECLARE @l_LedNarration varchar(50)
	 
 
	DECLARE @l_Description varchar(100);
	-- Set Local Variable value..
	SET @l_varRec = 0;
	SET @l_Description  = ''''
	SET @l_VendorAccID = 0
	SET @l_LedNarration =''''
 
 
	-- Variable for StockDetail
 
	SET @o_ErrorMesg='''';
 


	BEGIN TRY  
	BEGIN TRAN
 
 	SELECT @l_varRec = Count(PIID) From Indent Where PurchaseCode = @i_PurchaseCode AND PIID <> @i_PIID
 		IF @l_varRec = 0
 			BEGIN
 				Set @l_LedNarration  = ''Purchase Against '' + @i_PurchaseCode
 					-- Delete Stock	
				Update ItemStock
					Set ItemStock.QOH =  ItemStock.QOH - isnull(@i_tempQty,0)
--						(Select IsNull(Sum(ItemStockDetail.Qty),0)
--							From ItemStockDetail Where  ItemStockDetail.StockID = ItemStock.StockID 
--								And ItemStockDetail.RefID = @i_PIID And ItemStockDetail.GTID=200)
				From ItemStockDetail as SDet
				Where  
					SDet.StockID = ItemStock.StockID And 
					SDet.RefID = @i_PIID And
					ItemStock.StockID IN (Select StockID From ItemStockDetail
						Where ItemStockDetail.RefID = @i_PIID And ItemStockDetail.GTID=200) 

				-- Delete Record from StockDistrictDetail Table
				DELETE FROM ItemStockDetail WHERE RefID = @i_PIID AND GTID = 200;
			 	 
				Delete From Ledger Where TransactionTypeID=2 And TransactionID = @i_PIID

				Delete From IndentDetail Where PIID = @i_PIID;

 			 -- Update Record IN PurchaseInvoice		
				UPDATE
					Indent
				SET
					PurchaseCode = @i_PurchaseCode, 
					PurchaseDate=@i_PurchaseDate,   
					SrNo = @i_SrNo ,
					FYID=@i_FYID,
					VendorID=@i_VendorID,  
					VoucherNo = @i_VoucherNo ,   
					VoucherDate = @i_VoucherDate,   
					DueDate = @i_DueDate,
					DueDays = @i_DueDays,
					TotalAmount = @i_TotalAmount,   
					ServiceAmount = @i_ServiceAmount,
					ExciseAmount = @i_ExciseAmount,   
					CessAmount = @i_CessAmount,   
					HCessAmount = @i_HCessAmount,   
					AmountAfterExcise = @i_AmountAfterExcise,
					CSTAmount = @i_CSTAmount,   
					VATAmount = @i_VATAmount,   
					AVATAmount = @i_AVATAmount,   
					Discount = @i_Discount,
					NetAmount = @i_NetAmount,
					PaidAmount = @i_PaidAmount,
					Narration=@i_Narration,
					GodownID=@i_GodownID,
					PGID =  @i_PGID ,
					AgainstCForm=@i_AgainstCForm
				WHERE
					PIID = @i_PIID

 				-- Vendor''s Ledger Effect
				Select @l_VendorAccID = AccountID From Vendor Where VendorID = @i_VendorID
				---Insert Record in Ledger
				Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
							Values(@l_VendorAccID,@i_FYID, 2,				   @i_PIID, @i_PurchaseDate,0.000,@i_NetAmount,@l_LedNarration );

				Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
							Values(@l_VendorAccID,@i_FYID, 2,				   @i_PIID, @i_PurchaseDate,@i_PaidAmount,0.000,@l_LedNarration );
				-- Insert Record for Basic Excise Amount
				If @i_ServiceAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID, FYID,TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(10,           @i_FYID,2,				     @i_PIID,   @i_PurchaseDate,0.00,@i_ServiceAmount,@l_LedNarration);
				End
				-- Insert Record for Basic Excise Amount
				If @i_ExciseAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(2,   @i_FYID,        2,				     @i_PIID,   @i_PurchaseDate,@i_ExciseAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for Cess On Excise Amount
				If @i_CessAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID ,TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(3,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_CessAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for H Cess On Excise Amount
				If @i_HCessAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(4,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_HCessAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for CST On Excise Amount
				If @i_CSTAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(5,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_CSTAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for VAT On Excise Amount
				If @i_VATAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(6,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_VATAmount,0.00,@l_LedNarration);
				End
				-- Insert Record for AVAT On Excise Amount
				If @i_AVATAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(7,        @i_FYID,   2,				     @i_PIID,   @i_PurchaseDate,@i_AVATAmount,0.00,@l_LedNarration);
				End


			---Insert Record in Ledger For Cash
				Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
							Values(	1,		@i_FYID,	2,				     @i_PIID,   @i_PurchaseDate,0.00,@i_PaidAmount,@l_LedNarration);

 
				---Procedure For Insert Record into Purchase Invoice Detail Table...
				IF @i_Cnt > 0
				BEGIN		
					SELECT  x.d.value(''ItemID[1]'',''Bigint'') AS ItemID,							
						x.d.value(''Qty[1]'',''Decimal(18,3)'') AS Qty,
						x.d.value(''Rate[1]'',''Decimal(18,2)'') AS Rate,
						x.d.value(''Amount[1]'',''Decimal(18,2)'') AS Amount,
						x.d.value(''TaxClassID[1]'',''Bigint'') AS TaxClassID,
						x.d.value(''ServiceRate[1]'',''Decimal(5,2)'') AS ServiceRate,						
						x.d.value(''ServiceAmount[1]'',''Decimal(18,2)'') AS ServiceAmount,
						x.d.value(''ExciseRate[1]'',''Decimal(5,2)'') AS ExciseRate,						
						x.d.value(''ExciseAmount[1]'',''Decimal(18,2)'') AS ExciseAmount,
						x.d.value(''EduCessRate[1]'',''Decimal(5,2)'') AS EduCessRate,						
						x.d.value(''EduCessAmount[1]'',''Decimal(18,2)'') AS EduCessAmount,
						x.d.value(''HEduCessRate[1]'',''Decimal(5,2)'') AS HEduCessRate,						
						x.d.value(''HEduCessAmount[1]'',''Decimal(18,2)'') AS HEduCessAmount,
						x.d.value(''AmountAfterExcise[1]'',''Decimal(18,2)'') AS AmountAfterExcise,						
						x.d.value(''CSTRate[1]'',''Decimal(5,2)'') AS CSTRate,
						x.d.value(''CSTAmount[1]'',''Decimal(18,2)'') AS CSTAmount,
						x.d.value(''VATRate[1]'',''Decimal(5,2)'') AS VATRate,	
						x.d.value(''VATAmount[1]'',''Decimal(18,2)'') AS VATAmount,
						x.d.value(''AVATRate[1]'',''Decimal(5,2)'') AS AVATRate,
						x.d.value(''AVATAmount[1]'',''Decimal(18,2)'') AS AVATAmount,
						x.d.value(''NetAmount[1]'',''Decimal(18,2)'') AS NetAmount,
						x.d.value(''RemainingQty[1]'',''Decimal(18,3)'') AS RemainingQty,
						x.d.value(''ReceivedQty[1]'',''Decimal(18,3)'') AS ReceivedQty	,
                        x.d.value(''DDate[1]'',''datetime'') AS DDate	
					INTO #tmpDetail				
					FROM 
						@i_XMLString.nodes(''/NewDataSet/Table'') x(d);

					INSERT INTO IndentDetail (PIID,   ItemID,   Qty,   Rate,  Amount,   TaxClassID,ServiceRate,   ServiceAmount,     ExciseRate,  ExciseAmount,      CessRate,      CessAmount,   HCessRate,   HCessAmount,   AmountAfterExcise,   CSTRate,   CSTAmount,   VATRate,   VATAmount,   AVATRate,   AVATAmount,   NetAmount,RemainingQty,ReceivedQty,DDate)
											SELECT @i_PIID,T1.ItemID,T1.Qty,T1.Rate,T1.Amount,T1.TaxClassID,T1.ServiceRate,T1.ServiceAmount,T1.ExciseRate,T1.ExciseAmount,T1.EduCessRate,T1.EduCessAmount,T1.HEduCessRate,T1.HEduCessAmount,T1.AmountAfterExcise,T1.CSTRate,T1.CSTAmount,T1.VATRate,T1.VATAmount,T1.AVATRate,T1.AVATAmount,T1.NetAmount,T1.RemainingQty,T1.ReceivedQty,T1.DDate FROM #tmpDetail T1 

				SET @l_Description = ''Against Purchase Invoice : '' + @i_PurchaseCode; 
				Insert Into ItemStock(FYID,      ItemID,    QOH, MinLevel, MaxLevel, ReorderLvl, CreatedBy, CreatedDate , GodownID)
 							Select @i_FYID,#tmpDetail.ItemID, 0, 0, 0, 0, @i_UserID, @i_PurchaseDate , @i_GodownID
							From #tmpDetail Where #tmpDetail.ItemID Not In(
								Select ItemStock.ItemID From ItemStock WHERE ItemStock.FYID = @i_FYID)
				
				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
					Select ItemStock.StockID, 100,ItemStock.StockID, @i_PurchaseDate, ''Opening Stock'',0.000
						From #tmpDetail 
							Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
							Where ItemStock.QOH = 0 And ItemStock.FYID = @i_FYID
								And ItemStock.StockID Not In (Select StockID from ItemStockDetail Where 
									ItemStockDetail.StockID = ItemStock.StockID And ItemStockDetail.GTID=100)

				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
						Select ItemStock.StockID, 200,@i_PIID, @i_PurchaseDate, @l_Description,  #tmpDetail.ReceivedQty
							From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
							Where ItemStock.FYID = @i_FYID
		 				
				-- Update Stock
				Update ItemStock 
					Set ItemStock.QOH = ItemStock.QOH +
						(Select Sum(#tmpDetail.ReceivedQty) From #tmpDetail Where ItemStock.ItemID = #tmpDetail.ItemID )
				From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
				Where 
					ItemStock.FYID = @i_FYID  and GodownID=@i_GodownID
 				END
			  END
		  ELSE
			  BEGIN
					SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 23001 );
			  END		
		
	COMMIT TRAN
	END TRY
		BEGIN CATCH 
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );  
		ROLLBACK TRAN  
	END CATCH 
END








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Customer_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Update record in Customer Table
-- =============================================
 CREATE PROCEDURE [dbo].[usp_Customer_Update]
	@i_CustomerID Bigint,
	@i_FYID BIGINT,
	@i_AccountID bigint,
--	@i_CustomerCode varchar(20),
	@i_CustomerName Varchar(100),
	@i_Address Varchar(150),
	@i_CityID Bigint,
	@i_AreaID int,
	@i_Pincode varchar(20),
	@i_Phone1 varchar(20),
	@i_MobileNo varchar(20),
	@i_Email varchar(150),
	@i_Website nvarchar(50),
	@i_ContactPerson nvarchar(250),
--	@i_EmpID int,
--	@i_AllocatedToEmpID int,
	@i_Category varchar(50),
	@i_IsAccount Bigint,
	@i_Specification varchar(250),
	@i_Remarks varchar(MAX),
	@i_CreditDays int,
	@i_Name1 nvarchar(50),
	@i_Name2 nvarchar(50),
	@i_Name3 nvarchar(50),
	@i_Name4 nvarchar(50),
	@i_Name5 nvarchar(50),
	@i_Name6 nvarchar(50),
	@i_Value1 nvarchar(50),
	@i_Value2 nvarchar(50),
	@i_Value3 nvarchar(50),
	@i_Value4 nvarchar(50),
	@i_Value5 nvarchar(50),
	@i_Value6 nvarchar(50),
	@i_CompId bigint,	
	@i_TransactionDate Datetime,
	@i_CRAmount Decimal(18,2),
	@i_DBAmount Decimal(18,2),		
	@i_UserID bigint,
--	@i_Code varchar(20),
--	@i_Name Varchar(100),
--	@i_Address1 Varchar(100),
--	@i_Address2 Varchar(100),
--	@i_CityID Bigint,
--	@i_Pincode varchar(20),
--	@i_Phone1 varchar(20),
--	@i_Phone2 varchar(20),
--	@i_Fax varchar(150),
--	@i_Mobile varchar(20),
--	@i_TinNo varchar(20),
--	@i_CSTNo varchar(20),
--	@i_PANo varchar(20),
--	@i_EccNo varchar(20),
--	@i_CreditDays int,
--	@i_Range Varchar(50),
--	@i_Division Varchar(50),
--	@i_TransactionDate Datetime,
--	@i_CRAmount Decimal(18,2),
--	@i_DBAmount Decimal(18,2),
--	@i_LeadId int,	
--	@i_IsAccount Bigint,
--	@i_UserID bigint,
--	@i_ContactPerson nvarchar(250),
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	SELECT @l_varRec = Count(CustomerID) FROM CustomerMain WHERE Upper(CustomerName) = Upper(@i_CustomerName) AND CustomerID <> @i_CustomerID;
	IF @l_varRec=0
		BEGIN
			
					UPDATE CustomerMain
						SET
							CustomerName = @i_CustomerName,
							Address = @i_Address,							
							CityID = @i_CityID,
							Pincode = @i_Pincode,
							Phone1 = @i_Phone1,
							MobileNo = @i_MobileNo,
							Email = @i_Email,
							ContactPerson=@i_ContactPerson,
							AreaID =@i_AreaID,
--							EmpID=@i_EmpID, 
							Website=@i_Website,
							Name1=@i_Name1,
							Name2=@i_Name2,
							Name3=@i_Name3,
							Name4=@i_Name4,
							Name5=@i_Name5,
							Name6=@i_Name6,
							Value1=@i_Value1,
							Value2=@i_Value2,
							Value3=@i_Value3,
							Value4=@i_Value4,
							Value5=@i_Value5,
							Value6=@i_Value6,
							Category=@i_Category,
--							AllocatedToEmpID=@i_AllocatedToEmpID,
							CompId=@i_CompId,
							Specification = @i_Specification, 
							Remarks = @i_Remarks,							
							CreditDays = @i_CreditDays,							
							IsAccount = @i_IsAccount,
							ModifiedBy = @i_UserID,
							ModifiedDate = @l_Date
--							LeadId=@i_LeadId,
--							ContactPerson=@i_ContactPerson
					WHERE
						CustomerID = @i_CustomerID;
				
				
	End

	ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 240002 );
		END
		
END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CompanyInfo_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Insert record in Lead Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_CompanyInfo_Insert]

	@i_CompanyName varchar(100),
	@i_BusinessLine varchar(50),
	@i_Address1 varchar(150),
	@i_Address2 varchar(150),
	@i_CityName varchar(50),
	@i_State varchar(50),
	@i_Pincode varchar(50),
	@i_Phone1 varchar(15),
	@i_Phone2 varchar(15),
	@i_Mobile varchar(15),
	
	@i_Email varchar(50),
	
	@i_Logo nvarchar(max),
	@i_Header nvarchar(max),
	@i_Footer nvarchar(max),
	@i_Name1 nvarchar(50),
	@i_Name2 nvarchar(50),
	@i_Name3 nvarchar(50),
	@i_Name4 nvarchar(50),
	@i_Name5 nvarchar(50),
	@i_Name6 nvarchar(50),
	@i_Value1 nvarchar(50),
	@i_Value2 nvarchar(50),
	@i_Value3 nvarchar(50),
	@i_Value4 nvarchar(50),
	@i_Value5 nvarchar(50),
	@i_Value6 nvarchar(50),
	@i_Com_Profile nvarchar(max),
	@i_ReportPath nvarchar(max),
@i_DocPath nvarchar(max),
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
declare @ComName varchar(100)
declare @Sub1 varchar(100)
declare @Sub2 varchar(100)
declare @car varchar(100)

--select @ComName=CompanyCode from CompanyInfo where CompId=@i_CompId 
set @ComName=@i_CompanyName
set @Sub1=@ComName
set @Sub2=@ComName

if CHARINDEX('' '',@ComName) > 0
begin
    PRINT ''SPACE IN STRING'' 
	set @Sub1=SUBSTRING(@ComName, 1, CHARINDEX('' '', @ComName) - 1)
set @Sub2=SUBSTRING(@ComName, CHARINDEX('' '', @ComName) + 1, 8000) 
set @car=LEFT(@Sub1, 1)+LEFT(@Sub2, 1)  
PRINT @car
end
ELSE
BEGIN 
PRINT ''NO SPACE''
	set @Sub1=@ComName
 set @car=LEFT(@Sub1, 2) 
PRINT @car
END
	

--	SELECT @l_varRec = Count(CompId) FROM CompanyInfo WHERE Upper(CompanyCode) = Upper(@i_CompanyCode);
	IF @l_varRec=0
		BEGIN 
			INSERT INTO CompanyInfo(    CompanyName,CompanyCode,   BusinessLine,   Address1,   Address2,   CityName,   State,   Pincode,   Phone1,Phone2,Mobile,Email,Logo,Header,Footer,Name1,Name2,Name3,Name4,name5,Name6,Value1,Value2,Value3,Value4,Value5,Value6,Com_Profile,ReportPath,DocPath )
	
					VALUES(   @i_CompanyName,@car,   @i_BusinessLine,   @i_Address1,   @i_Address2,   @i_CityName,   @i_State,   @i_Pincode,   @i_Phone1,@i_Phone2,@i_Mobile,@i_Email,@i_Logo,@i_Header,@i_Footer,@i_Name1,@i_Name2,@i_Name3,@i_Name4,@i_Name5,@i_Name6,@i_Value1,@i_Value2,@i_Value3,@i_Value4,@i_Value5,@i_Value6,@i_Com_Profile,@i_ReportPath,@i_DocPath )
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 14001 );
		END

END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_VendorPayment_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 26th Jan 2011
-- Description:	Insert record of Payment and Payment Detail
-- =============================================

CREATE PROCEDURE [dbo].[usp_VendorPayment_Insert]
	@i_FYID BIGINT,
	@i_PaymentCode Varchar(20),
	@i_PaymentDate DateTime,
	@i_VendorID Bigint,
	@i_NetAmount Decimal(15,3),
	@i_Narration Varchar(250),
	@i_BankName	varchar(150),
	@i_ChequeNo	varchar(50),
	@i_ChequeDate Datetime= null,
	@i_XMLString xml,
	@i_Cnt Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
 	SET NOCOUNT ON;

   -- Declare Local Variables...
	Declare @l_varRec Bigint;
	Declare @l_VendorAccID Bigint
	Declare @l_LedNarration varchar(50)
	Declare @l_NewDetID Bigint
	Declare @l_NewID Bigint
	-- Set Local Variable value..
	Set @l_varRec = 0;
	Set @o_ErrorMesg='''';	
	Set @l_VendorAccID = 0
	Set @l_LedNarration =''''
	Set @l_NewDetID = 0
	Set @l_NewID = 0
	-- Variable for StockDetail
	DECLARE @l_PIID Bigint;
	Declare @l_PaidAmount decimal(15,3)

	SET @l_PIID = 0;
	Set @l_PaidAmount = 0.000
	 
--	BEGIN TRY  
--	BEGIN TRAN

		SELECT @l_varRec = Count(PaymentID) From Payment Where PaymentCode = @i_PaymentCode
		IF @l_varRec = 0
			BEGIN

				Set @l_LedNarration  = ''Payment Against '' + @i_PaymentCode
	
				--Insert Record into Payment Table...
					Insert Into Payment(  PaymentCode,   PaymentDate,   VendorID,   Narration,   NetAmount,BankName,ChequeNo,ChequeDate)
		     					Values(@i_PaymentCode,@i_PaymentDate,@i_VendorID,@i_Narration,@i_NetAmount,@i_BankName,@i_ChequeNo,@i_ChequeDate)
					SET @l_NewID = Scope_Identity();
				
					Select @l_VendorAccID = AccountID From Vendor Where VendorID = @i_VendorID
					---Insert Record in Ledger
					Insert Into Ledger (  FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(@i_FYID,@l_VendorAccID, 5,				     @l_NewID, @i_PaymentDate ,@i_NetAmount ,0.000,@l_LedNarration );
		 
					---Insert Record in Ledger
					Insert Into Ledger (   FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values( @i_FYID,   1,       5,				     @l_NewID,         @i_PaymentDate ,0.00,@i_NetAmount,@l_LedNarration);


					---Procedure For Insert Record into Sales Invoice Detail Table...
					While @i_Cnt>0
					BEGIN									
						SELECT  @l_PIID = x.d.value(''PIID[1]'',''Bigint'') ,
								@l_PaidAmount = x.d.value(''PaidAmount[1]'',''Decimal(18,2)'')								
						FROM @i_XMLString.nodes(''/NewDataSet/Table[position()=sql:variable("@i_Cnt")]'') x(d);

						--Statement For Insert Record into Purchase Invoice Detail Table
						Insert Into PaymentDetail( PaymentID,   PIID,    Amount)
									         Values(@l_NewID,@l_PIID,@l_PaidAmount)
						Set @l_NewDetID = Scope_Identity(); 
						 
						Update Indent 
						Set
							PaidAmount = PaidAmount + @l_PaidAmount
						Where PIID = @l_PIID;

						Set @i_Cnt = @i_Cnt - 1;
					END
			  END
		  ELSE
			  BEGIN
				 
					SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=20001 );
			  END			
		
--	COMMIT TRAN
--	END TRY
--		BEGIN CATCH 
--			SET @ErrorNo = 100     
--		ROLLBACK TRAN  
--	END CATCH 	

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_VendorPayment_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 26th Jan 2011
-- Description:	Update record of Payment and Payment Detail
-- =============================================
CREATE PROCEDURE [dbo].[usp_VendorPayment_Update]
	@i_PaymentID Bigint,
	@i_FYID BIGINT,
	@i_PaymentCode Varchar(20),
	@i_PaymentDate DateTime,
	@i_VendorID Bigint,
	@i_NetAmount Decimal(15,3),
	@i_Narration Varchar(250),
	@i_BankName	varchar(150),
	@i_ChequeNo	varchar(50),
	@i_ChequeDate Datetime= null,
	@i_XMLString xml,
	@i_Cnt Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
 	SET NOCOUNT ON;

   -- Declare Local Variables...
	Declare @l_varRec Bigint;
	Declare @l_VendorAccID Bigint
	Declare @l_LedNarration varchar(50)
	Declare @l_NewDetID Bigint

	-- Set Local Variable value..
	Set @l_varRec = 0;
	Set @l_VendorAccID = 0
	Set @l_LedNarration =''''
	Set @l_NewDetID = 0
	SET @o_ErrorMesg = ''''

	-- Variable for StockDetail
	DECLARE @l_PIID Bigint;
	Declare @l_PaidAmount decimal(15,3)

	SET @l_PIID = 0;
	Set @l_PaidAmount = 0.000
	 
--	BEGIN TRY  
--	BEGIN TRAN

		SELECT @l_varRec = Count(PaymentID) From Payment Where PaymentCode = @i_PaymentCode And PaymentID <> @i_PaymentID
		IF @l_varRec = 0
			BEGIN

				Set @l_LedNarration  = ''Payment Against '' + @i_PaymentCode
	
				--Insert Record into Payment Table...
					Update Payment
					Set PaymentDate = @i_PaymentDate, 
						Narration = @i_Narration,
						NetAmount = @i_NetAmount,
						BankName=@i_BankName,ChequeNo=@i_ChequeNo,ChequeDate=@i_ChequeDate
					Where PaymentID = @i_PaymentID
			
				
					Update Indent 
					Set
						Indent.PaidAmount = Indent.PaidAmount - PaymentDetail.Amount
					From PaymentDetail
					Where PaymentDetail.PIID = Indent.PIID And 
						PaymentDetail.PaymentID = @i_PaymentID
							
					Delete From Ledger Where TransactionTypeID = 5 And TransactionID = @i_PaymentID
					Delete From PaymentDetail Where PaymentID = @i_PaymentID;					

					Select @l_VendorAccID = AccountID From Vendor Where VendorID = @i_VendorID
					---Insert Record in Ledger
					Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(@i_FYID,@l_VendorAccID, 5,				     @i_PaymentID, @i_PaymentDate ,@i_NetAmount ,0.000,@l_LedNarration );
		 
					---Insert Record in Ledger
					Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(@i_FYID,   1,       5,				     @i_PaymentID,         @i_PaymentDate ,0.00,@i_NetAmount,@l_LedNarration);


					While @i_Cnt>0
					BEGIN									
						SELECT  @l_PIID = x.d.value(''PIID[1]'',''Bigint'') ,
								@l_PaidAmount = x.d.value(''PaidAmount[1]'',''Decimal(15,3)'')								
						FROM @i_XMLString.nodes(''/NewDataSet/Table[position()=sql:variable("@i_Cnt")]'') x(d);

						--Statement For Insert Record into Purchase Invoice Detail Table
						Insert Into PaymentDetail( PaymentID,   PIID,    Amount)
									         Values(@i_PaymentID,@l_PIID,@l_PaidAmount)
						Set @l_NewDetID = Scope_Identity(); 
						 
						Update Indent 
						Set
							PaidAmount = PaidAmount + @l_PaidAmount
						Where PIID = @l_PIID;

						Set @i_Cnt = @i_Cnt - 1;
					END
			  END
		  ELSE
			  BEGIN
					SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=20001 );
			  END			
		
--	COMMIT TRAN
--	END TRY
--		BEGIN CATCH 
--			SET @ErrorNo = 100     
--		ROLLBACK TRAN  
--	END CATCH 	

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemDetail_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert Record Into ItemDetail
-- =============================================
Create PROCEDURE [dbo].[usp_ItemDetail_Insert] 
	@i_Date datetime,
	@i_XmlData Xml,
	@i_Cnt Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @countItemId	bigint;
	Declare @l_Date As DateTime;	
	SET @countItemId= 0;

	DECLARE @l_ItemID bigint;
	DECLARE @l_Rate decimal(18,2);
	DECLARE @l_VatRate decimal(18,2);
	Declare @l_tmpCnt Bigint;

	SET @o_ErrorMesg='''';
	Set @l_tmpCnt = 1;

	Select @l_Date= Convert(datetime,getdate(),5) ;
	/* Check for Existnace of Entered  Item */
	BEGIN TRY  
		BEGIN TRAN
			While @i_Cnt >= @l_tmpCnt
				Begin		
					SET @l_ItemID=0;
					SET @l_Rate=0;
					SET @l_VatRate=0;
					Set @countItemId=0;
					SELECT  @l_ItemID = x.d.value(''ItemID[1]'',''bigint''),
							@l_Rate = x.d.value(''Rate[1]'',''decimal(18,2)''),
							@l_VatRate = x.d.value(''VatRate[1]'',''decimal(18,2)'') 
					FROM @i_XmlData.nodes(''/NewDataSet/Table[position()=sql:variable("@l_tmpCnt")]'') x(d);
			
					SELECT @countItemId = ItemID FROM ItemDetail WHERE ItemDetail.ItemID = @l_ItemID AND IsArchieve = 0;
			
					IF @countItemID <> 0 	/* Move the existing record into History */	
						BEGIN	
							SET NOCOUNT ON;	
								UPDATE
									 ItemDetail
								SET
									IsArchieve = 1
								WHERE
									ItemID = @countItemId;	
						END

					INSERT INTO ItemDetail (ItemID,Date,Rate,VAT,IsArchieve)
										VALUES (@l_ItemID,@i_Date,@l_Rate,@l_VatRate,0);

					Set @l_tmpCnt = @l_tmpCnt + 1;

				End	

		COMMIT TRAN
	END TRY

	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
		ROLLBACK TRAN  
	END CATCH 
 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_Rate_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21/1/2011
-- Description:	Insert Record Into Item_Detail
-- =============================================
Create PROCEDURE [dbo].[usp_Item_Rate_Insert] 
	@i_Date datetime,
	@i_XmlData Xml,
	@i_Cnt Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS

	DECLARE @countItemId	bigint;
	DECLARE @l_Date DateTime;
	DECLARE @l_ItemID bigint;
	DECLARE @l_Rate decimal(18,2);
	DECLARE @l_VatRate decimal(18,2);
	DECLARE @l_tmpCnt Bigint;
	
	SET @countItemId= 0;
	SET @o_ErrorMesg='''';
	SET @l_tmpCnt = 1;

	SELECT @l_Date= Convert(datetime,getdate(),5) ;

BEGIN
	SET NOCOUNT ON;

	BEGIN TRY  
		BEGIN TRAN

			While @i_Cnt >= @l_tmpCnt
				Begin		
					SET @l_ItemID=0;
					SET @l_Rate=0;
					SET @l_VatRate=0;
					Set @countItemId=0;
					SELECT  @l_ItemID = x.d.value(''ItemID[1]'',''bigint''),
							@l_Rate = x.d.value(''Rate[1]'',''decimal(18,2)''),
							@l_VatRate = x.d.value(''VatRate[1]'',''decimal(18,2)'')
					FROM @i_XmlData.nodes(''/NewDataSet/Table[position()=sql:variable("@l_tmpCnt")]'') x(d);
			
					SELECT @countItemId = ItemID FROM ItemDetail WHERE ItemDetail.ItemID = @l_ItemID AND IsArchieve = 0;
			
					IF @countItemID <> 0 		
						BEGIN	
							SET NOCOUNT ON;	

								UPDATE
									ItemDetail
								SET
									IsArchieve = 1
								WHERE
									ItemID = @countItemId;	
						END

					INSERT INTO ItemDetail (ItemID,Date,Rate,VAT,IsArchieve)
								VALUES (@l_ItemID,@i_Date,@l_Rate,@l_VatRate,0);

					Set @l_tmpCnt = @l_tmpCnt + 1;

				End	

		COMMIT TRAN
	END TRY

	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
		ROLLBACK TRAN  
	END CATCH 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemStock_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description: Insert record into Stock table
-- =============================================
 CREATE PROCEDURE [dbo].[usp_ItemStock_Insert]
	@i_FYID Bigint,
	@i_ItemID Bigint,
	@i_QOH Decimal(18,3) ,
	@i_MinLevel Decimal(18,3) , 
	@i_MaxLevel Decimal(18,3) , 
	@i_ReOrderLvl Decimal(18,3) , 
	@i_Location Varchar(100), 
	@i_RackNo varchar(100),
	@i_Date Datetime,
	@i_UserID bigint,
	@i_GodownID int,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN	
	SET NOCOUNT ON;

    -- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE @l_StockID bigint;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;
	SET @l_StockID = 0;

	BEGIN TRY  
	BEGIN TRAN

		SELECT @l_varRec =  Count(StockID) FROM ItemStock WHERE ItemID=@i_ItemID and GodownID = @i_GodownID ;
		IF @l_varRec=0
			BEGIN 
				
				--Insert record into stock table
				Insert Into ItemStock (   FYID,   ItemID,QOH,   MinLevel,   MaxLevel,   ReOrderLvl,   Location,   RackNo,   CreatedBy,CreatedDate, GodownID)
							   Values (@i_FYID,@i_ItemID,  0,@i_MinLevel,@i_MaxLevel,@i_ReOrderLvl,@i_Location,@i_RackNo,@i_UserID,@i_Date,@i_GodownID);

				Set @l_StockID = Scope_Identity();
		
				 /* UPDATE Stocks Table */
				UPDATE	ItemStock
					SET	QOH = QOH + @i_QOH
					WHERE	StockID = @l_StockID;

				/* INSERT Stock Detail Record */
				INSERT INTO ItemStockDetail (   StockID,GTID,     RefID,   Date,   Description,   Qty)
										  VALUES (@l_StockID,  100,@l_StockID,@i_Date,''Opening Stock'',@i_QOH)

				
			END
		ELSE
			BEGIN
				SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 35001 );
			END

	IF @o_ErrorMesg = ''''
	BEGIN
		COMMIT TRAN
	END
	ELSE
	BEGIN
		ROLLBACK TRAN  
	END

	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
	ROLLBACK TRAN  
	END CATCH 

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemCategory_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert Record of Item Category
-- =============================================
Create PROCEDURE [dbo].[usp_ItemCategory_Insert]
	@i_Name		   Varchar(50),
	@i_ItemGroupID BIGINT,
	@i_UserID     Bigint,
	@o_ErrorMesg  varchar(500) OUTPUT
AS
BEGIN
	
	 --Declare Local Variables..
	Declare @l_VarRec Bigint;
	Declare @l_CreatedDate DateTime;
	Declare @l_ErrorNo BigInt;

	--Set Local Variable value..
	Set @l_VarRec=0;
	Set @o_ErrorMesg='''';
 
	SET NOCOUNT ON;

  	--Set Current Date
	Select @l_CreatedDate = Convert(DateTime,GetDate(),105);

	--Check Custom Field caption is Exists or Not..	
	Select @l_varRec = Count(CategoryID) from ItemCategory WHERE UPPER([Name]) = UPPER(@i_Name) ;
	If @l_varRec = 0
		Begin
	
			Insert Into ItemCategory
					(  [Name],ItemGroupID  , CreatedBy,   CreatedDate)
			Values  ( @i_Name,@i_ItemGroupID, @i_UserID,@l_CreatedDate)

		End
	Else
		Begin
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10001 );
		End

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Area_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Update record in Area table
-- =============================================
Create PROCEDURE [dbo].[usp_Area_Update]
	@i_AreaID bigint,
	@i_CityID bigint,
	@i_AreaName Varchar(50),
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);

	SELECT @l_varRec = Count(AreaID) FROM Gen_Area WHERE Upper(Name) = Upper(@i_AreaName) And CityID = @i_CityID AND AreaID <> @i_AreaID ;
	
	IF @l_varRec=0
		BEGIN 
			UPDATE 
				Gen_Area 
			SET
				Name = @i_AreaName,
				CityID = @i_CityID,
				ModifiedBy = @i_UserID,
				ModifiedDate = @l_Date
			WHERE
				AreaID = @i_AreaID
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=6001 );			
		END
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Area_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record in Area Table
-- =============================================
Create PROCEDURE [dbo].[usp_Area_Insert]
	@i_CityID Bigint,
	@i_AreaName Varchar(50),
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	SELECT @l_varRec = Count(AreaID) FROM Gen_Area WHERE Upper(Name) = Upper(@i_AreaName) And CityID = @i_CityID;
	IF @l_varRec=0
		BEGIN 
			INSERT INTO Gen_Area (       Name,   CityID,CreatedBy,CreatedDate)
					       VALUES(@i_AreaName,@i_CityID,@i_UserID,@l_Date)
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 6001 );
		END

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemCategory_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Update record in Item Category
-- =============================================
Create PROCEDURE [dbo].[usp_ItemCategory_Update]
	@i_CategoryID Bigint,
	@i_ItemCategoryName Varchar(50),
	@i_ItemGroupID bigint,
	@i_UserID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
		SELECT @l_varRec = Count(CategoryID) FROM ItemCategory WHERE Upper([Name]) = Upper(@i_ItemCategoryName) AND CategoryID != @i_CategoryID ;
			IF @l_varRec=0
				BEGIN 
					UPDATE
						ItemCategory
					SET
						[Name]       = @i_ItemCategoryName,
						ItemGroupID  = @i_ItemGroupID,
						ModifiedBy   = @i_UserID,
						ModifiedDate = @l_Date
					WHERE
						CategoryID  = @i_CategoryID
						
				END
		ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10001 );
		END

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_City_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record in City Table
-- =============================================
Create PROCEDURE [dbo].[usp_City_Insert]
	@i_CityName Varchar(50),
	@i_StateID Bigint,
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	SELECT @l_varRec = Count(CityID) FROM Gen_City WHERE Upper(Name) = Upper(@i_CityName);
	IF @l_varRec=0
		BEGIN 
			INSERT INTO Gen_City (       Name,   StateID,CreatedBy,CreatedDate)
					       VALUES(@i_CityName,@i_StateID,@i_UserID,@l_Date)
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 5001 );
		END

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Account_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-01-2011
-- Description:	Delete Record for Account Head
-- Changed History:
-- Sr#       Date        Changed By       Description
-- =============================================
CREATE PROCEDURE [dbo].[usp_Account_Delete]
	@i_RecID Bigint,
	@i_IsDelete Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	Declare @l_VarRec Bigint;
	Set @l_VarRec=0;
	Set @o_ErrorMesg = ''''
	

	BEGIN TRY  
	BEGIN TRAN
	If @i_RecID>50
	Begin
		If @i_IsDelete = 1
		Begin
			Select @l_VarRec=Count(AccountID) From Ledger Where AccountID=@i_RecID
			If @l_VarRec=1
			Begin
				Select @l_VarRec=Count(AccountID) From OpeningBalance Where AccountID=@i_RecID
				If @l_VarRec=1
				Begin
					Delete From Ledger Where AccountID = @i_RecID;
					Delete From OpeningBalance Where AccountID = @i_RecID	
					Delete  from Account Where AccountID=@i_RecID;
				End
				Else
				Begin
					--Set @ErrorNo=7004; -- Account is associated with Opening..
					SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=7004);	
				End	
			End
			Else
			Begin
				--Set @ErrorNo=7003; -- Acount is associated with Ledger..	
				SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=7003);	
			End
		End
		Else
		Begin
			Select @l_VarRec=Count(AccountID) From Ledger Where AccountID=@i_RecID
			If @l_VarRec=0
			Begin
				Select @l_VarRec=Count(AccountID) From OpeningBalance Where AccountID=@i_RecID
				If @l_VarRec=0
				Begin
					If @i_IsDelete = 1
					Begin
						Delete From Ledger Where AccountID = @i_RecID;
						Delete From OpeningBalance Where AccountID = @i_RecID	
						Delete  from Account Where AccountID=@i_RecID;
					End
				End
				Else
				Begin
					--Set @ErrorNo=7004; -- Account is associated with Opening..
					SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=7004);	
				End	
			End
			Else
			Begin
				--Set @ErrorNo=7003; -- Acount is associated with Ledger..
				SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=7003);	
			End
		End
	End
	Else
	Begin
		SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=7005);	
	End
	COMMIT TRAN
	END TRY
		BEGIN CATCH 
			--SET @ErrorNo = 100   
			SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=1000);	 
		ROLLBACK TRAN  
	END CATCH 
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemStock_AdjustStock]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Adjust Item Stock
-- =============================================

/* For Execute Manually

DECLARE	@return_value int,
		@o_ErrorMesg varchar(200)

EXEC	@return_value = [dbo].[usp_ItemStock_AdjustStock]
		@i_FYID = 1,
	  	@i_AdjustDate = N''5-5-2010'',
		@i_Narration = N''test'',
		@i_StoreType = 100,
		@i_xmlData = N''<NewDataSet><Table><ItemID>2</ItemID><Qty>1500.000</Qty></Table> <Table><ItemID>11</ItemID><Qty>50.000</Qty></Table> </NewDataSet>'',
		@i_Cnt = 2,
		@i_UserID = 1,
		@o_ErrorMesg = @o_ErrorMesg OUTPUT

SELECT	@o_ErrorMesg as N''@o_ErrorMesg''

SELECT	''Return Value'' = @return_value

*/

CREATE PROCEDURE [dbo].[usp_ItemStock_AdjustStock]
	@i_FYID Bigint,
	@i_AdjustDate Datetime,	
	@i_Narration Varchar(200),
	@i_xmlData XML,
	@i_Cnt Bigint,
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN	
	SET NOCOUNT ON;

    -- Declare Local Variable	
	DECLARE	@l_Date Datetime;
	
	Declare @l_ItemID Bigint;
	Declare @l_Qty Decimal(18,3);	
	Declare @l_tmpCnt Bigint;

	-- Set Local Variable
	SET @o_ErrorMesg='''';
	Set @l_tmpCnt = 1;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	BEGIN TRY  
	BEGIN TRAN
		
		-- Insert record into ItemAdjustment Table
		While @i_Cnt >= @l_tmpCnt
		Begin		
			
			SELECT  @l_ItemID = x.d.value(''ItemID[1]'',''Bigint''),
					@l_Qty = x.d.value(''Qty[1]'',''Decimal(18,3)'')					
						
			FROM @i_xmlData.nodes(''/NewDataSet/Table[position()=sql:variable("@l_tmpCnt")]'') x(d);
			
			INSERT INTO ItemAdjustment (   FYID,       AdjustDate,   ItemID,   Qty,   Narration,   CreatedBy,CreatedDate)
							         VALUES (@i_FYID,@i_AdjustDate,@l_ItemID,@l_Qty,@i_Narration,@i_UserID,@l_Date)

			Set @l_tmpCnt = @l_tmpCnt + 1;

		End		

		
	COMMIT TRAN
	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
	ROLLBACK TRAN  
	END CATCH 

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Country_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Update record in Country table
-- =============================================
 
Create PROCEDURE [dbo].[usp_Country_Update]
	@i_CountryID bigint,
	@i_CountryName Varchar(50),
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);

	SELECT @l_varRec = Count(CountryID) FROM Gen_Country WHERE Upper(Name) = Upper(@i_CountryName) AND CountryID <> @i_CountryID ;
	
	IF @l_varRec=0
		BEGIN 
			UPDATE 
				Gen_Country 
			SET
				Name = @i_CountryName,
				ModifiedBy = @i_UserID,
				ModifiedDate = @l_Date
			WHERE
				CountryID = @i_CountryID
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 3001 );			
		END
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_City_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Update record in City table
-- =============================================
Create PROCEDURE [dbo].[usp_City_Update]
	@i_CityID bigint,
	@i_CityName Varchar(50),
	@i_StateID Bigint,
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);

	SELECT @l_varRec = Count(CityID) FROM Gen_City WHERE Upper(Name) = Upper(@i_CityName) AND CityID <> @i_CityID ;
	
	IF @l_varRec=0
		BEGIN 
			UPDATE 
				Gen_City 
			SET
				Name = @i_CityName,
				StateID = @i_StateID,
				ModifiedBy = @i_UserID,
				ModifiedDate = @l_Date
			WHERE
				CityID = @i_CityID
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 5001 );			
		END
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Expense_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		 Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	Insert New Expense
--Change History::
--Sr#	Date		Changed BY		DEscription
 -- =============================================
CREATE PROCEDURE [dbo].[usp_Expense_Insert]
	@i_FYID BIGINT,
	@i_ExpNo varchar(20),
	@i_Date DateTime, 
	@i_Amount Decimal(15,3), 
	@i_Narration Varchar(250),
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN

	Declare @l_varRec bigint;
	DECLARE @l_NewID BIGINT
	Declare @l_LedNarration varchar(50);	
 	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_NewID = 0;

	Select @l_varRec = Count(ExpenseID) From Expense Where ExpNo = @i_ExpNo;
	
	If @l_varRec = 0
		Begin
			Set @l_LedNarration = ''Expense Against '' + @i_ExpNo;

			Insert Into Expense ( FYID,ExpNo,ExpAccountID,Date,Amount,Narration)
						Values(@i_FYID,@i_ExpNo,1,@i_Date,@i_Amount,@i_Narration);
			Set @l_NewID=@@Identity;
			-- Insert Into Ledger for Cash Account
			Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
						Values(@i_FYID,1,			4,					@l_NewID,			@i_Date,		0.00,@i_Amount,@i_Narration );

			-- Insert Into Ledger For Expense Account
			Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
						Values(@i_FYID,9,			4,					@l_NewID,			@i_Date,@i_Amount,	0.00,@i_Narration );

		End
	Else
		Begin
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 22001 );
		End


END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Account_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-01-2011
-- Description:	Update Record For Account 

-- Change History::
-- Sr #	Date		Changed by		Description	

-- =============================================
CREATE PROCEDURE [dbo].[usp_Account_Update]
	@i_FYID Bigint,
    @i_AccountID bigint,
	@i_AccountCode varchar(20),
    @i_AccountName varchar(100),
    @i_AccCreatedDate DateTime,
    @i_OpeningCRAmount Decimal(18,2),
    @i_ClosingDBAmount Decimal(18,2),
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	Declare @l_Varcnt Int;
	Set @l_Varcnt=0;
 	Set @o_ErrorMesg = '''';

	Select @l_Varcnt=Count(AccountID) From Account Where AccountCode=@i_AccountCode And AccountID<>@i_AccountID;
	If @l_Varcnt=0
	Begin
		Select @l_Varcnt=Count(AccountID) From Account Where AccountName=@i_AccountName and AccountID<>@i_AccountID;
		If @l_Varcnt=0
		Begin
			Update
				Account
			Set
				AccountCode=@i_AccountCode,
				AccountName=@i_AccountName,
				AccCreatedDate=@i_AccCreatedDate
			Where
				AccountID=@i_AccountID 

			 --Update Record in OpeningBalance
			Update 
				OpeningBalance
			Set
				CRAmount=@i_OpeningCRAmount,
				DBAmount=@i_ClosingDBAmount
			Where
				AccountID=@i_AccountID AND
				FYID = @i_FYID
         									
			 --Update Record in Ledger
			Update
				Ledger
			Set
				TransactionDate=@i_AccCreatedDate,
				CRAmount=@i_OpeningCRAmount,
				DBAmount=@i_ClosingDBAmount	
			Where
				AccountID=@i_AccountID  And TransactionTypeID = 1 AND
				FYID = @i_FYID

		End
		Else
		Begin
			-- Account Name is Already Exists...
 
			SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=7001);			

		End
	End
	Else 
	Begin
		-- Account Code is Already Exists...
		SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=7002 );			

	End
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_AddressDetail_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record into Address Detail table
-- =============================================
Create PROCEDURE [dbo].[usp_AddressDetail_Insert]
	@i_AddressType tinyint,
	@i_RefID bigint,
	@i_AddressData Xml,
	@i_Cnt Bigint,
	@i_UserID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN	
	SET NOCOUNT ON;

    -- Declare Local Variable	
	DECLARE	@l_Date Datetime;
	
	Declare @l_Address1 varchar(150);
	Declare @l_Address2 varchar(150);
	Declare @l_CityID Bigint;
	Declare @l_PinCode varchar(20);
	Declare @l_Phone1 varchar(20);
	Declare @l_Fax varchar(20);
	Declare @l_Phone2 varchar(20);
	Declare @l_Mobile varchar(20);
	Declare @l_tmpCnt Bigint;

	-- Set Local Variable
	SET @o_ErrorMesg='''';
	Set @l_tmpCnt = 1;

	SET @l_Date=Convert(Datetime,getDate(),5);
	
	BEGIN TRY  
	BEGIN TRAN

		-- Delete Old record
		DELETE FROM AddressDetail WHERE AddressType = @i_AddressType AND RefID = @i_RefID;

		-- Insert record into Address Detail Table
		While @i_Cnt >= @l_tmpCnt
		Begin		
			
			SELECT  @l_Address1 = x.d.value(''Address1[1]'',''varchar(150)''),
					@l_Address2= x.d.value(''Address2[1]'',''varchar(150)''),
					@l_CityID = x.d.value(''CityID[1]'',''Bigint''),
					@l_PinCode = x.d.value(''Pincode[1]'',''varchar(20)''),
					@l_Phone1 = x.d.value(''Phone1[1]'',''varchar(20)''),
					@l_Phone2 = x.d.value(''Phone2[1]'',''varchar(20)''),
					@l_Mobile = x.d.value(''Mobile[1]'',''varchar(20)''),
					@l_Fax = x.d.value(''Fax[1]'',''varchar(20)'')
			FROM @i_AddressData.nodes(''/NewDataSet/Table[position()=sql:variable("@l_tmpCnt")]'') x(d);

			INSERT INTO AddressDetail(   AddressType,   RefID,   Address1,   Address2,   CityID,  Pincode,    Phone1,   Phone2,   Fax,    Mobile,   CreatedBy,CreatedDate)
							VALUES	(@i_AddressType,@i_RefID,@l_Address1,@l_Address2,@l_CityID,@l_Pincode, @l_Phone1,@l_Phone2,@l_Fax, @l_Mobile,@i_UserID,@l_Date);								

			Set @l_tmpCnt = @l_tmpCnt + 1;

		End		

		
	COMMIT TRAN
	END TRY
	BEGIN CATCH   
		SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );
	ROLLBACK TRAN  
	END CATCH 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Account_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-01-2011
-- Description:	Insert Record For Account
-- Sr.      Date        ModifiedBy         Description
-- =============================================
CREATE PROCEDURE [dbo].[usp_Account_Insert]
	@i_FYID BIGINT,
	@i_AccountCode varchar(20),
    @i_AccountName varchar(100),
    @i_AccCreatedDate DateTime,
    @i_OpeningCRAmount Decimal(18,2),
    @i_ClosingDBAmount Decimal(18,2) ,
	@o_ErrorMesg Varchar(200) OUTPUT 
AS
BEGIN

 Declare @l_Varcnt Int;
 Declare @l_AccountID Bigint;

 Set @l_Varcnt=0; 
 Set @l_AccountID=0;
 Set @o_ErrorMesg = '''';

 Select @l_Varcnt=Count(AccountID) From Account Where AccountCode=@i_AccountCode;
 If @l_Varcnt=0
 Begin
   Select @l_Varcnt=Count(AccountID) From Account Where AccountName=@i_AccountName;
     If @l_Varcnt=0
		Begin
--           -----Insert Record in Account
--			Insert Into Account(AccountCode,AccountName,AccCreatedDate)
--						Values(@i_AccountCode,@i_AccountName,@i_AccCreatedDate)
--				Set @l_AccountID = Scope_Identity();
--					
--           ----Insert Record in OpeningBalance
--              Insert Into OpeningBalance (FYID,AccountID, CRAmount, DBAmount)
--									Values(@i_FYID,@l_AccountID, @i_OpeningCRAmount, @i_ClosingDBAmount);
--           ---Insert Record in Ledger
--					Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount)
--								Values(@i_FYID,@l_AccountID, 1,				 @l_AccountID, @i_AccCreatedDate, @i_OpeningCRAmount, @i_ClosingDBAmount);
       

				-- Insert Service Account	
		SET IDENTITY_INSERT Account ON
			Insert Into Account(AccountID,AccountCode,AccountName,AccCreatedDate,AccTypeID)
						Values(10,''Acc-00010'',''Service Tax'',''2014-01-15'',1)
		SET IDENTITY_INSERT Account OFF
		----Insert Record in OpeningBalance
		Insert Into OpeningBalance (FYID,AccountID, CRAmount, DBAmount) Values(1,10, 0.00,0.00);
		---Insert Record in Ledger
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount)
						Values(1,10,       1,				  10,              ''2014-01-15'',		0.00, 0.00);




 End
     Else
       Begin
          -- Account Name is Already Exists...
		SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=7001);	
       End
 End
 Else 
  Begin
   -- Account Code is Already Exists...
       SET @o_ErrorMesg= (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo=7002 );		
       End
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record in Item Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_Item_Insert]
	@i_Code Varchar(50),
	@i_ItemName Varchar(MAX),
	@i_OtherName Varchar(100),
	@i_Specification Varchar(MAX),
	@i_CUOMID Bigint,
	@i_HSNCode nvarchar(150),
	@i_ProductCode nvarchar(150),
	@i_Price decimal(18,2),
	@i_UserID Bigint,
	@i_Cnt Bigint,
	@i_XMLString xml,

	@i_QOH Decimal(18,3) ,
	@i_ReOrderLvl Decimal(18,3) , 
	@i_Location Varchar(100), 
	@i_RackNo varchar(100),
	@i_GodownID int,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE @l_varRec bigint;
	DECLARE	@l_Date Datetime;


--ADDED NEW BY ROOJA ----
	DECLARE @l_ItemID bigint;
	DECLARE @l_StockID bigint;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	SET @l_Date=Convert(Datetime,getDate(),5);

	SELECT @l_varRec = Count(ItemID) FROM Item WHERE Upper(Code) = Upper(@i_Code) ;
	IF @l_varRec=0
		BEGIN 
			SELECT @l_varRec = Count(ItemID) FROM Item WHERE Upper(Name) = Upper(@i_ItemName);
			IF @l_varRec=0
				BEGIN 
					 INSERT INTO Item (   Code,     Name,     OtherName,   Specification,   CUomID, Price,     CreatedBy,CreatedDate,HSNCode,ProductCode )
						    VALUES(  @i_Code,@i_ItemName,@i_OtherName,@i_Specification,@i_CUOMID, @i_Price,   @i_UserID,@l_Date,@i_HSNCode,@i_ProductCode )

--------------new by rooja ---------------------
Set @l_ItemID = Scope_Identity();

INSERT INTO ItemStock (FYID,   ItemID,QOH,   MinLevel,   MaxLevel,   ReOrderLvl,   Location,   RackNo,   CreatedBy,CreatedDate, GodownID)
				VALUES(1,@l_ItemID,@i_QOH,0,0,@i_ReOrderLvl,@i_Location,@i_RackNo,@i_UserID,@l_Date,@i_GodownID)

Set @l_StockID = Scope_Identity();

/* UPDATE Stocks Table */
--				UPDATE	ItemStock
--					SET	QOH = QOH + @i_QOH
--					WHERE	StockID = @l_StockID;

				/* INSERT Stock Detail Record */
				INSERT INTO ItemStockDetail (   StockID,GTID,     RefID,   Date,   Description,   Qty)
										  VALUES (@l_StockID,  100,@l_StockID,@l_Date,''Opening Stock'',@i_QOH)


update Item set StockID=@l_StockID where ItemID=@l_ItemID



--------------new by rooja stock---------------------
--IF @i_Cnt > 0
--				BEGIN		
--					SELECT  x.d.value(''GodownID[1]'',''Bigint'') AS GodownID						
--					INTO #tmpDetail				
--					FROM 
--						@i_XMLString.nodes(''/NewDataSet/Table'') x(d);
--
--					INSERT INTO ItemStock (FYID,   ItemID,QOH,   MinLevel,   MaxLevel,   ReOrderLvl,   Location,   RackNo,   CreatedBy,CreatedDate, GodownID)
--											SELECT 1,@l_ItemID,0,0,0,0,'''','''',@i_UserID,@l_Date,T1.GodownID FROM #tmpDetail T1 
--
--Set @l_StockID = Scope_Identity();
--
--/* UPDATE Stocks Table */
--				UPDATE	ItemStock
--					SET	QOH = QOH + 0
--					WHERE	StockID = @l_StockID;
--
--				/* INSERT Stock Detail Record */
--				INSERT INTO ItemStockDetail (   StockID,GTID,     RefID,   Date,   Description,   Qty)
--										  VALUES (@l_StockID,  100,@l_StockID,@l_Date,''Opening Stock'',0)
--
--END
--
				END
			ELSE
				BEGIN
					SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 13002 );
				END
		END
	ELSE
		BEGIN
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 13001 );
		END

END













' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SalesInvoice_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 25th jan 2011
-- Description:	Update record of Sales Invoice and Sales Invoice Detail
-- =============================================
CREATE PROCEDURE [dbo].[usp_SalesInvoice_Update]
	@i_SIID Bigint,
	@i_SalesCode Varchar(20),
	@i_FYID Bigint,
	@i_SalesDate DateTime,
	
	@i_DCDate DATETIME,
	@i_CustomerID Bigint,
	@i_DueDays Bigint,
	@i_ExtraCharges decimal(18,2),
	@i_ExtraChargesType nvarchar(255),
	@i_TotalAmount Decimal(18,2),
	@i_ServiceAmount  Decimal(18,2),	
	@i_ExciseAmount  Decimal(18,2),	
	@i_CessAmount Decimal(18,2),
	@i_HCessAmount Decimal(18,2),
	@i_AmountAfterExcise Decimal(18,2),
	@i_CSTAmount Decimal(18,2),
	@i_VATAmount Decimal(18,2),
	@i_AVATAmount Decimal(18,2),
	@i_Discount  Decimal(18,2),
	@i_NetAmount  Decimal(18,2),
	@i_PaidAmount  Decimal(18,2),
	@i_Narration Varchar(250),
	@i_TIN nvarchar(50),
	@i_XMLString xml,
	@i_Cnt Bigint,
	@i_EmpID int,
--	@i_XMLString1 xml,
--	@i_Cnt1 Bigint,
	@i_UserID BIGINT,
	@i_Installation datetime,
	@i_Reminder datetime,
	@i_NoofServices int,
	@i_RecDay int,
	@i_Type nvarchar(50),
	@i_ShippingAdd nvarchar(1000),
	@i_BONo nvarchar(250),
	@i_BODate datetime,
	@i_DNote nvarchar(250),
	@i_DNoteDate datetime,
	@i_SuRNo nvarchar(250),
	@i_DDNo nvarchar(250),
	@i_DT nvarchar(250),
	@i_D nvarchar(250),
	@i_DtI datetime,
	@i_TI nvarchar(50),
	@i_DtR datetime,
	@i_TR nvarchar(50),
	@i_CC varchar(MAX),
	@i_BCC varchar(MAX),
	@i_ExtraCharges2 decimal(18,2),
	@i_ExtraChargesType2 nvarchar(255),
	@i_ExtraCharges3 decimal(18,2),
	@i_ExtraChargesType3 nvarchar(255),
	@i_ExtraReminder nvarchar(500),
	@i_dtExtraReminder datetime,
	@i_CustInvoiceNo nvarchar(50),
	@i_EmpAllToID int,
	@i_IsPaid bit,
	@i_TotalDiscAmt Decimal(18,2),
	@i_CompId bigint,
--	@i_GoDownID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT

AS
BEGIN
	SET NOCOUNT ON;

    -- Declare Local Variables...
	DECLARE @l_varRec Bigint;
 	DECLARE @l_CustomerAccID Bigint
	DECLARE @l_LedNarration varchar(50)
 	DECLARE @l_Description varchar(100);
	-- Set Local Variable value..
	SET @l_varRec = 0;
	SET @l_Description  = ''''
	SET @l_CustomerAccID = 0
	SET @l_LedNarration =''''
	
	-- Variable for StockDetail
 
	SET @o_ErrorMesg='''';

DECLARE	@l_Date Datetime;
--

SET @l_Date=Convert(Datetime,getDate(),5);
--	BEGIN TRY  
--	BEGIN TRAN
 
 	SELECT @l_varRec = Count(SIID) From SalesInvoice Where SalesCode = @i_SalesCode And SIID <> @i_SIID
 		IF @l_varRec = 0
 			BEGIN
 				Set @l_LedNarration  = ''Sales Against '' + @i_SalesCode
 					-- Delete Stock	
				
				Update ItemStock
					Set ItemStock.QOH =  ItemStock.QOH -
						(Select IsNull(Sum(ItemStockDetail.Qty),0)
							From ItemStockDetail Where  ItemStockDetail.StockID = ItemStock.StockID 
								And ItemStockDetail.RefID = @i_SIID And ItemStockDetail.GTID=300)
				From ItemStockDetail as SDet
				Where  
					SDet.StockID = ItemStock.StockID And 
					SDet.RefID = @i_SIID And
					ItemStock.StockID IN (Select StockID From ItemStockDetail
						Where ItemStockDetail.RefID = @i_SIID And ItemStockDetail.GTID=300) 


------------------------------------------------------------
--IF @i_Cnt > 0
--				BEGIN		
--					SELECT  
--						x.d.value(''GodownID[1]'',''int'') AS GodownID,
--						x.d.value(''ItemID[1]'',''Bigint'') AS ItemID,
--						x.d.value(''ItemDesc[1]'',''varchar(max)'') AS ItemDesc,
--						x.d.value(''Qty[1]'',''Decimal(18,3)'') AS Qty,
--						x.d.value(''Rate[1]'',''Decimal(18,2)'') AS Rate,
--						x.d.value(''Amount[1]'',''Decimal(18,2)'') AS Amount,
--						x.d.value(''TaxClassID[1]'',''Bigint'') AS TaxClassID,
--						x.d.value(''ServiceRate[1]'',''Decimal(5,2)'') AS ServiceRate,						
--						x.d.value(''ServiceAmount[1]'',''Decimal(18,2)'') AS ServiceAmount,
--						x.d.value(''ExciseRate[1]'',''Decimal(5,2)'') AS ExciseRate,						
--						x.d.value(''ExciseAmount[1]'',''Decimal(18,2)'') AS ExciseAmount,
--						x.d.value(''EduCessRate[1]'',''Decimal(5,2)'') AS EduCessRate,						
--						x.d.value(''EduCessAmount[1]'',''Decimal(18,2)'') AS EduCessAmount,
--						x.d.value(''HEduCessRate[1]'',''Decimal(5,2)'') AS HEduCessRate,						
--						x.d.value(''HEduCessAmount[1]'',''Decimal(18,2)'') AS HEduCessAmount,
--						x.d.value(''AmountAfterExcise[1]'',''Decimal(18,2)'') AS AmountAfterExcise,						
--						x.d.value(''CSTRate[1]'',''Decimal(5,2)'') AS CSTRate,
--						x.d.value(''CSTAmount[1]'',''Decimal(18,2)'') AS CSTAmount,
--						x.d.value(''VATRate[1]'',''Decimal(5,2)'') AS VATRate,	
--						x.d.value(''VATAmount[1]'',''Decimal(18,2)'') AS VATAmount,
--						x.d.value(''AVATRate[1]'',''Decimal(5,2)'') AS AVATRate,
--						x.d.value(''AVATAmount[1]'',''Decimal(18,2)'') AS AVATAmount,
--						x.d.value(''NetAmount[1]'',''Decimal(18,2)'') AS NetAmount,	
--						x.d.value(''Discount[1]'',''Decimal(18,2)'') AS Discount
--						
--					INTO #tmpDetail1				
--					FROM 
--						@i_XMLString.nodes(''/NewDataSet/Table'') x(d);

--					Update ItemStock
--					Set ItemStock.QOH =  ItemStock.QOH -
--						(Select IsNull(Sum(ItemStockDetail.Qty),0)
--							From ItemStockDetail Where  ItemStockDetail.StockID = ItemStock.StockID 
--								And ItemStockDetail.RefID = @i_SIID And ItemStockDetail.GTID=300)
--				From ItemStockDetail as SDet 
----inner join on #tmpDetail1
--				Where  
--					SDet.StockID = ItemStock.StockID And 
--					SDet.RefID = @i_SIID And
--					ItemStock.StockID IN (Select StockID From ItemStockDetail
--						Where ItemStockDetail.RefID = @i_SIID And ItemStockDetail.GTID=300) 
--					AND ItemStock.GodownID=#tmpDetail1.GodownID

-------------------------------------
-- Update Stock
--				Update ItemStock 
--					Set ItemStock.QOH = ItemStock.QOH -
--						(Select Sum(#tmpDetail.Qty) From #tmpDetail Where ItemStock.ItemID = #tmpDetail.ItemID )
--				From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
--				Where 
--					ItemStock.FYID = @i_FYID and ItemStock.GodownID=#tmpDetail.GoDownID
-- 				END
------------


--END

---------------------------

--					AND
--					ItemStock.GodownID=

				-- Delete Record from StockDistrictDetail Table
				DELETE FROM ItemStockDetail WHERE RefID = @i_SIID AND GTID = 300;
			 	 
				Delete From Ledger Where TransactionTypeID=3 And TransactionID = @i_SIID
				Delete From SaleDocList  Where SaleID = @i_SIID;
				Delete From SalesInvoiceDetail Where SIID = @i_SIID;
--				Delete From Sales_Service_Reminder Where SIID = @i_SIID AND SR_Done=0;

 			 -- Update Record IN SalesInvoice		
				UPDATE
					SalesInvoice
				SET
					SalesCode = @i_SalesCode, 
					SalesDate=@i_SalesDate,   
					CustomerID=@i_CustomerID,  
					
					FYID=@i_FYID,
				
					DCDate = @i_DCDate,   
				
					DueDays = @i_DueDays,
					TotalAmount = @i_TotalAmount,   
					ServiceAmount = @i_ServiceAmount,
					ExciseAmount = @i_ExciseAmount,   
					CessAmount = @i_CessAmount,   
					HCessAmount = @i_HCessAmount,   
					AmountAfterExcise = @i_AmountAfterExcise,
					CSTAmount = @i_CSTAmount,   
					VATAmount = @i_VATAmount,   
					AVATAmount = @i_AVATAmount,   
					Discount = @i_Discount,
					NetAmount = @i_NetAmount,
					PaidAmount = @i_PaidAmount,
					Narration=@i_Narration,
				
					InstallationDate=@i_Installation,
					ReminderDate=@i_Reminder,
					NoofServices=@i_NoofServices,
					ExtraCharges=@i_ExtraCharges,
					ExtraChargesType=@i_ExtraChargesType,
					EmpID=@i_EmpID,
					TIN=@i_TIN,
					RecDay=@i_RecDay,
					Type=@i_Type,
					ShippingAdd=@i_ShippingAdd,
					BONo=@i_BONo,
					BODate=@i_BODate,
					DNote=@i_DNote,
					DNoteDate=@i_DNoteDate,
					SuRNo=@i_SuRNo,
					DDNo=@i_DDNo,
					DT=@i_DT,
					D=@i_D,
					DtI=@i_DtI,
					TI=@i_TI,
					DtR=@i_DtR,
					TR=@i_TR,
					CC=@i_CC,
					BCC=@i_BCC,
					ExtraCharges2=@i_ExtraCharges2,
					ExtraChargesType2=@i_ExtraChargesType2,
					ExtraCharges3=@i_ExtraCharges3,
					ExtraChargesType3=@i_ExtraChargesType3,
					ExtraReminder=@i_ExtraReminder,
					dtExtraReminder=@i_dtExtraReminder,
					CustInvoiceNo=@i_CustInvoiceNo	,
					EmpAllToID=@i_EmpAllToID,
					IsPaid=@i_IsPaid,
					CompId=@i_CompId,
					TotalDiscAmt=@i_TotalDiscAmt,
--					GoDownID=@i_GoDownID,
					ModifiedBy = @i_UserID
				WHERE
					SIID = @i_SIID
				Set @l_CustomerAccID = 0
 				-- Vendor''s Ledger Effect
				Select @l_CustomerAccID = AccountID From Customer Where CustomerID = @i_CustomerID
				If @l_CustomerAccID>0
				Begin
					Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
								Values(@l_CustomerAccID,@i_FYID, 3,				   @i_SIID, @i_SalesDate,0.00,@i_NetAmount,@l_LedNarration );
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID ,TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
								Values(@l_CustomerAccID,@i_FYID, 3,				   @i_SIID, @i_SalesDate,@i_PaidAmount,0.000,@l_LedNarration );
				End
				-- Insert Record for Basic Excise Amount
				If @i_ServiceAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID, FYID,TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(10,           @i_FYID,3,				     @i_SIID,   @i_SalesDate,0.00,@i_ServiceAmount,@l_LedNarration);
				End
				-- Insert Record for Basic Excise Amount
				If @i_ExciseAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID, FYID,TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(2,           @i_FYID,3,				     @i_SIID,   @i_SalesDate,0.00,@i_ExciseAmount,@l_LedNarration);
				End
				-- Insert Record for Cess On Excise Amount
				If @i_CessAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(3,         @i_FYID,  3,				     @i_SIID,   @i_SalesDate,0.00,@i_CessAmount,@l_LedNarration);
				End
				-- Insert Record for H Cess On Excise Amount
				If @i_HCessAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(4,          @i_FYID, 3,				     @i_SIID,   @i_SalesDate,0.00,@i_HCessAmount,@l_LedNarration);
				End
				-- Insert Record for CST On Excise Amount
				If @i_CSTAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID, FYID,TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(5,           @i_FYID,3,				     @i_SIID,   @i_SalesDate,0.00,@i_CSTAmount,@l_LedNarration);
				End
				-- Insert Record for VAT On Excise Amount
				If @i_VATAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(6,           @i_FYID,3,				     @i_SIID,   @i_SalesDate,0.00,@i_VATAmount,@l_LedNarration);
				End
				-- Insert Record for AVAT On Excise Amount
				If @i_AVATAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(7,           @i_FYID,3,				     @i_SIID,   @i_SalesDate,0.00,@i_AVATAmount,@l_LedNarration);
				End


			---Insert Record in Ledger For Cash
				Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
							Values(	1,		@i_FYID,	3,				     @i_SIID,   @i_SalesDate,@i_PaidAmount,0.00,@l_LedNarration);

 
				---Procedure For Insert Record into Sales Invoice Detail Table...
				IF @i_Cnt > 0
				BEGIN		
					SELECT  
						x.d.value(''GodownID[1]'',''int'') AS GodownID,
						x.d.value(''ItemID[1]'',''Bigint'') AS ItemID,
						x.d.value(''ItemDesc[1]'',''varchar(max)'') AS ItemDesc,
						x.d.value(''Qty[1]'',''Decimal(18,3)'') AS Qty,
						x.d.value(''Rate[1]'',''Decimal(18,2)'') AS Rate,
						x.d.value(''Amount[1]'',''Decimal(18,2)'') AS Amount,
						x.d.value(''TaxClassID[1]'',''Bigint'') AS TaxClassID,
						x.d.value(''ServiceRate[1]'',''Decimal(5,2)'') AS ServiceRate,						
						x.d.value(''ServiceAmount[1]'',''Decimal(18,2)'') AS ServiceAmount,
						x.d.value(''ExciseRate[1]'',''Decimal(5,2)'') AS ExciseRate,						
						x.d.value(''ExciseAmount[1]'',''Decimal(18,2)'') AS ExciseAmount,
						x.d.value(''EduCessRate[1]'',''Decimal(5,2)'') AS EduCessRate,						
						x.d.value(''EduCessAmount[1]'',''Decimal(18,2)'') AS EduCessAmount,
						x.d.value(''HEduCessRate[1]'',''Decimal(5,2)'') AS HEduCessRate,						
						x.d.value(''HEduCessAmount[1]'',''Decimal(18,2)'') AS HEduCessAmount,
						x.d.value(''AmountAfterExcise[1]'',''Decimal(18,2)'') AS AmountAfterExcise,						
						x.d.value(''CSTRate[1]'',''Decimal(5,2)'') AS CSTRate,
						x.d.value(''CSTAmount[1]'',''Decimal(18,2)'') AS CSTAmount,
						x.d.value(''VATRate[1]'',''Decimal(5,2)'') AS VATRate,	
						x.d.value(''VATAmount[1]'',''Decimal(18,2)'') AS VATAmount,
						x.d.value(''AVATRate[1]'',''Decimal(5,2)'') AS AVATRate,
						x.d.value(''AVATAmount[1]'',''Decimal(18,2)'') AS AVATAmount,
						x.d.value(''NetAmount[1]'',''Decimal(18,2)'') AS NetAmount,	
						x.d.value(''Discount[1]'',''Decimal(18,2)'') AS Discount
						
					INTO #tmpDetail			
					FROM 
						@i_XMLString.nodes(''/NewDataSet/Table'') x(d);

				 	INSERT INTO SalesInvoiceDetail (SIID, GodownID,  ItemID,     ItemDesc,   Qty,   Rate,  Amount,   TaxClassID,    ServiceRate,   ServiceAmount,       ExciseRate,   ExciseAmount,   CessRate,      CessAmount,     HCessRate,      HCessAmount,   AmountafterExcise,   CSTRate,   CSTAmount,   VATRate,   VATAmount,   AVATRate,   AVATAmount,   NetAmount,Discount)
											SELECT @i_SIID,T1.GodownID,T1.ItemID,T1.ItemDesc,T1.Qty,T1.Rate,T1.Amount,T1.TaxClassID,T1.ServiceRate,T1.ServiceAmount,T1.ExciseRate,T1.ExciseAmount,T1.EduCessRate,T1.EduCessAmount,T1.HEduCessRate,T1.HEduCessAmount,T1.AmountafterExcise,T1.CSTRate,T1.CSTAmount,T1.VATRate,T1.VATAmount,T1.AVATRate,T1.AVATAmount,T1.NetAmount,T1.Discount FROM #tmpDetail T1 


--				IF @i_Cnt1 > 0
--				BEGIN		
--					SELECT  x1.d.value(''SR_Code[1]'',''varchar(50)'') AS SR_Code,
--						x1.d.value(''SR_Date[1]'',''DateTime'') AS SR_Date,							
--						x1.d.value(''SIID[1]'',''int'') AS SIID,
--						x1.d.value(''SR_Done[1]'',''int'') AS SR_Done
--												
--					INTO #tmpDetail1			
--					FROM 
--						@i_XMLString1.nodes(''/NewDataSet/Table'') x1(d);
--
--					INSERT INTO Sales_Service_Reminder (SR_Code,SR_Date,SIID,SR_Done)   
--											SELECT T2.SR_Code,T2.SR_Date,@i_SIID,T2.SR_Done FROM #tmpDetail1 T2 
--				IF @i_Cnt1 > 0
--				BEGIN		
--					SELECT  x1.d.value(''SR_Code[1]'',''varchar(50)'') AS SR_Code,
--						x1.d.value(''SR_Date[1]'',''DateTime'') AS SR_Date,							
--						x1.d.value(''SIID[1]'',''int'') AS SIID,
--						x1.d.value(''SR_Done[1]'',''int'') AS SR_Done					
--												
--					INTO #tmpDetail1			
--					FROM 
--						@i_XMLString1.nodes(''/NewDataSet/Table'') x1(d);
--
--					INSERT INTO Sales_Service_Reminder (SR_Code,SR_Date,SIID,SR_Done)   
--											SELECT T2.SR_Code,T2.SR_Date,@l_NewID,T2.SR_Done FROM #tmpDetail1 T2 



				SET @l_Description = ''Against Sales Invoice : '' + @i_SalesCode; 
				Insert Into ItemStock(FYID,      ItemID,    QOH, MinLevel, MaxLevel, ReorderLvl, CreatedBy, CreatedDate )
 							Select @i_FYID,#tmpDetail.ItemID, 0, 0, 0, 0, @i_UserID, @i_SalesDate
							From #tmpDetail Where #tmpDetail.ItemID Not In(
								Select ItemStock.ItemID From ItemStock WHERE ItemStock.FYID = @i_FYID)
				
				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
					Select ItemStock.StockID, 100,ItemStock.StockID, @i_SalesDate, ''Opening Stock'',0.000
						From #tmpDetail 
							Inner Join ItemStock On #tmpDetail.ItemID = ItemStock.ItemID
							Where ItemStock.QOH = 0 And ItemStock.FYID = @i_FYID
								And ItemStock.StockID Not In (Select StockID from ItemStockDetail Where 
									ItemStockDetail.StockID = ItemStock.StockID And ItemStockDetail.GTID=100)

				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
						Select ItemStock.StockID, 300,@i_SIID, @i_SalesDate, @l_Description, ((-1) * #tmpDetail.Qty)
							From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
							Where ItemStock.FYID = @i_FYID
		 				
				-- Update Stock
				Update ItemStock 
					Set ItemStock.QOH = ItemStock.QOH -
						(Select Sum(#tmpDetail.Qty) From #tmpDetail Where ItemStock.ItemID = #tmpDetail.ItemID )
				From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
				Where 
					ItemStock.FYID = @i_FYID
-- and ItemStock.GodownID=#tmpDetail.GoDownID
 				END
				END
			  END
--		  ELSE
--			  BEGIN
--					SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 25001 );
--			  END		
		
--		COMMIT TRAN
--	END TRY
--		BEGIN CATCH 
--			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );  
--		ROLLBACK TRAN  
--	END CATCH 
--END






























' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select Item
-- =============================================
CREATE PROCEDURE [dbo].[usp_Item_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT     Item.Code, Item.Name, Item.OtherName, Item.Specification, Item.Price, Item.CUOMID, Item.Width, Item.Length, Item.HSNCode, Item.ProductCode, ItemStock.GodownID, 
                      ItemStock.RackNo, ItemStock.Location, ItemStock.ReorderLvl, ItemStock.QOH,
			Item.StockID
FROM         Item LEFT JOIN
                      ItemStock ON ItemStock.StockID=Item.StockID 
	WHERE
		Item.ItemID = @i_RecID 

END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemAdjustment_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select ItemAdjustment record
-- =============================================
CREATE PROCEDURE [dbo].[usp_ItemAdjustment_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	
		ItemAdjustment.AdjustDate,
		ItemAdjustment.ItemID,
		Item.Name as ItemName,
		ItemAdjustment.Qty,
		ItemAdjustment.GodownID,
		ItemAdjustment.Narration,
		ISNULL(ItemStock.QOH,0) as QOH,
		FinancialYear.StartDate,
		FinancialYear.EndDate
	FROM
		ItemAdjustment 
		INNER JOIN Item ON ItemAdjustment.ItemID = Item.ItemID 
		LEFT JOIN ItemStock ON ItemAdjustment.ItemID = ItemStock.ItemID 
		INNER JOIN FinancialYear ON ItemAdjustment.FYID = FinancialYear.FYID
	WHERE
		ItemAdjustment.AdjustmentID = @i_RecID 

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_AdjustItemLOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Get items which has stock for adjustment
-- =============================================

/* For Execute Manually

DECLARE	@return_value int

EXEC	@return_value = [dbo].[usp_Item_AdjustItemLOV]
 

SELECT	''Return Value'' = @return_value

*/

CREATE PROCEDURE [dbo].[usp_Item_AdjustItemLOV]
	 
@i_GodownID int

AS
BEGIN
	SET NOCOUNT ON;

  If @i_GodownID=0
	Begin
	SELECT     ItemStock.ItemID, Item.Code AS ItemCode, Item.Name AS ItemName, ItemStock.QOH, ItemStock.GodownID, Item.ProductCode
FROM         ItemStock INNER JOIN
                      Item ON ItemStock.ItemID = Item.ItemID
ORDER BY ItemCode 
end
else
Begin
SELECT     ItemStock.ItemID, Item.Code AS ItemCode, Item.Name AS ItemName, ItemStock.QOH, ItemStock.GodownID, Item.ProductCode
FROM         ItemStock INNER JOIN
                      Item ON ItemStock.ItemID = Item.ItemID where ItemStock.GodownID=@i_GodownID
ORDER BY ItemCode 
end

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Indent_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 24th Jan 2011
-- Description:	Delete record from Purchase Invoice And Detail
-- =============================================

CREATE PROCEDURE [dbo].[usp_Indent_Delete]
	@i_RecID Bigint,
	@i_GodownID bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	-- Set Local Variable
	SET @o_ErrorMesg='''';
 
     
		-- Delete Stock	
		Update ItemStock
			Set ItemStock.QOH =  ItemStock.QOH -
				(Select IsNull(Sum(ItemStockDetail.Qty),0)
					From ItemStockDetail Where  ItemStockDetail.StockID = ItemStock.StockID 
						And ItemStockDetail.RefID = @i_RecID And ItemStockDetail.GTID=200)
		From ItemStockDetail as SDet
		Where  
			SDet.StockID = ItemStock.StockID And 
			SDet.RefID = @i_RecID And
			ItemStock.StockID IN (Select StockID From ItemStockDetail
				Where ItemStockDetail.RefID = @i_RecID And ItemStockDetail.GTID=200 and GodownID=@i_GodownID) 

		-- Delete Record from StockDistrictDetail Table
		DELETE FROM ItemStockDetail WHERE RefID = @i_RecID AND GTID = 200;
	 	 
		Delete From Ledger Where TransactionTypeID=2 And TransactionID = @i_RecID

		Delete From IndentDetail Where PIID = @i_RecID;
		Delete From Indent Where PIID = @i_RecID;

END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TaxClass_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	List of Tax Class
-- =============================================
CREATE PROCEDURE [dbo].[usp_TaxClass_List]

@i_UserID bigint

AS
BEGIN
 	SET NOCOUNT ON;
if @i_UserID = 1

begin

    SELECT
		Name As TaxClassName,
		TaxClassID,
		FromDate,
		Excise,
		VAT,
		Isnull(CST,0.00) As CST,
		IsNULL(AVAT,0.00) As AVAT,
		ServiceTax,
		EduCess,
		HEduCess
	FROM
		 TaxClass
	WHERE
		IsTerminate = 0
	ORDER BY
		TaxClassName

END

else
SELECT
		Name As TaxClassName,
		TaxClassID,
		FromDate,
		Excise,
		VAT,
		Isnull(CST,0.00) As CST,
		IsNULL(AVAT,0.00) As AVAT,
		ServiceTax,
		EduCess,
		HEduCess
	FROM
		 TaxClass
	WHERE
		IsTerminate = 0 and CreatedBy = @i_UserID
	ORDER BY
		TaxClassName

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TaxClass_GetRate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	List of TaxClass for Combo
-- =============================================
Create PROCEDURE [dbo].[usp_TaxClass_GetRate]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		TaxClassID,
		Name as TaxClass,		
		ISNULL(Excise,0) as Excise,
		ISNULL(EduCess,0) as EduCess,
		ISNULL(HEduCess,0) as HEduCess,
		ISNULL(ServiceTax,0) as ServiceTax,
		ISNULL(CST,0) as CST,
		ISNULL(VAT,0) as VAT,
		ISNULL(AVAT,0) as AVAT
	FROM
		 TaxClass
	WHERE
		TaxClassID = @i_RecID
	ORDER BY
		Name
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TaxClass_Terminate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	Sp is used for terminate record from tax class.
-- =============================================
Create  PROCEDURE [dbo].[usp_TaxClass_Terminate]
	@i_RecID Bigint,	
	@o_ErrorMesg  Varchar(500) OUTPUT

AS

BEGIN
	Set @o_ErrorMesg = '''';
	Declare @l_TerminateDate DateTime; 
    SET NOCOUNT ON;

	Select @l_TerminateDate = Convert(DateTime,GetDate(),105);

	Update  TaxClass
	Set
		IsTerminate = 1,
		TerminateDate = @l_TerminateDate
	Where
		TaxClassID = @i_RecID;

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TaxClass_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	List of TaxClass for Combo
-- =============================================
Create PROCEDURE [dbo].[usp_TaxClass_DDL]
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		TaxClassID,
		Name as TaxClass		
	FROM
		TaxClass
	WHERE
		IsTerminate = 0
	ORDER BY
		Name
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TaxClass_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	Sp is used for delete record from tax class.
-- =============================================
Create PROCEDURE [dbo].[usp_TaxClass_Delete]
	@i_RecID Bigint,	
	@o_ErrorMesg  Varchar(500) OUTPUT
AS
	Set @o_ErrorMesg = '''';

BEGIN
 	SET NOCOUNT ON;

	Delete From TaxClass Where TaxClassID = @i_RecID;	
									
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TaxClass_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	Select TaxClass record
-- =============================================
Create PROCEDURE [dbo].[usp_TaxClass_Select]
	@i_RecID Bigint
AS
BEGIN
	 SET NOCOUNT ON;

	SELECT
		Name As TaxClassName,
		FromDate,
		Excise,
		VAT,
		Isnull(CST,0.00) As CST,
		IsNULL(AVAT,0.00) As AVAT,
		ServiceTax,
		EduCess,
		HEduCess
	FROM
		 TaxClass
	WHERE
		TaxClassID = @i_RecID; 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_User_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List Of User
-- =============================================
CREATE PROCEDURE [dbo].[usp_User_List]
@i_CompId bigint,
@i_UserID bigint	 
AS
BEGIN
 
	if (@i_CompId=1) and (@i_UserID=1)
begin
	SELECT DISTINCT 
                      Gen_User.UserName, Gen_User.UserID, Gen_User.Password, Gen_User.Name AS DisplayName, CASE Gen_User.IsActive WHEN 0 THEN ''DeActive'' WHEN 1 THEN ''Active'' END AS IsActive, 
                      Gen_User.Company, Gen_User.Mail_Send, CompanyInfo.CompanyName, CompanyInfo.CompId
FROM         Gen_User left JOIN
                      CompanyInfo ON Gen_User.CompId = CompanyInfo.CompId
end
else
begin
	SELECT     Gen_User.UserID, Gen_User.UserName, Gen_User.Password, Gen_User.Name AS DisplayName, CASE Gen_User.IsActive WHEN 0 THEN ''DeActive'' WHEN 1 THEN ''Active'' END AS IsActive, 
                      CompanyInfo.CompId, Gen_User.Company, CompanyInfo.CompanyName, Gen_User.Mail_Send
FROM         Gen_User LEFT OUTER JOIN
                      CompanyInfo ON CompanyInfo.CompId = Gen_User.CompId where CompanyInfo.CompId=@i_CompId and CreatedBy=@i_UserID
	

	 
END
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CustomerMain_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Description:	List of Lead
-- =============================================
--select * from Lead
CREATE PROCEDURE [dbo].[usp_CustomerMain_List]
--[usp_CustomerMain_List]''1'',''1''
@i_CompId bigint,
@i_UserID bigint	
AS
--@i_UserID bigint	
BEGIN
    SET NOCOUNT ON;


if @i_UserID = 1

begin
SELECT     Gen_User.Name AS LeadBy, CustomerMain.AccountID, CustomerMain.CustomerID, CustomerMain.CustomerCode, CustomerMain.CustomerName, 
                      CustomerMain.CityID, CustomerMain.Address, CustomerMain.AreaID, CustomerMain.Pincode, CustomerMain.Phone1, CustomerMain.MobileNo, CustomerMain.Email, 
                      CustomerMain.Website, CustomerMain.ContactPerson, CustomerMain.EmpID, CustomerMain.Specification, CustomerMain.Remarks, CustomerMain.Name1, 
                      CustomerMain.Name2, CustomerMain.Name3, CustomerMain.Name4, CustomerMain.Name5, CustomerMain.Name6, CustomerMain.Value2, CustomerMain.Value1, 
                      CustomerMain.Value3, CustomerMain.Value4, CustomerMain.Value5, CustomerMain.Value6, CustomerMain.CompId
FROM         CustomerMain INNER JOIN
                      Gen_User ON CustomerMain.CreatedBy = Gen_User.UserID  where CustomerMain.CompId=@i_CompId
    --LEFT JOIN
    --Employee ON Lead.AllocatedToEmpID = Employee.EmpID	
    ORDER BY CustomerMain.CustomerCode DESC;
END
else

SELECT     Gen_User.Name AS LeadBy, CustomerMain.AccountID, CustomerMain.CustomerID, CustomerMain.CustomerCode, CustomerMain.CustomerName, 
                      CustomerMain.CityID, CustomerMain.Address, CustomerMain.AreaID, CustomerMain.Pincode, CustomerMain.Phone1, CustomerMain.MobileNo, CustomerMain.Email, 
                      CustomerMain.Website, CustomerMain.ContactPerson, CustomerMain.EmpID, CustomerMain.Specification, CustomerMain.Remarks, CustomerMain.Name1, 
                      CustomerMain.Name2, CustomerMain.Name3, CustomerMain.Name4, CustomerMain.Name5, CustomerMain.Name6, CustomerMain.Value2, CustomerMain.Value1, 
                      CustomerMain.Value3, CustomerMain.Value4, CustomerMain.Value5, CustomerMain.Value6, CustomerMain.CompId
FROM         CustomerMain INNER JOIN
                      Gen_User ON CustomerMain.CreatedBy = Gen_User.UserID  where CustomerMain.CompId=@i_CompId and  CustomerMain.CreatedBy = @i_UserID
    --LEFT JOIN
    --Employee ON Lead.AllocatedToEmpID = Employee.EmpID	
    ORDER BY CustomerMain.CustomerCode DESC;

end





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_User_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for select user record.
-- =============================================
 

CREATE PROCEDURE [dbo].[usp_User_Select]
	@i_RecID Bigint
AS
BEGIN
		
	SELECT     Gen_User.UserID, Gen_User.UserName, Gen_User.Password, Gen_User.Name, Gen_User.CompId, Gen_User.Company, Gen_User.User_Email, Gen_User.User_Password, Gen_User.User_ssl, 
                      Gen_User.User_Port, Gen_User.Company_Email, Gen_User.User_Host, Gen_User.User_NPassword
FROM         Gen_User LEFT OUTER JOIN
                      CompanyInfo ON CompanyInfo.CompId = Gen_User.CompId
	WHERE
		UserID = @i_RecID
	
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_User_MailDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List Of User
-- =============================================
CREATE PROCEDURE [dbo].[usp_User_MailDetails]
@i_CompId bigint,
@i_UserID bigint	 
AS
BEGIN
 
	
SELECT     Gen_User.UserID, Gen_User.UserName, Gen_User.Password, Gen_User.Name AS DisplayName, CASE Gen_User.IsActive WHEN 0 THEN ''DeActive'' WHEN 1 THEN ''Active'' END AS IsActive, 
                      CompanyInfo.CompId, Gen_User.Company, CompanyInfo.CompanyName, Gen_User.Mail_Send, Gen_User.User_Host, Gen_User.User_NPassword, Gen_User.User_Port, Gen_User.User_ssl, 
                      Gen_User.User_Email, Gen_User.User_Password
FROM         Gen_User LEFT OUTER JOIN
                      CompanyInfo ON CompanyInfo.CompId = Gen_User.CompId where CompanyInfo.CompId=@i_CompId and Gen_User.UserID=@i_UserID
	

	 
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetUserWisePrivilege_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of Privilege
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetUserWisePrivilege_List]
	@i_UserID bigint	
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @l_Privs VARCHAR(Max)  
	SET @l_Privs = ''#''

	SELECT 
		@l_Privs = coalesce(@l_Privs + ''#'', '''') + convert(varchar, PrivilegeID) 
	From Gen_UserScope 
	Inner Join Gen_User On Gen_User.UserID = Gen_UserScope.UserID 
			Where Gen_User.UserID = @i_UserID
			Order By PrivilegeID

	SET @l_Privs = @l_Privs + ''#''
	Select @l_Privs as PrivilegeID
		
END















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CustomerFFollowUp_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	List of LeadFollowUp
-- =============================================
CREATE PROCEDURE [dbo].[usp_CustomerFFollowUp_List]
--[usp_CustomerFFollowUp_List] ''54''
	 @i_LeadID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 			
		CustomerFollowUpId,
		NextFollowupDate as FollowupDate,
		Gen_User.Name as FollowupByName,
		Remarks
  FROM CustomerFollowUp
		Inner Join Gen_User ON Gen_User.UserID = CustomerFollowUp.FollowupBy
	Where LeadID = @i_LeadID
	Order By NextFollowupDate
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExceptionLog_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23-1-2011
-- Description:	Insert Exception Record in table
-- =============================================
Create PROCEDURE [dbo].[ExceptionLog_Insert]
	@i_Date Datetime,
	@i_ErrorMsg varchar(5000),
	@i_Module varchar(250),
	@i_UserID Bigint
AS

/* For manual Execution
	
DECLARE	@return_value int

EXEC	@return_value = [dbo].[ExceptionLog_Insert]
		@Date = N''2010-08-09'',
		@ErrorMsg = N''test'',
		@Module = N''test'' 
SELECT	''Return Value'' = @return_value

	
*/
BEGIN
	-- Insert record into Exception Log Table
	INSERT INTO ExceptionLog ( Date,  ErrorMessage,ModuleName,UserID)
						  VALUES (@i_Date, @i_ErrorMsg,@i_Module,@i_UserID);
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_VendorPayment_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 26th Jan 2011
-- Description:	Get Payment List
-- =============================================
CREATE PROCEDURE [dbo].[usp_VendorPayment_List]


AS
BEGIN
	SET NOCOUNT ON;
	SELECT Payment.PaymentID,
		Payment.PaymentCode,
		Payment.PaymentDate,
		Payment.VendorID,
		Vendor.Code as VendorCode,		
		Vendor.Name as VendorName,
		Payment.NetAmount,
		Payment.Narration
  FROM Payment
		Inner Join Vendor On Vendor.VendorID = Payment.VendorID
	Order By Payment.PaymentDate,Payment.PaymentCode Desc

END





set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_VendorPayment_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 26th Jan 2011
-- Description:	Select record from Payment and Payment Detail Table
-- =============================================
 CREATE PROCEDURE [dbo].[usp_VendorPayment_Select]
	@i_RecID Bigint 
AS
BEGIN
	SET NOCOUNT ON;
	
	 
	SELECT 
		Payment.PaymentID,
		Payment.PaymentCode ,
		Payment.PaymentDate ,
		Payment.VendorID ,
		Vendor.Code as VendorCode,
		Vendor.Name as VendorName,
		Payment.NetAmount,
		Payment.Narration,Payment.BankName,Payment.ChequeNo,Payment.ChequeDate
	FROM Payment
		Inner Join Vendor On Vendor.VendorID = Payment.VendorID
	Where Payment.PaymentID = @i_RecID

	-- Select Payment Detail
	SELECT 
		Indent.PIID,
		IsNull(PaymentDetail.Amount,0.00) as PaidAmount,
		(Indent.TotalAmount - Indent.PaidAmount)+isnull(Amount,0) as PendingAmount,
		Indent.PurchaseCode,
		Indent.PurchaseDate,
		IsNull(PaymentDetail.PayDetID,0) as PayDetID
	FROM 		PaymentDetail
		Right Join Indent On Indent.PIID = PaymentDetail.PIID
		Inner Join Payment On (Payment.PaymentID = PaymentDetail.PaymentID And  Indent.VendorID = Payment.VendorID)
	Where Payment.PaymentID = @i_RecID
	Order By PurchaseCode,PurchaseDate;


END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_VendorPayment_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 26th Jan 2011
-- Description:	Delete record from Payment And Detail
-- =============================================

CREATE PROCEDURE [dbo].[usp_VendorPayment_Delete]
	@i_RecID  bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

    Set @o_ErrorMesg='''';
	 
	Delete From Ledger Where TransactionTypeID = 5 And TransactionID = @i_RecID
	Update Indent 
	Set
		Indent.PaidAmount = Indent.PaidAmount - PaymentDetail.Amount
	From PaymentDetail
	Where PaymentDetail.PIID = Indent.PIID And 
		PaymentDetail.PaymentID = @i_RecID

	Delete From PaymentDetail Where PaymentID = @i_RecID;
	Delete From Payment Where PaymentID = @i_RecID;
	


END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SaleDocList_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SaleDocList_Insert]
	-- Add the parameters for the stored procedure here
	@i_SaleID Bigint,
	@i_DocName Varchar(250),
	@i_Remarks Varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

		--Delete From SaleDocList where SaleID=@i_SaleID
	INSERT INTO SaleDocList ( SaleID,DocName,Remarks)
			       VALUES(@i_SaleID,@i_DocName,@i_Remarks)
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SaleDocList_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SaleDocList_List]
	-- Add the parameters for the stored procedure here
	@i_RecID Bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM SaleDocList WHERE SaleID=@i_RecID
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_Sales_Service]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		PRIYANKA JADAV
-- Create date: 12/12/2014
-- Description:	SP FOR SALES & SERVICE ITEM DETAILS
-- =============================================
CREATE PROCEDURE [dbo].[rpt_Sales_Service]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		SELECT	SalesInvoice.SalesDate AS DATE,
				Item.Name AS ITEMNAME,
				SalesInvoiceDetail.Qty,
				Lead.CustomerName,
				''Sales'' AS TYPE
		FROM	SalesInvoiceDetail
		LEFT JOIN	Item ON Item.ItemID=SalesInvoiceDetail.ItemID
		LEFT JOIN	SalesInvoice ON SalesInvoice.SIID=SalesInvoiceDetail.SIID
		LEFT JOIN	LEAD ON LEAD.LeadID=SalesInvoice.CustomerID

	UNION ALL

		SELECT	ServiceModule.ServiceDate AS DATE,
				Item.Name AS ITEMNAME,
				ServiceDetails.Qty,
				ServiceModule.CustomerName,
				''Service'' AS TYPE
		FROM	ServiceDetails
		LEFT JOIN	Item ON Item.ItemID=ServiceDetails.ItemID
		LEFT JOIN	ServiceModule ON ServiceModule.ServiceId=ServiceDetails.SIID  

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ContactDetail_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for bind Customer lov.
-- =============================================
CREATE PROCEDURE [dbo].[usp_ContactDetail_LOV]
@i_TNC_Sub nvarchar(50)	 


AS
BEGIN
	SET NOCOUNT ON;
	SELECT     ContactID, ContactTitle, ContactName, Designation, Phone1, Phone2, Mobile, DoB, Email, DoA
FROM         ContactDetail
	
 
END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ContactDetail_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of Contact Person
-- =============================================
CREATE PROCEDURE [dbo].[usp_ContactDetail_List]
	@i_ContactType Tinyint,
	@i_RefID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		--Code,
		ContactID,
		RefID,
		ContactTitle,
		ContactName,
		Designation,
		Phone1,
		Phone2,
		Mobile,
		Email,
		DoB,
		DoA
	FROM
		ContactDetail
	WHERE
		ContactType = @i_ContactType AND
		RefID = @i_RefID
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Employee_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Sp is used for bind Employee combo box.
-- =============================================
Create PROCEDURE [dbo].[usp_Employee_DDL]
	
AS
BEGIN
 
	SET NOCOUNT ON;

    Select 
		EmpID,
		EmpName
	From 
		Employee
	Order By 
		EmpName;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Employee_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	List of Employee
-- =============================================
CREATE PROCEDURE [dbo].[usp_Employee_List]
	

@i_UserID bigint

AS
BEGIN
	SET NOCOUNT ON;

if @i_UserID = 1
begin
	SELECT     EmpID, EmpName, Address, PhoneNo, Email, Department
FROM         Employee 
	ORDER BY
		EmpName

end
else 
begin 

SELECT     EmpID, EmpName, Address, PhoneNo, Email, Department
FROM         Employee  where CreatedBy= @i_UserID
	ORDER BY
		EmpName
		
END
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Employee_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Select Employee record
-- =============================================
CREATE PROCEDURE [dbo].[usp_Employee_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT     EmpID, EmpName, Address, PhoneNo, Email, Department, Salary
FROM         Employee
	WHERE
		EmpId = @i_RecID 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_EmpDepartment_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[usp_EmpDepartment_DDL]

AS
BEGIN
	SET NOCOUNT ON;

	 Select Distinct Department From Employee Where Department<>''''
		Order By Department

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Employee_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Delete record from Employee 
-- =============================================
 Create PROCEDURE [dbo].[usp_Employee_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	
	DELETE FROM Employee
		WHERE EmpId = @i_RecID ;
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Item_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Delete record from Item 
-- =============================================
CREATE PROCEDURE [dbo].[usp_Item_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	-- Declare Local Variable
	DECLARE @l_varRec bigint;
		
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	SET @l_varRec=0;

	Delete From ItemDetail Where ItemID = @i_RecID
	DELETE FROM 
		Item
	WHERE 
		ItemID = @i_RecID
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_AddressDetail_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of Address Detail
-- =============================================
Create PROCEDURE [dbo].[usp_AddressDetail_List]
	@i_AddressType Tinyint,
	@i_RefID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		Address1,
		Address2,
		CityID,
		Pincode,
		Phone1,
		Phone2,
		Fax,
		Mobile
	FROM
		AddressDetail
	WHERE
		AddressType = @i_AddressType AND
		RefID = @i_RefID
END
' 
END
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
	SELECT
		@l_Path_BackUp = SysSettings.Path_BackUp
	FROM
		SysSettings
 
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
Create PROCEDURE [dbo].[usp_BackupList]
	 
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
Create PROCEDURE [dbo].[usp_Restore]
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Area_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Delete record from Area 
-- =============================================
Create PROCEDURE [dbo].[usp_Area_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';

	DELETE FROM Gen_Area
		WHERE AreaID = @i_RecID ;
				
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Area_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select Area record
-- =============================================
Create PROCEDURE [dbo].[usp_Area_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		
		 Name as AreaName 
	FROM
		Gen_Area
	WHERE
		AreaID = @i_RecID 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_CountryStateCityArea]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of Country,State,City and Area for Report
-- =============================================
CREATE PROCEDURE [dbo].[rpt_CountryStateCityArea]
	
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT
		Gen_Country.Name as Country,
		Gen_State.Name AS State,
		Gen_City.Name AS City,	
		Gen_Area.Name AS Area
	FROM
		Gen_Country LEFT JOIN
		Gen_State ON Gen_Country.CountryID = Gen_State.CountryID LEFT JOIN
		Gen_City ON Gen_State.StateID = Gen_City.StateID LEFT JOIN
		Gen_Area ON Gen_City.CityID = Gen_Area.CityID
	ORDER BY
		Country,
		State,
		City,
		Area

END
' 
END
GO
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Account_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-01-2011
-- Description:	List of Account
-- =============================================
--select * from AccountType
CREATE PROCEDURE [dbo].[usp_Account_List]
  
AS
BEGIN
	
    SELECT
		Account.AccountID,
		Account.AccountCode,
		Account.AccountName,
        OpeningBalance.CrAmount,
        OpeningBalance.DBAmount,
		AccountType.AccTypeID,
		AccountType.AcountType

	FROM
		Account 
			LEFT Join OpeningBalance on OpeningBalance.AccountID=Account.AccountID 
			LEFT Join AccountType On Account.AccTypeID=AccountType.AccTypeID 
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Account_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-01-2011
-- Description:	Account LOV
-- =============================================
CREATE PROCEDURE [dbo].[usp_Account_LOV]

AS
BEGIN

	SET NOCOUNT ON;
	Select 
		AccountID,
		AccountCode,
		AccountName 
	From Account
	--Where AccountID Not IN (5,6)
	Order By AccountCode

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetAccountList]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23th Jan 2011
-- Description:	Get Account Details For Seleced Account 
-- =============================================
CREATE FUNCTION [dbo].[fn_GetAccountList]
(
	@i_AccountID Bigint,
	@i_TransactionTypeID bigint,
	@i_TransactionID bigint	

)
RETURNS varchar(max)
AS
BEGIN
	DECLARE @l_AccountName varchar(100)
	
	SET @l_AccountName = ''''

	SELECT 
		@l_AccountName = coalesce(@l_AccountName+ '''', '''') + AccountName + Char(13)
	FROM 
		Account 
	WHERE AccountID IN (SELECT 
							AccountID 
						FROM 
							Ledger 
						WHERE 
							TransactionTypeID = @i_TransactionTypeID AND 
							TransactionID = @i_TransactionID AND 
							AccountID <> @i_AccountID
						)
	RETURN @l_AccountName

END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Account_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author: Manoj Savalia
-- Create date: 21-01-2011
-- Description: Select Record For Account
-- =============================================
CREATE PROCEDURE [dbo].[usp_Account_Select]
	@i_RecID Bigint
AS
BEGIN
 
	SELECT
		Account.AccountCode,
		Account.AccountName,
		Account.AccCreatedDate,
		OpeningBalance.CrAmount,
		OpeningBalance.DBAmount ,
		Account.AccTypeID
	FROM
		Account 
		LEFT Join OpeningBalance ON OpeningBalance.AccountID=Account.AccountID 
	WHERE
		Account.AccountID=@i_RecID
 
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PODocList_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Insert record in QuotationDocList Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_PODocList_Insert]
	@i_POID Bigint,
	@i_DocName Varchar(250)
	--@i_Remarks Varchar(250)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO PODocList ( PIID,DocName)
			       VALUES(@i_POID,@i_DocName)

END


















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Email_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Email_LOV] 
	-- Add the parameters for the stored procedure here
	@i_Type nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     Subject,Replace( Header,CHAR(10),''<BR />'') as Header, REPLACE(Footer,CHAR(10),''<BR />'') as Footer
FROM         Email
WHERE Type=@i_Type
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Email_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Email_List]
	-- Add the parameters for the stored procedure here
@i_CompId bigint,
@i_UserID bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if @i_UserID = 1
begin    

    -- Insert statements for procedure here
SELECT     Email_ID, Type, Subject, Header, Footer, Email.CompId
FROM         Email 
END

else 

SELECT     Email_ID, Type, Subject, Header, Footer, Email.CompId
FROM         Email  where CreatedBy = @i_UserID

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Email_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Email_Select]
	-- Add the parameters for the stored procedure here
	@i_RecID Bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     Email.*
FROM         Email where Email_ID=@i_RecID
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Indent_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	Get Purchase Invoice List
-- =============================================
CREATE PROCEDURE [dbo].[usp_Indent_List]
	@i_FYID BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Indent.PIID,
		Indent.PurchaseCode,
		Indent.PurchaseDate,
		Indent.VendorID,
		Vendor.Code,		
		Vendor.[Name] as VendorName,
		Indent.DueDays,
		Indent.GodownID,
		Indent.DueDate,
		Indent.TotalAmount,
		Indent.NetAmount,
		Indent.Narration,
		Indent.SrNo,
        Indent.PGID,
		Indent.AgainstCForm
  FROM Indent
		Inner Join Vendor On Vendor.VendorID = Indent.VendorID
	WHERE Indent.FYID = @i_FYID
	Order By Indent.PurchaseDate,Indent.PurchaseCode Desc

END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Vendor_PendingPaymentList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:        Manoj Savalia
-- Create date: 29th Jan 2011
-- Description:    Get Pending 1 List
-- =============================================
CREATE PROCEDURE [dbo].[usp_Vendor_PendingPaymentList]
@i_CompId bigint

AS
BEGIN
    SET NOCOUNT ON;
    SELECT  
        Vendor.Code as VendorCode,        
        Vendor.Name as VendorName,
        Indent.PurchaseCode,
        --PurchaseInvoice.PurchaseDate,
        Indent.DueDays,
        Indent.DueDate,
        Indent.NetAmount - Indent.PaidAmount as PendingAmount,
        Indent.NetAmount
    FROM Indent
        Inner Join Vendor On Vendor.VendorID = Indent.VendorID
    Where Indent.PaidAmount < Indent.NetAmount
    Order By Indent.VendorID,Indent.PurchaseDate,Indent.PurchaseCode
    
END

 set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_VendorPayment]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author: Manoj Savalia
-- Create date: 26th Jan 2011
-- Description: Get Receipt List
-- =============================================
CREATE PROCEDURE [dbo].[rpt_VendorPayment]

AS
BEGIN
SET NOCOUNT ON;

	SELECT Indent.PIID, 
	Vendor.Code as VendorCode, 
		Vendor.Name as VendorName, 
		Indent.PurchaseCode, 
		Indent.PurchaseDate, 
		Indent.DueDays, 
		Indent.DueDate, 
		Indent.NetAmount,
		IsNull(Indent.PaidAmount,0.00) as PaidAmount, 
		(Indent.NetAmount - Indent.PaidAmount) As PendingAmount 
	FROM Indent 
		Inner Join Vendor On Vendor.VendorID = Indent.VendorID  
	Order By PurchaseCode,PurchaseDate;

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Vendor_PaymentPendingList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:        Manoj Savalia
-- Create date: 03-06-2010
-- Description:    Get Customer Payment List
-- =============================================
CREATE PROCEDURE [dbo].[usp_Vendor_PaymentPendingList]
    

AS
BEGIN
    SET NOCOUNT ON;


SELECT     Vendor.Code, Indent.PurchaseCode, Indent.DueDays, Indent.NetAmount, Vendor.Name, Vendor.Fax
FROM         Indent INNER JOIN
                      Vendor ON Indent.VendorID = Vendor.VendorID
WHERE     (Indent.NetAmount > Indent.PaidAmount)
ORDER BY Indent.VendorID, Indent.PurchaseDate, Indent.PurchaseCode

--SELECT     SalesInvoice.SalesCode, SalesInvoice.NetAmount - SalesInvoice.PaidAmount AS PendingAmount, SalesInvoice.NetAmount, Lead.LeadNo AS CustomerCode, 
--                      Lead.CustomerName, Lead.Email,  SalesInvoice.SalesDate + SalesInvoice.DueDays as DueDate,SalesInvoice.RecDay,SalesInvoice.DueDays
--FROM         SalesInvoice INNER JOIN
--                      Lead ON SalesInvoice.CustomerID = Lead.LeadId
--WHERE     (SalesInvoice.NetAmount > SalesInvoice.PaidAmount)
--ORDER BY SalesInvoice.CustomerID, SalesInvoice.SalesDate, SalesInvoice.SalesCode

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_IndentRegister]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Roshni Patel
-- Create date: 23rd Jan 2011
-- Description:	Report of Purchase Invoice
-- =============================================
CREATE PROCEDURE [dbo].[rpt_IndentRegister]
	@i_FYID BIGINT 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Indent.PIID,
		Indent.PurchaseCode,
		Indent.PurchaseDate,
		Indent.VoucherNo,
		Indent.VoucherDate,
		Indent.VendorID,
		Vendor.Code,		
		Vendor.[Name] as VendorName,
		Indent.DueDays,
		Indent.DueDate,
		Indent.TotalAmount,
		Indent.ExciseAmount,
		Indent.CessAmount,
		Indent.HCessAmount,
		Indent.AmountAfterExcise,
		Indent.CSTAmount,
		Indent.VATAmount,
		Indent.AVATAmount,
		Indent.Discount,
		Indent.NetAmount,
		Indent.Narration,
		Indent.AgainstCForm
  FROM Indent
		Inner Join Vendor On Vendor.VendorID = Indent.VendorID
	WHERE Indent.FYID = @i_FYID
	Order By Indent.PurchaseDate,Indent.PurchaseCode Desc

END





set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_QuotationDocList_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Insert record in QuotationDocList Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_QuotationDocList_Insert]
	@i_QuotationID Bigint,
	@i_DocName Varchar(250)
	--@i_Remarks Varchar(250)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO QuotationDocList ( QuotationID,DocName)
			       VALUES(@i_QuotationID,@i_DocName)

END
















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PromoMail_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_PromoMail_List]
	-- Add the parameters for the stored procedure here
@i_CompId bigint,
@i_UserID bigint	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

if @i_UserID = 1
begin

    -- Insert statements for procedure here
SELECT     CustomerName, Email, Subject, Header, Footer, FileCount, PromoMailID, CompId
FROM         PromoMail where PromoMail.CompId=@i_CompId
END

else

SELECT     CustomerName, Email, Subject, Header, Footer, FileCount, PromoMailID, CompId
FROM         PromoMail where PromoMail.CompId=@i_CompId and PromoMail.CreatedBy = @i_UserID

end




set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PromoMail_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_PromoMail_Update]	
	-- Add the parameters for the stored procedure here
    @i_PCustomerName nvarchar(MAX),
	@i_PMail nvarchar(MAX),
	@i_Subject nVarchar(MAX),
	@i_PCategory nvarchar(MAX),
	@i_PMobile varchar(MAX),
	@i_Header nvarchar(MAX),
	@i_Footer nvarchar(MAX),
    @i_FileCount nvarchar(MAX),
	@i_ModifiedBy Bigint,
	@i_PromoMail_ID int,
	@i_CompId bigint,
	@o_ErrorMesg   varchar(500) OUTPUT


AS
BEGIN
		SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @l_EmailCount Bigint;
	Declare @l_Date DateTime;
	Declare @l_ErrorNo BigINt;
	--Set Local Variable value..
	Set @l_EmailCount=0;
	Set @o_ErrorMesg='''';
	--Set Current Date
	Select @l_Date=Convert(DateTime,GetDate(),5);
	Declare @l_ACDate DateTime;
	Set @l_ErrorNo = 0;
	
				Update 
					PromoMail
				Set 
                    CustomerName=@i_PCustomerName,
					Email = @i_PMail,
					Mobile=@i_PMobile,
					Category=@i_PCategory,
					Subject = @i_Subject,
					Header=@i_Header,
					Footer=@i_Footer,
                    FileCount=@i_FileCount,
					ModifiedBy=@i_ModifiedBy,
					CompId=@i_CompId,
					ModifiedDate=@l_Date
				Where 
					PromoMailID = @i_PromoMail_ID and CompId=@i_CompId
END







set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PromoMail_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_PromoMail_Insert]	
	-- Add the parameters for the stored procedure here
    @i_PCustomerName nvarchar(MAX),
	@i_PMail varchar(MAX),
	@i_PCategory nvarchar(MAX),
	@i_PMobile varchar(MAX),
	@i_Subject    Varchar(MAX),
	@i_Header    Varchar(MAX),
	@i_Footer    Varchar(MAX),
    @i_FileCount varchar(MAX),
	@i_CreatedBy   Bigint,
	@i_CompId bigint,
	@o_ErrorMesg   varchar(500) OUTPUT

AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @l_EmailCount Bigint;
	Declare @l_CreatedDate DateTime;
	Declare @l_ErrorNo BigInt;

	--Set Local Variable value..
	Set @l_EmailCount=0;
	Set @o_ErrorMesg='''';
	Set @l_ErrorNo = 0;

  	--Set Current Date
	Select @l_CreatedDate = Convert(DateTime,GetDate(),105);

					Insert Into PromoMail(CustomerName,Email,Mobile,Category,Subject ,Header ,Footer,FileCount,CreatedBy,CreatedDate,CompId ) 
 							Values  (@i_PCustomerName,@i_PMail,@i_PMobile,@i_PCategory,@i_Subject,@i_Header,@i_Footer,@i_FileCount,@i_CreatedBy,@l_CreatedDate,@i_CompId);
			
END









set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PromoMail_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_PromoMail_LOV] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     Subject,Replace( Header,CHAR(10),''<BR />''), REPLACE(Footer,CHAR(10),''<BR />'')
FROM         PromoMail
END



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PromoMail_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_PromoMail_Select]
--[usp_PromoMail_Select] ''25''
	-- Add the parameters for the stored procedure here
	@i_RecID Bigint
--	@i_CompId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     PromoMail.*
FROM         PromoMail where PromoMailID=@i_RecID 
END

Select DocID,
		PromoMailID,
		DocName
	From PromoMailDocList
	Where PromoMailID = @i_RecID ;
	


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_QuotationPaymentDetail_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Insert record in QuotationPaymentDetail Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_QuotationPaymentDetail_Insert]
	@i_QuotationID Bigint,
	@i_NextDate Datetime,
	@i_Payment Decimal(18,0),
	@i_Remarks Varchar(250)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO QuotationPaymentDetail ( QuotationID,NextDate,Payment, Remarks)
			       VALUES(@i_QuotationID,@i_NextDate,@i_Payment,@i_Remarks)

END


















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Commission_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 26th Jan 2011
-- Description:	Insert Record For Account
-- Sr.      Date        ModifiedBy         Description
-- =============================================
CREATE PROCEDURE [dbo].[usp_Commission_Insert]
	@i_FYID BIGINT,
	@i_AccountID varchar(20),
    @i_Date DateTime,
    @i_CRAmount Decimal(18,2),
    @i_DBAmount Decimal(18,2),
	@i_Narration varchar(250),
	@o_ErrorMesg Varchar(200) OUTPUT
 
    
AS
BEGIN

	Set @o_ErrorMesg = ''''
	Declare @l_Narration varchar(100)
	Set @l_Narration = ''Against Commission''
		---Insert Record in Ledger
			Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
						Values(@i_FYID,@i_AccountID, 7,				 @i_AccountID, @i_Date, @i_CRAmount, @i_DBAmount,@l_Narration );
    
--			Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
--						Values(@i_FYID,1,			7,				 @i_AccountID, @i_Date, @i_CRAmount, @i_DBAmount,@l_Narration );

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Expense_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		 Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	Update Expense Record
--Change History::
--Sr#	Date		Changed BY		DEscription
 -- =============================================
CREATE PROCEDURE [dbo].[usp_Expense_Update]
	@i_FYID BIGINT,
	@i_ExpenseID Bigint,
	@i_Date DateTime, 
	@i_Amount Decimal(15,3), 
	@i_Narration Varchar(250),
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	
 
	-- Set Local Variable
	SET @o_ErrorMesg='''';
	Declare @l_LedNarration varchar(50);	

	SET @l_LedNarration = ''''
	
	Select @l_LedNarration = ''Expense Against '' + ExpNo From Expense Where ExpenseID = @i_ExpenseID;
	Delete From Ledger Where TransactionTypeID = 4 And TransactionID = @i_ExpenseID;

	Update Expense 
	Set
		Date = @i_Date,
		Amount = @i_Amount,
		Narration = @i_Narration
	Where ExpenseID = @i_ExpenseID
		-- Insert Into Ledger for Cash Account
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
					Values(@i_FYID,1,			4,					@i_ExpenseID,		@i_Date,		0.00,@i_Amount,@l_LedNarration );
	  
	-- Insert Into Ledger For Expense Account
		Insert Into Ledger (FYID,AccountID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
					Values(@i_FYID,9,			4,					@i_ExpenseID,			@i_Date,@i_Amount,	0.00,@l_LedNarration );


END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Expense_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		 Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	Delete Expense Record
--Change History::
--Sr#	Date		Changed BY		DEscription
 -- =============================================
Create PROCEDURE [dbo].[usp_Expense_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT

AS
BEGIN
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
 
	
	Delete From Ledger Where TransactionTypeID = 4 And TransactionID = @i_RecID
	Delete From Expense  Where ExpenseID = @i_RecID;

	
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CustomerReceipt_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 26th Jan 2011
-- Description:	Delete record from Receipt And Detail
-- =============================================

CREATE PROCEDURE [dbo].[usp_CustomerReceipt_Delete]
	@i_RecID  bigint,
	@o_ErrorMesg Varchar(200) OUTPUT

AS
BEGIN
	SET NOCOUNT ON;

    Set @o_ErrorMesg='''';
	
		Delete From Ledger Where TransactionTypeID = 6 And TransactionID = @i_RecID
		Update SalesInvoice 
		Set
			SalesInvoice.PaidAmount = SalesInvoice.PaidAmount - ReceiptDetail.Amount,
			IsPaid=''False''
		From ReceiptDetail
		Where ReceiptDetail.SIID = SalesInvoice.SIID And 
			ReceiptDetail.ReceiptID = @i_RecID

		Delete From ReceiptDetail Where ReceiptID = @i_RecID;
		Delete From Receipt Where ReceiptID = @i_RecID;
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Customer_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for bind Customer lov.
-- =============================================
CREATE PROCEDURE [dbo].[usp_Customer_DDL]
	 
AS
BEGIN
	 SET NOCOUNT ON;

    Select 
		CustomerID,
		CustomerName
	From
		 CustomerMain
	Order By
		CustomerName
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemAdjustment_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record in ItemAdjustment Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_ItemAdjustment_Insert]
	@i_FYID Bigint,
	@i_AdjustDate Datetime,
	@i_ItemID Bigint,
	@i_Qty Decimal(18,3),
	@i_Narration Varchar(200),
	@i_UserID bigint,
	@i_GodownID int,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';

	SET @l_Date=Convert(Datetime,getDate(),5);
	 
	INSERT INTO ItemAdjustment (   FYID,   AdjustDate,   ItemID,   Qty,   Narration,CreatedBy,CreatedDate , GodownID)
						VALUES (@i_FYID,@i_AdjustDate,@i_ItemID,@i_Qty,@i_Narration,@i_UserID,@l_Date , @i_GodownID)


END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemAdjustment_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Insert record in ItemAdjustment Table
-- =============================================
CREATE PROCEDURE [dbo].[usp_ItemAdjustment_Update]
	@i_AdjustmentID Bigint,	
	@i_AdjustDate Datetime,
	@i_ItemID Bigint,
	@i_Qty Decimal(18,3),
	@i_Narration Varchar(200),	
	@i_UserID bigint,
	@i_GodownID int,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	DECLARE	@l_Date Datetime;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';

	SET @l_Date=Convert(Datetime,getDate(),5);
	 
	UPDATE ItemAdjustment
		SET 
			AdjustDate = @i_AdjustDate,
			ItemID = @i_ItemID,
			Qty = @i_Qty,
			Narration = @i_Narration,
			ModifiedBy = @i_UserID,
			ModifiedDate = @l_Date,
			GodownID=@i_GodownID
		WHERE
			AdjustmentID = @i_AdjustmentID

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemAdjustment_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Delete record from ItemAdjustment 
-- =============================================
CREATE PROCEDURE [dbo].[usp_ItemAdjustment_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';

	DELETE FROM  ItemAdjustment
		WHERE AdjustmentID = @i_RecID ;
				
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Expense_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		 Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	Select State
-- Change history:
 -- =============================================
Create PROCEDURE [dbo].[usp_Expense_Select]
	@i_RecID BIGINT 
AS
BEGIN
	Select
		ExpenseID,
		ExpNo,
		Date,
		Amount,
		Narration
	From 
		Expense
	Where
		ExpenseID = @i_RecID;
	 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Expense_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		 Manoj Savalia
-- Create date: 23rd Jan 2011
-- Description:	List of State
-- =============================================
CREATE PROCEDURE [dbo].[usp_Expense_List]
	@i_FYID Bigint
AS
BEGIN
	SELECT
		Expense.ExpenseID,
		Expense.ExpNo,
		Expense.Date,
		Expense.Amount,
		Expense.Narration
	FROM
		Expense
	WHERE FYID = @i_FYID
		ORDER By Date
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PromoMailDocList_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_PromoMailDocList_Insert]
	@i_PromoMailID Bigint,
	@i_DocName Varchar(250)
	--@i_Remarks Varchar(250)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO PromoMailDocList ( PromoMailID,DocName)
			       VALUES(@i_PromoMailID,@i_DocName)

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CompanyInfo_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Select CompanyInfo record
-- =============================================
CREATE PROCEDURE [dbo].[usp_CompanyInfo_Select]
@i_CompId bigint	 
AS
BEGIN
	SET NOCOUNT ON;

SELECT CompId, CompanyCode, CompanyName, Address1, Address2, Pincode, Phone1, Phone2, Mobile, Fax, Email, ReportPath, DocPath, Con_Email, Con_Password, 
               Host, isnull(Port,0) as Port, isnull(ssl,0)as ssl, Logo, Header, Footer, BusinessLine, Name1, Name2, Name3, Name5, Name4, Name6, Value1, Value2, Value4, Value3, Value5, Value6, CityName,
               State, Com_Profile, BackupDBName
FROM  CompanyInfo
where CompId=@i_CompId
END









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CompanyInfoDetail_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CompanyInfoDetail_Select]
	-- Add the parameters for the stored procedure here
	@i_CompId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT CompId, CompanyCode, CompanyName, BusinessLine, Address1, Address2, CityName, State, Pincode, Phone1, Phone2, Mobile, Fax, Email, ReportPath, DocPath, 
               Con_Email, Con_Password, ModifiedBy, ModifiedDate, Host, Port, ssl, Logo, Header, Footer, Name1, Name2, Name3, Name4, Name5, Name6, Value1, Value2, Value3, 
               Value4, Value5, Value6, Com_Profile
FROM  CompanyInfo
WHERE CompId = @i_CompId
END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CompanyInfo_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CompanyInfo_List]
--[usp_CompanyInfo_List] ''1''
	-- Add the parameters for the stored procedure here
@i_CompId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
if @i_CompId=1
begin
	SELECT  DISTINCT CompanyInfo.CompanyName,CompanyInfo.CompId
FROM  CompanyInfo
end
else
begin
	SELECT  DISTINCT CompanyInfo.CompanyName,CompanyInfo.CompId
FROM  CompanyInfo where CompanyInfo.CompId=@i_CompId-- and CompanyInfo.CompId<>1
end
-- where CompId=@i_CompId 
--GROUP BY CompanyName
END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CompanyInfo_Detail_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--select * from SalesInvoice
CREATE PROCEDURE [dbo].[usp_CompanyInfo_Detail_Update]
	-- Add the parameters for the stored procedure here
	@i_CompId bigint,
	
	@i_CompanyName nvarchar(150),
	@i_BusinessLine nvarchar(50),
@i_Address1 nvarchar(50),
@i_Address2 nvarchar(50),
@i_State nvarchar(50),
	@i_City nvarchar(50),
@i_Pincode nvarchar(50),
@i_Phone1 nvarchar(50),
@i_Phone2 nvarchar(50),
@i_Mobile nvarchar(50),
@i_Email nvarchar(50),
@i_Logo nvarchar(max),
@i_Header nvarchar(max),
@i_Footer nvarchar(max),
@i_Name1 nvarchar(50),
@i_Name2 nvarchar(50),
@i_Name3 nvarchar(50),
@i_Name4 nvarchar(50),
@i_Name5 nvarchar(50),
@i_Name6 nvarchar(50),
@i_Value1 nvarchar(50),
@i_Value2 nvarchar(50),
@i_Value3 nvarchar(50),
@i_Value4 nvarchar(50),
@i_Value5 nvarchar(50),
@i_Value6 nvarchar(50),
@i_CProfile nvarchar(MAX),
@i_ReportPath nvarchar(max),
@i_DocPath nvarchar(max)
AS
BEGIN
		SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE	@l_Date Datetime;
	SET @l_Date=Convert(Datetime,getDate(),5);
-----
declare @ComName varchar(100)
declare @Sub1 varchar(100)
declare @Sub2 varchar(100)
declare @car varchar(100)

--select @ComName=CompanyCode from CompanyInfo where CompId=@i_CompId 
set @ComName=@i_CompanyName
set @Sub1=@ComName
set @Sub2=@ComName

if CHARINDEX('' '',@ComName) > 0
begin
    PRINT ''SPACE IN STRING'' 
	set @Sub1=SUBSTRING(@ComName, 1, CHARINDEX('' '', @ComName) - 1)
set @Sub2=SUBSTRING(@ComName, CHARINDEX('' '', @ComName) + 1, 8000) 
set @car=LEFT(@Sub1, 1)+LEFT(@Sub2, 1)  
PRINT @car
end
ELSE
BEGIN 
PRINT ''NO SPACE''
	set @Sub1=@ComName
 set @car=LEFT(@Sub1, 2) 
PRINT @car
END

------------
	Update	CompanyInfo
		Set
			CompanyName=@i_CompanyName,
			CompanyCode=@car,
			BusinessLine=@i_BusinessLine,
Address1=@i_Address1,
Address2=@i_Address2,
CityName=@i_City,
			State=@i_State,
			Pincode=@i_Pincode,
Phone1=@i_Phone1,
Phone2=@i_Phone2,
Mobile=@i_Mobile,
Email=@i_Email,
Logo=@i_Logo,
Header=@i_Header,
Footer=@i_Footer,
Name1=@i_Name1,
Name2=@i_Name2,
Name3=@i_Name3,
Name4=@i_Name4,
Name5=@i_Name5,
Name6=@i_Name6,
Value1=@i_Value1,
Value2=@i_Value2,
Value3=@i_Value3,
Value4=@i_Value4,
Value5=@i_Value5,
Value6=@i_Value6,
Com_Profile=@i_CProfile,
ReportPath=@i_ReportPath,
DocPath=@i_DocPath

where CompanyInfo.CompId=@i_CompId

	
END










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_Company]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_Company]
	-- Add the parameters for the stored procedure here
(
	@i_CompId bigint
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     CompId, CompanyCode, CompanyName, BusinessLine, Address1, Address2, CityName, State, Pincode, Phone1, Phone2, Mobile, Fax, Email, ReportPath, 
                      DocPath
FROM         CompanyInfo where CompanyInfo.CompId=@i_CompId
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Email_Detail_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Email_Detail_Update]
	-- Add the parameters for the stored procedure here
	@i_Con_Email nvarchar(150),
	@i_Con_Password nvarchar(50),
@i_Con_Host nvarchar(50),
@i_Con_Port nvarchar(50),
@i_Con_SSL nvarchar(50),
@i_CompId bigint,
	@i_ModifiedBy bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE	@l_Date Datetime;
	SET @l_Date=Convert(Datetime,getDate(),5);

	Update	CompanyInfo
		Set
			Con_Email=@i_Con_Email,
			Con_Password=@i_Con_Password,
Host=@i_Con_Host,
Port=@i_Con_Port,
ssl=@i_Con_SSL,
			ModifiedBy=@i_ModifiedBy,
			
			ModifiedDate=@l_Date
where CompId=@i_CompId
	
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_Company1]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[rpt_Company1]
	-- Add the parameters for the stored procedure here
(
	@i_CompId bigint
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     CompId, CompanyCode, CompanyName, BusinessLine, Address1, Address2, CityName, State, Pincode, Phone1, Phone2, Mobile, Fax, Email, ReportPath, 
                      DocPath
FROM         CompanyInfo where CompId=@i_CompId
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_CompanyOld]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_CompanyOld]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     CompId, CompanyCode, CompanyName, BusinessLine, Address1, Address2, CityName, State, Pincode, Phone1, Phone2, Mobile, Fax, Email, ReportPath, 
                      DocPath
FROM         CompanyInfo
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CompanyCount]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Count(*) from CompanyInfo
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CompanyCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CompanyCount]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Count(*) as Company from CompanyInfo
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Company_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Company_DDL]
	-- Add the parameters for the stored procedure here
--	<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
--	<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select 
		CompId as CompanyID,
		CompanyName
	From
		CompanyInfo
	Order By
		CompId
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_VendorPayment_PendingPI_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 26th Jan 2011
-- Description:	Get Pending Payment List
-- =============================================
CREATE PROCEDURE [dbo].[usp_VendorPayment_PendingPI_List]
	@i_VendorID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	Select PIID,
		0.000 as PaidAmount,
		(NetAmount - PaidAmount) as PendingAmount,
		PurchaseCode,
		PurchaseDate
	From Indent
	Where Indent.VendorID = @i_VendorID And
		(NetAmount - PaidAmount)>0
	Order By PurchaseCode,PurchaseDate;



END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Indent_Purchase_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for bind Vendor lov.
-- =============================================
CREATE PROCEDURE [dbo].[usp_Indent_Purchase_LOV]
	 @i_RecID int
AS
BEGIN
	 SET NOCOUNT ON;

SELECT     IndentDetail.ItemID, IndentDetail.Qty,IndentDetail.Rate, IndentDetail.Amount, IndentDetail.ExciseAmount, IndentDetail.RemainingQty, 
                      IndentDetail.ReceivedQty, IndentDetail.CessAmount, IndentDetail.CessRate, IndentDetail.HCessRate, IndentDetail.HCessAmount, 
                      IndentDetail.AmountAfterExcise, IndentDetail.CSTRate, IndentDetail.CSTAmount, IndentDetail.VATRate, IndentDetail.VATAmount, 
                      IndentDetail.AVATRate, IndentDetail.AVATAmount, IndentDetail.NetAmount, IndentDetail.ServiceRate, IndentDetail.ServiceAmount
FROM         Indent INNER JOIN
                      IndentDetail ON Indent.PIID = IndentDetail.PIID




END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_Get_ReceivedQty]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--select * from Item
--select * from SalesInvoiceDetail
--select * from OrderBookingDetail

--select * from pURCHASEiNVOICEDetail
--select * from PODetail

CREATE PROCEDURE [dbo].[rpt_Get_ReceivedQty]
--[rpt_Get_ReceivedQty] ''ITEM-00002'',''2''
	-- Add the parameters for the stored procedure here
	@i_ItemCode nvarchar(50),
	@i_POID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select Sum(b.ReceivedQty)
	From Indent a
	LEFT JOIN	IndentDetail  b On b.PIID=a.PIID
	Where b.ItemID=(Select ItemId From Item Where Code=@i_ItemCode) And a.PGID=@i_POID
END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_QuotationContact_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_QuotationContact_Select]
--[usp_QuotationConatct_Select] ''PF/QU/15-16/00021''
	-- Add the parameters for the stored procedure here
	
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

--SELECT   distinct  TNCID,TNC_Sub, TNC_Desc,Q_TNC_ID
SELECT     Code, ContactTitle, ContactName, Designation, Phone1, Phone2, Mobile, Email, DoB, DoA,''True'' as IsChecked
FROM         Quotation_Contact
WHERE     (Code = @i_Code)


END










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_QuotationQContact_Delete_On_Close]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_QuotationQContact_Delete_On_Close]
	-- Add the parameters for the stored procedure here
	
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

DELETE FROM Quotation_Contact WHERE Code=@i_Code

	

END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_QuotationFollowUp_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	List of LeadFollowUp
-- =============================================
create PROCEDURE [dbo].[usp_QuotationFollowUp_List]
	 @i_LeadID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 			
		QuotationFollowUpId,
		FollowupDate as FollowupDate,
		Gen_User.Name as FollowupByName,
		Remarks
  FROM QuotationFollowUp
		Inner Join Gen_User ON Gen_User.UserID = QuotationFollowUp.FollowupBy
	Where QuotationID = @i_LeadID
	Order By FollowupDate
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SaleContact_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_SaleContact_Select]
--[usp_QuotationConatct_Select] ''PF/QU/15-16/00021''
	-- Add the parameters for the stored procedure here
	
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

--SELECT   distinct  TNCID,TNC_Sub, TNC_Desc,Q_TNC_ID
SELECT     Code, ContactTitle, ContactName, Designation, Phone1, Phone2, Mobile, Email, DoB, DoA
FROM         Sale_Contact
WHERE     (Code = @i_Code)


END










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SaleContact_Delete_On_Close]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_SaleContact_Delete_On_Close]
	-- Add the parameters for the stored procedure here
	
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

DELETE FROM Sale_Contact WHERE Code=@i_Code

	

END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ServiceContact_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_ServiceContact_Select]
--[usp_QuotationConatct_Select] ''PF/QU/15-16/00021''
	-- Add the parameters for the stored procedure here
	
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

--SELECT   distinct  TNCID,TNC_Sub, TNC_Desc,Q_TNC_ID
SELECT     Code, ContactTitle, ContactName, Designation, Phone1, Phone2, Mobile, Email, DoB, DoA
FROM         Service_Contact
WHERE     (Code = @i_Code)


END










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ServiceContact_Delete_On_Close]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_ServiceContact_Delete_On_Close]
	-- Add the parameters for the stored procedure here
	
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

DELETE FROM Service_Contact WHERE Code=@i_Code

	

END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_ItemBeanCard]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	List of Stock for Bean card 
-- =============================================
Create PROCEDURE [dbo].[rpt_ItemBeanCard]
	@i_StockID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		Item.Code,
		Item.Name,
		ItemStockDetail.Date,
		ItemStockDetail.Description,
		CASE
			When ItemStockDetail.Qty >= 0 Then ItemStockDetail.Qty
			Else 0
		END AS InQty,
		CASE
			When ItemStockDetail.Qty < 0 Then (-1) * ItemStockDetail.Qty
			Else 0
		END AS OutQty
	FROM
		ItemStock INNER JOIN
		ItemStockDetail ON ItemStock.StockID = ItemStockDetail.StockID INNER JOIN
		Item ON ItemStock.ItemID = Item.ItemID
	WHERE
		ItemStock.StockID = @i_StockID
	ORDER BY
		ItemStockDetail.StockDetailID

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemStock_Editable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Count stock if its editable or not?
-- =============================================
CREATE PROCEDURE [dbo].[usp_ItemStock_Editable]
	@i_StockID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Count(StockID) 
		FROM ItemStockDetail 
	WHERE StockID = @i_StockID AND GTID <> 100;
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemCategory_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Get Item Category DDL
-- =============================================
Create PROCEDURE [dbo].[usp_ItemCategory_DDL]
AS
BEGIN
	SET NOCOUNT ON;
		
	Select 
		CategoryID,
		Name
	From 
		ItemCategory	
	Order By 
		Name
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemCategory_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Delete record from ItemCategory 
-- =============================================
Create PROCEDURE [dbo].[usp_ItemCategory_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	 -- Set Local Variable
	SET @o_ErrorMesg='''';
	
	DELETE FROM  ItemCategory
		WHERE CategoryID = @i_RecID ;
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ItemCategory_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Select Item Category
-- =============================================
Create PROCEDURE [dbo].[usp_ItemCategory_Select]
	@i_RecID Bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		
		[Name],
		ItemGroupID
	FROM
		 ItemCategory
	WHERE
		CategoryID = @i_RecID 

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Select_CatID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Select_CatID]
	-- Add the parameters for the stored procedure here
	@i_Cat nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     CategoryID FROM ItemCategory WHERE Name=@i_Cat

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ServiceModule_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
 
-- Description:	Insert record in ServiceModule Table
-- =============================================
--select * from ServiceModule
--update ServiceModule set FYID=1
CREATE PROCEDURE [dbo].[usp_ServiceModule_Insert]	 
	@i_RequestNo	varchar(20),
	@i_ServiceDate	datetime,
	@i_CustomerID Bigint,
	@i_CustomerName	varchar(150),
	@i_Address	varchar(500),
	@i_MobileNo	varchar(20),
	@i_FYID Bigint,
	@i_ModelNumber	varchar(50),
	@i_Problem	varchar(500),
	@i_AttendedBy	bigint,
	@i_JobComputed	varchar(500),
	@i_Remarks	varchar(500),
	@i_OtherRequirement	varchar(500),
	@i_Charges	decimal(18,0),
	@i_SIID bigint,
	@i_GodownID int,
	@i_CallID int,
	@i_TypeOfSale varchar(50),
	@i_UserID bigint,
	@i_Status nvarchar(50),
	
	@i_Cnt Bigint,

	
	@i_TotalAmount decimal(18,2),
	@i_ServiceAmount decimal(18,2),
	@i_ExciseAmount decimal(18,2),
	@i_CessAmount decimal(18,2),
	@i_HCessAmount decimal(18,2),
	@i_AmountAfterExcise decimal(18,2),
	@i_CSTAmount decimal(18,2),
	@i_VATAmount decimal(18,2),
	@i_AVATAmount decimal(18,2),
	@i_Discount decimal(18,2),
	@i_NetAmount decimal(18,2),
	@i_PaidAmount decimal(18,2),
	@i_XMLString xml,
	@i_EmpAllToID bigint,
	@i_CompId bigint,
	@o_ErrorMesg Varchar(200) OUTPUT 
AS
BEGIN
	SET NOCOUNT ON;

	-- Declare Local Variable
	 DECLARE	@l_Date Datetime;
	 DECLARE @l_varRec Bigint;
 	DECLARE @l_CustomerAccID Bigint
	DECLARE @l_LedNarration varchar(50)
	DECLARE @l_StockID Bigint
	DECLARE @l_NewDetID Bigint
	DECLARE @l_NewID BIGINT
	DECLARE @l_Description varchar(100);
	-- Set Local Variable value..
	SET @l_varRec = 0;
	SET @l_Description  = ''''
	SET @l_CustomerAccID = 0
	SET @l_LedNarration =''''
	SET @l_StockID = 0
	SET @l_NewDetID = 0
	-- Variable for StockDetail
 
	SET @o_ErrorMesg='''';
	SET @l_NewID = 0
 
--	BEGIN TRY  
--	BEGIN TRAN

--	SELECT @l_varRec = Count(SIID) From ServiceModule Where RequestNo = @i_RequestNo
-- 		IF @l_varRec = 0
-- 			BEGIN
		Set @l_LedNarration  = ''Service Against '' + @i_RequestNo
	-- Set Local Variable
 
	 
	SET @l_Date=Convert(Datetime,getDate(),5);
 
	INSERT INTO 
		ServiceModule
			(   RequestNo,   ServiceDate,CustomerID,   CustomerName,   Address,   MobileNo,     ModelNumber,   Problem,   AttendedBy,   JobComputed,   Remarks,   OtherRequirement,   Charges,CreatedBy,CreatedDate,SIID ,  TotalAmount, ServiceAmount,ExciseAmount,CessAmount,HCessAmount, AmountAfterExcise, CSTAmount,VATAmount, AVATAmount,Discount,NetAmount,PaidAmount, GodownID,CallID ,TypeOfSale,FYID,EmpAllToID,Status,CompId)
	 VALUES (@i_RequestNo,@i_ServiceDate,@i_CustomerID,@i_CustomerName,@i_Address,@i_MobileNo,@i_ModelNumber,@i_Problem,@i_AttendedBy,@i_JobComputed,@i_Remarks,@i_OtherRequirement,@i_Charges,@i_UserID,@l_Date,@i_SIID , @i_TotalAmount,@i_ServiceAmount, @i_ExciseAmount,@i_CessAmount,@i_HCessAmount, @i_AmountAfterExcise,@i_CSTAmount,@i_VATAmount, @i_AVATAmount,@i_Discount,@i_NetAmount, @i_PaidAmount , @i_GodownID,@i_CallID,@i_TypeOfSale,@i_FYID,@i_EmpAllToID,@i_Status,@i_CompId)
	 
	SET @l_NewID = Scope_Identity();
   Set @o_ErrorMesg=convert(varchar, @l_NewID)
 				-- Customer''s Ledger Effect
				
					IF @i_Cnt > 0
				BEGIN		
					SELECT  x.d.value(''ItemID[1]'',''Bigint'') AS ItemID,
						x.d.value(''ItemDesc[1]'',''varchar(100)'') AS ItemDesc,							
						x.d.value(''Qty[1]'',''Decimal(18,3)'') AS Qty,
						x.d.value(''Rate[1]'',''Decimal(18,2)'') AS Rate,
						x.d.value(''Amount[1]'',''Decimal(18,2)'') AS Amount,
						x.d.value(''TaxClassID[1]'',''Bigint'') AS TaxClassID,
						x.d.value(''ServiceRate[1]'',''Decimal(5,2)'') AS ServiceRate,						
						x.d.value(''ServiceAmount[1]'',''Decimal(18,2)'') AS ServiceAmount,
						x.d.value(''ExciseRate[1]'',''Decimal(5,2)'') AS ExciseRate,						
						x.d.value(''ExciseAmount[1]'',''Decimal(18,2)'') AS ExciseAmount,
						x.d.value(''EduCessRate[1]'',''Decimal(5,2)'') AS EduCessRate,						
						x.d.value(''EduCessAmount[1]'',''Decimal(18,2)'') AS EduCessAmount,
						x.d.value(''HEduCessRate[1]'',''Decimal(5,2)'') AS HEduCessRate,						
						x.d.value(''HEduCessAmount[1]'',''Decimal(18,2)'') AS HEduCessAmount,
						x.d.value(''AmountAfterExcise[1]'',''Decimal(18,2)'') AS AmountAfterExcise,						
						x.d.value(''CSTRate[1]'',''Decimal(5,2)'') AS CSTRate,
						x.d.value(''CSTAmount[1]'',''Decimal(18,2)'') AS CSTAmount,
						x.d.value(''VATRate[1]'',''Decimal(5,2)'') AS VATRate,	
						x.d.value(''VATAmount[1]'',''Decimal(18,2)'') AS VATAmount,
						x.d.value(''AVATRate[1]'',''Decimal(5,2)'') AS AVATRate,
						x.d.value(''AVATAmount[1]'',''Decimal(18,2)'') AS AVATAmount,
						x.d.value(''NetAmount[1]'',''Decimal(18,2)'') AS NetAmount	
					INTO #tmpDetail				
					FROM 
						@i_XMLString.nodes(''/NewDataSet/Table'') x(d);

					INSERT INTO ServiceDetails (SIID,    ItemID,   ItemDesc,     Qty,   Rate,  Amount,   TaxClassID,    ServiceRate,  ServiceAmount,   ExciseRate,   ExciseAmount,       CessRate,      CessAmount,     HCessRate,      HCessAmount,   AmountafterExcise,   CSTRate,   CSTAmount,   VATRate,   VATAmount,   AVATRate,   AVATAmount,   NetAmount)
											SELECT @l_NewID,T1.ItemID,T1.ItemDesc,T1.Qty,T1.Rate,T1.Amount,T1.TaxClassID,T1.ServiceRate,T1.ServiceAmount,T1.ExciseRate,T1.ExciseAmount,T1.EduCessRate,T1.EduCessAmount,T1.HEduCessRate,T1.HEduCessAmount,T1.AmountafterExcise,T1.CSTRate,T1.CSTAmount,T1.VATRate,T1.VATAmount,T1.AVATRate,T1.AVATAmount,T1.NetAmount FROM #tmpDetail T1 

				SET @l_Description = ''Against Service Details : '' + @i_RequestNo; 
				Insert Into ItemStock(FYID,      ItemID,    QOH, MinLevel, MaxLevel, ReorderLvl, CreatedBy, CreatedDate , GodownID)
 							Select @i_FYID,#tmpDetail.ItemID, 0, 0, 0, 0, @i_UserID, @i_ServiceDate, @i_GodownID
							From #tmpDetail Where #tmpDetail.ItemID Not In(
								Select ItemStock.ItemID From ItemStock WHERE ItemStock.FYID = @i_FYID)
				
				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
					Select ItemStock.StockID, 100,ItemStock.StockID, @i_ServiceDate, ''Opening Stock'',0.000
						From #tmpDetail 
							Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
							Where ItemStock.QOH = 0 And ItemStock.FYID = @i_FYID
								And ItemStock.StockID Not In (Select StockID from ItemStockDetail Where 
									ItemStockDetail.StockID = ItemStock.StockID And ItemStockDetail.GTID=100)

				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
						Select ItemStock.StockID, 300,@l_NewID, @i_ServiceDate, @l_Description,((-1) * #tmpDetail.Qty)
							From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
							Where ItemStock.FYID = @i_FYID
		 				
				-- Update Stock
				Update ItemStock 
					Set ItemStock.QOH = ItemStock.QOH -
						(Select Sum(#tmpDetail.Qty) From #tmpDetail Where ItemStock.ItemID = #tmpDetail.ItemID )
				From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
				Where 
					ItemStock.FYID = @i_FYID and ItemStock.GodownID=@i_GodownID
 
 				END
			  END
--		  ELSE
--			  BEGIN
--					SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 25001 );
--			  END			
		
--	COMMIT TRAN
--	END TRY
--		BEGIN CATCH 
--			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );  
--		ROLLBACK TRAN  
--	END CATCH 	

--END















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_Customer_Payment_Receipt]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author: Manoj Savalia
-- Create date: 26th Jan 2011
-- Description: Get Receipt List
-- =============================================
CREATE PROCEDURE [dbo].[rpt_Customer_Payment_Receipt]
	@i_ReceiptID BIGINT
AS
BEGIN
SET NOCOUNT ON;

	SELECT DISTINCT A.ReceiptCode,C.CUSTOMERNAME,A.NetAmount
	FROM Receipt A
		LEFT JOIN ReceiptDetail B ON B.ReceiptID=A.ReceiptID
		LEFT JOIN LEAD C ON C.LEADID=A.CUSTOMERID
	WHERE A.ReceiptID=@i_ReceiptID


END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CustomerReceipt_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 26th Jan 2011
-- Description:	Select record from Receipt and Receipt Detail Table
-- =============================================
 CREATE PROCEDURE [dbo].[usp_CustomerReceipt_Select]
	@i_RecID Bigint

AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT     Receipt.ReceiptID, Receipt.ReceiptCode, Receipt.ReceiptDate, Receipt.CustomerID,
 Receipt.NetAmount, Receipt.Narration,
 Receipt.BankName, Receipt.ChequeNo, 
 Receipt.ChequeDate, Lead.CustomerName, Lead.LeadNo as CustomerCode
FROM         Receipt INNER JOIN
                      Lead ON Receipt.CustomerID = Lead.LeadId
WHERE     (Receipt.ReceiptID = @i_RecID)


	-- Select Payment Detail
SELECT     SalesInvoice.SIID, ISNULL(ReceiptDetail.Amount, 0.00) AS PaidAmount, SalesInvoice.NetAmount - SalesInvoice.PaidAmount + ISNULL(ReceiptDetail.Amount, 0) 
                      AS PendingAmount, SalesInvoice.SalesCode, SalesInvoice.SalesDate, CONVERT(BIt, ISNULL(ReceiptDetail.RecDetID, 0)) AS RecDetID
FROM         ReceiptDetail RIGHT OUTER JOIN
                      SalesInvoice ON SalesInvoice.SIID = ReceiptDetail.SIID INNER JOIN
                      Receipt ON Receipt.ReceiptID = ReceiptDetail.ReceiptID AND SalesInvoice.CustomerID = Receipt.CustomerID
WHERE     (Receipt.ReceiptID = @i_RecID)
ORDER BY SalesInvoice.SalesCode, SalesInvoice.SalesDate

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_QuotationTNC_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--select * from Quotation_TNC
CREATE PROCEDURE [dbo].[usp_QuotationTNC_Update]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub nvarchar(250),
	@i_Code nvarchar(50),
	@i_TNC_Desc nvarchar(Max),
	@i_TNCID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
DELETE  FROM Quotation_TNC WHERE  Code=@i_Code and TNCID=@i_TNCID;

	INSERT INTO Quotation_TNC
                      (Code,TNC_Sub,TNC_Desc,TNCID)
VALUES     (@i_Code,@i_TNC_Sub,@i_TNC_Desc,@i_TNCID)

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_QuotationTNC_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_QuotationTNC_Insert]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub nvarchar(250),
	@i_Code nvarchar(50),
	@i_TNC_Desc nvarchar(Max)
	--@i_TNCID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--DELETE  FROM Quotation_TNC WHERE  Code=@i_Code;

	INSERT INTO Quotation_TNC
                      (Code,TNC_Sub,TNC_Desc
--,TNCID
)
VALUES     (@i_Code,@i_TNC_Sub,@i_TNC_Desc
--,@i_TNCID
)

END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_Quotation_TNC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--	SELECT *,TNC_Desc FROM Quotation_TNC
--u
CREATE PROCEDURE [dbo].[rpt_Quotation_TNC]
--[rpt_Quotation_TNC] ''PF/QU/15-16/00020'',''QUOTATION''
	-- Add the parameters for the stored procedure here
	@i_Code as nvarchar(50),
	@i_TNC_Sub as nvarchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--	SELECT TNCID,TNC_Desc
--FROM         Quotation_TNC
--WHERE Code=@i_Code AND TNC_Sub=@i_TNC_Sub

SELECT TNC_Desc
FROM         Quotation_TNC
WHERE Code=@i_Code AND TNC_Sub=@i_TNC_Sub
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_QuotationTNC_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_QuotationTNC_Select]
--[usp_QuotationTNC_Select] ''PF/QU/15-16/00021''
	-- Add the parameters for the stored procedure here
	
	@i_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

--SELECT   distinct  TNCID,TNC_Sub, TNC_Desc,Q_TNC_ID
SELECT     TNC_Sub, TNC_Desc
FROM         Quotation_TNC
WHERE     (Code = @i_Code)


END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_FYYear_DDL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Get Financial Year List
-- =============================================
Create PROCEDURE [dbo].[usp_FYYear_DDL]

AS
BEGIN
	SET NOCOUNT ON;
	Select 
		FYID,
		Convert(varchar,DatePart(Year,StartDate)) + '' - '' + Convert(varchar,DatePart(Year,EndDate)) as FYYears
	From FinancialYear
	Order By FYID Desc

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Select_All_TNC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Select_All_TNC]
	-- Add the parameters for the stored procedure here
	@i_TNC_SUB nvarchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TNC_DESC,TNCID FROM TermsNConditions WHERE TNC_SUB=@i_TNC_SUB
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TNC_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_TNC_List]
	-- Add the parameters for the stored procedure here
@i_UserID bigint

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

if @i_UserID = 1
begin

    -- Insert statements for procedure here
	SELECT  DISTINCT   TNC_Sub
FROM         TermsNConditions
GROUP BY TNC_Sub
END
else

SELECT  DISTINCT   TNC_Sub
FROM         TermsNConditions where CreatedBy = @i_UserID
GROUP BY TNC_Sub

end	



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TNC_LOV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Sp is used for bind Customer lov.
-- =============================================
CREATE PROCEDURE [dbo].[usp_TNC_LOV]
@i_TNC_Sub nvarchar(50)	 


AS
BEGIN
	SET NOCOUNT ON;
	 SELECT   
--TNCID,
TNC_Desc
FROM         TermsNConditions
WHERE  TNC_Sub=@i_TNC_Sub
	
 
END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_TNC_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_TNC_Select]
	-- Add the parameters for the stored procedure here
	@i_TNC_Sub  nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from TermsNConditions where TNC_Sub=@i_TNC_Sub 
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Indent_Rate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		PRIYANKA
-- Create date: 25/11/2014
-- Description:	SELECT LATEST RATE FROM PURCHASE
-- =============================================
CREATE PROCEDURE [dbo].[usp_Indent_Rate] 
	-- Add the parameters for the stored procedure here
	@i_ItemID bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select RATE 
from IndentDetail
WHERE PIID=(SELECT MAX(PIID) FROM IndentDetail WHERE ITEMID=@i_ItemID) and ITEMID=@i_ItemID
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SalesInvoice_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 25th Jan 2011
-- Description:	Insert record of Sales Invoice and Sales Invoice Detail
-- =============================================

--select * from Lead
--select * from Quotation
--select * from SalesInvoice
-- Lead.LeadNo AS Code,

CREATE PROCEDURE [dbo].[usp_SalesInvoice_Insert]
	@i_SalesCode Varchar(20),
	@i_FYID Bigint,
	@i_SalesDate DateTime,
	
	@i_DCDate DATETIME,
	@i_CustomerID Bigint,
	@i_DueDays Bigint,
	@i_TotalAmount Decimal(18,2),
	@i_ServiceAmount  Decimal(18,2),	
	@i_ExciseAmount  Decimal(18,2),	
	@i_CessAmount Decimal(18,2),
	@i_HCessAmount Decimal(18,2),
	@i_AmountAfterExcise Decimal(18,2),
	@i_CSTAmount Decimal(18,2),
	@i_VATAmount Decimal(18,2),
	@i_AVATAmount Decimal(18,2),
	@i_Discount  Decimal(18,2),
	@i_NetAmount  Decimal(18,2),
	@i_PaidAmount  Decimal(18,2),
	@i_Narration Varchar(250),
	@i_XMLString xml,
	@i_Cnt Bigint,
	@i_XMLString1 xml,
	@i_Cnt1 Bigint,
	@i_UserID BIGINT,
	@i_Installation datetime,
	@i_Reminder datetime,
	@i_NoofServices int,
	@i_ExtraCharges decimal(18,2),
	@i_ExtraChargesType nvarchar(255),
	@i_EmpID int,
	@i_TIN nvarchar(50),
	@i_RecDay int,
	@i_Type nvarchar(50),
	@i_ShippingAdd nvarchar(1000),
	@i_BONo nvarchar(250),
	@i_BODate datetime,
	@i_DNote nvarchar(250),
	@i_DNoteDate datetime,
	@i_SuRNo nvarchar(250),
	@i_DDNo nvarchar(250),
	@i_DT nvarchar(250),
	@i_D nvarchar(250),
	@i_DtI datetime,
	@i_TI nvarchar(50),
	@i_DtR datetime,
	@i_TR nvarchar(50),
	@i_CC varchar(MAX),
	@i_BCC varchar(MAX),
	@i_ExtraCharges2 decimal(18,2),
	@i_ExtraChargesType2 nvarchar(255),
	@i_ExtraCharges3 decimal(18,2),
	@i_ExtraChargesType3 nvarchar(255),
	@i_ExtraReminder nvarchar(500),
	@i_dtExtraReminder datetime,
	@i_CustInvoiceNo nvarchar(50),
	@i_EmpAllToID int,
	@i_IsPaid bit,
--	@i_GoDownID bigint,
	@i_TotalDiscAmt  Decimal(18,2),
	@i_CompId bigint,
	@o_ErrorMesg Varchar(200) OUTPUT

AS
BEGIN
 	SET NOCOUNT ON;

   -- Declare Local Variables...
	DECLARE @l_varRec Bigint;
 	DECLARE @l_CustomerAccID Bigint
	DECLARE @l_LedNarration varchar(50)
	DECLARE @l_StockID Bigint
	DECLARE @l_NewDetID Bigint
	DECLARE @l_NewID BIGINT
	DECLARE @l_Description varchar(100);
	-- Set Local Variable value..
	SET @l_varRec = 0;
	SET @l_Description  = ''''
	SET @l_CustomerAccID = 0
	SET @l_LedNarration =''''
	SET @l_StockID = 0
	SET @l_NewDetID = 0
	-- Variable for StockDetail
 
	SET @o_ErrorMesg='''';
	SET @l_NewID = 0

DECLARE	@l_Date Datetime;
--------------------------------

	DECLARE @i_FYID1 BIGINT;
	DECLARE @i_AccountID bigint;
	DECLARE @i_CustomerCode varchar(20);
	DECLARE @i_CustomerName Varchar(100);
	DECLARE @i_Address Varchar(150);
	DECLARE @i_CityID Bigint;
	DECLARE @i_AreaID int;
	DECLARE @i_Pincode varchar(20);
	DECLARE @i_Phone1 varchar(20);
	DECLARE @i_MobileNo varchar(20);
	DECLARE @i_Email varchar(150);
	DECLARE @i_Website nvarchar(50);
	DECLARE @i_ContactPerson nvarchar(250);
--	@i_EmpID int;
--	@i_AllocatedToEmpID int;
	DECLARE @i_Category varchar(50);
	DECLARE @i_IsAccount Bigint;
	DECLARE @i_Specification varchar(250);
	DECLARE @i_Remarks varchar(MAX);
	DECLARE @i_CreditDays int;
	DECLARE @i_Name1 nvarchar(50);
	DECLARE @i_Name2 nvarchar(50);
	DECLARE @i_Name3 nvarchar(50);
	DECLARE @i_Name4 nvarchar(50);
	DECLARE @i_Name5 nvarchar(50);
	DECLARE @i_Name6 nvarchar(50);
	DECLARE @i_Value1 nvarchar(50);
	DECLARE @i_Value2 nvarchar(50);
	DECLARE @i_Value3 nvarchar(50);
	DECLARE @i_Value4 nvarchar(50);
	DECLARE @i_Value5 nvarchar(50);
	DECLARE @i_Value6 nvarchar(50);
	DECLARE @i_CompId1 bigint;	
	DECLARE @i_TransactionDate Datetime;
	DECLARE @i_CRAmount Decimal(18,2);
	DECLARE @i_DBAmount Decimal(18,2);		
	DECLARE @i_UserID1 bigint;
--	@i_LeadId int,	
	DECLARE @o_ErrorMesg1 Varchar(200)

--------------------------------
 


--	BEGIN TRY  
--	BEGIN TRAN
-- 
-- 	SELECT @l_varRec = Count(SIID) From SalesInvoice Where SalesCode = @i_SalesCode
-- 		IF @l_varRec = 0
-- 			BEGIN

 				Set @l_LedNarration  = ''Sales Against '' + @i_SalesCode
SET @l_Date=Convert(Datetime,getDate(),5);
 	
 				--Insert Record into Sales invoice Table...
 				Insert Into SalesInvoice(  FYID,   SalesCode,   SalesDate,       DCDate,   CustomerID ,    DueDays,  
  TotalAmount,   ServiceAmount,    ExciseAmount ,   CessAmount,   HCessAmount,   AmountAfterExcise ,   CSTAmount,   VATAmount,   
AVATAmount  ,    Discount, NetAmount,    Narration,   PaidAmount, InstallationDate,ReminderDate,NoofServices,EmpID,ExtraCharges,ExtraChargesType,TIN,RecDay,Type,
ShippingAdd,BONo,BODate,DNote,DNoteDate,SuRNo,DDNo,DT,D,DtI,TI,DtR,TR,
CC,BCC,ExtraCharges2,ExtraChargesType2,ExtraCharges3,ExtraChargesType3,
ExtraReminder,dtExtraReminder,CustInvoiceNo,EmpAllToID,IsPaid,TotalDiscAmt,CompId,CreatedBy)
 				Values(@i_FYID,@i_SalesCode,@i_SalesDate,@i_DCDate,@i_CustomerID , @i_DueDays,
 @i_TotalAmount,@i_ServiceAmount ,@i_ExciseAmount ,@i_CessAmount,@i_HCessAmount,@i_AmountAfterExcise ,@i_CSTAmount,@i_VATAmount,
@i_AVATAmount  ,@i_Discount, @i_NetAmount, @i_Narration,@i_PaidAmount, @i_Installation,@i_Reminder,@i_NoofServices,@i_EmpID,
@i_ExtraCharges , @i_ExtraChargesType,@i_TIN,@i_RecDay,@i_Type,
@i_ShippingAdd,@i_BONo,@i_BODate,@i_DNote,@i_DNoteDate,@i_SuRNo,@i_DDNo,@i_DT,@i_D,@i_DtI,@i_TI,@i_DtR,@i_TR,
@i_CC,@i_BCC,@i_ExtraCharges2,@i_ExtraChargesType2,@i_ExtraCharges3,@i_ExtraChargesType3,
@i_ExtraReminder,@i_dtExtraReminder,@i_CustInvoiceNo,@i_EmpAllToID,@i_IsPaid,@i_TotalDiscAmt,@i_CompId,@i_UserID)

update Lead set InterestLevel=''SALE'' where LeadId=(select CustomerID from SalesInvoice where FYID=@i_FYID and SalesInvoice.SalesCode=@i_SalesCode and CompId=@i_CompId) 

--update Customer set IsAccount=1 where 
--select * from Customer
--select * from Lead
-------------------------------insert data in customer ---------------
declare @AccountID as int;

Declare @l_MaxNo bigint;
Declare @l_MaxNoCust bigint;
Declare @l_CustAccountID bigint;
DEclare @l_FinalCode varchar(20);

select @AccountID=AccountID from Lead where LeadId=@i_CustomerID
print @AccountID
if @AccountID=0
begin
--DECLARE @i_CustomerName Varchar(100);
SELECT @l_MaxNo  = isnull(Max(Convert(bigint,Right((CustomerCode),5))),0)
            from CustomerMain
--print @l_MaxNo
            set @l_MaxNo   = @l_MaxNo  + 1
--        print @l_MaxNo

            -- Genarete Code with MAX
                Select  @l_FinalCode  = ''CUST'' + ''-''  + REPLICATE(''0'',5 - LEN(CAST(@l_MaxNo AS varchar(5)))) + CAST( @l_MaxNo AS varchar(5))  
--print @l_FinalCode


		select 
	@i_FYID=1,
	@i_AccountID=0 ,
	@i_CustomerCode=@l_FinalCode,
	@i_CustomerName=CustomerName,
	@i_Address=Address,
	@i_CityID= CityID,
	@i_AreaID=AreaID ,
	@i_Pincode=Pincode ,
	@i_Phone1= Phone1,
	@i_MobileNo= MobileNo,
	@i_Email= Email,
	@i_Website=Website,
	@i_ContactPerson=ContactPerson ,
	@i_Category= Category,
	@i_IsAccount= 1,
	@i_Specification= Specification,
	@i_Remarks= Remarks,
	@i_CreditDays= 0,
	@i_Name1= Name1,
	@i_Name2= Name2,
	@i_Name3= Name3,
	@i_Name4= Name4,
	@i_Name5= Name5,
	@i_Name6= Name6,
	@i_Value1= Value1,
	@i_Value2= Value2,
	@i_Value3 =Value3,
	@i_Value4=Value4 ,
	@i_Value5= Value5,
	@i_Value6= Value6,
	@i_CompId= CompId,	
	@i_TransactionDate =getdate(),
	@i_CRAmount =0,
	@i_DBAmount= 0,		
	@i_UserID=CreatedBy
	
from Lead where Lead.LeadId=@i_CustomerID

--------------------------------------

	exec [usp_Customer_Insert] @i_FYID,
	@i_AccountID ,
	@i_CustomerCode,
	@i_CustomerName,
	@i_Address,
	@i_CityID ,
	@i_AreaID ,
	@i_Pincode ,
	@i_Phone1 ,
	@i_MobileNo ,
	@i_Email ,
	@i_Website,
	@i_ContactPerson ,
	@i_Category ,
	@i_IsAccount ,
	@i_Specification ,
	@i_Remarks ,
	@i_CreditDays ,
	@i_Name1 ,
	@i_Name2 ,
	@i_Name3 ,
	@i_Name4 ,
	@i_Name5 ,
	@i_Name6 ,
	@i_Value1 ,
	@i_Value2 ,
	@i_Value3 ,
	@i_Value4 ,
	@i_Value5 ,
	@i_Value6 ,
	@i_CompId ,	
	@i_TransactionDate ,
	@i_CRAmount ,
	@i_DBAmount ,		
	@i_UserID ,	
	@o_ErrorMesg

--end

SELECT @l_MaxNoCust  = isnull(Max(CustomerID),0)
            from CustomerMain
--print @l_MaxNoCust
	select @l_CustAccountID=AccountID from CustomerMain where CustomerID=@l_MaxNoCust
update Lead set AccountID=@l_CustAccountID where Lead.LeadId=@i_CustomerID
end
--            set @l_MaxNo   = @l_MaxNo  + 1

-----------------------------------------------------------------------
				SET @l_NewID = Scope_Identity();
				Set @o_ErrorMesg=convert(varchar, @l_NewID)
 				-- Customer''s Ledger Effect
				Set @l_CustomerAccID = 0
				Select @l_CustomerAccID = AccountID From Customer Where CustomerID = @i_CustomerID
				---Insert Record in Ledger
				If @l_CustomerAccID>0
				Begin
					Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
								Values(@l_CustomerAccID,@i_FYID, 3,				   @l_NewID, @i_SalesDate,0.00,@i_NetAmount,@l_LedNarration );

					Insert Into Ledger (AccountID, FYID, TransactionTypeID, TransactionID, TransactionDate,    CRAmount, DBAmount,Narration)
								Values(@l_CustomerAccID,@i_FYID, 3,				   @l_NewID, @i_SalesDate,@i_PaidAmount,0.00,@l_LedNarration );
				End
				-- Insert Record for Service Tax Amount
				If @i_ServiceAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(10,    @i_FYID,       3,				     @l_NewID,   @i_SalesDate,0.00,@i_ServiceAmount,@l_LedNarration);
				End


				-- Insert Record for Basic Excise Amount
				If @i_ExciseAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(2,    @i_FYID,       3,				     @l_NewID,   @i_SalesDate,0.00,@i_ExciseAmount,@l_LedNarration);
				End

				-- Insert Record for Basic Excise Amount
				If @i_ExciseAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(2,    @i_FYID,       3,				     @l_NewID,   @i_SalesDate,0.00,@i_ExciseAmount,@l_LedNarration);
				End
				-- Insert Record for Cess On Excise Amount
				If @i_CessAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(3,    @i_FYID,       3,				     @l_NewID,   @i_SalesDate,0.00,@i_CessAmount,@l_LedNarration);
				End
				-- Insert Record for H Cess On Excise Amount
				If @i_HCessAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(4,         @i_FYID,  3,				     @l_NewID,   @i_SalesDate,0.00,@i_HCessAmount,@l_LedNarration);
				End
				-- Insert Record for CST On Excise Amount
				If @i_CSTAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(5,       @i_FYID,    3,				     @l_NewID,   @i_SalesDate,0.00,@i_CSTAmount,@l_LedNarration);
				End
				-- Insert Record for VAT On Excise Amount
				If @i_VATAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(6,        @i_FYID,   3,				     @l_NewID,   @i_SalesDate,0.00,@i_VATAmount,@l_LedNarration);
				End
				-- Insert Record for AVAT On Excise Amount
				If @i_AVATAmount>0
				Begin
					---Insert Record in Ledger
					Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
								Values(7,       @i_FYID,    3,				     @l_NewID,   @i_SalesDate,0.00,@i_AVATAmount,@l_LedNarration);
				End


			---Insert Record in Ledger For Cash
				Insert Into Ledger (AccountID,FYID, TransactionTypeID, TransactionID, TransactionDate, CRAmount, DBAmount,Narration)
							Values(	1,		@i_FYID,	3,				     @l_NewID,   @i_SalesDate,@i_PaidAmount,0.00,@l_LedNarration);

 

				---Procedure For Insert Record into Sales Invoice Detail Table...
				IF @i_Cnt > 0
				BEGIN		
					SELECT  
						x.d.value(''GodownID[1]'',''int'') AS GodownID,
						x.d.value(''ItemID[1]'',''int'') AS ItemID,
						x.d.value(''ItemDesc[1]'',''varchar(max)'') AS ItemDesc,							
						x.d.value(''Qty[1]'',''Decimal(18,3)'') AS Qty,
						x.d.value(''Rate[1]'',''Decimal(18,2)'') AS Rate,
						x.d.value(''Amount[1]'',''Decimal(18,2)'') AS Amount,
						x.d.value(''TaxClassID[1]'',''Bigint'') AS TaxClassID,
						x.d.value(''ServiceRate[1]'',''Decimal(5,2)'') AS ServiceRate,						
						x.d.value(''ServiceAmount[1]'',''Decimal(18,2)'') AS ServiceAmount,
						x.d.value(''ExciseRate[1]'',''Decimal(5,2)'') AS ExciseRate,						
						x.d.value(''ExciseAmount[1]'',''Decimal(18,2)'') AS ExciseAmount,
						x.d.value(''EduCessRate[1]'',''Decimal(5,2)'') AS EduCessRate,						
						x.d.value(''EduCessAmount[1]'',''Decimal(18,2)'') AS EduCessAmount,
						x.d.value(''HEduCessRate[1]'',''Decimal(5,2)'') AS HEduCessRate,						
						x.d.value(''HEduCessAmount[1]'',''Decimal(18,2)'') AS HEduCessAmount,
						x.d.value(''AmountAfterExcise[1]'',''Decimal(18,2)'') AS AmountAfterExcise,						
						x.d.value(''CSTRate[1]'',''Decimal(5,2)'') AS CSTRate,
						x.d.value(''CSTAmount[1]'',''Decimal(18,2)'') AS CSTAmount,
						x.d.value(''VATRate[1]'',''Decimal(5,2)'') AS VATRate,	
						x.d.value(''VATAmount[1]'',''Decimal(18,2)'') AS VATAmount,
						x.d.value(''AVATRate[1]'',''Decimal(5,2)'') AS AVATRate,
						x.d.value(''AVATAmount[1]'',''Decimal(18,2)'') AS AVATAmount,
						x.d.value(''NetAmount[1]'',''Decimal(18,2)'') AS NetAmount,	
						x.d.value(''Discount[1]'',''Decimal(18,2)'') AS Discount
						
					INTO #tmpDetail				
					FROM 
						@i_XMLString.nodes(''/NewDataSet/Table'') x(d);

					INSERT INTO SalesInvoiceDetail (SIID,  GodownID , ItemID,   ItemDesc,     Qty,   Rate,  Amount,   TaxClassID,    ServiceRate,  ServiceAmount,   ExciseRate,   ExciseAmount,       CessRate,      CessAmount,     HCessRate,      HCessAmount,   AmountafterExcise,   CSTRate,   CSTAmount,   VATRate,   VATAmount,   AVATRate,   AVATAmount,   NetAmount,Discount)
											SELECT @l_NewID,T1.GodownID,T1.ItemID,T1.ItemDesc,T1.Qty,T1.Rate,T1.Amount,T1.TaxClassID,T1.ServiceRate,T1.ServiceAmount,T1.ExciseRate,T1.ExciseAmount,T1.EduCessRate,T1.EduCessAmount,T1.HEduCessRate,T1.HEduCessAmount,T1.AmountafterExcise,T1.CSTRate,T1.CSTAmount,T1.VATRate,T1.VATAmount,T1.AVATRate,T1.AVATAmount,T1.NetAmount,T1.Discount FROM #tmpDetail T1


								---Procedure For Insert Record into Sales Invoice Detail Table...
				IF @i_Cnt1 > 0
				BEGIN		
					SELECT  x1.d.value(''SR_Code[1]'',''varchar(50)'') AS SR_Code,
						x1.d.value(''SR_Date[1]'',''DateTime'') AS SR_Date,							
						x1.d.value(''SIID[1]'',''int'') AS SIID,
						x1.d.value(''SR_Done[1]'',''int'') AS SR_Done
					
												
					INTO #tmpDetail1			
					FROM 
						@i_XMLString1.nodes(''/NewDataSet/Table'') x1(d);

					INSERT INTO Sales_Service_Reminder (SR_Code,SR_Date,SIID,SR_Done)   
											SELECT T2.SR_Code,T2.SR_Date,@l_NewID,T2.SR_Done FROM #tmpDetail1 T2 		 

				
				
					SET @l_Description = ''Against Sales Invoice : '' + @i_SalesCode; 
				Insert Into ItemStock(FYID,      ItemID,    QOH, MinLevel, MaxLevel, ReorderLvl, CreatedBy, CreatedDate,GodownID )
 							Select @i_FYID,#tmpDetail.ItemID, 0, 0, 0, 0, @i_UserID, @i_SalesDate,#tmpDetail.GoDownID
							From #tmpDetail Where #tmpDetail.ItemID Not In(
								Select ItemStock.ItemID From ItemStock WHERE ItemStock.FYID = @i_FYID )
				
				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
					Select ItemStock.StockID, 100,ItemStock.StockID, @i_SalesDate, ''Opening Stock'',0.000
						From #tmpDetail 
							Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
							Where ItemStock.QOH = 0 And ItemStock.FYID = @i_FYID
								And ItemStock.StockID Not In (Select StockID from ItemStockDetail Where 
									ItemStockDetail.StockID = ItemStock.StockID And ItemStockDetail.GTID=100)

				-- Insert record in StockDistrictDetail
				Insert Into ItemStockDetail( StockID,  GTID,  RefID,  Date, Description ,  Qty)
						Select ItemStock.StockID, 300,@l_NewID, @i_SalesDate, @l_Description,((-1) * #tmpDetail.Qty)
							From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
							Where ItemStock.FYID = @i_FYID
		 				
				-- Update Stock
				Update ItemStock 
					Set ItemStock.QOH = ItemStock.QOH -
						(Select Sum(#tmpDetail.Qty) From #tmpDetail Where ItemStock.ItemID = #tmpDetail.ItemID )
				From #tmpDetail Inner Join ItemStock On #tmpDetail.ItemID=ItemStock.ItemID
				Where 
					ItemStock.FYID = @i_FYID
-- and ItemStock.GodownID=#tmpDetail.GoDownID
				 END
 				END
--			  END
		  ELSE
			  BEGIN
					SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 25001 );
			  END			
		
--	COMMIT TRAN
--	END TRY
--		BEGIN CATCH 
--			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 10000 );  
--		ROLLBACK TRAN  
--	END CATCH 	

END






































' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Customer_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Delete record from Customer 
-- =============================================
CREATE PROCEDURE [dbo].[usp_Customer_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
		
	Declare @l_varRec bigint;
	Declare @l_AccountID Bigint;
	Declare @l_Count Bigint;

	Set @l_AccountID = 0;
	Set @l_varRec = 0;
  
	Set @l_Count = 0;
	Select @l_AccountID = AccountID From CustomerMain Where CustomerID= @i_RecID;
	
	If @l_AccountID IS NULL Or @l_AccountID = 0
	BEGIN
		DELETE FROM AddressDetail WHERE AddressType = 1 AND RefID = @i_RecID;
		DELETE FROM ContactDetail WHERE ContactType = 1 AND RefID = @i_RecID;
		DELETE FROM CustomerMain WHERE CustomerID = @i_RecID ;	
		RETURN
	END
	

	Select @l_varRec = Count(AccountID) From OpeningBalance Where AccountID = @l_AccountID;
 
		If @l_varRec = 1
		Begin
			Select @l_varRec = Count(AccountID) From Ledger Where AccountID = @l_AccountID;
			If @l_varRec = 1
			Begin
				DELETE FROM Ledger WHERE AccountID = @l_AccountID;
				DELETE FROM OpeningBalance WHERE AccountID = @l_AccountID	
				Exec usp_Account_Delete @l_AccountID ,2, @o_ErrorMesg  Output
				If @o_ErrorMesg = ''''
				Begin
					DELETE FROM Ledger WHERE AccountID = @l_AccountID;
					DELETE FROM OpeningBalance WHERE AccountID = @l_AccountID										
					DELETE FROM AddressDetail WHERE AddressType = 1 AND RefID = @i_RecID;
					DELETE FROM ContactDetail WHERE ContactType = 1 AND RefID = @i_RecID;
					DELETE FROM CustomerMain WHERE CustomerID = @i_RecID ;	
					DELETE FROM Account WHERE AccountID=@l_AccountID;

				End	
			End
			Else
			Begin
				--Set @o_ErrorMesg=8003; -- Customer is associated with Ledger..
				SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 8003 );
			End			
		End
		Else
		Begin
			--Set @o_ErrorMesg=8004; -- Customer is associated with OpeningBalance..
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 8004 );
		End

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Vendor_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 21-1-2011
-- Description:	Delete record from Vendor 
-- =============================================
CREATE PROCEDURE [dbo].[usp_Vendor_Delete]
	@i_RecID Bigint,
	@o_ErrorMesg Varchar(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Set Local Variable
	SET @o_ErrorMesg='''';
		
	Declare @l_varRec bigint;
	Declare @l_AccountID Bigint;
	Declare @l_Count Bigint;

	Set @l_AccountID = 0;
	Set @l_varRec = 0;
  
	Set @l_Count = 0;
	Select @l_AccountID = AccountID From Vendor Where VendorID= @i_RecID;

	Select @l_varRec = Count(AccountID) From OpeningBalance Where AccountID = @l_AccountID;

		If @l_varRec = 1
		Begin
			Select @l_varRec = Count(AccountID) From Ledger Where AccountID = @l_AccountID;
			If @l_varRec = 1
			Begin
				DELETE FROM  Ledger WHERE AccountID = @l_AccountID;
				DELETE FROM OpeningBalance WHERE AccountID = @l_AccountID	
				Exec usp_Account_Delete @l_AccountID ,2, @o_ErrorMesg  Output
				If @o_ErrorMesg = ''''
				Begin
					DELETE FROM Ledger WHERE AccountID = @l_AccountID;
					DELETE FROM OpeningBalance WHERE AccountID = @l_AccountID										
					DELETE FROM AddressDetail WHERE AddressType = 0 AND RefID = @i_RecID;
					DELETE FROM ContactDetail WHERE ContactType = 0 AND RefID = @i_RecID;
					DELETE FROM Vendor WHERE VendorID = @i_RecID ;
					DELETE FROM Account WHERE AccountID=@l_AccountID;
				End	
			End
			Else
			Begin
				--Set @o_ErrorMesg=8003; -- Customer is associated with Ledger..
				SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 8003 );
			End			
		End
		Else
		Begin
			--Set @o_ErrorMesg=8004; -- Customer is associated with OpeningBalance..
			SET @o_ErrorMesg = (SELECT ErrorMsg FROM Gen_ErrorMsg WHERE ErrorNo = 8004 );
		End
	
			


END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_AccountLedger]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Manoj Savalia
-- Create date: 23rh Jan 2011
-- Description:	Get Account Ledger Report
-- =============================================
CREATE PROCEDURE [dbo].[rpt_AccountLedger] 
	@i_AccountID bigint,
    @i_FromDate datetime,
    @i_ToDate Datetime
AS
BEGIN
	DECLARE @i_AccountOpening decimal(18,2)
	DECLARE @i_AccountOpeningType varchar(2)

	DECLARE @i_OpeningBalance decimal(18,2)
	DECLARE @i_OpeningType varchar(2)

	DECLARE @i_ClosingBalance decimal(18,2)
	DECLARE @i_ClosingType varchar(2)

	DECLARE @i_FinalOpening decimal(18,2)	
	DECLARE @i_FinalOpeningType varchar(2)

	Declare @i_AccCode varchar(50);
	Declare @i_AccName Varchar(50);

	SET @i_AccountOpeningType = ''CR''
	SET @i_OpeningType = ''CR''
	SET @i_FinalOpeningType = ''CR'' 
	SET @i_ClosingType = ''CR''

	SET @i_AccountOpening = 0.00
	SET @i_OpeningBalance = 0.00
	SET @i_FinalOpening = 0.00
	SET @i_ClosingBalance = 0.00
	Set @i_AccName = '''';
	Set @i_AccCode = '''';
	
	SELECT 
		@i_AccCode = AccountCode,	
		@i_AccName= AccountName
	FROM	
		Account 
	Where AccountID = @i_AccountID;
		

	SELECT
			@i_AccountOpening =
			CASE 
				WHEN CRAmount = 0.00 AND DBAmount = 0.00 THEN 0 
				WHEN CRAmount = 0.00 AND DBAmount <> 0.00 THEN DBAmount 
				WHEN CRAmount <> 0.00 AND DBAmount = 0.00 THEN CRAmount 
			End,
			@i_AccountOpeningType =
			CASE 
				WHEN CRAmount = 0.00 AND DBAmount = 0.00 THEN ''CR'' 
				WHEN CRAmount = 0.00 AND DBAmount <> 0.00 THEN ''DB''
				WHEN CRAmount <> 0.00 AND DBAmount = 0.00 THEN ''CR'' 
			End
	FROM
		Ledger
	WHERE
		AccountID = @i_AccountID AND
		TransactionTypeID = 1

	SELECT  
			@i_OpeningBalance =
			CASE 
				WHEN IsNull(Sum(CRAmount),0) = IsNull(Sum(DBAmount),0) THEN 0.00 
				WHEN IsNull(Sum(CRAmount),0) < IsNull(Sum(DBAmount),0) THEN IsNull(Sum(DBAmount),0) - IsNull(Sum(CRAmount),0)
				WHEN IsNull(Sum(CRAmount),0) > IsNull(Sum(DBAmount),0) THEN IsNull(Sum(CRAmount),0) - IsNull(Sum(DBAmount),0)
			End,
			@i_OpeningType =
			CASE 
				WHEN IsNull(Sum(CRAmount),0) = IsNull(Sum(DBAmount),0) THEN ''CR'' 
				WHEN IsNull(Sum(CRAmount),0) < IsNull(Sum(DBAmount),0) THEN ''DB''
				WHEN IsNull(Sum(CRAmount),0) > IsNull(Sum(DBAmount),0) THEN ''CR''
			End
	FROM
		Ledger
	WHERE
		AccountID = @i_AccountID AND
		TransactionTypeID <> 1 AND
		TransactionDate < @i_FromDate 

	IF @i_AccountOpeningType = @i_OpeningType 
	BEGIN
		SET @i_FinalOpening = @i_OpeningBalance + @i_AccountOpening
		SET @i_FinalOpeningType = @i_OpeningType
	END

	IF @i_AccountOpeningType <> @i_OpeningType
	BEGIN
		IF @i_OpeningBalance = @i_AccountOpening
		BEGIN
			SET @i_FinalOpening = 0
			SET @i_FinalOpeningType = ''CR''
		END

		IF @i_OpeningBalance > @i_AccountOpening
		BEGIN
			SET @i_FinalOpening = @i_OpeningBalance - @i_AccountOpening
			SET @i_FinalOpeningType = @i_OpeningType
		END

		IF @i_OpeningBalance < @i_AccountOpening
		BEGIN
			SET @i_FinalOpening = @i_AccountOpening - @i_OpeningBalance 
			SET @i_FinalOpeningType = @i_AccountOpeningType
		END
	END

	

	-- Get Closing Balance
	SELECT		
			@i_ClosingBalance =
			CASE 
				WHEN Sum(CRAmount) = Sum(DBAmount) THEN 0.00
				WHEN Sum(CRAmount) < Sum(DBAmount) THEN Sum(DBAmount) - Sum(CRAmount)
				WHEN Sum(CRAmount) > Sum(DBAmount) THEN Sum(CRAmount) - Sum(DBAmount)
			End,
			@i_ClosingType =
			CASE 
				WHEN Sum(CRAmount) = Sum(DBAmount) THEN ''CR'' 
				WHEN Sum(CRAmount) < Sum(DBAmount) THEN ''DB''
				WHEN Sum(CRAmount) > Sum(DBAmount) THEN ''CR''
			End
	FROM
		Ledger
	WHERE
		AccountID = @i_AccountID AND
		TransactionDate < @i_ToDate



	SELECT
		@i_AccCode as AccCode,
		@i_AccName as AccName,
		@i_FromDate as TransactionDate,
		''Opening Balance'' AS TransactionType,
		''Opening Balance'' AS Narration,
		CASE 
			WHEN @i_FinalOpeningType = ''CR'' THEN @i_FinalOpening ELSE 0.00
		END CRAmount,
		CASE		
			WHEN @i_FinalOpeningType = ''DB'' THEN @i_FinalOpening ELSE 0.00
		END DBAmount,
		''N/A'' AS AccountName,
		0 AS LedgerID
	UNION
    SELECT
		@i_AccCode as AccCode,
		@i_AccName as AccName,
		FL.TransactionDate, 
		AccountTransaction.TransactionType, 
		FL.Narration,
		FL.CRAmount,
		FL.DBAmount,
		Case When FL.TransactionTypeID = 7 Then
			''Commission''
			When FL.TransactionTypeID = 4 Then
			''Expense''
		Else
			Case When FL.AccountID < 50	 Then
				@i_AccName
			Else
				dbo.fn_GetAccountList(FL.AccountID, FL.TransactionTypeID, FL.TransactionID) 
			End
		End as AccountName,
		FL.LedgerID
	FROM
        Ledger FL 
			INNER JOIN AccountTransaction ON FL.TransactionTypeID = AccountTransaction.TransactionTypeID
	WHERE
		AccountID = @i_AccountID AND
		FL.TransactionTypeID <> 1 AND
		FL.TransactionDate BETWEEN @i_FromDate AND @i_ToDate
UNION
	SELECT
		@i_AccCode as AccCode,
		@i_AccName as AccName,
		@i_ToDate AS TransactionDate,
		''Closing Balance'' AS TransactionType,
		''Closing Balance'' AS Narration,
		CASE 
			WHEN  @i_ClosingType = ''DB'' THEN @i_ClosingBalance ELSE 0.00
		END CRAmount,
		CASE		
			WHEN  @i_ClosingType = ''CR'' THEN @i_ClosingBalance ELSE 0.00
		END DBAmount,
		''N/A'' AS AccountName,
		9999999 as LedgerID
ORDER BY LedgerID,TransactionDate
END

' 
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ServiceDetails_Item]') AND parent_object_id = OBJECT_ID(N'[dbo].[ServiceDetails]'))
ALTER TABLE [dbo].[ServiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_ServiceDetails_Item] FOREIGN KEY([ServiceDetailID])
REFERENCES [dbo].[ServiceDetails] ([ServiceDetailID])
GO
ALTER TABLE [dbo].[ServiceDetails] CHECK CONSTRAINT [FK_ServiceDetails_Item]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ServiceDetails_ServiceModule]') AND parent_object_id = OBJECT_ID(N'[dbo].[ServiceDetails]'))
ALTER TABLE [dbo].[ServiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_ServiceDetails_ServiceModule] FOREIGN KEY([ServiceDetailID])
REFERENCES [dbo].[ServiceDetails] ([ServiceDetailID])
GO
ALTER TABLE [dbo].[ServiceDetails] CHECK CONSTRAINT [FK_ServiceDetails_ServiceModule]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ServiceDetails_TaxClass]') AND parent_object_id = OBJECT_ID(N'[dbo].[ServiceDetails]'))
ALTER TABLE [dbo].[ServiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_ServiceDetails_TaxClass] FOREIGN KEY([ServiceDetailID])
REFERENCES [dbo].[ServiceDetails] ([ServiceDetailID])
GO
ALTER TABLE [dbo].[ServiceDetails] CHECK CONSTRAINT [FK_ServiceDetails_TaxClass]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemStockDetail_GoodsTransaction]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemStockDetail]'))
ALTER TABLE [dbo].[ItemStockDetail]  WITH CHECK ADD  CONSTRAINT [FK_ItemStockDetail_GoodsTransaction] FOREIGN KEY([GTID])
REFERENCES [dbo].[GoodsTransaction] ([GTID])
GO
ALTER TABLE [dbo].[ItemStockDetail] CHECK CONSTRAINT [FK_ItemStockDetail_GoodsTransaction]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Item-Category_Item-Group]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemCategory]'))
ALTER TABLE [dbo].[ItemCategory]  WITH CHECK ADD  CONSTRAINT [FK_Item-Category_Item-Group] FOREIGN KEY([ItemGroupID])
REFERENCES [dbo].[ItemGroup] ([ItemGroupID])
GO
ALTER TABLE [dbo].[ItemCategory] CHECK CONSTRAINT [FK_Item-Category_Item-Group]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Vendor_City]') AND parent_object_id = OBJECT_ID(N'[dbo].[Vendor]'))
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[Gen_City] ([CityID])
GO
ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_City]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Area_City]') AND parent_object_id = OBJECT_ID(N'[dbo].[Gen_Area]'))
ALTER TABLE [dbo].[Gen_Area]  WITH CHECK ADD  CONSTRAINT [FK_Area_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[Gen_City] ([CityID])
GO
ALTER TABLE [dbo].[Gen_Area] CHECK CONSTRAINT [FK_Area_City]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_State_Country]') AND parent_object_id = OBJECT_ID(N'[dbo].[Gen_State]'))
ALTER TABLE [dbo].[Gen_State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Gen_Country] ([CountryID])
GO
ALTER TABLE [dbo].[Gen_State] CHECK CONSTRAINT [FK_State_Country]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_City_State]') AND parent_object_id = OBJECT_ID(N'[dbo].[Gen_City]'))
ALTER TABLE [dbo].[Gen_City]  WITH CHECK ADD  CONSTRAINT [FK_City_State] FOREIGN KEY([StateID])
REFERENCES [dbo].[Gen_State] ([StateID])
GO
ALTER TABLE [dbo].[Gen_City] CHECK CONSTRAINT [FK_City_State]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Gen_City_Gen_City]') AND parent_object_id = OBJECT_ID(N'[dbo].[Gen_City]'))
ALTER TABLE [dbo].[Gen_City]  WITH CHECK ADD  CONSTRAINT [FK_Gen_City_Gen_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[Gen_City] ([CityID])
GO
ALTER TABLE [dbo].[Gen_City] CHECK CONSTRAINT [FK_Gen_City_Gen_City]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PODetail_PO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PODetail]'))
ALTER TABLE [dbo].[PODetail]  WITH CHECK ADD  CONSTRAINT [FK_PODetail_PO] FOREIGN KEY([PIID])
REFERENCES [dbo].[PO] ([PIID])
GO
ALTER TABLE [dbo].[PODetail] CHECK CONSTRAINT [FK_PODetail_PO]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Lead_LeadStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[Lead]'))
ALTER TABLE [dbo].[Lead]  WITH CHECK ADD  CONSTRAINT [FK_Lead_LeadStatus] FOREIGN KEY([LeadStatusID])
REFERENCES [dbo].[LeadStatus] ([LeadStatusID])
GO
ALTER TABLE [dbo].[Lead] CHECK CONSTRAINT [FK_Lead_LeadStatus]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseInvoiceDetail_Item]') AND parent_object_id = OBJECT_ID(N'[dbo].[IndentDetail]'))
ALTER TABLE [dbo].[IndentDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoiceDetail_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ItemID])
GO
ALTER TABLE [dbo].[IndentDetail] CHECK CONSTRAINT [FK_PurchaseInvoiceDetail_Item]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseInvoiceDetail_PurchaseInvoice]') AND parent_object_id = OBJECT_ID(N'[dbo].[IndentDetail]'))
ALTER TABLE [dbo].[IndentDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoiceDetail_PurchaseInvoice] FOREIGN KEY([PIID])
REFERENCES [dbo].[Indent] ([PIID])
GO
ALTER TABLE [dbo].[IndentDetail] CHECK CONSTRAINT [FK_PurchaseInvoiceDetail_PurchaseInvoice]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseInvoiceDetail_TaxClass]') AND parent_object_id = OBJECT_ID(N'[dbo].[IndentDetail]'))
ALTER TABLE [dbo].[IndentDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoiceDetail_TaxClass] FOREIGN KEY([TaxClassID])
REFERENCES [dbo].[TaxClass] ([TaxClassID])
GO
ALTER TABLE [dbo].[IndentDetail] CHECK CONSTRAINT [FK_PurchaseInvoiceDetail_TaxClass]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesInvoiceDetail_Item]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesInvoiceDetail]'))
ALTER TABLE [dbo].[SalesInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_SalesInvoiceDetail_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ItemID])
GO
ALTER TABLE [dbo].[SalesInvoiceDetail] CHECK CONSTRAINT [FK_SalesInvoiceDetail_Item]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesInvoiceDetail_TaxClass]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesInvoiceDetail]'))
ALTER TABLE [dbo].[SalesInvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_SalesInvoiceDetail_TaxClass] FOREIGN KEY([TaxClassID])
REFERENCES [dbo].[TaxClass] ([TaxClassID])
GO
ALTER TABLE [dbo].[SalesInvoiceDetail] CHECK CONSTRAINT [FK_SalesInvoiceDetail_TaxClass]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReceiptDetail_Receipt]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReceiptDetail]'))
ALTER TABLE [dbo].[ReceiptDetail]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptDetail_Receipt] FOREIGN KEY([ReceiptID])
REFERENCES [dbo].[Receipt] ([ReceiptID])
GO
ALTER TABLE [dbo].[ReceiptDetail] CHECK CONSTRAINT [FK_ReceiptDetail_Receipt]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PaymentDetail_Payment]') AND parent_object_id = OBJECT_ID(N'[dbo].[PaymentDetail]'))
ALTER TABLE [dbo].[PaymentDetail]  WITH CHECK ADD  CONSTRAINT [FK_PaymentDetail_Payment] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payment] ([PaymentID])
GO
ALTER TABLE [dbo].[PaymentDetail] CHECK CONSTRAINT [FK_PaymentDetail_Payment]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PaymentDetail_PurchaseInvoice]') AND parent_object_id = OBJECT_ID(N'[dbo].[PaymentDetail]'))
ALTER TABLE [dbo].[PaymentDetail]  WITH CHECK ADD  CONSTRAINT [FK_PaymentDetail_PurchaseInvoice] FOREIGN KEY([PIID])
REFERENCES [dbo].[Indent] ([PIID])
GO
ALTER TABLE [dbo].[PaymentDetail] CHECK CONSTRAINT [FK_PaymentDetail_PurchaseInvoice]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ServiceModule_Employee]') AND parent_object_id = OBJECT_ID(N'[dbo].[ServiceModule]'))
ALTER TABLE [dbo].[ServiceModule]  WITH CHECK ADD  CONSTRAINT [FK_ServiceModule_Employee] FOREIGN KEY([AttendedBy])
REFERENCES [dbo].[Employee] ([EmpID])
GO
ALTER TABLE [dbo].[ServiceModule] CHECK CONSTRAINT [FK_ServiceModule_Employee]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Ledger_Account]') AND parent_object_id = OBJECT_ID(N'[dbo].[Ledger]'))
ALTER TABLE [dbo].[Ledger]  WITH CHECK ADD  CONSTRAINT [FK_Ledger_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Ledger] CHECK CONSTRAINT [FK_Ledger_Account]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Ledger_AccountTransaction]') AND parent_object_id = OBJECT_ID(N'[dbo].[Ledger]'))
ALTER TABLE [dbo].[Ledger]  WITH CHECK ADD  CONSTRAINT [FK_Ledger_AccountTransaction] FOREIGN KEY([TransactionTypeID])
REFERENCES [dbo].[AccountTransaction] ([TransactionTypeID])
GO
ALTER TABLE [dbo].[Ledger] CHECK CONSTRAINT [FK_Ledger_AccountTransaction]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Ledger_FinancialYear]') AND parent_object_id = OBJECT_ID(N'[dbo].[Ledger]'))
ALTER TABLE [dbo].[Ledger]  WITH CHECK ADD  CONSTRAINT [FK_Ledger_FinancialYear] FOREIGN KEY([FYID])
REFERENCES [dbo].[FinancialYear] ([FYID])
GO
ALTER TABLE [dbo].[Ledger] CHECK CONSTRAINT [FK_Ledger_FinancialYear]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OpeningBalance_Account]') AND parent_object_id = OBJECT_ID(N'[dbo].[OpeningBalance]'))
ALTER TABLE [dbo].[OpeningBalance]  WITH CHECK ADD  CONSTRAINT [FK_OpeningBalance_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[OpeningBalance] CHECK CONSTRAINT [FK_OpeningBalance_Account]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OpeningBalance_FinancialYear]') AND parent_object_id = OBJECT_ID(N'[dbo].[OpeningBalance]'))
ALTER TABLE [dbo].[OpeningBalance]  WITH CHECK ADD  CONSTRAINT [FK_OpeningBalance_FinancialYear] FOREIGN KEY([FYID])
REFERENCES [dbo].[FinancialYear] ([FYID])
GO
ALTER TABLE [dbo].[OpeningBalance] CHECK CONSTRAINT [FK_OpeningBalance_FinancialYear]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Payment_Vendor]') AND parent_object_id = OBJECT_ID(N'[dbo].[Payment]'))
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([VendorID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Vendor]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseInvoice_FinancialYear]') AND parent_object_id = OBJECT_ID(N'[dbo].[Indent]'))
ALTER TABLE [dbo].[Indent]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoice_FinancialYear] FOREIGN KEY([FYID])
REFERENCES [dbo].[FinancialYear] ([FYID])
GO
ALTER TABLE [dbo].[Indent] CHECK CONSTRAINT [FK_PurchaseInvoice_FinancialYear]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseInvoice_Vendor]') AND parent_object_id = OBJECT_ID(N'[dbo].[Indent]'))
ALTER TABLE [dbo].[Indent]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoice_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([VendorID])
GO
ALTER TABLE [dbo].[Indent] CHECK CONSTRAINT [FK_PurchaseInvoice_Vendor]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Account_AccountType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Account]'))
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_AccountType] FOREIGN KEY([AccTypeID])
REFERENCES [dbo].[AccountType] ([AccTypeID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_AccountType]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemAdjustment_FinancialYear]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemAdjustment]'))
ALTER TABLE [dbo].[ItemAdjustment]  WITH CHECK ADD  CONSTRAINT [FK_ItemAdjustment_FinancialYear] FOREIGN KEY([FYID])
REFERENCES [dbo].[FinancialYear] ([FYID])
GO
ALTER TABLE [dbo].[ItemAdjustment] CHECK CONSTRAINT [FK_ItemAdjustment_FinancialYear]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemAdjustment_Item]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemAdjustment]'))
ALTER TABLE [dbo].[ItemAdjustment]  WITH CHECK ADD  CONSTRAINT [FK_ItemAdjustment_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ItemID])
GO
ALTER TABLE [dbo].[ItemAdjustment] CHECK CONSTRAINT [FK_ItemAdjustment_Item]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemDetail_Item]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemDetail]'))
ALTER TABLE [dbo].[ItemDetail]  WITH CHECK ADD  CONSTRAINT [FK_ItemDetail_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ItemID])
GO
ALTER TABLE [dbo].[ItemDetail] CHECK CONSTRAINT [FK_ItemDetail_Item]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemStock_FinancialYear]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemStock]'))
ALTER TABLE [dbo].[ItemStock]  WITH CHECK ADD  CONSTRAINT [FK_ItemStock_FinancialYear] FOREIGN KEY([FYID])
REFERENCES [dbo].[FinancialYear] ([FYID])
GO
ALTER TABLE [dbo].[ItemStock] CHECK CONSTRAINT [FK_ItemStock_FinancialYear]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Expense_FinancialYear]') AND parent_object_id = OBJECT_ID(N'[dbo].[Expense]'))
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_FinancialYear] FOREIGN KEY([FYID])
REFERENCES [dbo].[FinancialYear] ([FYID])
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_FinancialYear]
