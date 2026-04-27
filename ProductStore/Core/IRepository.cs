using System.Collections.Generic;

namespace ProductStore.Core;

public interface IRepository<T> where T : class
{
    void Add(T name);
    void Delete(int id);
    void Update(T name);
    List<T> GetAll();
}