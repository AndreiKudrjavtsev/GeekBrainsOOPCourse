using Incapsulation.Data.Entities;
using Incapsulation.Data.Specifications;

namespace Incapsulation.Data.Storages
{
    public class DataStorage<TEntity> where TEntity : IEntity
    {
        private Dictionary<int, TEntity> _data = new Dictionary<int, TEntity>();

        // crud - create update read delete

        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public void AddEntity(TEntity entity)
        {
            _data.Add(entity.Id, entity);
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <returns></returns>
        public TEntity? GetById(int id)
        {
            var result = _data.TryGetValue(id, out var entity);
            return result == false
                ? null
                : entity;
        }

        public TEntity[] GetBySpecification(SpecificationBase<TEntity> spec)
        {
            var allEntities = _data.Values.ToArray();
            var result = new List<TEntity>();
            foreach (var entity in allEntities)
            {
                if (spec.Ensure(entity))
                    result.Add(entity);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Update customer
        /// </summary>
        /// <returns></returns>
        public bool UpdateCustomer(int id, TEntity updatedEntity)
        {
            if (_data.TryGetValue(id, out var _))
            {
                _data[id] = updatedEntity;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteCustomer(int id)
        {
            return _data.Remove(id);
        }
    }
}
