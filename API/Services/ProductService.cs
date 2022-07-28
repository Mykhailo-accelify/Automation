namespace API.Services
{
    using API.Interfaces.Services;
    using API.Models;
    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ProductService : IProductService
    {
        private readonly ILogger logger;
        private readonly Context context;
        private readonly IHelperService helperService;
        private readonly IEqualityComparer<Client> clientComparer;

        public ProductService(
            Context context,
            ILogger<ProductService> logger,
            IHelperService helperService,
            IEqualityComparer<Client> clientComparer)
        {
            this.logger = logger;
            this.context = context;
            this.helperService = helperService;
            this.clientComparer = clientComparer;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await context.Product
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetNames()
        {
            return await context.Product
                .Select(p => p.Name)
                .ToListAsync();
        }

        public async Task<Product?> Get(int id)
        {
            return await context.Product
                .Include(i => i.Clients)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Product?> Create(Product product)
        {
            await context.Product.AddAsync(product);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return product;
        }

        public async Task<Product?> Delete(int id)
        {
            var product = await context.Product.SingleOrDefaultAsync(i => i.Id == id);
            if (product == default)
            {
                logger.LogInformation($"Try delete non exist {nameof(Product)} entity");
                return default; 
            }

            context.Product.Remove(product);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return product;
        }

        public async Task<Product?> Update(Product item)
        {
            var product = await Get(item.Id);
            if (product == default)
            {
                logger.LogInformation($"Try update non exist {nameof(Product)} entity");
                return default;
            }

            context.Entry(product).CurrentValues.SetValues(item);

            helperService.UpdateRelationCollection(product.Clients, item.Clients, clientComparer);

            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return product;
        }
    }
}
