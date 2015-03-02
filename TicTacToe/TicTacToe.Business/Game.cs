namespace TicTacToe.Business
{
    public class BoardGame
    {
        readonly PlayerIcon[,] _board;

        public BoardGame(int boadSize)
        {
            _board = new PlayerIcon[boadSize+1, boadSize+1];
        }

        public int GetRowCount()
        {
            return _board.GetLength(0)-1;
        }

        public int GetColumnCount()
        {
            return _board.GetLength(1)-1;
        }

        public void MarkCell(PlayerIcon icon, int row, int column)
        {
            if (_board[row, column] != PlayerIcon.Empty)
                throw new InvalidMoveException(string.Format("Cell[{0},{1}] is not empty", row, column));
            
            _board[row, column] = icon;
        }

        public PlayerIcon GetCellStatus(int row, int column)
        {
            return _board[row,column];
        }

        public PlayerIcon Winner()
        {
            PlayerIcon firstCell    = _board[1, 1];
            PlayerIcon secondCell   = _board[1, 2];
            PlayerIcon thirdCell    = _board[1, 3];

            if (firstCell == secondCell && firstCell == thirdCell)
                return firstCell;

            return PlayerIcon.Empty;
        }
    }
}