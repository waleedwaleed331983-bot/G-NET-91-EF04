using Assignment_EF_Core_04.Contexts;

namespace Assignment_EF_Core_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Initial View
            Console.WriteLine("=====================================");
            Console.WriteLine("National Bank - Management");
            Console.WriteLine("=====================================");

            Console.WriteLine("1) Add new a Customer");
            Console.WriteLine("2) Open a new Account for a Customer");
            Console.WriteLine("3) Update Account Status ( Active / Closed )");
            Console.WriteLine("4) Remove an Account for a Customer");
            Console.WriteLine("5) List all Customers ( with Accounts )");
            Console.WriteLine("0) Exit");
            Console.WriteLine("-------------------------------------");

            #endregion

            var dbCotext = new MyContextClass();

            Console.ReadKey();
        }
    }
}
