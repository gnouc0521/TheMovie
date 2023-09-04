using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Movie.Authorization.Roles;
using Movie.Authorization.Users;
using Movie.MultiTenancy;
using Movie.Enities;

namespace Movie.EntityFrameworkCore
{
	public class MovieDbContext : AbpZeroDbContext<Tenant, Role, User, MovieDbContext>
	{
		/* Define a DbSet for each entity of the application */
		public DbSet<TheMovie> movie { get; set; }
		public MovieDbContext(DbContextOptions<MovieDbContext> options)
				: base(options)
		{
		}
	}
}
