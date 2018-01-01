using System;

namespace AirlineOnTimePerformance.Sql.Model
{
    public class FlightStatisticsItem
    {
        /// <summary>
        /// Year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Month
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Day of Month.
        /// </summary>
        public int DayOfMonth { get; set; }

        /// <summary>
        /// Day of Week.
        /// </summary>
        public int DayOfWeekId { get; set; }

        /// <summary>
        /// Flight Date (yyyymmdd)
        /// </summary>
        public DateTime FlightDate { get; set; }

        /// <summary>
        /// Unique Carrier Code. When the same code has been used by multiple carriers, a numeric suffix is 
        /// used for earlier users, for example, PA, PA(1), PA(2). Use this field for analysis across a range 
        /// of years.
        /// </summary>
        public int CarrierId { get; set; }

        /// <summary>
        /// Tail Number.
        /// </summary>
        public string TailNumber { get; set; }

        /// <summary>
        /// Flight Number.
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        /// Origin Airport, Airport ID. An identification number assigned by US DOT to identify a unique airport. Use 
        /// this field for airport analysis across a range of years because an airport can change its airport code 
        /// and airport codes can be reused.
        /// </summary>
        public int? OriginAirportIdentifierId { get; set; }

        /// <summary>
        /// Origin Airport.
        /// </summary>
        public int? OriginAirportId { get; set; }

        /// <summary>
        /// Origin Airport, State Code.
        /// </summary>
        public int? OriginStateId { get; set; }

        /// <summary>
        /// Destination Airport, Airport ID. An identification number assigned by US DOT to identify a unique airport. Use 
        /// this field for airport analysis across a range of years because an airport can change its airport code 
        /// and airport codes can be reused.
        /// </summary>
        public int? DestinationAirportIdentifierId { get; set; }

        /// <summary>
        /// Destination Airport.
        /// </summary>
        public int? DestinationAirportId { get; set; }

        /// <summary>
        /// Destination Airport, State Code.
        /// </summary>
        public int? DestinationStateId { get; set; }

        /// <summary>
        /// CRS Departure Time (local time: hhmm).
        /// </summary>
        public DateTime? ScheduledDepatureTime { get; set; }

        /// <summary>
        /// Actual Departure Time (local time: hhmm).
        /// </summary>
        public DateTime? ActualDepartureTime { get; set; }

        /// <summary>
        /// Difference in minutes between scheduled and actual departure time. Early departures show negative numbers.
        /// </summary>
        public int? DepartureDelay { get; set; }

        /// <summary>
        /// Difference in minutes between scheduled and actual departure time. Early departures set to 0.
        /// </summary>
        public int? DepartureDelayNew { get; set; }

        /// <summary>
        /// Departure Delay Indicator, 15 Minutes or More (1=Yes).
        /// </summary>
        public bool? DepartureDelayIndicator { get; set; }

        /// <summary>
        /// Departure Delay intervals, every (15 minutes from -15 to 180).
        /// </summary>
        public int? DepartureDelayGroupId { get; set; }

        /// <summary>
        /// Taxi Out Time, in Minutes.
        /// </summary>
        public int? TaxiOut { get; set; }

        /// <summary>
        /// Wheels Off Time (local time: hhmm).
        /// </summary>
        public DateTime? WheelsOff { get; set; }

        /// <summary>
        /// Wheels On Time (local time: hhmm).
        /// </summary>
        public DateTime? WheelsOn { get; set; }

        /// <summary>
        /// Taxi In Time, in Minutes.
        /// </summary>
        public int? TaxiIn { get; set; }

        /// <summary>
        /// CRS Arrival Time (local time: hhmm).
        /// </summary>
        public DateTime? ScheduledArrivalTime { get; set; }

        /// <summary>
        /// Actual Arrival Time (local time: hhmm).
        /// </summary>
        public DateTime? ActualArrivalTime { get; set; }

        /// <summary>
        /// Difference in minutes between scheduled and actual arrival time. Early arrivals show negative numbers.
        /// </summary>
        public int? ArrivalDelay { get; set; }

        /// <summary>
        /// Difference in minutes between scheduled and actual arrival time. Early arrivals set to 0.
        /// </summary>
        public int? ArrivalDelayNew { get; set; }

        /// <summary>
        /// Arrival Delay Indicator, 15 Minutes or More (1=Yes).
        /// </summary>
        public bool? ArrivalDelayIndicator { get; set; }

        /// <summary>
        /// Arrival Delay intervals, every (15-minutes from -15 to 180).
        /// </summary>
        public int? ArrivalDelayGroupId { get; set; }

        /// <summary>
        /// Cancelled Flight Indicator (1=Yes).
        /// </summary>
        public bool? CancelledFlight { get; set; }

        /// <summary>
        /// Specifies The Reason For Cancellation.
        /// </summary>
        public int? CancellationCodeId { get; set; }

        /// <summary>
        /// Diverted Flight Indicator (1=Yes).
        /// </summary>
        public bool? DivertedFlight { get; set; }

        /// <summary>
        /// CRS Elapsed Time of Flight, in Minutes.
        /// </summary>
        public int? ScheduledElapsedTimeOfFlight { get; set; }

        /// <summary>
        /// Actual Elapsed Time of Flight, in Minutes.
        /// </summary>
        public int? ActualElapsedTimeOfFlight { get; set; }

        /// <summary>
        /// Flight Time, in Minutes.
        /// </summary>
        public int? AirTime { get; set; }

        /// <summary>
        /// Number of Flights.
        /// </summary>
        public int? NumberOfFlights { get; set; }

        /// <summary>
        /// Distance between airports (miles).
        /// </summary>
        public double? Distance { get; set; }

        /// <summary>
        /// Distance Intervals, every 250 Miles, for Flight Segment.
        /// </summary>
        public int? DistanceGroup { get; set; }

        /// <summary>
        /// Carrier Delay, in Minutes.
        /// </summary>
        public int? CarrierDelay { get; set; }

        /// <summary>
        /// Weather Delay, in Minutes.
        /// </summary>
        public int? WeatherDelay { get; set; }

        /// <summary>
        /// National Air System Delay, in Minutes.
        /// </summary>
        public int? NasDelay { get; set; }

        /// <summary>
        /// Security Delay, in Minutes.
        /// </summary>
        public int? SecurityDelay { get; set; }

        /// <summary>
        /// Late Aircraft Delay, in Minutes.
        /// </summary>
        public int? LateAircraftDelay { get; set; }
    }
}