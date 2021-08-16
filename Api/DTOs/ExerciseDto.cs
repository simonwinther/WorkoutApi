namespace WorkoutApi.DTOs
{
    public class ExerciseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
    }
}