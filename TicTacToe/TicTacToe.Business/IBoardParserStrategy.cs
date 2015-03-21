namespace TicTacToe.Business
{
    public interface IBoardParserStrategy
    {
        CellState Parse(Board board);
    }
}