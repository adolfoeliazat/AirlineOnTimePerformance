// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using AirlineOnTimePerformance.Sql.Lookups;

using CsvLookupItemDataType = AirlineOnTimePerformance.Csv.Model.LookupItem;
using SqlLookupItemDataType = AirlineOnTimePerformance.Sql.Model.LookupItem;

using CsvFlightStatisticsItemDataType = AirlineOnTimePerformance.Csv.Model.FlightStatisticsItem;
using SqlFlightStatisticsItemDataType = AirlineOnTimePerformance.Sql.Model.FlightStatisticsItem;

namespace AirlineOnTimePerformance.Converters
{
    public interface IConverter<in TSourceType, out TTargetType>
    {
        TTargetType Convert(TSourceType source);
    }

    public abstract class BaseConverter<TSourceType, TTargetType> : IConverter<TSourceType, TTargetType>
        where TSourceType : class
        where TTargetType : class, new()
    {
        public TTargetType Convert(TSourceType source)
        {
            if (source == null)
            {
                return null;
            }

            TTargetType target = new TTargetType();

            InternalConvert(source, target);

            return target;
        }

        protected abstract void InternalConvert(TSourceType source, TTargetType target);
    }

    public class LookupItemConverter : BaseConverter<CsvLookupItemDataType, SqlLookupItemDataType>
    {
        protected override void InternalConvert(CsvLookupItemDataType source, SqlLookupItemDataType target)
        {
            target.Code = source.Code;
            target.Description = source.Description;
        }
    }

    public class FlightStatisticsItemConverter : BaseConverter<CsvFlightStatisticsItemDataType, SqlFlightStatisticsItemDataType>
    {
        private readonly FlightStatisticLookup lookup;

        public FlightStatisticsItemConverter(FlightStatisticLookup lookup)
        {
            this.lookup = lookup;
        }

        protected override void InternalConvert(CsvFlightStatisticsItemDataType source, SqlFlightStatisticsItemDataType target)
        {
            target.ActualArrivalTime = source.ActualArrivalTime.HasValue ? source.FlightDate.Add(source.ActualArrivalTime.Value) : default(DateTime?);
            target.ActualDepartureTime = source.ActualDepartureTime.HasValue ? source.FlightDate.Add(source.ActualDepartureTime.Value) : default(DateTime?);
            target.ActualElapsedTimeOfFlight = source.ActualElapsedTimeOfFlight;
            target.AirTime = source.AirTime;
            target.ArrivalDelayGroupId = lookup.GetDelayGroupId(source.ArrivalDelayGroup);
            target.ArrivalDelayIndicator = source.ArrivalDelayIndicator;
            target.ArrivalDelay = source.ArrivalDelay;
            target.ArrivalDelayNew = source.ArrivalDelayNew;
            target.CancellationCodeId = lookup.GetCancellationCodeId(source.CancellationCode);
            target.CancelledFlight = source.CancelledFlight;
            target.FlightDate = source.FlightDate;
            target.CarrierDelay = source.CarrierDelay;
            target.DayOfWeekId = lookup.GetDayOfWeekId(source.DayOfWeek);
            target.DayOfMonth = source.DayOfMonth;
            target.OriginAirportId = lookup.GetAirportId(source.Origin);
            target.OriginAirportIdentifierId = lookup.GetAirportIdentifierId(source.OriginAirport);
            target.OriginStateId = lookup.GetStateId(source.OriginState);
            target.DepartureDelayGroupId = lookup.GetDelayGroupId(source.DepartureDelayGroup);
            target.DepartureDelayIndicator = source.DepartureDelayIndicator;
            target.DepartureDelay = source.DepartureDelay;
            target.DepartureDelayNew = source.DepartureDelayNew;
            target.DestinationAirportId = lookup.GetAirportId(source.Destination);
            target.DestinationAirportIdentifierId = lookup.GetAirportIdentifierId(source.DestinationAirport);
            target.DestinationStateId = lookup.GetStateId(source.DestinationState);
            target.NasDelay = source.NasDelay;
            target.TailNumber = source.TailNumber;
            target.WheelsOn = source.WheelsOn.HasValue ? source.FlightDate.Add(source.WheelsOn.Value) : default(DateTime?);
            target.SecurityDelay = source.SecurityDelay;
            target.WheelsOff = source.WheelsOff.HasValue ? source.FlightDate.Add(source.WheelsOff.Value) : default(DateTime?);
            target.FlightNumber = source.FlightNumber;
            target.WeatherDelay = source.WeatherDelay;
            target.NumberOfFlights = source.NumberOfFlights;
            target.ScheduledDepatureTime = source.ScheduledDepatureTime.HasValue ? source.FlightDate.Add(source.ScheduledDepatureTime.Value) : default(DateTime?);
            target.TaxiIn = source.TaxiIn;
            target.Distance = source.Distance;
            target.CarrierId = lookup.GetCarrierId(source.UniqueCarrier);
            target.Month = source.Month;
            target.ScheduledArrivalTime = source.ScheduledArrivalTime.HasValue ? source.FlightDate.Add(source.ScheduledArrivalTime.Value) : default(DateTime?);
            target.LateAircraftDelay = source.LateAircraftDelay;
            target.DistanceGroup = source.DistanceGroup;
            target.ScheduledElapsedTimeOfFlight = source.ScheduledElapsedTimeOfFlight;
            target.DivertedFlight = source.DivertedFlight;
            target.TaxiOut = source.TaxiOut;
            target.Year = source.Year;
        }
    }
}
