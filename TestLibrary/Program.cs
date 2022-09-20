using CapstoneLibrary.Models;

Console.WriteLine("Capstone Library");

AppDbContext _context = new();

UsersController userCtrl = new(_context);

List<User> users = userCtrl.GetAll().ToList();

foreach (User user in users)
{
    Print(user);
}

void Print(object obj)
{
    Console.WriteLine(obj);
    System.Diagnostics.Debug.WriteLine(obj.ToString());
}