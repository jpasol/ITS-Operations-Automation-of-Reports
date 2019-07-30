using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Vessel_Movement_Report_Creator_User_Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Shutout_Form : UserControl
    {
        public Shutout_Form()
        {
            InitializeComponent();
        }

        public void LoadShutout(ObservableCollection<Model.Shutout_Container> ShutoutContainers)
        {
            ViewModel.ViewModelLocator tempVM = (ViewModel.ViewModelLocator)this.dgShutout.DataContext;
            tempVM.Main.LoadShutout(ref ShutoutContainers);
        }

    }
}
