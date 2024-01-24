using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private static List<Event> events = new List<Event>
        {
            new Event{id=1, title="wedding", start=new DateTime()},
            new Event{id=2, title="BirthDate", start=new DateTime()},
            new Event{id=3, title="Party", start=new DateTime()}
        };

        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            foreach (Event ev in events)
            {
                if (ev.id==id)
                {
                    return Ok(ev);
                }
            }

            return NotFound();
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Event value)
        {
            Event newEvent = new Event { id = value.id, title = value.title, end = value.end, start = value.start };
            events.Add(newEvent);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] Event value)
        //{ 
        //    Event update_event = new Event { id = value.id, title = value.title, end = value.end, start = value.start };
        //    foreach (Event event in events)
        //    { 
        //        if (event.id == id)
        //        { 
        //                event.id= value.id;
        //                event.id= value.id;
        //                event.id= value.id;
        //        }
        //    }
        //}
        public IActionResult Put(int id, [FromBody] Event updatedEvent)
        {
            //var existingEvent = events.FirstOrDefault(e => e.id == id);
            foreach (Event item in events)
            {
                if(item.id == id)
                {
                    item.title = updatedEvent.title;
                    item.end = updatedEvent.end;
                    item.start = updatedEvent.start;
                    return Ok(item);
                }  
            }

            return NotFound();
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            foreach (Event item in events)
            {
             if(item.id == id)
                {
                    events.Remove(item);
                    return Ok();
                }
                    
            }
            return NotFound();
        }
    }
}
