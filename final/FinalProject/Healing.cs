using System;

namespace DnDSpellCaster
{
    public class Healing : Spell
    {
        public string HealDie { get; private set; }
        private int _healingModifier;

        public Healing(string name, string healDie) : base(name)
        {
            HealDie = healDie;
        }

        public void SetModifiers(int healingModifier)
        {
            _healingModifier = healingModifier;
        }

        public override void Cast()
        {
            int healingRoll = DieRoll.Roll(HealDie) + _healingModifier;
            Console.WriteLine($"Casting {Name}: Healing Roll = {healingRoll}\n");
        }
    }
}
