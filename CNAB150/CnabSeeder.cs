namespace CNAB150
{
    public class CnabSeeder
    {
        public static CnabRecordRule[] HeaderRules
        {
            get
            {
                CnabRecordRule rule1X = new CnabRecordRule // THIS SHOULD BE STRICT RULE, THE LENGTH SHOULD BE EXACT
                {
                    Length = 1,
                    AllowedCharacters = "A",
                    FillingChar = ' ',
                    FillAtEnd = true,
                    TruncationMethodType = TruncationMethodType.RemoveAtEnd,
                };

                CnabRecordRule rule19 = new CnabRecordRule // THIS SHOULD BE STRICT RULE, THE LENGTH SHOULD BE EXACT
                {
                    Length = 1,
                    AllowedCharacters = "0-9",
                    FillingChar = '0',
                    FillAtEnd = false,
                    TruncationMethodType = TruncationMethodType.NotAllowed,
                };

                CnabRecordRule rule20X = new CnabRecordRule
                {
                    Length = 20,
                    AllowedCharacters = "0-9a-zA-Z\\s",
                    FillingChar = ' ',
                    FillAtEnd = true,
                    TruncationMethodType = TruncationMethodType.RemoveAtEnd,
                };

                CnabRecordRule rule39 = new CnabRecordRule
                {
                    Length = 3,
                    AllowedCharacters = "0-9",
                    FillingChar = '0',
                    FillAtEnd = false,
                    TruncationMethodType = TruncationMethodType.NotAllowed,
                };

                CnabRecordRule rule89 = new CnabRecordRule
                {
                    Length = 8,
                    AllowedCharacters = "0-9",
                    FillingChar = '0',
                    FillAtEnd = false,
                    TruncationMethodType = TruncationMethodType.RemoveAtEnd,
                };

                CnabRecordRule rule69 = new CnabRecordRule
                {
                    Length = 6,
                    AllowedCharacters = "0-9",
                    FillingChar = '0',
                    FillAtEnd = false,
                    TruncationMethodType = TruncationMethodType.NotAllowed,
                };

                CnabRecordRule rule29 = new CnabRecordRule
                {
                    Length = 2,
                    AllowedCharacters = "0-9",
                    FillingChar = '0',
                    FillAtEnd = false,
                    TruncationMethodType = TruncationMethodType.NotAllowed,
                };

                CnabRecordRule rule17X = new CnabRecordRule
                {
                    Length = 17,
                    AllowedCharacters = "0-9a-zA-Z\\s",
                    FillingChar = ' ',
                    FillAtEnd = true,
                    TruncationMethodType = TruncationMethodType.RemoveAtEnd,
                };

                return new CnabRecordRule[]
                {
                    rule1X,
                    rule19,
                    rule20X,
                    rule20X,
                    rule39,
                    rule20X,
                    rule89,
                    rule69,
                    rule29,
                    rule17X
                };

            }
        }

        public static CnabRecordRule[] DetailRules
        {
            get
            {
                CnabRecordRule rule1X = new CnabRecordRule
                {
                    Length = 1, // THIS SHOULD BE STRICT RULE, THE LENGTH SHOULD BE EXACT
                    AllowedCharacters = "G", 
                    FillingChar = ' ',
                    FillAtEnd = true,
                    TruncationMethodType = TruncationMethodType.NotAllowed, // SHOULDN'T ALLOW FILLING
                };

                CnabRecordRule rule20X = new CnabRecordRule
                {
                    Length = 20,
                    AllowedCharacters = @"0-9a-zA-Z\s-/",
                    FillingChar = ' ',
                    FillAtEnd = true,
                    TruncationMethodType = TruncationMethodType.RemoveAtEnd,
                };

                CnabRecordRule rule89 = new CnabRecordRule
                {
                    Length = 8, // THIS SHOULD BE STRICT RULE, THE LENGTH SHOULD BE EXACT
                    AllowedCharacters = "0-9",
                    FillingChar = '0',
                    FillAtEnd = false,
                    TruncationMethodType = TruncationMethodType.NotAllowed, // SHOULDN'T ALLOW FILLING
                };

                CnabRecordRule rule44X = new CnabRecordRule
                {
                    Length = 44, // THIS SHOULD BE STRICT RULE, THE LENGTH SHOULD BE EXACT
                    AllowedCharacters = "0-9a-zA-Z\\s",
                    FillingChar = ' ',
                    FillAtEnd = true,
                    TruncationMethodType = TruncationMethodType.NotAllowed, // SHOULDN'T ALLOW FILLING
                };

                CnabRecordRule rule129 = new CnabRecordRule
                {
                    Length = 12,
                    AllowedCharacters = "0-9",
                    FillingChar = '0',
                    FillAtEnd = false,
                    TruncationMethodType = TruncationMethodType.NotAllowed,
                };

                CnabRecordRule rule79 = new CnabRecordRule
                {
                    Length = 7,
                    AllowedCharacters = "0-9",
                    FillingChar = '0',
                    FillAtEnd = false,
                    TruncationMethodType = TruncationMethodType.NotAllowed,
                };

                CnabRecordRule rule8X = new CnabRecordRule
                {
                    Length = 8,
                    AllowedCharacters = "0-9a-zA-Z",
                    FillingChar = ' ',
                    FillAtEnd = true,
                    TruncationMethodType = TruncationMethodType.RemoveAtEnd,
                };

                CnabRecordRule rule1XCustom = new CnabRecordRule
                {
                    Length = 1, // THIS SHOULD BE STRICT RULE, THE LENGTH SHOULD BE EXACT
                    AllowedCharacters = "1-6a-f",
                    FillingChar = ' ',
                    FillAtEnd = true,
                    TruncationMethodType = TruncationMethodType.NotAllowed, // SHOULDN'T ALLOW FILLING
                };

                CnabRecordRule rule23X = new CnabRecordRule
                {
                    Length = 23,
                    AllowedCharacters = "0-9a-zA-Z",
                    FillingChar = ' ',
                    FillAtEnd = true,
                    TruncationMethodType = TruncationMethodType.RemoveAtEnd,
                };

                CnabRecordRule rule19Custom = new CnabRecordRule
                {
                    Length = 1, // THIS SHOULD BE STRICT RULE, THE LENGTH SHOULD BE EXACT
                    AllowedCharacters = "123",
                    FillingChar = '0',
                    FillAtEnd = false,
                    TruncationMethodType = TruncationMethodType.NotAllowed, // SHOULDN'T ALLOW FILLING
                };

                return new CnabRecordRule[] 
                {
                    rule1X,
                    rule20X,
                    rule89,
                    rule89,
                    rule44X,
                    rule129,
                    rule79,
                    rule89,
                    rule8X,
                    rule1XCustom,
                    rule23X,
                    rule19Custom
                };
            }
        }
        
        public static CnabRecordRule[] TraillerRules
        {
            get
            {
                CnabRecordRule rule1X = new CnabRecordRule
                {
                    Length = 1,
                    AllowedCharacters = "Z", // CHANGE TO JUST 'Z'
                    FillingChar = ' ',
                    FillAtEnd = true,
                    TruncationMethodType = TruncationMethodType.RemoveAtEnd,
                };

                CnabRecordRule rule69 = new CnabRecordRule
                {
                    Length = 6,
                    AllowedCharacters = "0-9",
                    FillingChar = '0',
                    FillAtEnd = false,
                    TruncationMethodType = TruncationMethodType.RemoveAtEnd,
                };

                CnabRecordRule rule179 = new CnabRecordRule
                {
                    Length = 17,
                    AllowedCharacters = "0-9",
                    FillingChar = '0',
                    FillAtEnd = false,
                    TruncationMethodType = TruncationMethodType.RemoveAtEnd,
                };

                return new CnabRecordRule[] 
                {
                    rule1X,
                    rule69,
                    rule179
                };
            }
        }
    }
}
