using System.Collections.Generic;

namespace PTCGLDeckTracker.Gameplay
{
    public class Attack
    {
        public string Name { get; }
        public int Damage { get; }
        public int EnergyCost { get; }

        /// <summary>
        /// Energy type used for this attack, e.g. "Fire".
        /// </summary>
        public string Type { get; }

        public Attack(string name, int damage, int energyCost, string type = "")
        {
            Name = name;
            Damage = damage;
            EnergyCost = energyCost;
            Type = type;
        }
    }
}
