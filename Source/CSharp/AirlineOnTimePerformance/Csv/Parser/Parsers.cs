// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using AirlineOnTimePerformance.Csv.Mapper;
using AirlineOnTimePerformance.Csv.Model;
using TinyCsvParser;

namespace AirlineOnTimePerformance.Csv.Parser
{
    public static class Parsers
    {
        public static CsvParser<FlightStatisticsItem> FlightStatisticsParser
        {
            get
            {
                CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');

                return new CsvParser<FlightStatisticsItem>(csvParserOptions, new FlightStatisticsItemMapper());
            }
        }

        public static CsvParser<LookupItem> LookupParser
        {
            get
            {
                CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');

                return new CsvParser<LookupItem>(csvParserOptions, new LookupItemMapper());
            }
        }
    }
}