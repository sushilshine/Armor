using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketSubmission.DataAccess.Entity;
using TicketSubmission.Models;

namespace TicketSubmission.Mapper
{
    public class TicketMapper : ITicketMapper
    {
        public void MapToEntityFromUiModel(TicketSubmissionModel uiModel, Ticket ticket)
        {
            ticket.Customer = new Customer { LastName = uiModel.LastName, FirstName = uiModel.FirstName, EmailAddress = uiModel.EmailAddress };
            ticket.TicketSubject = uiModel.TicketSubject;
            ticket.TicketDescription = uiModel.TicketDescription;
            ticket.PriorityId = (int)uiModel.PriorityId;
            //ticket.TicketStatus = uiModel.TicketStatus;
            //ticket.DateCaptured = uiModel.DateCaptured;
        }

        public void MapToUiModelFromEntity(TicketSubmissionModel uiModel, Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}