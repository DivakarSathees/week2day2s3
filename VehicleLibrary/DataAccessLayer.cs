using System;
using System.Collections.Generic;

public class DataAccessLayer
{
    private List<Vehicle> vehicles;

    public DataAccessLayer()
    {
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        int newId = GetNextId();
        vehicle.Id = newId;
        vehicles.Add(vehicle);
    }

    public void EditVehicle(Vehicle vehicle)
    {
        Vehicle existingVehicle = vehicles.Find(v => v.Id == vehicle.Id);
        if (existingVehicle != null)
        {
            existingVehicle.Make = vehicle.Make;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.Type = vehicle.Type;
            existingVehicle.Year = vehicle.Year;
        }
        else
        {
            throw new ArgumentException("Vehicle not found.");
        }
    }

    public List<Vehicle> GetAllVehicles()
    {
        return vehicles;
    }

    public List<Vehicle> FindVehicles(string keyword)
    {
        return vehicles.FindAll(vehicle =>
            vehicle.Make.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
            vehicle.Model.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
            vehicle.Type.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
    }

    public void DeleteVehicle(int vehicleId)
    {
        Vehicle vehicle = vehicles.Find(v => v.Id == vehicleId);
        if (vehicle != null)
        {
            vehicles.Remove(vehicle);
        }
        else
        {
            throw new ArgumentException("Vehicle not found.");
        }
    }

    private int GetNextId()
    {
        return vehicles.Count + 1;
    }
}
