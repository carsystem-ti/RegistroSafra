using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.Pre_LCM
{

    public class PreLCM
    {
        public Journalvoucher JournalVoucher { get; set; }
    }

    public class Journalvoucher
    {
        public Journalentry JournalEntry { get; set; }
    }

    public class Journalentry
    {
        public string ReferenceDate { get; set; }
        public string Memo { get; set; }
        public string Reference { get; set; }
        public string Reference2 { get; set; }
        public string TransactionCode { get; set; }
        public string ProjectCode { get; set; }
        public string TaxDate { get; set; }
        public int? JdtNum { get; set; }
        public object Indicator { get; set; }
        public string UseAutoStorno { get; set; }
        public object StornoDate { get; set; }
        public object VatDate { get; set; }
        public int? Series { get; set; }
        public string StampTax { get; set; }
        public string DueDate { get; set; }
        public string AutoVAT { get; set; }
        public int? Number { get; set; }
        public object FolioNumber { get; set; }
        public object FolioPrefixString { get; set; }
        public string ReportEU { get; set; }
        public string Report347 { get; set; }
        public string Printed { get; set; }
        public object LocationCode { get; set; }
        public string OriginalJournal { get; set; }
        public int? Original { get; set; }
        public string BaseReference { get; set; }
        public string BlockDunningLetter { get; set; }
        public string AutomaticWT { get; set; }
        public float? WTSum { get; set; }
        public float? WTSumSC { get; set; }
        public float? WTSumFC { get; set; }
        public object SignatureInputMessage { get; set; }
        public object SignatureDigest { get; set; }
        public object CertificationNumber { get; set; }
        public object PrivateKeyVersion { get; set; }
        public string Corisptivi { get; set; }
        public string Reference3 { get; set; }
        public object DocumentType { get; set; }
        public string DeferredTax { get; set; }
        public object BlanketAgreementNumber { get; set; }
        public object OperationCode { get; set; }
        public string ResidenceNumberType { get; set; }
        public string ECDPostingType { get; set; }
        public object ExposedTransNumber { get; set; }
        public object PointOfIssueCode { get; set; }
        public object Letter { get; set; }
        public object FolioNumberFrom { get; set; }
        public object FolioNumberTo { get; set; }
        public string IsCostCenterTransfer { get; set; }
        public object ReportingSectionControlStatementVAT { get; set; }
        public string ExcludeFromTaxReportControlStatementVAT { get; set; }
        public object SAPPassport { get; set; }
        public object Cig { get; set; }
        public object Cup { get; set; }
        public string AdjustTransaction { get; set; }
        public Journalentryline[] JournalEntryLines { get; set; }
        public object[] WithholdingTaxDataCollection { get; set; }
    }

    public class Journalentryline
    {
        public int? Line_ID { get; set; }
        public string AccountCode { get; set; }
        public float? Debit { get; set; }
        public float? Credit { get; set; }
        public float? FCDebit { get; set; }
        public float? FCCredit { get; set; }
        public object FCCurrency { get; set; }
        public string DueDate { get; set; }
        public string ShortName { get; set; }
        public string ContraAccount { get; set; }
        public string LineMemo { get; set; }
        public string ReferenceDate1 { get; set; }
        public object ReferenceDate2 { get; set; }
        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string ProjectCode { get; set; }
        public string CostingCode { get; set; }
        public string TaxDate { get; set; }
        public float? BaseSum { get; set; }
        public object TaxGroup { get; set; }
        public float? DebitSys { get; set; }
        public float? CreditSys { get; set; }
        public object VatDate { get; set; }
        public string VatLine { get; set; }
        public float? SystemBaseAmount { get; set; }
        public float? VatAmount { get; set; }
        public float? SystemVatAmount { get; set; }
        public float? GrossValue { get; set; }
        public string AdditionalReference { get; set; }
        public object CheckAbs { get; set; }
        public string CostingCode2 { get; set; }
        public string CostingCode3 { get; set; }
        public string CostingCode4 { get; set; }
        public object TaxCode { get; set; }
        public string TaxPostAccount { get; set; }
        public string CostingCode5 { get; set; }
        public object LocationCode { get; set; }
        public string ControlAccount { get; set; }
        public float? EqualizationTaxAmount { get; set; }
        public float? SystemEqualizationTaxAmount { get; set; }
        public float? TotalTax { get; set; }
        public float? SystemTotalTax { get; set; }
        public string WTLiable { get; set; }
        public string WTRow { get; set; }
        public string PaymentBlock { get; set; }
        public object BlockReason { get; set; }
        public object FederalTaxID { get; set; }
        public int? BPLID { get; set; }
        public string BPLName { get; set; }
        public string VATRegNum { get; set; }
        public string PaymentOrdered { get; set; }
        public object ExposedTransNumber { get; set; }
        public int? DocumentArray { get; set; }
        public int? DocumentLine { get; set; }
        public string CostElementCode { get; set; }
        public object Cig { get; set; }
        public object Cup { get; set; }
        public object[] CashFlowAssignments { get; set; }
    }

}
