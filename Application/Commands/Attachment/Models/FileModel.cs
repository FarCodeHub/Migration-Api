using Application.Interfaces;
using AutoMapper;

namespace Application.Commands
{
   public class FileModel : IMapFrom<Domain.Entities.Attachment>
   {

       public int Id { get; set; }
       public string FileName { get; set; }
       public int UserId { get; set; }
       


        public void Mapping(Profile profile)
       {
           profile.CreateMap<Domain.Entities.Attachment, FileModel>();
       }
   }
   
}
