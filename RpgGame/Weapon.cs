namespace RpgGame
{

    /// <summary>
    /// Class representing weapon to fight enemies with.
    /// </summary>
    class Weapon
    {

        /// <summary>
        /// Weapon name/description.
        /// </summary>
        private string _name = "Widomaker";

        /// <summary>
        /// Weapon type.
        /// </summary>
        private eWeaponType _type = eWeaponType.Sword;

        /// <summary>
        /// Minimum amount of damage this weapon cen inflict.
        /// </summary>
        private int _minDamage = 10;

        /// <summary>
        /// Maximum amount of damage this weapon can inflict.
        /// </summary>
        private int _maxDamage = 18;

        /// <summary>
        /// Returns weapon's description.
        /// </summary>
        /// <returns>Weapon's description.</returns>
        public string DescribeMe()
        {
            return "Weapon\n" +
                  $"Name:       {_name}\n" +
                  $"Type:       {_type}\n" +
                  $"Min damage: {_minDamage}\n" +
                  $"Max damage: {_maxDamage}\n";
        }

    }

    /// <summary>
    /// Enumeration of weapon types.
    /// </summary>
    enum eWeaponType
    {
        None = 0,
        Dagger = 1,
        Sword = 2,
        Axe = 3,
        Staff = 4,
        Bow = 5,
        Crossbow = 6
    }

}