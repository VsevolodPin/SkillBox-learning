using System.Windows;

namespace SkillBoxTask12
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public IWorker currentWorker = new Consultant(); // базовая инициализация на случай закрытия окна без фактического выбора

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
