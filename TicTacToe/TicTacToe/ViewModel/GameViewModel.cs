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
                var bsquare = new BigSquare();
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

        public int Row { get; set; }
        public int Column { get; set; }
        public List<SmallSquare> SmallSquares { get; set; } = new List<SmallSquare>();
        public BigSquare()
        {
            for (int i = 0; i < 9; i++)
            {
                var smallSquare = new SmallSquare(i);
                smallSquare.Column = i % 3;
                smallSquare.Row = i / 3;
                //smallSquare.CurrentPlayer = $"Index: {i}";
                SmallSquares.Add(smallSquare);
            }
        }

    }

    class SmallSquare
    {
        //public bool IsFirstPlayer;
        public int Row { get; set; }
        public int Column { get; set; }
        public ICommand TickCommand { get; set; }

        public int BigSquareIndex { get; }

        public SmallSquare(int bigSquareIndex)
        {
            TickCommand = new RelayCommand<object>((p) => { return true; }, (button) => {

                MessageBox.Show("test"+ BigSquareIndex);

            });

            BigSquareIndex = bigSquareIndex;
        }

        public bool IsEnable
        {
            get
            {
                return string.IsNullOrEmpty("");
            }
        }

        
    }

}
