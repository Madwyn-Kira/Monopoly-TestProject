using System.ComponentModel.DataAnnotations;

namespace MonopolyProject.src
{
    public class Box
    {
        public int Id { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Depth { get; set; }
        [Required]
        public double Weight { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; private set; }

        public double Volume => Width * Height * Depth;

        public Box(int id, double width, double height, double depth, double weight, DateTime? productionDate)
        {
            Id = id;
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
            ProductionDate = productionDate;
            ExpirationDate = ProductionDate?.AddDays(100);
        }

        public Box(string[] data)
        {
            if (data.Length != 5 && data.Length != 6) throw new ArgumentException("Invalid data format");
            if (!int.TryParse(data[0], out int id) || id <= 0) throw new ArgumentException("Invalid ID");
            Id = id;
            if (!double.TryParse(data[1], out double width) || width <= 0) throw new ArgumentException("Invalid width");
            Width = width;
            if (!double.TryParse(data[2], out double height) || height <= 0) throw new ArgumentException("Invalid height");
            Height = height;
            if (!double.TryParse(data[3], out double depth) || depth <= 0) throw new ArgumentException("Invalid depth");
            Depth = depth;
            if (!double.TryParse(data[4], out double weight) || weight <= 0) throw new ArgumentException("Invalid weight");
            Weight = weight;

            if (data.Length == 6)
            {
                if (DateTime.TryParse(data[5], out DateTime productionDate))
                {
                    ProductionDate = productionDate;
                }
                else
                {
                    throw new ArgumentException("Invalid ProductionDate format");
                }
            }
            else if (data.Length != 5)
            {
                throw new ArgumentException("Invalid data format");
            }
            ExpirationDate = ProductionDate?.AddDays(100);
        }
    }
}
