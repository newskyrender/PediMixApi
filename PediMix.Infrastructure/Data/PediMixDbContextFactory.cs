using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PediMix.Infrastructure.Data;

namespace PediMix.Infrastructure.Data;

public class PediMixDbContextFactory : IDesignTimeDbContextFactory<PediMixDbContext>
{
    public PediMixDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PediMixDbContext>();
        
        // Connection string para Railway MySQL
        var connectionString = "Server=mainline.proxy.rlwy.net;Port=49986;Database=railway;User=root;Password=jYFqsjMdBZJGWfEMrukyftRgcEYazGKq;SslMode=Required;";
        
        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));
        
        return new PediMixDbContext(optionsBuilder.Options);
    }
}
