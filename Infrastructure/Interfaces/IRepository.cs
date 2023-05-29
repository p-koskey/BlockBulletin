using System.Linq.Expressions;

namespace Infrastructure.Interfaces;

public interface IRepository<T> where T: class
{
    IQueryable<T> FindAll();

    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    T? FindById(object id);

    Task Create(T entity);

    void Update(T entity);

    void Delete(T entity);

    void SoftDelete(T entity);
}