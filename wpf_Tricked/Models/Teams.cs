namespace wpf_Tricked.Models
{
    public class Teams
    {
        //Variables & Properties
        public string Name { get; private set; }
        public int Rank { get; private set; }

        #region Constructors
        public Teams(string name, int rank)
        {
            this.Name = name;
            this.Rank = rank;
        }

        public Teams(string name) : this(name, 0)
        {
            this.Name = name;
        }
        #endregion
    }
}
