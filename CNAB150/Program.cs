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
            string filler = string.Empty.PadRight(52, ' ');

            StringBuilder header = new StringBuilder();
            header.Append(recordTypeCode);
            header.Append(remittanceCode);
            header.Append(bankAgreementCode.Fit(20, ' ', StringUtils.FillAtEnd));
            header.Append(businessUnitName.Fit(20, ' ', StringUtils.FillAtEnd));
            header.Append(strBankCode.Fit(3, '0', StringUtils.FillAtStart)); // CHECK IF 33.ToString().Length > 3 => EXCEPTION
            header.Append(bankName.Fit(20, ' ', StringUtils.FillAtEnd));
            header.Append(formattedCnabCreationDate.Fit(8, '0', StringUtils.FillAtStart));
            header.Append(strSequencialCnabFileNumber.Fit(6, '0', StringUtils.FillAtStart));
            header.Append(strCnabLayoutVersion.Fit(2, '0', StringUtils.FillAtStart));
            header.Append(barcodePhrase.Fit(17, ' ', StringUtils.FillAtEnd));
            header.Append(filler);

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
            char recordTypeCode = 'Z';
            int numOfRecords = 3;
            string strNumOfRecord = numOfRecords.ToString();
            int totalValue = 150;
            string strTotalValue = totalValue.ToString();
            string filler = string.Empty.PadRight(126, ' ');

            StringBuilder trailler = new StringBuilder();
            trailler.Append(recordTypeCode);
            trailler.Append(strNumOfRecord.Fit(6, '0', StringUtils.FillAtStart));
            trailler.Append(strTotalValue.Fit(17, '0', StringUtils.FillAtStart));
            trailler.Append(string.Empty.PadRight(150 - trailler.Length, ' '));

            return trailler.ToString();
        }
    }
}
