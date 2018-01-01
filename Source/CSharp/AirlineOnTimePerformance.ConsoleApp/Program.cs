// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using AirlineOnTimePerformance.Converters;
using AirlineOnTimePerformance.Csv.Parser;
using AirlineOnTimePerformance.Sql.Client;
using AirlineOnTimePerformance.Sql.Lookups;
using AirlineOnTimePerformance.Sql.Model;
using TinyCsvParser;

namespace AirlineOnTimePerformance.ConsoleApp
{
    public class Program
    {
        // The ConnectionString used to decide which database to connect to:
        private static readonly string ConnectionString = "Data Source=.;Integrated Security=true;Initial Catalog=LocalWeatherDatabase;";

        public static void Main(string[] args)
        {
            // Import Airport Lookup Data:
            var csvAirportLookupFiles = new[]
            {
                "D:\\datasets\\AOTP\\ZIP\\Lookup Tables\\LookupTables\\OnTimePerformance\\AIRPORT.csv"
            };

            foreach (var csvAirportLookupFile in csvAirportLookupFiles)
            {
                ProcessLookupTable("Airport", csvAirportLookupFile);
            }

            // Import AirportIdentifier Lookup Data:
            var csvAirportIdentifierLookupFiles = new[]
            {
                "D:\\datasets\\AOTP\\ZIP\\Lookup Tables\\LookupTables\\OnTimePerformance\\AIRPORT_ID.csv"
            };

            foreach (var csvAirportIdentifierLookupFile in csvAirportIdentifierLookupFiles)
            {
                ProcessLookupTable("AirportIdentifier", csvAirportIdentifierLookupFile);
            }

            // Import CancellationCode Lookup Data:
            var csvCancellationCodeLookupFiles = new[]
            {
                "D:\\datasets\\AOTP\\ZIP\\Lookup Tables\\LookupTables\\OnTimePerformance\\CANCELLATION.csv"
            };

            foreach (var csvCancellationCodeLookupFile in csvCancellationCodeLookupFiles)
            {
                ProcessLookupTable("CancellationCode", csvCancellationCodeLookupFile);
            }

            // Import Carrier Lookup Data:
            var csvCarrierLookupFiles = new[]
            {
                "D:\\datasets\\AOTP\\ZIP\\Lookup Tables\\LookupTables\\OnTimePerformance\\UNIQUE_CARRIERS.csv"
            };

            foreach (var csvCarrierLookupFile in csvCarrierLookupFiles)
            {
                ProcessLookupTable("Carrier", csvCarrierLookupFile);
            }

            // Import DayOfWeek Lookup Data:
            var csvDayOfWeekLookupFiles = new[]
            {
                "D:\\datasets\\AOTP\\ZIP\\Lookup Tables\\LookupTables\\OnTimePerformance\\WEEKDAYS.csv"
            };

            foreach (var csvDayOfWeekLookupFile in csvDayOfWeekLookupFiles)
            {
                ProcessLookupTable("DayOfWeek", csvDayOfWeekLookupFile);
            }

            // Import DelayGroup Lookup Data:
            var csvDelayGroupLookupFiles = new[]
            {
                "D:\\datasets\\AOTP\\ZIP\\Lookup Tables\\LookupTables\\OnTimePerformance\\L_ONTIME_DELAY_GROUPS.csv"
            };

            foreach (var csvDelayGroupLookupFile in csvDelayGroupLookupFiles)
            {
                ProcessLookupTable("DelayGroup", csvDelayGroupLookupFile);
            }

            // Import State Lookup Data:
            var csvStateLookupFiles = new[]
            {
                "D:\\datasets\\AOTP\\ZIP\\Lookup Tables\\LookupTables\\OnTimePerformance\\STATE_ABR_AVIATION.csv"
            };

            foreach (var csvStateLookupFile in csvStateLookupFiles)
            {
                ProcessLookupTable("State", csvStateLookupFile);
            }

            // Import all hourly weather data from 2014:
            var csvFlightStatisticsFiles = new[]
            {
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201401.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201402.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201403.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201404.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201405.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201406.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201407.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201408.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201409.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201410.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201411.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201412.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201501.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201502.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201503.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201504.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201505.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201506.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201507.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201508.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201509.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201510.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201511.csv",
                "D:\\datasets\\AOTP\\ZIP\\AirOnTimeCSV_1987_2017\\AirOnTimeCSV\\airOT201512.csv",
            };
            
            foreach (var csvFlightStatisticsFile in csvFlightStatisticsFiles)
            {
                ProcessFlightStatisticsItems(csvFlightStatisticsFile);
            }
        }

        private static void ProcessLookupTable(string lookupTable, string csvFilePath)
        {
            // Construct the Batch Processor:
            var processor = new LookupItemBatchProcessor(ConnectionString, new TableDefinition("sample", lookupTable));

            // Create the Converter:
            var converter = new LookupItemConverter();

            // Access to the List of Parsers:
            Parsers
                // Use the LocalWeatherData Parser:
                .LookupParser
                // Read the File:
                .ReadFromFile(csvFilePath, Encoding.UTF8)
                // As an Observable:
                .ToObservable()
                // Batch in 80000 Entities / or wait 1 Second:
                .Buffer(TimeSpan.FromSeconds(1), 80000)

                // And subscribe to the Batch
                .Subscribe(records =>
                {
                    var validRecords = records
                        // Get the Valid Results:
                        .Where(x => x.IsValid)
                        // And get the populated Entities:
                        .Select(x => x.Result)
                        // Group by Code to avoid duplicates for this batch:
                        .GroupBy(x => new { x.Code })
                        // If there are duplicates then make a guess and select the first one:
                        .Select(x => x.First())
                        // Convert into the Sql Data Model:
                        .Select(x => converter.Convert(x))
                        // Evaluate:
                        .ToList();

                    // Finally write them with the Batch Writer:
                    processor.Write(validRecords);
                });
        }


        private static void ProcessFlightStatisticsItems(string csvFilePath)
        {
            // Construct the Batch Processor:
            var processor = new FlightStatisticsItemBatchProcessor(ConnectionString);

            // Create the Lookup Table:
            var lookup = FlightStatisticLookup.Create(ConnectionString);

            // Create the Converter:
            var converter = new FlightStatisticsItemConverter(lookup);

            // Access to the List of Parsers:
            Parsers
                // Use the LocalWeatherData Parser:
                .FlightStatisticsParser
                // Read the File:
                .ReadFromFile(csvFilePath, Encoding.UTF8)
                // As an Observable:
                .ToObservable()
                // Batch in 80000 Entities / or wait 1 Second:
                .Buffer(TimeSpan.FromSeconds(5), 80000)
                // And subscribe to the Batch
                .Subscribe(records =>
                {
                    var validRecords = records
                        // Get the Valid Results:
                        .Where(x => x.IsValid)
                        // And get the populated Entities:
                        .Select(x => x.Result)
                        // Group by WBAN, Date and Time to avoid duplicates for this batch:
                        .GroupBy(x => new { x.UniqueCarrier, x.FlightNumber, x.FlightDate })
                        // If there are duplicates then make a guess and select the first one:
                        .Select(x => x.First())
                        // Convert into the Sql Data Model:
                        .Select(x => converter.Convert(x))
                        // Evaluate:
                        .ToList();

                    // Finally write them with the Batch Writer:
                    processor.Write(validRecords);
                });
        }
    }
}
