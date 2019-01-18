using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VG.OrderProcessing.Common
{
    /// <summary>
    /// Helper class for order related utility methods
    /// </summary>
    public class OrderHelper
    {
        #region properties/Fields

        //Random generator
        private static Random random = new Random();

        #endregion

        #region Methods

        /// <summary>
        /// Generate random order confirmation number from VC side.
        /// This number will be sent to the customer as a reference
        /// The logic could be customize as per the VC company policy
        /// </summary>
        /// <returns>Randomly generated order confirmation number</returns>
        public string GenerateOrderConformationNumber()
        {
            StringBuilder Builder = new StringBuilder();
            
            //Random char list
            const string Chars = Constants.ORDER_CONFORMATION_CHAR_LIST;

            //Guid based random string
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            string GuidStr = string.Format("{0:x}", i - DateTime.Now.Ticks).ToUpper();

            //Generate random string with given lenght
            string RandomString = new string(Enumerable.Repeat(Chars, Constants.ORDER_CONFORMATION_LENGTH)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            Builder.Append(RandomString);
            Builder.Append(GuidStr);

            return Builder.ToString();
        }  

    #endregion
}
}
