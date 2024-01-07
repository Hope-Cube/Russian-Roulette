using System;

namespace ConsoleMenu
{
    /// <summary>
    /// Represents an option that can be interacted with in a console menu.
    /// </summary>
    internal class InteractableOption
    {
        // Private fields for option properties
        private readonly int _index;
        private readonly Action _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractableOption"/> class with an index and associated action.
        /// </summary>
        /// <param name="index">The index of the interactable option.</param>
        /// <param name="action">The action to be executed when the option is selected.</param>
        public InteractableOption(int index, Action action)
        {
            _index = index;
            _action = action;
        }

        // Public properties for accessing option information
        /// <summary>
        /// Gets the index of the interactable option.
        /// </summary>
        public int Index => _index;

        /// <summary>
        /// Gets the action associated with the interactable option.
        /// </summary>
        public Action Action => _action;
    }
}