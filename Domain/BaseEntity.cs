using Domain.Interfaces;

namespace Domain
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get ; set ; }
        public bool? IsDeleted { get ; set; }
    }
}
