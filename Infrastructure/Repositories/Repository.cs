using System.Linq.Expressions;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T:class
{
    protected  AppDbContext dbContext { get; set; }

    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public virtual IQueryable<T> FindAll()
    {
        return this.dbContext.Set<T>().AsNoTracking();
    }

    public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return this.dbContext.Set<T>()
            .Where(expression).AsNoTracking();
    }

    public virtual async Task Create(T entity)
    {
        await this.dbContext.Set<T>().AddAsync(entity);
    }

    public virtual void Update(T entity)
    {
        this.dbContext.Set<T>().Update(entity);
    }

    public virtual void Delete(T entity)
    {
        this.dbContext.Set<T>().Remove(entity);
    }

    public virtual void SoftDelete(T entity)
    {
        var tmpEntity = entity as Entity;
        if (tmpEntity != null)
        {
            this.dbContext.Update(tmpEntity);
        }
    }

    public virtual T? FindById(object id)
    {
        return this.dbContext.Set<T>().Find(id);
    }
}