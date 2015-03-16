namespace TicTacToe.Business
{
    public class Game
    {
        public Board _board = new Board();

        public void MarkCell(CellState cellState, int row, int column)
        {
            if (!_board.IsCellEmpty(row, column))
                throw new InvalidMoveException(string.Format("CellState[{0},{1}] is not empty", row, column));

            _board.MarkCell(cellState, row, column);
        }

        public CellState GetCellStatus(int row, int column)
        {
            return _board.GetCellStatus(row, column);
        }

        public CellState GetWinner()
        {
            CellState winnnerByRow = _board.GetWinnnerByRow();
            if (winnnerByRow != CellState.Empty) return winnnerByRow;

            CellState winnnerByColumn = _board.GetWinnnerByColumn();
            if (winnnerByColumn != CellState.Empty) return winnnerByColumn;
           

            
            return CellState.Empty;
        }

        
    }
}