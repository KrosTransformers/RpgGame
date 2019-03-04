namespace RpgGame
{

    /// <summary>
    /// Class representing potion to restore health.
    /// </summary>
    class Potion
    {

        /// <summary>
        /// Name of the potion.
        /// </summary>
        private string _name = "Medium potion";

        /// <summary>
        /// Maximum amount of HP this potion could restore.
        /// </summary>
        private int _maxHealedHp = 55;

        /// <summary>
        /// Returns potion's description.
        /// </summary>
        /// <returns>Potion's description.</returns>
        public string DescribeMe()
        {
            return "Potion\n" +
                  $"Name:  {_name}\n" +
                  $"Heals: {_maxHealedHp} HP\n";
        }

    }

}