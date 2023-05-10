using Microsoft.EntityFrameworkCore;
using RecycleDevices.Data;
using RecycleDevices.Models;

namespace RecycleDevices.Models
{
    public class ProductsData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApointmentContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApointmentContext>>()))
            {
                if (context.Product.Any())
                {
                    return;
                }
                context.Product.AddRange(
                    new Product
                    {
                        Name = "Equipos de informática y telecomunicaciones",
                        Description = "Computadoras de escritorio, laptops, tabletas, telefonos, routers, impresoras",
                        Points = 50
                    }, new Product
                    {
                        Name = "Grandes electrodomésticos",
                        Description = "Refrigeradores, lavadoras, secadoras, estufas, hornos",
                        Points = 45
                    }, new Product
                    {
                        Name = "Herramientas electricas y electronicas",
                        Description = "Taladros, cierras electricas, martillos electricos, lijadoras, cortadoras de cespe",
                        Points = 40
                    }, new Product
                    {
                        Name = "Equipos electronicos de consumo",
                        Description = "Tv, reproductores DVD, sistemas de sonido, camaras, relojes inteligentes",
                        Points = 30
                    }, new Product
                    {
                        Name = "Pequeños electrodomesticos",
                        Description = "Licuadoras, Cafeteras, Tostadoras, Batidoras, Planchas",
                        Points = 25
                    }, new Product
                    {
                        Name = "Jueguetes, equipos deportivos y de ocio",
                        Description = "Consolas, patinetas electricas, drones",
                        Points = 20
                    }, new Product
                    {
                        Name = "Dispositivos medicos",
                        Description = "",
                        Points = 15
                    }
                    );
                context.SaveChanges();
            }
        }

    }
}
