namespace Russian_Roulette
{
    internal class Item
    {
        public class Saw : Item
        {
            public static string Form =>
@"_____ ____
  \____|---/";
            public static string Name => "Knife";
            public static string Description => "Shortens the barrel, doubles the dmg.";
        }
        public class Glass : Item
        {
            public static string Form => @"  ___      
//   \____ 
\\___/---/ ";
            public static string Name => "Magnifying Glass";
            public static string Description => "Reveals the shot.";
        }
        public class Handcuffs : Item
        {
            public static string Form => @"";
            public static string Name => "HandCuffs";
            public static string Description => "Opponent skips a round.";
        }
        public class Soda : Item
        {
            public static string Form => @"";
            public static string Name => "Soda";
            public static string Description => "Rejects a shot.";
        }
        public class Smoke : Item
        {
            public static string Form => @"";
            public static string Name => "Cigarette";
            public static string Description => "Gives a life.";
        }
    }
}