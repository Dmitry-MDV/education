class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] {0, 2, 5, 3, 7, 8, 4};

    public int Today() => birdsPerDay[birdsPerDay.GetUpperBound(0)];

    public void IncrementTodaysCount() {
        ++birdsPerDay[birdsPerDay.GetUpperBound(0)];
    }

    public bool HasDayWithoutBirds() {
        foreach (int count in birdsPerDay) {
            if (count == 0) {
                return true;
            }
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int count = 0;
        if (numberOfDays > birdsPerDay.GetLength(0)) {
            numberOfDays = birdsPerDay.GetLength(0);
        }
        if (numberOfDays < 0) {
            numberOfDays = 0;
        }

        for (int i = 0;i < numberOfDays;++i) {
            count += birdsPerDay[i];
        }
        return count;
    }

    public int BusyDays()
    {
        int busyDays = 0;
        foreach (int count in birdsPerDay) {
            if (count >= 5) {
                ++busyDays;
            }
        }
        return busyDays;
    }
}
