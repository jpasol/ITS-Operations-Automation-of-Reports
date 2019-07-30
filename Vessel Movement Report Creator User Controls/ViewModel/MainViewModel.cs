using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
namespace Vessel_Movement_Report_Creator_User_Controls.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        private ObservableCollection<Model.Shutout_Container> _shutoutContainers;
        private Model.Shutout_Container _selectedContainer;
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
        public ObservableCollection<Model.Shutout_Container> ShutoutContainers => _shutoutContainers;
        public Model.Shutout_Container SelectedContainer
        {
            get
            {
                return _selectedContainer;
            }
            set
            {
                _selectedContainer = value;
                RaisePropertyChanged("SelectedContainer");
            }

           
        }
        public void LoadShutout(ref ObservableCollection<Model.Shutout_Container> ShutoutContainers)
        {
            this._shutoutContainers = ShutoutContainers;
            this.RaisePropertyChanged(() => this.ShutoutContainers);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Shutout Loaded"));
        }
    }
}