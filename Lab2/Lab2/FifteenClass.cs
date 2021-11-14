using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Lab2
{

    public class FifteenClass
    {

        /// Declaring private class variables

        /// <summary>
        /// Initialize count to 0, the number of moves performed
        /// Initialize a 6 by 6 array field. 
        /// Inside a filled field with values from 1 to 15 and one empty cell with a value of -1
        /// around itself is a 4 by 4 field surrounded by zeros. 
        /// It is also taken into account that all variations of creation are not random 
        /// and all combinations of numbers provide for victory.
        /// </summary>
        public FifteenClass()
        {
            
        }

        /// <summary>
        /// Public property for the move counter
        /// </summary>
        public int Count
        {

        }

        /// <summary>
        /// Open indexator
        /// </summary>
        /// <param name="i">Row number</param>
        /// <param name="j">Column number</param>
        /// <returns>The value in the specified cell</returns>
        public int this[int i, int j]
        {
            
        }

        /// <summary>
        /// Checks if there is an empty cell at the top, bottom, left, or right
        /// </summary>
        /// <param name="i">Row number</param>
        /// <param name="j">Column number</param>
        /// <returns>Coordinates of an empty cell if it is nearby or coordinates 0 0</returns>
        public int[] Twist(int i, int j)
        {
            
        }

        /// <summary>
        /// Check winnings
        /// </summary>
        /// <returns>True if win and false if lose</returns>
        public bool Check()
        {
            
        }
    }
}