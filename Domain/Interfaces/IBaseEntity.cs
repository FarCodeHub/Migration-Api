namespace  Domain.Interfaces
{
   public interface IBaseEntity
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }


    }
}
