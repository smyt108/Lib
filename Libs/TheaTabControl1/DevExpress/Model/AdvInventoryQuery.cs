using System.Collections.Generic;

namespace DevExpress.Model
{
    public class AdvInventoryQuery
    {
        public List<string> CUSIPAndPoolNumbers { get; set; }
        public bool WholePool { get; set; }
        public bool SpecPoolsOnly { get; set; }
        public bool ExcludeMEGA { get; set; }

        public string Product { get; set; }
        public string Account { get; set; }
        public string Agency { get; set; }
        public string PoolCode { get; set; }
        public string Coupon { get; set; }
        public string Factor { get; set; }

        public string WAC { get; set; }
        public string WAM { get; set; }
        public string WALA { get; set; }
        public string TrdDtRPB { get; set; }
        public string TrdDtFace { get; set; }
        public string Issuer { get; set; }

        public string IssueState { get; set; }
        public string LTV { get; set; }
        public string CreditScore { get; set; }
        public string LoanSize { get; set; }
        public string MaxLoanSize { get; set; }
        public string PoolSize { get; set; }


        public string ProdYear { get; set; }
        public string Purchase { get; set; }
        public string Refi { get; set; }
        public string Owner { get; set; }
        public string Investor { get; set; }
        public string Servicer { get; set; }

        public string CPR1 { get; set; }
        public string CPR3 { get; set; }
        public string CPR12 { get; set; }
        public string MinLTV { get; set; }
        public string MaxFICO { get; set; }
        public string SettlementDt { get; set; }

        public bool DetailLevel { get; set; }

        public string MatDt { get; set; }
        public string IssueDt { get; set; }
        public bool IsSortByAbsoluteValue { get; set; }
    }
}
