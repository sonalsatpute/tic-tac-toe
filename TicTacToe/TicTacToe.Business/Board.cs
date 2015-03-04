namespace TicTacToe.Business
{
    public class Board
    {
        const int BOARD_SIZE = 3;
        readonly CellState[,] _cells = new CellState[BOARD_SIZE, BOARD_SIZE];

        public void MarkCell(CellState cellState, int row, int column)
        {
            _cells[row, column] = cellState;
        }

        public bool IsCellEmpty(int row, int column)
        {
            return _cells[row, column] != CellState.Empty;
        }

        public CellState GetCellStatus(int row, int column)
        {
            return _cells[row, column];
        }
    }
}