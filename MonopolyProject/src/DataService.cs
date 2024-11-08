namespace MonopolyProject.src
{
    public class DataService
    {
        public List<Palette> LoadPalettesFromFile(string filePath)
        {
            List<Palette> palettes = new List<Palette>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts[0] == "Palette")
                    {
                        Palette _palette = new Palette(parts.Skip(1).ToArray());
                        palettes.Add(_palette);
                    }
                    else if (parts[0] == "Box")
                    {
                        palettes.Last().AddBox(new Box(parts.Skip(1).ToArray()));
                    }

                }
                return palettes;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {filePath}");
                return new List<Palette>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                return new List<Palette>();
            }
        }

        public void PrintPalettes(List<Palette> palettes)
        {
            foreach (var palette in palettes)
            {
                Console.WriteLine($"\nПаллета ID: {palette.Id}, Вес: {palette.Weight} кг, Срок годности: {palette.ExpirationDate?.ToShortDateString()}, Объем: {palette.Volume}");
                foreach (var box in palette.Boxes)
                {
                    Console.WriteLine($"\tКоробка ID: {box.Id}, Вес: {box.Weight} кг, Срок годности: {box.ExpirationDate?.ToShortDateString()}, Объем: {box.Volume}");
                }
            }
        }
    }
}
