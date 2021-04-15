using System;
using System.Linq;
using System.Text;

namespace CNAB150
{
    public class CnabRecordLayout
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
                throw new Exception($"Set of cnab rules has invalid sum of length limit (filledLength = {filledLength}, recordLimit = {length})"); // USE CUSTOMIZED EXCEPTIONS
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


        public string BuildFrom(string[] values)
        {
            if (_rules.Length == values.Length)
            {
                int nextBackup = _next;
                Reset();

                StringBuilder record = new StringBuilder();
                foreach (string value in values)
                {
                    record.Append(NextRule().Apply(value));
                }
                record.Append(Filler);

                _next = nextBackup;

                return record.ToString();
            }
            else
            {
                throw new Exception($"Incompatible number of values ({values.Length}). [number of rules = {_rules.Length}]"); // USE CUSTOMIZED EXCEPTIONS
            }
        }

        private void Reset()
        {
            _next = 0;
        }

        private bool HasNext()
        {
            return _next < _rules.Length;
        }

        private int FilledLength()
        {
            return _rules.Aggregate(0, (acc, rule) => acc + rule.Length);
        }

        private CnabRecordRule NextRule()
        {
            return HasNext() ? _rules[_next++] : throw new Exception($"There was no rule left."); // USE CUSTOMIZED EXCEPTIONS;
        }

    }
}
