using BBC.Api.Data;

namespace BBC.Api.Endpoint;

public static class CustomerEndpoint
{
    public static RouteGroupBuilder MapCustomerEndpoint(this WebApplication app){
        var CustomerEP = app.MapGroup("Customer");

        CustomerEP.MapGet("/", (BBCContext dbContext)=>{
            return dbContext.Customers;
        });

        return CustomerEP;
    }
}
