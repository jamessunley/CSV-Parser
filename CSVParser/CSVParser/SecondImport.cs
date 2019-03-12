using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParser
{
    class DatasetImport
    {
        private enum ElementPosistion
        {
            Email = 0,
            Token = 1,
            Value1 = 2
        }

        /// <summary>
        /// Do not allow external construction
        /// </summary>
        private DatasetImport()
        {

        }

        public static DatasetImport FromElements(string[] elements)
        {

            DatasetImport retVal = new DatasetImport()
            {
                Email = elements[(int)ElementPosistion.Email],
                Token = elements[(int)ElementPosistion.Token],
                Value1 = elements[(int)ElementPosistion.Value1]
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
    }
}
