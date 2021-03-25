using System;
using System.IO;
using System.Text;

namespace CNAB150
{
    class Program
    {
        private const string foldersPath = @"C:\CNAB150";
        private const string fileName = "teste.REM";

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
            };

            CnabRecordRule rule19 = new CnabRecordRule
            {
                Length = 1,
                AllowedCharacters = "0-9",
                FillingChar = '0',
                FillAtEnd = false,
            };

            CnabRecordRule rule20X = new CnabRecordRule
            {
                Length = 20,
                AllowedCharacters = "0-9a-zA-Z\\s",
                FillingChar = ' ',
                FillAtEnd = true,
            };

            CnabRecordRule rule39 = new CnabRecordRule
            {
                Length = 3,
                AllowedCharacters = "0-9",
                FillingChar = '0',
                FillAtEnd = false,
            };

            CnabRecordRule rule89 = new CnabRecordRule
            {
                Length = 8,
                AllowedCharacters = "0-9",
                FillingChar = '0',
                FillAtEnd = false,
            };

            CnabRecordRule rule69 = new CnabRecordRule
            {
                Length = 6,
                AllowedCharacters = "0-9",
                FillingChar = '0',
                FillAtEnd = false,
            };

            CnabRecordRule rule29 = new CnabRecordRule
            {
                Length = 2,
                AllowedCharacters = "0-9",
                FillingChar = '0',
                FillAtEnd = false,
            };

            CnabRecordRule rule17X = new CnabRecordRule
            {
                Length = 17,
                AllowedCharacters = "0-9a-zA-Z\\s",
                FillingChar = ' ',
                FillAtEnd = true,
            };

            CnabRecordRule ruleFiller = new CnabRecordRule
            {
                Length = 52,
                AllowedCharacters = "0-9a-zA-Z\\s",
                FillingChar = ' ',
                FillAtEnd = true,
            };

            string recordTypeCode = "A";
            int remittanceCode = 0;
            string bankAgreementCode = "CÓDIGO DE CONVÊNIO";
            string businessUnitName = "FITBANK PAGAMENTOS ELETRÔNICOS SA";
            int bankCode = 33;
            string strBankCode = bankCode.ToString();
            string bankName = "BANCO SANTANDER";
            DateTime cnabCreationDate = DateTime.Now;
            string formattedCnabCreationDate = cnabCreationDate.ToString("yyyyMMdd");
            int sequencialCnabFileNumber = 1;
            string strSequencialCnabFileNumber = sequencialCnabFileNumber.ToString();
            int cnabLayoutVersion = 1;
            string strCnabLayoutVersion = cnabLayoutVersion.ToString();
            string barcodePhrase = "CÓDIGO DE BARRAS";

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
            header.Append(ruleFiller.Apply(string.Empty));

            return header.ToString();
        }

        private static string MainRecords()
        {
            char recordTypeCode = 'G';
            string accountToBeCredited = "0123 00012345-0";
            DateTime paymentDate = DateTime.Now;
            string formattedPaymentDate = paymentDate.ToString("yyyyMMdd");
            DateTime creditDate = DateTime.Now;
            string formattedCreditDate = creditDate.ToString("yyyyMMdd");
            string barcode = "85860000000600003282105707082105139388749347"; // CHECK IF barcode.Length == 44 => EXCEPTION
            double amountReceived = 150.5387890;
            double fareAmount = 2.00;
            int recordSequencialNumber = 1;
            string strRecordSequencialNumber = recordSequencialNumber.ToString();
            string collectionAgencyCode = "722";
            char collectionMethod = '1'; // CREATE A ENUM BASED ON CHAR VALUES
            string transactionCode = "238ef6ad";
            int paymentMethod = 3; // CREATE A ENUM FOR [1, 2, 3] = [CASH, CHECK, UNIDENTIFIED]
            string filler = string.Empty.PadRight(9, ' ');

            StringBuilder record = new StringBuilder();
            record.Append(recordTypeCode);
            record.Append(accountToBeCredited.Fit(20, ' ', StringUtils.FillAtEnd));
            record.Append(formattedPaymentDate.Fit(8, '0', StringUtils.FillAtStart));
            record.Append(formattedCreditDate.Fit(8, '0', StringUtils.FillAtStart));
            record.Append(barcode);
            record.Append(amountReceived.ToStandardizedString(12, '0', StringUtils.FillAtStart)); // 9(10)V99 MEANS 10 PLACES FOR THE INTEGER PART AND 2 FOR DECIMALS PLACES
            record.Append(fareAmount.ToStandardizedString(7, '0', StringUtils.FillAtStart)); // 9(5)V99 MEANS 10 PLACES FOR THE INTEGER PART AND 2 FOR DECIMALS PLACES
            record.Append(strRecordSequencialNumber.Fit(8, '0', StringUtils.FillAtStart));
            record.Append(collectionAgencyCode.Fit(8, ' ', StringUtils.FillAtEnd));
            record.Append(collectionMethod);
            record.Append(transactionCode.Fit(23, ' ', StringUtils.FillAtEnd));
            record.Append(paymentMethod);
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
            };

            CnabRecordRule rule69 = new CnabRecordRule
            {
                Length = 6,
                AllowedCharacters = "0-9",
                FillingChar = '0',
                FillAtEnd = false,
            };

            CnabRecordRule rule179 = new CnabRecordRule
            {
                Length = 17,
                AllowedCharacters = "0-9",
                FillingChar = '0',
                FillAtEnd = false,
            };

            CnabRecordRule ruleFiller = new CnabRecordRule
            {
                Length = 126,
                AllowedCharacters = "0-9a-zA-Z\\s",
                FillingChar = ' ',
                FillAtEnd = true,
            };


            string recordTypeCode = "Z";
            int numOfRecords = 3;
            string strNumOfRecord = numOfRecords.ToString();
            int totalValue = 150;
            string strTotalValue = totalValue.ToString();

            StringBuilder trailler = new StringBuilder();
            trailler.Append(rule1X.Apply(recordTypeCode));
            trailler.Append(rule69.Apply(strNumOfRecord));
            trailler.Append(rule179.Apply(strTotalValue));
            trailler.Append(ruleFiller.Apply(string.Empty));

            return trailler.ToString();
        }
    }
}
