using System.Collections.Generic;

namespace ConsoleMenu
{
    /// <summary>
    /// Represents a manager for running and navigating through a collection of menus.
    /// </summary>
    internal class MenuRun
    {
        private List<Menu> _menus;
        private int _depth;
        private int _index;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuRun"/> class.
        /// </summary>
        public MenuRun()
        {
            _menus = new List<Menu>();
        }

        /// <summary>
        /// Adds a menu to the collection.
        /// </summary>
        /// <param name="menu">The menu to be added.</param>
        public void Add(Menu menu)
        {
            _menus.Add(menu);
        }

        /// <summary>
        /// Removes a menu from the collection.
        /// </summary>
        /// <param name="menu">The menu to be removed.</param>
        public void Remove(Menu menu)
        {
            _menus.Remove(menu);
        }

        /// <summary>
        /// Runs the menu navigation loop.
        /// </summary>
        public void Run()
        {
            // Start with the first menu in the collection
            Menu currentMenu = _menus[0];

            while (true)
            {
                // Run the current menu and get the result index
                _index = currentMenu.Run();

                // Update the depth based on the index
                switch (_index)
                {
                    case -1:
                        _depth--; // Go back
                        break;
                    default:
                        _depth++; // Move to the next menu
                        break;
                }

                // Find the next menu based on depth and trigger index
                Menu nextMenu = FindNextMenu(currentMenu);

                if (nextMenu != null)
                {
                    // If a next menu is found, set it as the current menu
                    currentMenu = nextMenu;
                }
                else
                {
                    // If no next menu is found, decrease the depth
                    _depth--;
                }
            }
        }

        /// <summary>
        /// Finds the next menu based on the current depth and trigger index.
        /// </summary>
        /// <param name="currentMenu">The current menu.</param>
        /// <returns>The next menu or null if no next menu is found.</returns>
        private Menu FindNextMenu(Menu currentMenu)
        {
            foreach (var menu in _menus)
            {
                // Check if the depth and index match the trigger conditions for the menu
                if (_depth == menu.Depthindex && _index == menu.TriggerIndex)
                {
                    return menu;
                }
            }

            // If the depth is 0, return the first menu; otherwise, return null
            return (_depth == 0) ? _menus[0] : null;
        }
    }
}