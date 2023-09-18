using System;

namespace wpf_Tricked.Custom_Datatypes
{
    #region MonthAsAcronym Enum
    public enum MonthAsAcronym
    {
        Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
    }
    #endregion

    public class OnlyDate
    {
        public int Day { get; private set; }
        public MonthAsAcronym Month { get; private set; }
        public int Year { get; private set; }

        #region Constructor
        public OnlyDate(string value)
        {
            this.Day = GetDay(value);
            this.Month = (MonthAsAcronym)Enum.Parse(typeof(MonthAsAcronym), GetMonth(value));
            this.Year = GetYear(value);
        }
        #endregion

        #region Convertion Method 'GetDay'
        private int GetDay(string value)
        {
            string[] array = value.Split("-");
            return Int32.Parse(array[2]);
        }
        #endregion

        #region Convertion Method 'GetMonth'
        private string GetMonth(string value)
        {
            string[] array = value.Split("-");
            return array[1];
        }
        #endregion

        #region Convertion Method 'GetYear'
        private int GetYear(string value)
        {
            string[] array = value.Split("-");
            return Int32.Parse(array[0]);
        }
        #endregion
    }

    // NOTE
    // SQL Date Format = yyyy-mm-dd
    // SQL Time Format = HH:MM:SS.MI
    // XAML Calender Format = m-dd-yyyy hh:mm:ss (AM/PM)
}
