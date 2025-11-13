namespace RobloxCacheWiper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Are you sure you want to clear your roblox cache? (y/n)");
            string? answer = Console.ReadLine();

            if (answer == "y")
            {
                Console.Clear();
                ClearCache();
            }
            else
            {
                Environment.Exit(0);
            }
            Console.WriteLine("You can close this program now.");
            Console.ReadLine();
        }

        static void ClearCache()
        {
            string Temp = Path.GetTempPath();
            string Cache = Path.Combine(Temp, "Roblox");

            if (!Directory.Exists(Cache))
            {
                Console.WriteLine("Unable to find " + Cache);
                Environment.Exit(0);
            }

            foreach (var file in Directory.GetFiles(Cache))
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (var dir in Directory.GetDirectories(Cache))
            {
                Directory.Delete(dir, true);
            }
            Console.WriteLine("Successfully wiped client cache");
        }
    }
}
