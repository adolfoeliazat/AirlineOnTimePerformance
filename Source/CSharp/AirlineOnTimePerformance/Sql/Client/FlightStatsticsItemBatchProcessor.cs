// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AirlineOnTimePerformance.Sql.Extensions;
using AirlineOnTimePerformance.Sql.Model;
using Microsoft.SqlServer.Server;

namespace AirlineOnTimePerformance.Sql.Client
{
    public class FlightStatisticsItemBatchProcessor : IBatchProcessor<FlightStatisticsItem>
    {
        private readonly string connectionString;

        public FlightStatisticsItemBatchProcessor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Write(IList<FlightStatisticsItem> items)
        {
            if (items == null)
            {
                return;
            }

            if (items.Count == 0)
            {
                return;
            }
            
            using (var connection = new SqlConnection(connectionString))
            {
                // Open the Connection:
                connection.Open();

                // Execute the Batch Write Command:
                using (IDbCommand cmd = connection.CreateCommand())
                {
                    // Build the Stored Procedure Command:
                    cmd.CommandText = "[sample].[InsertOrUpdateFlightStatisticsItem]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Create the TVP:
                    SqlParameter parameter = new SqlParameter();

                    parameter.ParameterName = "@Entities";
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "[sample].[FlightStatisticsItemType]";
                    parameter.Value = ToSqlDataRecords(items);

                    // Add it as a Parameter:
                    cmd.Parameters.Add(parameter);

                    // And execute it:
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private IEnumerable<SqlDataRecord> ToSqlDataRecords(IEnumerable<FlightStatisticsItem> items)
        {
            // Construct the Data Record with the MetaData:
            SqlDataRecord sdr = new SqlDataRecord(
                new SqlMetaData("Year", SqlDbType.Int),
                new SqlMetaData("Month", SqlDbType.Int),
                new SqlMetaData("DayOfMonth", SqlDbType.Int),
                new SqlMetaData("DayOfWeekID", SqlDbType.Int),
                new SqlMetaData("FlightDate", SqlDbType.DateTime2),
                new SqlMetaData("CarrierID", SqlDbType.Int),
                new SqlMetaData("TailNumber", SqlDbType.NVarChar, 55),
                new SqlMetaData("FlightNumber", SqlDbType.NVarChar, 55),
                new SqlMetaData("OriginAirportIdentifierID", SqlDbType.Int),
                new SqlMetaData("OriginAirportID", SqlDbType.Int),
                new SqlMetaData("OriginStateID", SqlDbType.Int),
                new SqlMetaData("DestinationAirportIdentifierID", SqlDbType.Int),
                new SqlMetaData("DestinationAirportID", SqlDbType.Int),
                new SqlMetaData("DestinationStateID", SqlDbType.Int),
                new SqlMetaData("ScheduledDepatureTime", SqlDbType.DateTime2),
                new SqlMetaData("ActualDepartureTime", SqlDbType.DateTime2),
                new SqlMetaData("DepartureDelay", SqlDbType.Int),
                new SqlMetaData("DepartureDelayNew", SqlDbType.Int),
                new SqlMetaData("DepartureDelayIndicator", SqlDbType.Bit),
                new SqlMetaData("DepartureDelayGroupID", SqlDbType.Int),
                new SqlMetaData("TaxiOut", SqlDbType.Int),
                new SqlMetaData("WheelsOff", SqlDbType.DateTime2),
                new SqlMetaData("WheelsOn", SqlDbType.DateTime2),
                new SqlMetaData("TaxiIn", SqlDbType.Int),
                new SqlMetaData("ScheduledArrivalTime", SqlDbType.DateTime2),
                new SqlMetaData("ActualArrivalTime", SqlDbType.DateTime2),
                new SqlMetaData("ArrivalDelay", SqlDbType.Int),
                new SqlMetaData("ArrivalDelayNew", SqlDbType.Int),
                new SqlMetaData("ArrivalDelayIndicator", SqlDbType.Bit),
                new SqlMetaData("ArrivalDelayGroupID", SqlDbType.Int),
                new SqlMetaData("CancelledFlight", SqlDbType.Bit),
                new SqlMetaData("CancellationCodeID", SqlDbType.Int),
                new SqlMetaData("DivertedFlight", SqlDbType.Bit),
                new SqlMetaData("ScheduledElapsedTimeOfFlight", SqlDbType.Int),
                new SqlMetaData("ActualElapsedTimeOfFlight", SqlDbType.Int),
                new SqlMetaData("AirTime", SqlDbType.Int),
                new SqlMetaData("NumberOfFlights", SqlDbType.Int),
                new SqlMetaData("Distance", SqlDbType.Float),
                new SqlMetaData("DistanceGroup", SqlDbType.Int),
                new SqlMetaData("CarrierDelay", SqlDbType.Int),
                new SqlMetaData("WeatherDelay", SqlDbType.Int),
                new SqlMetaData("NasDelay", SqlDbType.Int),
                new SqlMetaData("SecurityDelay", SqlDbType.Int),
                new SqlMetaData("LateAircraftDelay", SqlDbType.Int)
            );

            // Now yield the Measurements in the Data Record:
            foreach (var item in items)
            {
                sdr.SetInt32(0, item.Year);
                sdr.SetInt32(1, item.Month);
                sdr.SetInt32(2, item.DayOfMonth);
                sdr.SetInt32(3, item.DayOfWeekId);
                sdr.SetDateTime(4, item.FlightDate);
                sdr.SetInt32(5, item.CarrierId);
                sdr.SetString(6, item.TailNumber);
                sdr.SetString(7, item.FlightNumber);
                sdr.SetNullableInt32(8, item.OriginAirportIdentifierId);
                sdr.SetNullableInt32(9, item.OriginAirportId);
                sdr.SetNullableInt32(10, item.OriginStateId);
                sdr.SetNullableInt32(11, item.DestinationAirportIdentifierId);
                sdr.SetNullableInt32(12, item.DestinationAirportId);
                sdr.SetNullableInt32(13, item.DestinationStateId);
                sdr.SetNullableDateTime(14, item.ScheduledDepatureTime);
                sdr.SetNullableDateTime(15, item.ActualDepartureTime);
                sdr.SetNullableInt32(16, item.DepartureDelay);
                sdr.SetNullableInt32(17, item.DepartureDelayNew);
                sdr.SetNullableBoolean(18, item.DepartureDelayIndicator);
                sdr.SetNullableInt32(19, item.DepartureDelayGroupId);
                sdr.SetNullableInt32(20, item.TaxiOut);
                sdr.SetNullableDateTime(21, item.WheelsOff);
                sdr.SetNullableDateTime(22, item.WheelsOn);
                sdr.SetNullableInt32(23, item.TaxiIn);
                sdr.SetNullableDateTime(24, item.ScheduledArrivalTime);
                sdr.SetNullableDateTime(25, item.ActualArrivalTime);
                sdr.SetNullableInt32(26, item.ArrivalDelay);
                sdr.SetNullableInt32(27, item.ArrivalDelayNew);
                sdr.SetNullableBoolean(28, item.ArrivalDelayIndicator);
                sdr.SetNullableInt32(29, item.ArrivalDelayGroupId);
                sdr.SetNullableBoolean(30, item.CancelledFlight);
                sdr.SetNullableInt32(31, item.CancellationCodeId);
                sdr.SetNullableBoolean(32, item.DivertedFlight);
                sdr.SetNullableInt32(33, item.ScheduledElapsedTimeOfFlight);
                sdr.SetNullableInt32(34, item.ActualElapsedTimeOfFlight);
                sdr.SetNullableInt32(35, item.AirTime);
                sdr.SetNullableInt32(36, item.NumberOfFlights);
                sdr.SetNullableDouble(37, item.Distance);
                sdr.SetNullableInt32(38, item.DistanceGroup);
                sdr.SetNullableInt32(39, item.CarrierDelay);
                sdr.SetNullableInt32(40, item.WeatherDelay);
                sdr.SetNullableInt32(41, item.NasDelay);
                sdr.SetNullableInt32(42, item.SecurityDelay);
                sdr.SetNullableInt32(43, item.LateAircraftDelay);

                yield return sdr;
            }
        }
    }
}