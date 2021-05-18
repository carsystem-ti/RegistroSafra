using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.Oportunidade
{

    public class CadastroOportunidades
    {
        public CadastroOportunidade[] value { get; set; }
    }

    public class CadastroOportunidade
    {
        public int? SequentialNo { get; set; }

        public int? InterestId { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public int? SalesPerson { get; set; }
        public int? ContactPerson { get; set; }
        public object Source { get; set; }
        public int? InterestField1 { get; set; }
        public object InterestField2 { get; set; }
        public object InterestField3 { get; set; }
        public object InterestLevel { get; set; }
        public string StartDate { get; set; }
        public string PredictedClosingDate { get; set; }
        public float? MaxLocalTotal { get; set; }
        public float? MaxSystemTotal { get; set; }
        public float? WeightedSumLC { get; set; }
        public float? WeightedSumSC { get; set; }
        public float? GrossProfit { get; set; }
        public float? GrossProfitTotalLocal { get; set; }
        public float? GrossProfitTotalSystem { get; set; }
        public object Remarks { get; set; }
        public string Status { get; set; }
        public object ReasonForClosing { get; set; }
        public float? TotalAmountLocal { get; set; }
        public float? TotalAmounSystem { get; set; }
        public float? ClosingGrossProfitLocal { get; set; }
        public float? ClosingGrossProfitSystem { get; set; }
        public float? ClosingPercentage { get; set; }
        public int? CurrentStageNo { get; set; }
        public int? CurrentStageNumber { get; set; }
        public string OpportunityName { get; set; }
        public object Industry { get; set; }
        public string LinkedDocumentType { get; set; }
        public object DataOwnershipfield { get; set; }
        public object StatusRemarks { get; set; }
        public object ProjectCode { get; set; }
        public object BPChanelName { get; set; }
        public int? UserSignature { get; set; }
        public string CustomerName { get; set; }
        public object DocumentCheckbox { get; set; }
        public object LinkedDocumentNumber { get; set; }
        public object Territory { get; set; }
        public object ClosingDate { get; set; }
        public object BPChannelContact { get; set; }
        public object BPChanelCode { get; set; }
        public string ClosingType { get; set; }
        public object AttachmentEntry { get; set; }
        public string OpportunityType { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateTime { get; set; }
        public Salesopportunitiesline[] SalesOpportunitiesLines { get; set; }
        public object[] SalesOpportunitiesCompetition { get; set; }
        public object[] SalesOpportunitiesPartners { get; set; }
        public Salesopportunitiesinterest[] SalesOpportunitiesInterests { get; set; }
        public object[] SalesOpportunitiesReasons { get; set; }
    }

    public class Salesopportunitiesline
    {
        public int? LineNum { get; set; }
        public int? SalesPerson { get; set; }
        public string StartDate { get; set; }
        public string ClosingDate { get; set; }
        public int? StageKey { get; set; }
        public float? PercentageRate { get; set; }
        public float? MaxLocalTotal { get; set; }
        public float? MaxSystemTotal { get; set; }
        public object Remarks { get; set; }
        public string Contact { get; set; }
        public string Status { get; set; }
        public float? WeightedAmountLocal { get; set; }
        public float? WeightedAmountSystem { get; set; }
        public object DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public object DocumentCheckbox { get; set; }
        public object ContactPerson { get; set; }
        public object BPChanelName { get; set; }
        public object BPChanelCode { get; set; }
        public int? SequenceNo { get; set; }
        public int? DataOwnershipfield { get; set; }
        public object BPChannelContact { get; set; }
    }

    public class Salesopportunitiesinterest
    {
        public int? RowNo { get; set; }
        public int? SequenceNo { get; set; }
        public string PrimaryInterest { get; set; }
        public int? InterestId { get; set; }
    }

}
