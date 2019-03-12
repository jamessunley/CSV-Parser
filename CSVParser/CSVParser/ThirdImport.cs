namespace CSVParser
{
    class TokenImport
    {

        private enum ElementPosistion
        {
            Email = 0,
            Token = 1
        }

        /// <summary>
        /// Do not allow external construction
        /// </summary>
        private TokenImport()
        {

        }

        public static TokenImport FromElements(string[] elements)
        {

            TokenImport retVal = new TokenImport()
            {
                Email = elements[(int)ElementPosistion.Email],
                Token = elements[(int)ElementPosistion.Token]
            };

            return retVal;
        }

        /// <summary>
        /// As received in Creditor CSV (column is b_ext_reference)
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}
