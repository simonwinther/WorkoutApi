using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkoutApi.Data;
using WorkoutApi.Models;

namespace WorkoutApi.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly IDataContext _context;
        public ExerciseRepository(IDataContext context)
        {
            _context = context;
        }
        public async Task Add(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _context.Exercises.FindAsync(id);
            if (item is not null)
                throw new NullReferenceException();
            _context.Exercises.Remove(item);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Exercise>> GetAll()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise> GetExercise(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task Update(Exercise exercise)
        {
            var item = await _context.Exercises.FindAsync(exercise.Id);
            if (item is not null)
                throw new NullReferenceException();
            item.Name = exercise.Name;
            item.Description = exercise.Description;
            item.Weight = exercise.Weight;
            item.Reps = exercise.Reps;
            item.Sets = exercise.Sets;
            await _context.SaveChangesAsync();
        }
    }
}