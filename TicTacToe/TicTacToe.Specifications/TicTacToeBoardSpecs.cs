using System;
using Machine.Specifications;
using TicTacToe.Business;

namespace TicTacToe.Specifications
{
    [Subject("")]
    public class TicTacToeBoardSpecs
    {
        const int ZERO_BASED_INDEX = 1;
        static Game _game;
        

        Establish beforeEach = () =>
        {
            _game = new Game();
        };

        static void MarkBoardRow(int row, string rowMap)
        {
            if (string.IsNullOrWhiteSpace(rowMap)) return;

            string[] cellStates = rowMap.Trim().Split(' ');

            for (int col = 0; col < cellStates.Length; col++)
            {
                CellState cellState = cellStates[col] == "X" ? CellState.Cross : CellState.Nought;

                _game.MarkCell(cellState, row - ZERO_BASED_INDEX, col);
            }
        }


        public class when_marking_the_board_cell
        {
            Because of = () => _game.MarkCell(CellState.Cross, 1, 1);

            It board_cell_is_marked = () => _game.GetCellStatus(1, 1).ShouldEqual(CellState.Cross);
        }

        public class when_board_cell_is_already_marked
        {
            static Exception Exception;

            Because of = () =>
            {
                _game.MarkCell(CellState.Cross, 1, 1);
                Exception = Catch.Exception(() => _game.MarkCell(CellState.Cross, 1, 1));
            };

            It should_fail = () => Exception.ShouldBeOfExactType<InvalidMoveException>();
            It should_have_a_specific_reason = () => Exception.Message.ShouldContain("CellState[1,1] is not empty");
        }

        public class when_board_top_cells_are_marked_as_Cross
        {
            Because of = () =>
            {
                MarkBoardRow(1, "X X X");
                MarkBoardRow(2, "     ");
                MarkBoardRow(3, "     ");
            };

            It should_declare_Cross_as_a_winner = () => _game.GetWinner().ShouldEqual(CellState.Cross);
        }

        public class when_board_top_cells_are_marked_as_Nought
        {
            Because of = () =>
            {
                MarkBoardRow(1, "O O O");
                MarkBoardRow(2, "     ");
                MarkBoardRow(3, "     ");
            };

            It should_declare_Nought_as_a_winner = () => _game.GetWinner().ShouldEqual(CellState.Nought);
        }
    }
}