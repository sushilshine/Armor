using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketSubmission.DataAccess.Entity;
using TicketSubmission.Models;

namespace TicketSubmission.Mapper
{
    public interface ITicketMapper
    {
        void MapToEntityFromUiModel(TicketSubmissionModel uiModel, Ticket ticket);
        void MapToUiModelFromEntity(TicketSubmissionModel uiModel, Ticket ticket);
    }
}