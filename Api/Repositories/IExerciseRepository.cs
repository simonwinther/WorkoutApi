using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutApi.Models;

namespace WorkoutApi.Repositories
{
    public interface IExerciseRepository
    {
        Task<Exercise> GetExercise(int id);
        Task<IEnumerable<Exercise>> GetAll();
        Task Add(Exercise exercise);
        Task Delete(int id);
        Task Update(Exercise exercise);
    }
}