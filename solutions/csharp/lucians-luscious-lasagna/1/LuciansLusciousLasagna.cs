class Lasagna {
    // the expected oven time in minutes - how many minutes the lasagna should be in the oven?
    public int ExpectedMinutesInOven() {
        return 40;
    }

    // the remaining oven time in minutes - how many minutes the lasagna still has to remain in the oven?
    public int RemainingMinutesInOven (int minutesNumber) {
        return this.ExpectedMinutesInOven() - minutesNumber;
    }

    // the preparation time in minutes - how many minutes did it take to cook the lasagna?
    public int PreparationTimeInMinutes(int layersNumber) {
        return 2 * layersNumber;
    }

    // the elapsed time in minutes - time already spent to cooking the lasagna and baking it in the oven
    public int ElapsedTimeInMinutes(int layersNumber, int minutesNumber) {
        return this.PreparationTimeInMinutes(layersNumber) + minutesNumber;
    }
}
