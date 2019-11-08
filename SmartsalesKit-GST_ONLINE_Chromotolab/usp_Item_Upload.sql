USE [SSKONLINEDEMO3]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_Upload]    Script Date: 22/01/2018 16:52:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_Item_Upload] 
	-- Add the parameters for the stored procedure her
	@i_XMLString xml,
    @i_Cnt int,
	@i_CompId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(@i_Cnt > 0)
	BEGIN
		SELECT
		      x.d.value('Item[1]','varchar(MAX)') AS Item,
			  x.d.value('Price[1]','float') AS Price,
			  x.d.value('UOM[1]','nvarchar(255)') AS UOM,
		      x.d.value('Currency[1]','nvarchar(255)') AS Currency,	
			  x.d.value('ProductCode[1]','nvarchar(150)') AS ProductCode,
			  x.d.value('HSNCode[1]','nvarchar(150)') AS HSNCode, 
			  x.d.value('Godown[1]','nvarchar(255)') AS Godown,
			  x.d.value('OpeningStock[1]', 'nvarchar(255)') AS OpeningStock,
			  x.d.value('ReorderLevel[1]', 'nvarchar(255)') AS ReorderLevel,
			  x.d.value('Location[1]', 'nvarchar(255)') AS Location,
			  x.d.value('RackNo[1]', 'nvarchar(255)') AS RackNo,
			  x.d.value('Description[1]','nvarchar(255)') AS Description
			  
	  INTO #TmpItem FROM @i_XMLString.nodes('/NewDataSet/Table') x (d)
	END
	  INSERT INTO TEMP_ITEM(ITEM,PRICE,UOM,CURRENCY,PRODUCT_CODE,HSN_CODE,GODOWN,OPENING_STOCK,REORDER_LEVEL,LOCATION,RACKNO,DESCRIPTION)
	  SELECT T1.Item,T1.Price,T1.UOM,T1.Currency,T1.ProductCode,T1.HSNCode,T1.Godown,T1.OpeningStock,T1.ReorderLevel,T1.Location,T1.RackNo,T1.Description FROM #TmpItem T1
	 DELETE  #TmpItem
END

