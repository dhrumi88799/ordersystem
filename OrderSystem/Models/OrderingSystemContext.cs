using Microsoft.EntityFrameworkCore;
namespace OrderSystem.Models

{
    public class OrderingSystemContext : DbContext
    {
        /// <summary>
        /// Step 1
        /// we gonna make the connection to the database so if we have two three databse we need to create two three context
        /// </summary>
        public OrderingSystemContext(DbContextOptions<OrderingSystemContext> options):base(options)
        {

        }
        public OrderingSystemContext()
        {
        }

        ///<summary>
        /// Step 2
        /// We gonna create the classes(Tables DbSet)
        /// User_Registration is mapping to the table
        /// </summary>
        public DbSet<User_Registration> User_Registration { get; set; }
        public DbSet<Product_Details> Product_Details { get; set; }
        public DbSet<Category_Detail> Category_Detail { get; set; }
        public DbSet<Sub_Category_Details> Sub_Category_Details { get; set; }

    }
}
