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
            writer.WriteLine(Trailler());
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
            header.Append(bankAgreementCode.Fit(20, ' ', bankAgreementCode.PadRight));
            header.Append(businessUnitName.Fit(20, ' ', businessUnitName.PadRight));
            header.Append(strBankCode.Fit(3, '0', strBankCode.PadLeft)); // CHECAR SE 33.ToString().Length > 3 => EXCEÇÃO
            header.Append(bankName.Fit(20, ' ', bankName.PadRight));
            header.Append(formattedCnabCreationDate.Fit(8, '0', formattedCnabCreationDate.PadLeft));
            header.Append(strSequencialCnabFileNumber.Fit(6, '0', strSequencialCnabFileNumber.PadLeft));
            header.Append(strCnabLayoutVersion.Fit(2, '0', strCnabLayoutVersion.PadLeft));
            header.Append(barcodePhrase.Fit(17, ' ', barcodePhrase.PadRight));
            header.Append(filler);

            return header.ToString();
        }

        private static string MainRecords()
        {
            string recordTypeCode = "G";
            string filler = string.Empty.PadRight(9, ' ');

            StringBuilder record = new StringBuilder();


            return record.ToString();
        }

        private static string Trailler()
        {
            string recordTypeCode = "Z";
            int numOfRecords = 3;
            string strNumOfRecord = numOfRecords.ToString();
            int totalValue = 150;
            string strTotalValue = totalValue.ToString();
            string filler = string.Empty.PadRight(126, ' ');

            StringBuilder trailler = new StringBuilder();
            trailler.Append(recordTypeCode);
            trailler.Append(strNumOfRecord.Fit(6, '0', strNumOfRecord.PadLeft));
            trailler.Append(strTotalValue.Fit(17, '0', strTotalValue.PadLeft));
            trailler.Append(filler);

            return trailler.ToString();
        }
    }
}
