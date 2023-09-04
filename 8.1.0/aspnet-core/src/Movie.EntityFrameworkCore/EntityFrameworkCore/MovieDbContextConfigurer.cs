using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Movie.EntityFrameworkCore
{
    public static class MovieDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MovieDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MovieDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
