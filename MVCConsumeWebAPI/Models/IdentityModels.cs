using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using PI_Neoxam_GRH.Domain.Enities;
using System;

namespace MVCConsumeWebAPI.Models
{

    //New drived classes 
    public class UserRoleIntPk : IdentityUserRole<int>
    {
    }

    public class UserClaimIntPk : IdentityUserClaim<int>
    {
    }

    public class UserLoginIntPk : IdentityUserLogin<int>
    {
    }

    public class RoleIntPk : IdentityRole<int, UserRoleIntPk>
    {
        public RoleIntPk() { }
        public RoleIntPk(string name) { Name = name; }
    }

    public class UserStoreIntPk : UserStore<ApplicationUser, RoleIntPk, int,
        UserLoginIntPk, UserRoleIntPk, UserClaimIntPk>
    {
        public UserStoreIntPk(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class RoleStoreIntPk : RoleStore<RoleIntPk, int, UserRoleIntPk>
    {
        public RoleStoreIntPk(ApplicationDbContext context)
            : base(context)
        {
        }
    }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, UserLoginIntPk, UserRoleIntPk, UserClaimIntPk>
    {
        public int jeeUserId { get; set; }
        [StringLength(31)]
        public string role { get; set; }

        [StringLength(255)]
        public string phone_number { get; set; }

        public DateTime registration_date { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        [StringLength(255)]
        public string house_number { get; set; }

        [StringLength(255)]
        public string street { get; set; }

        [StringLength(255)]
        public string city { get; set; }

        [StringLength(255)]
        public string country { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        [StringLength(255)]
        public string zipCode { get; set; }

        [StringLength(255)]
        public string cin { get; set; }

        [StringLength(255)]
        public string first_name { get; set; }

        [StringLength(255)]
        public string last_name { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [Display(Name = "Date de naissance")] //pour changer le nom de la var dans la vue
        [DataType(DataType.Date)]
        public DateTime birthdate { get; set; }






        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            if (this.role != null)
                userIdentity.AddClaim(new Claim("Id", this.Id.ToString()));
            if (this.role!=null)
                userIdentity.AddClaim(new Claim("role", this.role.ToString()));
            if (this.phone_number != null)
                userIdentity.AddClaim(new Claim("phone_number", this.phone_number.ToString()));

                userIdentity.AddClaim(new Claim("registration_date", this.registration_date.ToString()));

            if (this.status != null)
                userIdentity.AddClaim(new Claim("status", this.status.ToString()));
            if (this.cin != null)
                userIdentity.AddClaim(new Claim("cin", this.cin.ToString()));
            if (this.first_name != null)
                userIdentity.AddClaim(new Claim("first_name", this.first_name.ToString()));
            if (this.last_name != null)
                userIdentity.AddClaim(new Claim("last_name", this.last_name.ToString()));
            if (this.picture != null)
                userIdentity.AddClaim(new Claim("picture", this.picture.ToString()));
            if (this.birthdate != null)
                userIdentity.AddClaim(new Claim("birthdate", this.birthdate.ToString()));

            if (this.Email != null)
                userIdentity.AddClaim(new Claim("Email", this.Email.ToString()));
    
                userIdentity.AddClaim(new Claim("jeeUserId", this.jeeUserId.ToString()));

            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, RoleIntPk, int,
        UserLoginIntPk, UserRoleIntPk, UserClaimIntPk>
    {
        public ApplicationDbContext() : base("name=Context")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().Property(u => u.UserName).IsUnicode(false).HasMaxLength(255);
            modelBuilder.Entity<ApplicationUser>().Property(u => u.Email).IsUnicode(false).HasMaxLength(255);
           // modelBuilder.Entity<IdentityRole>().Property(r => r.Name).HasMaxLength(255);
            modelBuilder.Entity<RoleIntPk>().Property(r => r.Name).HasMaxLength(255);


            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<MyUser>().ToTable("AspNetUsers");
            //modelBuilder.Entity<MyUserRole>().ToTable("AspNetUserRoles");
            //modelBuilder.Entity<MyLogin>().ToTable("AspNetUserLogins");
            //modelBuilder.Entity<MyClaim>().ToTable("AspNetUserClaims");
            //modelBuilder.Entity<MyRole>().ToTable("AspNetRoles");


            //var user = modelBuilder.Entity<IdentityUser>().HasKey(u => u.Id).ToTable("user"); //Specify our our own table names instead of the defaults


            //var role = modelBuilder.Entity<IdentityRole>().HasKey(ir => ir.Id).ToTable("ApplicationRole", "Users");

            //role.Property(ir => ir.Id).HasColumnName("Id");
            //role.Property(ir => ir.Name).HasColumnName("Name").HasMaxLength(255);

            //var claim = modelBuilder.Entity<IdentityUserClaim>().HasKey(iuc => iuc.Id).ToTable("UserClaim", "Users");

            //claim.Property(iuc => iuc.Id).HasColumnName("Id");
            //claim.Property(iuc => iuc.ClaimType).HasColumnName("ClaimType");
            //claim.Property(iuc => iuc.ClaimValue).HasColumnName("ClaimValue");
            //claim.Property(iuc => iuc.UserId).HasColumnName("UserId");

            //var login = modelBuilder.Entity<IdentityUserLogin>().HasKey(iul => new { iul.UserId, iul.LoginProvider, iul.ProviderKey }).ToTable("UserLogin", "Users"); //Used for third party OAuth providers

            //login.Property(iul => iul.UserId).HasColumnName("UserId");
            //login.Property(iul => iul.LoginProvider).HasColumnName("LoginProvider");
            //login.Property(iul => iul.ProviderKey).HasColumnName("ProviderKey");

            //var userRole = modelBuilder.Entity<IdentityUserRole>().HasKey(iur => new { iur.UserId, iur.RoleId }).ToTable("UserRole", "Users");

            //userRole.Property(ur => ur.UserId).HasColumnName("UserId");
            //userRole.Property(ur => ur.RoleId).HasColumnName("RoleId");

        }


    }
}