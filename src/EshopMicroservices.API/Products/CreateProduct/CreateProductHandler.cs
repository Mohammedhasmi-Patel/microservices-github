namespace EshopMicroservices.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Categories, string Description, string ImageFile, decimal Price) : ICommand<CreateproductResult>;

public record CreateproductResult(Guid Id);
internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateproductResult>
{
    public async Task<CreateproductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // create new product from the command 
        var product = new Product
        {
            Name = command.Name,
            Categories = command.Categories,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };
        // save to the database 
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        // return the result
        return new CreateproductResult(product.Id);
    }
}
