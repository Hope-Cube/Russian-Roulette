using ConsoleMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleMenu.Menu;
using static System.Console;

namespace Russian_Roulette
{
    internal class Game
    {
        private readonly ShotHolder _shotholder;
        private readonly bool _isPvP;
        private readonly Player _p1;
        private readonly Player _p2;
        public Game() 
        {
            MenuRun menuRun;
            var playmenu = new Menu(1, 0, '>', "PlayTime!", new string[] { "Easy", "Medium", "Hard" }, ConstOpts.Back | ConstOpts.Exit);
            var aboutmenu = new Menu(1, 2, '>', "About menu", new string[] {
                $@"  ___     
  //   \____
  \\___/---/ {Item.Glass.Name}: {Item.Glass.Description}",
                $@"  __  __  
  //¨¨\/¨¨\\
  \\__/\__// {Item.Handcuffs.Name}: {Item.Handcuffs.Description}",
                $@"_____ ____
  \____|---/ {Item.Saw.Name}: {Item.Saw.Description}
",
                $@"/¨¨¨¨\   
  |SODA|   
  \____/ {Item.Soda.Name}: {Item.Soda.Description}
",
                $@"|¨¨¨¨¨|
  |SMOKE|
  |_____| {Item.Smoke.Name}: {Item.Smoke.Description}"
            }, ConstOpts.Back | ConstOpts.Exit);

            menuRun = new MenuRun();
            menuRun.Add(new Menu(0, '>', "Russian Roulette", new string[] { "Play", "Options", "About" }, ConstOpts.Exit));
            menuRun.Add(playmenu);
            menuRun.Add(aboutmenu);

            menuRun.Run();
        }
        public bool IsPvP => _isPvP;
        internal ShotHolder Shotholder => _shotholder;
        internal Player P1 => _p1;
        internal Player P2 => _p2;
    }
}
