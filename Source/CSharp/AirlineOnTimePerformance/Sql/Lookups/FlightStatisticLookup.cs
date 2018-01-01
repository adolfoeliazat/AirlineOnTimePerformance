using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AirlineOnTimePerformance.Sql.Model;
using Dapper;

namespace AirlineOnTimePerformance.Sql.Lookups
{
    public class FlightStatisticLookup
    {
        private readonly IDictionary<string, int> airportLookup;
        private readonly IDictionary<string, int> airportIdentifierLookup;
        private readonly IDictionary<string, int> stateLookup;
        private readonly IDictionary<string, int> dayOfWeekLookup;
        private readonly IDictionary<string, int> cancellationCodeLookup;
        private readonly IDictionary<string, int> carrierLookup;
        private readonly IDictionary<string, int> delayGroupLookup;

        public FlightStatisticLookup(IDictionary<string, int> airportLookup, IDictionary<string, int> airportIdentifierLookup, IDictionary<string, int> stateLookup, IDictionary<string, int> dayOfWeekLookup, IDictionary<string, int> cancellationCodeLookup, IDictionary<string, int> carrierLookup, IDictionary<string, int> delayGroupLookup)
        {
            this.airportLookup = airportLookup;
            this.airportIdentifierLookup = airportIdentifierLookup;
            this.stateLookup = stateLookup;
            this.dayOfWeekLookup = dayOfWeekLookup;
            this.cancellationCodeLookup = cancellationCodeLookup;
            this.carrierLookup = carrierLookup;
            this.delayGroupLookup = delayGroupLookup;
        }

        public int? GetAirportId(string code)
        {
            if (!airportLookup.ContainsKey(code))
            {
                return default(int?);
            }

            return airportLookup[code];
        }

        public int? GetAirportIdentifierId(string code)
        {
            if (!airportIdentifierLookup.ContainsKey(code))
            {
                return default(int?);
            }

            return airportIdentifierLookup[code];
        }

        public int? GetStateId(string code)
        {
            return stateLookup[code];
    }

        public int GetDayOfWeekId(string code)
        {
            return dayOfWeekLookup[code];
        }

        public int? GetCancellationCodeId(string code)
        {
            if (!cancellationCodeLookup.ContainsKey(code))
            {
                return default(int?);
            }

            return cancellationCodeLookup[code];
        }

        public int GetCarrierId(string code)
        {
            return carrierLookup[code];
        }

        public int? GetDelayGroupId(string code)
        {
            if (!delayGroupLookup.ContainsKey(code))
            {
                return default(int?);
            }

            return delayGroupLookup[code];
        }

        public static FlightStatisticLookup Create(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return new FlightStatisticLookup(
                    GetLookupTable(connection, new TableDefinition("sample", "Airport")),
                    GetLookupTable(connection, new TableDefinition("sample", "AirportIdentifier")),
                    GetLookupTable(connection, new TableDefinition("sample", "State")),
                    GetLookupTable(connection, new TableDefinition("sample", "DayOfWeek")),
                    GetLookupTable(connection, new TableDefinition("sample", "CancellationCode")),
                    GetLookupTable(connection, new TableDefinition("sample", "Carrier")),
                    GetLookupTable(connection, new TableDefinition("sample", "DelayGroup")));
            }
        }

        private static IDictionary<string, int> GetLookupTable(SqlConnection connection, TableDefinition table)
        {
            // Build the Query:
            var lookupQuery = string.Format("SELECT {0}ID as Id, Code, Description FROM {1}", table.TableName, table.GetFullQualifiedTableName());

            // Get all Lookup Items:
            var lookupItems = connection.Query<LookupItem>(lookupQuery).ToList();

            // Finally build the Dictionary for faster Lookups:
            return lookupItems.ToDictionary(x => x.Code, x => x.Id);
        }
    }
}