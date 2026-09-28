namespace EshopMicroservices.API.Products.DeleteProduct;

public record DeleteProductResponse(bool IsSuccess);


public class DeleteProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
        {
            var command = new DeleteProductCommand(id);
            var result = await sender.Send(command);
            var response = result.Adapt<DeleteProductResponse>();
            return Results.Ok(response);
        })
        .WithName("DeleteProduct")
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithTags("Products");
    }
}
