using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCDT41_CW2
{
    internal class Service
    {
        public enum PropertyType
        {
            COMMERCIAL,
            DOMESTIC
        }

        public enum ServiceType
        {
            VACUUMING,
            MOPPING,
            DUSTING,
            FIRE,
            SMOKE,
            WATER
        }

        // Note: Service ID, Client Firstname, Client Surname, Staff ID, DateTime of appointment, Details of service, Property type, Address, Customer phone number, Total cost

        public Guid serviceID;
        public string firstName, lastName, staffId, address;
        public DateTime dateTime;
        public string phoneNumber;
        public double totalCost;
        public PropertyType property;
        public ServiceType typeOfService;
        public string status;

        public Service(string clientFirstname, string clientLastname, string staffMemberId, string clientAddress, string clientPhoneNumber, double clientCost, PropertyType propertyType, ServiceType serviceType)
        {
            status = "open";
            dateTime = DateTime.Now;
            serviceID = Guid.NewGuid();
            firstName = clientFirstname;
            lastName = clientLastname;
            staffId = staffMemberId;
            address = clientAddress;
            phoneNumber = clientPhoneNumber;
            totalCost = clientCost;
            property = propertyType;
            typeOfService = serviceType;
        }

        public static List<String> GetInfo(Service service)
        {

            List<String> info = new List<String> { 
                $"Service ID: {service.serviceID} ({service.dateTime.ToLongDateString()} {service.dateTime.TimeOfDay.ToString()})", 
                $"",
                $"Client Information:",
                $"- Firstname: {service.firstName}",
                $"- Surname: {service.lastName}",
                $"- Phone Number: {service.phoneNumber}",
                $"- Address: {service.address}",
                $"",
                $"Property Information:",
                $"- Type: {service.property.ToString()}",
                $"- Service: {service.typeOfService.ToString()}",
                $"- Total Cost: {service.totalCost.ToString()}",
                $""

            };
            return info;
        }

        public static void AddService(Service service)
        {
            Console.WriteLine($"Shaun's Cleaning Services // New service added:");
            for (int i = 0; i < GetInfo(service).Count; i++)
            {
                Console.WriteLine(GetInfo(service)[i]);
            }
            Program.services.Add(service);
        }

        public static void DeleteService(Service service)
        {
            Console.WriteLine($"Shaun's Cleaning Services // Deleting service {service.serviceID.ToString()}");
            Program.services.Remove(service);
        }

        public static void UpdateService(Service service, String key, Object value)
        {

            switch (key)
            {
                case "firstname":
                    service.firstName = (String) value; 
                    break;
                case "surname":
                    service.lastName = (String) value;
                    break;
                case "phonenumber":
                    service.phoneNumber = (String) value;
                    break;
                case "address":
                    service.address = (String) value;
                    break;
                case "type":
                    service.property = (PropertyType)value;
                    break;
                case "service":
                    service.typeOfService = (ServiceType)value;
                    break;
                case "totalcost":
                    service.totalCost = (double)value;
                    break;

                Console.WriteLine($"Updated service information {key} to {value}.");
            }
        }
    }
}
