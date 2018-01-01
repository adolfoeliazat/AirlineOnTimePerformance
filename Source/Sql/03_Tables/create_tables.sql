USE $(dbname) 
GO

IF  NOT EXISTS 
    (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'[sample].[Airport]') AND type in (N'U'))
     
BEGIN

    CREATE TABLE [sample].[Airport](
        [AirportID] [NUMERIC](9, 0) IDENTITY(1,1),
        [Code] [NVARCHAR](55) NULL,
        [Description] [NVARCHAR](255) NULL,
        CONSTRAINT [PK_Airport] PRIMARY KEY CLUSTERED 
        (
            [AirportID] ASC
        ),
    ) ON [PRIMARY]

END
GO

IF  NOT EXISTS 
    (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'[sample].[AirportIdentifier]') AND type in (N'U'))
     
BEGIN

    CREATE TABLE [sample].[AirportIdentifier](
        [AirportIdentifierID] [NUMERIC](9, 0) IDENTITY(1,1),
        [Code] [NVARCHAR](55) NULL,
        [Description] [NVARCHAR](255) NULL,
        CONSTRAINT [PK_AirportIdentifier] PRIMARY KEY CLUSTERED 
        (
            [AirportIdentifierID] ASC
        ),
    ) ON [PRIMARY]

END
GO

IF  NOT EXISTS 
    (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'[sample].[Carrier]') AND type in (N'U'))
     
BEGIN

    CREATE TABLE [sample].[Carrier](
        [CarrierID] [NUMERIC](9, 0) IDENTITY(1,1),
        [Code] [NVARCHAR](55) NULL,
        [Description] [NVARCHAR](255) NULL,
        CONSTRAINT [PK_Carrier] PRIMARY KEY CLUSTERED 
        (
            [CarrierID] ASC
        ),
    ) ON [PRIMARY]

END
GO

IF  NOT EXISTS 
    (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'[sample].[CancellationCode]') AND type in (N'U'))
     
BEGIN

    CREATE TABLE [sample].[CancellationCode](
        [CancellationCodeID] [NUMERIC](9, 0) IDENTITY(1,1),
        [Code] [NVARCHAR](55) NULL,
        [Description] [NVARCHAR](255) NULL,
        CONSTRAINT [PK_CancellationCode] PRIMARY KEY CLUSTERED 
        (
            [CancellationCodeID] ASC
        ),
    ) ON [PRIMARY]

END
GO

IF  NOT EXISTS 
    (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'[sample].[DayOfWeek]') AND type in (N'U'))
     
BEGIN

    CREATE TABLE [sample].[DayOfWeek](
        [DayOfWeekID] [NUMERIC](9,0) IDENTITY(1,1),
        [Code] [NVARCHAR](55) NULL,
        [Description] [NVARCHAR](255) NULL,
        CONSTRAINT [PK_DayOfWeek] PRIMARY KEY CLUSTERED 
        (
            [DayOfWeekID] ASC
        ),
    ) ON [PRIMARY]

END
GO

IF  NOT EXISTS 
    (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'[sample].[State]') AND type in (N'U'))
     
BEGIN

    CREATE TABLE [sample].[State](
        [StateID] [NUMERIC](9, 0) IDENTITY(1,1),
        [Code] [NVARCHAR](55) NULL,
        [Description] [NVARCHAR](255) NULL,
        CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
        (
            [StateID] ASC
        ),
    ) ON [PRIMARY]

END
GO

IF  NOT EXISTS 
    (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'[sample].[DelayGroup]') AND type in (N'U'))
     
BEGIN

    CREATE TABLE [sample].[DelayGroup](
        [DelayGroupID] [NUMERIC](9, 0) IDENTITY(1,1),
        [Code] [NVARCHAR](55) NULL,
        [Description] [NVARCHAR](255) NULL,
        CONSTRAINT [PK_DelayGroup] PRIMARY KEY CLUSTERED 
        (
            [DelayGroupID] ASC
        ),
    ) ON [PRIMARY]

END
GO

IF  NOT EXISTS 
    (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'[sample].[FlightStatisticsItem]') AND type in (N'U'))
     
BEGIN

    CREATE TABLE [sample].[FlightStatisticsItem](
        [Year] [NUMERIC](9, 0),
        [Month] [NUMERIC](9, 0),
        [DayOfMonth] [NUMERIC](9, 0),
        [DayOfWeekID] [NUMERIC](9, 0),
        [FlightDate] [DATETIME2],
        [CarrierID] [NUMERIC](9, 0),
        [TailNumber] [NVARCHAR](255),
        [FlightNumber] [NVARCHAR](255),
        [OriginAirportIdentifierID] [NUMERIC](9, 0),
        [OriginAirportID] [NUMERIC](9, 0),
        [OriginStateID] [NUMERIC](9, 0),
        [DestinationAirportIdentifierID] [NUMERIC](9, 0),
        [DestinationAirportID] [NUMERIC](9, 0),
        [DestinationStateID] [NUMERIC](9, 0),
        [ScheduledDepatureTime] [DATETIME2],
        [ActualDepartureTime] [DATETIME2],
        [DepartureDelay] [NUMERIC](9, 0),
        [DepartureDelayNew] [NUMERIC](9, 0),
        [DepartureDelayIndicator] [BIT],
        [DepartureDelayGroupID] [NUMERIC](9, 0),
        [TaxiOut] [NUMERIC](9, 0),
        [WheelsOff] [DATETIME2],
        [WheelsOn] [DATETIME2],
        [TaxiIn] [NUMERIC](9, 0),
        [ScheduledArrivalTime] [DATETIME2],
        [ActualArrivalTime] [DATETIME2],
        [ArrivalDelay] [NUMERIC](9, 0),
        [ArrivalDelayNew] [NUMERIC](9, 0),
        [ArrivalDelayIndicator] [BIT],
        [ArrivalDelayGroupID] [NUMERIC](9, 0),
        [CancelledFlight] [BIT],
        [CancellationCodeID] [NUMERIC](9, 0),
        [DivertedFlight] [BIT] ,
        [ScheduledElapsedTimeOfFlight] [NUMERIC](9, 0),
        [ActualElapsedTimeOfFlight] [NUMERIC](9, 0),
        [AirTime] [NUMERIC](9, 0),
        [NumberOfFlights] [NUMERIC](9, 0),
        [Distance] [FLOAT],
        [DistanceGroup] [NUMERIC](9, 0),
        [CarrierDelay] [NUMERIC](9, 0),
        [WeatherDelay] [NUMERIC](9, 0),
        [NasDelay] [NUMERIC](9, 0),
        [SecurityDelay] [NUMERIC](9, 0),
        [LateAircraftDelay] [NUMERIC](9, 0)
    ) ON [PRIMARY]

END
GO

