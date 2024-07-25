using BBC.Api.Data;
using BBC.Api.Entities;
using BBC.Api.Mapping;
using Microsoft.EntityFrameworkCore;
using static BBC.Api.Dto.CustomerDto;


namespace BBC.Api.Endpoint;

public static class CustomerEndpoint
{
    public static RouteGroupBuilder MapCustomerEndpoint(this WebApplication app)
    {
        var CustomerEP = app.MapGroup("Customer");

        // GET ALL CUSTOMER ONLY
        CustomerEP.MapGet("/", async (BBCContext dbContext) =>
        {
            var AllCustomers = await dbContext.Customers
                                    .Select(c => c.ToCustomerDetailsDto())
                                    .ToListAsync();

            return Results.Ok(AllCustomers);
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

            //to use Manual mapping
            var customerDto = customerDets.ToCustomerWithOrdersDto(); //pass the details into mapper
            return Results.Ok(customerDto);
        });

        // POST
        CustomerEP.MapPost("/", async (BBCContext dbContext, CreateCustomerDto newCustomer) =>
        {
            // Map CreateCustomerDto to CustomerEntity
            var customerEntity = new CustomerEntity
            {
                Name = newCustomer.Name!,
                ContactNumber = newCustomer.ContactNumber
            };

            // Add the new customer to the database
            await dbContext.Customers.AddAsync(customerEntity);
            await dbContext.SaveChangesAsync();

            // Return the created customer with a 201 Created response
            return Results.Created($"/Customer/{customerEntity.Id}", customerEntity.ToCustomerDetailsDto());
        });

        // // PUT
        CustomerEP.MapPut("/{id}", async (int id, BBCContext dbContext, UpdateCustomerDto editedCustomer) =>
        {
            var customerData = await dbContext.Customers.FindAsync(id);

            if (customerData == null)
            {
                return Results.NotFound("Customer not found");
            }

            customerData.Name = editedCustomer.Name!;
            customerData.ContactNumber = editedCustomer.ContactNumber;
        

            await dbContext.SaveChangesAsync();


            return Results.Created($"/Customer/{customerData!.Id}", customerData.ToCustomerDetailsDto());
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