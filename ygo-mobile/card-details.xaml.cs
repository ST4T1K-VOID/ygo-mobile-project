namespace ygo_mobile;

public partial class card_details : ContentPage
{
	//TODO: Remove mock data after testing
    public Card? CurrentCard = new Card("46986416", "Dark Magician", "'The ultimate wizard in terms of attack and defense''", "Normal monster", "spellcaster", "DARK", 7, 2500, 2100);

    public card_details()
	{
		InitializeComponent();
		AddToImages(CurrentCard);
		UpdatePage();
    }

	//TODO: remove after testing
	public void AddToImages(Card card)
	{
		card.CardImages.Add("baseImage", "https://images.ygoprodeck.com/images/cards/46986414.jpg");
    }

	/// <summary>
	/// replaces placeholder images with card specefic data
	/// </summary>
	public void UpdatePage()
	{
		if (CurrentCard != null)
		{
            //TODO: Check for chached image before fetching the url image
            image_card.Source = CurrentCard.UrlToImage("baseImage").Source;


			image_attribute.Source = ImageSource.FromFile($"attribute_{CurrentCard.Attribute}.png");
			label_attribute.Text = CurrentCard.Attribute;

            image_type.Source = ImageSource.FromFile($"attribute_{CurrentCard.Tribe}.png");
			label_type.Text = CurrentCard.Tribe;

			label_name.Text = CurrentCard.Name;
			label_cardName.Text = CurrentCard.Name;

			label_atk.Text = CurrentCard.Atk.ToString();
			label_def.Text = CurrentCard.Def.ToString();

			label_description.Text = CurrentCard.Description;

			label_carddata.Text = $"{CurrentCard.Tribe}||{CurrentCard.Type}";
			
			return;
        }
	}
}