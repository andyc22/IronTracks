using System.Collections.Generic;

namespace PTCGLDeckTracker.Gameplay
{
    public class Attack
    {
        public string Name { get; }
        public int Damage { get; }
        public int EnergyCost { get; }

        public Attack(string name, int damage, int energyCost)
        {
            Name = name;
            Damage = damage;
            EnergyCost = energyCost;
        }
    }
}
