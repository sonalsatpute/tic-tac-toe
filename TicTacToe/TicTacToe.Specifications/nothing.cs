using System;
using Machine.Specifications;
using TicTacToe.Business;

namespace TicTacToe.Specifications
{
    [Subject("Tic Tac Toe")]
    public class TicTacToeBoardSpecs
    {
        public class When_given_boad_size
        {
            static Game _game;

            Establish context = () => { _game = new Game(3); };

            It should_have_3_rows = () => _game.GetRowCount().ShouldEqual(3);
            It should_have_3_columns = () => _game.GetColumnCount().ShouldEqual(3);
        }
    }
}