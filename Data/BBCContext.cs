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
                ContactNumber = 0901
            },
            new{
                Id = 2,
                Name = "Sean",
                ContactNumber = 0902
            },
            new{
                Id = 3,
                Name = "Jojo",
                ContactNumber = 0903
            },
            new{
                Id = 4,
                Name = "Niks",
                ContactNumber = 0904
            },
            new{
                Id = 5,
                Name = "Mat",
                ContactNumber = 0905
            }
        );
        base.OnModelCreating(modelBuilder);
    }
    
}
