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
            
            StringBuilder header = new StringBuilder();
            header.Append(headerLayout.ApplyNextRule(recordTypeCode.ToString()));
            header.Append(headerLayout.ApplyNextRule(remittanceCode.ToString()));
            header.Append(headerLayout.ApplyNextRule(bankAgreementCode));
            header.Append(headerLayout.ApplyNextRule(businessUnitName));
            header.Append(headerLayout.ApplyNextRule(bankCode.ToString()));
            header.Append(headerLayout.ApplyNextRule(bankName));
            header.Append(headerLayout.ApplyNextRule(cnabCreationDate.ToString("yyyyMMdd")));// FIND A WAY TO PUT THE FORMATING IN THE RULE INSTEAD OF HERE
            header.Append(headerLayout.ApplyNextRule(sequencialCnabFileNumber.ToString()));
            header.Append(headerLayout.ApplyNextRule(cnabLayoutVersion.ToString()));
            header.Append(headerLayout.ApplyNextRule(barcodePhrase));
            header.Append(headerLayout.Filler);

            return header.ToString();
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

            StringBuilder record = new StringBuilder();
            record.Append(detailLayout.ApplyNextRule(recordTypeCode.ToString()));
            record.Append(detailLayout.ApplyNextRule(accountToBeCredited));
            record.Append(detailLayout.ApplyNextRule(formattedPaymentDate));
            record.Append(detailLayout.ApplyNextRule(formattedCreditDate));
            record.Append(detailLayout.ApplyNextRule(barcode));
            record.Append(detailLayout.ApplyNextRule(amountReceived.ToStandardizedString())); // 9(10)V99 MEANS 10 PLACES FOR THE INTEGER PART AND 2 FOR DECIMALS PLACES
            record.Append(detailLayout.ApplyNextRule(fareAmount.ToStandardizedString())); // 9(5)V99 MEANS 10 PLACES FOR THE INTEGER PART AND 2 FOR DECIMALS PLACES
            record.Append(detailLayout.ApplyNextRule(strRecordSequencialNumber));
            record.Append(detailLayout.ApplyNextRule(collectionAgencyCode));
            record.Append(detailLayout.ApplyNextRule(collectionMethod.ToString()));
            record.Append(detailLayout.ApplyNextRule(transactionCode));
            record.Append(detailLayout.ApplyNextRule(paymentMethod.ToString()));
            record.Append(detailLayout.Filler);

            return record.ToString();
        }

        private static string Trailler(CnabRecordLayout traillerLayout)
        {
            char recordTypeCode = 'Z';
            int numOfRecords = 3;
            string strNumOfRecord = numOfRecords.ToString();
            int totalValue = 150;
            string strTotalValue = totalValue.ToString();

            StringBuilder trailler = new StringBuilder();
            trailler.Append(traillerLayout.ApplyNextRule(recordTypeCode.ToString()));
            trailler.Append(traillerLayout.ApplyNextRule(strNumOfRecord));
            trailler.Append(traillerLayout.ApplyNextRule(strTotalValue));
            trailler.Append(traillerLayout.Filler);

            return trailler.ToString();
        }
    }
}
