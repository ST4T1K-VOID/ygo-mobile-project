using Microsoft.Maui.Controls.Internals;

namespace ygo_mobile;

public partial class cardDetails : ContentPage
{

    public cardDetails()
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

        List<Card> cards = await aPIReqeustHandler.SendRequest(new Dictionary<string, string> { {"type", "spell%20card" } });
        Card currentCard = cards[0];
        //-------------------

        if (currentCard == null)
        {
            return;
        }

        try
        {
            image_card.Source = currentCard.CardImages["Image"].Source;
        }
        catch
        {
            //use placeholder image
        }

        label_name.Text = currentCard.Name;
        label_cardName.Text = currentCard.Name;
        label_description.Text = currentCard.Description;

        //cleans tribe value to match image naming conventions (alphanumeric & '_')
        image_tribe.Source = ImageSource.FromFile($"tribe_{currentCard.Tribe.Replace("-", "").Replace(" ","")}.png");
        label_tribe.Text = currentCard.Tribe;
        //use TYPE in place of ATTRIBUTE when a card does not have an ATTRIBUTE i.e. spell/trap cards
        if (currentCard is not MonsterCard)
        {
            image_attribute.Source = ImageSource.FromFile($"attribute_{currentCard.Type.Replace(" ", "")}.png");
            label_attribute.Text = currentCard.Type;
        }

		if (currentCard is MonsterCard)
		{
            MonsterCard ConvertedCard = (MonsterCard)currentCard;

            image_attribute.Source = ImageSource.FromFile($"attribute_{ConvertedCard.Attribute}.png");
            label_attribute.Text = ConvertedCard.Attribute;

            label_atk.Text = $"ATK: {ConvertedCard.Atk.ToString()}|";
            label_def.Text = $"|DEF: {ConvertedCard.Def.ToString()}";

            label_carddata.Text = $"{currentCard.Tribe}||{currentCard.Type.Replace(" Monster", "").Replace(" ", "||")}";

            if (ConvertedCard.Type.Contains("XYZ"))
            {
                list_rank.ItemsSource = new byte[(int)ConvertedCard.Level];
                border_rank.IsVisible = true;
            }
            else
            {
                list_level.ItemsSource = new byte[(int)ConvertedCard.Level];
                border_level.IsVisible = true;
            }
            if (ConvertedCard.Type == "Link Monster")
            {
                //display unique properties
            }
        }
		if (currentCard is PendulumMonster)
		{
            PendulumMonster ConvertedCard = (PendulumMonster)currentCard;

            label_pend_description.Text = ConvertedCard.PendDesc;
            border_pendulum_desc.IsVisible = true;

            //display unique properties
		}
		return;
	}
}