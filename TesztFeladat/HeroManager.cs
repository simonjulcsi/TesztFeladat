namespace TesztFeladat
{
    internal static class HeroManager
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// Return a random HeroClass (ijasz, kardos or lovas).
        /// </summary>
        /// <returns></returns>
        internal static HeroClass GetRandomHeroClass()
        {
            var values = Enum.GetValues(typeof(HeroClass));
            return (HeroClass)values.GetValue(random.Next(values.Length));
        }

        /// <summary>
        /// Return a random Hero from a list of heroes.
        /// </summary>
        /// <param name="heroes"></param>
        /// <returns></returns>
        internal static Hero GetRandomHero(List<Hero> heroes)
        {
            return heroes[random.Next(heroes.Count)];
        }

        /// <summary>
        /// Return true if the attack is successful. The attack success is 60%.
        /// </summary>
        /// <returns></returns>
        internal static bool IsAttackSuccessful()
        {
            return random.NextDouble() < 0.6;
        }
    }
}
