USE [SSKONLINECHROMOTO_2019]
GO
ALTER TABLE [dbo].[Vendor] DROP CONSTRAINT [FK_Vendor_Gen_City]
GO
ALTER TABLE [dbo].[ServiceModule] DROP CONSTRAINT [FK_ServiceModule_Employee]
GO
ALTER TABLE [dbo].[ServiceDetails] DROP CONSTRAINT [FK_ServiceDetails_TaxClass]
GO
ALTER TABLE [dbo].[ServiceDetails] DROP CONSTRAINT [FK_ServiceDetails_ServiceModule]
GO
ALTER TABLE [dbo].[ServiceDetails] DROP CONSTRAINT [FK_ServiceDetails_Item]
GO
ALTER TABLE [dbo].[SalesInvoiceDetail] DROP CONSTRAINT [FK_SalesInvoiceDetail_TaxClass]
GO
ALTER TABLE [dbo].[SalesInvoiceDetail] DROP CONSTRAINT [FK_SalesInvoiceDetail_Item]
GO
ALTER TABLE [dbo].[ReceiptDetail] DROP CONSTRAINT [FK_ReceiptDetail_Receipt]
GO
ALTER TABLE [dbo].[PODetail] DROP CONSTRAINT [FK_PODetail_PO]
GO
ALTER TABLE [dbo].[PaymentDetail] DROP CONSTRAINT [FK_PaymentDetail_PurchaseInvoice]
GO
ALTER TABLE [dbo].[PaymentDetail] DROP CONSTRAINT [FK_PaymentDetail_Payment]
GO
ALTER TABLE [dbo].[Payment] DROP CONSTRAINT [FK_Payment_Vendor]
GO
ALTER TABLE [dbo].[OpeningBalance] DROP CONSTRAINT [FK_OpeningBalance_FinancialYear]
GO
ALTER TABLE [dbo].[OpeningBalance] DROP CONSTRAINT [FK_OpeningBalance_Account]
GO
ALTER TABLE [dbo].[Ledger] DROP CONSTRAINT [FK_Ledger_FinancialYear]
GO
ALTER TABLE [dbo].[Ledger] DROP CONSTRAINT [FK_Ledger_Account]
GO
ALTER TABLE [dbo].[Lead] DROP CONSTRAINT [FK_Lead_LeadStatus]
GO
ALTER TABLE [dbo].[ItemStockDetail] DROP CONSTRAINT [FK_ItemStockDetail_GoodsTransaction]
GO
ALTER TABLE [dbo].[ItemStock] DROP CONSTRAINT [FK_ItemStock_FinancialYear]
GO
ALTER TABLE [dbo].[ItemDetail] DROP CONSTRAINT [FK_ItemDetail_Item]
GO
ALTER TABLE [dbo].[ItemCategory] DROP CONSTRAINT [FK_Item-Category_Item-Group]
GO
ALTER TABLE [dbo].[ItemAdjustment] DROP CONSTRAINT [FK_ItemAdjustment_Item]
GO
ALTER TABLE [dbo].[ItemAdjustment] DROP CONSTRAINT [FK_ItemAdjustment_FinancialYear]
GO
ALTER TABLE [dbo].[IndentDetail] DROP CONSTRAINT [FK_PurchaseInvoiceDetail_TaxClass]
GO
ALTER TABLE [dbo].[IndentDetail] DROP CONSTRAINT [FK_PurchaseInvoiceDetail_Item]
GO
ALTER TABLE [dbo].[Indent] DROP CONSTRAINT [FK_PurchaseInvoice_Vendor]
GO
ALTER TABLE [dbo].[Indent] DROP CONSTRAINT [FK_PurchaseInvoice_FinancialYear]
GO
ALTER TABLE [dbo].[Gen_State] DROP CONSTRAINT [FK_State_Country]
GO
ALTER TABLE [dbo].[Gen_City] DROP CONSTRAINT [FK_Gen_City_Gen_City]
GO
ALTER TABLE [dbo].[Gen_City] DROP CONSTRAINT [FK_City_State]
GO
ALTER TABLE [dbo].[Gen_Area] DROP CONSTRAINT [FK_Area_City]
GO
ALTER TABLE [dbo].[Expense] DROP CONSTRAINT [FK_Expense_FinancialYear]
GO
ALTER TABLE [dbo].[Bank] DROP CONSTRAINT [FK_Bank_Account]
GO
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK_Account_AccountType]
GO
/****** Object:  Table [dbo].[VersionInfo]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[VersionInfo]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Vendor]
GO
/****** Object:  Table [dbo].[TypeOfCall]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[TypeOfCall]
GO
/****** Object:  Table [dbo].[test_BAK]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[test_BAK]
GO
/****** Object:  Table [dbo].[test]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[test]
GO
/****** Object:  Table [dbo].[TermsNConditions]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[TermsNConditions]
GO
/****** Object:  Table [dbo].[Temp_Vendor]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Temp_Vendor]
GO
/****** Object:  Table [dbo].[Temp_Lead]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Temp_Lead]
GO
/****** Object:  Table [dbo].[Temp_Item]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Temp_Item]
GO
/****** Object:  Table [dbo].[Temp_Customer]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Temp_Customer]
GO
/****** Object:  Table [dbo].[TaxClass]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[TaxClass]
GO
/****** Object:  Table [dbo].[SysSettings]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[SysSettings]
GO
/****** Object:  Table [dbo].[Services_TNC]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Services_TNC]
GO
/****** Object:  Table [dbo].[ServiceModule]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ServiceModule]
GO
/****** Object:  Table [dbo].[ServiceDocList]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ServiceDocList]
GO
/****** Object:  Table [dbo].[ServiceDetails]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ServiceDetails]
GO
/****** Object:  Table [dbo].[Service_Contact]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Service_Contact]
GO
/****** Object:  Table [dbo].[SalesInvoiceDetail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[SalesInvoiceDetail]
GO
/****** Object:  Table [dbo].[SalesInvoice]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[SalesInvoice]
GO
/****** Object:  Table [dbo].[Sales_TNC]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Sales_TNC]
GO
/****** Object:  Table [dbo].[Sales_Service_Reminder]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Sales_Service_Reminder]
GO
/****** Object:  Table [dbo].[SaleDocList]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[SaleDocList]
GO
/****** Object:  Table [dbo].[Sale_Contact]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Sale_Contact]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Registration]
GO
/****** Object:  Table [dbo].[ReceiptReturnDetail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ReceiptReturnDetail]
GO
/****** Object:  Table [dbo].[ReceiptReturn]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ReceiptReturn]
GO
/****** Object:  Table [dbo].[ReceiptDetail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ReceiptDetail]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Receipt]
GO
/****** Object:  Table [dbo].[QuotationPaymentDetail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[QuotationPaymentDetail]
GO
/****** Object:  Table [dbo].[QuotationFollowup]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[QuotationFollowup]
GO
/****** Object:  Table [dbo].[QuotationDocList]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[QuotationDocList]
GO
/****** Object:  Table [dbo].[QuotationDetail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[QuotationDetail]
GO
/****** Object:  Table [dbo].[Quotation_TNC]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Quotation_TNC]
GO
/****** Object:  Table [dbo].[Quotation_Revised_TNC]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Quotation_Revised_TNC]
GO
/****** Object:  Table [dbo].[Quotation_Contact]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Quotation_Contact]
GO
/****** Object:  Table [dbo].[Quotation]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Quotation]
GO
/****** Object:  Table [dbo].[PurchaseIndentReq]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[PurchaseIndentReq]
GO
/****** Object:  Table [dbo].[PurchaseindentDocList]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[PurchaseindentDocList]
GO
/****** Object:  Table [dbo].[Purchase_TNC]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Purchase_TNC]
GO
/****** Object:  Table [dbo].[PromoMailDocList]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[PromoMailDocList]
GO
/****** Object:  Table [dbo].[PromoMail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[PromoMail]
GO
/****** Object:  Table [dbo].[PODocList]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[PODocList]
GO
/****** Object:  Table [dbo].[PODetail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[PODetail]
GO
/****** Object:  Table [dbo].[PO]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[PO]
GO
/****** Object:  Table [dbo].[PaymentReturnDetail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[PaymentReturnDetail]
GO
/****** Object:  Table [dbo].[PaymentReturn]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[PaymentReturn]
GO
/****** Object:  Table [dbo].[PaymentDetail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[PaymentDetail]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Payment]
GO
/****** Object:  Table [dbo].[OpeningBalance]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[OpeningBalance]
GO
/****** Object:  Table [dbo].[MaterialReturn]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[MaterialReturn]
GO
/****** Object:  Table [dbo].[MaterialIssue]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[MaterialIssue]
GO
/****** Object:  Table [dbo].[Ledger]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Ledger]
GO
/****** Object:  Table [dbo].[LeadStatus]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[LeadStatus]
GO
/****** Object:  Table [dbo].[LeadFollowUp]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[LeadFollowUp]
GO
/****** Object:  Table [dbo].[LeadDocList]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[LeadDocList]
GO
/****** Object:  Table [dbo].[Lead]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Lead]
GO
/****** Object:  Table [dbo].[ItemStockDetail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ItemStockDetail]
GO
/****** Object:  Table [dbo].[ItemStock]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ItemStock]
GO
/****** Object:  Table [dbo].[ItemGroup]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ItemGroup]
GO
/****** Object:  Table [dbo].[ItemDetail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ItemDetail]
GO
/****** Object:  Table [dbo].[ItemClass]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ItemClass]
GO
/****** Object:  Table [dbo].[ItemCategory]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ItemCategory]
GO
/****** Object:  Table [dbo].[ItemAdjustment]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ItemAdjustment]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Item]
GO
/****** Object:  Table [dbo].[IndentDetail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[IndentDetail]
GO
/****** Object:  Table [dbo].[Indent]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Indent]
GO
/****** Object:  Table [dbo].[GoodsTransaction]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[GoodsTransaction]
GO
/****** Object:  Table [dbo].[Godown]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Godown]
GO
/****** Object:  Table [dbo].[Gen_UserScope]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Gen_UserScope]
GO
/****** Object:  Table [dbo].[Gen_User]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Gen_User]
GO
/****** Object:  Table [dbo].[Gen_UOM]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Gen_UOM]
GO
/****** Object:  Table [dbo].[Gen_State]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Gen_State]
GO
/****** Object:  Table [dbo].[Gen_Privilege]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Gen_Privilege]
GO
/****** Object:  Table [dbo].[Gen_ErrorMsg]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Gen_ErrorMsg]
GO
/****** Object:  Table [dbo].[Gen_Country]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Gen_Country]
GO
/****** Object:  Table [dbo].[Gen_City]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Gen_City]
GO
/****** Object:  Table [dbo].[Gen_Area]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Gen_Area]
GO
/****** Object:  Table [dbo].[FinancialYear]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[FinancialYear]
GO
/****** Object:  Table [dbo].[Expense]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Expense]
GO
/****** Object:  Table [dbo].[ExceptionLog]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ExceptionLog]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Employee]
GO
/****** Object:  Table [dbo].[Email]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Email]
GO
/****** Object:  Table [dbo].[demotry]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[demotry]
GO
/****** Object:  Table [dbo].[DebitNoteDetails]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[DebitNoteDetails]
GO
/****** Object:  Table [dbo].[DebitNote]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[DebitNote]
GO
/****** Object:  Table [dbo].[DBTrans]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[DBTrans]
GO
/****** Object:  Table [dbo].[CustomerMain]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[CustomerMain]
GO
/****** Object:  Table [dbo].[CustomerFollowUp]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[CustomerFollowUp]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Customer]
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Currency]
GO
/****** Object:  Table [dbo].[CreditNoteDetails]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[CreditNoteDetails]
GO
/****** Object:  Table [dbo].[CreditNote]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[CreditNote]
GO
/****** Object:  Table [dbo].[ContactDetail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[ContactDetail]
GO
/****** Object:  Table [dbo].[CompanyInfo]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[CompanyInfo]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Bank]
GO
/****** Object:  Table [dbo].[AddressDetail]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[AddressDetail]
GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[AccountType]
GO
/****** Object:  Table [dbo].[AccountTransaction]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[AccountTransaction]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 08/11/2019 5:09:21 PM ******/
DROP TABLE [dbo].[Account]
GO
