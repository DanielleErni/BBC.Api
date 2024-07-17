
using BBC.Api.Dto;

namespace BBC.Api.Endpoint;

public static class BooksEndpoint
{
    private static readonly List<BookSummaryDto> MemaOrderDb = 
    [
        new(
            1,
            2,
            1,
            2
        ),
        new(
            2,
            1,
            2,
            3
        ),
        new(
            3,
            3,
            2,
            1
        )
    ];


    public static RouteGroupBuilder MapOrderEndpoint(this WebApplication app){

        var OrderEP = app.MapGroup("Order");

        OrderEP.MapGet("/", ()=>{
            return MemaOrderDb;
        });
        
        OrderEP.MapGet("/{id}", (int id) =>{
            var existingBook = MemaOrderDb.Find(el => el.Id == id);

            if(existingBook == null){
                return Results.NotFound();
            }

            return Results.Ok(existingBook);
        });



        return OrderEP;
    }

}
