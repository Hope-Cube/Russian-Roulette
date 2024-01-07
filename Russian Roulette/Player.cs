using System.Collections.Generic;
namespace Russian_Roulette
{
    internal class Player
    {
        private readonly string _name;
        private int _hp;
        private readonly List<Item> _items;
        private readonly short _max_item;
        public Player(string name, int hp, short max_item)
        {
            _name = name;
            _hp = hp;
            _max_item = max_item;
        }
        public string Name => _name;
        public int Hp => _hp;
        public short Max_item => _max_item;
        public List<Item> Items => _items;
        public void TakeDMG(int dmg)
        {
            _hp -= dmg;
        }
        public override string ToString()
        {
            return $"{Name}, {Hp}, {Max_item}, {Items.Count}";
        }
    }
}