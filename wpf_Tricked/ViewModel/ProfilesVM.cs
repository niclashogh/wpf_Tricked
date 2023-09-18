using System;
using System.Collections.ObjectModel;
//Namespaces
using wpf_Tricked.Models;
using wpf_Tricked.Repositories;

namespace wpf_Tricked.ViewModel
{
    public class ProfilesVM : BaseVM
    {
        ProfileRepo Repository = new();

        #region Variables & Properties
        public ObservableCollection<Profiles> ProfileList { get; private set; } = new();

        public string SelRole { get; private set; }
        private Profiles selProfile { get; set; }
        public Profiles SelProfile
        {
            get { return selProfile; }
            set
            {
                selProfile = value;
                OnPropertyChanged(nameof(SelProfile));
                if (selProfile != null)
                {
                    SelRole = value.Role.ToString();
                    OnPropertyChanged(nameof(SelRole));
                }
            }
        }
        #endregion

        #region Constructor
        public ProfilesVM()
        {
            Repository.Load(ProfileList);
        }
        #endregion

        #region Save/Update
        public void Update(int index, string name, string IGN, string role, string elo)
        {
            Profiles updated = new(name, IGN, (Roles)Enum.Parse(typeof(Roles), role), Int32.Parse(elo));
            Repository.Update(updated, index, ProfileList);
            Repository.Load(ProfileList);
        }
        #endregion

        #region Add
        public void Add()
        {
            Repository.Add();
            Repository.Load(ProfileList);
        }
        #endregion

        #region Remove
        public void Remove(Profiles selected)
        {
            Repository.Remove(selected);
            Repository.Load(ProfileList);
        }
        #endregion
        
        #region EnableSave Boolean
        public bool EnableSave(int index, string name, string IGN, string role, string elo)
        {
            if (name != ProfileList[index].Name)
            {  
                return true;
            }
            else if (IGN != ProfileList[index].IGN)
            {
                return true;
            }
            else if (role != ProfileList[index].Role.ToString())
            {
                return true;
            }
            else if (elo != ProfileList[index].Elo.ToString())
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
