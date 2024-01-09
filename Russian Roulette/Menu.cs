using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ConsoleMenu
{
    /// <summary>
    /// Represents a menu with options that can be navigated and interacted with.
    /// </summary>
    internal class Menu
    {
        private string _title;
        private string[] _options;
        private readonly ConsoleColor _color;

        // Enum defining constant options for menus
        public enum ConstOpts { None = 1, Back = 2, Exit = 4 }

        private ConstOpts _constopt;
        private int _index;
        private int _titleNopts;
        private int _titleNoptspp = 0;
        private string _prompt;
        private int _depthindex;
        private int _triggerindex;
        private List<InteractableOption> _actions;

        // Properties for accessing menu information
        public string Title => _title;
        public string[] Options => _options;
        public ConstOpts ConstOpt => _constopt;
        public int Index => _index;
        public int TitleAndOpts => _titleNopts;
        public string Prompt { get => _prompt; set => _prompt = value; }
        public int Depthindex => _depthindex;
        public int TriggerIndex => _triggerindex;
        public List<InteractableOption> Actions => _actions;
        public ConsoleColor Color => _color;

        // Overrides ToString method to provide a string representation of the menu
        public override string ToString() => $"{Title},\n{string.Join(", ", Options)},\n{ConstOpt},\n{Index},\n{TitleAndOpts},\n{Prompt},\n{Depthindex},\n{TriggerIndex},\n{Actions}";

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class for creating a simple menu without actions.
        /// </summary>
        /// <param name="depthIndex">The depth index of the menu.</param>
        /// <param name="prompt">The character used as a prompt for the menu.</param>
        /// <param name="title">The title of the menu.</param>
        /// <param name="options">The array of options for the menu.</param>
        /// <param name="constOpts">The constant options for the menu.</param>
        /// <param name="color">The color for the menu (default is ConsoleColor.White).</param>
        public Menu(int depthIndex, char prompt, string title, string[] options, ConstOpts constOpts, ConsoleColor color = ConsoleColor.White) : this(depthIndex, 0, prompt, title, null, options, constOpts, color) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class for creating a menu with options.
        /// </summary>
        /// <param name="depthIndex">The depth index of the menu.</param>
        /// <param name="triggerIndex">The trigger index of the menu.</param>
        /// <param name="prompt">The character used as a prompt for the menu.</param>
        /// <param name="title">The title of the menu.</param>
        /// <param name="options">The array of options for the menu.</param>
        /// <param name="constOpts">The constant options for the menu.</param>
        /// <param name="color">The color for the menu (default is ConsoleColor.White).</param>
        public Menu(int depthIndex, int triggerIndex, char prompt, string title, string[] options, ConstOpts constOpts, ConsoleColor color = ConsoleColor.White)
        {
            _depthindex = depthIndex;
            _triggerindex = triggerIndex;
            _prompt = prompt.ToString() + ' ';
            _title = title;
            _actions = null;
            _options = ConstOptions(options, constOpts);
            _index = 0;
            _titleNopts = title.Count(c => c == '\n') + 2;
            _constopt = constOpts;
            _color = color; // Set color (defaulting to ConsoleColor.White)
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class for creating a menu with options and actions.
        /// </summary>
        /// <param name="depthIndex">The depth index of the menu.</param>
        /// <param name="triggerIndex">The trigger index of the menu.</param>
        /// <param name="prompt">The character used as a prompt for the menu.</param>
        /// <param name="title">The title of the menu.</param>
        /// <param name="actions">The list of interactable options associated with the menu.</param>
        /// <param name="options">The array of options for the menu.</param>
        /// <param name="constOpts">The constant options for the menu.</param>
        /// <param name="color">The color for the menu (default is ConsoleColor.White).</param>
        public Menu(int depthIndex, int triggerIndex, char prompt, string title, List<InteractableOption> actions, string[] options, ConstOpts constOpts, ConsoleColor color = ConsoleColor.White)
        {
            _depthindex = depthIndex;
            _triggerindex = triggerIndex;
            _prompt = prompt.ToString() + ' ';
            _title = title;
            _actions = actions;
            _options = ConstOptions(options, constOpts);
            _index = 0;
            _titleNopts = title.Count(c => c == '\n') + 2;
            _constopt = constOpts;
            _color = color; // Set color (defaulting to ConsoleColor.White)
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class specifically designed for game field menus.
        /// </summary>
        /// <param name="gamefieldrows">A list of strings representing the rows of the game field.</param>
        /// <param name="depthIndex">The depth index of the menu.</param>
        /// <param name="triggerIndex">The trigger index of the menu.</param>
        /// <param name="prompt">The prompt displayed before each menu option.</param>
        /// <param name="title">The title of the menu.</param>
        /// <param name="actions">The list of interactable actions associated with the menu.</param>
        /// <param name="options">The array of menu options.</param>
        /// <param name="constOpts">The constant options to be added based on the ConstOpts enum.</param>
        /// <param name="color">The color of the menu (defaulting to ConsoleColor.White).</param>
        public Menu(List<string> gamefieldrows, int depthIndex, int triggerIndex, char prompt, string title, List<InteractableOption> actions, string[] options, ConstOpts constOpts, ConsoleColor color = ConsoleColor.White)
        {
            // Set the total number of rows in the game field
            _titleNoptspp = gamefieldrows.Count;

            // Set the depth index of the menu
            _depthindex = depthIndex;

            // Set the trigger index of the menu
            _triggerindex = triggerIndex;

            // Set the prompt character for each option in the menu
            _prompt = prompt.ToString() + ' ';

            // Set the title of the menu
            _title = title;

            // Initialize the list of actions associated with menu options
            _actions = actions;

            // Apply constant options to the provided options based on the ConstOpts enum
            _options = ConstOptions(options, constOpts);

            // Set the initial selected index to 0
            _index = 0;

            // Calculate the total number of lines occupied by the title and options
            _titleNopts = title.Count(c => c == '\n') + 2;

            // Set the constant options for the menu
            _constopt = constOpts;

            // Set the color of the menu (defaulting to ConsoleColor.White)
            _color = color;
        }


        // Adds constant options (like Back, Exit) to the provided options
        private string[] ConstOptions(string[] options, ConstOpts constOpts)
        {
            List<string> optionsList = options.ToList();

            if (constOpts.HasFlag(ConstOpts.Back))
            {
                optionsList.Insert(0, "Back");
            }

            if (constOpts.HasFlag(ConstOpts.Exit))
            {
                optionsList.Add("Exit");
            }

            return optionsList.ToArray();
        }

        // Displays the menu title and options
        private void MenuOut()
        {
            WriteLine(_title);
            OptionsOut();
        }

        // Displays individual menu options
        private void OptionsOut()
        {
            SetCursorPosition(0, _titleNoptspp + _titleNopts);

            for (int i = 0; i < _options.Length; i++)
            {
                ConsoleColor foregroundColor = (_index == i) ? ConsoleColor.Black : ConsoleColor.White;
                ConsoleColor backgroundColor = (_index == i) ? ConsoleColor.White : ConsoleColor.Black;

                (ForegroundColor, BackgroundColor) = (foregroundColor, backgroundColor);

                WriteLine((_index == i) ? _prompt + _options[i] : "  " + _options[i]);
            }
        }

        // Runs the menu and handles user input
        public int Run()
        {
            Clear();
            MenuOut();

            ConsoleKey pressedKey;
            do
            {
                pressedKey = ReadKey(true).Key;

                switch (pressedKey)
                {
                    case ConsoleKey.UpArrow:
                        _index = (_index != 0) ? _index - 1 : _index;
                        break;
                    case ConsoleKey.DownArrow:
                        _index = (_index != _options.Length - 1) ? _index + 1 : _index;
                        break;
                }

                OptionsOut();

            } while (pressedKey != ConsoleKey.Enter);

            bool isBack = _constopt.HasFlag(ConstOpts.Back);
            bool isExit = _constopt.HasFlag(ConstOpts.Exit);

            if (isBack && _index == 0) return -1;
            if (isExit && _index == _options.Length - 1)
            {
                Environment.Exit(0);
                return 0;
            }

            if (_actions != null)
            {
                foreach (var action in _actions)
                {
                    if (_index == action.Index)
                    {
                        action.Action.Invoke();
                        return _index;
                    }
                }
            }

            return _index;
        }
    }
}