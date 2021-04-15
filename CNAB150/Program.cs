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

        static void Main()
        {
            CnabRecordLayout headerLayout = new CnabRecordLayout(LayoutCharLimit, CnabSeeder.HeaderRules, ' ', "Header");
            CnabRecordLayout detailLayout = new CnabRecordLayout(LayoutCharLimit, CnabSeeder.DetailRules, ' ', "Details");
            CnabRecordLayout traillerLayout = new CnabRecordLayout(LayoutCharLimit, CnabSeeder.TraillerRules, ' ', "Trailler");

            string path = Path.Combine(foldersPath, fileName);
            using StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(Header(headerLayout));
            writer.WriteLine(MainRecords(detailLayout));
            writer.Write(Trailler(traillerLayout));
        }

        private static string Header(CnabRecordLayout headerLayout)
        {
            char recordTypeCode = 'A';
            int remittanceCode = 0;
            string bankAgreementCode = "CÓDIGO DE CONVÊNIO";
            string businessUnitName = "FITBANK PAGAMENTOS ELETRÔNICOS SA";
            int bankCode = 33;
            string bankName = "BANCO SANTANDER";
            DateTime cnabCreationDate = DateTime.Now;
            int sequencialCnabFileNumber = 1;
            int cnabLayoutVersion = 1;
            string barcodePhrase = "CÓDIGO DE BARRAS";

            string[] values = new string[] {
                    recordTypeCode.ToString(),
                    remittanceCode.ToString(),
                    bankAgreementCode,
                    businessUnitName,
                    bankCode.ToString(),
                    bankName,
                    cnabCreationDate.ToString("yyyyMMdd"),
                    sequencialCnabFileNumber.ToString(),
                    cnabLayoutVersion.ToString(),
                    barcodePhrase
                };

            return headerLayout.BuildFrom(values);
        }

        private static string MainRecords(CnabRecordLayout detailLayout)
        {
            char recordTypeCode = 'G';
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
            char collectionMethod = '1'; // CREATE AN ENUM BASED ON CHAR VALUES
            string transactionCode = "238EF6AD";
            int paymentMethod = 3; // CREATE A ENUM FOR [1, 2, 3] = [CASH, CHECK, UNIDENTIFIED]

            string[] values = new string[]
            {
                recordTypeCode.ToString(),
                accountToBeCredited,
                formattedPaymentDate,
                formattedCreditDate,
                barcode,
                amountReceived.ToStandardizedString(),
                fareAmount.ToStandardizedString(),
                strRecordSequencialNumber,
                collectionAgencyCode,
                collectionMethod.ToString(),
                transactionCode,
                paymentMethod.ToString()
            };

            return detailLayout.BuildFrom(values);
        }

        private static string Trailler(CnabRecordLayout traillerLayout)
        {
            char recordTypeCode = 'Z';
            int numOfRecords = 3;
            string strNumOfRecord = numOfRecords.ToString();
            int totalValue = 150;
            string strTotalValue = totalValue.ToString();

            string[] values = new string[] {
                recordTypeCode.ToString(),
                strNumOfRecord,
                strTotalValue
            };

            return traillerLayout.BuildFrom(values);
        }
    }
}
