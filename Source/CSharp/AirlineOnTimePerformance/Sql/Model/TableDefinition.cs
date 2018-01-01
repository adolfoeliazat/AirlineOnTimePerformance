namespace AirlineOnTimePerformance.Sql.Model
{
    public class TableDefinition
    {
        public readonly string SchemaName;
        public readonly string TableName;

        public TableDefinition(string tableName)
            : this(string.Empty, tableName)
        {
        }

        public TableDefinition(string schemaName, string tableName)
        {
            SchemaName = schemaName;
            TableName = tableName;
        }

        public string GetFullQualifiedTableName()
        {
            if (string.IsNullOrWhiteSpace(SchemaName))
            {
                return string.Format("[{0}]", TableName);

            }
            return string.Format("[{0}].[{1}]", SchemaName, TableName);
        }
    }
}