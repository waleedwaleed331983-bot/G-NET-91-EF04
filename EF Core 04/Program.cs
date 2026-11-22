using Assignment_EF_Core_04.Contexts;
using Assignment_EF_Core_04.Enums;
using Assignment_EF_Core_04.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Loader;

namespace Assignment_EF_Core_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbCnotext = new MyContextClass();
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


            Console.Write("Enter Your Choice: ");
            var UserOption = Convert.ToInt32(Console.ReadLine());
            DateOnly customerDOB;
            //var res03;
            switch (UserOption)
            {
                case 1:
                    #region Add a new Customer
                    Console.WriteLine("--- Add a new Customer ---");

                    Console.Write("Full Name: ");
                    string customerFullName = Console.ReadLine() ?? string.Empty;

                    Console.Write("National ID: ");
                    string customerNationalId = Console.ReadLine() ?? string.Empty;

                    Console.Write("Date of Birth (yyyy-MM-dd): ");
                    while (!DateOnly.TryParse(Console.ReadLine(), out customerDOB))
                    {
                        Console.Write("Invalid date. Please re-enter (yyyy-MM-dd): ");
                    }

                    Console.Write("Email: ");
                    string customerEmail = Console.ReadLine() ?? string.Empty;

                    Console.Write("Phone: ");
                    string customerPhone = Console.ReadLine() ?? string.Empty;

                    Console.Write("Address (Country, City, Street): ");
                    string addressInput = Console.ReadLine() ?? string.Empty;
                    string[] parts = addressInput.Split(',');

                    Console.WriteLine("Customer Type:");
                    Console.WriteLine(" 1) Individual");
                    Console.WriteLine(" 2) Business");
                    Console.Write("Select option: ");
                    int.TryParse(Console.ReadLine(), out int userOptionToCustomerType);

                    CustomerType selectedType = userOptionToCustomerType == 2
                        ? CustomerType.Business
                        : CustomerType.Individual;

                    var newCustomer = new Customer
                    {
                        FullName = customerFullName,
                        NationalId = customerNationalId,
                        DateOfBirth = customerDOB,
                        Email = customerEmail.Trim(),
                        PhoneNumber = customerPhone.Trim(),
                        Address = new EF_Core_04.Models.Address
                        {
                            Country = parts.Length > 0 ? parts[0].Trim() : string.Empty,
                            City = parts.Length > 1 ? parts[1].Trim() : string.Empty,
                            Street = parts.Length > 2 ? parts[2].Trim() : string.Empty
                        },
                        CustomerType = selectedType
                    };

                    dbCnotext.Add(newCustomer);
                    dbCnotext.SaveChanges();

                    Console.WriteLine($"Customer created successfully. Customer Id = {newCustomer.Id}");
                    #endregion
                    break;
                case 2:
                    Console.WriteLine("--- Open New Account ---");

                    Console.Write("Account Number : ");
                    if (!int.TryParse(Console.ReadLine(), out int accountNumber))
                    {
                        Console.WriteLine("Invalid Account Number!");
                        break;
                    }

                    Console.WriteLine("Account Type :");
                    Console.WriteLine(" 1) Savings");
                    Console.WriteLine(" 2) Current");
                    Console.WriteLine(" 3) Business");
                    Console.Write("Choice: ");
                    int.TryParse(Console.ReadLine(), out int userOptionForAddAccount);

                    AccountType selectedAccountType = userOptionForAddAccount switch
                    {
                        2 => AccountType.Current,
                        3 => AccountType.Buisness, 
                        _ => AccountType.Savings
                    };

                    Console.Write("Branch Code : ");
                    if (!int.TryParse(Console.ReadLine(), out int accountBranchCode))
                    {
                        Console.WriteLine("Invalid Branch Code!");
                        break;
                    }

                    Console.Write("CustomerId : ");
                    if (!int.TryParse(Console.ReadLine(), out int accountCustomerId))
                    {
                        Console.WriteLine("Invalid Customer ID!");
                        break;
                    }

                    Console.WriteLine("OwnerShip Role:");
                    Console.WriteLine(" 1) Primary");
                    Console.WriteLine(" 2) CoHolder");
                    Console.Write("Choice: ");
                    int.TryParse(Console.ReadLine(), out int userOptionToOwnerShipType);
                    OwnerShipType selectedTypeForOwnerShip = userOptionToOwnerShipType == 2 ? OwnerShipType.CoHolder : OwnerShipType.Primary;

                    Console.WriteLine($"Validating Branch #{accountBranchCode} and Customer #{accountCustomerId}...");

                    var branchExists = dbCnotext.Branches.Any(b => b.Code == accountBranchCode);
                    var customerExists = dbCnotext.Customers.Any(c => c.Id == accountCustomerId);

                    if (!branchExists || !customerExists)
                    {
                        Console.WriteLine("Error: Branch or Customer does not exist! Please create them first.");
                        break;
                    }

                    var newAccount = new Account
                    {
                        AccountNumber = accountNumber,
                        AccountType = selectedAccountType,
                        BranchId = accountBranchCode
                    };

                    dbCnotext.Accounts.Add(newAccount);
                    dbCnotext.SaveChanges(); 

                    var accountOwner = new CustomerAccount
                    {
                        AccountId = newAccount.AccountNumber,
                        CustomerId = accountCustomerId,
                        OwnerShipType = selectedTypeForOwnerShip
                    };

                    dbCnotext.CustomerAccounts.Add(accountOwner);
                    dbCnotext.SaveChanges();

                    Console.WriteLine($"Account '{accountNumber}' created and linked to customer {accountCustomerId} as {selectedTypeForOwnerShip} owner.");
                    break;
                case 3:
                    Console.WriteLine("--- Update Account Status ---");

                    Console.Write("Account Number: ");
                    if (!int.TryParse(Console.ReadLine(), out int accountNumberForUpdate))
                    {
                        Console.WriteLine("Invalid Account Number!");
                        break;
                    }

                    Console.Write("Customer Id : ");
                    if (!int.TryParse(Console.ReadLine(), out int customerForUpdateAccount))
                    {
                        Console.WriteLine("Invalid Customer Id!");
                        break;
                    }

                    Console.WriteLine("New Status: ");
                    Console.WriteLine("   1) Active");
                    Console.WriteLine("   2) Closed");
                    Console.Write("Choice : ");
                    int.TryParse(Console.ReadLine(), out int userOptionForUpdateAccount);
                    AccountStatus selectedNewValue = userOptionForUpdateAccount == 2 ? AccountStatus.Closed : AccountStatus.Active;


                    var res = dbCnotext.Accounts.FirstOrDefault(a =>
                        a.AccountNumber == accountNumberForUpdate &&
                        a.CustomerAccounts.Any(ca => ca.CustomerId == customerForUpdateAccount));


                    if (res == null)
                    {
                        Console.WriteLine("Error: Account not found or does not belong to this customer!");
                        break;
                    }


                    res.AccountStatus = selectedNewValue;

                    dbCnotext.SaveChanges();

                    Console.WriteLine($"Account #{accountNumberForUpdate} status updated to {selectedNewValue} successfully.");
                    break;
                case 4:
                    Console.WriteLine("--- Remove Account From Customer ---");
                    Console.Write("Account Number : ");
                    if (!int.TryParse(Console.ReadLine(), out int accountNumberForDelete))
                    {
                        Console.WriteLine("Invalid Account Number!");
                        break;
                    };
                    Console.Write("Customer Id    : ");
                    if (!int.TryParse(Console.ReadLine(), out int customerIdForDelete))
                    {
                        Console.WriteLine("Invalid Customer Id!");
                        break;
                    }

                    var result = dbCnotext.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumberForDelete && a.CustomerAccounts.Any(ca => ca.CustomerId == customerIdForDelete));

                    if (result == null)
                    {
                        Console.WriteLine("Error: Account not found or does not belong to this customer!");
                        break;
                    }

                    dbCnotext.Remove(result);
                    dbCnotext.SaveChanges();

                    Console.WriteLine("OwnerShip link deleted");

                    Console.WriteLine($"Account '{accountNumberForDelete}' is deleted successfully.");

                    break;
                case 5:
                    Console.WriteLine("--- All Customers ---");
                    //foreach (var item in dbCnotext.CustomerAccounts)
                    //{
                    //    Console.WriteLine($"#{item.CustomerId} ({item.Customer.CustomerType})");
                    //    Console.WriteLine($"{item.Account.AccountNumber}  Current Balance: {item.Account.CurrentBalance} {item.OwnerShipType} {item.Account.AccountStatus} @{item.Customer.Address.City} {item.Account.Branch.Name}");
                    //}

                    var res02 = dbCnotext.Customers.Select(c => new
                    {
                        customerId = c.Id,
                        customerName = c.FullName,
                        cusstomerType = c.CustomerType
                    }).ToList();
                    
                    foreach (var item in res02)
                    {
                        Console.WriteLine($"#{item.customerId} {item.customerName} ({item.cusstomerType})");
                         var res03 = dbCnotext.CustomerAccounts.Include(ca => ca.Account).ThenInclude(a => a.Branch).FirstOrDefault(ca => ca.CustomerId == item.customerId);
                        if (res03 != null)
                        {
                            Console.WriteLine($"{res03.AccountId} {res03.Account.CurrentBalance} {item.cusstomerType} {res03.OwnerShipType} {res03.Account.AccountStatus} @ {res03.Account.Branch.Name}");
                        }
                        else
                        {
                            Console.WriteLine("   No accounts found for this customer.");
                        }
                    }
                    ;

                    break;
            }

            Console.ReadKey();
        }
    }
}
