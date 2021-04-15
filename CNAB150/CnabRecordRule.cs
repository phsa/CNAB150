using System;
using System.Text.RegularExpressions;

namespace CNAB150
{

    public delegate string Truncate(string str, int length);
    public delegate string Fill(string str, int lengthLimit, char fillerChar);

    public class CnabRecordRule
    {
        private int _length;
        private string _allowedCharacters;
        private Regex _expression;
        private char _fillingChar;
        private bool _fillAtEnd;
        private Fill _fillingMethod;
        private TruncationMethodType _truncationMethodType;
        private Truncate _truncationMethod;

        public string Description { get; set; }
        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
                UpdateRegularExpression();
            }
        }
        public string AllowedCharacters
        {
            get
            {
                return _allowedCharacters;
            }
            set
            {
                _allowedCharacters = value;
                UpdateRegularExpression();
            }
        }
        public char FillingChar
        {
            get
            {
                return _fillingChar;
            }
            set
            {
                _fillingChar = value;
                UpdateRegularExpression();
            }
        }
        public bool FillAtEnd {
            get
            {
                return _fillAtEnd;
            }
            set
            {
                _fillAtEnd = value;
                if (value)
                {
                    _fillingMethod = StringUtils.FillAtEnd;
                }
                else
                {
                    _fillingMethod = StringUtils.FillAtStart;
                }
            } 
        }
        public TruncationMethodType TruncationMethodType
        {
            get
            {
                return _truncationMethodType;
            }
            set
            {
                _truncationMethodType = value;
                _truncationMethod = value switch
                {
                    TruncationMethodType.RemoveAtStart => StringUtils.TruncateFromEnd,
                    TruncationMethodType.RemoveAtEnd => StringUtils.TruncateFromStart,
                    TruncationMethodType.KeepMiddle => StringUtils.TruncateAtSides,
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
            return _expression.IsMatch(str);
        }

        private void UpdateRegularExpression()
        {
            string pattern = $"^[{_fillingChar}{_allowedCharacters}]{{{_length},{_length}}}$";
            _expression = new Regex(pattern);
        }

        private string Fit(string str)
        {
            if (str.Length > _length)
            {
                if (_truncationMethod == null)
                {
                    throw new Exception($"The string \'{str}\' is bigger than rule {_length} char limit and it doesn't allow truncation."); // USE CUSTOMIZED EXCEPTIONS
                }
                return _truncationMethod(str, _length);
            }
            else if (str.Length < _length)
            {
                return _fillingMethod(str, _length, _fillingChar);
            }
            else
            {
                return str;
            }
        }
    }
}
