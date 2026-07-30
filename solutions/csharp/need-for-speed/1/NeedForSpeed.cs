public class RemoteControlCar {

    private int batteryCharge = 100; // the level of the battery charge
    private int batteryDrain;        // the battery drain percentage
    private int carSpeed;            // the speed of the car in meters
    private int distance = 0;        // the number of meters driven based on the car’s speed

    public RemoteControlCar(int carSpeed, int batteryDrain) {
        this.batteryDrain = batteryDrain;
        this.carSpeed = carSpeed;
    }

    public bool BatteryDrained() => batteryCharge < batteryDrain ? true : false;

    public int DistanceDriven() => distance;

    public void Drive() {
        if (!BatteryDrained()) {
            batteryCharge -= batteryDrain;
            distance += carSpeed;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);

}


public class RaceTrack {

    private int distance; // distance - the track’s distance in meters

    public RaceTrack(int distance) {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (car.DistanceDriven() < distance) {
            if (car.BatteryDrained()) {
                return false;
            }
            car.Drive();
        }
        return true;
    }

}
