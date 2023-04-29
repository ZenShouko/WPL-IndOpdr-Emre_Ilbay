namespace ClassLib.Data.Framework
{
    public static class Settings
    {
        public static string GetConnectionString()
        {
            return
                @"server=HINOKAMI_KAGURA\SQLEXPRESS; " +
                "Database = Pokemon; " +
                "Trusted_Connection = True;";
        }
    }
}
