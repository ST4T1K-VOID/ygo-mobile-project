using Microsoft.Maui.Controls.Internals;

namespace ygo_mobile;

public partial class cardDetails : ContentPage
{
    Card CurrentCard = null;
    public cardDetails(Card selectedCard)
	{
        CurrentCard = selectedCard;
		InitializeComponent();
		UpdatePage();
    }

	/// <summary>
	/// Fills the page with data from the current card
	/// </summary>
	public async void UpdatePage()
	{
        if (CurrentCard == null)
        {
            //display error "card undefined"
            return;
        }

        try
        {
            image_card.Source = CurrentCard.CardImages["image"].Source;
        }
        catch
        {
            //use placeholder image
        }

        label_name.Text = CurrentCard.Name;
        label_cardName.Text = CurrentCard.Name;
        label_description.Text = CurrentCard.Description;

        //cleans tribe value to match image naming conventions (alphanumeric & '_')
        image_tribe.Source = ImageSource.FromFile($"tribe_{CurrentCard.Tribe.Replace("-", "").Replace(" ","")}.png");
        label_tribe.Text = CurrentCard.Tribe;
        //use TYPE in place of ATTRIBUTE when a card does not have an ATTRIBUTE i.e. spell/trap cards
        if (CurrentCard is not MonsterCard)
        {
            image_attribute.Source = ImageSource.FromFile($"attribute_{CurrentCard.Type.Replace(" ", "")}.png");
            label_attribute.Text = CurrentCard.Type;
        }

		if (CurrentCard is MonsterCard)
		{
            MonsterCard ConvertedCard = (MonsterCard)CurrentCard;

            image_attribute.Source = ImageSource.FromFile($"attribute_{ConvertedCard.Attribute}.png");
            label_attribute.Text = ConvertedCard.Attribute;

            label_atk.Text = $"ATK: {ConvertedCard.Atk.ToString()}|";
            label_def.Text = $"|DEF: {ConvertedCard.Def.ToString()}";

            label_carddata.Text = $"{CurrentCard.Tribe}||{CurrentCard.Type.Replace(" Monster", "").Replace(" ", "||")}";

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
		if (CurrentCard is PendulumMonster)
		{
            PendulumMonster ConvertedCard = (PendulumMonster)CurrentCard;

            label_pend_description.Text = ConvertedCard.PendDesc;
            border_pendulum_desc.IsVisible = true;

            //display unique properties
		}
		return;
	}
}