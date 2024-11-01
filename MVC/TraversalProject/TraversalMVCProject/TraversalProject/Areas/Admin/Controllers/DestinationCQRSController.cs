using Microsoft.AspNetCore.Mvc;
using TraversalProject.CQRS.Commands.DestinationCommand;
using TraversalProject.CQRS.Handlers.DestinationHandlers;
using TraversalProject.CQRS.Queries.DestinationQueries;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;  
        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, RemoveDestinationCommandHandler removeDestinationCommandHandler = null)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _removeDestinationCommandHandler = removeDestinationCommandHandler;
        }
        public IActionResult Index()
        {
            var values = _getAllDestinationQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult GetDestination(int id)
        {

            var values = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
            
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetDestination(UpdateDestinationCommand command)
        {
            _updateDestinationCommandHandler.Handle(command);
            return Redirect("/Admin/Destination/Index");
        }

        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand command)
        {
           _createDestinationCommandHandler.Handle(command);
            return Redirect("/Admin/Destination/Index");
        }

        public IActionResult DeleteDestination(int id) 
        {
            _removeDestinationCommandHandler.Handle(new RemoveDestinationCommand(id));
            return Redirect("/Admin/Destination/Index");
        }

    }
}
