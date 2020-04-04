using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickleAndHope.Models;
using PickleAndHope.DataAccess;

namespace PickleAndHope.Controllers
{
    [Route("api/pickles")]
    [ApiController]
    public class PickleController : ControllerBase
    {
        PickleRepository _repository = new PickleRepository();
        [HttpPost] //Attribute//
        public IActionResult AddPickle(Pickle pickleToAdd)
        {
            var existingPickle = _repository.GetByType(pickleToAdd.Type);
            if (existingPickle == null)
            {
                _repository.Add(pickleToAdd);
                return Created("", pickleToAdd);
            }
            else
            {
                _repository.Update(pickleToAdd);
                var updatedPickle = _repository.GetByType(pickleToAdd.Type);
                return Ok(updatedPickle);
            }
        }
    }
}