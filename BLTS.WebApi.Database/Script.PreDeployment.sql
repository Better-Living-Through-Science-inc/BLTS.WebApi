USE [BenefitsIntegration]
GO
/*clearing of old log data  */
TRUNCATE TABLE [BenefitsIntegrationImport_ETL].[ImportHistoryProcessErrorDetail]
TRUNCATE TABLE [LOG].[SsisActivityLog]
TRUNCATE TABLE [LOG].[ValidationError]
TRUNCATE TABLE [EDI].[CurrentProcessReferenceMap]
TRUNCATE TABLE [EDI].[CurrentProcessPerson]
TRUNCATE TABLE [EDI].[CurrentProcessEmployee]
TRUNCATE TABLE [EDI].[CurrentProcessEnrollment]
TRUNCATE TABLE [EDI].[CurrentProcessMappingDocument]
TRUNCATE TABLE [LOG].[OnDemandProcessLog]
TRUNCATE TABLE [LOG].[SystemStatusLog]


--UPDATE [ImportLookup].[AddressType]
--   SET [LookupValueInt] = [AddressTypeId]
--GO

--UPDATE [dbo].[SfFeedGenerationLog]
--   SET [UniqueId] = 555555555
-- WHERE [UniqueId] IS NULL
--GO


--/*resolve referencial integrity error*/
--MERGE [dbo].[SfFeedGenerationLog] AS TARGET
--USING (
--SELECT DISTINCT
--  [SfFeedGenerationLog].[ImportHistoryId]
--FROM
--  [dbo].[SfFeedGenerationLog]
--  INNER JOIN [BenefitsIntegrationImport_ETL].[ImportHistory] ON [ImportHistory].[ImportHistoryId] = [SfFeedGenerationLog].[ImportHistoryId]
--) AS SOURCE
--ON TARGET.[ImportHistoryId] = SOURCE.[ImportHistoryId]
--WHEN NOT MATCHED BY SOURCE
--THEN
--  DELETE;

--/*resolve referencial integrity error*/
--MERGE [LNK].[SfClientExtClient] AS TARGET
--USING (
--  SELECT
--    DENSE_RANK() OVER (PARTITION BY [SfClientExtClient].[ClientVendorFeedId] ORDER BY [SfClientExtClient].[CreatedOn] DESC) AS [DeletionRank]
--    ,[SfClientExtClient].[SfClientExtClientId]
--  FROM
--    [LNK].[SfClientExtClient]
--  WHERE
--    [SfClientExtClient].[IsDeleted] = 0
--) AS SOURCE
--ON TARGET.[SfClientExtClientId] = SOURCE.[SfClientExtClientId] AND SOURCE.[DeletionRank] > 1
--WHEN MATCHED
--THEN
--  UPDATE SET TARGET.[IsDeleted] = 1;
--GO
