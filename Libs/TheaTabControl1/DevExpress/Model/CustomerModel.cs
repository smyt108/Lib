namespace DevExpress.Model
{
    public class CustomerModel<T> : BaseModel
    {
        private T indicatorValue;
        public T IndicatorValue
        {
            get
            {
                return indicatorValue;
            }
            set
            {
                if (!value.Equals(indicatorValue))
                {
                    indicatorValue = value;
                    RaisePropertyChanged(() => IndicatorValue);
                }
            }
        }
    }
}
