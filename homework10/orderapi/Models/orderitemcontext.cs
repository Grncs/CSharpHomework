using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace orderapi.Models
{
    public class OrderItemContext:DbContext{
        public OrderItemContext()
            :base()
            {

            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 获取appsettings.json配置信息
            var config = new ConfigurationBuilder()
                            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
            // 获取数据库连接字符串
            string conn = config.GetConnectionString("order");
            //连接数据库
            optionsBuilder.UseSqlServer(conn);
        }


         public OrderItemContext(DbContextOptions<OrderItemContext> options)
            : base(options)
        {
        }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}