using ProductManager.Models;

namespace ProductManager.Domain.Test
{
    public class ProductTest
    {
        [Fact]
        public void NameOfProductFilledIn()
        {
            //Arrange
            string value = "test";
            Product product = new Product();

            //Act
            product.Name = value;

            //Assert
            Assert.Equal(value, product.Name);
        }
    }
}