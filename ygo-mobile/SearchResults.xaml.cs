namespace ygo_mobile;

public partial class SearchResults : ContentPage
{
	List<Card> Cards = new List<Card>();
    Card SelectedCard = null;

	public SearchResults( List<Card> cards = null)
	{
		InitializeComponent();
        Cards = cards;

        collection_resulstsPortrait.ItemsSource = Cards;
        collection_resulstsLandscape.ItemsSource = Cards;
        //if cards == empty display no results found message
    }

    private async void button_back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void collection_resulstsPortrait_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		try
		{
            SelectedCard = collection_resulstsPortrait.SelectedItem as Card;
            if (SelectedCard == null)
            {
                return;
            }
			await Navigation.PushModalAsync(new cardDetails(SelectedCard));
            collection_resulstsPortrait.SelectedItem = null;
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
            SelectedCard = collection_resulstsLandscape.SelectedItem as Card;
            if (SelectedCard == null)
            {
                return;
            }
            await Navigation.PushModalAsync(new cardDetails(collection_resulstsLandscape.SelectedItem as Card));
            collection_resulstsLandscape.SelectedItem = null;
        }
        catch
        {
            //display error "something went wrong"
            return;
        }
    }
}