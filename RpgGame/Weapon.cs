namespace RpgGame
{

    /// <summary>
    /// Class representing weapon to fight enemies with.
    /// </summary>
    class Weapon
    {

        #region Attributes

        /// <summary>
        /// Weapon name/description.
        /// </summary>
        private string _name;

        /// <summary>
        /// Weapon type.
        /// </summary>
        private eWeaponType _type;

        /// <summary>
        /// Minimum amount of damage this weapon cen inflict.
        /// </summary>
        private int _minDamage;

        /// <summary>
        /// Maximum amount of damage this weapon can inflict.
        /// </summary>
        private int _maxDamage;

        #endregion

        #region Constructors

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="name">weapon name/description.</param>
        /// <param name="type">Weapon type.</param>
        /// <param name="minDamage">Minimum amount of damage this weapon cen inflict.</param>
        /// <param name="maxDamage">Maximum amount of damage this weapon cen inflict.</param>
        public Weapon(string name, eWeaponType type, int minDamage, int maxDamage)
        {
            _name = name;
            _type = type;
            _minDamage = minDamage;
            _maxDamage = maxDamage;
        }

        #endregion

        #region Methods

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

        #endregion

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