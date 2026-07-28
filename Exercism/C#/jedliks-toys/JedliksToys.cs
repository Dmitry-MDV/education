class RemoteControlCar {

    private int batteryCharge = 100;
    private int drivenDistance = 0;

    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {drivenDistance} meters";

    public string BatteryDisplay() => batteryCharge > 0 ? $"Battery at {batteryCharge}%" : "Battery empty";

    public void Drive() {
        if (batteryCharge < 1) {
            return;
        }
        --batteryCharge;
        drivenDistance += 20;
    }

}
