public class Player
{
    private Random random = new();

    public int RollDie() => random.Next(1, 19);

    public double GenerateSpellStrength() => 100.0d * (double)random.NextDouble();

}
