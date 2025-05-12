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
        collection_resulstsPortrait.ItemsSource = new byte[8];
        collection_resulstsLandscape.ItemsSource = new byte[8];
    }
}