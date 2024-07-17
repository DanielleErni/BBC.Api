using BBC.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BBC.Api.Data;

//eto nagsasabe like context about db pano sya kontakin
public class BBCContext(DbContextOptions<BBCContext> options) : DbContext(options)
{
    public DbSet<OrderEntity> Order => Set<OrderEntity>();
    public DbSet<GameEntity> Game => Set<GameEntity>();
    public DbSet<CustomerEntity  > Customer => Set<CustomerEntity>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameEntity>().HasData(
            new{
                Id = 1,
                Title = "Red Dead Redemption 2",
                Genre = "Action",
                Price = 59.99
            },
            new{
                Id = 2,
                Title = "Stalker",
                Genre = "Fps",
                Price = 69.69
            },
            new{
                Id = 3,
                Title = "Fear and Hunger",
                Genre = "Survival Horror",
                Price = 120.25
            },
            new{
                Id = 4,
                Title = "Black Souls",
                Genre = "Rpg",
                Price = 75.05
            },
            new{
                Id = 5,
                Title = "StarCraft",
                Genre = "Rts",
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
