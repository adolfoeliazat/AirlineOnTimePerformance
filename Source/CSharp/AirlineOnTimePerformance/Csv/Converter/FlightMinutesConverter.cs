// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using TinyCsvParser.TypeConverter;

namespace AirlineOnTimePerformance.Csv.Converter
{
    public class FlightMinutesConverter : ITypeConverter<int?>
    {
        private readonly NullableSingleConverter converter;

        public FlightMinutesConverter()
            : this(new NullableSingleConverter())
        {
        }

        public FlightMinutesConverter(NullableSingleConverter converter)
        {
            this.converter = converter;
        }

        public bool TryConvert(string value, out int? result)
        {
            result = default(int?);

            Single? singleValue;

            if (converter.TryConvert(value, out singleValue))
            {
                // If the Minutes are not given, return immediately:
                if (!singleValue.HasValue)
                {
                    return true;
                }

                // Make sure we are in a valid range for Integer:
                if (singleValue > int.MaxValue)
                {
                    return false;
                }

                if (singleValue < int.MinValue)
                {
                    return false;
                }

                // We can safely assume we can convert the value:
                result = Convert.ToInt32(singleValue);

                return true;
            }

            return false;
        }

        public Type TargetType
        {
            get { return typeof(int?); }
        }
    }
}
