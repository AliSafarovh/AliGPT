using DataAccessLayer.Concrete;
using TraversalProject.CQRS.Commands.DestinationCommand;

namespace TraversalProject.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;
        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var values=_context.Destinations.Find(command.DestinationId);
            values.City=command.City;
            values.DayNight = command.dayNight;
            values.Price=command.Price;
            _context.SaveChanges();
        }
    }
}
