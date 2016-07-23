using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Feature.Llamas
{
    [AllowAnonymous]
    [Route("api/v1/llamas")]
    public class LLamasController : Controller
    {
        public LLamasController(ILlamaRepository llamaItems)
        {
            Llamas = llamaItems;
        }
        public ILlamaRepository Llamas { get; set; }

        [HttpGet]
        public IEnumerable<Llama> GetAll()
        {
            return Llamas.GetAll();
        }
        
        [HttpGet("{id}", Name = "GetLLama")]
        public IActionResult GetById(string id)
        {
            var item = Llamas.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        [SkipValidateModelState]
        public IActionResult Create([FromBody] Llama item)
        {
            // if(!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }

            if (item == null)
            {
                return BadRequest();
            }
            Llamas.Add(item);
            return CreatedAtRoute("GetLLama", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Llama item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var llama = Llamas.Find(id);
            if (llama == null)
            {
                return NotFound();
            }

            Llamas.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Llamas.Remove(id);
        }
    }
}
