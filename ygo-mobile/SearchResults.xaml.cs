namespace ygo_mobile;

public partial class SearchResults : ContentPage
{
	List<Card> Cards = new List<Card>();

	public SearchResults( List<Card> cards = null)
	{
		InitializeComponent();
		//collection_resulstsPortrait.SelectedItem = null;
		//collection_resulstsLandscape.SelectedItem = null;
		testFunc();
		//if cards == empty display no results found message
	}

	public async void testFunc()
	{
        APIReqeustHandler handler = new APIReqeustHandler();
		Cards = await handler.SendRequest(new Dictionary<string, string> { { "fname", "toon" } });

        collection_resulstsPortrait.ItemsSource = Cards;
	}

    private async void collection_resulstsPortrait_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		try
		{
			await Navigation.PushModalAsync(new cardDetails(collection_resulstsPortrait.SelectedItem as Card));
        }
		catch
		{
			//display error "something went wrong"
			return;
		}
    }

    private async void collection_resulstsLandscape_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            await Navigation.PushModalAsync(new cardDetails(collection_resulstsLandscape.SelectedItem as Card));
        }
        catch
        {
            //display error "something went wrong"
            return;
        }
    }
}