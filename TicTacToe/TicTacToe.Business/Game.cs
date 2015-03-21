using System.Collections.Generic;

namespace TicTacToe.Business
{
    public class Game
    {
        readonly Board _board = new Board();
        CellState _winner = CellState.Empty;

        readonly List<IBoardParserStrategy> _boardParserStrategies = new List<IBoardParserStrategy>
        {
            new HorizontalBoardParser(),
            new VerticalBoardParser()
        };

        public void MarkCell(CellState cellState, int row, int column)
        {
            if (!_board.IsCellEmpty(row, column))
                throw new InvalidMoveException(string.Format("CellState[{0},{1}] is not empty", row, column));

            _board.MarkCell(cellState, row, column);
            PolulateWinnerIfAny();
        }

        public CellState GetCellStatus(int row, int column)
        {
            return _board.GetCellStatus(row, column);
        }

        public CellState GetWinner()
        {
            return _winner;
        }

        private void PolulateWinnerIfAny()
        {
            foreach (IBoardParserStrategy parserStrategy in _boardParserStrategies)
            {
                CellState winner = parserStrategy.Parse(_board);

                if (winner != CellState.Empty)
                    _winner = winner;
            }
        }
    }
}