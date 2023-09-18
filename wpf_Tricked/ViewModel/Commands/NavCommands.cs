namespace wpf_Tricked.ViewModel.Commands
{
    public class NavCommands : BaseCMD
    {
        //Inst Namespaces
        private MainVM mainVM;

        #region Constructor
        public NavCommands(MainVM mainVM)
        {
            this.mainVM = mainVM;
        }
        #endregion

        #region On Execution
        public override void Execute(object? parameter)
        {
            if (parameter.ToString() == "Teams")
            {
                mainVM.SelVM = new TeamsVM();
            }
            else if (parameter.ToString() == "Profiles")
            {
                mainVM.SelVM = new ProfilesVM();
            }
            else if (parameter.ToString() == "Events")
            {
                mainVM.SelVM = new EventsVM();
            }
        }
        #endregion
    }
}
