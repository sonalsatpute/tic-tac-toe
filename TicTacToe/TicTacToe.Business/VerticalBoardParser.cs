namespace TicTacToe.Business
{
    public class VerticalBoardParser : IBoardParserStrategy
    {
        Board _board;

        public CellState Parse(Board board)
        {
            _board = board;

            return GetCellStateAcrossColumn();
        }


        public CellState GetCellStateAcrossColumn()
        {
            for (int column = 0; column < Board.BOARD_SIZE; column++)
            {
                CellState columnCellState = GetCellStateIfAllMatchingOrEmpty(column);

                if (columnCellState != CellState.Empty)
                    return columnCellState;
            }

            return CellState.Empty;
        }

        private CellState GetCellStateIfAllMatchingOrEmpty(int column)
        {
            CellState firstCellState  = _board.GetCellStatus(0, column);
            CellState secondCellState = _board.GetCellStatus(1, column);
            CellState thirdCellState  = _board.GetCellStatus(2, column);

            bool areFirstSecondAndThirdCellHaveSameCellState = 
                firstCellState == secondCellState &&
                firstCellState == thirdCellState;

            if (areFirstSecondAndThirdCellHaveSameCellState)
                return firstCellState;

            return CellState.Empty;
        }
    }
}