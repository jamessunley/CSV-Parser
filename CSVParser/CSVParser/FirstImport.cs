using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParser
{
    class CreditorsImport
    {
        private enum ElementPosistion
        {
            Email = 0,
            Token = 1,
            Value1 = 2,
            Value2 = 3,
            Value3 = 4
        }

        /// <summary>
        /// Do not allow external construction
        /// </summary>
        private CreditorsImport()
        {

        }

        public static CreditorsImport FromElements(string[] elements)
        {

            CreditorsImport retVal = new CreditorsImport()
            {
                Email = elements[(int)ElementPosistion.Email],
                Token = elements[(int)ElementPosistion.Token],
                Value1 = elements[(int)ElementPosistion.Value1],
                Value2 = elements[(int)ElementPosistion.Value2],
                Value3 = elements[(int)ElementPosistion.Value3]
            };

            return retVal;
        }

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 3rd value
        /// </summary>
        public string Value1 { get; set; }

        /// <summary>
        /// 3rd value
        /// </summary>
        public string Value2 { get; set; }

        /// <summary>
        /// 3rd value
        /// </summary>
        public string Value3 { get; set; }
    }
}
