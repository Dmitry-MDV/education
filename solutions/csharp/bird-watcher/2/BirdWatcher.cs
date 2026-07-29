using System;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] {0, 2, 5, 3, 7, 8, 4};

    // birdsPerDay.GetUpperBound(0) | birdsPerDay.GetLength(0) - 1 | только для одномерного массива birdsPerDay.Length - 1 или birdsPerDay[^1]
    public int Today() => birdsPerDay[^1];

    public void IncrementTodaysCount() => ++birdsPerDay[^1];

    public bool HasDayWithoutBirds() => Array.IndexOf(birdsPerDay, 0) >=0 ? true : false;

    public int CountForFirstDays(int numberOfDays) {
        int count = 0;
        if (numberOfDays > birdsPerDay.Length) {
            numberOfDays = birdsPerDay.Length;
        }
        if (numberOfDays <= 0) {
            return -1;
        }
        for (int i = 0;i < numberOfDays;++i) {
            count += birdsPerDay[i];
        }
        return count;
    }

    public int BusyDays() {
        int busyDays = 0;
        foreach (int count in birdsPerDay) {
            if (count >= 5) {
                ++busyDays;
            }
        }
        return busyDays;
    }
}
