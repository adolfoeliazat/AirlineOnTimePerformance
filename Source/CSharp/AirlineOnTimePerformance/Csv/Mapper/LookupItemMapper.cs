﻿// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using AirlineOnTimePerformance.Csv.Model;
using TinyCsvParser.Mapping;

namespace AirlineOnTimePerformance.Csv.Mapper
{
    public class LookupItemMapper : CsvMapping<LookupItem>
    {
        public LookupItemMapper()
        {
            MapProperty(0, x => x.Code);
            MapProperty(1, x => x.Description);
        }
    }
}
