using MonopolyProject.src;
using Xunit;

namespace MonopolyProject.tests
{
    public class PaletteTests
    {
        [Fact]
        public void Palette_AddBox_ValidBox_AddsBox()
        {
            var palette = new Palette(1, 100, 100, 100);
            var box = new Box(1, 10, 10, 10, 10, new DateTime(2024, 01, 01));
            palette.AddBox(box);
            Assert.Single(palette.Boxes);
            Assert.Equal(40, palette.Weight); // 10 + 30
        }

        [Fact]
        public void Palette_AddBox_TooBigBox_ThrowsException()
        {
            var palette = new Palette(1, 100, 100, 100);
            var box = new Box(1, 150, 10, 10, 10, new DateTime(2024, 01, 01));
            Assert.Throws<ArgumentException>(() => palette.AddBox(box));
        }
    }
}
