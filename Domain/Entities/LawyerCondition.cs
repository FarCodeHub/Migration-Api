namespace Domain.Entities
{
   public class LawyerCondition : BaseEntity
    {
  
        public int LawyerId { get; set; }
        public int ConditionId { get; set; }
        public bool? IsAccepted { get; set; }
        public Lawyer Lawyer { get; set; }
        public Condition Condition { get; set; }
    }
}
