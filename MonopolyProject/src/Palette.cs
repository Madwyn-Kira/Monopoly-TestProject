using System.ComponentModel.DataAnnotations;

namespace MonopolyProject.src
{
    public class Palette
    {
        public int Id { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Depth { get; set; }
        public double Weight { get; private set; }
        public List<Box> Boxes { get; } = new List<Box>();
        public DateTime? ExpirationDate { get; private set; }
        public double Volume => Boxes.Sum(box => box.Volume) + Width * Height * Depth;

        public Palette(int id, double width, double height, double depth)
        {
            Id = id;
            Width = width;
            Height = height;
            Depth = depth;
        }

        public Palette(string[] data)
        {
            if (data.Length != 4) throw new ArgumentException("Invalid data format");
            if (!int.TryParse(data[0], out int id) || id <= 0) throw new ArgumentException("Invalid ID");
            Id = id;
            if (!double.TryParse(data[1], out double width) || width <= 0) throw new ArgumentException("Invalid width");
            Width = width;
            if (!double.TryParse(data[2], out double height) || height <= 0) throw new ArgumentException("Invalid height");
            Height = height;
            if (!double.TryParse(data[3], out double depth) || depth <= 0) throw new ArgumentException("Invalid depth");
            Depth = depth;
        }

        public void AddBox(Box box)
        {
            if (box.Width > Width || box.Depth > Depth)
            {
                throw new ArgumentException("Box is too large for the pallet.");
            }
            Boxes.Add(box);
            RecalculateWeightAndExpirationDate();
        }

        private void RecalculateWeightAndExpirationDate()
        {
            Weight = Boxes.Sum(box => box.Weight) + 30;
            ExpirationDate = Boxes.Min(box => box.ExpirationDate ?? DateTime.MaxValue);
        }
    }
}
