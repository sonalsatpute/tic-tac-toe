using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Business
{
    public class Board
    {
        public const int BOARD_SIZE = 3;
        readonly CellState[,] _cells = new CellState[BOARD_SIZE, BOARD_SIZE];
        readonly List<IWinnerFinderStrategy> winnerFinder = new List<IWinnerFinderStrategy>
        {
            new ByRowWinnerFinderStrategy(),
            new ByColumnWinnerFinderStrategy()
        }; 

        public void MarkCell(CellState cellState, int row, int column)
        {
            _cells[row, column] = cellState;
        }

        public bool IsCellEmpty(int row, int column)
        {
            return _cells[row, column] == CellState.Empty;
        }

        public CellState GetCellStatus(int row, int column)
        {
            return _cells[row, column];
        }

        public CellState GetWinnner()
        {
            CellState winner = CellState.Empty;

            foreach (IWinnerFinderStrategy wfs in winnerFinder)
            {
                winner = wfs.FindWinner(this);
                if (winner != CellState.Empty) break;
            }

            return winner;
        }

        

        
    }
}