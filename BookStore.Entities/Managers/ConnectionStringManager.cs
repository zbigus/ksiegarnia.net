namespace BookStore.Entities.Managers
{
    public class ConnectionStringManager
    {
        private static string _current;

        public static string Current
        {
            get
            {
                if (string.IsNullOrEmpty(_current))
                    SetDefaultConnectionString();
                return _current;
            }
        }

        private static void SetDefaultConnectionString()
        {
            SetConnectionString("91.236.74.193", "BookStoreDatabase", "abis", "siba");
        }

        /// <summary>
        ///     Ustawia connection string do bazy z logowaniem zintegrowanym
        /// </summary>
        /// <param name="dataSource">Adres bazy</param>
        /// <param name="dbName">Nazwa bazy</param>
        public static void SetConnectionString(string dataSource, string dbName)
        {
            _current = string.Format(@"Data Source={0};
Initial Catalog={1};
Integrated Security=True;
MultipleActiveResultSets=True", dataSource, dbName);
        }

        /// <summary>
        ///     Ustawia connection string do bazy z podanymi danymi użytkownika
        /// </summary>
        /// <param name="dataSource">Adres bazy</param>
        /// <param name="dbName">Nazwa bazy</param>
        /// <param name="user">Użytkownik w kontekście którego ma nastąpić połączenie</param>
        /// <param name="password">Hasło użytkownika</param>
        public static void SetConnectionString(string dataSource, string dbName, string user, string password)
        {
            _current = string.Format(@"Data Source={0};
Initial Catalog={1};
Integrated Security=False;
User Id={2};
Password={3};
MultipleActiveResultSets=True", dataSource, dbName, user, password);
        }
    }
}