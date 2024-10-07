using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraverSalApiProject.DAL.Context;
using TraverSalApiProject.DAL.Entities;

namespace TraverSalApiProject.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult AddVisitor(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                return Ok(visitor);

            }
        }
        [HttpGet("{id}")]
        public IActionResult GetVisitorById(int id) 
        {
            using (var context = new VisitorContext())
            {
                var values=context.Visitors.Find(id);
                if(values == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id) 
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Remove(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor) 
        {
            using (var context = new VisitorContext())
            {
                var values = context.Find<Visitor>(visitor.VisitorId);
                if (values == null) 
                {
                    return NotFound();
                }
                else
                {
                    values.Name= visitor.Name;
                    values.SurName= visitor.SurName;
                    values.City= visitor.City;
                    values.Country= visitor.Country;
                    context.Update(values);
                    context.SaveChanges();
                    return Ok();
                }    
                
            }
        }
    }
}
