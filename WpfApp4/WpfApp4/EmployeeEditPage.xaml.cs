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

namespace WpfApp4
{
    public partial class EmployeeEditPage : Page
    {
        private Employee employee;
        private Action<Employee> onSave; // Управление сохранениями

        public EmployeeEditPage(Employee employee, Action<Employee> onSave)
        {
            InitializeComponent();
            this.employee = employee;
            this.onSave = onSave; // Сохраняем обратный вызов
            NameTextBox.Text = employee.Name;
            PositionTextBox.Text = employee.Position;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем обьект employee новыми значениями из текстовых полей
            employee.Name = NameTextBox.Text;
            employee.Position = PositionTextBox.Text;

            // Вызываем обратный вызов сохранения
            onSave?.Invoke(employee);

            // Отображаем сообщение о том, что изменения были сохранены
            MessageBox.Show("Changes saved successfully!");

            // Возвращаемся на страницу списка сотрудников
            NavigationService.GoBack();
        }
    }
}
