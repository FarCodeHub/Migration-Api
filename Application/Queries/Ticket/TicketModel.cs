﻿using Application.Interfaces;
using Application.Queries.TicketItem;
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
        public int? Status { get; set; }
        public bool IsFinished { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public List<TicketItemModel> TicketItems { get; set; }
        public string FullName { get;   set; }
        public string UserName { get; internal set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Ticket, TicketModel>()
      .ForMember(src => src.TicketItems, opt => opt.MapFrom(x => x.TicketItems));

        }

    }
}
