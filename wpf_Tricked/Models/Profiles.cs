namespace wpf_Tricked.Models
{
    #region Enumerations
    public enum Roles
    {
        RIFLER, AWP, IGL, SUPPORT, LURKER
    }
    #endregion

    public class Profiles
	{
        //Variables & Properties
		public string Name { get; private set; }
		public string IGN { get; private set; }

		public Roles Role { get; private set; }
        public int Elo { get; private set; }

        #region Constructors
        public Profiles(string name, string IGN, Roles role, int elo)
		{
			this.Name = name;
			this.IGN = IGN;
			this.Role = role;
			this.Elo = elo;
		}

		public Profiles(string IGN, Roles role, int elo) : this("", IGN, role, elo)
		{
			this.IGN = IGN;
			this.Role = role;
			this.Elo = elo;
		}
        #endregion
    }
}
