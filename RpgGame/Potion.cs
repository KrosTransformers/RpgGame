namespace RpgGame
{

    /// <summary>
    /// Class representing potion to restore health.
    /// </summary>
    class Potion
    {

        #region Properties

        /// <summary>
        /// Name of the potion.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Maximum amount of HP this potion could restore.
        /// </summary>
        public int MaxHealedHp { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="name">Name of the potion.</param>
        /// <param name="maxHealedHp">Maximum amount of HP this potion could restore.</param>
        public Potion(string name, int maxHealedHp)
        {
            Name = name;
            MaxHealedHp = maxHealedHp;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns potion's description.
        /// </summary>
        /// <returns>Potion's description.</returns>
        public string DescribeMe()
        {
            return "Potion\n" +
                  $"Name:  {Name}\n" +
                  $"Heals: {MaxHealedHp} HP\n";
        }

        #endregion

    }

}