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
    public partial class EmployeeListPage : Page
    {
        private List<Employee> employees;

        public EmployeeListPage()
        {
            InitializeComponent();
            LoadEmployees(); // Загружаем данные о сотрудниках
            EmployeeDataGrid.ItemsSource = employees; // Прикрипряем список сотрудников к DataGrid
        }

        private void LoadEmployees()
        {
            // Создаем и заполняем список сотрудников
            employees = new List<Employee>
            {
                new Employee { Name = "John Doe", Position = "Software Engineer" },
                new Employee { Name = "Jane Smith", Position = "Project Manager" },
                new Employee { Name = "Sam Brown", Position = "HR Specialist" }
            };
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбран ли сотрудник в DataGrid
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                // Переходим на страницу редактирования и вносим изменения
                EmployeeEditPage editPage = new EmployeeEditPage(selectedEmployee, SaveEmployee);
                NavigationService.Navigate(editPage);
            }
            else
            {
                // Отображаем сообщение, если сотрудник не выбран
                MessageBox.Show("Please select an employee to edit.");
            }
        }

        private void SaveEmployee(Employee updatedEmployee)
        {
            // Находим существует ли сотркдник в списке
            var employee = employees.Find(e => e.Name == updatedEmployee.Name);
            if (employee != null)
            {
                employee.Position = updatedEmployee.Position; // Обновляем должность
            }

            // Обновляем табличные данные, чтобы отразить изменения
            EmployeeDataGrid.Items.Refresh();
        }
    }
}
