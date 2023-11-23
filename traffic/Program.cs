using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        Road road = new Road
        {
            Length = random.Next(5, 10),
            Width = random.Next(3, 12),
            NumberOfLanes = random.Next(2, 5),
            TrafficLevel = random.Next(1, 6)
        };

        string[] vehicleTypes = { "Car", "Truck", "Bus" };

        Vehicle car = new Vehicle
        {
            Speed = random.Next(50, 150), 
            Size = 1.5,
            Type = vehicleTypes[random.Next(vehicleTypes.Length)]
        };

        Vehicle truck = new Vehicle
        {
            Speed = random.Next(40, 80),
            Size = 3,
            Type = vehicleTypes[random.Next(vehicleTypes.Length)]
        };

        TrafficSimulation simulation = new TrafficSimulation();
        simulation.SimulateMovement(car, road);
        simulation.SimulateMovement(truck, road);

        TrafficLight[] trafficLights = new TrafficLight[2]
        {
            new TrafficLight(),
            new TrafficLight()
        };

        simulation.OptimizeTraffic(new Vehicle[] { car, truck }, trafficLights);
    }
}
class Road
{
    public double Length { get; set; }
    public double Width { get; set; }
    public int NumberOfLanes { get; set; }
    public int TrafficLevel { get; set; }
}

interface IDriveable
{
    void Move();
    void Stop();
}
class Vehicle : IDriveable
{
    public double Speed { get; set; }
    public double Size { get; set; }
    public string Type { get; set; } = "";

    private bool isMoving;

    public void Move()
    {
        if (!isMoving)
        {
            isMoving = true;
            Console.WriteLine($"{Type} is moving at a speed of {Speed} km/h.");
        }
        else
        {
            Console.WriteLine($"{Type} is already in motion.");
        }
    }

    public void Stop()
    {
        if (isMoving)
        {
            isMoving = false;
            Console.WriteLine($"{Type} has stopped.");
        }
        else
        {
            Console.WriteLine($"{Type} is already stopped.");
        }
    }
}
class TrafficSimulation
{
    public void SimulateMovement(Vehicle vehicle, Road road)
    {
        Console.WriteLine($"Simulating movement of {vehicle.Type} on a road with {road.NumberOfLanes} lanes and traffic level {road.TrafficLevel}.");
        vehicle.Move();
    }

    public void OptimizeTraffic(Vehicle[] vehicles, TrafficLight[] trafficLights)
    {
        foreach (var light in trafficLights)
        {
            if (light.IsRed)
            {
                light.ChangeLight();
                Console.WriteLine("Traffic light changed to green.");
            }
        }
    }
}
class TrafficLight
{
    public bool IsGreen { get; set; }
    public bool IsRed { get; set; }

    public void ChangeLight()
    {
        IsGreen = !IsGreen;
        IsRed = !IsRed;
    }
}
