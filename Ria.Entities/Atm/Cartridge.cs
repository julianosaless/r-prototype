namespace Ria.Entities.Atm
{
    internal class Cartridge
    {
        public Cartridge(int note)
        {
            Note = note;
        }

        public int Note { get; private set; }
    }
}
