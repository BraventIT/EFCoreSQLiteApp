using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace EFCoreSQLiteXamFormsApp.Models
{
    public class DataBaseContext: DbContext, IDbContext
    {
        private IDatabaseService DataBaseService => DependencyService.Get<IDatabaseService>();

        DataBaseContext _dbContext;
        DataBaseContext IDbContext.DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new DataBaseContext();
                    _dbContext.Database.EnsureCreated();
                }
                return _dbContext;
            }
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var j = DataBaseService.GetDbPath();
            optionsBuilder.UseSqlite($"Filename={DataBaseService.GetDbPath()}");
        }
    }

}
