using System.Collections.Generic;

namespace Russian_Roulette
{
    internal class ShotHolder
    {
        private readonly int _dmg;
        private readonly List<bool> _shots;
        private bool _isShort = false;
        public int Dmg => _dmg;
        public List<bool> Shots => _shots;
        public bool IsShort => _isShort;
        public ShotHolder(List<bool> shots, int dmg) 
        {
            _shots = shots;
            _dmg = dmg;
        }
        public void Shortened()
        {
            _isShort = true;
        }
        public void Longened()
        {
            _isShort = false;
        }
        public int MinusDmg
        {
            get 
            {
                switch (_isShort)
                {
                    case true: return _dmg;
                    case false: return 2 * _dmg;
                }
                return _dmg; 
            }
        }
        public override string ToString()
        {
            return $"{Shots.Count}, shortened: {IsShort}, dmg: {MinusDmg}";
        }
    }
}