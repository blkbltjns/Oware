using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mike.Oware.Engine
{
    internal class BoardState : List<int>
    {
        internal BoardState(int numberOfPits)
        {
            if (numberOfPits % 2 != 0)
            {
                throw new ArgumentException("Number of pits must be divisible by 2 to be a valid board!");
            }

            for (int i = 0; i < numberOfPits; i++)
            {
                this.Add(0);
            }
        }

        public static BoardState CreateBoard(char[] initialBoard, GameConfiguration config, bool isHome)
        {
            var boardState = new BoardState(config.NumberOfPits);
            var a = new ArrayList();
            foreach (char c in initialBoard)
            {
                int position = TranslatePosition(c, config.NumberOfPits, isHome);
                boardState[position]++;
            }
            return boardState;
        }

        /// <summary>
        /// Translates from A-F, a-f to a board position 0-12. Takes IsHome into account
        /// so the first positions are always the current player's.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="boardSize"></param>
        /// <param name="isHome"></param>
        /// <returns></returns>
        private static int TranslatePosition(char position, int boardSize, bool isHome)
        {
            // if uppercase letter
            if (position < 97)
            {
                if (isHome)
                {
                    return position - 'A';
                }
                else
                {
                    return position - 'A' + (boardSize / 2);
                }
            }
            else
            {
                if (isHome)
                {
                    return position - 'a' + (boardSize / 2);
                }
                else
                {
                    return position - 'a';
                }
            }
        }

        public BoardState CreateCopy()
        {
            var copy = new BoardState(this.Count);
            for (int pit = 0; pit < this.Count; pit++)
            {
                copy[pit] = this[pit];
            }
            return copy;
        }
    }


}
