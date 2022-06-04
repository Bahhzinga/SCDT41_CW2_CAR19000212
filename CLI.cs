using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCDT41_CW2
{
    internal class CLI
    {
        public static Double balance = 1000;

        private static List<String> commands = new List<string> { 
        
            "Shaun's Cleaning Services // Property Management Interface",
            "",
            "(1). Book a service",
            "(2). Manage a booking",
            "(3). Purchase materials",
            "(4). Performance review",
            "(5). Complete a service"

        };

        public static void startScreen()
        {

            // Display available commands (Yassify the console)
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < commands.Count; i++)
            {
                Console.WriteLine(commands[i]);
            }
            Console.WriteLine("");  // One-line buffer, improves readability in CLI

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Active services: " + Program.services.Count);

            // Display all services using GetInfo()
            for (int i = 0;i< Program.services.Count; i++)
            {
                Service.GetInfo(Program.services[i]);
            }

            // Check for inputs
            do
            {
                switch (Console.ReadLine())
                {
                    case "1":

                        string firstname, surname, staffID, address, phoneNumber;
                        double totalCost;
                        Service.PropertyType propertyType;
                        Service.ServiceType serviceType;

                        // Prompt user to input requirements for service
                        Console.WriteLine("(New Service) Please enter the requirements of this service:");
                        Console.WriteLine("------------------------------------------------------------");
                        Console.WriteLine("(1). Please enter the client's firstname below.");
                        firstname = Console.ReadLine();
                        Console.WriteLine("(2). Please enter the client's surname below.");
                        surname = Console.ReadLine();
                        Console.WriteLine("(3). Please enter your eight digit staff ID.");
                        staffID = Console.ReadLine();
                        Console.WriteLine("(4). Please enter the client's address.");
                        address = Console.ReadLine();
                        Console.WriteLine("(5). Please enter the client's phone number.");
                        phoneNumber = Console.ReadLine();
                        Console.WriteLine("(6). Please enter the cost to the client.");
                        totalCost = Double.Parse(Console.ReadLine());
                        Console.WriteLine("(7). Please enter the type of property - COMMERCIAL or DOMESTIC.");
                        propertyType = (Service.PropertyType) Enum.Parse(typeof(Service.PropertyType), Console.ReadLine());
                        Console.WriteLine("(8). Please enter the type of service - COSMETIC: Vacuuming, Mopping, Dusting. DAMAGE: Water, Fire, Smoke.");
                        serviceType = (Service.ServiceType)Enum.Parse(typeof(Service.ServiceType), Console.ReadLine());
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Green;

                        // Add service to list
                        Service.AddService(new Service(firstname, surname, staffID, address, phoneNumber, totalCost, propertyType, serviceType));

                        // Notify user
                        for (int i = 0;i< 32;i++)
                        {
                            Console.WriteLine("");
                        }
                        Console.WriteLine($"(Service Added) Successfully added new service for client {firstname} {surname} at {address}.\n\n\n");

                        startScreen();
                        break;

                    case "2":
                        Console.WriteLine("$(Service Management) Please enter the service ID of the service you'd like to update.");

                        for (int i = 0;i< Program.services.Count; i++)
                        {
                            string input = Console.ReadLine();
                            if (Program.services[i].serviceID == Guid.Parse(input))
                            {
                                Service service = Program.services[i];

                                Console.WriteLine($"(Service Management) You are updating Service #{service.serviceID}, please enter one of the following options and a corresponding value:");
                                Console.WriteLine("-----------------------------------------------");
                                Console.WriteLine($"(1). Update the client's firstname ({service.firstName})");
                                Console.WriteLine($"(2). Update the client's surname  ({service.lastName})");
                                Console.WriteLine($"(3). Update the staff member's ID ({service.staffId})");
                                Console.WriteLine($"(4). Update the client's address ({service.address})");
                                Console.WriteLine($"(5). Update the client's telephone number ({service.phoneNumber})");
                                Console.WriteLine($"(6). Update the client's cost ({service.totalCost})");
                                Console.WriteLine($"(7). Update the client's property type ({service.property.ToString()})");
                                Console.WriteLine($"(8). Update the client's service type ({service.typeOfService.ToString()})");

                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        service.firstName = Console.ReadLine();
                                        Console.WriteLine($"(Updated #{service.serviceID}) Changed client's firstname to {service.firstName}");
                                        startScreen();
                                        break;
                                    case "2":
                                        service.lastName = Console.ReadLine();
                                        Console.WriteLine($"(Updated #{service.serviceID}) Changed client's lastname to {service.lastName}");
                                        startScreen();
                                        break;
                                    case "3":
                                        service.staffId = Console.ReadLine();
                                        Console.WriteLine($"(Updated #{service.serviceID}) Changed staff ID to {service.staffId}");
                                        startScreen();
                                        break;
                                    case "4":
                                        service.address = Console.ReadLine();
                                        Console.WriteLine($"(Updated #{service.serviceID}) Changed client's address to {service.address}");
                                        startScreen();
                                        break;
                                    case "5":
                                        service.phoneNumber = Console.ReadLine();
                                        Console.WriteLine($"(Updated #{service.serviceID}) Changed client's phone number to {service.phoneNumber}");
                                        startScreen();
                                        break;
                                    case "6":
                                        service.totalCost = Double.Parse(Console.ReadLine());
                                        Console.WriteLine($"(Updated #{service.serviceID}) Changed client's total cost to {service.totalCost}");
                                        startScreen();
                                        break;
                                    case "7":
                                        service.property = (Service.PropertyType)Enum.Parse(typeof(Service.PropertyType), Console.ReadLine());
                                        Console.WriteLine($"(Updated #{service.serviceID}) Changed client's property type to {service.property.ToString()}");
                                        startScreen();
                                        break;
                                    case "8":
                                        service.property = (Service.PropertyType)Enum.Parse(typeof(Service.ServiceType), Console.ReadLine());
                                        Console.WriteLine($"(Updated #{service.serviceID}) Changed client's service type to {service.typeOfService.ToString()}");
                                        startScreen();
                                        break;
                                }

                            }
                        }

                        break;
                    case "3":
                        Console.WriteLine("(Stock Management) Your current balance is £{balance}.");
                        Console.WriteLine("(Stock Management) Please enter one of the following materials: ");
                        Console.WriteLine("");
                        Console.WriteLine("(1). Steel (£200.00)\n(2). Timber (£50.00)\n(3). Concrete (£100.00)");

                        if (Console.ReadLine() == "1")
                        {
                            Console.WriteLine($"You've purchased Steel for £200.00, you now have £{balance} remaining.");
                            balance = balance - 200;
                            startScreen();
                        } else if (Console.ReadLine() == "2")
                        {
                            Console.WriteLine($"You've purchased Timber for £50.00, you now have £{balance} remaining.");
                            balance = balance - 50;
                            startScreen();
                        } else if (Console.ReadLine() == "3")
                        {
                            Console.WriteLine($"You've purchased Concrete for £100.00, you now have £{balance} remaining.");
                            balance = balance - 100;
                            startScreen();
                        }

                        break;
                    case "4":

                        // Loop through all services
                        for (int i = 0; i < Program.services.Count; i++)
                        {
                            for (int f = 0; f < Service.GetInfo(Program.services[i]).Count; f++)
                            {
                                Console.WriteLine(Service.GetInfo(Program.services[i])[f]);
                            }
                        }

                        Console.WriteLine("(Performance Review) Please enter one of the above Service IDs to view a performance review.");
                        for (int i = 0; i < Program.services.Count; i++)
                        {
                            string input = Console.ReadLine();
                            if (Program.services[i].serviceID == Guid.Parse(input))
                            {
                                Service service = Program.services[i];

                                Console.WriteLine($"(Service #{service.serviceID.ToString()}) Started on {service.dateTime.ToString()}, finished {DateTime.Now.ToString()}.");

                            }
                        }
                        break;
                    case "5":

                        for (int i = 0; i < Program.services.Count; i++)
                        {
                            string input = Console.ReadLine();
                            if (Program.services[i].serviceID == Guid.Parse(input))
                            {
                                Service service = Program.services[i];
                                service.status = "closed";
                                Console.WriteLine($"(Service #{service.serviceID.ToString()}) Set service status to closed.");
                            }
                        }

                        break;
                }


            } while (Console.ReadLine() != "exit");
        }




    }
}
