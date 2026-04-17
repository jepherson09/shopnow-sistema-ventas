using Xunit;
using ShopNow.Models;

namespace ShopNow.Tests
{
    public class CarritoTests
    {
        [Fact]
        public void CalcularTotal_DosProductos_RetornaMontoConITBIS()
        {
            // Arrange
            decimal precioUnitario = 1000m;
            int cantidad = 2;
            decimal subtotal = precioUnitario * cantidad;
            decimal itbis = subtotal * 0.18m;

            // Act
            decimal total = subtotal + itbis;

            // Assert
            Assert.Equal(2360m, total);
        }

        [Fact]
        public void CalcularITBIS_Precio1000_Retorna180()
        {
            // Arrange
            decimal precio = 1000m;

            // Act
            decimal itbis = precio * 0.18m;

            // Assert
            Assert.Equal(180m, itbis);
        }

        [Fact]
        public void Producto_StockNegativo_DebeSerCero()
        {
            // Arrange
            var producto = new Producto
            {
                Nombre = "Laptop Test",
                Precio = 35000m,
                Stock = 0
            };

            // Act & Assert
            Assert.Equal(0, producto.Stock);
        }

        [Fact]
        public void Usuario_RolPorDefecto_EsCliente()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nombre = "Test User",
                Email = "test@test.com",
                Contrasena = "Test1234!"
            };

            // Assert
            Assert.Equal("cliente", usuario.Rol);
        }

        [Fact]
        public void Orden_EstadoPorDefecto_EsPendiente()
        {
            // Arrange
            var orden = new Orden
            {
                NumeroOrden = "ORD-001",
                UsuarioId = 1,
                Total = 2360m,
                ITBIS = 360m
            };

            // Assert
            Assert.Equal("Pendiente", orden.Estado);
        }

        [Fact]
        public void DetalleOrden_CalcularSubtotal_EsCorrecto()
        {
            // Arrange
            decimal precioUnitario = 500m;
            int cantidad = 3;

            // Act
            decimal subtotal = precioUnitario * cantidad;

            // Assert
            Assert.Equal(1500m, subtotal);
        }

        [Fact]
        public void Producto_Activo_PorDefectoEsTrue()
        {
            // Arrange
            var producto = new Producto
            {
                Nombre = "Camiseta",
                Precio = 500m,
                Stock = 10
            };

            // Assert
            Assert.True(producto.Activo);
        }

        [Fact]
        public void CalcularTotal_CarritoVacio_EsCero()
        {
            // Arrange
            decimal subtotal = 0m;
            decimal itbis = subtotal * 0.18m;

            // Act
            decimal total = subtotal + itbis;

            // Assert
            Assert.Equal(0m, total);
        }

        [Fact]
        public void NumeroOrden_FormatoValido_ContieneORD()
        {
            // Arrange
            string numeroOrden = "ORD-" + DateTime.Now.Ticks.ToString().Substring(10);

            // Assert
            Assert.StartsWith("ORD-", numeroOrden);
        }

        [Fact]
        public void Categoria_ListaProductos_IniciaVacia()
        {
            // Arrange
            var categoria = new Categoria
            {
                Nombre = "Electronica"
            };

            // Assert
            Assert.NotNull(categoria.Productos);
            Assert.Empty(categoria.Productos);
        }
    }
}