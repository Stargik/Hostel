using System;
namespace HostelDAL.Interfaces
{
	public interface IRepository<T>
	{
		void Create(T entity);
		void Update(T entity);
        void Delete(T entity);
        void DeleteById(Guid id);
		IEnumerable<T> GetAll();
		T? GetById(Guid id);

	}
}

