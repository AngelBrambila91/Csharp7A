using static System.Console;
namespace Person
{
    public class DvDPlayer : IPlayable
    {
        public void Pause()
        {
            throw new System.NotImplementedException();
        }

        public void Play()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            WriteLine("Default Implementation of Stop()");
        }
    }
}