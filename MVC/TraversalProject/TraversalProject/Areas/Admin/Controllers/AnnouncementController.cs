using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalProject.Areas.Admin.Models;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AnnouncementController : Controller
    {
        IAnnouncementService _announcementService;
        IMapper _mapper;
        public AnnouncementController(IAnnouncementService announcementService,IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.GetList());  
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.Add(new Announcement()
                {
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return Redirect("/Admin/Announcement/Index");


            }
            return View();
        }
     
        public IActionResult DeleteAnnouncement(int id) 
        {
            var values=_announcementService.GetByID(id);
            _announcementService.Delete(values);
            return Redirect("/Admin/Announcement/Index");
        }
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.GetByID(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.Update(new Announcement
                {
                    AnnouncementId = model.AnnouncementId,
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return Redirect("/Admin/Announcement/Index");
            }
            return View(model);
        }
    }
}
