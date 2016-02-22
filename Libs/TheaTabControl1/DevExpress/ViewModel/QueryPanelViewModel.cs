using DevExpress.CommonControls;
using DevExpress.Model;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;

namespace DevExpress.ViewModel
{
    public class QueryPanelViewModel : NotificationObject
    {
        public QueryPanelViewModel()
        {
            InitializeData();
            this.SubmitCommand = new DelegateCommand(() => this.Submit());//move to inventorySearchViewModel
            this.BreakDownCommand = new DelegateCommand(() => this.BreakDownSelected());
            this.NetLvlCommand = new DelegateCommand(() => this.NetLvlSelected());
            this.ResetCommand = new DelegateCommand(() => this.Reset());

            SpecPoolOnly = true;
            NetLvlChecked = true;
            SubmitEnabled = true;
        }

        #region commands
        public DelegateCommand SubmitCommand { get; private set; }
        public DelegateCommand BreakDownCommand { get; private set; }
        public DelegateCommand NetLvlCommand { get; private set; }
        public DelegateCommand ResetCommand { get; private set; } 
        
        
        #endregion

        public event EventHandler QueryReset;
        private static readonly string[] newLineString = { Environment.NewLine };
      //  private bool returnKeyDownEventIsInGrid;

       // public ISearchablePoolView MasterView { get; set; }
        

        private CompositeControlCollection listBox;
        public CompositeControlCollection ListBox
        {
            get { return listBox; }
            set
            {
                if(value != null)
                {
                    listBox = value;
                    RaisePropertyChanged(() => ListBox);
                }
            }
        }

        public int ListBoxColumns { get; set; }
        
        private string cusipAndPoolNumbers;
        public string CusipAndPoolNumbers
        {
            get { return cusipAndPoolNumbers; }
            set
            {
                if (value != null)
                {
                    cusipAndPoolNumbers = value;
                    RaisePropertyChanged(() => CusipAndPoolNumbers);
                }
            }
        }

        private bool wholePoolOnly;
        public bool WholePoolOnly
        {
            get { return wholePoolOnly; }
            set
            {
                if (value != wholePoolOnly)
                {
                    wholePoolOnly = value;
                    RaisePropertyChanged(() => WholePoolOnly);
                }
            }
        }

        private bool specPoolOnly;
        public bool SpecPoolOnly
        {
            get { return specPoolOnly; }
            set
            {
                if (value != specPoolOnly)
                {
                    specPoolOnly = value;
                    RaisePropertyChanged(() => SpecPoolOnly);
                }
            }
        }

        private bool excludeMegas;
        public bool ExcludeMegas
        {
            get { return excludeMegas; }
            set
            {
                if (value != excludeMegas)
                {
                    excludeMegas = value;
                    RaisePropertyChanged(() => ExcludeMegas);
                }
            }
        }

        private bool submitEnabled;
        public bool SubmitEnabled
        {
            get { return submitEnabled; }
            set
            {
                if (value != submitEnabled)
                {
                    submitEnabled = value;
                    RaisePropertyChanged(() => SubmitEnabled);
                }
            }
        }

        private bool breakdownChecked;
        public bool BreakdownChecked
        {
            get { return breakdownChecked; }
            set
            {
                if (value != breakdownChecked)
                {
                    breakdownChecked = value;
                    RaisePropertyChanged(() => BreakdownChecked);
                }
            }
        }

        private bool netLvlChecked;
        public bool NetLvlChecked
        {
            get { return netLvlChecked; }
            set
            {
                if (value != netLvlChecked)
                {
                    netLvlChecked = value;
                    RaisePropertyChanged(() => NetLvlChecked);
                }
            }
        }

        


        private void InitializeData()
        {
            this.ListBox = new CompositeControlCollection();
            ListBoxColumns = 5;

            ObservableCollection<string> selectionValues = new ObservableCollection<string>();
            selectionValues.Add("FHLMC");
            selectionValues.Add("FNMA");
            selectionValues.Add("GNMA");
            selectionValues.Add("GNMA2");

            ListBox.Add(new TextModel() { UniqId = "Product", Title = "Product:" });
            ListBox.Add(new TextModel() { UniqId = "WAC", Title = "WAC:" });
            ListBox.Add(new TextModel() { UniqId = "IssueState", Title = "Issue State:" });
            ListBox.Add(new TextModel() { UniqId = "ProdYear", Title = "Prod Year:" });
            ListBox.Add(new TextModel() { UniqId = "CPR1", Title = "CPR1:" });

            ListBox.Add(new TextModel() { UniqId = "Account", Title = "Account:" });
            ListBox.Add(new TextModel() { UniqId = "WAM", Title = "WAM:" });
            ListBox.Add(new TextModel() { UniqId = "LTV", Title = "LTV:" });
            ListBox.Add(new TextModel() { UniqId = "Purchase", Title = "Purchase:" });
            ListBox.Add(new TextModel() { UniqId = "CPR3", Title = "CPR3:" });

            ListBox.Add(new ComboModel() { UniqId = "Agency", Title = "Agency:", SelectionValues = selectionValues });
            ListBox.Add(new TextModel() { UniqId = "WALA", Title = "WALA:" });
            ListBox.Add(new TextModel() { UniqId = "CreditScore", Title = "Credit Score:" });
            ListBox.Add(new TextModel() { UniqId = "Refi", Title = "Refi:" });
            ListBox.Add(new TextModel() { UniqId = "CPR12", Title = "CPR12:" });

            ListBox.Add(new TextModel() { UniqId = "PoolCode", Title = "Pool Code:" });
            ListBox.Add(new TextModel() { UniqId = "TrdDtRPB", Title = "TrdDt RPB:" });
            ListBox.Add(new TextModel() { UniqId = "LoanSize", Title = "Loan Size:" });
            ListBox.Add(new TextModel() { UniqId = "Owner", Title = "Owner:" });
            ListBox.Add(new TextModel() { UniqId = "MinLTV", Title = "Min LTV:" });

            ListBox.Add(new TextModel() { UniqId = "Coupon", Title = "Coupon:" });
            ListBox.Add(new TextModel() { UniqId = "TrdDtFace", Title = "TrdDt Face:" });
            ListBox.Add(new TextModel() { UniqId = "MaxLoanSize", Title = "Max Loan Size:" });
            ListBox.Add(new TextModel() { UniqId = "Investor", Title = "Investor:" });
            ListBox.Add(new TextModel() { UniqId = "MaxFICO", Title = "Max FICO:" });

            ListBox.Add(new TextModel() { UniqId = "Factor", Title = "Factor:" });
            ListBox.Add(new TextModel() { UniqId = "Issuer", Title = "Issuer:" });
            ListBox.Add(new TextModel() { UniqId = "PoolSize", Title = "Pool Size:" });
            ListBox.Add(new TextModel() { UniqId = "Servicer", Title = "Servicer:" });
            ListBox.Add(new DateModel() { UniqId = "SettleDate", Title = "Settle Date:", IndicatorValue = DateTime.Now });

        }


        private void Submit()
        {
          //  Dispatcher.ShowWaitCursorTillApplicationBecomesIdle();
            AdvInventoryQuery query = generateQuery();

           // MasterView.PopulateAdvancedSearchTab(PerformAdvancedInventorySearch(query, ViewModel.SearchablePools), query);
        }

        private void BreakDownSelected()
        {
            NetLvlChecked = false;
        }

        private void NetLvlSelected()
        {
            BreakdownChecked = false;
        }

        public void Populate(AdvInventoryQuery query)
        {
            if (query != null)
            {
                if (query.CUSIPAndPoolNumbers != null && query.CUSIPAndPoolNumbers.Count > 0)
                {
                    CusipAndPoolNumbers = string.Join("\r\n", query.CUSIPAndPoolNumbers);
                }
                else
                {
                    CusipAndPoolNumbers = string.Empty;
                }

                WholePoolOnly = query.WholePool;
                SpecPoolOnly = query.SpecPoolsOnly;
                ExcludeMegas = query.ExcludeMEGA;

                ListBox.Set<string>("Product", query.Product);
                ListBox.Set<string>("Account", query.Account);
                ListBox.Set<string>("Agency", query.Agency);
                ListBox.Set<string>("PoolCode", query.PoolCode);
                ListBox.Set<string>("Coupon", query.Coupon);
                ListBox.Set<string>("Factor", query.Factor);

                ListBox.Set<string>("WAC", query.WAC);
                ListBox.Set<string>("WAM", query.WAM);
                ListBox.Set<string>("WALA", query.WALA);
                ListBox.Set<string>("TrdDtRPB", query.TrdDtRPB);
                ListBox.Set<string>("TrdDtFace", query.TrdDtFace);
                ListBox.Set<string>("Issuer", query.Issuer);

                ListBox.Set<string>("IssueState", query.IssueState);
                ListBox.Set<string>("LTV", query.LTV);
                ListBox.Set<string>("CreditScore", query.CreditScore);
                ListBox.Set<string>("LoanSize", query.LoanSize);
                ListBox.Set<string>("MaxLoanSize", query.MaxLoanSize);
                ListBox.Set<string>("PoolSize", query.PoolSize);

                ListBox.Set<string>("ProdYear", query.ProdYear);
                ListBox.Set<string>("Purchase", query.Purchase);
                ListBox.Set<string>("Refi", query.Refi);
                ListBox.Set<string>("Owner", query.Owner);
                ListBox.Set<string>("Investor", query.Investor);
                ListBox.Set<string>("Servicer", query.Servicer);

                ListBox.Set<string>("CPR1", query.CPR1);
                ListBox.Set<string>("CPR3", query.CPR3);
                ListBox.Set<string>("CPR12", query.CPR12);
                ListBox.Set<string>("MinLTV", query.MinLTV);
                ListBox.Set<string>("MaxFICO", query.MaxFICO);
                ListBox.Set<DateTime>("SettleDate", DateTime.Parse(query.SettlementDt));

              //  ListBox.Set<string>("MatDt", query.MatDt);
              //  ListBox.Set<string>("IssueDt", query.IssueDt);


            }
            else Reset();
        }

        public void Reset()
        {
                CusipAndPoolNumbers = string.Empty;

                WholePoolOnly = false;
                SpecPoolOnly = true;
                ExcludeMegas = false;

                ListBox.Set<string>("Product", string.Empty);
                ListBox.Set<string>("Account", string.Empty);
                ListBox.Set<string>("Agency", string.Empty);
                ListBox.Set<string>("PoolCode", string.Empty);
                ListBox.Set<string>("Coupon", string.Empty);
                ListBox.Set<string>("Factor", string.Empty);

                ListBox.Set<string>("WAC", string.Empty);
                ListBox.Set<string>("WAM", string.Empty);
                ListBox.Set<string>("WALA", string.Empty);
                ListBox.Set<string>("TrdDtRPB", string.Empty);
                ListBox.Set<string>("TrdDtFace", string.Empty);
                ListBox.Set<string>("Issuer", string.Empty);

                ListBox.Set<string>("IssueState", string.Empty);
                ListBox.Set<string>("LTV", string.Empty);
                ListBox.Set<string>("CreditScore", string.Empty);
                ListBox.Set<string>("LoanSize", string.Empty);
                ListBox.Set<string>("MaxLoanSize", string.Empty);
                ListBox.Set<string>("PoolSize", string.Empty);

                ListBox.Set<string>("ProdYear", string.Empty);
                ListBox.Set<string>("Purchase", string.Empty);
                ListBox.Set<string>("Refi", string.Empty);
                ListBox.Set<string>("Owner", string.Empty);
                ListBox.Set<string>("Investor", string.Empty);
                ListBox.Set<string>("Servicer", string.Empty);

                ListBox.Set<string>("CPR1", string.Empty);
                ListBox.Set<string>("CPR3", string.Empty);
                ListBox.Set<string>("CPR12", string.Empty);
                ListBox.Set<string>("MinLTV", string.Empty);
                ListBox.Set<string>("MaxFICO", string.Empty);
                ListBox.Set<DateTime>("SettleDate", DateTime.Parse("2015-01-01"));

                NetLvlChecked = true;
                BreakdownChecked = false;

                if (QueryReset != null)
                    QueryReset(this, new EventArgs());
        }

        public AdvInventoryQuery generateQuery()
        {
            AdvInventoryQuery query = new AdvInventoryQuery
            {
                CUSIPAndPoolNumbers =
                (from str in CusipAndPoolNumbers.Split(newLineString, StringSplitOptions.None) where !string.IsNullOrEmpty(str.Trim()) select str.Trim()).ToList(),

                WholePool = WholePoolOnly,
                SpecPoolsOnly = SpecPoolOnly,
                ExcludeMEGA = ExcludeMegas,

                Product = ListBox.Get<string>("Product"),
                Account = ListBox.Get<string>("Account"),
                Agency = ListBox.Get<string>("Agency"),
                PoolCode = ListBox.Get<string>("PoolCode"),
                Coupon = ListBox.Get<string>("Coupon"),
                Factor = ListBox.Get<string>("Factor"),

                WAC = ListBox.Get<string>("WAC"),
                WAM = ListBox.Get<string>("WAM"),
                WALA = ListBox.Get<string>("WALA"),
                TrdDtRPB = ListBox.Get<string>("TrdDtRPB"),
                TrdDtFace = ListBox.Get<string>("TrdDtFace"),
                Issuer = ListBox.Get<string>("Issuer"),

                IssueState = ListBox.Get<string>("IssueState"),
                LTV = ListBox.Get<string>("LTV"),
                CreditScore = ListBox.Get<string>("CreditScore"),
                LoanSize = ListBox.Get<string>("LoanSize"),
                MaxLoanSize = ListBox.Get<string>("MaxLoanSize"),
                PoolSize = ListBox.Get<string>("PoolSize"),

                ProdYear = ListBox.Get<string>("ProdYear"),
                Purchase = ListBox.Get<string>("Purchase"),
                Refi = ListBox.Get<string>("Refi"),
                Owner = ListBox.Get<string>("Owner"),
                Investor = ListBox.Get<string>("Investor"),
                Servicer = ListBox.Get<string>("Servicer"),

                CPR1 = ListBox.Get<string>("CPR1"),
                CPR3 = ListBox.Get<string>("CPR3"),
                CPR12 = ListBox.Get<string>("CPR12"),
                MinLTV = ListBox.Get<string>("MinLTV"),
                MaxFICO = ListBox.Get<string>("MaxFICO"),
                SettlementDt = ListBox.Get<DateTime>("SettleDate").ToString(),

                DetailLevel = BreakdownChecked,
                MatDt = string.Empty,
                IssueDt = string.Empty,

                IsSortByAbsoluteValue = true,
            };

            return query;

        }



        //private void advInventory_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Return)
        //    {
        //        e.Handled = true;
        //        returnKeyDownEventIsInGrid = true;
        //    }
        //}

        //private void advInventory_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Return)
        //    {
        //        if (returnKeyDownEventIsInGrid)
        //        {
        //            Submit();
        //            returnKeyDownEventIsInGrid = false;
        //        }
        //    }
        //}



        //private int GetOrder(string position, List<string> list)
        //{
        //    int index = -1;
        //    index = list.IndexOf(position.Cusip);

        //    if (index == -1)
        //    {
        //        index = list.IndexOf(position.BBGTicker);
        //    }

        //    if (index == -1)
        //    {
        //        index = list.IndexOf(position.I_POOL_NUMBER);
        //    }

        //    return index == -1 ? int.MaxValue : index;
        //}

        //public ObservablePoolCollection PerformAdvancedInventorySearch(AdvInventoryQuery query, ObservablePoolCollection allPos)
        //{

        //    if (query == null) return allPos;

        //    IEnumerable<ObservablePool> detailPositions;
        //    if (query.DetailLevel)
        //        detailPositions = allPos.SelectMany(pos =>
        //        {
        //            var childs = pos.Children.Where(c => c.Value != 0.0).ToList();
        //            if (childs.Count > 0)
        //                return pos.Children;
        //            else
        //                return Enumerable.Repeat(pos, 1);
        //        });
        //    else
        //        detailPositions = allPos;

        //    var filteredPositions =
        //        from position in detailPositions
        //        where position.IsInPool(query.CUSIPAndPoolNumbers) &&
        //              position.HasProductType(query.Product) &&
        //              position.IsInAccounts(query.Account) &&
        //              position.IssuedByAgency(query.Agency) &&
        //              position.IssuedBy(query.Issuer) &&
        //              position.HasPoolCode(query.PoolCode) &&
        //              position.HasPoolSize(query.PoolSize) &&
        //              position.HasCoupon(query.Coupon) &&
        //              position.HasFactor(query.Factor) &&
        //              position.HasWAC(query.WAC) &&
        //              position.HasWAM(query.WAM) &&
        //              position.HasWALA(query.WALA) &&
        //              position.HasMaturityDate(query.MatDt) &&
        //              position.HasIssueDate(query.IssueDt) &&
        //              position.HasTrdDtRPB(query.TrdDtRPB) &&
        //              position.HasTrdDtFace(query.TrdDtFace) &&
        //              position.HasProdYear(query.ProdYear) &&
        //              position.SatisfiesIssueStateExpression(query.IssueState) &&
        //              position.WithCPR1(query.CPR1) &&
        //              position.WithCPR3(query.CPR3) &&
        //              position.WithCPR12(query.CPR12) &&
        //              position.WithLTV(query.LTV) &&
        //              position.WithCreditScore(query.CreditScore) &&
        //              position.WithLoanSize(query.LoanSize) &&
        //              position.WithMaxLoanSize(query.MaxLoanSize) &&
        //              position.ServicedBy(query.Servicer) &&
        //              position.WithPurchase(query.Purchase) &&
        //              position.WithRefi(query.Refi) &&
        //              position.WithOwner(query.Owner) &&
        //              position.WithInvestor(query.Investor) &&
        //              (query.WholePool ? position.WholePoolFlag : true) &&
        //              (query.SpecPoolsOnly ? position.IsInSpecPool() : true) &&
        //              (query.ExcludeMEGA ? position.IsExcludeMEGA() : true) &&
        //              position.WithMinLTV(query.MinLTV) &&
        //              position.WithMaxFICO(query.MaxFICO) &&
        //              position.HasSettlementDate(query.SettlementDt)
        //        select position;

        //    if (query.CUSIPAndPoolNumbers != null && query.CUSIPAndPoolNumbers.Count > 0)
        //    {
        //        filteredPositions = from position in filteredPositions
        //                            orderby GetOrder(position, query.CUSIPAndPoolNumbers)
        //                            select position;
        //    }

        //    return new ObservablePoolCollection(filteredPositions);
        //}

    }
}
