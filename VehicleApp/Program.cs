using System;
using System.Collections.Generic;

namespace VehicleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BusinessLayer businessLayer = new BusinessLayer();

            while (true)
            {
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Edit Vehicle");
                Console.WriteLine("3. Delete Vehicle");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice (1-4):");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Vehicle newVehicle = GetVehicleDetailsFromUser();
                        businessLayer.AddVehicle(newVehicle);
                        Console.WriteLine("Vehicle added successfully!");
                        Console.WriteLine();
                        break;
                    case "2":
                        List<Vehicle> allVehicles = businessLayer.GetAllVehicles();
                        Console.WriteLine("All Vehicles:");
                        PrintVehicles(allVehicles);
                        Console.WriteLine("Enter the ID of the vehicle to edit:");
                        if (int.TryParse(Console.ReadLine(), out int editId))
                        {
                            Vehicle vehicleToEdit = allVehicles.Find(v => v.Id == editId);
                            if (vehicleToEdit != null)
                            {
                                Vehicle editedVehicle = GetVehicleDetailsFromUser();
                                editedVehicle.Id = vehicleToEdit.Id;
                                businessLayer.EditVehicle(editedVehicle);
                                Console.WriteLine("Vehicle edited successfully!");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Invalid vehicle ID.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid vehicle ID.");
                            Console.WriteLine();
                        }
                        break;
                    case "3":
                        List<Vehicle> vehiclesToDelete = businessLayer.GetAllVehicles();
                        Console.WriteLine("All Vehicles:");
                        PrintVehicles(vehiclesToDelete);
                        Console.WriteLine("Enter the ID of the vehicle to delete:");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            Vehicle vehicleToDelete = vehiclesToDelete.Find(v => v.Id == deleteId);
                            if (vehicleToDelete != null)
                            {
                                businessLayer.DeleteVehicle(vehicleToDelete.Id);
                                Console.WriteLine("Vehicle deleted successfully!");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Invalid vehicle ID.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid vehicle ID.");
                            Console.WriteLine();
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1-4).");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private static Vehicle GetVehicleDetailsFromUser()
        {
            Console.WriteLine("Enter Vehicle Make:");
            string make = Console.ReadLine();
            Console.WriteLine("Enter Vehicle Model:");
            string model = Console.ReadLine();
            Console.WriteLine("Enter Vehicle Type:");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Vehicle Year:");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                return new Vehicle
                {
                    Make = make,
                    Model = model,
                    Type = type,
                    Year = year
                };
            }
            else
            {
                Console.WriteLine("Invalid input. Year must be a numeric value.");
                return null;
            }
        }

        private static void PrintVehicles(List<Vehicle> vehicles)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine($"ID: {vehicle.Id}");
                Console.WriteLine($"Make: {vehicle.Make}");
                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Type: {vehicle.Type}");
                Console.WriteLine($"Year: {vehicle.Year}");
                Console.WriteLine();
            }
        }
    }
}
