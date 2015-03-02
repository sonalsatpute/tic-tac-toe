namespace TicTacToe.Business
{
    public enum PlayerIcon 
    {
        Empty  = ' ',
        Nought = 'O',
        Cross  = 'X'
    }

    public class BoardGame
    {
        readonly PlayerIcon[,] _board;

        public BoardGame(int boadSize)
        {
            _board = new PlayerIcon[boadSize, boadSize];
        }

        public int GetRowCount()
        {
            return _board.GetLength(0);
        }

        public int GetColumnCount()
        {
            return _board.GetLength(1);
        }

        public void Mark(PlayerIcon icon, int row, int column)
        {
            _board[row, column] = icon;
        }

        public PlayerIcon GetCellStatus(int row, int column)
        {
            return _board[row,column];
        }
    }
}