namespace Space_Defender.Utility
{
    public interface IFpsHandler
    {
        void FpsChanged(int fps);
    }

    public class Fps
    {
        private static IFpsHandler _fpsHandler;
        private static double _timer;
        private static int _frames;

        public static void AttachTo(IFpsHandler fpsHandler)
        {
            _fpsHandler = fpsHandler;
            _timer = 0;
            _frames = 0;
        }

        public static void Update(double delta)
        {
            _timer += delta;
            _frames++;
            if (!(_timer >= 1000.0))
                return;
            _timer = 1000.0 - _timer;
            _fpsHandler.FpsChanged(_frames);
            _frames = 0;
        }
    }
}
