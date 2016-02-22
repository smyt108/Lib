using Microsoft.Practices.Prism.ViewModel;
namespace DevExpress.Model
{
    public class BaseModel : NotificationObject
    {
        public string UniqId { get; set; }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value != title)
                {
                    title = value;
                    RaisePropertyChanged(() => Title);
                }
            }
        }

        private double titleWidth;
        public double TitleWidth
        {
            get
            {
                return titleWidth;
            }
            set
            {
                if (titleWidth != value)
                {
                    titleWidth = value;
                    RaisePropertyChanged(() => TitleWidth);
                }
            }
        }

        private double indicatorWidth;
        public double IndicatorWidth
        {
            get
            {
                return indicatorWidth;
            }
            set
            {
                if (indicatorWidth != value)
                {
                    indicatorWidth = value;
                    RaisePropertyChanged(() => IndicatorWidth);
                }
            }
        }

    }
}
