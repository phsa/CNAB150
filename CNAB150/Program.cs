using System;
using System.IO;
using System.Text;

namespace CNAB150
{
    class Program
    {
        private const string foldersPath = @"C:\CNAB150";
        private const string fileName = "teste.REM";
        private const int LayoutCharLimit = 150;

        static void Main(string[] args)
        {
            string path = Path.Combine(foldersPath, fileName);
            using StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(Header());
            writer.WriteLine(MainRecords());
            writer.Write(Trailler());
        }

        private static string Header()
        {
            CnabRecordRule rule1X = new CnabRecordRule
            {
                Length = 1,
                AllowedCharacters = "0-9a-zA-Z",
                FillingChar = ' ',
                FillAtEnd = true,
                TruncationMethodType = TruncationMethodType.RemoveAtEnd,
            };

            CnabRecordRule rule19 = new CnabRecordRule
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

            string recordTypeCode = "A";
            int remittanceCode = 0;
            string bankAgreementCode = "CÓDIGO DE CONVÊNIO";
            string businessUnitName = "FITBANK PAGAMENTOS ELETRÔNICOS SA";
            int bankCode = 33;
            string strBankCode = bankCode.ToString();
            string bankName = "BANCO SANTANDER";
            DateTime cnabCreationDate = DateTime.Now;
            string formattedCnabCreationDate = cnabCreationDate.ToString("yyyyMMdd"); // FIND A WAY TO PUT THE FORMATING IN THE RULE AND NOT HERE
            int sequencialCnabFileNumber = 1;
            string strSequencialCnabFileNumber = sequencialCnabFileNumber.ToString();
            int cnabLayoutVersion = 1;
            string strCnabLayoutVersion = cnabLayoutVersion.ToString();
            string barcodePhrase = "CÓDIGO DE BARRAS";
            int filled = rule1X.Length + rule19.Length + rule20X.Length + rule20X.Length + rule39.Length + rule20X.Length + rule89.Length + rule69.Length + rule29.Length + rule17X.Length;

            StringBuilder header = new StringBuilder();
            header.Append(rule1X.Apply(recordTypeCode));
            header.Append(rule19.Apply(remittanceCode.ToString()));
            header.Append(rule20X.Apply(bankAgreementCode));
            header.Append(rule20X.Apply(businessUnitName));
            header.Append(rule39.Apply(strBankCode)); // CHECK IF 33.ToString().Length > 3 => EXCEPTION
            header.Append(rule20X.Apply(bankName));
            header.Append(rule89.Apply(formattedCnabCreationDate));
            header.Append(rule69.Apply(strSequencialCnabFileNumber));
            header.Append(rule29.Apply(strCnabLayoutVersion));
            header.Append(rule17X.Apply(barcodePhrase));
            header.Append(string.Empty.PadRight(LayoutCharLimit - filled, ' '));

            return header.ToString();
        }

        private static string MainRecords()
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

            string recordTypeCode = "G";
            string accountToBeCredited = "0123 00012345-0";
            DateTime paymentDate = DateTime.Now;
            string formattedPaymentDate = paymentDate.ToString("yyyyMMdd"); // FIND A WAY TO PUT THE FORMATING IN THE RULE AND NOT HERE
            DateTime creditDate = DateTime.Now;
            string formattedCreditDate = creditDate.ToString("yyyyMMdd"); // FIND A WAY TO PUT THE FORMATING IN THE RULE AND NOT HERE
            string barcode = "85860000000600003282105707082105139388749347"; // CHECK IF barcode.Length == 44 => EXCEPTION
            double amountReceived = 150.5387890;
            double fareAmount = 2.00;
            int recordSequencialNumber = 1;
            string strRecordSequencialNumber = recordSequencialNumber.ToString();
            string collectionAgencyCode = "722";
            char collectionMethod = '1'; // CREATE A ENUM BASED ON CHAR VALUES
            string transactionCode = "238EF6AD";
            int paymentMethod = 3; // CREATE A ENUM FOR [1, 2, 3] = [CASH, CHECK, UNIDENTIFIED]
            int filled = rule1X.Length + rule20X.Length + rule89.Length + rule89.Length + rule44X.Length + rule129.Length + rule79.Length + rule89.Length + rule8X.Length + rule1XCustom.Length + rule23X.Length + rule19Custom.Length;
            string filler = string.Empty.PadRight(LayoutCharLimit - filled, ' ');

            StringBuilder record = new StringBuilder();
            record.Append(rule1X.Apply(recordTypeCode));
            record.Append(rule20X.Apply(accountToBeCredited));
            record.Append(rule89.Apply(formattedPaymentDate));
            record.Append(rule89.Apply(formattedCreditDate));
            record.Append(rule44X.Apply(barcode));
            record.Append(rule129.Apply(amountReceived.ToStandardizedString())); // 9(10)V99 MEANS 10 PLACES FOR THE INTEGER PART AND 2 FOR DECIMALS PLACES
            record.Append(rule79.Apply(fareAmount.ToStandardizedString())); // 9(5)V99 MEANS 10 PLACES FOR THE INTEGER PART AND 2 FOR DECIMALS PLACES
            record.Append(rule89.Apply(strRecordSequencialNumber));
            record.Append(rule8X.Apply(collectionAgencyCode));
            record.Append(rule1XCustom.Apply(collectionMethod.ToString()));
            record.Append(rule23X.Apply(transactionCode));
            record.Append(rule19Custom.Apply(paymentMethod.ToString()));
            record.Append(filler);

            return record.ToString();
        }

        private static string Trailler()
        {
            CnabRecordRule rule1X = new CnabRecordRule
            {
                Length = 1,
                AllowedCharacters = "0-9a-zA-Z",
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


            string recordTypeCode = "Z";
            int numOfRecords = 3;
            string strNumOfRecord = numOfRecords.ToString();
            int totalValue = 150;
            string strTotalValue = totalValue.ToString();
            int filled = rule1X.Length + rule69.Length + rule179.Length;

            StringBuilder trailler = new StringBuilder();
            trailler.Append(rule1X.Apply(recordTypeCode));
            trailler.Append(rule69.Apply(strNumOfRecord));
            trailler.Append(rule179.Apply(strTotalValue));
            trailler.Append(string.Empty.PadRight(LayoutCharLimit - filled, ' '));

            return trailler.ToString();
        }
    }
}
