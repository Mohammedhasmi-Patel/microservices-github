using MediatR;
namespace EshopMicroservices.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Categories, string Description, string ImageFile, decimal Price) : IRequest<CreateproductResult>;

public record CreateproductResult(Guid Id);
internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateproductResult>
{
    public Task<CreateproductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
