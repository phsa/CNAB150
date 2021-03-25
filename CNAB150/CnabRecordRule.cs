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
        public TruncationMethodType TruncationMethodType { get; set; }

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
        private Func<string, int, string> TruncationMethod
        {
            get
            {
                return TruncationMethodType switch
                {
                    TruncationMethodType.RemoveAtStart => StringUtils.TruncateFromEnd,
                    TruncationMethodType.RemoveAtEnd => StringUtils.TruncateFromStart,
                    TruncationMethodType.LeaveMiddle => StringUtils.TruncateAtSides,
                    TruncationMethodType.NotAllowed => null,
                    _ => null,
                };
            }
        }

        public string Apply(string str)
        {
            //ADD ALLOWED CHARACTERS CHECK [REPLACE OR REMOVE METHODS (OR THROW AN EXCEPTION)]
            string adjusted = Fit(str);
            return adjusted;
        }

        public bool Check(string str)
        {
            return Expression.IsMatch(str);
        }

        private string Fit(string str)
        {
            if (str.Length > Length)
            {
                if (TruncationMethod == null)
                {
                    throw new Exception($"The string \'{str}\' is bigger than rule {Length} char limit and the rule doesn't allow truncation.");
                }
                return TruncationMethod(str, Length);
            }
            else if (str.Length < Length)
            {
                return FillingMethod(str, Length, FillingChar);
            }
            else
            {
                return str;
            }
        }
    }
}
