using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;

namespace LunchBoxApp.Domain.Services.SQLite
{
    public class ProductService : SQLiteServiceBase, IProductService
    {
        private static List<Product> Products = new List<Product>();

        public ProductService()
        {
            Products = connection.Table<Product>().ToList();

            if (Products.Count == 0)
            {
                GenerateData();
                Products = connection.Table<Product>().ToList();
            }
        }

        /// <summary>
        /// Returns all existing products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAlProducts()
        {
            await Task.Delay(0);
            return Products;
        }

        /// <summary>
        /// Returns a product by product id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetProductByProductId(Guid id)
        {
            await Task.Delay(0);
            return Products.FirstOrDefault(p => p.ProductId == id);
        }

        /// <summary>
        /// Returns a list of products by sbcategory id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductBySubcategoryId(Guid id)
        {
            await Task.Delay(0);
            return Products.Where(p => p.SubcategoryId == id).ToList();
        }

        public async Task<Product> GetProductOfTheWeek()
        {
            await Task.Delay(0);
            return Products.FirstOrDefault(p => p.ProductOfTheWeek == true);
        }

        private void GenerateData()
        {
            List<Product> productsSeeding = new List<Product>()
            {
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje kaas",
                    Ingredients = new List<string>() {"kaas", "mayo", "sla", "ei", "komkommer", "wortel"},
                    ImageUrl = "test.jpg",
                    ProductDescription = "Eeaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                    ProductPrice = 3.20m,
                    SubcategoryId = new Constants().Subcategory1Guid,
                    ProductOfTheWeek = true
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje brie",
                    Ingredients = new List<string>() {"brie", "notenmengeling", "honing", "rucola"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.90m,
                    SubcategoryId = new Constants().Subcategory1Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje mozarella",
                    Ingredients = new List<string>() {"mozarella", "tomaat", "zongedr. tomaat", "pesto", "rucola"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.70m,
                    SubcategoryId = new Constants().Subcategory1Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje kruidenkaas",
                    Ingredients = new List<string>() {"kruidenkaas", "rucola", "zongedr. tomaat"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.90m,
                    SubcategoryId = new Constants().Subcategory1Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje tonijn",
                    Ingredients = new List<string>() {"tonijnsla", "sla", "wortel", "komkommer", "tomaat", "ei"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.40m,
                    SubcategoryId = new Constants().Subcategory2Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje tonijntino",
                    Ingredients = new List<string>() {"tonijnsla", "martinosaus", "mosterd", "ansjovis", "sla", "tomaat", "komkommer", "ei"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.90m,
                    SubcategoryId = new Constants().Subcategory2Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje krab",
                    Ingredients = new List<string>() {"krabsla", "sla", "komkommer", "tomaat", "ei"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.80m,
                    SubcategoryId = new Constants().Subcategory2Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje gerookte zalm",
                    Ingredients = new List<string>() {"gerookte zalm", "ui", "sla", "mayo"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 4.50m,
                    SubcategoryId = new Constants().Subcategory2Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje kruidenzalm",
                    Ingredients = new List<string>() {"gerookte zalm", "kruidenkaas", "sla", "zongedr. tomaat"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 4.70m,
                    SubcategoryId = new Constants().Subcategory2Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje kabeljauwsla",
                    Ingredients = new List<string>() {"kabeljauwsla", "tomaat", "komkommer", "sla"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 4.60m,
                    SubcategoryId = new Constants().Subcategory2Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje ham",
                    Ingredients = new List<string>() {"ham", "mayo", "sla", "tomaat", "ei", "komkommer", "wortel"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.20m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje smos",
                    Ingredients = new List<string>() {"ham", "kaas", "mayo", "sla", "tomaat", "ei", "komkommer", "wortel"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.50m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje prepare",
                    Ingredients = new List<string>() {"americain", "ui", "sla", "tomaat"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.10m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje martino",
                    Ingredients = new List<string>() {"americain", "ui", "augurk", "martinosaus", "ansjovis", "mosterd"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.70m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje bicky",
                    Ingredients = new List<string>() {"americain", "bickysaus", "geroosterde ui", "augurk", "sla", "tomaat"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.60m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje bacon pepper",
                    Ingredients = new List<string>() {"americain", "verse ui", "pepersaus", "spek", "tomaat", "sla"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 4.20m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje salami",
                    Ingredients = new List<string>() {"salami", "mayo", "sla", "tomaat", "wortel", "komkommer", "ei"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.20m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje serranoham",
                    Ingredients = new List<string>() {"serranoham", "pesto", "permezaan", "rucola"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 4.00m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje pain de veau",
                    Ingredients = new List<string>() {"vleesbrood", "sla", "tomaat", "komkommer", "mosterd"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 4.10m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje italiano",
                    Ingredients = new List<string>() {"serranoham", "mozzarella", "pesto", "rucola", "zongedr. tomaat"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 4.20m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje vleessla",
                    Ingredients = new List<string>() {"vleessla", "sla", "tomaat", "ei", "komkommer", "wortel"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.20m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje carrero",
                    Ingredients = new List<string>() {"warme mexicano", "tomaat", "sla", "geroosterde ui", "bickysaus"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 4.50m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje vleesbrood spec.",
                    Ingredients = new List<string>() {"vleesbrood", "spek", "kaas", "tomaat", "sla", "curryketchup", "mayo"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 4.60m,
                    SubcategoryId = new Constants().Subcategory3Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje kip maison",
                    Ingredients = new List<string>() {"gebakken kip", "spek", "sla", "tomaat", "geroosterde uitjes", "giantsaus"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 4.20m,
                    SubcategoryId = new Constants().Subcategory4Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Broodje kip curry",
                    Ingredients = new List<string>() {"kip curry", "sla", "tomaat", "wortel", "komkommer"},
                    ImageUrl = "https://i.gyazo.com/72b598e9ca1b0103fa92ee903fd22f36.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.30m,
                    SubcategoryId = new Constants().Subcategory4Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Panini kaas & ham",
                    Ingredients = new List<string>() {"ham", "kaas", "tomaat"},
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 4.20m,
                    SubcategoryId = new Constants().Subcategory5Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Panini gerookte zalm",
                    Ingredients = new List<string>() {"zalm", "kruidenkaas", "tomaat"},
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 6.00m,
                    SubcategoryId = new Constants().Subcategory5Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Panini serranoham",
                    Ingredients = new List<string>() {"serranoham", "pesto", "rucola", "mozarella", "zongedr. tomaat"},
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.60m,
                    SubcategoryId = new Constants().Subcategory5Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Panini drie kazen",
                    Ingredients = new List<string>() {"jonge kaas", "mozarella", "brie", "pesto", "tomaat", "zongedr. tomaat", "basilicum"},
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.60m,
                    SubcategoryId = new Constants().Subcategory5Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Groentensalade",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.50m,
                    SubcategoryId = new Constants().Subcategory6Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Salade met kip",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 8.00m,
                    SubcategoryId = new Constants().Subcategory6Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Salade met gerookte zalm",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 9.00m,
                    SubcategoryId = new Constants().Subcategory6Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Salade met mozarella",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 8.00m,
                    SubcategoryId = new Constants().Subcategory6Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta bolognaise (S)",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta bolognaise (M)",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 6.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta bolognaise (L)",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 7.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta carbonara (S)",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta carbonara (M)",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 6.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta carbonara (L)",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 7.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta arrabiata (S)",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta arrabiata (M)",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 6.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta arrabiata (L)",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 7.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta vier kazen (S)",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta vier kazen (M)",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 6.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Pasta vier kazen (L)",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 7.00m,
                    SubcategoryId = new Constants().Subcategory7Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Worstenbroodje",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.20m,
                    SubcategoryId = new Constants().Subcategory8Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Droge worst",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/6bfef0c5ecfa3d869d8ec3cdba5829a1.jpg",
                    ProductDescription = null,
                    ProductPrice = 1.20m,
                    SubcategoryId = new Constants().Subcategory8Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Donut",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/91c009a2ed0474ae7bca046d9c9e835e.jpg",
                    ProductDescription = null,
                    ProductPrice = 1.40m,
                    SubcategoryId = new Constants().Subcategory9Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Rijsttaartje",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/91c009a2ed0474ae7bca046d9c9e835e.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.00m,
                    SubcategoryId = new Constants().Subcategory9Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Chocoladekoek",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/91c009a2ed0474ae7bca046d9c9e835e.jpg",
                    ProductDescription = null,
                    ProductPrice = 1.20m,
                    SubcategoryId = new Constants().Subcategory10Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Croissant",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/91c009a2ed0474ae7bca046d9c9e835e.jpg",
                    ProductDescription = null,
                    ProductPrice = 1.20m,
                    SubcategoryId = new Constants().Subcategory10Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Ontbijt-Box",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/91c009a2ed0474ae7bca046d9c9e835e.jpg",
                    ProductDescription = null,
                    ProductPrice = 5.00m,
                    SubcategoryId = new Constants().Subcategory10Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Thee",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.20m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Koffie",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.20m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Deca koffie",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.20m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Cappuccino",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.50m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Macchiato",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.50m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Warme chocolademelk",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.50m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Take away dagsoep 1/2 l.",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 2.00m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Take away dagsoep 1 l.",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.80m,
                    SubcategoryId = new Constants().Subcategory11Guid
                },

                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Take a seat dagsoep",
                    Ingredients = null,
                    ImageUrl = "https://i.gyazo.com/fd2b7d7808b734f3d3bcede09fdcd049.jpg",
                    ProductDescription = null,
                    ProductPrice = 3.00m,
                    SubcategoryId = new Constants().Subcategory11Guid
                }
            };
            connection.InsertAll(productsSeeding);
        }
    }
}
