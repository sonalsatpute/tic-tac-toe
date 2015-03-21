namespace TicTacToe.Business
{
    public class HorizontalBoardParser : IBoardParserStrategy
    {
        Board _board;

        public CellState Parse(Board board)
        {
            _board = board;

            return GetCellStateAcrossColumn();
        }


        private CellState GetCellStateAcrossColumn()
        {
            for (int row = 0; row < Board.BOARD_SIZE; row++)
            {
                CellState rowCellState = GetCellStateIfAllMatchingOrEmpty(row);

                if (rowCellState != CellState.Empty) 
                    return rowCellState;
            }

            return CellState.Empty;
        }

        private CellState GetCellStateIfAllMatchingOrEmpty(int row)
        {
            CellState firstCellState  = _board.GetCellStatus(row, 0);
            CellState secondCellState = _board.GetCellStatus(row, 1);
            CellState thirdCellState  = _board.GetCellStatus(row, 2);

            bool areFirstSecondAndThirdCellHaveSameCellState = firstCellState == secondCellState &&
                                                             firstCellState == thirdCellState;

            if (areFirstSecondAndThirdCellHaveSameCellState)
                return firstCellState;

            return CellState.Empty;
        }
    }
}