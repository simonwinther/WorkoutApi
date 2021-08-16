namespace WorkoutApi.Util
{
    public interface IPasswordHandler
    {
        string Hash(string password);

        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}