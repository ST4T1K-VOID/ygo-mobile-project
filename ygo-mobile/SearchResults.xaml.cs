namespace ygo_mobile;

public partial class search_results : ContentPage
{
	public search_results()
	{
		InitializeComponent();
		testFunc();
	}

	public void testFunc()
	{
		view_TEST.ItemsSource = new byte[8];
        view_TEST_grid.ItemsSource = new byte[8];
    }
}