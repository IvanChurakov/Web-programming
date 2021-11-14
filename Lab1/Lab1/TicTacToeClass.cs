using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    public class TicTacToeClass
    {
        /// Declaring private class variables

        /// <summary>
        /// The constructor initializes the variable player with a value
        /// and field with a values -1
        /// </summary>
        public TicTacToeClass()
        {

        }

        /// <summary>
        /// A property to interact with the player variable outside the class
        /// </summary>
        public int Player;

        /// <summary>
        /// A property to interact with the field of play
        /// </summary>
        /// <param name="i">Field column</param>
        /// <param name="j">Field row</param>
        public int this[int i, int j]
        {
            get
            {

            }
            set
            {

            }
        
        }

        /// <summary>
        /// Checks the columns for a win
        /// </summary>
        /// <param name="test">Player value to check</param>
        /// <returns>True if victory is found and false if victory is not found</returns>
        private bool CheckCols(int test)
        {

        }

        /// <summary>
        /// Checks the rows for a win
        /// </summary>
        /// <param name="test">Player value to check</param>
        /// <returns>True if victory is found and false if victory is not found</returns>
        private bool CheckRows(int test)
        {

        }

        /// <summary>
        /// Checks the major for a win
        /// </summary>
        /// <param name="test">Player value to check</param>
        /// <returns>True if victory is found and false if victory is not found</returns>
        private bool CheckMajorDiag(int test)
        {

        }

        /// <summary>
        /// Checks the minor for a win
        /// </summary>
        /// <param name="test">Player value to check</param>
        /// <returns>True if victory is found and false if victory is not found</returns>
        private bool CheckMinorDiag(int test)
        {

        }

        /// <summary>
        /// Checks the field for a tie
        /// </summary>
        /// <returns>True if tie is found and false if tie is not found</returns>
        private bool CheckTie()
        {

        }

        /// <summary>
        /// Checking all possible types of wins and tie
        /// </summary>
        /// <returns>
        /// 0 if win player O     <br/>
        /// 1 if win player X     <br/>
        /// 2 if tie              <br/>
        /// -1 in any other case
        /// </returns>
        public int Check()
        {

        }
    }

}