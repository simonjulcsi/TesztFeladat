namespace TesztFeladat
{
    internal class Hero
    {
        /// <summary>
        /// name of the hero
        /// </summary>
        internal string Name { get; set; }
        /// <summary>
        /// class of the hero
        /// </summary>
        internal HeroClass HeroClass { get; set; }
        /// <summary>
        /// maximum health points of the hero
        /// </summary>
        internal int MaxHP { get; set; }      
        /// <summary>
        /// current health points of the hero
        /// </summary>
        internal int CurrHP { get; set; }
        /// <summary>
        /// minimum health points of the hero
        /// </summary>
        internal int MinHP { get; set; }
        /// <summary>
        /// is the hero dead
        /// </summary>
        internal bool IsDead { get; set; }
        public Hero(int i, HeroClass hc)
        {
            HeroClass = hc;
            Name = $"{i}. hős ({HeroClass})";
            MaxHP = (int)HeroClass;
            CurrHP = MaxHP;
            MinHP = MaxHP / 4;
            IsDead = false;
        }

        /// <summary>
        /// The current HP increases by 10, but not above the maximum HP.
        /// </summary>
        public void Healing()
        {
            CurrHP += 10;
            if (CurrHP > MaxHP) CurrHP = MaxHP;
        }

        /// <summary>
        /// The current HP is reduced by half. If current HP becomes less than minimum HP, the hero dies.
        /// </summary>
        public void TakeDamage()
        {
            CurrHP /= 2;
            IsDead = CurrHP < MinHP;
        }
    }
}
