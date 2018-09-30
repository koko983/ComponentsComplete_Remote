using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ComponentsComplete.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class AppUserLogin : IdentityUserLogin<int>
	{

	}

	public class AppUserRole : IdentityUserRole<int>
	{

	}

	public class AppUserClaim : IdentityUserClaim<int>
	{

	}

	public class AppRole : IdentityRole<int, AppUserRole>
	{

	}


	public class ApplicationUser : IdentityUser<int, AppUserLogin, AppUserRole, AppUserClaim>, IUser<int>
	{
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}
	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
	{
		public ApplicationDbContext()
			: base("DefaultConnection")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			//modelBuilder.Entity<ApplicationUser>().HasKey(t => t.Id);
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}