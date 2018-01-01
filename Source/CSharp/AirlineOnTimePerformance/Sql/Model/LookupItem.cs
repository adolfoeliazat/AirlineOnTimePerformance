namespace AirlineOnTimePerformance.Sql.Model
{
    /// <summary>
    /// A Lookup Item in the Database.
    /// </summary>
    public class LookupItem
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
