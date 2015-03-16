namespace TicTacToe.Business
{
    public class ByRowWinnerFinderStrategy : IWinnerFinderStrategy
    {
        Board _board;

        public CellState FindWinner(Board board)
        {
            _board = board;

            return GetWinnnerByRow();
        }


        public CellState GetWinnnerByRow()
        {
            CellState rowCellState = CellState.Empty;

            for (int row = 0; row < Board.BOARD_SIZE; row++)
            {
                rowCellState = RowCellState(row);

                if (rowCellState != CellState.Empty)
                    return rowCellState;
            }

            return rowCellState;
        }

        private CellState RowCellState(int row)
        {
            CellState firstCellState  = _board.GetCellStatus(row, 0);
            CellState secondCellState = _board.GetCellStatus(row, 1);
            CellState thirdCellState  = _board.GetCellStatus(row, 2);

            bool firsSecondAndThirdRowCellHasSameCellState = firstCellState == secondCellState &&
                                                             firstCellState == thirdCellState;

            if (firstCellState != CellState.Empty && firsSecondAndThirdRowCellHasSameCellState)
                return firstCellState;

            return CellState.Empty;
        }
    }
}