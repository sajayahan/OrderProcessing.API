using System;
using System.Collections.Generic;
using System.Text;

namespace VG.OrderProcessing.Common
{
    /// <summary>
    /// All the constants will be defined in this class
    /// </summary>
   public class Constants
    {
        /// <summary>
        /// Use in orde confirmation number generation logic
        /// </summary>
        public const int ORDER_CONFORMATION_LENGTH= 4;

        /// <summary>
        /// Char pool for confirmation number generation logic
        /// </summary>
        public const string ORDER_CONFORMATION_CHAR_LIST = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
}
