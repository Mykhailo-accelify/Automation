namespace API.Services
{
    using API.Interfaces.Services;
    using API.Models;
    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class InstanceService : ICRUDService<Instance>
    {
        private readonly ILogger logger;
        private readonly Context context;
        private readonly IHelperService helperService;
        private readonly IEqualityComparer<Infrastructure> instanceComparer;

        public InstanceService(
            Context context,
            ILogger<InstanceService> logger,
            IHelperService helperService,
            IEqualityComparer<Infrastructure> instanceComparer)
        {
            this.logger = logger;
            this.context = context;
            this.helperService = helperService;
            this.instanceComparer = instanceComparer;
        }

        public async Task<IEnumerable<Instance>> GetAll()
        {
            return await context.Instance
                .ToListAsync();
        }

        public async Task<Instance?> Get(int id)
        {
            return await context.Instance
                .Include(i => i.Infrastructures)
                .Include(i => i.TypeInstance)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Instance?> Create(Instance instance)
        {
            await context.Instance.AddAsync(instance);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return instance;
        }

        public async Task<Instance?> Delete(int id)
        {
            var instance = await context.Instance.SingleOrDefaultAsync(i => i.Id == id);
            if (instance == default)
            {
                logger.LogInformation($"Try delete non exist {nameof(Client)} entity");
                return default;
            }

            context.Instance.Remove(instance);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return instance;
        }

        public async Task<Instance?> Update(Instance item)
        {
            //var existingBlog = context.Blogs
            //    .Include(b => b.Posts)
            //    .FirstOrDefault(b => b.BlogId == blog.BlogId);

            //if (existingBlog == null)
            //{
            //    context.Add(blog);
            //}
            //else
            //{
            //    context.Entry(existingBlog).CurrentValues.SetValues(blog);
            //    foreach (var post in blog.Posts)
            //    {
            //        var existingPost = existingBlog.Posts
            //            .FirstOrDefault(p => p.PostId == post.PostId);

            //        if (existingPost == null)
            //        {
            //            existingBlog.Posts.Add(post);
            //        }
            //        else
            //        {
            //            context.Entry(existingPost).CurrentValues.SetValues(post);
            //        }
            //    }

            //    foreach (var post in existingBlog.Posts)
            //    {
            //        if (!blog.Posts.Any(p => p.PostId == post.PostId))
            //        {
            //            context.Remove(post);
            //        }
            //    }
            //}
            var instance = await Get(item.Id);
            if (instance == default)
            {
                logger.LogInformation($"Try update non exist {nameof(Instance)} entity");
                return default;
            }

            context.Entry(instance).CurrentValues.SetValues(item);

            helperService.UpdateRelationCollection(instance.Infrastructures, item.Infrastructures, instanceComparer);

            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            await context.Entry(instance).Reference(i => i.TypeInstance).LoadAsync();
            return instance;
        }
    }
}
