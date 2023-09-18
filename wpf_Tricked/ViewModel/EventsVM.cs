using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Printing;
//Namespaces
using wpf_Tricked.Models;
using wpf_Tricked.Repositories;

namespace wpf_Tricked.ViewModel
{
    public class EventsVM : BaseVM
    {
        EventRepo EventRepository = new();
        TeamRepo TeamRepository = new();

        #region Variables & Properties
        public ObservableCollection<Events> EventList { get; private set; } = new();
        private Events selEvent { get; set; }
        public Events SelEvent
        {
            get { return selEvent; }
            set
            {
                selEvent = value;
                OnPropertyChanged(nameof(SelEvent));
            }
        }

        public ObservableCollection<Teams> TeamList { get; private set; } = new();
        #endregion

        #region Constructor
        public EventsVM()
        {
            EventRepository.Load(EventList);
            TeamRepository.Load(TeamList);
        }
        #endregion

        #region Save/Update
        public void Update(int index, string location, string date, string time)
        {
            var Date = DateTime.Parse($"{date} {time}");

            Events updated = new(location, Date, EventList[index].EventID);
            EventRepository.Update(updated, index, EventList);
            EventRepository.Load(EventList);
        }
        #endregion

        #region EnableSave Boolean
        public bool EnableSave(int index, string location, string date, string time)
        {
            if (location != EventList[index].Location)
            {
                return true;
            }
            else if (date != EventList[index].Date.ToString())
            {
                return true;
            }
            else if (time != EventList[index].Date.ToString("HH:mm"))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
