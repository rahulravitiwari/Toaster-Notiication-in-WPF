using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TosterNotify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToasterNotification ToasterNotification = null;

        public MainWindow()
        {
            InitializeComponent();
            ToasterNotification = new ToasterNotification();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            ToasterNotification.SetNotificationModel(this, "success", "Welcome to Toaster Notification");
        }

        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            ToasterNotification.SetNotificationModel(this, "success", "Hello Ravi Kant Tiwari");
        }

        private void Btnerror_Click(object sender, RoutedEventArgs e)
        {
            ToasterNotification.SetNotificationModel(this, "error", "Hello Ravi Kant Tiwari");
        }

        private void BtnWrong_Click(object sender, RoutedEventArgs e)
        {
            ToasterNotification.SetNotificationModel(this, "warning", "Hello Ravi Kant Tiwari");

        }
    }
}
