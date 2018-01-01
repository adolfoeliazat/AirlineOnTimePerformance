USE $(dbname)
GO

IF EXISTS (SELECT * FROM sys.types WHERE is_table_type = 1 AND name = '[sample].[FlightStatisticsItemType]')
BEGIN
    DROP TYPE [sample].[FlightStatisticsItemType]
END

CREATE TYPE [sample].[FlightStatisticsItemType] AS TABLE (
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
);

GO

IF EXISTS (SELECT * FROM sys.types WHERE is_table_type = 1 AND name = '[sample].[LookupDataType]')
BEGIN
    DROP TYPE [sample].[LookupDataType]
END

CREATE TYPE [sample].[LookupDataType] AS TABLE (
    Code NVARCHAR(55) NOT NULL, 
    Description [NVARCHAR](255) NOT NULL
);

GO

