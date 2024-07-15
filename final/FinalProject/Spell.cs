namespace DnDSpellCaster
{
    public abstract class Spell
    {
        public string Name { get; private set; }

        protected Spell(string name)
        {
            Name = name;
        }

        public abstract void Cast();
    }
}
