namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.PcShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.PcShopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            /*context.Products.AddOrUpdate(new EF.Models.Product
            {
                CategoryId = 1,
                BrandId= 1,
                Name= "Corsair VENGEANCE RGB PRO 16GB (2 x 8GB) DDR4 3200MHz C16 RAM Kit Black",
                ProductPrice= 9500,
                CostPrice= 7500,
                Quantity= 10,
                Description= "The THERMALTAKE WATERRAM RGB 32GB DDR4 3600MHz CL18 (8GB X 4) Desktop RAM is a high-performance memory module designed to enhance the overall performance of your desktop computer. With a memory capacity of 32GB, it provides ample space for multitasking, gaming, and content creation. The DDR4 technology ensures faster data transfer rates and improved efficiency compared to its predecessors.\r\n\r\nOne of the standout features of this RAM is its impressive frequency of 3600MHz. This high clock speed allows for faster data processing, resulting in smoother multitasking and improved system responsiveness. Additionally, the low latency of 18-20-20-39 ensures quick access to data, reducing lag and enhancing overall performance.",
            });*/
        }
    }
}
