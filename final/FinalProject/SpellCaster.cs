using System;
using System.Collections.Generic;
using System.IO;

namespace DnDSpellCaster
{
    public class SpellCaster
    {
        public string Name { get; private set; }
        public int AttackModifier { get; private set; }
        private SpellBook spellBook = new SpellBook();

        public SpellCaster(string name)
        {
            Name = name;
            AttackModifier = 0;
        }

        public void AddSpellToBook(Spell spell)
        {
            spellBook.AddSpell(spell);
        }

        public void CastSpell(string spellName)
        {
            Spell spell = spellBook.GetSpells().Find(s => s.Name == spellName);
            if (spell != null)
            {
                if (spell is AttackSpell attackSpell)
                {
                    Console.Write("Enter damage modifier: ");
                    int damageModifier = int.Parse(Console.ReadLine());
                    attackSpell.SetModifiers(AttackModifier, damageModifier);
                    attackSpell.Cast();
                }
                else if (spell is SaveSpell saveSpell)
                {
                    Console.Write("Enter damage modifier: ");
                    int damageModifier = int.Parse(Console.ReadLine());
                    saveSpell.SetModifiers(damageModifier);
                    saveSpell.Cast();
                }
                else if (spell is Healing healingSpell)
                {
                    Console.Write("Enter healing modifier: ");
                    int healingModifier = int.Parse(Console.ReadLine());
                    healingSpell.SetModifiers(healingModifier);
                    healingSpell.Cast();
                }
            }
            else
            {
                Console.WriteLine($"Spell '{spellName}' not found in the spell book.\n");
            }
        }

        public void DisplaySpells()
        {
            spellBook.DisplaySpells();
        }

        public void SaveSpellBook(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(AttackModifier);
                spellBook.SaveToFile(filename);
            }
        }

        public void LoadSpellBook(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                AttackModifier = int.Parse(reader.ReadLine());
                spellBook.LoadFromFile(filename);
            }
        }

        public void DisplayAttackModifier()
        {
            Console.WriteLine($"Attack Modifier: {AttackModifier}\n");
        }

        public void SetAttackModifier(int modifier)
        {
            AttackModifier = modifier;
            Console.WriteLine($"Attack Modifier set to: {AttackModifier}\n");
        }
    }
}
