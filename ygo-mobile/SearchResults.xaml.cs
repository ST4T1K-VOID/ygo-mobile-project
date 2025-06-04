namespace ygo_mobile;

public partial class SearchResults : ContentPage
{
	List<Card> Cards = new List<Card>();

	public SearchResults( List<Card> cards = null)
	{
		InitializeComponent();
		testFunc();
		//if cards == empty display no results found message
	}

	public async void testFunc()
	{
        APIReqeustHandler handler = new APIReqeustHandler();
		Cards = await handler.SendRequest(new Dictionary<string, string> { { "fname", "toon" } });

        collection_resulstsPortrait.ItemsSource = Cards;
	}
}