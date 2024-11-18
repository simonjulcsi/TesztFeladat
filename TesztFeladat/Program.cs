using TesztFeladat;

Console.Write("Add meg a hősök számát: ");

if (int.TryParse(Console.ReadLine(), out int number))
{
    List<Hero> heroes = new List<Hero>();
    for (int i = 0; i < number; i++)
    {
        heroes.Add(new Hero(i+1, HeroManager.GetRandomHeroClass()));
    }

    int round = 1;

    Console.WriteLine("---------------------------------------------------------------------------------------------------");

    while (heroes.Count > 1)
    {
        Hero attacker = HeroManager.GetRandomHero(heroes);
        Hero defender;
        do
        {
            defender = HeroManager.GetRandomHero(heroes);
        } while (defender == attacker);

        if (attacker.HeroClass == HeroClass.lovas ||
          (attacker.HeroClass != HeroClass.lovas && defender.HeroClass != HeroClass.lovas))
        {
            defender.IsDead = true;
        }
        else
        {
            if(HeroManager.IsAttackSuccessful())
            {
                defender.IsDead = true;
            }
            else
            {
                defender.TakeDamage();
            }
        }

        attacker.TakeDamage();

        if (attacker.IsDead) heroes.Remove(attacker);
        if (defender.IsDead) heroes.Remove(defender);

        heroes.ForEach(hero => hero.Healing());

        Console.WriteLine($"{round}. kör");
        Console.WriteLine($"támadó: {attacker.Name}");
        Console.WriteLine($"védekező: {defender.Name}");
        Console.WriteLine($"{(attacker.IsDead ? "támadó meghalt" : $"támadó megmaradt életereje: {attacker.CurrHP}")}");
        Console.WriteLine($"{(defender.IsDead ? "védekező meghalt" : $"védekező megmaradt életereje: {defender.CurrHP}")}");
        Console.WriteLine($"{heroes.Count} hős maradt játékban");
        Console.WriteLine("---------------------------------------------------------------------------------------------------");

        round ++;
    }

    if(heroes.Count == 0)
    {
        Console.WriteLine("Nem maradt életben egy hős sem.");
    }
    else
    {
        Console.WriteLine($"A győztes: {heroes[0].Name}, {heroes[0].CurrHP} életerő ponttal.");
    }
}
else
{
    Console.WriteLine("Hiba: Nem számot adtál meg.");
}

Console.WriteLine("\nKilépéshez nyomj meg egy billentyűt.");
Console.ReadKey();
