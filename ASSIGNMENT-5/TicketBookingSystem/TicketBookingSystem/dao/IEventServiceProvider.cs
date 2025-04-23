using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.entity;

namespace TicketBookingSystem.dao
{
    public interface IEventServiceProvider
    {
        void DisplayEvents();
        void CreateEvent(Event eventObj);
        List<Event> GetEventDetails();
        int GetAvailableNoOfTickets(int eventId);
    }
}
