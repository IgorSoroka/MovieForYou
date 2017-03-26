using System.Data.Entity;

namespace MovieForYou.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class SimpleDbContext : DbContext
    {
        public SimpleDbContext()
        { }

        public SimpleDbContext(string connectionString)
            : base(connectionString)
        { }

        public DbSet<DbItem> DbItems { get; set; }
    }

    //public class MovieDbModel : DbContext
    //{
    //    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    //    public class OwnDbContext : DbContext
    //    {
    //        public OwnDbContext()
    //        { }
    //        public OwnDbContext(string connectionString) : base(connectionString)
    //        { }


    //    }
    //}

    public class DbItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
    }
}