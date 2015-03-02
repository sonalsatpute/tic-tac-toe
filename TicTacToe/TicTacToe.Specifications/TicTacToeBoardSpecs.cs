using System;
using Machine.Specifications;
using TicTacToe.Business;

namespace TicTacToe.Specifications
{
    [Subject("")]
    public class TicTacToeBoardSpecs
    {
        public class when_given_boad_size
        {
            static BoardGame _boardGame;

            Establish context = () => { _boardGame = new BoardGame(3); };

            It should_have_3_rows = () => _boardGame.GetRowCount().ShouldEqual(3);
            It should_have_3_columns = () => _boardGame.GetColumnCount().ShouldEqual(3);
        }

        public class when_marking_the_board_cell
        {
            static BoardGame _boardGame;

            Establish context = () => { _boardGame = new BoardGame(3); };

            Because of = () => _boardGame.Mark(PlayerIcon.Cross, 1, 1);

            It board_cell_is_marked = () => _boardGame.GetCellStatus(1, 1).ShouldEqual(PlayerIcon.Cross);
        }
    }
}