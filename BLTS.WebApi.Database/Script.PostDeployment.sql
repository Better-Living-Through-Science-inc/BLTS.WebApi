USE [Website]
GO


MERGE [dbo].[OperationalConfiguration] AS TARGET
USING (

          SELECT 1 AS [ApplicationId], N'AutoRefreshTimer' AS [PropertyName], N'length of time in hours (int) between cache refresh' AS [Description], NULL AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], 1 AS [IntegerValue], NULL AS [LongValue], NULL AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'ConsolPopupLogLevel' AS [PropertyName], N'Valid values are "Error" "Warning" "Information" and "None"' AS [Description], NULL AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], NULL AS [IntegerValue], NULL AS [LongValue], N'None' AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'DatabaseAppLogLevel' AS [PropertyName], N'Valid values are "Error" "Warning" "Information" and "None"' AS [Description], NULL AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], NULL AS [IntegerValue], NULL AS [LongValue], N'Information' AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'EmailLogLevel' AS [PropertyName], N'Valid values are "Error" "Warning" "Information" and "None"' AS [Description], NULL AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], NULL AS [IntegerValue], NULL AS [LongValue], N'None' AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'EmailLogUserFrom' AS [PropertyName], N'Log to email from email address' AS [Description], NULL AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], NULL AS [IntegerValue], NULL AS [LongValue], N'MCrawford@BetterLivingThroughScience' AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'EmailLogUserToList' AS [PropertyName], N'Log to email recipients ";" separated ex: "MCrawford@BetterLivingThroughScience"' AS [Description], NULL AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], NULL AS [IntegerValue], NULL AS [LongValue], N'MCrawford@BetterLivingThroughScience' AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'EnableApplicationCache' AS [PropertyName], N'Turns on and off the DB cache system' AS [Description], 0 AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], NULL AS [IntegerValue], NULL AS [LongValue], NULL AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'EnableDbSaves' AS [PropertyName], N'disables saves and deletes' AS [Description], 1 AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], NULL AS [IntegerValue], NULL AS [LongValue], NULL AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'EnableManyToManyRelationshipLoading' AS [PropertyName], N'Turns on and off the loading of many to many relationships as this can be an extremely high number of DB calls, turn off when manual is better' AS [Description], 0 AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], NULL AS [IntegerValue], NULL AS [LongValue], NULL AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'EnableSubObjectCrossLink' AS [PropertyName], N'Turns on and off the loading of sub objects and then cross populating the collection in the child object of the parent object - making a full circle possible' AS [Description], 1 AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], NULL AS [IntegerValue], NULL AS [LongValue], NULL AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'ErrorRetryNumber' AS [PropertyName], N'Number of retries when errors occur' AS [Description], NULL AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], 10 AS [IntegerValue], NULL AS [LongValue], NULL AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'FileArchivePath' AS [PropertyName], N'Archive path to append to existing path when archiving files' AS [Description], NULL AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], NULL AS [IntegerValue], NULL AS [LongValue], N'Archive\$YYYY$$MM$$DD$\$HH$$mm$$SS$' AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'ParallelFileReadThreadCount' AS [PropertyName], N'Number of files to read in parallel' AS [Description], NULL AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], 1 AS [IntegerValue], NULL AS [LongValue], NULL AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'SingleBatchMaxLimit' AS [PropertyName], N'Max batch size to send to SQL for a single operation' AS [Description], NULL AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], 25000 AS [IntegerValue], NULL AS [LongValue], NULL AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'SqlCommandTimeout' AS [PropertyName], N'Command timeout ' AS [Description], NULL AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], NULL AS [IntegerValue], NULL AS [LongValue], NULL AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'SystemAppLogLevel' AS [PropertyName], N'Valid values are "Error" "Warning" "Information" and "None"' AS [Description], NULL AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], NULL AS [IntegerValue], NULL AS [LongValue], N'None' AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]
UNION ALL SELECT 1 AS [ApplicationId], N'WaitTimeout' AS [PropertyName], N'Seconds (int) timeout to wait for errors and timers and try again' AS [Description], NULL AS [BoolValue], NULL AS [DateValue], NULL AS [DecimalValue], NULL AS [GuidValue], 5 AS [IntegerValue], NULL AS [LongValue], NULL AS [StringValue], 0 AS [IsConnectionString], 1 AS [IsEnabled], '2021-04-07 17:32:45.6133276' AS [CreationDate], '2021-04-07 17:32:45.6133276' AS [LastModificationDate], 0 AS [IsDeleted]

) AS SOURCE
ON TARGET.[ApplicationId] = SOURCE.[ApplicationId] AND TARGET.[PropertyName] = SOURCE.[PropertyName]
WHEN NOT MATCHED BY TARGET
THEN
  INSERT ([ApplicationId],[PropertyName],[Description],[BoolValue],[DateValue],[DecimalValue],[GuidValue],[IntegerValue],[LongValue],[StringValue],[IsConnectionString],[IsEnabled],[CreationDate],[LastModificationDate],[IsDeleted])
  VALUES (SOURCE.[ApplicationId],SOURCE.[PropertyName],SOURCE.[Description],SOURCE.[BoolValue],SOURCE.[DateValue],SOURCE.[DecimalValue],SOURCE.[GuidValue],SOURCE.[IntegerValue],SOURCE.[LongValue],SOURCE.[StringValue],SOURCE.[IsConnectionString],SOURCE.[IsEnabled],SOURCE.[CreationDate],SOURCE.[LastModificationDate],SOURCE.[IsDeleted])
WHEN MATCHED
THEN
  UPDATE SET TARGET.[ApplicationId] = SOURCE.[ApplicationId],TARGET.[PropertyName] = SOURCE.[PropertyName],TARGET.[Description] = SOURCE.[Description],TARGET.[BoolValue] = SOURCE.[BoolValue],TARGET.[DateValue] = SOURCE.[DateValue],TARGET.[DecimalValue] = SOURCE.[DecimalValue],TARGET.[GuidValue] = SOURCE.[GuidValue],TARGET.[IntegerValue] = SOURCE.[IntegerValue],TARGET.[LongValue] = SOURCE.[LongValue],TARGET.[StringValue] = SOURCE.[StringValue],TARGET.[IsConnectionString] = SOURCE.[IsConnectionString],TARGET.[IsEnabled] = SOURCE.[IsEnabled],TARGET.[CreationDate] = SOURCE.[CreationDate],TARGET.[LastModificationDate] = SOURCE.[LastModificationDate],TARGET.[IsDeleted] = SOURCE.[IsDeleted];
GO














--SET IDENTITY_INSERT [Polymorph].[DataSource] ON
--MERGE [Polymorph].[DataSource] AS TARGET
--USING (

--          SELECT 1 AS [DataSourceId], NULL AS [DelimiterId], N'BenefitsIntegration' AS [Name], N'BenefitsIntegration Database Tables' AS [Description], 0 AS [IsDeleted], 1 AS [IsGenerateDynamicObjects], 0 AS [IsImportSource], 0 AS [IsAutoGenerateObjectStructure]
--UNION ALL SELECT 2 AS [DataSourceId], NULL AS [DelimiterId], N'Bswift' AS [Name], N'Bswift XML Import File Structure' AS [Description], 0 AS [IsDeleted], 1 AS [IsGenerateDynamicObjects], 1 AS [IsImportSource], 1 AS [IsAutoGenerateObjectStructure]
--UNION ALL SELECT 3 AS [DataSourceId], NULL AS [DelimiterId], N'GenericFlatFile' AS [Name], N'Generic Flat File Import Structure' AS [Description], 0 AS [IsDeleted], 1 AS [IsGenerateDynamicObjects], 1 AS [IsImportSource], 1 AS [IsAutoGenerateObjectStructure]
--) AS SOURCE
--ON TARGET.[DataSourceId] = SOURCE.[DataSourceId]
--WHEN NOT MATCHED BY TARGET
--THEN
--  INSERT ([DataSourceId],[DelimiterId],[Name],[Description],[IsDeleted],[IsGenerateDynamicObjects],[IsImportSource],[IsAutoGenerateObjectStructure])
--  VALUES (SOURCE.[DataSourceId],SOURCE.[DelimiterId],SOURCE.[Name],SOURCE.[Description],SOURCE.[IsDeleted],SOURCE.[IsGenerateDynamicObjects],SOURCE.[IsImportSource],SOURCE.[IsAutoGenerateObjectStructure])
--WHEN MATCHED
--THEN
--  UPDATE SET TARGET.[DelimiterId] = SOURCE.[DelimiterId],TARGET.[Name] = SOURCE.[Name],TARGET.[Description] = SOURCE.[Description],TARGET.[IsDeleted] = SOURCE.[IsDeleted],TARGET.[IsGenerateDynamicObjects] = SOURCE.[IsGenerateDynamicObjects],TARGET.[IsImportSource] = SOURCE.[IsImportSource],TARGET.[IsAutoGenerateObjectStructure] = SOURCE.[IsAutoGenerateObjectStructure];
--SET IDENTITY_INSERT [Polymorph].[DataSource] OFF
--GO

--MERGE [Polymorph].[DataSourceProperty] AS TARGET
--USING (

--          SELECT 1 AS [DataSourceId], N'ConnectionString' AS [KeyName], N'Primary Database Connection String' AS [Description]
--UNION ALL SELECT 1 AS [DataSourceId], N'ConnectionTimeout' AS [KeyName], N'Primary Database Connection Timeout' AS [Description]
--) AS SOURCE
--ON TARGET.[DataSourceId] = SOURCE.[DataSourceId] AND TARGET.[KeyName] = SOURCE.[KeyName]
--WHEN MATCHED
--THEN
--  UPDATE SET TARGET.[Description] = SOURCE.[Description];
--GO

--MERGE [ImportLookup].[LeaveOfAbsence] AS TARGET
--USING (
--            SELECT 2 AS [ExtSourceId], 0 AS [LookupValueInt], N'' AS [LookupValueString], N'Not On Leave' AS [OutputValue], N'Not On Leave' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 1 AS [LookupValueInt], N'' AS [LookupValueString], N'FMLA' AS [OutputValue], N'FMLA' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 2 AS [LookupValueInt], N'' AS [LookupValueString], N'Military' AS [OutputValue], N'Military' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 3 AS [LookupValueInt], N'' AS [LookupValueString], N'Sabbatical' AS [OutputValue], N'Sabbatical' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 4 AS [LookupValueInt], N'' AS [LookupValueString], N'Short Term Disability' AS [OutputValue], N'Short Term Disability' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 5 AS [LookupValueInt], N'' AS [LookupValueString], N'Long Term Disability' AS [OutputValue], N'Long Term Disability' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 6 AS [LookupValueInt], N'' AS [LookupValueString], N'Non-FMLA' AS [OutputValue], N'Non-FMLA' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 7 AS [LookupValueInt], N'' AS [LookupValueString], N'Personal' AS [OutputValue], N'Personal' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 8 AS [LookupValueInt], N'' AS [LookupValueString], N'Workers Comp' AS [OutputValue], N'Workers Comp' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 9 AS [LookupValueInt], N'' AS [LookupValueString], N'Administrative' AS [OutputValue], N'Administrative' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 10 AS [LookupValueInt], N'' AS [LookupValueString], N'Other' AS [OutputValue], N'Other' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 11 AS [LookupValueInt], N'' AS [LookupValueString], N'STD - FMLA' AS [OutputValue], N'STD - FMLA' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 12 AS [LookupValueInt], N'' AS [LookupValueString], N'STD - non FMLA' AS [OutputValue], N'STD - non FMLA' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 13 AS [LookupValueInt], N'' AS [LookupValueString], N'STD - FMLA exhausted' AS [OutputValue], N'STD - FMLA exhausted' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 14 AS [LookupValueInt], N'' AS [LookupValueString], N'FMLA - using PTO' AS [OutputValue], N'FMLA - using PTO' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 15 AS [LookupValueInt], N'' AS [LookupValueString], N'FMLA - unpaid' AS [OutputValue], N'FMLA - unpaid' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 16 AS [LookupValueInt], N'' AS [LookupValueString], N'WC - FMLA' AS [OutputValue], N'WC - FMLA' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 17 AS [LookupValueInt], N'' AS [LookupValueString], N'WC - non FMLA' AS [OutputValue], N'WC - non FMLA' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 18 AS [LookupValueInt], N'' AS [LookupValueString], N'WC - FMLA exhausted' AS [OutputValue], N'WC - FMLA exhausted' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 19 AS [LookupValueInt], N'' AS [LookupValueString], N'Personal LOA - paid' AS [OutputValue], N'Personal LOA - paid' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 20 AS [LookupValueInt], N'' AS [LookupValueString], N'Personal LOA - unpaid' AS [OutputValue], N'Personal LOA - unpaid' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 21 AS [LookupValueInt], N'' AS [LookupValueString], N'Jury Duty' AS [OutputValue], N'Jury Duty' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 22 AS [LookupValueInt], N'' AS [LookupValueString], N'LTD - Pending' AS [OutputValue], N'LTD - Pending' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 23 AS [LookupValueInt], N'' AS [LookupValueString], N'STD - Pending' AS [OutputValue], N'STD - Pending' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 24 AS [LookupValueInt], N'' AS [LookupValueString], N'STD - Appeal' AS [OutputValue], N'STD - Appeal' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 25 AS [LookupValueInt], N'' AS [LookupValueString], N'LTD - Appeal' AS [OutputValue], N'LTD - Appeal' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 26 AS [LookupValueInt], N'' AS [LookupValueString], N'Layoff' AS [OutputValue], N'Layoff' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 27 AS [LookupValueInt], N'' AS [LookupValueString], N'STD - 3rd Party' AS [OutputValue], N'STD - 3rd Party' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 28 AS [LookupValueInt], N'' AS [LookupValueString], N'STD - Co Paid' AS [OutputValue], N'STD - Co Paid' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 29 AS [LookupValueInt], N'' AS [LookupValueString], N'Intermittent FMLA' AS [OutputValue], N'Intermittent FMLA' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 30 AS [LookupValueInt], N'' AS [LookupValueString], N'Leave Pending' AS [OutputValue], N'Leave Pending' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 31 AS [LookupValueInt], N'' AS [LookupValueString], N'Maternity' AS [OutputValue], N'Maternity' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 32 AS [LookupValueInt], N'' AS [LookupValueString], N'Education' AS [OutputValue], N'Education' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 33 AS [LookupValueInt], N'' AS [LookupValueString], N'Medical' AS [OutputValue], N'Medical' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 34 AS [LookupValueInt], N'' AS [LookupValueString], N'Parental' AS [OutputValue], N'Parental' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 35 AS [LookupValueInt], N'' AS [LookupValueString], N'Educational Employment Break' AS [OutputValue], N'Educational Employment Break' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 36 AS [LookupValueInt], N'' AS [LookupValueString], N'Jury Duty - Unpaid' AS [OutputValue], N'Jury Duty - Unpaid' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 37 AS [LookupValueInt], N'' AS [LookupValueString], N'Military - Unpaid' AS [OutputValue], N'Military - Unpaid' AS [Description]
--  UNION ALL SELECT 2 AS [ExtSourceId], 38 AS [LookupValueInt], N'' AS [LookupValueString], N'Maternity/Paternity - Unpaid' AS [OutputValue], N'Maternity/Paternity - Unpaid' AS [Description]
--) AS SOURCE
--ON TARGET.[ExtSourceId] = SOURCE.[ExtSourceId] AND TARGET.[LookupValueInt] = SOURCE.[LookupValueInt]
--WHEN NOT MATCHED BY TARGET
--THEN
--  INSERT ([ExtSourceId],[LookupValueInt],[LookupValueString],[OutputValue],[Description])
--  VALUES (SOURCE.[ExtSourceId],SOURCE.[LookupValueInt],SOURCE.[LookupValueString],SOURCE.[OutputValue],SOURCE.[Description])
--WHEN MATCHED
--THEN
--  UPDATE SET TARGET.[ExtSourceId] = SOURCE.[ExtSourceId],TARGET.[LookupValueInt] = SOURCE.[LookupValueInt],TARGET.[LookupValueString] = SOURCE.[LookupValueString],TARGET.[OutputValue] = SOURCE.[OutputValue],TARGET.[Description] = SOURCE.[Description];


--MERGE [Polymorph].[ValueFormat] AS TARGET
--USING (

--          SELECT 1 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'YYYYMMDD' AS [Description], N'yyyyMMdd' AS [FormatCode], N'YYYYMMDD' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 2 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'YYYY/MM/DD' AS [Description], N'yyyy/MM/dd' AS [FormatCode], N'YYYY/MM/DD' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 3 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'YYYY-MM-DD' AS [Description], N'yyyy-MM-dd' AS [FormatCode], N'YYYY-MM-DD' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 4 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'MMDDYYYY' AS [Description], N'MMddyyyy' AS [FormatCode], N'MMDDYYYY' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 5 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'MM/DD/YYYY' AS [Description], N'MM/dd/yyyy' AS [FormatCode], N'MM/DD/YYYY' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 6 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'MM-DD-YYYY' AS [Description], N'MM-dd-yyyy' AS [FormatCode], N'MM-DD-YYYY' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 7 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'DDMMYYYY' AS [Description], N'ddMMyyyy' AS [FormatCode], N'DDMMYYYY' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 8 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'DD/MM/YYYY' AS [Description], N'dd/MM/yyyy' AS [FormatCode], N'DD/MM/YYYY' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 9 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'DD-MM-YYYY' AS [Description], N'dd-MM-yyyy' AS [FormatCode], N'DD-MM-YYYY' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 10 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'YYYYMMDDHHMM' AS [Description], N'yyyyMMddHHmm' AS [FormatCode], N'YYYYMMDDHHMM' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 11 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'M/d/yyyy hh:mm:ss tt' AS [Description], N'M/d/yyyy hh:mm:ss tt' AS [FormatCode], N'M/d/yyyy hh:mm:ss tt' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 12 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'M/D/YYYY' AS [Description], N'M/d/yyyy' AS [FormatCode], N'M/D/YYYY' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 13 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'The hour, using a 12-hour clock from 1 to 12' AS [Description], N'h' AS [FormatCode], N'Hour' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 14 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'The hour, using a 12-hour clock from 01 to 12' AS [Description], N'hh' AS [FormatCode], N'Hour - 2 Digit' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 15 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'The hour, using a 24-hour clock from 0 to 23' AS [Description], N'H' AS [FormatCode], N'Hour - 24 hour' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 16 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'The hour, using a 24-hour clock from 00 to 23' AS [Description], N'HH' AS [FormatCode], N'Hour - 24 hour  2 Digit' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 17 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'The minute, from 0 through 59' AS [Description], N'm' AS [FormatCode], N'Minute' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 18 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'The minute, from 00 through 59' AS [Description], N'mm' AS [FormatCode], N'Minute - 2 Digit' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 19 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'The second, from 0 through 59' AS [Description], N's' AS [FormatCode], N'Second' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 20 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'The second, from 00 through 59' AS [Description], N'ss' AS [FormatCode], N'Second - 2 Digit' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 21 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'The first character of the AM/PM designator' AS [Description], N't' AS [FormatCode], N'A/M' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 22 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'The AM/PM designator' AS [Description], N'tt' AS [FormatCode], N'AM/PM' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 23 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'Hour using 1 through 12 (Using 12 hour clock), minute using 0 through 59, and second using 0 through 59' AS [Description], N'hms' AS [FormatCode], N'HourMinuteSecond - 777' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 24 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'Hour using 01 through 12 (Using 12 hour clock), minute using 00 through 59, and second using 00 through 59' AS [Description], N'hhmmss' AS [FormatCode], N'HourMinuteSecond - 070707' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 25 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'Hour using 0 through 23 (Using 24 hour clock), minute using 0 through 59, and second using 0 through 59' AS [Description], N'Hms' AS [FormatCode], N'HourMinuteSecond - 1777' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 26 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'Hour using 00 through 23 (Using 24 hour clock), minute using 00 through 59, and second using 00 through 59' AS [Description], N'HHmmss' AS [FormatCode], N'HourMinuteSecond - 170707' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 27 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'Hour using 01 through 12 (Using 12 hour clock), minute using 00 through 59, and second using 00 through 59 and AM/PM designator' AS [Description], N'hhmmsstt' AS [FormatCode], N'HourMinuteSecond - 070707pm' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 28 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'Hour using 00 through 23 (Using 24 hour clock), minute using 00 through 59, and second using 00 through 59 and AM/PM Designator' AS [Description], N'HHmmsstt' AS [FormatCode], N'HourMinuteSecond - 170707pm' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 29 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'dd' AS [Description], N'dd' AS [FormatCode], N'DD' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 30 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'DDMMYY' AS [Description], N'ddMMyy' AS [FormatCode], N'DDMMYY' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 31 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'MM' AS [Description], N'MM' AS [FormatCode], N'MM' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 32 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'MMDDYY' AS [Description], N'MMddyy' AS [FormatCode], N'MMDDYY' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 33 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'YYMMDD' AS [Description], N'yyMMdd' AS [FormatCode], N'YYMMDD' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 34 AS [ValueFormatId], 9 AS [ObjectProperyTypeId], N'yyyy' AS [Description], N'yyyy' AS [FormatCode], N'YYYY' AS [Name], NULL AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 35 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Replace whitespace with emptystring' AS [Description], N'' AS [FormatCode], N'Replace whitespace with emptystring' AS [Name], N' ' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 36 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'For Addresses - replace # with whitespace, then strip everything but whitespace and alphanumeric' AS [Description], N' |||' AS [FormatCode], N'For Addresses: replace "#" with whitespace, then strip everything but whitespace and alphanumeric' AS [Name], N'#|||[^A-Za-z 0-9]' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 37 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Right 1 characters of string' AS [Description], N'$1' AS [FormatCode], N'Right 1' AS [Name], N'.*(.{1})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 38 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Right 10 characters of string' AS [Description], N'$1' AS [FormatCode], N'Right 10' AS [Name], N'.*(.{10})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 39 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Right 2 characters of string' AS [Description], N'$1' AS [FormatCode], N'Right 2' AS [Name], N'.*(.{2})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 40 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Right 3 characters of string' AS [Description], N'$1' AS [FormatCode], N'Right 3' AS [Name], N'.*(.{3})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 41 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Right 4 characters of string' AS [Description], N'$1' AS [FormatCode], N'Right 4' AS [Name], N'.*(.{4})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 42 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Right 5 characters of string' AS [Description], N'$1' AS [FormatCode], N'Right 5' AS [Name], N'.*(.{5})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 43 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Right 6 characters of string' AS [Description], N'$1' AS [FormatCode], N'Right 6' AS [Name], N'.*(.{6})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 44 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Right 7 characters of string' AS [Description], N'$1' AS [FormatCode], N'Right 7' AS [Name], N'.*(.{7})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 45 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Right 8 characters of string' AS [Description], N'$1' AS [FormatCode], N'Right 8' AS [Name], N'.*(.{8})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 46 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Right 9 characters of string' AS [Description], N'$1' AS [FormatCode], N'Right 9' AS [Name], N'.*(.{9})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 47 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'10 digit phone with all non-numeric characters stripped' AS [Description], N'$2$3$4' AS [FormatCode], N'10 digit phone with all non-numeric characters stripped' AS [Name], N'.*\+*([1-9]{0,3}-*[1-9]{0,3})[-. /]*\(*([2-9]\d{2})\)*[-. /]*(\d{3})[-. /]*(\d{4}) *e*x*t*\.* *\d{0,4}$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 48 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'10 digit phone with dashes' AS [Description], N'$2-$3-$4' AS [FormatCode], N'10 digit phone with dashes' AS [Name], N'.*\+*([1-9]{0,3}-*[1-9]{0,3})[-. /]*\(*([2-9]\d{2})\)*[-. /]*(\d{3})[-. /]*(\d{4}) *e*x*t*\.* *\d{0,4}$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 49 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'10 digit phone with parens and a dash' AS [Description], N'($2) $3-$4' AS [FormatCode], N'10 digit phone with parens and a dash' AS [Name], N'.*\+*([1-9]{0,3}-*[1-9]{0,3})[-. /]*\(*([2-9]\d{2})\)*[-. /]*(\d{3})[-. /]*(\d{4}) *e*x*t*\.* *\d{0,4}$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 50 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Replace [:''"",!.;?]] with emptystring' AS [Description], N'' AS [FormatCode], N'Yes' AS [Name], N'[:''"",!.;?]' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 51 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Postal code, five digits, or five dash four (if available)' AS [Description], N'|||$1-$2|||$1$3' AS [FormatCode], N'Postal code: five digits, or five dash four (if available)' AS [Name], N'[^0-9]|||^([0-9]{5})([0-9]{4})?\z|||^(([0-9]|-)*)([0-9])-?' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 52 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Left 1 character of string' AS [Description], N'$1' AS [FormatCode], N'Left 1' AS [Name], N'^(.{0,1}).*' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 53 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Left 2 characters of string' AS [Description], N'$1' AS [FormatCode], N'Left 2' AS [Name], N'^(.{0,2}).*' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 54 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Left 3 characters of string' AS [Description], N'$1' AS [FormatCode], N'Left 3' AS [Name], N'^(.{0,3}).*' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 55 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Left 4 characters of string' AS [Description], N'$1' AS [FormatCode], N'Left 4' AS [Name], N'^(.{0,4}).*' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 56 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Left 5 characters of string' AS [Description], N'$1' AS [FormatCode], N'Left 5' AS [Name], N'^(.{0,5}).*' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 57 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Left 6 characters of string' AS [Description], N'$1' AS [FormatCode], N'Left 6' AS [Name], N'^(.{0,6}).*' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 58 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Left 7 characters of string' AS [Description], N'$1' AS [FormatCode], N'Left 7' AS [Name], N'^(.{0,7}).*' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 59 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Left 8 characters of string' AS [Description], N'$1' AS [FormatCode], N'Left 8' AS [Name], N'^(.{0,8}).*' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 60 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Left 9 characters of string' AS [Description], N'$1' AS [FormatCode], N'Left 9' AS [Name], N'^(.{0,9}).*' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 61 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'SSN stripped of non-numeric characters' AS [Description], N'$1$2$3' AS [FormatCode], N'SSN stripped of non-numeric characters' AS [Name], N'^([0-9]{3})[^0-9]?([0-9]{2})[^0-9]?([0-9]{4})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 62 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'SSN with dashes' AS [Description], N'$1-$2-$3' AS [FormatCode], N'SSN with dashes' AS [Name], N'^([0-9]{3})[^0-9]?([0-9]{2})[^0-9]?([0-9]{4})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 63 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'SSN stripped of non-numeric characters and prepended with 0' AS [Description], N'0$1$2$3' AS [FormatCode], N'SSN stripped of non-numeric characters and prepended with 0' AS [Name], N'^([0-9]{3})[^0-9]?([0-9]{2})[^0-9]?([0-9]{4})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 64 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Postal code, five digits, remainder stripped if sent' AS [Description], N'$1' AS [FormatCode], N'Postal code, five digits, remainder stripped if sent' AS [Name], N'^(\d{5})([ -]{1})?(\d{4})?$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 65 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Postal code, up to nine digits, with whitespace or dash stripped' AS [Description], N'$1$3' AS [FormatCode], N'Postal code, up to nine digits, with whitespace or dash stripped' AS [Name], N'^(\d{5})([ -]{1})?(\d{4})?$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 66 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Phone extension, up to six digits, with non-numeric characters stripped' AS [Description], N'$1' AS [FormatCode], N'Phone extension, up to six digits, with non-numeric characters stripped' AS [Name], N'^*e*x*t*\.* *(\d{0,6})$' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 67 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'YES STRIP ANY PUNCTUATIONS' AS [Description], N' |||' AS [FormatCode], N'Yes' AS [Name], N'-|||[^A-Za-z 0-9]' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 68 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'For Addresses - replace dash with whitespace, then strip everything but whitespace and alphanumeric' AS [Description], N' |||' AS [FormatCode], N'For Addresses: replace dash with whitespace, then strip everything but whitespace and alphanumeric' AS [Name], N'-|||[^A-Za-z 0-9]' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--UNION ALL SELECT 69 AS [ValueFormatId], 8 AS [ObjectProperyTypeId], N'Replace all Zeros with emptystring' AS [Description], N'' AS [FormatCode], N'Replace all Zeros with emptystring' AS [Name], N'0+' AS [RegexMatch], 0 AS [RankOrder], 1 AS [IsEnabled]
--) AS SOURCE
--ON TARGET.[ValueFormatId] = SOURCE.[ValueFormatId]
--WHEN NOT MATCHED BY TARGET
--THEN
--  INSERT ([ValueFormatId],[ObjectProperyTypeId],[Description],[FormatCode],[Name],[RegexMatch],[RankOrder],[IsEnabled])
--  VALUES (SOURCE.[ValueFormatId],SOURCE.[ObjectProperyTypeId],SOURCE.[Description],SOURCE.[FormatCode],SOURCE.[Name],SOURCE.[RegexMatch],SOURCE.[RankOrder],SOURCE.[IsEnabled])
--WHEN MATCHED
--THEN
--  UPDATE SET TARGET.[ObjectProperyTypeId] = SOURCE.[ObjectProperyTypeId],TARGET.[Description] = SOURCE.[Description],TARGET.[FormatCode] = SOURCE.[FormatCode],TARGET.[Name] = SOURCE.[Name],TARGET.[RegexMatch] = SOURCE.[RegexMatch],TARGET.[RankOrder] = SOURCE.[RankOrder],TARGET.[IsEnabled] = SOURCE.[IsEnabled];
--GO

--DELETE FROM
--  [Polymorph].[DataSourceProperty]
--WHERE
-- [DataSourceId] IN (2, 3)
--GO

--MERGE [dbo].[ReferenceMap] AS TARGET
--USING (
--          SELECT 96 AS [ReferenceMapId], N'Mass of Sun' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Mass of Sun' AS [Description], N'1,988,550,000 X 10^21 kg' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 97 AS [ReferenceMapId], N'Radius of Sun' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Radius of Sun' AS [Description], N'696342 km' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 98 AS [ReferenceMapId], N'Mass of Jupiter' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Mass of Jupiter' AS [Description], N'1,898,600 X 10^21 kg' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 99 AS [ReferenceMapId], N'Radius of Jupiter' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Radius of Jupiter' AS [Description], N'69911 km' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 100 AS [ReferenceMapId], N'Mass of Saturn' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Mass of Saturn' AS [Description], N'568,460 X 10^21 kg' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 101 AS [ReferenceMapId], N'Radius of Saturn' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Radius of Saturn' AS [Description], N'58232 km' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 102 AS [ReferenceMapId], N'Mass of Uranus' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Mass of Uranus' AS [Description], N'86,832 X 10^21 kg' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 103 AS [ReferenceMapId], N'Radius of Uranus' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Radius of Uranus' AS [Description], N'25362 km' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 104 AS [ReferenceMapId], N'Mass of Neptune' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Mass of Neptune' AS [Description], N'102,430 X 10^21 kg' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 105 AS [ReferenceMapId], N'Radius of Neptune' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Radius of Neptune' AS [Description], N'24622 km' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 106 AS [ReferenceMapId], N'Mass of Earth' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Mass of Earth' AS [Description], N'5,973.6 X 10^21 kg' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 107 AS [ReferenceMapId], N'Radius of Earth' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Radius of Earth' AS [Description], N'6371 km' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 108 AS [ReferenceMapId], N'Mass of Venus' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Mass of Venus' AS [Description], N'4,868.5 X 10^21 kg' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 109 AS [ReferenceMapId], N'Radius of Venus' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Radius of Venus' AS [Description], N'6051.8 km' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 110 AS [ReferenceMapId], N'Mass of Mars' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Mass of Mars' AS [Description], N'641.85 X 10^21 kg' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 111 AS [ReferenceMapId], N'Radius of Mars' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Radius of Mars' AS [Description], N'3389.5 km' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 112 AS [ReferenceMapId], N'Mass of Mercury' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Mass of Mercury' AS [Description], N'330.2 X 10^21 kg' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 113 AS [ReferenceMapId], N'Radius of Mercury' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Radius of Mercury' AS [Description], N'2439.7 km' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 114 AS [ReferenceMapId], N'c - Speed of Causality & Light' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'The speed at which all massless particles and changes of the associated fields (including light, a type of electromagnetic radiation, and gravitational waves) travel in vacuum.' AS [Description], N'299792458 km/s' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 115 AS [ReferenceMapId], N'Imputed Income One' AS [RefName], 14 AS [ReferenceMapGroupId], N'VW_CurrentReferenceMapValuesSubscriberIncomeRate' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 1 AS [IsPlanData], N'**Description**' AS [Description], N'1234.56' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 116 AS [ReferenceMapId], N'G - Gravitational constant (Big G)' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 0 AS [IsVisible834Menu], 0 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'According to Newton''s law of universal gravitation, the the attractive force (F) between two point-like bodies is directly proportional to the product of their masses (m1 and m2), and inversely proportional to the square of the distance, r' AS [Description], N'6.673889x10^-11 km^3 * kg^-1 * s^-2' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 117 AS [ReferenceMapId], N'Calculated Value' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 1 AS [IsVisible834Menu], 1 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Calculates a value based on overrides' AS [Description], N'12345.67' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 118 AS [ReferenceMapId], N'e - Natural logarithmic base' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 1 AS [IsVisible834Menu], 1 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'e - Represents the natural logarithmic base.' AS [Description], N'2.7182818284590452354' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--UNION ALL SELECT 119 AS [ReferenceMapId], N'π - Pi' AS [RefName], 4 AS [ReferenceMapGroupId], N'Generated in EDI SSIS' AS [AssociatedViewName], 1 AS [IsVisible834Menu], 1 AS [IsVisibleNon834Menu], 0 AS [IsPlanData], N'Pi or p - Represents the ratio of the circumference of a circle to its diameter.' AS [Description], N'3.14159265358979323846' AS [ReturnValueFormat], N'decimal' AS [ReturnValueType], 0 AS [ReturnValueFormatAttributeValueId], 0 AS [ReturnValueReferenceMapId]
--) AS SOURCE
--ON TARGET.[ReferenceMapId] = SOURCE.[ReferenceMapId]
--WHEN NOT MATCHED BY TARGET
--THEN
--  INSERT ([ReferenceMapId],[RefName],[ReferenceMapGroupId],[AssociatedViewName],[IsVisible834Menu],[IsVisibleNon834Menu],[IsPlanData],[Description],[ReturnValueFormat],[ReturnValueType],[ReturnValueFormatAttributeValueId],[ReturnValueReferenceMapId])
--  VALUES (SOURCE.[ReferenceMapId],SOURCE.[RefName],SOURCE.[ReferenceMapGroupId],SOURCE.[AssociatedViewName],SOURCE.[IsVisible834Menu],SOURCE.[IsVisibleNon834Menu],SOURCE.[IsPlanData],SOURCE.[Description],SOURCE.[ReturnValueFormat],SOURCE.[ReturnValueType],SOURCE.[ReturnValueFormatAttributeValueId],SOURCE.[ReturnValueReferenceMapId])
--WHEN MATCHED
--THEN
--  UPDATE SET TARGET.[RefName] = SOURCE.[RefName],TARGET.[ReferenceMapGroupId] = SOURCE.[ReferenceMapGroupId],TARGET.[AssociatedViewName] = SOURCE.[AssociatedViewName],TARGET.[IsVisible834Menu] = SOURCE.[IsVisible834Menu],TARGET.[IsVisibleNon834Menu] = SOURCE.[IsVisibleNon834Menu],TARGET.[IsPlanData] = SOURCE.[IsPlanData],TARGET.[Description] = SOURCE.[Description],TARGET.[ReturnValueFormat] = SOURCE.[ReturnValueFormat],TARGET.[ReturnValueType] = SOURCE.[ReturnValueType],TARGET.[ReturnValueFormatAttributeValueId] = SOURCE.[ReturnValueFormatAttributeValueId],TARGET.[ReturnValueReferenceMapId] = SOURCE.[ReturnValueReferenceMapId]
--WHEN NOT MATCHED BY SOURCE
--THEN
--  DELETE;
--GO

--/**********************************************************************************************************************/
--/**********************************************************************************************************************/
--/**********************************************************************************************************************/
--/***********************************************Add Your Code Above****************************************************/
--/**************************************** Do Not Modify Below This Point **********************************************/
--/***********************************************Deployment Maintenance*************************************************/
--/**********************************************************************************************************************/

--/**********************************************************************************************************************/
--/******************************* resync the DB schema for the app to know the new schema ******************************/

--EXECUTE [Polymorph].[Proc_SyncSchemaToDatabase]  @RebuildSprocs = 0
--GO
--UPDATE [Polymorph].[ObjectHierarchy]
--SET [IsExcludeWhereClauseSel] = 1
--    ,[IsExcludeWhereClausePrimitiveSel] = 1
--    ,[IsReportChangeTracking] = 0
--WHERE
--  [SchemaName] IN ('EDI', 'SSRS')
--  AND
--  CASE
--    WHEN [IsExcludeWhereClauseSel] = 0
--    THEN 1
--    WHEN [IsExcludeWhereClausePrimitiveSel] = 0
--    THEN 1
--    WHEN [IsReportChangeTracking] = 1
--    THEN 1
--  END = 1
--GO
--GO
--EXECUTE [Polymorph].[Proc_SyncSchemaToDatabase] 
--GO
/**********************************************************************************************************************/
/**********************************************rebuild all table indexs************************************************/
DECLARE @SqlStatment AS NVARCHAR(1024);
DECLARE @StartTime DATETIME2(7) = SYSDATETIME();

DECLARE [SqlStatmentCursor] CURSOR FOR
  SELECT 
    'ALTER TABLE ['+SCHEMA_NAME(uid)+'].[' + [Name] + '] REBUILD WITH (DATA_COMPRESSION = ROW, FILLFACTOR = 90); ALTER TABLE ['+SCHEMA_NAME(uid)+'].[' + [Name] + '] SET (LOCK_ESCALATION = AUTO);' AS [SqlStatement]
  FROM
    sysobjects
  WHERE
    TYPE = 'U' -- all user tables
UNION ALL
  SELECT 
    'ALTER INDEX ALL on ['+SCHEMA_NAME(uid)+'].[' + [Name] + '] REBUILD PARTITION = ALL WITH ( DATA_COMPRESSION = ROW, FILLFACTOR = 90, PAD_INDEX  = ON, MAXDOP = 0, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF, ONLINE = OFF, SORT_IN_TEMPDB = ON );' AS [SqlStatement]
  FROM
    sysobjects
  WHERE
    TYPE = 'U' -- all user tables
ORDER BY SqlStatement DESC

OPEN [SqlStatmentCursor]

FETCH NEXT FROM [SqlStatmentCursor] INTO @SqlStatment
WHILE @@FETCH_STATUS = 0
BEGIN
  SET @StartTime = SYSDATETIME();
  BEGIN TRY
    PRINT('Starting: ' + CONVERT(NVARCHAR(10), DATEDIFF(MILLISECOND,@StartTime, SYSDATETIME())) +' - ' + @SqlStatment)
    EXEC (@SqlStatment)
    PRINT('Success: ' + CONVERT(NVARCHAR(10), DATEDIFF(MILLISECOND,@StartTime, SYSDATETIME())) +' - ' + @SqlStatment)
  END TRY
  BEGIN CATCH
    PRINT('Failure: ' + CONVERT(NVARCHAR(10), DATEDIFF(MILLISECOND,@StartTime, SYSDATETIME())) +' - ' + @SqlStatment)
  END CATCH
 FETCH NEXT FROM [SqlStatmentCursor] INTO @SqlStatment
END

CLOSE SqlStatmentCursor
DEALLOCATE SqlStatmentCursor

--DBCC CHECKDB



