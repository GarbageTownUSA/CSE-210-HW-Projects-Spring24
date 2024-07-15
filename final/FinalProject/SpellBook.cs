using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DnDSpellCaster
{
    public class SpellBook
    {
        private List<Spell> spells = new List<Spell>();

        public void AddSpell(Spell spell)
        {
            spells.Add(spell);
            Console.WriteLine($"Spell '{spell.Name}' added to spell book.\n");
        }

        public void RemoveSpell(Spell spell)
        {
            spells.Remove(spell);
            Console.WriteLine($"Spell '{spell.Name}' removed from spell book.\n");
        }

        public List<Spell> GetSpells()
        {
            return spells;
        }

        public void DisplaySpells()
        {
            if (spells.Count == 0)
            {
                Console.WriteLine("No spells in the spell book.\n");
            }
            else
            {
                Console.WriteLine("Spells in the spell book:");
                foreach (var spell in spells)
                {
                    Console.WriteLine($"- {spell.Name}");
                }
                Console.WriteLine();
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var spell in spells)
                {
                    writer.WriteLine(spell.GetType().Name);
                    writer.WriteLine(spell.Name);

                    if (spell is AttackSpell attackSpell)
                    {
                        writer.WriteLine(attackSpell.DamageDie);
                    }
                    else if (spell is SaveSpell saveSpell)
                    {
                        writer.WriteLine(saveSpell.SaveType);
                        writer.WriteLine(saveSpell.DamageDie ?? string.Empty);
                    }
                    else if (spell is Healing healing)
                    {
                        writer.WriteLine(healing.HealDie);
                    }
                }
            }
        }

        public void LoadFromFile(string filename)
        {
            spells.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string spellType = reader.ReadLine();
                    string name = reader.ReadLine();

                    if (spellType == nameof(AttackSpell))
                    {
                        string damageDie = reader.ReadLine();
                        spells.Add(new AttackSpell(name, damageDie));
                    }
                    else if (spellType == nameof(SaveSpell))
                    {
                        string saveType = reader.ReadLine();
                        string damageDie = reader.ReadLine();
                        spells.Add(new SaveSpell(name, saveType, string.IsNullOrWhiteSpace(damageDie) ? null : damageDie));
                    }
                    else if (spellType == nameof(Healing))
                    {
                        string healDie = reader.ReadLine();
                        spells.Add(new Healing(name, healDie));
                    }
                }
            }
        }
    }
}
