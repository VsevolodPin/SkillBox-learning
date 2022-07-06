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
using System.Windows.Shapes;

namespace SkillBoxTask12
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public IWorker currentWorker = new Consultant();

        public Authorization()
        {
            InitializeComponent();
        }

        private void EmployerPicked(object sender, RoutedEventArgs e)
        {
            if (e.RoutedEvent.Name == "Консультант")
                currentWorker = new Consultant();
            else
                currentWorker = new Manager();
            Close();
        }
    }
}
