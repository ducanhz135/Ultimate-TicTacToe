using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using TicTacToe.Model;
using System.Windows.Media;
using System.Collections.Generic;

namespace TicTacToe.ViewModel
{
    class GameViewModel: BaseViewModel
    {
        public List<BigSquare> BigSquares { get; set; } = new List<BigSquare>();

        public GameViewModel()
        {

            for (int i = 0; i < 9; i++)
            {
                var bsquare = new BigSquare(i);
                bsquare.Column = i % 3;
                bsquare.Row = i / 3;
                //bsquare.Winner = $"Index: {i}";
                BigSquares.Add(bsquare);
            }

        }
        
    }

    class BigSquare
    {
        public string Winner { get; }
        public bool IsEnalble
        {
            get
            {
                return string.IsNullOrEmpty(Winner);
            }
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public List<SmallSquare> SmallSquares { get; set; } = new List<SmallSquare>();
        public BigSquare(int bigSquareIndex)
        {
            for (int i = 0; i < 9; i++)
            {
                var smallSquare = new SmallSquare(bigSquareIndex);
                smallSquare.Column = i % 3;
                smallSquare.Row = i / 3;
                //smallSquare.CurrentPlayer = $"Index: {i}";
                SmallSquares.Add(smallSquare);
            }
        }

    }

    class SmallSquare
    {
        public string CurrentPlayer { get; set; }
        //public bool IsFirstPlayer;
        public int Row { get; set; }
        public int Column { get; set; }

        private string _ContentButton;
        public string ContentButton { get => _ContentButton; set { _ContentButton = value; } }

        public ICommand TickCommand { get; set; }

        public int BigSquareIndex { get; }

        public SmallSquare(int bigSquareIndex)
        {
            TickCommand = new RelayCommand<object>((p) => { return true; }, (button) => {

                //ContentButton = "X";

            });

            BigSquareIndex = bigSquareIndex;
        }

        public bool IsEnable
        {
            get
            {
                return string.IsNullOrEmpty(CurrentPlayer);
            }
        }

        
    }

}
