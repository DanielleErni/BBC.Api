using System.Text.RegularExpressions;
using BBC.Api.Dto;

namespace BBC.Api.Endpoint;

public static class BooksEndpoint
{
    private static readonly List<BookSummary> bookSum = 
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


    public static RouteGroupBuilder BookEndpoint(WebApplication app){

        var BookEP = app.MapGroup("Book");

        BookEP.MapGet("/", ()=>{
            return bookSum;
        });

        return BookEP;
    }

}
