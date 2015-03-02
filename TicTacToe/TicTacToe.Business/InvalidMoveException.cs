using System;

namespace TicTacToe.Business
{
    public class InvalidMoveException : ApplicationException
    {
        public InvalidMoveException(string message) : base(message)
        {
        }
    }
}