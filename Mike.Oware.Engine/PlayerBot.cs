using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mike.Oware.Engine
{
    public class PlayerBot : IPlayerBot
    {
        private readonly GameConfiguration _gameConfiguration;

        public PlayerBot(GameConfiguration gameConfiguration)
        {
            _gameConfiguration = gameConfiguration;
        }

        public bool IsHome { get; set; }

        public char TakeTurn(char[] state)
        {
            var currentBoard = BoardState.CreateBoard(state, _gameConfiguration, IsHome);
            DebugPrintBoard(currentBoard, 0);

            var successors = GenerateSuccessors(currentBoard, IsHome);
            foreach (var successor in successors)
            {
                DebugPrintBoard(successor, 1);
            }

            throw new NotImplementedException();
        }

        private IEnumerable<BoardState> GenerateSuccessors(BoardState currentBoard, bool isHome)
        {
            for (var pit = 0; pit < _gameConfiguration.NumberOfPits/2; pit++)
            {
                if (currentBoard[pit] > 0)
                {
                    var successor = Play(currentBoard, pit);
                    if (IsLegalPlay(currentBoard, successor, pit))
                    {
                        yield return successor;
                    }
                }
            }
        }

        private bool IsLegalPlay(BoardState currentBoard, BoardState successor, int pit)
        {
            return true;
        }

        private BoardState Play(BoardState currentBoard, int pit)
        {
            var copyOfBoard = currentBoard.CreateCopy();
            var leftToDistribute = copyOfBoard[pit];
            copyOfBoard[pit] = 0;

            while (leftToDistribute > 0)
            {
                if (pit < currentBoard.Count)
                {
                    pit++;
                }
                else
                {
                    pit = 0;
                }
                copyOfBoard[pit]++;
                leftToDistribute--;
            }
            return copyOfBoard;
        }

        private void DebugPrintBoard(BoardState board, int indent = 0)
        {
            Debug.WriteLine("");
            Debug.Write(new string('\t', indent));
            Debug.Write(new string('-', _gameConfiguration.NumberOfPits/2*3));
            Debug.WriteLine("");
            Debug.Write(new string('\t', indent));

            for (var pit = _gameConfiguration.NumberOfPits - 1; pit >= _gameConfiguration.NumberOfPits/2; pit--)
            {
                Debug.Write(board[pit].ToString().PadRight(3));
            }

            Debug.WriteLine("");
            Debug.Write(new string('\t', indent));

            for (var pit = 0; pit < _gameConfiguration.NumberOfPits/2; pit++)
            {
                Debug.Write(board[pit].ToString().PadRight(3));
            }

            Debug.WriteLine("");

            Debug.Write(new string('\t', indent));
            Debug.Write(new string('-', _gameConfiguration.NumberOfPits/2*3));
            Debug.WriteLine("");
        }
    }
}