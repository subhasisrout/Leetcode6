using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //https://www.youtube.com/watch?v=vYYNp0Jrdv0
    // #DFS #WordSearch #Graph
    
    public class WordsearchLC79
    {
        
        public WordsearchLC79()
        {
           

        }

        public bool Exist(char[,] board, string word)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {

                    if (board[i,j] == word[0] && DFSUtil(board,i,j,0,word)) //Without applying the first condition also works
                                                                            //but its an optimization
                    {
                        return true;

                    }
                }
            }
            return false;
        }

        private bool DFSUtil(char[,] board, int i, int j, int count, string word)
        {
            if (count == word.Length)
                return true;

            if (i < 0 || i >= board.GetLength(0) || j < 0 || j > board.GetLength(1) || board[i,j] != word[count])
                return false;

            char temp = board[i,j];
            board[i,j] = ' '; //This is needed. So that you dont come back in cycle and repeat the same character.

            bool found = DFSUtil(board, i + 1, j, count + 1, word) ||
                                DFSUtil(board, i - 1, j, count + 1, word) ||
                                DFSUtil(board, i, j + 1, count + 1, word) ||
                                DFSUtil(board, i, j - 1, count + 1, word);

            board[i,j] = temp;

            return found;
        }
    }
}
