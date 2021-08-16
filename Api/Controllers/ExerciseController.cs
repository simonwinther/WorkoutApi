using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkoutApi.Models;
using WorkoutApi.Data;
using WorkoutApi.Repositories;
using WorkoutApi.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "User")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;
        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetAll()
        {
            var exercises = await _exerciseRepository.GetAll();
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> Get(int id)
        {
            var exercise = await _exerciseRepository.GetExercise(id);
            if (exercise is null)
                return NotFound();
            return Ok(exercise);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExerciseDto exerciseDto)
        {
            Exercise exercise = new()
            {
                Name = exerciseDto.Name,
                Description = exerciseDto.Description,
                Weight = exerciseDto.Weight,
                Sets = exerciseDto.Sets,
                Reps = exerciseDto.Reps,
            };
            await _exerciseRepository.Add(exercise);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ExerciseDto exerciseDto)
        {
            Exercise exercise = new()
            {
                Id = id,
                Name = exerciseDto.Name,
                Description = exerciseDto.Description,
                Weight = exerciseDto.Weight,
                Sets = exerciseDto.Sets,
                Reps = exerciseDto.Reps,
            };
            await _exerciseRepository.Update(exercise);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _exerciseRepository.Delete(id);
            return Ok();
        }
    }
}