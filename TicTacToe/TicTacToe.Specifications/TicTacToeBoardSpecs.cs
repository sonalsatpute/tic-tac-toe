using System;
using Machine.Specifications;
using TicTacToe.Business;

namespace TicTacToe.Specifications
{
    [Subject("")]
    public class TicTacToeBoardSpecs
    {
        static BoardGame _boardGame;
        

        Establish beforeEach = () =>
        {
            _boardGame = new BoardGame(3);
        };

        public static void MarkBoard(string boardMap)
        {
            string[] rows = boardMap.Split('\n');
            for (int row = 1; row < rows.Length; row++)
            {
                string[] columns = rows[row].Trim().Split(' ');
                for (int col = 1; col < columns.Length; col++)
                {
                    PlayerIcon icon = columns[col] == "X" ? PlayerIcon.Cross : PlayerIcon.Nought;
                    _boardGame.MarkCell(icon, row,col);
                }
            }
        }


        public class when_given_boad_size
        {
            It should_have_3_rows = () => _boardGame.GetRowCount().ShouldEqual(3);
            It should_have_3_columns = () => _boardGame.GetColumnCount().ShouldEqual(3);
        }

        public class when_marking_the_board_cell
        {
            Because of = () => _boardGame.MarkCell(PlayerIcon.Cross, 1, 1);

            It board_cell_is_marked = () => _boardGame.GetCellStatus(1, 1).ShouldEqual(PlayerIcon.Cross);
        }

        public class when_board_cell_is_already_marked
        {
            static Exception Exception;

            Because of = () =>
            {
                _boardGame.MarkCell(PlayerIcon.Cross, 1, 1);
                Exception = Catch.Exception(() => _boardGame.MarkCell(PlayerIcon.Cross, 1, 1));
            };

            It should_fail = () => Exception.ShouldBeOfExactType<InvalidMoveException>();
            It should_have_a_specific_reason = () => Exception.Message.ShouldContain("Cell[1,1] is not empty");
        }

        public class when_board_top_cells_are_marked_as_Cross
        {
            static string boardMap;
            Because of = () =>
            {
               boardMap =
                           @"0 1 2 3
                             1 X X X
                             2      
                             3      
                            ";

                MarkBoard(boardMap);
            };

            It should_declare_Cross_as_a_winner = () => _boardGame.Winner().ShouldEqual(PlayerIcon.Cross);
        }

        public class when_board_top_cells_are_marked_as_Nought
        {
            static string boardMap;
            Because of = () =>
            {
                boardMap =
                            @"0 1 2 3
                             1 O O O
                             2      
                             3      
                            ";

                MarkBoard(boardMap);
            };

            It should_declare_Nought_as_a_winner = () => _boardGame.Winner().ShouldEqual(PlayerIcon.Nought);
        }
    }
}