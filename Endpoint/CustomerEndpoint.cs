using AutoMapper;
using BBC.Api.Data;
using BBC.Api.Dto.GameDto;
using BBC.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BBC.Api.Endpoint;

public static class CustomerEndpoint
{
    public static RouteGroupBuilder MapCustomerEndpoint(this WebApplication app){
        var CustomerEP = app.MapGroup("Customer");

        //GET ALL
        CustomerEP.MapGet("/", (BBCContext dbContext)=>{
            return dbContext.Customers;
        });

        //GET SPECIFIC
        CustomerEP.MapGet("/{id}", async(int id, BBCContext dbContext)=>{
            var customerDets = await dbContext.Customers
                                                .Include(game => game.Orders)
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(game => game.Id == id);
                                                        
            return Results.Ok(customerDets);
        });

        //POST
        CustomerEP.MapPost("/", async(BBCContext dbContext, CreateGameDto newCustomer,
        IMapper mapper)=>{
            var customerData = mapper.Map<CustomerEntity>(newCustomer);

            await dbContext.Customers.AddAsync(customerData!);
            await dbContext.SaveChangesAsync();
            return Results.Created($"/Customer/{customerData!.Id}", customerData);
        });

        //PUT
        CustomerEP.MapPut("/{id}", async(int id, BBCContext dbContext, UpdateGameDto editedCustomer,
        IMapper mapper)=>{

            var customerData = await dbContext.Customers.FindAsync(id);

            if(customerData == null){
                return Results.NotFound();
            }

            mapper.Map(editedCustomer, customerData);

            await dbContext.SaveChangesAsync();
            return Results.Created($"/Customer/{customerData!.Id}", editedCustomer);
        });

        //DELETE
        CustomerEP.MapDelete("/{id}", async(int id, BBCContext dbContext)=>{
            await dbContext.Customers.Where(el => el.Id == id).ExecuteDeleteAsync(); //where is basically find
                                     
            return Results.Ok("Data has been deleted success");
        });

        return CustomerEP;
    }
}
