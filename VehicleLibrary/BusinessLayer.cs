using System;
using System.Collections.Generic;

public class BusinessLayer
{
    private readonly DataAccessLayer dataAccessLayer;

    public BusinessLayer()
    {
        dataAccessLayer = new DataAccessLayer();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        ValidateVehicleData(vehicle);
        dataAccessLayer.AddVehicle(vehicle);
    }

    public void EditVehicle(Vehicle vehicle)
    {
        ValidateVehicleData(vehicle);
        dataAccessLayer.EditVehicle(vehicle);
    }

    public List<Vehicle> GetAllVehicles()
    {
        return dataAccessLayer.GetAllVehicles();
    }

    public void DeleteVehicle(int vehicleId)
    {
        dataAccessLayer.DeleteVehicle(vehicleId);
    }

    private void ValidateVehicleData(Vehicle vehicle)
    {
        if (string.IsNullOrEmpty(vehicle.Make))
        {
            throw new ArgumentException("Make is required.");
        }

        if (string.IsNullOrEmpty(vehicle.Model))
        {
            throw new ArgumentException("Model is required.");
        }

        if (string.IsNullOrEmpty(vehicle.Type))
        {
            throw new ArgumentException("Type is required.");
        }

        if (vehicle.Year <= 0)
        {
            throw new ArgumentException("Invalid year.");
        }
    }
}
