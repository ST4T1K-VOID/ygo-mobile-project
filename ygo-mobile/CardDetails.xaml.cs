using Microsoft.Maui.Controls.Internals;

namespace ygo_mobile;

public partial class card_details : ContentPage
{

    public card_details()
	{
		InitializeComponent();
		UpdatePage();
    }

	/// <summary>
	/// Fills the page with data from the current card
	/// </summary>
	public async void UpdatePage()
	{
		//------remove------
        APIReqeustHandler aPIReqeustHandler = new APIReqeustHandler();
		string longname = "Endymion,%20the%20Mighty%20Master%20of%20Magic";

        List<Card> cards = await aPIReqeustHandler.SendRequest(new Dictionary<string, string> { {"name","pot%20of%20greed" } });
        MonsterCard currentCard = null;

        Card card = cards[0];
        //-------------------

        if (card == null)
        {
            return;
        }

        try
        {
            image_card.Source = card.UrlToImage("image_url").Source;
        }
        catch
        {
            //use placeholder image
        }

        label_name.Text = card.Name;
        label_cardName.Text = card.Name;
        label_description.Text = card.Description;

        //cleans tribe value to match image naming conventions (alphanumeric & '_')
        image_tribe.Source = ImageSource.FromFile($"tribe_{card.Tribe.Replace("-", "").Replace(" ","")}.png");
        label_tribe.Text = card.Tribe;
        image_attribute.Source = ImageSource.FromFile($"attribute_{card.Type.Replace(" ", "")}.png");
        label_attribute.Text = card.Type;


        label_carddata.Text = $"{card.Tribe}||{card.Type}";


		if (card is MonsterCard)
		{
            image_attribute.Source = ImageSource.FromFile($"attribute_{currentCard.Attribute}.png");
            label_attribute.Text = currentCard.Attribute;

            label_atk.Text = $"ATK: {currentCard.Atk.ToString()}|";
            label_def.Text = $"|DEF: {currentCard.Def.ToString()}";
            
            if (currentCard.Type.Contains("XYZ"))
            {
                list_rank.ItemsSource = new byte[(int)currentCard.Level];
                border_rank.IsVisible = true;
            }
            else
            {
                list_level.ItemsSource = new byte[(int)currentCard.Level];
                border_level.IsVisible = true;
            }
            
        }
		if (currentCard is PendulumMonster)
		{

		}
		

		{
			//TODO: Check for chached image before fetching the url image
			//TODO: try/catch >> Image not found//placeholder image






			return;
		}
		return;
	}
}