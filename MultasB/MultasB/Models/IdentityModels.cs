using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MultasB.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
  
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    /// <summary>
    /// apresenta a criação da base de dados
    /// -dos utilizdores
    /// -dos dados do 'negócio'
    /// </summary>
    public class MultasDB : IdentityDbContext<ApplicationUser>
    {
        public MultasDB()
            : base("MultasDBConnectionString", throwIfV1Schema: false)
        {
        }

        static MultasDB()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<MultasDB>(new ApplicationDbInitializer());
        }

        public static MultasDB Create()
        {
            return new MultasDB();
        }

        // adicionar aqui as tabelas da BD

        // Definir as tabelas da DB

        public DbSet<Condutores> Condutores { get; set; }
        public DbSet<Agentes> Agentes { get; set; }
        public DbSet<Viaturas> Viaturas { get; set; }
        public DbSet<Multas> Multas { get; set; }


        // Método a ser executado no inicio da criação do modelo
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Eliminar a convenção de atribuir automaticamente o 'onDeleteCascade' nas FKs
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }




    }
}