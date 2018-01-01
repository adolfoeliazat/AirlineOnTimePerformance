// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AirlineOnTimePerformance.Sql.Model;
using Microsoft.SqlServer.Server;

namespace AirlineOnTimePerformance.Sql.Client
{
    public class LookupItemBatchProcessor : IBatchProcessor<LookupItem>
    {
        private readonly string connectionString;
        private readonly TableDefinition lookupTable;

        public LookupItemBatchProcessor(string connectionString, TableDefinition lookupTable)
        {
            this.connectionString = connectionString;
            this.lookupTable = lookupTable;
        }

        public void Write(IList<LookupItem> items)
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
                    cmd.CommandText = string.Format("[sample].[InsertOrUpdate{0}]", lookupTable.TableName);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Create the TVP:
                    SqlParameter parameter = new SqlParameter();

                    parameter.ParameterName = "@Entities";
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "[sample].[LookupDataType]";
                    parameter.Value = ToSqlDataRecords(items);

                    // Add it as a Parameter:
                    cmd.Parameters.Add(parameter);

                    // And execute it:
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private IEnumerable<SqlDataRecord> ToSqlDataRecords(IEnumerable<LookupItem> items)
        {
            // Construct the Data Record with the MetaData:
            SqlDataRecord sdr = new SqlDataRecord(
                new SqlMetaData("Code", SqlDbType.NVarChar, 55),
                new SqlMetaData("Description", SqlDbType.NVarChar, 255)
            );

            // Now yield the Measurements in the Data Record:
            foreach (var item in items)
            {
                sdr.SetString(0, item.Code);
                sdr.SetString(1, item.Description);

                yield return sdr;
            }
        }
    }
}