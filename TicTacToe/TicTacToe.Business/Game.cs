namespace TicTacToe.Business
{
    public class Game
    {
        public Board _board = new Board();

        public void MarkCell(CellState cellState, int row, int column)
        {
            if (_board.IsCellEmpty(row, column))
                throw new InvalidMoveException(string.Format("CellState[{0},{1}] is not empty", row, column));

            _board.MarkCell(cellState, row, column);
        }

        public CellState GetCellStatus(int row, int column)
        {
            return _board.GetCellStatus(row, column);
        }

        public CellState GetWinner()
        {
            CellState firstCellState  = _board.GetCellStatus(0, 0);
            CellState secondCellState = _board.GetCellStatus(0, 1);
            CellState thirdCellState  = _board.GetCellStatus(0, 2);

            if (firstCellState == secondCellState && firstCellState == thirdCellState)
                return firstCellState;

            return CellState.Empty;
        }
    }
}