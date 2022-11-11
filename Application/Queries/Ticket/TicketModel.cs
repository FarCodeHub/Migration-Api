using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Ticket
{
   public class TicketModel : IMapFrom<Domain.Entities.Ticket>
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public List<TicketItemModel> TicketItems { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Ticket, TicketModel>()
      .ForMember(src => src.TicketItems, opt => opt.MapFrom(x => x.TicketItems));

        }

    }

    public class TicketItemModel : IMapFrom<TicketItem>
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public short Status { get; set; }
        public bool IsAnswer { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TicketItem, TicketItemModel>();
     

        }
    }

}
