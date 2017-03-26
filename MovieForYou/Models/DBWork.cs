namespace MovieForYou.Models
{
    public class DbWork
    {
        private static string connectionString = @"Server=localhost;Database=myFirstDataBase;Uid=root;Pwd=Cartabia-1993";
        SimpleDbContext _context = new SimpleDbContext(connectionString);

        public void AddData()
        {
            DbItem _first = new DbItem() { Id = 1, Name = "Igor", Type = 1 };
            _context.DbItems.Add(_first);
            _context.SaveChanges();
        }
    }
}
