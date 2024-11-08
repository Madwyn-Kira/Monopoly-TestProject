namespace MonopolyProject.src
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataService service = new DataService();

            string filePath = "data.txt";
            List<Palette> palettes = service.LoadPalettesFromFile(filePath);

            if (palettes.Count > 0)
            {
                var groupedPalettes = GroupAndSortPalettes(palettes);
                Console.WriteLine("Palettes grouped by expiration date:");
                service.PrintPalettes(groupedPalettes);

                var top3Palettes = GetTop3Palettes(palettes);
                Console.WriteLine("\nTop 3 palettes with the latest expiration dates:");
                service.PrintPalettes(top3Palettes);
            }
            else
            {
                Console.WriteLine("No data loaded.");
            }

            Console.ReadKey();
        }

        static List<Palette> GroupAndSortPalettes(List<Palette> palettes)
        {
            return palettes
                 .GroupBy(p => p.ExpirationDate)
                 .OrderBy(g => g.Key)
                 .SelectMany(g => g.OrderBy(p => p.Weight))
                 .ToList();
        }

        static List<Palette> GetTop3Palettes(List<Palette> palettes)
        {
            return palettes
                .OrderByDescending(p => p.ExpirationDate)
                .ThenBy(p => p.Volume)
                .Take(3)
                .ToList();
        }
    }
}
