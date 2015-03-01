namespace TicTacToe.Business
{
    public class Game
    {
        readonly int[,] _board;

        public Game(int boadSize)
        {
            _board = new int[boadSize,boadSize];
        }

        public int GetRowCount()
        {
            return _board.GetLength(0);
        }

        public int GetColumnCount()
        {
            return _board.GetLength(1);
        }
    }
}