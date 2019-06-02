namespace Vega.Common
{
    public class Constants
    {
        public class ConnectionString {
            public const string Default = "Default";
        }

        public static class Policies {
            public const string RequiresAdminRole = "RequiresAdminRole";
            public const string RequiresManagerRole = "RequiresManagerRole";
        }

        public static class Roles {
            public const string Admin = "Admin";
            public const string Manager = "Manager";
        }

        public static class ClaimTypes {
            public const string VegaRoles = "https://vega.com/roles";
        }
    }
}