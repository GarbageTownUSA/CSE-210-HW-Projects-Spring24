using System;

namespace DnDSpellCaster
{
    public class SaveSpell : Spell
    {
        public string SaveType { get; private set; }
        public string DamageDie { get; private set; }
        private int _damageModifier;

        public SaveSpell(string name, string saveType, string damageDie) : base(name)
        {
            SaveType = saveType;
            DamageDie = damageDie;
        }

        public void SetModifiers(int damageModifier)
        {
            _damageModifier = damageModifier;
        }

        public override void Cast()
        {
            if (DamageDie != null)
            {
                int damageRoll = DieRoll.Roll(DamageDie) + _damageModifier;
                Console.WriteLine($"Casting {Name}: Save Type = {SaveType}, Damage Roll = {damageRoll}\n");
            }
            else
            {
                Console.WriteLine($"Casting {Name}: Save Type = {SaveType}\n");
            }
        }
    }
}
