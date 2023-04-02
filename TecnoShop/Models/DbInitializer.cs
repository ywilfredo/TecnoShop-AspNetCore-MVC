using System.IO.Pipelines;
using TecnoShop.Models;
namespace TecnoShop.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            TecnoShopDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<TecnoShopDbContext>();

            if (!context.Categorias.Any())
            {
                context.Categorias.AddRange(Categorias.Select(c => c.Value));
            }

            if (!context.Marcas.Any())
            {
                context.Marcas.AddRange(Marcas.Select(m => m.Value));
            }

            if (!context.Productos.Any())
            {
                context.AddRange
                (
                  new Producto
                  {
                      Nombre = "HP Envy 17T i7-1195G7",
                      Especificaciones = "Laptop HP modelo Envy 17T procesador i7-1195G7 de 11ª generación, 16 GB de RAM, 512 GB NVMe SSD, 17.3 pulgadas FHD Touch, Thunderbolt 4, Win 11 PRO, WiFi 6, altavoces B&O, USB-A, gráficos Intel Xe, plata, 64 GB Tech Warehouse Flashdrive",
                      Precio = 1029.00M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/8190NynblEL._AC_UL320_.jpg",
                      Marca = Marcas["Hp"],
                      Categoria = Categorias["Notebooks"]
                  },
                  new Producto
                  {
                      Nombre = "HP Pavilion i7-1255U",
                      Especificaciones = "Marca HP modelo Pavilion con pantalla táctil FHD de 15.6 pulgadas, procesador Intel Core i7-1255U (10 núcleos), gráficos GeForce MX550, 32 GB de RAM, 1 TB PCIe SSD, Wi-Fi 6, HDMI, cámara web, teclado retroiluminado, Windows 11 Pro",
                      Precio = 1149.99M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/818VkKnDR+L._AC_SX679_.jpg",
                      Marca = Marcas["Hp"],
                      Categoria = Categorias["Notebooks"]
                  },
                  new Producto
                  {
                      Nombre = "HP Victus AMD Ryzen 7 5800H",
                      Especificaciones = "HP Portátil para juegos Victus 15 2022, pantalla FHD de 15.6 pulgadas 144 Hz, AMD Ryzen 7 5800H (hasta 4.4 GHz), Nvidia RTX 3050Ti (32 GB de RAM | SSD de 1 TB)",
                      Precio = 974.69M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/71h2AVQdfGL._AC_SX466_.jpg",
                      Marca = Marcas["Hp"],
                      Categoria = Categorias["Gaming"]
                  },
                  new Producto
                  {
                      Nombre = "HP Pavilion Gaming Intel Core i5-9300H",
                      Especificaciones = "HP Pavilion Gaming - Laptop de 15 pulgadas, Intel Core i5-9300H, NVIDIA GeForce GTX 1650, 12 GB de RAM, SSD de 256 GB, Windows 10 (15-dk0041nr, negro)",
                      Precio = 1029.00M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/810gynDZHzL._AC_SX466_.jpg",
                      Marca = Marcas["Hp"],
                      Categoria = Categorias["Gaming"]
                  },
                  new Producto
                  {
                      Nombre = "ASUS ROG Gaming AMD Ryzen 9 5900HX",
                      Especificaciones = "ASUS ROG Strix Scar 15 Gaming Laptop, 15.6\" 300Hz IPS Type FHD Display, NVIDIA GeForce RTX 3080, AMD Ryzen 9 5900HX, 16GB DDR4, 1TB SSD, Opti-Mechanical Per-Key RGB Keyboard, Windows 11, G533QS-DS94",
                      Precio = 1499.99M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/71sgAr9atBS._AC_SX679_.jpg",
                      Marca = Marcas["Asus"],
                      Categoria = Categorias["Gaming"]
                  },
                  new Producto
                  {
                      Nombre = "ASUS ROG Gaming AMD Ryzen 9 5900HX",
                      Especificaciones = "ASUS ROG Strix Scar 15 Gaming Laptop, 15.6\" 300Hz IPS Type FHD Display, NVIDIA GeForce RTX 3080, AMD Ryzen 9 5900HX, 16GB DDR4, 1TB SSD, Opti-Mechanical Per-Key RGB Keyboard, Windows 11, G533QS-DS94",
                      Precio = 1499.99M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/71sgAr9atBS._AC_SX679_.jpg",
                      Marca = Marcas["Asus"],
                      Categoria = Categorias["Gaming"]
                  },
                  new Producto
                  {
                      Nombre = "ASUS Vivobook 2023 AMD Ryzen 3 3250U",
                      Especificaciones = "ASUS Portátil Vivobook 2023, pantalla de 14 pulgadas, procesador AMD Ryzen 3 3250U, 8 GB de RAM, 128 GB SSD, gráficos Intel HD 5000, Bluetooth, cámara web, Windows 11 en modo S, gris pizarra",
                      Precio = 329.99M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/61R7Bsn3t3L._AC_SX466_.jpg",
                      Marca = Marcas["Asus"],
                      Categoria = Categorias["Ultrabook"]
                  },
                  new Producto
                  {
                      Nombre = "Lenovo Ideapad Intel Core i3-1115G4",
                      Especificaciones = "Lenovo Laptop Ideapad 3 2022, pantalla táctil HD de 15.6 pulgadas, procesador Intel Core i3-1115G4 de 11ª generación, 8 GB de RAM DDR4, SSD PCIe NVMe de 256 GB, HDMI, cámara web, Wi-Fi 5, Bluetooth, Windows 11 Home, almendra",
                      Precio = 375.99M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/61QGMX0Qy6L._AC_SX466_.jpg",
                      Marca = Marcas["Lenovo"],
                      Categoria = Categorias["Notebooks"]
                  },
                  new Producto
                  {
                      Nombre = "Lenovo ThinkPad 2023 AMD Ryzen 5 5625U",
                      Especificaciones = "Lenovo 2023 ThinkPad E15 Gen 4 - Portátil empresarial de alto rendimiento: AMD Ryzen 5 5625U Hex-Core, 40GB RAM, 1TB NVMe SSD, pantalla IPS FHD 1920x1080, Win 10 Pro, plateado",
                      Precio = 1399.00M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/71hwpV5oXsL._AC_SX679_.jpg",
                      Marca = Marcas["Lenovo"],
                      Categoria = Categorias["Profesional"]
                  },
                  new Producto
                  {
                      Nombre = "Lenovo Legion 5 Ryzen 5 5600H",
                      Especificaciones = "Lenovo Legion 5 15.6, Ryzen 5 5600H, GeForce RTX 3050 Ti, 8 GB de RAM, SSD de 512 GB, azul fantasma, Windows 11 Home, 82JW00Q7US",
                      Precio = 765.45M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/41NssgHyqBL._AC_SX466_.jpg",
                      Marca = Marcas["Lenovo"],
                      Categoria = Categorias["Gaming"]
                  },
                  new Producto
                  {
                      Nombre = "Dell Inspiron Intel Core i5-1135G7",
                      Especificaciones = "Dell Laptop Inspiron 3511 2022, pantalla táctil FHD de 15.6 pulgadas, Intel Core i5-1135G7, 16 GB DDR4 RAM, 512 GB PCIe SSD, lector de tarjetas SD, cámara web, HDMI, Wi-Fi, Windows 11 Home, negro",
                      Precio = 528.00M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/71I8QUVcEpL._AC_SX679_.jpg",
                      Marca = Marcas["Dell"],
                      Categoria = Categorias["Notebooks"]
                  },
                  new Producto
                  {
                      Nombre = "Dell G15 Gaming AMD Ryzen 7 5800H",
                      Especificaciones = "Dell Laptop G15 para juegos, pantalla FHD de 15.6 pulgadas, procesador AMD Ryzen 7 5800H de 8 núcleos, NVIDIA GeForce RTX 3050Ti, 32GB de RAM, SSD PCIe de 1TB, teclado retroiluminado, Wi-Fi 6, Windows 10, gris fantasma",
                      Precio = 999.99M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/71QGcQ-X-fL._AC_SX679_.jpg",
                      Marca = Marcas["Dell"],
                      Categoria = Categorias["Gaming"]
                  },
                  new Producto
                  {
                      Nombre = "Acer Aspire 5 AMD Ryzen 3 3350U",
                      Especificaciones = "Laptop Acer Aspire 5 Slim 2022, IPS Full HD de 15.6 pulgadas, procesador AMD Ryzen 3 3350U Quad-Core, 12 GB DDR4 RAM, 512 GB SSD, Intel WiFi 6, KB retroiluminado, lector de huellas dactilares, Amazon Alexa, Windows 11",
                      Precio = 469.00M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/81Uc3Mfg6RL._AC_SX466_.jpg",
                      Marca = Marcas["Acer"],
                      Categoria = Categorias["Notebooks"]
                  },
                  new Producto
                  {
                      Nombre = "Acer Predator Helios  Intel i7-11800H",
                      Especificaciones = "Acer Predator Helios 300 PH315-54-760S laptop con Intel i7-11800H, NVIDIA GeForce RTX 3060, pantalla IPS Full HD de 15.6 pulgadas, 144 Hz, 3 ms, 16 GB DDR4, SSD de 512 GB, Killer WiFi 6, teclado RGB",
                      Precio = 1210.00M,
                      Disponible = true,
                      Destacado = true,
                      ImagenUrl = "https://m.media-amazon.com/images/I/71nz3cIcFOL._AC_SX679_.jpg",
                      Marca = Marcas["Acer"],
                      Categoria = Categorias["Gaming"]
                  }
                  );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Categoria>? categorias;

        public static Dictionary<string, Categoria> Categorias
        {
            get
            {
                if (categorias == null)
                {
                    var genresList = new Categoria[]
                    {
                        new Categoria { Nombre="Notebooks" },
                        new Categoria { Nombre="Ultrabook"},
                        new Categoria { Nombre="Gaming"},
                        new Categoria { Nombre="Profesional"}
                    };

                    categorias = new Dictionary<string, Categoria>();

                    foreach (Categoria genre in genresList)
                    {
                        categorias.Add(genre.Nombre, genre);
                    }
                }

                return categorias;
            }
        }

        //
        private static Dictionary<string, Marca>? marcas;

        public static Dictionary<string, Marca> Marcas
        {
            get
            {
                if (marcas == null)
                {
                    var genresList = new Marca[]
                    {
                        new Marca { Nombre="Asus"},
                        new Marca { Nombre="Hp"},
                        new Marca { Nombre="Lenovo"},
                        new Marca { Nombre="Dell"},
                        new Marca { Nombre="Acer"},
                        new Marca { Nombre="Msi"}
                    };

                    marcas = new Dictionary<string, Marca>();

                    foreach (Marca genre in genresList)
                    {
                        marcas.Add(genre.Nombre, genre);
                    }
                }

                return marcas;
            }
        }

    }
}
