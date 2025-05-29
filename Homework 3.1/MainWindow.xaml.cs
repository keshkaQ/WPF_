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

namespace Homework_3._1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<Student> students;
    private Student? selectedStudent;

    private TextBox[] InputFields => new[] { nameTextBox, surnameTextBox, ageTextBox, specializationTextBox };

    public MainWindow()
    {
        InitializeComponent();
        InitializeStudents();
        ResetToDefaultState();
    }

    private void InitializeStudents()
    {
        students = new List<Student>
        {
            new() { Name = "Николай", Surname = "Соловьев", Age = 23, Specialization = "Токарь" },
            new() { Name = "Иван", Surname = "Смирнов", Age = 20, Specialization = "Маляр" },
            new() { Name = "Григорий", Surname = "Иванов", Age = 22, Specialization = "Слесарь" }
        };
        UpdateDataGrid();
    }
    private bool ValidateInputs()
    {
        if (string.IsNullOrEmpty(nameTextBox.Text) || string.IsNullOrEmpty(surnameTextBox.Text) || string.IsNullOrEmpty(ageTextBox.Text) || string.IsNullOrEmpty(specializationTextBox.Text))
        {
            MessageBox.Show("Поля не могут быть пустыми");
            return false;
        }
        return true;
    }
    private void ResetToDefaultState()
    {
        ClearFields();
        UpdateButtonsState(addEnabled: true, deleteEnabled: false, editEnabled: false);
    }

    private void ClearFields()
    {
        foreach (var field in InputFields)
        {
            field.Text = string.Empty;
        }
    }

    private void UpdateDataGrid()
    {
        dataGridStudents.ItemsSource = null;
        dataGridStudents.ItemsSource = students;
    }

    private void UpdateButtonsState(bool addEnabled, bool deleteEnabled, bool editEnabled)
    {
        addButton.IsEnabled = addEnabled;
        deleteButton.IsEnabled = deleteEnabled;
        editButton.IsEnabled = editEnabled;
    }

    private void dataGridStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (dataGridStudents.SelectedItem is Student student)
        {
            selectedStudent = student;
            nameTextBox.Text = student.Name;
            surnameTextBox.Text = student.Surname;
            ageTextBox.Text = student.Age.ToString();
            specializationTextBox.Text = student.Specialization;
            UpdateButtonsState(addEnabled: false, deleteEnabled: true, editEnabled: true);
        }
    }

    private void AddStudent(object sender, RoutedEventArgs e)
    {
        if (!ValidateInputs())
        {
            return;
        }
        students.Add(new Student
        {
            Name = nameTextBox.Text,
            Surname = surnameTextBox.Text,
            Age = int.Parse(ageTextBox.Text),
            Specialization = specializationTextBox.Text
        });
        ResetToDefaultState();
        UpdateDataGrid();
    }

    private void EditStudent(object sender, RoutedEventArgs e)
    {
        if (selectedStudent != null)
        {
            selectedStudent.Name = nameTextBox.Text;
            selectedStudent.Surname = surnameTextBox.Text;
            selectedStudent.Age = int.Parse(ageTextBox.Text);
            selectedStudent.Specialization = specializationTextBox.Text;
            ResetToDefaultState();
            UpdateDataGrid();
        }
    }

    private void DeleteStudent(object sender, RoutedEventArgs e)
    {
        if (selectedStudent != null)
        {
            students.Remove(selectedStudent);
            ResetToDefaultState();
            UpdateDataGrid();
        }
    }

    private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
    {
        ResetToDefaultState();
    }
}

public class Student
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required int Age { get; set; }
    public required string Specialization { get; set; }
}