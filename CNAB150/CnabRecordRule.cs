using System;
using System.Text.RegularExpressions;

namespace CNAB150
{
    class CnabRecordRule
    {
        public int Length { get; set; }
        public string AllowedCharacters { get; set; }
        public string Description { get; set; }
        public char FillingChar { get; set; }
        public bool FillAtEnd { get; set; }

        private Regex Expression
        {
            get
            {
                string pattern = $"^[{FillingChar}{AllowedCharacters}]{{{Length},{Length}}}$";
                return new Regex(pattern);
            }
        }
        private Func<string, int, char, string> FillingMethod
        {
            get
            {
                if (FillAtEnd)
                {
                    return StringUtils.FillAtEnd;
                }
                else
                {
                    return StringUtils.FillAtStart;
                }
            }
        }

        public string Apply(string str)
        {
            //ADD ALLOWED CHARACTERS CHECK [REPLACE OR REMOVE METHODS]
            //ADD TRUNCATE METHODS [REMOVE AT END, AT START, AT BOTH METHODS (THROW AN EXCEPTION)]
            return str.Fit(Length, FillingChar, FillingMethod); 
        }

        public bool Check(string str)
        {
            return Expression.IsMatch(str);
        }
    }
}
