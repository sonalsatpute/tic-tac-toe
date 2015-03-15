namespace TicTacToe.Business
{
    public class Board
    {
        public const int BOARD_SIZE = 3;
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

        public CellState GetWinnnerByRow()
        {
            CellState rowCellState = CellState.Empty;

            for (int row = 0; row < BOARD_SIZE; row++)
            {
                rowCellState = RowCellState(row);

                if (rowCellState != CellState.Empty)
                    return rowCellState;
            }

            return rowCellState;
        }

        private CellState RowCellState(int row)
        {
            CellState firstCellState  = GetCellStatus(row, 0);
            CellState secondCellState = GetCellStatus(row, 1);
            CellState thirdCellState  = GetCellStatus(row, 2);

            bool firsSecondAndThirdRowCellHasSameCellState = firstCellState == secondCellState &&
                                                          firstCellState == thirdCellState;

            if (firstCellState != CellState.Empty && firsSecondAndThirdRowCellHasSameCellState)
                return firstCellState;

            return CellState.Empty;
        }

        public CellState GetWinnnerByColumn()
        {
            CellState columnCellState = CellState.Empty;

            for (int column = 0; column < BOARD_SIZE; column++)
            {
                columnCellState = ColumnCellState(column);

                if (columnCellState != CellState.Empty)
                    return columnCellState;
            }

            return columnCellState;
        }

       

        private CellState ColumnCellState(int column)
        {
            CellState firstCellState  = GetCellStatus(0, column);
            CellState secondCellState = GetCellStatus(1, column);
            CellState thirdCellState  = GetCellStatus(2, column);

            bool firsSecondAndThirdColumnCellHasSameCellState = firstCellState == secondCellState &&
                                                          firstCellState == thirdCellState;

            if (firstCellState != CellState.Empty && firsSecondAndThirdColumnCellHasSameCellState)
                return firstCellState;

            return CellState.Empty;
        }
    }
}