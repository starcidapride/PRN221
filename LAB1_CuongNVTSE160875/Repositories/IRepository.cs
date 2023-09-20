using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public interface IRepository<T> where T : class
{
    public static abstract bool Update(T entity);

    public static abstract bool Add(T entity);

    public static abstract T? Get(int id);

    public static abstract List<T> GetMany(int pageNumber, int pageSize);

    public static abstract int GetPages(int pageSize);
}
