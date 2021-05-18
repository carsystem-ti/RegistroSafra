using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.Atividade
{

    public class CadastroAtividades
    {
        public string odatametadata { get; set; }
        public CadastroAtividade[] value { get; set; }
    }

    public class CadastroAtividade
    {
        public int? ActivityCode { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Notes { get; set; }
        public string ActivityDate { get; set; }
        public string ActivityTime { get; set; }
        public string StartDate { get; set; }
        public string Closed { get; set; }
        public string CloseDate { get; set; }
        public string Phone { get; set; }
        public object Fax { get; set; }
        public int? Subject { get; set; }
        public string DocType { get; set; }
        public string DocNum { get; set; }
        public string DocEntry { get; set; }
        public string Priority { get; set; }
        public string Details { get; set; }
        public string Activity { get; set; }
        public int? ActivityType { get; set; }
        public int? Location { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public float? Duration { get; set; }
        public string DurationType { get; set; }
        public int? SalesEmployee { get; set; }
        public int? ContactPersonCode { get; set; }
        public int? HandledBy { get; set; }
        public string Reminder { get; set; }
        public float? ReminderPeriod { get; set; }
        public string ReminderType { get; set; }
        public object City { get; set; }
        public string PersonalFlag { get; set; }
        public object Street { get; set; }
        public object ParentObjectId { get; set; }
        public object ParentObjectType { get; set; }
        public object Room { get; set; }
        public string InactiveFlag { get; set; }
        public object State { get; set; }
        public int? PreviousActivity { get; set; }
        public object Country { get; set; }
        public int? Status { get; set; }
        public string TentativeFlag { get; set; }
        public string EndDueDate { get; set; }
        public string DocTypeEx { get; set; }
        public object AttachmentEntry { get; set; }
        public string RecurrencePattern { get; set; }
        public string EndType { get; set; }
        public string SeriesStartDate { get; set; }
        public object SeriesEndDate { get; set; }
        public object MaxOccurrence { get; set; }
        public int? Interval { get; set; }
        public string Sunday { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string RepeatOption { get; set; }
        public object BelongedSeriesNum { get; set; }
        public string IsRemoved { get; set; }
        public object AddressName { get; set; }
        public string AddressType { get; set; }
        public object HandledByEmployee { get; set; }
        public object RecurrenceSequenceSpecifier { get; set; }
        public object RecurrenceDayInMonth { get; set; }
        public object RecurrenceMonth { get; set; }
        public object RecurrenceDayOfWeek { get; set; }
        public object SalesOpportunityId { get; set; }
        public object SalesOpportunityLine { get; set; }
        public object HandledByRecipientList { get; set; }
        public object[] CheckInListParams { get; set; }
    }

}
