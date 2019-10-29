using System.Collections.Generic;

namespace Library.Repositories
{
    /// <summary>
    /// Basic repository functionality, exposes CRUD-operations.
    /// </summary>
    interface IRepository<T, Tid>
    {
        void Add(T item);
        void Remove(T item);
        T Find(Tid id);
        void Edit(T item);
        IEnumerable<T> All();
    }
}
