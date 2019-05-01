using Microsoft.EntityFrameworkCore;

namespace Vega.Models
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DbSet<Model> Models { get; set; }
    }
}
