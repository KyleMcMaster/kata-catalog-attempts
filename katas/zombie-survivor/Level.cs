namespace Kata.Starter
{
    public class Level
    {
        public string Code { get; }
        public int MinimumExperience { get; }

        protected Level(string code, int minimumExperience)
        {
            Code = code;
            MinimumExperience = minimumExperience;
        }

        public static Level BLUE => new Level(nameof(BLUE), 0);
        public static Level YELLOW => new Level(nameof(YELLOW), 6);
        public static Level ORANGE => new Level(nameof(ORANGE), 18);
        public static Level RED => new Level(nameof(RED), 42);
    }
}
