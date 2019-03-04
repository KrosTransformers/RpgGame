﻿namespace RpgGame
{
    
    /// <summary>
    /// Class representing hero.
    /// </summary>
    class Hero
    {

        /// <summary>
        /// Hero's name.
        /// </summary>
        private string _name = "Lothar Lightbringer";

        /// <summary>
        /// Hero's race.
        /// </summary>
        private eHeroRace _race = eHeroRace.Human;

        /// <summary>
        /// Hero's class.
        /// </summary>
        private eHeroClass _class = eHeroClass.Paladin;

        /// <summary>
        /// Level.
        /// </summary>
        private int _level = 2;

        /// <summary>
        /// Current health.
        /// </summary>
        private int _health = 100;

        /// <summary>
        /// Maximum health.
        /// </summary>
        private int _maxHealth = 100;

        /// <summary>
        /// Experience points.
        /// </summary>
        private int _xp = 80;

        /// <summary>
        /// Gold.
        /// </summary>
        private int _gold = 250;

        /// <summary>
        /// Minimum amount of attack this monster can inflict.
        /// </summary>
        private int _minAttack = 12;

        /// <summary>
        /// Maximum amount of attack this monster can inflict.
        /// </summary>
        private int _maxAttack = 20;

        /// <summary>
        /// Strength of defense.
        /// </summary>
        private int _defense = 5;

        /// <summary>
        /// Percentual chance to evade incoming attack.
        /// </summary>
        private double _evade = 0.025;

        /// <summary>
        /// Percentual chance to score critical hit.
        /// </summary>
        private double _luck = 0.05;

        /// <summary>
        /// Returns hero's description.
        /// </summary>
        /// <returns>Hero's description.</returns>
        public string DescribeMe()
        {
            return "Hero\n" +
                  $"Name:       {_name}\n" +
                  $"Race:       {_race}\n" +
                  $"Class:      {_class}\n" +
                  $"Level:      {_level}\n" +
                  $"Health:     {_health} HP\n" +
                  $"Gold:       {_gold}\n" +
                  $"Min attack: {_minAttack}\n" +
                  $"Max attack: {_maxAttack}\n" +
                  $"Defense:    {_defense}\n" +
                  $"Evade:      {_evade:0.00%}\n" +
                  $"Luck:       {_luck:0.00%}\n";
        }

    }

    /// <summary>
    /// Enumeration of hero races.
    /// </summary>
    enum eHeroRace
    {
        None = 0,
        Human = 1,
        Dwarf = 2,
        Elf = 3
    }

    /// <summary>
    /// Enumeration of hero class.
    /// </summary>
    enum eHeroClass
    {
        None = 0,
        Paladin = 1,
        Thief = 2,
        Mage = 3
    }

}