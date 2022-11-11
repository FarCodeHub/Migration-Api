using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Attachment:BaseEntity
    {
       
        public string FileName { get; set; }
        public int UserId { get; set; }
        

        public virtual User User { get; set; }
    }
}
