using Npgsql;

namespace ConsoleApp2
{
    class connection
    {
        private static NpgsqlConnection? _connection;

       public string GetConnectionString()
        {
            return @"Host=10.30.0.137;Port=5432;Database=gr612_fepol;Username=gr612_fepol;Password=Raz93pimzc";
        }
    }
}