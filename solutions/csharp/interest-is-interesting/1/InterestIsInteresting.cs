static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0.0m) {
            // 3.213% for a negative balance (balance gets more negative)
            return 3.213f;
        } else if (balance >= 0.0m && balance < 1000.0m) {
            // 0.5% for a positive balance less than 1000 dollars
            return 0.5f;
        } else if (balance >= 1000.0m && balance < 5000.0m) {
            // 1.621% for a positive balance greater than or equal to 1000 dollars and less than 5000 dollars
            return 1.621f;
        } else {
            // if (balance >= 5000.0m)
            // 2.475% for a positive balance greater than or equal to 5000 dollars
            return 2.475f;
        }
    }

    public static decimal Interest(decimal balance) => (decimal)SavingsAccount.InterestRate(balance) * balance / 100.0m;

    public static decimal AnnualBalanceUpdate(decimal balance) => SavingsAccount.Interest(balance) + balance;

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance) {
        decimal balanceUpdate = balance;
        int yearsCount = 0;
        while (balanceUpdate < targetBalance)
        {
            balanceUpdate = SavingsAccount.AnnualBalanceUpdate(balanceUpdate);
            yearsCount += 1;
        }
        return yearsCount;
    }

}
