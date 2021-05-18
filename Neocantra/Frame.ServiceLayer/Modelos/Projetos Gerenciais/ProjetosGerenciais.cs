using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.Projetos_Gerenciais
{

    public class ProjetosGerenciais
    {
        public string odatametadata { get; set; }
        public ProjetoGerencial[] value { get; set; }
    }

    public class ProjetoGerencial
    {
        public int? AbsEntry { get; set; }
        public object Owner { get; set; }
        public string ProjectName { get; set; }
        public string StartDate { get; set; }
        public float? FinishedPercent { get; set; }
        public int? DocNum { get; set; }
        public int? Series { get; set; }
        public string ProjectType { get; set; }
        public string BusinessPartner { get; set; }
        public string BusinessPartnerName { get; set; }
        public object ContactPerson { get; set; }
        public object Territory { get; set; }
        public string SalesEmployee { get; set; }
        public string AllowSubprojects { get; set; }
        public string ProjectStatus { get; set; }
        public string DueDate { get; set; }
        public string ClosingDate { get; set; }
        public string FinancialProject { get; set; }
        public string RiskLevel { get; set; }
        public object Industry { get; set; }
        public object Reason { get; set; }
        public object AttachmentEntry { get; set; }
        public PM_Stagescollection[] PM_StagesCollection { get; set; }
        public object[] PM_OpenIssuesCollection { get; set; }
        public PM_Documentscollection[] PM_DocumentsCollection { get; set; }
        public object[] PM_ActivitiesCollection { get; set; }
        public object[] PM_WorkOrdersCollection { get; set; }
        public PM_Summarydata PM_SummaryData { get; set; }
        public object[] PM_DocAttachements { get; set; }
        public object[] PM_StageAttachements { get; set; }
    }

    public class PM_Summarydata
    {
        public int? LineID { get; set; }
        public float? SubprojectBudget { get; set; }
        public float? SumOpenAmountPurchase { get; set; }
        public float? SumInvoicedAmountPurchase { get; set; }
        public float? TotalAmountPurchase { get; set; }
        public float? TotalVariancePurchase { get; set; }
        public float? VariancePerceptionPurchase { get; set; }
        public float? AccumSubprojectBudget { get; set; }
        public float? AccumOpenAmountPurchase { get; set; }
        public float? AccumInvoicedAmountPurchase { get; set; }
        public float? AccumTotalPurchase { get; set; }
        public float? AccumTotalVariancePurchase { get; set; }
        public float? AccumVariancePerceptionPurchase { get; set; }
        public float? PotentialSubprojectAmount { get; set; }
        public float? SumOpenAmountSales { get; set; }
        public float? SumInvoicedAmountSales { get; set; }
        public float? TotalAmountSales { get; set; }
        public float? TotalVarianceSales { get; set; }
        public float? VariancePerceptionSales { get; set; }
        public float? AccumPotentialSubprojectAmount { get; set; }
        public float? AccumOpenAmountSales { get; set; }
        public float? AccumInvoicedAmountSales { get; set; }
        public float? AccumTotalSales { get; set; }
        public float? AccumTotalVarianceSales { get; set; }
        public float? AccumVariancePerceptionSales { get; set; }
        public float? ActualItemComponentCost { get; set; }
        public float? ActualResourceComponentCost { get; set; }
        public float? ActualAdditionalCost { get; set; }
        public float? ActualProductCost { get; set; }
        public float? ActualByProductCost { get; set; }
        public float? TotalVariance { get; set; }
        public string DueDate { get; set; }
        public object ActualClosingDate { get; set; }
        public int? Overdue { get; set; }
    }

    public class PM_Stagescollection
    {
        public int? LineID { get; set; }
        public int? StageID { get; set; }
        public int? StageType { get; set; }
        public string StartDate { get; set; }
        public string CloseDate { get; set; }
        public int? Task { get; set; }
        public string Description { get; set; }
        public float? ExpectedCosts { get; set; }
        public float? InvoicedAmountSales { get; set; }
        public float? OpenAmountSales { get; set; }
        public float? InvoicedAmountPurchase { get; set; }
        public float? OpenAmountPurchase { get; set; }
        public float? PercentualCompletness { get; set; }
        public string IsFinished { get; set; }
        public object StageOwner { get; set; }
        public object DependsOnStage1 { get; set; }
        public object DependsOnStage2 { get; set; }
        public object DependsOnStage3 { get; set; }
        public object DependsOnStage4 { get; set; }
        public string StageDependency1Type { get; set; }
        public string StageDependency2Type { get; set; }
        public string StageDependency3Type { get; set; }
        public string StageDependency4Type { get; set; }
        public object DependsOnStageID1 { get; set; }
        public object DependsOnStageID2 { get; set; }
        public object DependsOnStageID3 { get; set; }
        public object DependsOnStageID4 { get; set; }
        public object AttachmentEntry { get; set; }
        public string UniqueID { get; set; }
        public string FinishedDate { get; set; }
    }

    public class PM_Documentscollection
    {
        public int? LineID { get; set; }
        public int? StageID { get; set; }
        public string DocType { get; set; }
        public int? DocEntry { get; set; }
        public string DocDate { get; set; }
        public float? Total { get; set; }
        public object LineNumber { get; set; }
        public string Status { get; set; }
        public string AmountCategory { get; set; }
        public string Categorize { get; set; }
        public string Operation { get; set; }
    }

}
