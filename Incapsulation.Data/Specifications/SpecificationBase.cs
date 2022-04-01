using Incapsulation.Data.Entities;

namespace Incapsulation.Data.Specifications
{
    public abstract class SpecificationBase<TEntity> where TEntity : IEntity
    {
        public bool Ensure(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }

            return CheckSpecification(entity);
        }

        protected abstract bool CheckSpecification(TEntity entity);
    }
}
