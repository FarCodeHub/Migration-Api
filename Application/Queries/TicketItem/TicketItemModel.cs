using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.TicketItem
{
   public class TicketItemModel : IMapFrom<Domain.Entities.TicketItem>
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public bool IsFinished { get; set; }
        public string FullName { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public bool IsAnswer { get; set; }
        public string? Answer { get; set; }
        public DateTime? DateAnswer { get; set; }
        public string UserName { get; internal set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.TicketItem, TicketItemModel>();

        }
    }
}
