namespace wpf_Tricked.Custom_Datatypes
{
    public class OnlyTime
    {
        public string Time { get; private set; }

        #region Constructor
        public OnlyTime(string value)
        {
            this.Time = GetHour(value);
        }
        #endregion

        #region Convertion Method 'GetHour'
        public string GetHour(string value)
        {
            string[] array = value.Split(':');
            return @"{array[0]} {array[1]}";
        }
        #endregion
    }
}
