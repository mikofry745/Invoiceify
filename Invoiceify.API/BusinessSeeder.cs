using Invoiceify.Entities;
using Invoiceify.Entities.Entities;
using Invoiceify.Entities.Enums;

namespace Invoiceify.API;

public class BusinessSeeder
{
    private readonly InvoiceifyDbContext _dbContext;

    public BusinessSeeder(InvoiceifyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Seed()
    {
        if (_dbContext.Database.CanConnect())
        {
            if (!_dbContext.Businesses.Any())
            {
                var businesses = GetBusinesses();

                _dbContext.Businesses.AddRange(businesses);
                _dbContext.SaveChanges();
            }
        }
    }
    
    private IEnumerable<Business> GetBusinesses()
    {
        var businesses = new List<Business>()
        {
            new Business()
            {
                IsOrganization = true,
                DefaultInvoiceNote = "Thank you :>",
                Profile = new BusinessProfile()
                {
                    City  = "Warszawa",
                    Country = "Poland",
                    EmailAddress = "contact@warzywowo.com",
                    Name = "Warzywowo",
                    PhoneNumber = "723012452",
                    Street = "Polna 14",
                    TaxIdentificationNumber = "PL40269941778109024683512296",
                    PostalCode = "00-006"
                },
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Name = "Banana",
                        Description = "Fruit",
                        UnitPrice = 1,
                        UnitType = UnitType.Piece,
                        TaxPercentage = 17
                    },
                    new Product()
                    {
                        Name = "Apple",
                        Description = "Fruit",
                        UnitPrice = (decimal)0.70,
                        UnitType = UnitType.Piece,
                        TaxPercentage = 17
                    },
                    new Product()
                    {
                        Name = "Grapes",
                        Description = "Fruit",
                        UnitPrice = 5,
                        UnitType = UnitType.Piece,
                        TaxPercentage = 17
                    }
                },
                Customers = new List<Customer>()
                {
                    new Customer()
                    {
                        City  = "Warszawa",
                        Country = "Poland",
                        EmailAddress = "contact@techdo.com",
                        Name = "Techdo",
                        IsOrganization = true,
                        PhoneNumber = "754200412",
                        Street = "Topolowa 54",
                        TaxIdentificationNumber = "PL78109024026994174683512296",
                        PostalCode = "00-007"
                    },
                    new Customer()
                    {
                        City = "Piaseczno",
                        Country = "Poland",
                        EmailAddress = "contact@shopcub.com",
                        Name = "Shopcub",
                        IsOrganization = true,
                        PhoneNumber = "652108712",
                        Street = "Cicha 61",
                        TaxIdentificationNumber = "PL35122978199417468609024026",
                        PostalCode = "05-502"
                    }
                },
                Invoices = new List<Invoice>()
                {
                    new Invoice()
                    {
                        Number = "1",
                        DueDate = DateTime.Today.AddDays(14),
                        IssueDate = DateTime.Today,
                        Type = InvoiceType.Regular,
                        Currency = CurrencyType.Euro,
                        Note = "Thank you :)",
                        SubTotal = 150,
                        TotalShiping = 20,
                        TotalTax = 10,
                        TotalPrice = 180,
                        PaymentDate = DateTime.Today,
                        Issuer = new InvoiceCustomer()
                        {
                            City  = "Warszawa",
                            Country = "Poland",
                            EmailAddress = "contact@warzywowo.com",
                            Name = "Warzywowo",
                            IsOrganization = true,
                            PhoneNumber = "723012452",
                            Street = "Polna 14",
                            TaxIdentificationNumber = "PL40269941778109024683512296",
                            PostalCode = "00-006" 
                        },
                        Recipient = new InvoiceCustomer()
                        {
                            City = "Warszawa",
                            EmailAddress = "mar12@gmail.com",
                            IsOrganization = false,
                            Name = "Mariusz Podolski",
                            PhoneNumber = "732012334",
                            PostalCode = "00-006",
                            Street = "Owocowa 16",
                            TaxIdentificationNumber = "PL40269941778109024683512296"
                        },
                        Products = new List<InvoiceProduct>()
                        {
                            new InvoiceProduct()
                            {
                                Name = "Banana",
                                Description = "Fruit",
                                UnitPrice = 1,
                                UnitType = UnitType.Piece,
                                TaxPercentage = 17,
                                Quantity = 5
                            },
                            new InvoiceProduct()
                            {
                                Name = "Grapes",
                                Description = "Fruit",
                                UnitPrice = 5,
                                UnitType = UnitType.Piece,
                                TaxPercentage = 17,
                                Quantity = 2
                            }
                        }
                    }
                }
            }
        };
            
        return businesses;
    }
    
}