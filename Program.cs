using System.Collections;
using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;
using Spectre.Console;

class Program 
{
    static List<Person> persons = new List<Person>();
    static List<Customer> customers = new List<Customer>();
    public static void Main()
    {

        //Customer Relaction Management

        var menu = "";
    
        

        while(menu != "Exit")
        {
            Console.Clear();

            AnsiConsole.Write(
            new FigletText("C.R.Management")
            .Centered()
            .Color(Color.BlueViolet));

            menu = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .PageSize(7)
            .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
            .AddChoices(new[] {
                "Mijozlarni qo'shish, yangilash va o'chirish.", "Savdolarni ro'yxatdan o'tkazish va savdolarni yangilash.",
                "Mijozlar va savdolar haqidagi to'liq ma'lumotlarni ko'rsatish.", "Mijozlarni ismi, email manzili yoki kompaniya nomi bo'yicha qidirish.",
                "Eng muhim savdolarni ko'rsatish va savdolarni daromad bo'yicha saralash.", "Exit",
            }));

            Console.Clear();

            switch(menu)
            {
                case "Mijozlarni qo'shish, yangilash va o'chirish.":
                {
                    Console.Clear();
                    AnsiConsole.Write(
                    new FigletText("Mijozlar")
                    .Centered()
                    .Color(Color.BlueViolet));
                    var menu1 = "";
                    while(menu1 != "Exit.")
                    {
                        menu1 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                        .AddChoices(new[] {
                        
                            "Mijozlarni qoshish.", "Mijozlarni o'chirish.",
                            "Mijozlarni yangilash.", "Exit.",
                        }));

                        switch(menu1)
                        {
                            case "Mijozlarni qoshish.":
                            {
                                AddPersons();
                            }
                            break;
                            case "Mijozlarni o'chirish.":
                            {
                                DeletePesons();
                            }
                            break;
                            case "Mijozlarni yangilash.":
                            {
                                ViewPerons();
                            }
                            break;
                        }
                    }
                }
                break;
                case "Savdolarni ro'yxatdan o'tkazish va savdolarni yangilash.":
                {
                    Console.Clear();
                    AnsiConsole.Write(
                    new FigletText("Savdogarlar")
                    .Centered()
                    .Color(Color.BlueViolet));
                    var menu1 = "";
                    while(menu1 != "Exit.")
                    {
                        menu1 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .PageSize(10)
                        .MoreChoicesText("[grey]()[/]")
                        .AddChoices(new[] {
                        
                            "Savdogar qoshish.", "Savdogar o'chirish.",
                            "Savdogar yangilash.", "Exit.",
                        }));
                        switch(menu1)
                        {
                            case "Savdogar qoshish.":
                            {
                                AddSell();
                            }
                            break;
                            case "Savdogar o'chirish.":
                            {
                                DeleteSellers();
                            }
                            break;
                            case "Savdogar yangilash.":
                            {
                                ViewSellers();
                            }
                            break;
                        }
                    }
                }
                break;
                case "Mijozlar va savdolar haqidagi to'liq ma'lumotlarni ko'rsatish.":
                {
                    Console.Clear();
                    if(persons.Count > 0 && customers.Count > 0)
                    {
                        AnsiConsole.Write(
                        new FigletText("Foydalanuvchilar")
                        .Centered()
                        .Color(Color.Yellow3_1));
                    }
                    if(persons.Count > 0)
                    {
                        PersonsTable();
                    }
                    else
                    {
                        AnsiConsole.Write(
                        new FigletText("Mizojlar mavjud emas")
                        .Centered()
                        .Color(Color.Yellow3_1
                        ));
                    }

                    Console.WriteLine();

                    if(customers.Count > 0)
                    {
                        SellersPerons();
                    }
                    else
                    {
                        AnsiConsole.Write(
                        new FigletText("Savdogarlar mavjud emas")
                        .Centered()
                        .Color(Color.BlueViolet));
                    }
                    Console.WriteLine();

                    var menu1 = "";
                    while(menu1 != "Exit.")
                    {
                        menu1 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .PageSize(10)
                        .MoreChoicesText("[grey]()[/]")
                        .AddChoices(new[] {
                        
    
                            "Exit.",
                        }));

                    }
                }
                break;
                case "Mijozlarni ismi, email manzili yoki kompaniya nomi bo'yicha qidirish.":
                {
                    var menu1 = "";
                    while(menu1 != "Exit.")
                    {
                        menu1 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .PageSize(10)
                        .MoreChoicesText("[grey]()[/]")
                        .AddChoices(new[] {
                        
                            "Mijozlarni ismi","Mijozlarni familiyasi", "Mijozlarni emaili", "Exit.",
                        }));

                        switch(menu1)
                        {
                            case "Mijozlarni ismi":
                            {
                                Console.Clear();
                                AnsiConsole.Write(
                                new FigletText("Qidirish")
                                .Centered()
                                .Color(Color.BlueViolet));
                                Console.Write("Mijozning ismini kriting: ");
                                string ismi = Console.ReadLine()!;
                                var table = new Table();
                                for(int i = 0; i < persons.Count; i++)
                                {
                                    if(ismi == persons[i].FirstName)
                                    {
                                        table.AddColumn("[yellow]FirstName[/]");
                                        table.AddColumn("[yellow]LastName[/]");
                                        table.AddColumn("[yellow]Email[/]");

                                        table.AddRow(persons[i].FirstName, persons[i].LastName, persons[i].Email);

                                        table.Border = TableBorder.Square;
                                        table.Centered();
                                        table.Expand();

                                        AnsiConsole.Write(table);
                                    }
                                }
                                
                            }
                            break;
                            case "Mijozlarni familiyasi":
                            {
                                Console.Clear();
                                AnsiConsole.Write(
                                new FigletText("Qidirish")
                                .Centered()
                                .Color(Color.BlueViolet));
                                Console.Write("Mijozning ismini kriting: ");
                                string familiyasi = Console.ReadLine()!;
                                var table = new Table();
                                for(int i = 0; i < persons.Count; i++)
                                {
                                    if(familiyasi == persons[i].LastName)
                                    {
                                        table.AddColumn("[yellow]FirstName[/]");
                                        table.AddColumn("[yellow]LastName[/]");
                                        table.AddColumn("[yellow]Email[/]");

                                        table.AddRow(persons[i].FirstName, persons[i].LastName, persons[i].Email);

                                        table.Border = TableBorder.Square;
                                        table.Centered();
                                        table.Expand();

                                        AnsiConsole.Write(table);
                                    }
                                }
                            }
                            break;
                            case "Mijozlarni emaili":
                            {
                                Console.Clear();
                                AnsiConsole.Write(
                                new FigletText("Qidirish")
                                .Centered()
                                .Color(Color.BlueViolet));
                                Console.Write("Mijozning ismini kriting: ");
                                string email = Console.ReadLine()!;
                                var table = new Table();
                                for(int i = 0; i < persons.Count; i++)
                                {
                                    if(email == persons[i].Email)
                                    {
                                        table.AddColumn("[yellow]FirstName[/]");
                                        table.AddColumn("[yellow]LastName[/]");
                                        table.AddColumn("[yellow]Email[/]");

                                        table.AddRow(persons[i].FirstName, persons[i].LastName, persons[i].Email);

                                        table.Border = TableBorder.Square;
                                        table.Centered();
                                        table.Expand();

                                        AnsiConsole.Write(table);
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
                break;
                case "Eng muhim savdolarni ko'rsatish va savdolarni daromad bo'yicha saralash.":
                {
                    Console.Clear();
                    var table = new Table();
                    table.AddColumn("[green]ID[/]");
                    table.AddColumn("[green]Companuy[/]");
                    table.AddColumn("[green]Increment[/]");

                    table.AddRow("1", "Walmart", "$600.11 billion");
                    table.AddRow("2", "Amazon", "502.19 billion");
                    table.AddRow("3", "China Petroleum", "$486.84 billion");
                    table.AddRow("4", "PetroChina", "$486.40 billion");
                    table.AddRow("5", "Apple", "$394.34 billion");
                    table.AddRow("6", "Exxon Mobil", "$386.83 billion");
                    table.AddRow("7", "Shell", "$365.29 billion");
                    table.AddRow("8", "UnitedHealth Group", "$324.16 billion");
                    table.AddRow("9", "CVS Health", "$315.20 billion");
                    table.AddRow("10", "Volkswagen", "$303.20 billion");


                    AnsiConsole.Write(table);
                    Console.WriteLine();
                    var menu1 = "";
                    while(menu1 != "Exit.")
                    {
                        menu1 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .PageSize(10)
                        .MoreChoicesText("[grey]()[/]")
                        .AddChoices(new[] {
                        
                            "Exit.",
                        }));
                    }
                }
                break;
            
            }

        }
    }

    private static void ViewSellers()
    {
        if(customers.Count > 0)
        {
            AnsiConsole.Write(
            new FigletText("View Sellers")
            .Centered()
            .Color(Color.Blue));

            SellersPerons();

            Console.Write("Yangilamoqchi bo'lgan savdogarni ID sini kiting: ");
            int PersonRemove = Convert.ToInt32(Console.ReadLine()!);
            for(int i = 0; i < persons.Count; i++)
            {
                if(PersonRemove > 0 && PersonRemove <= persons.Count)
                {
                    Console.Write("Savdogarni Ismini kiriting: ");
                    string ism = Console.ReadLine()!;
                    Console.Write("Savdogarni familiyasi kiriting: ");
                    string familiyasi = Console.ReadLine()!;
                    Console.Write("Savdogarni telefon raqamini kriting(format +998-XX-XXX-XX-XX): ");
                    string savdogaraqam = Console.ReadLine()!;
                    Regex regex = new Regex(@"^\+998-\d{2}-\d{3}-\d{2}-\d{2}");

                    if(regex.IsMatch(savdogaraqam))
                    {
                        customers[i].SellersFirstName = ism;
                        customers[i].SellersLastName = familiyasi;
                        customers[i].SellersEmail = savdogaraqam;
                        AnsiConsole.Status()
                        .Start("Removing...", ctx => 
                        {
                            AnsiConsole.MarkupLine("");
                            Thread.Sleep(1000);
                            
                            
                            ctx.Status("Successfully");
                            ctx.Spinner(Spinner.Known.Star);
                            ctx.SpinnerStyle(Style.Parse("green"));

                            
                            Thread.Sleep(2000);
                            Console.Clear();
                        });
                    }
                    else
                    {
                        AnsiConsole.Status()
                        .Start("Removing...", ctx => 
                        {
                            AnsiConsole.MarkupLine("");
                            Thread.Sleep(1000);
                            
                            
                            ctx.Status("Error");
                            ctx.Spinner(Spinner.Known.Star);
                            ctx.SpinnerStyle(Style.Parse("red"));

                            
                            Thread.Sleep(2000);
                            Console.Clear();
                        });
                    }
                    
                }
            }
        }
        else
        {
            AnsiConsole.Status()
            .Start("Thinking...", ctx => 
            {
                AnsiConsole.MarkupLine("");
                Thread.Sleep(1000);
                
                
                ctx.Status("Error");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("red"));

                
                AnsiConsole.MarkupLine("");
                Thread.Sleep(2000);
            });
        }
    }

    private static void DeleteSellers()
    {
        if(customers.Count > 0)
        {
            AnsiConsole.Write(
                new FigletText("Delet Sellers")
                .Centered()
                .Color(Color.Blue));

                SellersPerons();

                Console.Write("O'chirish uchun ID raqamini kriting: ");
                int PersonNumber = Convert.ToInt32(Console.ReadLine());
                if(PersonNumber > 0 && PersonNumber <= customers.Count)
                {
                    customers.RemoveAt(PersonNumber-1);
                    AnsiConsole.Status()
                            .Start("Deleting...", ctx => 
                            {
                                AnsiConsole.MarkupLine("");
                                Thread.Sleep(1000);
                                
                                
                                ctx.Status("Successfully");
                                ctx.Spinner(Spinner.Known.Star);
                                ctx.SpinnerStyle(Style.Parse("green"));

                                
                                Thread.Sleep(2000);
                                Console.Clear();
                            });
                    
                }
                else
                {
                    AnsiConsole.Status()
                    .Start("Deleting...", ctx => 
                    {
                        AnsiConsole.MarkupLine("");
                        Thread.Sleep(1000);
                        
                        
                        ctx.Status("Error.");
                        ctx.Spinner(Spinner.Known.Star);
                        ctx.SpinnerStyle(Style.Parse("red"));

                        
                        Thread.Sleep(2000);
                        Console.Clear();
                    });
                    
                }
        }
        else
        {
            AnsiConsole.Status()
            .Start("Thinking...", ctx => 
            {
                AnsiConsole.MarkupLine("");
                Thread.Sleep(1000);
                
                
                ctx.Status("Error");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("red"));

                
                AnsiConsole.MarkupLine("");
                Thread.Sleep(2000);
            });
        }
    }

    private static void ViewPerons()
    {
        if(persons.Count > 0)
        {
            AnsiConsole.Write(
            new FigletText("View Persons")
            .Centered()
            .Color(Color.Blue));

            PersonsTable();

            Console.Write("Yangilamoqchi bo'lgan mijozni ID sini kiting: ");
            int PersonRemove = Convert.ToInt32(Console.ReadLine()!);
            for(int i = 0; i < persons.Count; i++)
            {
                if(PersonRemove > 0 && PersonRemove <= persons.Count)
                {
                    Console.Write("Mijozning Ismini kiriting: ");
                    string ism = Console.ReadLine()!;
                    Console.Write("Mijozning familiyasi kiriting: ");
                    string familiyasi = Console.ReadLine()!;
                    Console.Write("Mijozning Email adresini kiriting: ");
                    string emails = Console.ReadLine()!;

                    persons[i].FirstName = ism;
                    persons[i].LastName = familiyasi;
                    persons[i].Email = emails;
                    AnsiConsole.Status()
                    .Start("Removing...", ctx => 
                    {
                        AnsiConsole.MarkupLine("");
                        Thread.Sleep(1000);
                        
                        
                        ctx.Status("Successfully");
                        ctx.Spinner(Spinner.Known.Star);
                        ctx.SpinnerStyle(Style.Parse("green"));

                        
                        Thread.Sleep(2000);
                        Console.Clear();
                    });
                    
                }
            }
        }
        else
        {
            AnsiConsole.Status()
            .Start("Thinking...", ctx => 
            {
                AnsiConsole.MarkupLine("");
                Thread.Sleep(1000);
                
                
                ctx.Status("Error");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("red"));

                
                AnsiConsole.MarkupLine("");
                Thread.Sleep(2000);
            });
        }

    }

    private static void DeletePesons()
    {
        if(persons.Count > 0)
        {
            AnsiConsole.Write(
                new FigletText("Delet Persons")
                .Centered()
                .Color(Color.Blue));

                PersonsTable();

                Console.Write("O'chirish uchun ID raqamini kriting: ");
                int PersonNumber = Convert.ToInt32(Console.ReadLine());
                if(PersonNumber > 0 && PersonNumber <= persons.Count)
                {
                    persons.RemoveAt(PersonNumber-1);
                    AnsiConsole.Status()
                            .Start("Deleting...", ctx => 
                            {
                                AnsiConsole.MarkupLine("");
                                Thread.Sleep(1000);
                                
                                
                                ctx.Status("Successfully");
                                ctx.Spinner(Spinner.Known.Star);
                                ctx.SpinnerStyle(Style.Parse("green"));

                                
                                Thread.Sleep(2000);
                                Console.Clear();
                            });
                    
                }
                else
                {
                    AnsiConsole.Status()
                    .Start("Deleting...", ctx => 
                    {
                        AnsiConsole.MarkupLine("");
                        Thread.Sleep(1000);
                        
                        
                        ctx.Status("Error.");
                        ctx.Spinner(Spinner.Known.Star);
                        ctx.SpinnerStyle(Style.Parse("red"));

                        
                        Thread.Sleep(2000);
                        Console.Clear();
                    });
                
                }
        }
        else
        {
            AnsiConsole.Status()
            .Start("Thinking...", ctx => 
            {
                AnsiConsole.MarkupLine("");
                Thread.Sleep(1000);
                
                
                ctx.Status("Error");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("red"));

                
                AnsiConsole.MarkupLine("");
                Thread.Sleep(2000);
            });
        }
    }

    private static void SellersPerons()
    {
        var table = new Table();
        for(int i = 0; i < customers.Count; i++)
            {  
                
                table.AddColumn("[yellow]ID[/]");
                table.AddColumn("[yellow]FirstName[/]");
                table.AddColumn("[yellow]LastName[/]");
                table.AddColumn("[yellow]PhoneNumber[/]");

                table.AddRow($"{i+1}",customers[i].SellersFirstName, customers[i].SellersLastName, customers[i].SellersEmail);

                table.Border = TableBorder.Square;
                table.Centered();
                table.Expand();

            }
            AnsiConsole.Write(table);
        
    }

    private static void PersonsTable()
    { 
        var table = new Table();
        for(int i = 0; i < persons.Count; i++)
            {  
                
                table.AddColumn("[yellow]ID[/]");
                table.AddColumn("[yellow]FirstName[/]");
                table.AddColumn("[yellow]LastName[/]");
                table.AddColumn("[yellow]Email[/]");

                table.AddRow($"{i+1}",persons[i].FirstName, persons[i].LastName, persons[i].Email);

                table.Border = TableBorder.Square;
                table.Centered();
                table.Expand();

            }
            AnsiConsole.Write(table);
        
    }

    private static void AddPersons()
    {
        Console.Clear();
        AnsiConsole.Write(
        new FigletText("Mijorlarni qoshish")
        .Centered()
        .Color(Color.BlueViolet));
        Console.Write("Mijozning Ismini kiriting: ");
        string ism = Console.ReadLine()!;
        Console.Write("Mijozning familiyasi kiriting: ");
        string familiyasi = Console.ReadLine()!;
        Console.Write("Mijozning Email adresini kiriting: ");
        string emails = Console.ReadLine()!;

        Console.Clear();

        if(ism.Trim().Length > 0 && familiyasi.Trim().Length > 0 && emails.Trim().Length > 0)
        {
            persons.Add(new Person(ism, familiyasi, emails));
            AnsiConsole.Status()
            .Start("Thinking...", ctx => 
            {
                AnsiConsole.MarkupLine("");
                Thread.Sleep(1000);
                
                
                ctx.Status("Successfully added");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("green"));

                
                AnsiConsole.MarkupLine("");
                Thread.Sleep(2000);
            });

            Console.Clear();
        }
    }

    private static void AddSell()
    {
        Console.Write("Savdogarni ismini kiriting: ");
        string savdogarismi = Console.ReadLine()!;
        Console.Write("Savdogarni familiyasini kiriting: ");
        string savdogarfamiliyasi = Console.ReadLine()!;
        Console.Write("Savdogarni telefon raqamini kriting(format +998-XX-XXX-XX-XX): ");
        string savdogaraqami = Console.ReadLine()!;
        Regex regex = new Regex(@"^\+998-\d{2}-\d{3}-\d{2}-\d{2}");

        Console.Clear();

        if(regex.IsMatch(savdogaraqami) && savdogarismi.Trim().Length > 0 && savdogarfamiliyasi.Trim().Length > 0)
        {
            customers.Add(new Customer(savdogaraqami, savdogarfamiliyasi, savdogarismi));
            AnsiConsole.Status()
            .Start("Thinking...", ctx => 
            {
                AnsiConsole.MarkupLine("");
                Thread.Sleep(1000);
                
                
                ctx.Status("Successfully added");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("green"));

                
                AnsiConsole.MarkupLine("");
                Thread.Sleep(2000);
            });

            Console.Clear();

        }
        else
        {
            AnsiConsole.Status()
            .Start("Thinking...", ctx => 
            {
                ctx.Status("Successfully added");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("green"));
            });
            Console.Clear();
        }
    }
}

class Person
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}

    public Person(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}

class Customer
{
    public string SellersFirstName {get; set;}
    public string SellersLastName {get; set;}
    public string SellersEmail {get; set;}
    public Customer(string sellersEmail, string sellerslastName, string sellerfirstName)
    {
        SellersFirstName = sellerfirstName;
        SellersLastName = sellerslastName;
        SellersEmail = sellersEmail;
    }
}

// class Program
// {
//     public static void Main()
//     {
//         var table = new Table();

//         // Add some columns
//         table.AddColumn("Foo");
//         table.AddColumn(new TableColumn("Bar").Centered());

//         // Add some rows
//         table.AddRow("Baz", "[green]Qux[/]");
//         table.AddRow(new Markup("[blue]Corgi[/]"), new Panel("Waldo"));

//         // Render the table to the console
//         AnsiConsole.Write(table);
//     }
// }