using Microsoft.EntityFrameworkCore;

namespace iStore.Models;

public static class SeedData
{
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        StoreDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<StoreDbContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        if (!context.Products.Any())
        {
            context.Products.AddRange(
            new Product
            {
                Name = "Apple iPhone 15 Pro dual-SIM 256 ГБ, «титановый бежевый»",
                Description = "Процессор A17 Pro",
                Category = "iPhone",
                Price = 149990m
            },
            new Product
            {
                Name = "Apple iPhone 15 Pro Max SIM 256 ГБ, «титановый синий»",
                Description = "Процессор A17 Pro",
                Category = "iPhone",
                Price = 165990m
            },
            new Product
            {
                Name = "Apple iPhone 15 dual-SIM 256 ГБ, черный",
                Description = "Процессор A16 Bionic",
                Category = "iPhone",
                Price = 19.50m
            },
            new Product
            {
                Name = "Apple MacBook Air 15\" (M2, 8C CPU/10C GPU, 2023), 8 ГБ, 512 ГБ SSD, «полуночный черный»",
                Description = "Процессор\r\nApple M2\r\nЦвет\r\n«полуночный черный»\r\nПамять\r\n512 ГБ\r\nОбъем оперативной памяти\r\n8 ГБ",
                Category = "Mac",
                Price = 179990m
            },
            new Product
            {
                Name = "Apple MacBook Pro 14\" (M3 Pro 11C CPU, 14C GPU, 2023) 18 ГБ, 512 ГБ SSD, «чёрный космос»",
                Description = "Процессор\r\nApple M3 Pro\r\nЦвет\r\n«чёрный космос»\r\nПамять\r\n512 ГБ\r\nОбъем оперативной памяти\r\n18 ГБ",
                Category = "Mac",
                Price = 269990m
            },
            new Product
            {
                Name = "Apple Watch Ultra 2 GPS + Cellular, 49 мм, корпус из титана, ремешок Ocean синего цвета",
                Description = "Время автономной работы\r\nдо 72 часов",
                Category = "Watch",
                Price = 109990m
            },
            new Product
            {
                Name = "Apple Watch Series 9, 45 мм, корпус из алюминия цвета «тёмная ночь», спортивный ремешок цвета «тёмная ночь», размер M/L",
                Description = "Время автономной работы\r\nдо 18 часов",
                Category = "Watch",
                Price = 51990m
            },
            new Product
            {
                Name = "Apple Watch SE 2023, 44 мм, корпус из алюминия цвета «тёмная ночь», спортивный ремешок цвета «тёмная ночь» M/L",
                Description = "Время автономной работы\r\nдо 18 часов",
                Category = "Watch",
                Price = 33990m
            },
            new Product
            {
                Name = "Беспроводные наушники Apple AirPods Pro (2-го поколения, 2023) MagSafe USB-C, белый",
                Description = "Время работы (воспроизведение), ч\r\n6",
                Category = "AirPods",
                Price = 31990m
            },
            new Product
            {
                Name = "Наушники Apple AirPods (3-его поколения, 2022) белые",
                Description = "\r\nВремя работы (воспроизведение), ч\r\n6",
                Category = "AirPods",
                Price = 21990m
            });

            context.SaveChanges();
        }
    }
}