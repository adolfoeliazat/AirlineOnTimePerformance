USE $(dbname)

IF OBJECT_ID(N'[sample].[InsertOrUpdateFlightStatisticsItem]', N'P') IS NOT NULL
BEGIN
    DROP PROCEDURE [sample].[InsertOrUpdateFlightStatisticsItem]
END
GO 

CREATE PROCEDURE [sample].[InsertOrUpdateFlightStatisticsItem]
  @Entities [sample].[FlightStatisticsItemType] ReadOnly
AS
BEGIN
    
    SET NOCOUNT ON;

    INSERT INTO [sample].[FlightStatisticsItem]
    SELECT * FROM @Entities;
    
END
GO

IF OBJECT_ID(N'[sample].[InsertOrUpdateAirport]', N'P') IS NOT NULL
BEGIN
    DROP PROCEDURE [sample].[InsertOrUpdateAirport]
END
GO 

CREATE PROCEDURE [sample].[InsertOrUpdateAirport]
  @Entities [sample].[LookupDataType] ReadOnly
AS
BEGIN
    
    SET NOCOUNT ON;

    MERGE [sample].[Airport] AS TARGET USING @Entities AS SOURCE ON (TARGET.Code = SOURCE.Code) 
    WHEN MATCHED THEN
        UPDATE SET TARGET.Code = SOURCE.Code, TARGET.Description = SOURCE.Description
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (Code, Description)
        VALUES (SOURCE.Code, SOURCE.Description);

END
GO

IF OBJECT_ID(N'[sample].[InsertOrUpdateAirportIdentifier]', N'P') IS NOT NULL
BEGIN
    DROP PROCEDURE [sample].[InsertOrUpdateAirportIdentifier]
END
GO 

CREATE PROCEDURE [sample].[InsertOrUpdateAirportIdentifier]
  @Entities [sample].[LookupDataType] ReadOnly
AS
BEGIN
    
    SET NOCOUNT ON;

    MERGE [sample].[AirportIdentifier] AS TARGET USING @Entities AS SOURCE ON (TARGET.Code = SOURCE.Code) 
    WHEN MATCHED THEN
        UPDATE SET TARGET.Code = SOURCE.Code, TARGET.Description = SOURCE.Description
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (Code, Description)
        VALUES (SOURCE.Code, SOURCE.Description);

END
GO

IF OBJECT_ID(N'[sample].[InsertOrUpdateCancellationCode]', N'P') IS NOT NULL
BEGIN
    DROP PROCEDURE [sample].[InsertOrUpdateCancellationCode]
END
GO 

CREATE PROCEDURE [sample].[InsertOrUpdateCancellationCode]
  @Entities [sample].[LookupDataType] ReadOnly
AS
BEGIN
    
    SET NOCOUNT ON;

    MERGE [sample].[CancellationCode] AS TARGET USING @Entities AS SOURCE ON (TARGET.Code = SOURCE.Code) 
    WHEN MATCHED THEN
        UPDATE SET TARGET.Code = SOURCE.Code, TARGET.Description = SOURCE.Description
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (Code, Description)
        VALUES (SOURCE.Code, SOURCE.Description);

END
GO

IF OBJECT_ID(N'[sample].[InsertOrUpdateCarrier]', N'P') IS NOT NULL
BEGIN
    DROP PROCEDURE [sample].[InsertOrUpdateCarrier]
END
GO 

CREATE PROCEDURE [sample].[InsertOrUpdateCarrier]
  @Entities [sample].[LookupDataType] ReadOnly
AS
BEGIN
    
    SET NOCOUNT ON;

    MERGE [sample].[Carrier] AS TARGET USING @Entities AS SOURCE ON (TARGET.Code = SOURCE.Code) 
    WHEN MATCHED THEN
        UPDATE SET TARGET.Code = SOURCE.Code, TARGET.Description = SOURCE.Description
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (Code, Description)
        VALUES (SOURCE.Code, SOURCE.Description);

END
GO

CREATE PROCEDURE [sample].[InsertOrUpdateDayOfWeek]
  @Entities [sample].[LookupDataType] ReadOnly
AS
BEGIN
    
    SET NOCOUNT ON;

    MERGE [sample].[DayOfWeek] AS TARGET USING @Entities AS SOURCE ON (TARGET.Code = SOURCE.Code) 
    WHEN MATCHED THEN
        UPDATE SET TARGET.Code = SOURCE.Code, TARGET.Description = SOURCE.Description
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (Code, Description)
        VALUES (SOURCE.Code, SOURCE.Description);

END
GO

IF OBJECT_ID(N'[sample].[InsertOrUpdateDelayGroup]', N'P') IS NOT NULL
BEGIN
    DROP PROCEDURE [sample].[InsertOrUpdateDelayGroup]
END
GO 

CREATE PROCEDURE [sample].[InsertOrUpdateDelayGroup]
  @Entities [sample].[LookupDataType] ReadOnly
AS
BEGIN
    
    SET NOCOUNT ON;

    MERGE [sample].[DelayGroup] AS TARGET USING @Entities AS SOURCE ON (TARGET.Code = SOURCE.Code) 
    WHEN MATCHED THEN
        UPDATE SET TARGET.Code = SOURCE.Code, TARGET.Description = SOURCE.Description
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (Code, Description)
        VALUES (SOURCE.Code, SOURCE.Description);

END
GO

IF OBJECT_ID(N'[sample].[InsertOrUpdateState]', N'P') IS NOT NULL
BEGIN
    DROP PROCEDURE [sample].[InsertOrUpdateState]
END
GO 

CREATE PROCEDURE [sample].[InsertOrUpdateState]
  @Entities [sample].[LookupDataType] ReadOnly
AS
BEGIN
    
    SET NOCOUNT ON;

    MERGE [sample].[State] AS TARGET USING @Entities AS SOURCE ON (TARGET.Code = SOURCE.Code) 
    WHEN MATCHED THEN
        UPDATE SET TARGET.Code = SOURCE.Code, TARGET.Description = SOURCE.Description
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (Code, Description)
        VALUES (SOURCE.Code, SOURCE.Description);

END
GO
