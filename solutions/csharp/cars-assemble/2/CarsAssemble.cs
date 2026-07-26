static class AssemblyLine {

    public static double SuccessRate(int speed) {
        if (speed < 1 || speed > 10) {
            return 0.0;
        } else if (speed < 5) {
            // 1 to 4: 100% success rate
            return 1.0;
        } else if (speed < 9) {
            // 5 to 8: 90% success rate
            return 0.9;
        } else if (speed == 9) {
            // 9: 80% success rate
            return 0.8;
        } else {
            // 10: 77% success rate
            return 0.77;
        }
    }

    public static double ProductionRatePerHour(int speed) => 221 * speed * AssemblyLine.SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) => (int)AssemblyLine.ProductionRatePerHour(speed)/60;

}
