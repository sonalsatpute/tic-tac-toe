namespace TicTacToe.Business
{
    public interface IWinnerFinderStrategy
    {
        CellState FindWinner(Board board);
    }
}