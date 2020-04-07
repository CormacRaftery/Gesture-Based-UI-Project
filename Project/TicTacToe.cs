using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

using Windows.Media.SpeechRecognition;
using Windows.Storage;
using System.Linq;

namespace Project
{

    public class TicTacToe
    {
        public TicTacToe()
        {
            ticSpeech();
        }
        Grid grid1;
        private SpeechRecognizer speechRecognizer;
        private async void ticSpeech()
        {
            speechRecognizer = new SpeechRecognizer();
            speechRecognizer.Timeouts.BabbleTimeout = TimeSpan.FromSeconds(0);
            speechRecognizer.Timeouts.InitialSilenceTimeout = TimeSpan.FromSeconds(5);
            speechRecognizer.Timeouts.EndSilenceTimeout = TimeSpan.FromSeconds(0.5);

            // load grammar file here
            var grammarFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///ticTacToeGrammar.xml"));
            //adds constraints to the speechrecognizer
            speechRecognizer.Constraints.Add(new SpeechRecognitionGrammarFileConstraint(grammarFile));
            var result = await speechRecognizer.CompileConstraintsAsync();
            if (result.Status == SpeechRecognitionResultStatus.Success)
            {
                while (true)
                {
                    //listen in to the user
                    SpeechRecognitionResult srr = await speechRecognizer.RecognizeAsync();
                    string myCommand = "No command found";
                    if ((srr.Confidence == SpeechRecognitionConfidence.High) ||
                        (srr.Confidence == SpeechRecognitionConfidence.Medium))
                    {
                        //get commands
                        myCommand = srr.SemanticInterpretation.Properties["command"].Single();
                        string ruleID = srr.RulePath[0];
                        var arr = grid1.Children.ToArray();
                        #region voice placements
                        if (myCommand == "topleft")
                        {
                            if (!_won)
                            {
                                arr[0] = Piece();
                                _board[0, 0] = _piece;
                                if (Winner())
                                {
                                    _won = true;
                                    Show($"{_piece} wins!", title);
                                }
                                else if (Drawn())
                                {
                                    Show("Draw!", title);
                                }
                                else
                                {
                                    // Swap Players
                                    _piece = (_piece == cross ? nought : cross);
                                }
                            }
                            else
                            {
                                Show("Game Over!", title);
                            }
                            arr[0].SetValue(Grid.ColumnProperty, 0);
                            arr[0].SetValue(Grid.RowProperty, 0);
                            grid1.Children.Add(arr[0]);
                        }
                        else if (myCommand == "topmiddle")
                        {
                            if (!_won)
                            {
                                arr[1] = Piece();
                                _board[0, 1] = _piece;
                                if (Winner())
                                {
                                    _won = true;
                                    Show($"{_piece} wins!", title);
                                }
                                else if (Drawn())
                                {
                                    Show("Draw!", title);
                                }
                                else
                                {
                                    // Swap Players
                                    _piece = (_piece == cross ? nought : cross);
                                }
                            }
                            else
                            {
                                Show("Game Over!", title);
                            }
                            arr[1].SetValue(Grid.ColumnProperty, 1);
                            arr[1].SetValue(Grid.RowProperty, 0);
                            grid1.Children.Add(arr[1]);
                        }
                        if (myCommand == "topright")
                        {
                            if (!_won)
                            {
                                arr[2] = Piece();
                                _board[0, 2] = _piece;
                                if (Winner())
                                {
                                    _won = true;
                                    Show($"{_piece} wins!", title);
                                }
                                else if (Drawn())
                                {
                                    Show("Draw!", title);
                                }
                                else
                                {
                                    // Swap Players
                                    _piece = (_piece == cross ? nought : cross);
                                }
                            }
                            else
                            {
                                Show("Game Over!", title);
                            }
                            arr[2].SetValue(Grid.ColumnProperty, 2);
                            arr[2].SetValue(Grid.RowProperty, 0);
                            grid1.Children.Add(arr[2]);
                        }
                        if (myCommand == "middleleft")
                        {
                            if (!_won)
                            {
                                arr[3] = Piece();
                                _board[1, 0] = _piece;
                                if (Winner())
                                {
                                    _won = true;
                                    Show($"{_piece} wins!", title);
                                }
                                else if (Drawn())
                                {
                                    Show("Draw!", title);
                                }
                                else
                                {
                                    // Swap Players
                                    _piece = (_piece == cross ? nought : cross);
                                }
                            }
                            else
                            {
                                Show("Game Over!", title);
                            }
                            arr[3].SetValue(Grid.ColumnProperty, 0);
                            arr[3].SetValue(Grid.RowProperty, 1);
                            grid1.Children.Add(arr[3]);
                        }
                        if (myCommand == "middlemiddle")
                        {
                            if (!_won)
                            {
                                arr[4] = Piece();
                                _board[1, 1] = _piece;
                                if (Winner())
                                {
                                    _won = true;
                                    Show($"{_piece} wins!", title);
                                }
                                else if (Drawn())
                                {
                                    Show("Draw!", title);
                                }
                                else
                                {
                                    // Swap Players
                                    _piece = (_piece == cross ? nought : cross);
                                }
                            }
                            else
                            {
                                Show("Game Over!", title);
                            }
                            arr[4].SetValue(Grid.ColumnProperty, 1);
                            arr[4].SetValue(Grid.RowProperty, 1);
                            grid1.Children.Add(arr[4]);
                        }
                        if (myCommand == "middleright")
                        {
                            if (!_won)
                            {
                                arr[5] = Piece();
                                _board[1, 2] = _piece;
                                if (Winner())
                                {
                                    _won = true;
                                    Show($"{_piece} wins!", title);
                                }
                                else if (Drawn())
                                {
                                    Show("Draw!", title);
                                }
                                else
                                {
                                    // Swap Players
                                    _piece = (_piece == cross ? nought : cross);
                                }
                            }
                            else
                            {
                                Show("Game Over!", title);
                            }
                            arr[5].SetValue(Grid.ColumnProperty, 2);
                            arr[5].SetValue(Grid.RowProperty, 1);
                            grid1.Children.Add(arr[5]);
                        }
                        if (myCommand == "bottomleft")
                        {
                            if (!_won)
                            {
                                arr[6] = Piece();
                                _board[2, 0] = _piece;
                                if (Winner())
                                {
                                    _won = true;
                                    Show($"{_piece} wins!", title);
                                }
                                else if (Drawn())
                                {
                                    Show("Draw!", title);
                                }
                                else
                                {
                                    // Swap Players
                                    _piece = (_piece == cross ? nought : cross);
                                }
                            }
                            else
                            {
                                Show("Game Over!", title);
                            }
                            arr[6].SetValue(Grid.ColumnProperty, 0);
                            arr[6].SetValue(Grid.RowProperty, 2);
                            grid1.Children.Add(arr[6]);
                        }
                        if (myCommand == "bottommiddle")
                        {
                            if (!_won)
                            {
                                arr[7] = Piece();
                                _board[2, 1] = _piece;
                                if (Winner())
                                {
                                    _won = true;
                                    Show($"{_piece} wins!", title);
                                }
                                else if (Drawn())
                                {
                                    Show("Draw!", title);
                                }
                                else
                                {
                                    // Swap Players
                                    _piece = (_piece == cross ? nought : cross);
                                }
                            }
                            else
                            {
                                Show("Game Over!", title);
                            }
                            arr[7].SetValue(Grid.ColumnProperty, 1);
                            arr[7].SetValue(Grid.RowProperty, 2);
                            grid1.Children.Add(arr[7]);
                        }
                        if (myCommand == "bottomright")
                        {
                            if (!_won)
                            {
                                arr[8] = Piece();
                                _board[2, 2] = _piece;
                                if (Winner())
                                {
                                    _won = true;
                                    Show($"{_piece} wins!", title);
                                }
                                else if (Drawn())
                                {
                                    Show("Draw!", title);
                                }
                                else
                                {
                                    // Swap Players
                                    _piece = (_piece == cross ? nought : cross);
                                }
                            }
                            else
                            {
                                Show("Game Over!", title);
                            }
                            arr[8].SetValue(Grid.ColumnProperty, 2);
                            arr[8].SetValue(Grid.RowProperty, 2);
                            grid1.Children.Add(arr[8]);
                        }
                        #endregion
                    }
                }
            }
        }

        private const string title = "Tic Tac Toe";
        private const string blank = " ";
        private const string nought = "\U00002B55";
        private const string cross = "\U0000274C";
        private const int size = 3;
        private bool _won = false;
        private string _piece = blank;
        private string[,] _board = new string[size, size];
        private int i = 0;
        private async Task<bool> ConfirmAsync(string content, string title,
         string ok, string cancel)
        {
            bool result = false;
            MessageDialog dialog = new MessageDialog(content, title);
            dialog.Commands.Add(new UICommand(ok,
            new UICommandInvokedHandler((cmd) => result = true)));
            dialog.Commands.Add(new UICommand(cancel,
            new UICommandInvokedHandler((cmd) => result = false)));
            await dialog.ShowAsync();
            return result;
        }
        #region end conditions
        private void Show(string content, string title)
        {
            _ = new MessageDialog(content, title).ShowAsync();
        }
        private bool Winner()
        {
            return (_board[0, 0] == _piece && _board[0, 1] ==
            _piece && _board[0, 2] == _piece) ||
            (_board[1, 0] == _piece && _board[1, 1] ==
            _piece && _board[1, 2] == _piece) ||
            (_board[2, 0] == _piece && _board[2, 1] ==
            _piece && _board[2, 2] == _piece) ||
            (_board[0, 0] == _piece && _board[1, 0] ==
            _piece && _board[2, 0] == _piece) ||
            (_board[0, 1] == _piece && _board[1, 1] ==
            _piece && _board[2, 1] == _piece) ||
            (_board[0, 2] == _piece && _board[1, 2] ==
            _piece && _board[2, 2] == _piece) ||
            (_board[0, 0] == _piece && _board[1, 1] ==
            _piece && _board[2, 2] == _piece) ||
            (_board[0, 2] == _piece && _board[1, 1] ==
            _piece && _board[2, 0] == _piece);
        }
        private bool Drawn()
        {
            return _board[0, 0] != blank && _board[0, 1] !=
            blank && _board[0, 2] != blank &&
            _board[1, 0] != blank && _board[1, 1] !=
            blank && _board[1, 2] != blank &&
            _board[2, 0] != blank && _board[2, 1] !=
            blank && _board[2, 2] != blank;
        }
        #endregion

        private Viewbox Piece()
        {
            TextBlock textblock = new TextBlock()
            {
                Text = _piece,
                IsColorFontEnabled = true,
                TextLineBounds = TextLineBounds.Tight,
                FontFamily = new FontFamily("Segoe UI Emoji"),
                HorizontalTextAlignment = TextAlignment.Center
            };
            return new Viewbox()
            {
                Child = textblock
            };
        }
        private void Add(ref Grid grid, int row, int column, int i)
        {
            Button button = new Button()
            {
                Tag = i,
                Width = 75,
                Height = 75,
                Margin = new Thickness(10),
                Style = (Style)Application.Current.Resources
            ["ButtonRevealStyle"]
            };

            button.Click += (object sender, RoutedEventArgs e) =>/////////change for speech
            {
                if (!_won)
                {
                    button = (Button)sender;
                    if (button.Content == null)
                    {
                        button.Content = Piece();
                        _board[(int)button.GetValue(Grid.RowProperty),
                        (int)button.GetValue(Grid.ColumnProperty)] = _piece;
                    }
                    if (Winner())
                    {
                        _won = true;
                        Show($"{_piece} wins!", title);
                    }
                    else if (Drawn())
                    {
                        Show("Draw!", title);
                    }
                    else
                    {
                        // Swap Players
                        _piece = (_piece == cross ? nought : cross);
                    }
                }
                else
                {
                    Show("Game Over!", title);
                }
            };
            button.SetValue(Grid.ColumnProperty, column);
            button.SetValue(Grid.RowProperty, row);
            grid.Children.Add(button);
        }
        #region setup game
        private void Layout(ref Grid grid)
        {
            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
            // Setup Grid
            for (int index = 0; (index < size); index++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            // Setup Board
            for (int row = 0; (row < size); row++)
            {
                for (int column = 0; (column < size); column++)
                {
                    Add(ref grid, row, column, i);
                    _board[row, column] = blank;
                    i++;
                }
            }
        }
        public async void New(Grid grid)
        {
            grid1 = grid;
            Layout(ref grid);
            _won = false;
            _piece = await ConfirmAsync("Who goes First?", title,
            nought, cross) ? nought : cross;
        }
        #endregion
    }
}