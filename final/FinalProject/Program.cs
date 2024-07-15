using System;

namespace DnDSpellCaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the name of your character: ");
            string characterName = Console.ReadLine();
            SpellCaster spellCaster = new SpellCaster(characterName);

            while (true)
            {
                Console.WriteLine("\n1. Add Spell");
                Console.WriteLine("2. Cast Spell");
                Console.WriteLine("3. Display Spells");
                Console.WriteLine("4. Save Spell Book");
                Console.WriteLine("5. Load Spell Book");
                Console.WriteLine("6. Display Attack Modifier");
                Console.WriteLine("7. Set Attack Modifier");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    Console.Write("Enter spell type (Attack, Save, Healing): ");
                    string spellType = Console.ReadLine();
                    Console.Write("Enter spell name: ");
                    string name = Console.ReadLine();

                    Spell spell = null;

                    switch (spellType.ToLower())
                    {
                        case "attack":
                            Console.Write("Enter damage die (e.g., 2d4, 1d6+1d8): ");
                            string attackDie = Console.ReadLine();
                            spell = new AttackSpell(name, attackDie);
                            break;
                        case "save":
                            Console.Write("Enter save type (e.g., Strength, Dexterity): ");
                            string saveType = Console.ReadLine();
                            Console.Write("Enter damage die (e.g., 2d4, 1d6+1d8) or leave blank if no damage: ");
                            string damageDieInput = Console.ReadLine();
                            string saveDamageDie = string.IsNullOrWhiteSpace(damageDieInput) ? null : damageDieInput;
                            spell = new SaveSpell(name, saveType, saveDamageDie);
                            break;
                        case "healing":
                            Console.Write("Enter healing die (e.g., 2d4, 1d6+1d8): ");
                            string healingDie = Console.ReadLine();
                            spell = new Healing(name, healingDie);
                            break;
                        default:
                            Console.WriteLine("Invalid spell type.\n");
                            break;
                    }

                    if (spell != null)
                    {
                        spellCaster.AddSpellToBook(spell);
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Enter the name of the spell to cast: ");
                    string spellName = Console.ReadLine();
                    spellCaster.CastSpell(spellName);
                }
                else if (choice == "3")
                {
                    spellCaster.DisplaySpells();
                }
                else if (choice == "4")
                {
                    Console.Write("Enter filename to save spell book: ");
                    string filename = Console.ReadLine();
                    spellCaster.SaveSpellBook(filename);
                    Console.WriteLine("Spell book saved.\n");
                }
                else if (choice == "5")
                {
                    Console.Write("Enter filename to load spell book: ");
                    string filename = Console.ReadLine();
                    spellCaster.LoadSpellBook(filename);
                    Console.WriteLine("Spell book loaded.\n");
                }
                else if (choice == "6")
                {
                    spellCaster.DisplayAttackModifier();
                }
                else if (choice == "7")
                {
                    Console.Write("Enter new attack modifier: ");
                    int newModifier = int.Parse(Console.ReadLine());
                    spellCaster.SetAttackModifier(newModifier);
                }
                else if (choice == "8")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.\n");
                }
            }
        }
    }
}
