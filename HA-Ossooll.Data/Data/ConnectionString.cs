namespace HA_Ossooll.Data.Data
{
    public static class ConnectionString
    {
        public static string TestString =>
            Environment.GetEnvironmentVariable("MYSQL_URL")
            ?? throw new Exception("MYSQL_URL not found");
    }
}