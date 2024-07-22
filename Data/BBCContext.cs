using BBC.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BBC.Api.Data;

//eto nagsasabe like context about db pano sya kontakin
public class BBCContext(DbContextOptions<BBCContext> options) : DbContext(options)
{
    public DbSet<OrderEntity> Orders => Set<OrderEntity>();
    public DbSet<GameEntity> Games => Set<GameEntity>();
    public DbSet<CustomerEntity  > Customers => Set<CustomerEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        // // Configure CustomerEntity relationships
        // modelBuilder.Entity<OrderEntity>()
        //     .HasMany(c => c.GameDetails)
        //     .WithOne(o => o.CustomerDetails)
        //     .HasForeignKey(o => o.CustomerId)
        //     .ExecuteDeleteAsync()
        //     .OnDelete(DeleteBehavior.NoAction);

        // base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<GameEntity>().HasData(
            new{
                Id = 1,
                Title = "Red Dead Redemption 2",
                Genre = "Action",
                Quantity = 1,
                Price = 59.99
            },
            new{
                Id = 2,
                Title = "Stalker",
                Genre = "Fps",
                Quantity = 4,
                Price = 69.69
            },
            new{
                Id = 3,
                Title = "Fear and Hunger",
                Genre = "Survival Horror",
                Quantity = 2,
                Price = 120.25
            },
            new{
                Id = 4,
                Title = "Black Souls",
                Genre = "Rpg",
                Quantity = 5,
                Price = 75.05
            },
            new{
                Id = 5,
                Title = "StarCraft",
                Genre = "Rts",
                Quantity = 3,
                Price = 59.99
            }
        );

        modelBuilder.Entity<CustomerEntity>().HasData(
            new{
                Id = 1,
                Name = "Kyla",
                ContanctNumber = 0901
            },
            new{
                Id = 2,
                Name = "Sean",
                ContanctNumber = 0902
            },
            new{
                Id = 3,
                Name = "Jojo",
                ContanctNumber = 0903
            },
            new{
                Id = 4,
                Name = "Niks",
                ContanctNumber = 0904
            },
            new{
                Id = 5,
                Name = "Mat",
                ContanctNumber = 0905
            }
        );
    }
    
}
