using System;
using System.Text.RegularExpressions;

namespace CNAB150
{
    class CnabRecordRule
    {
        public int Length { get; set; }
        public string AllowedCharacters { get; set; }
        public char FillingChar { get; set; }
        public string Description { get; set; }
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
            return str.Fit(Length, FillingChar, FillingMethod); //ADD ALLOWED CHARACTERS CHECK [REPLACE OR REMOVE METHODS]
        }

        public bool Check(string str)
        {
            return Expression.IsMatch(str);
        }
    }
}
