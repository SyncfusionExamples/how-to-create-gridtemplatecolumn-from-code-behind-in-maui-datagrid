using Syncfusion.Maui.DataGrid;

namespace DataGridMAUI;

public partial class MainPage : ContentPage
{
    private SfDataGrid sfDataGrid;
    private EmployeeViewModel gridData;

    public MainPage()
	{
		InitializeComponent();
        sfDataGrid = new SfDataGrid();
        gridData = new EmployeeViewModel();
        sfDataGrid.AutoGenerateColumnsMode = AutoGenerateColumnsMode.None;
        var templateColumn = new DataGridTemplateColumn()
        {
            MappingName = "EmployeeID",
            HeaderText = "Employee ID",
            Width = 100
        };
        var dataTemplate = new DataTemplate(() =>
        {
            var label = new Label()
            {
                TextColor = Colors.Blue,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            label.SetBinding(Label.TextProperty, "EmployeeID");
            return label;
        });
        templateColumn.CellTemplate = dataTemplate;
        sfDataGrid.Columns.Add(templateColumn);
        sfDataGrid.Columns.Add(new DataGridTextColumn() { MappingName = "Name", Width = 100 });
        sfDataGrid.Columns.Add(new DataGridTextColumn() { MappingName = "ContactID",HeaderText="Contact ID", Width = 100 });
        sfDataGrid.ItemsSource = gridData.Employees;
        this.Content = sfDataGrid;
    }	
}

