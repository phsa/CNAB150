using System;
using System.Linq;

namespace CNAB150
{
    class CnabRecordLayout
    {
        private readonly int _length;
        private readonly CnabRecordRule[] _rules;
        private readonly char _fillerChar;
        private int _next = 0;

        public string Description { get; set; }

        public CnabRecordLayout(int length, CnabRecordRule[] rules, char filler)
        {
            _length = length;
            _fillerChar = filler;
            _rules = rules;
            int filledLength = FilledLength();
            if (_length < filledLength)
                throw new Exception($"Set of cnab rules has invalid sum of length limit (filledLength = {filledLength}, recordLimit = {length})");
        }

        public CnabRecordLayout(int length, CnabRecordRule[] rules, char filler, string description) : this(length, rules, filler)
        {
            Description = description;
        }

        public string Filler
        {
            get
            {
                return string.Empty.PadRight(_length - FilledLength(), _fillerChar);
            }
        }

        public string ApplyNextRule(string value)
        {
            return NextRule().Apply(value);
        }

        private bool HasNext()
        {
            return (_next < _length);
        }

        private int FilledLength()
        {
            return _rules.Aggregate(0, (acc, rule) => acc + rule.Length);
        }

        private CnabRecordRule NextRule()
        {
            return HasNext() ? _rules[_next++] : null;
        }

    }
}
