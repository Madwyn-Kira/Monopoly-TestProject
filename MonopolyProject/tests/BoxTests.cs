using MonopolyProject.src;
using Xunit;

namespace MonopolyProject.tests
{
    public class BoxTests
    {
        [Fact]
        public void Box_Constructor_ValidData_CreatesBox()
        {
            var box = new Box(1, 10, 10, 10, 10, new DateTime(2024, 01, 01));
            Assert.Equal(1, box.Id);
            Assert.Equal(10, box.Width);
            Assert.Equal(new DateTime(2024, 01, 01).AddDays(100), box.ExpirationDate);
        }

        [Fact]
        public void Box_Constructor_InvalidData_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Box(1, -10, 10, 10, 10, new DateTime(2024, 01, 01)));
            Assert.Throws<ArgumentException>(() => new Box(1, 10, 10, 10, 10, new DateTime(2024, 01, 01)));
            Assert.Throws<ArgumentException>(() => new Box(["1;abc;10;10;10;01.01.2024"]));
        }
    }
}
