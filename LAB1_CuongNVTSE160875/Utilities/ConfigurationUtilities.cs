
using Microsoft.Extensions.Configuration;

namespace Utilities;
public class ConfigurationUtilites
    {
        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
        }

        public static string? GetConnectionString()
        {
            var config = GetConfiguration();
            return config["ConnectionStrings:DefaultConnectionStringDB"];
        }

        public static bool CheckAdministrator(string email, string password)
        {
            var config = GetConfiguration();
            return config["Administrator:Email"] == email
                && config["Administrator:Password"] == password;
        }
}
