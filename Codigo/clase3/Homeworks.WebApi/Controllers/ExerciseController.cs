using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Homeworks.Domain;
using Homeworks.BusinessLogic;

namespace Homeworks.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ExercisesController : ControllerBase, IDisposable
    {
        private ExerciseLogic exerciseLogic;

        public ExercisesController() {
            exerciseLogic = new ExerciseLogic();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(exerciseLogic.GetExercises());
        }

        [HttpGet("{id}", Name = "GetExercise")]
        public IActionResult Get(Guid id)
        {
            Exercise exercise = exerciseLogic.Get(id);
            if (exercise == null) {
                return NotFound();
            }
            return Ok(exercise);
        }

        public void Dispose()
        {
            exerciseLogic.Dispose();
        }

    }
}