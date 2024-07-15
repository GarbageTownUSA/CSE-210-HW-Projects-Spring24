using System;

namespace DnDSpellCaster
{
    public class AttackSpell : Spell
    {
        public string DamageDie { get; private set; }
        private int _attackModifier;
        private int _damageModifier;

        public AttackSpell(string name, string damageDie) : base(name)
        {
            DamageDie = damageDie;
        }

        public void SetModifiers(int attackModifier, int damageModifier)
        {
            _attackModifier = attackModifier;
            _damageModifier = damageModifier;
        }

        public override void Cast()
        {
            int attackRoll = DieRoll.Roll("1d20") + _attackModifier;
            int damageRoll = DieRoll.Roll(DamageDie) + _damageModifier;
            Console.WriteLine($"Casting {Name}: Attack Roll = {attackRoll}, Damage Roll = {damageRoll}\n");
        }
    }
}
