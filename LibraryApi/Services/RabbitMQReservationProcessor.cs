using LibraryApi.Domain;
using RabbitMqUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class RabbitMQReservationProcessor : IWriteToTheMessageQueue
    {
        IRabbitManager Manager;

        public RabbitMQReservationProcessor(IRabbitManager manager)
        {
            Manager = manager;
        }

        public async Task Write(Reservation reservation)
        {
            Manager
                .Publish(
                    reservation, 
                    "", 
                    "direct", 
                    "reservations");
        }
    }
}
