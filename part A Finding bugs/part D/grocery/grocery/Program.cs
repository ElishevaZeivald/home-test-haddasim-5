// See https://aka.ms/new-console-template for more information
using DALgrocery;

Console.WriteLine("Hello, World!");



{
    static void Main(string[] args)
    {
        using (var db = new AppDbContext())
        {
            db.Database.EnsureCreated();
            Console.WriteLine("המסד נוצר בהצלחה");
        }
    }
}
