class RemoteControlCar {

  private int batteryCharge = 100;
  private int drivenDistance = 0;

    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {drivenDistance} meters";

    public string BatteryDisplay()
    {
        //
    if (batteryCharge == 0) {
      return "Battery empty";
    } else {
      return $"Battery at {batteryCharge}%";
    }
    }

    public void Drive()
    {
    if (batteryCharge == 0) {
      return;
    }
    --batteryCharge;
    drivenDistance += 20;
    }

}
