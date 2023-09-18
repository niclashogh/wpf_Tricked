using System.Collections.ObjectModel;

namespace wpf_Tricked.Repositories
{


    public interface IGenericRepo<T> where T : class
    {
        #region Variables & Properties
        abstract string LoadStatement { get; }
        abstract string UpdateStatement { get; }
        abstract string RemoveStatement { get; }
        abstract string AddStatement { get; }
        #endregion

        void Load(ObservableCollection<T> collection);
        void Update(T updated, int index, ObservableCollection<T> collection);
        void Remove(T selected);
        void Add();
    }   
}
