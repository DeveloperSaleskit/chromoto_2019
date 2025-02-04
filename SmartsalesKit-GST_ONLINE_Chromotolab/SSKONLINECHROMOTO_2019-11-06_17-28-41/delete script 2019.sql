USE [SSKONLINECHROMOTO_2019]
GO
/****** Object:  StoredProcedure [dbo].[usp_VendorPaymentReturn_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_VendorPaymentReturn_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_VendorPaymentReturn_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_VendorPaymentReturn_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_VendorPaymentReturn_PendingSI_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_VendorPaymentReturn_PendingSI_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_VendorPaymentReturn_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_VendorPaymentReturn_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_VendorPaymentReturn_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_VendorPaymentReturn_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_VendorPaymentReturn_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_VendorPaymentReturn_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_VendorPayment_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_VendorPayment_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_VendorPayment_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_VendorPayment_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_VendorPayment_PendingPI_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_VendorPayment_PendingPI_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_VendorPayment_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_VendorPayment_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_VendorPayment_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_VendorPayment_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_VendorPayment_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_VendorPayment_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Vendor_Upload]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Vendor_Upload]
GO
/****** Object:  StoredProcedure [dbo].[usp_Vendor_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Vendor_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Vendor_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Vendor_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Vendor_PendingPaymentList]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Vendor_PendingPaymentList]
GO
/****** Object:  StoredProcedure [dbo].[usp_Vendor_PaymentPendingList]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Vendor_PaymentPendingList]
GO
/****** Object:  StoredProcedure [dbo].[usp_Vendor_LOV_PaymentReturn]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Vendor_LOV_PaymentReturn]
GO
/****** Object:  StoredProcedure [dbo].[usp_Vendor_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Vendor_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Vendor_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Vendor_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Vendor_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Vendor_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Vendor_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Vendor_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Vendor_category]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Vendor_category]
GO
/****** Object:  StoredProcedure [dbo].[usp_usp_PurchaseIndent_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_usp_PurchaseIndent_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_UserList_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_UserList_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_User_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_User_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_MailDetails]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_User_MailDetails]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_User_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_User_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_User_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_ActiveDeactive]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_User_ActiveDeactive]
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_Reminder_Flag]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Update_Reminder_Flag]
GO
/****** Object:  StoredProcedure [dbo].[usp_UOM_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_UOM_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_UOM_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_UOM_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_UOM_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_UOM_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_UOM_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_UOM_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_UOM_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_UOM_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_UOM_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_UOM_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_TypeOfCall_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TypeOfCall_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_TypeOfCall_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TypeOfCall_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_TypeOfCall_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TypeOfCall_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_TypeOfCall_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TypeOfCall_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_TypeOfCall_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TypeOfCall_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_TodaysLead]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TodaysLead]
GO
/****** Object:  StoredProcedure [dbo].[usp_TNCSub_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TNCSub_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_TNC_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TNC_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_TNC_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TNC_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_TNC_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TNC_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_TNC_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TNC_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_TNC_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TNC_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_TNC_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TNC_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_TaxClass_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TaxClass_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_TaxClass_Terminate]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TaxClass_Terminate]
GO
/****** Object:  StoredProcedure [dbo].[usp_TaxClass_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TaxClass_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_TaxClass_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TaxClass_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_TaxClass_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TaxClass_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_TaxClass_GetRate]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TaxClass_GetRate]
GO
/****** Object:  StoredProcedure [dbo].[usp_TaxClass_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TaxClass_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_TaxClass_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_TaxClass_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_State_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_State_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_State_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_State_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_State_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_State_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_State_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_State_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_State_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_State_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_State_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_State_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_SourceOfLead_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SourceOfLead_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_SignIn]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SignIn]
GO
/****** Object:  StoredProcedure [dbo].[usp_ServicesTNC_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ServicesTNC_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ServicesTNC_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ServicesTNC_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_ServicesTNC_Delete_On_Close]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ServicesTNC_Delete_On_Close]
GO
/****** Object:  StoredProcedure [dbo].[usp_ServicesTNC_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ServicesTNC_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_ServiceModule_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ServiceModule_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_ServiceModule_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ServiceModule_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ServiceModule_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ServiceModule_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_ServiceModule_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ServiceModule_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_ServiceModule_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ServiceModule_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_ServiceDocList_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ServiceDocList_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_ServiceDocList_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ServiceDocList_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_ServiceContact_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ServiceContact_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ServiceContact_Delete_On_Close]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ServiceContact_Delete_On_Close]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_UOMID]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Select_UOMID]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_Max_Code_Vendor]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Select_Max_Code_Vendor]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_Max_Code_Lead]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Select_Max_Code_Lead]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_Max_Code_Item]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Select_Max_Code_Item]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_Max_Code]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Select_Max_Code]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_GodownID]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Select_GodownID]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_CurrencyID]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Select_CurrencyID]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_ClassID]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Select_ClassID]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_CityID]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Select_CityID]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_CatID]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Select_CatID]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_All_TNC]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Select_All_TNC]
GO
/****** Object:  StoredProcedure [dbo].[usp_SEContactDetail_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SEContactDetail_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_SEContactDetail_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SEContactDetail_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_SContactDetail_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SContactDetail_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_SContactDetail_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SContactDetail_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_SalesTNC_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SalesTNC_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_SalesTNC_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SalesTNC_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_SalesTNC_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SalesTNC_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_SalesTNC_Delete_On_Close]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SalesTNC_Delete_On_Close]
GO
/****** Object:  StoredProcedure [dbo].[usp_SalesTNC_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SalesTNC_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_SalesInvoice_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SalesInvoice_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_SalesInvoice_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SalesInvoice_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_SalesInvoice_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SalesInvoice_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_SalesInvoice_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SalesInvoice_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_SalesInvoice_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SalesInvoice_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_SaleInvoice_CNOutstanding]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SaleInvoice_CNOutstanding]
GO
/****** Object:  StoredProcedure [dbo].[usp_SaleDocList_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SaleDocList_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_SaleDocList_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SaleDocList_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_SaleContact_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SaleContact_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_SaleContact_Delete_On_Close]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_SaleContact_Delete_On_Close]
GO
/****** Object:  StoredProcedure [dbo].[usp_Sale_Quotation]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Sale_Quotation]
GO
/****** Object:  StoredProcedure [dbo].[usp_Sale_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Sale_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Revised_old]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Revised_old]
GO
/****** Object:  StoredProcedure [dbo].[usp_Revised]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Revised]
GO
/****** Object:  StoredProcedure [dbo].[usp_Restore]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Restore]
GO
/****** Object:  StoredProcedure [dbo].[usp_Reminder_Service_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Reminder_Service_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Reminder_List_old1]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Reminder_List_old1]
GO
/****** Object:  StoredProcedure [dbo].[usp_Reminder_List_Old]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Reminder_List_Old]
GO
/****** Object:  StoredProcedure [dbo].[usp_Reminder_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Reminder_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Reminder_For_Service]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Reminder_For_Service]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationTNC_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationTNC_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationTNC_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationTNC_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationTNC_Revised_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationTNC_Revised_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationTNC_Revised_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationTNC_Revised_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationTNC_Revised_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationTNC_Revised_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationTNC_Revised_Delete_On_Close]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationTNC_Revised_Delete_On_Close]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationTNC_Revised_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationTNC_Revised_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationTNC_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationTNC_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationTNC_Delete_On_Close]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationTNC_Delete_On_Close]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationTNC_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationTNC_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationQContact_Delete_On_Close]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationQContact_Delete_On_Close]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationPaymentDetail_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationPaymentDetail_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationFollowUp_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationFollowUp_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationFollowup_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationFollowup_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationDocList_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationDocList_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuotationContact_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QuotationContact_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Quotation_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Quotation_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Quotation_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Quotation_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Quotation_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Quotation_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Quotation_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Quotation_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Quotation_Id]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Quotation_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Quotation_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Quotation_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Quotation_All_TNC_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Quotation_All_TNC_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Quotation_All_TNC_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Quotation_All_TNC_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_QContactDetail_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QContactDetail_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_QContactDetail_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_QContactDetail_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_PurchseIndentDocfinal]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PurchseIndentDocfinal]
GO
/****** Object:  StoredProcedure [dbo].[usp_PurchaseTNC_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PurchaseTNC_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_PurchaseTNC_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PurchaseTNC_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_PurchaseTNC_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PurchaseTNC_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_PurchaseTNC_Delete_On_Close]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PurchaseTNC_Delete_On_Close]
GO
/****** Object:  StoredProcedure [dbo].[usp_PurchaseTNC_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PurchaseTNC_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_PurchaseInvoice_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PurchaseInvoice_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_PurchaseindentDocList_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PurchaseindentDocList_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_PurchaseIndent_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PurchaseIndent_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_PurchaseIndent_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PurchaseIndent_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_PurchaseIndent_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PurchaseIndent_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_PurchaseIndent_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PurchaseIndent_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_PurchaseIndent_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PurchaseIndent_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Purchase_Item_Edit]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Purchase_Item_Edit]
GO
/****** Object:  StoredProcedure [dbo].[usp_Purchase_Indent_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Purchase_Indent_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_PromoMailLead_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PromoMailLead_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_PromoMailDocList_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PromoMailDocList_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_PromoMail_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PromoMail_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_PromoMail_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PromoMail_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_PromoMail_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PromoMail_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_PromoMail_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PromoMail_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_PromoMail_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PromoMail_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_PromoMail_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PromoMail_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_PODocList_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PODocList_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_PO_Update2]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PO_Update2]
GO
/****** Object:  StoredProcedure [dbo].[usp_PO_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PO_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_PO_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PO_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_PO_Rate]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PO_Rate]
GO
/****** Object:  StoredProcedure [dbo].[usp_PO_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PO_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_PO_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PO_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_PO_Id]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PO_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_PO_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_PO_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_MaterialReturn_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MaterialReturn_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_MaterialReturn_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MaterialReturn_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_MaterialReturn_ItemNEW_lov]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MaterialReturn_ItemNEW_lov]
GO
/****** Object:  StoredProcedure [dbo].[usp_MaterialReturn_Item_lov]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MaterialReturn_Item_lov]
GO
/****** Object:  StoredProcedure [dbo].[usp_MaterialReturn_Item]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MaterialReturn_Item]
GO
/****** Object:  StoredProcedure [dbo].[usp_MaterialReturn_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MaterialReturn_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_MaterialIssues_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MaterialIssues_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_MaterialIssues_DELETEVerify]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MaterialIssues_DELETEVerify]
GO
/****** Object:  StoredProcedure [dbo].[usp_MaterialIssue_Reason]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MaterialIssue_Reason]
GO
/****** Object:  StoredProcedure [dbo].[usp_MaterialIssue_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MaterialIssue_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_MaterialIssue_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MaterialIssue_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_MatearialReturn_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MatearialReturn_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_MatearialReturn_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MatearialReturn_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_MatearialIssue_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MatearialIssue_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_MatearialIssue_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_MatearialIssue_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_mailStatus]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_mailStatus]
GO
/****** Object:  StoredProcedure [dbo].[usp_LogIN_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_LogIN_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_LogIN_Fetch]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_LogIN_Fetch]
GO
/****** Object:  StoredProcedure [dbo].[usp_LeadStatus_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_LeadStatus_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_LeadFollowUp_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_LeadFollowUp_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_LeadFollowUp_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_LeadFollowUp_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_LeadDocList_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_LeadDocList_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_LeadDocfinal]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_LeadDocfinal]
GO
/****** Object:  StoredProcedure [dbo].[usp_Lead_Upload]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Lead_Upload]
GO
/****** Object:  StoredProcedure [dbo].[usp_Lead_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Lead_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Lead_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Lead_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Lead_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Lead_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Lead_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Lead_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Lead_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Lead_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Lead_Id]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Lead_Id]
GO
/****** Object:  StoredProcedure [dbo].[usp_Lead_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Lead_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Lead_CUSTID_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Lead_CUSTID_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemStock_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemStock_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemStock_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemStock_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemStock_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemStock_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemStock_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemStock_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemStock_Editable]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemStock_Editable]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemStock_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemStock_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemStock_AdjustStock]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemStock_AdjustStock]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemGroup_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemGroup_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemGroup_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemGroup_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemGroup_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemGroup_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemGroup_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemGroup_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemGroup_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemGroup_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemGroup_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemGroup_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemDetail_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemDetail_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemClass_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemClass_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemClass_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemClass_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemClass_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemClass_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemClass_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemClass_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemClass_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemClass_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemClass_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemClass_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemCategory_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemCategory_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemCategory_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemCategory_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemCategory_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemCategory_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemCategory_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemCategory_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemCategory_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemCategory_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemCategory_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemCategory_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemAdjustment_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemAdjustment_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemAdjustment_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemAdjustment_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemAdjustment_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemAdjustment_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemAdjustment_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemAdjustment_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemAdjustment_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemAdjustment_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_ItemAdjustment_Confirm]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ItemAdjustment_Confirm]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_Upload]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_Upload]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_StockItemLOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_StockItemLOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_Service_edit]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_Service_edit]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_Sale_edit]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_Sale_edit]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_Rate_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_Rate_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_Rate_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_Rate_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_Quotation_edit]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_Quotation_edit]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_LOV_QUOTATION]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_LOV_QUOTATION]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_List_old]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_List_old]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_GRN_edit]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_GRN_edit]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_DebitNote_edit]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_DebitNote_edit]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_CreditNote_edit]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_CreditNote_edit]
GO
/****** Object:  StoredProcedure [dbo].[usp_Item_AdjustItemLOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Item_AdjustItemLOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_IsCUST_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_IsCUST_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Invoice_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Invoice_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_InqResponse_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_InqResponse_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_Indent_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Indent_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Indent_SelectNew]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Indent_SelectNew]
GO
/****** Object:  StoredProcedure [dbo].[usp_Indent_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Indent_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Indent_Rate]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Indent_Rate]
GO
/****** Object:  StoredProcedure [dbo].[usp_Indent_Purchase_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Indent_Purchase_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Indent_New_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Indent_New_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Indent_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Indent_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Indent_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Indent_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Indent_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Indent_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Indent_DNOutstanding]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Indent_DNOutstanding]
GO
/****** Object:  StoredProcedure [dbo].[usp_Indent_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Indent_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Import_Vendor_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Import_Vendor_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Import_Lead_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Import_Lead_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Import_Item_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Import_Item_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Import_Customer_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Import_Customer_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Godown_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Godown_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Godown_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Godown_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Godown_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Godown_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Godown_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Godown_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Godown_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Godown_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Godown_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Godown_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserWisePrivilege_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_GetUserWisePrivilege_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSourcePath]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_GetSourcePath]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSelectedPrivilegeList]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_GetSelectedPrivilegeList]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetPrivilege_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_GetPrivilege_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetParentPrivilege_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_GetParentPrivilege_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Get_Privilage_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Get_Privilage_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_FYYear_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_FYYear_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_Expense_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Expense_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Expense_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Expense_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Expense_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Expense_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Expense_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Expense_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Expense_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Expense_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Employee_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Employee_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Employee_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Employee_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Employee_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Employee_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Employee_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Employee_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Employee_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Employee_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Employee_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Employee_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_EmpDepartment_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_EmpDepartment_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_Email_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Email_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Email_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Email_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Email_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Email_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Email_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Email_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Email_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Email_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Email_Detail_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Email_Detail_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Email_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Email_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_DebitNote_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_DebitNote_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_DebitNote_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_DebitNote_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_DebitNote_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_DebitNote_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_DebitNote_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_DebitNote_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_DebitNote_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_DebitNote_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_DBInitialize]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_DBInitialize]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerReceiptReturn_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerReceiptReturn_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerReceiptReturn_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerReceiptReturn_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerReceiptReturn_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerReceiptReturn_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerReceiptReturn_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerReceiptReturn_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerReceiptReturn_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerReceiptReturn_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerReceipt_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerReceipt_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerReceipt_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerReceipt_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerReceipt_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerReceipt_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerReceipt_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerReceipt_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerReceipt_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerReceipt_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerPaymentReturn_PendingSI_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerPaymentReturn_PendingSI_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerPayment_PendingSI_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerPayment_PendingSI_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerMain_Select_Account]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerMain_Select_Account]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerMain_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerMain_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerMain_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerMain_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerFollowUp_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerFollowUp_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerFollowUp_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerFollowUp_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_CustomerFFollowUp_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CustomerFFollowUp_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_Upload]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_Upload]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_Select_Account]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_Select_Account]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_Sales_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_Sales_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_ReceiptPendingList_old1]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_ReceiptPendingList_old1]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_ReceiptPendingList_old]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_ReceiptPendingList_old]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_ReceiptPendingList]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_ReceiptPendingList]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_Quotation_LOV_oldN]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_Quotation_LOV_oldN]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_Quotation_LOV_old]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_Quotation_LOV_old]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_Quotation_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_Quotation_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_LOV_Service]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_LOV_Service]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_LOV_PaymentReturn]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_LOV_PaymentReturn]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_LOV_Payment]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_LOV_Payment]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_LOV_CreditNote]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_LOV_CreditNote]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_Lead_LOV_Details]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_Lead_LOV_Details]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_Lead_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_Lead_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_Insert_updateAccount]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_Insert_updateAccount]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Customer_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Customer_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_Currency_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Currency_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Currency_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Currency_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Currency_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Currency_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Currency_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Currency_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Currency_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Currency_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Currency_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Currency_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_CreditNote_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CreditNote_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_CreditNote_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CreditNote_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_CreditNote_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CreditNote_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_CreditNote_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CreditNote_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_CreditNote_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CreditNote_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Country_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Country_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Country_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Country_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Country_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Country_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Country_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Country_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Country_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Country_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Country_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Country_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_ContactDetail_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ContactDetail_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_ContactDetail_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ContactDetail_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_ContactDetail_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_ContactDetail_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_CompanyInfoDetail_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CompanyInfoDetail_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_CompanyInfo_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CompanyInfo_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_CompanyInfo_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CompanyInfo_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_CompanyInfo_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CompanyInfo_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_CompanyInfo_Detail_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CompanyInfo_Detail_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_CompanyCount]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_CompanyCount]
GO
/****** Object:  StoredProcedure [dbo].[usp_Company_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Company_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_Commission_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Commission_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_City_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_City_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_City_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_City_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_City_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_City_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_City_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_City_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_City_GetStateCountry]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_City_GetStateCountry]
GO
/****** Object:  StoredProcedure [dbo].[usp_City_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_City_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_City_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_City_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_Check_Revised]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Check_Revised]
GO
/****** Object:  StoredProcedure [dbo].[usp_Category_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Category_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_Bank_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Bank_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Bank_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Bank_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Bank_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Bank_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Bank_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Bank_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Bank_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Bank_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_Bank_DDL]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Bank_DDL]
GO
/****** Object:  StoredProcedure [dbo].[usp_BackupList]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_BackupList]
GO
/****** Object:  StoredProcedure [dbo].[usp_BackUp]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_BackUp]
GO
/****** Object:  StoredProcedure [dbo].[usp_Automatic_Number_ID]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Automatic_Number_ID]
GO
/****** Object:  StoredProcedure [dbo].[usp_Automatic_Number]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Automatic_Number]
GO
/****** Object:  StoredProcedure [dbo].[usp_Area_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Area_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Area_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Area_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Area_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Area_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Area_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Area_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Area_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Area_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_AddressDetail_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_AddressDetail_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_AddressDetail_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_AddressDetail_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Account_Update]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Account_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_Account_Select]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Account_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_Account_LOV]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Account_LOV]
GO
/****** Object:  StoredProcedure [dbo].[usp_Account_List]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Account_List]
GO
/****** Object:  StoredProcedure [dbo].[usp_Account_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Account_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_Account_Delete]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[usp_Account_Delete]
GO
/****** Object:  StoredProcedure [dbo].[rpt_VendorPaymentReturn]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_VendorPaymentReturn]
GO
/****** Object:  StoredProcedure [dbo].[rpt_VendorPayment]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_VendorPayment]
GO
/****** Object:  StoredProcedure [dbo].[rpt_ServiceInvoice-old]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_ServiceInvoice-old]
GO
/****** Object:  StoredProcedure [dbo].[rpt_ServiceInvoice]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_ServiceInvoice]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Service_TNC]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Service_TNC]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Service_Order]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Service_Order]
GO
/****** Object:  StoredProcedure [dbo].[rpt_SalesInvoiceRegister]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_SalesInvoiceRegister]
GO
/****** Object:  StoredProcedure [dbo].[rpt_salesinvoicereg_new]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_salesinvoicereg_new]
GO
/****** Object:  StoredProcedure [dbo].[rpt_SalesInvoice-old]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_SalesInvoice-old]
GO
/****** Object:  StoredProcedure [dbo].[rpt_SalesInvoiceDetail]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_SalesInvoiceDetail]
GO
/****** Object:  StoredProcedure [dbo].[rpt_SalesInvoice]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_SalesInvoice]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Sales_TNC]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Sales_TNC]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Sales_Service_Quotation]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Sales_Service_Quotation]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Sales_Service]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Sales_Service]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Quotation_TNC]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Quotation_TNC]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Quotation_Revised_TNC]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Quotation_Revised_TNC]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Quotation_old]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Quotation_old]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Quotation]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Quotation]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Purchase_TNC]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Purchase_TNC]
GO
/****** Object:  StoredProcedure [dbo].[rpt_ProfitLossStatement]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_ProfitLossStatement]
GO
/****** Object:  StoredProcedure [dbo].[rpt_POVsGRN_Register]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_POVsGRN_Register]
GO
/****** Object:  StoredProcedure [dbo].[rpt_PORegister]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_PORegister]
GO
/****** Object:  StoredProcedure [dbo].[rpt_POGST_Register]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_POGST_Register]
GO
/****** Object:  StoredProcedure [dbo].[rpt_PODetail]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_PODetail]
GO
/****** Object:  StoredProcedure [dbo].[rpt_PO]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_PO]
GO
/****** Object:  StoredProcedure [dbo].[rpt_MaterialReturn]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_MaterialReturn]
GO
/****** Object:  StoredProcedure [dbo].[rpt_MaterialIssues]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_MaterialIssues]
GO
/****** Object:  StoredProcedure [dbo].[rpt_ItemBeanCard]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_ItemBeanCard]
GO
/****** Object:  StoredProcedure [dbo].[rpt_IndentRegister]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_IndentRegister]
GO
/****** Object:  StoredProcedure [dbo].[rpt_IndentDetail]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_IndentDetail]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Indent]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Indent]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Get_ReceivedQty]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Get_ReceivedQty]
GO
/****** Object:  StoredProcedure [dbo].[rpt_DebitNote]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_DebitNote]
GO
/****** Object:  StoredProcedure [dbo].[rpt_CustomerReturnReceipt]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_CustomerReturnReceipt]
GO
/****** Object:  StoredProcedure [dbo].[rpt_CustomerReceipt]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_CustomerReceipt]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Customer_Payment_Receipt-old]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Customer_Payment_Receipt-old]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Customer_Payment_Receipt]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Customer_Payment_Receipt]
GO
/****** Object:  StoredProcedure [dbo].[rpt_CreditNoteDetails]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_CreditNoteDetails]
GO
/****** Object:  StoredProcedure [dbo].[rpt_CreditNote]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_CreditNote]
GO
/****** Object:  StoredProcedure [dbo].[rpt_CountryStateCityArea]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_CountryStateCityArea]
GO
/****** Object:  StoredProcedure [dbo].[rpt_CompanyOld]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_CompanyOld]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Company1]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Company1]
GO
/****** Object:  StoredProcedure [dbo].[rpt_Company]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_Company]
GO
/****** Object:  StoredProcedure [dbo].[rpt_ChallanCumTaxInvoice]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_ChallanCumTaxInvoice]
GO
/****** Object:  StoredProcedure [dbo].[rpt_AccountLedger]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[rpt_AccountLedger]
GO
/****** Object:  StoredProcedure [dbo].[proc_DBInitialize]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[proc_DBInitialize]
GO
/****** Object:  StoredProcedure [dbo].[insert_Demo]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[insert_Demo]
GO
/****** Object:  StoredProcedure [dbo].[GetMaxPIID]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[GetMaxPIID]
GO
/****** Object:  StoredProcedure [dbo].[GetMaxMRID]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[GetMaxMRID]
GO
/****** Object:  StoredProcedure [dbo].[ExceptionLog_Insert]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[ExceptionLog_Insert]
GO
/****** Object:  StoredProcedure [dbo].[CompanyCount]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP PROCEDURE [dbo].[CompanyCount]
GO
/****** Object:  User [Sskonlinechromoto2019]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP USER [Sskonlinechromoto2019]
GO
/****** Object:  User [SMimageshreekrishna]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP USER [SMimageshreekrishna]
GO
/****** Object:  User [QMonlinedemo]    Script Date: 08/11/2019 5:02:39 PM ******/
DROP USER [QMonlinedemo]
GO
