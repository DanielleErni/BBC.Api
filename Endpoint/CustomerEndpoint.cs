using AutoMapper;
using BBC.Api.Data;
using BBC.Api.Dto.CustomerDto;
using BBC.Api.Entities;
using BBC.Api.Mapping;
using Microsoft.EntityFrameworkCore;
using static BBC.Api.Dto.GetOrderDto;

namespace BBC.Api.Endpoint;

public static class CustomerEndpoint
{
    public static RouteGroupBuilder MapCustomerEndpoint(this WebApplication app)
    {
        var CustomerEP = app.MapGroup("Customer");

        // GET ALL
        CustomerEP.MapGet("/", async (BBCContext dbContext, IMapper mapper) =>
        {
            var customers = await dbContext.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.Games)
                .AsNoTracking()
                .ToListAsync();

            var customerDtos = mapper.Map<List<CustomerWithOrdersDto>>(customers);
            return Results.Ok(customerDtos);
        });

        // GET SPECIFIC
        CustomerEP.MapGet("/{id}", async (int id, BBCContext dbContext) =>
        {
            var customerDets = await dbContext.Customers
                .Include(c => c.Orders) //call orders
                .ThenInclude(o => o.Games) //call games inside orders
                .FirstOrDefaultAsync(c => c.Id == id); //find id

            if (customerDets == null)
            {
                return Results.NotFound();
            }

            //use AutoMapper
            //var customerDto = mapper.Map<CustomerWithOrdersDto>(customerDets);

            //to use Manual mapping
            var customerDto = customerDets.ToCustomerWithOrdersDto(); //pass the details into mapper
            return Results.Ok(customerDto);
        });

        // POST
        CustomerEP.MapPost("/", async (BBCContext dbContext, CreateCustomerDto newCustomer, IMapper mapper) =>
        {
            var customerData = mapper.Map<CustomerEntity>(newCustomer);

            await dbContext.Customers.AddAsync(customerData!);
            await dbContext.SaveChangesAsync();
            return Results.Created($"/Customer/{customerData!.Id}", customerData);
        });

        // PUT
        CustomerEP.MapPut("/{id}", async (int id, BBCContext dbContext, UpdateCustomerDto editedCustomer, IMapper mapper) =>
        {
            var customerData = await dbContext.Customers.FindAsync(id);

            if (customerData == null)
            {
                return Results.NotFound();
            }

            mapper.Map(editedCustomer, customerData);

            await dbContext.SaveChangesAsync();
            return Results.Created($"/Customer/{customerData!.Id}", editedCustomer);
        });

        // DELETE
        CustomerEP.MapDelete("/{id}", async (int id, BBCContext dbContext) =>
        {
            await dbContext.Customers.Where(el => el.Id == id).ExecuteDeleteAsync(); // where is basically find

            return Results.Ok("Data has been deleted success");
        });

        return CustomerEP;
    }
}