namespace TicTacToe.Business
{
    public class ByColumnWinnerFinderStrategy : IWinnerFinderStrategy
    {
        Board _board;

        public CellState FindWinner(Board board)
        {
            _board = board;

            return GetWinnnerByColumn();
        }


        public CellState GetWinnnerByColumn()
        {
            CellState columnCellState = CellState.Empty;

            for (int column = 0; column < Board.BOARD_SIZE; column++)
            {
                columnCellState = ColumnCellState(column);

                if (columnCellState != CellState.Empty)
                    return columnCellState;
            }

            return columnCellState;
        }

        private CellState ColumnCellState(int column)
        {
            CellState firstCellState  = _board.GetCellStatus(0, column);
            CellState secondCellState = _board.GetCellStatus(1, column);
            CellState thirdCellState  = _board.GetCellStatus(2, column);

            bool firsSecondAndThirdColumnCellHasSameCellState = firstCellState == secondCellState &&
                                                                firstCellState == thirdCellState;

            if (firstCellState != CellState.Empty && firsSecondAndThirdColumnCellHasSameCellState)
                return firstCellState;

            return CellState.Empty;
        }
    }
}