using HrManagementSystem.Common.Data;
using HrManagementSystem.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace HrManagementSystem.Common.Repositories
{

    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : BaseModel
    {
        protected readonly AppDbContext _dbContext;
        DbSet<Entity> _dbSet;
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Entity>();
        }

        // --------------------- Add ---------------------

        public async Task AddAsync(Entity entity, string currentUserId , CancellationToken cancellationToken)
        {
            entity.CreatedByUser = currentUserId;
            entity.CreatedAt = DateTime.UtcNow;

            await _dbSet.AddAsync(entity , cancellationToken);
        }

        public async Task AddAsync(Entity entity , CancellationToken cancellationToken)
        {
            entity.CreatedAt = DateTime.UtcNow;

            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<Entity> entities , CancellationToken cancellationToken)
        {
            await _dbSet.AddRangeAsync(entities , cancellationToken);
        }

        // --------------------- Delete ---------------------

        public async Task DeleteFromAsync(Expression<Func<Entity, bool>> expression, string currentUserId, CancellationToken cancellationToken)
        {
            await Get(expression)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => e.IsDeleted, true)
                    .SetProperty(e => e.IsActive, false)
                    .SetProperty(e => e.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(e => e.UpdatedByUser, currentUserId), cancellationToken);
        }

        public async Task DeleteAsync(string id, string currentUserId, CancellationToken cancellationToken)
        {
            await Get(e => e.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => e.IsDeleted, true)
                    .SetProperty(e => e.IsActive, false)
                    .SetProperty(e => e.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(e => e.UpdatedByUser, currentUserId), cancellationToken);
        }



        // --------------------- Get All ---------------------

        public IQueryable<Entity> GetAll()
        {
            var query = _dbSet
             .AsNoTracking()
             .Where(e => !e.IsDeleted && e.IsActive);

            return query;
        }

        public IQueryable<Entity> Get(Expression<Func<Entity, bool>> expression)
        {
            var filteredQuery = GetAll().Where(expression);
            return filteredQuery;
        }

        // --------------------- Get by ID ---------------------

        public async Task<Entity?> GetByIDAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);

            return entity;
        }


        // --------------------- Update ---------------------

        public void Update(Entity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
           _dbSet.Update(entity);
        }

        public void Update(Entity entity, string currentUserId)
        {
            entity.UpdatedByUser = currentUserId;
            entity.UpdatedAt = DateTime.Now;
            _dbSet.Update(entity);
        }

        // --------------------- Reflection Update (Specific Properties) ---------------------
        public async Task UpdateIncludeAsync(Entity entity, string currentUserId, CancellationToken cancellationToken, params string[] modifiedParams)
        {
            var local = _dbSet.Local.FirstOrDefault(x => x.Id == entity.Id);
            if (local == null)
                _dbSet.Attach(entity);

            var entry = _dbContext.Entry(entity);

            foreach (var prop in entry.Properties)
            {
                if (modifiedParams.Contains(prop.Metadata.Name))
                {
                    var newValue = entity.GetType().GetProperty(prop.Metadata.Name)?.GetValue(entity);
                    prop.CurrentValue = newValue;
                    prop.IsModified = true;
                }
            }

            entity.UpdatedAt = DateTime.UtcNow;
            entity.UpdatedByUser = currentUserId;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        //_______________ Entity exists ______________________
        public async Task<bool> IsExistsAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

    }

}
