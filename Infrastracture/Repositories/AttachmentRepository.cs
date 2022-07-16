using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence;
using Persistence.Repositories;

namespace Infrastracture.Repositories
{
   public class AttachmentRepository : Repository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(MigrationContext context) : base(context)
        {
        }


    }
 
}
