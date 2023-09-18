using System;

namespace wpf_Tricked.Models
{
    public class Events
    {
        //Variables & Properties
        public string Location { get; private set; }
        public DateTime Date { get; private set; }
        public int EventID { get; private set; }


        #region Constructor
        public Events(string location, DateTime date, int eventID)
        {
            this.Location = location;
            this.Date = date;
            this.EventID = eventID;
        }
        #endregion
    }
}
