namespace ygo_mobile;

public partial class AdvancedSearchpage : ContentPage
{
    private bool IsMonsterCard = false; 
    private readonly APIReqeustHandler RequestHandler = new APIReqeustHandler();
    public AdvancedSearchpage()
	{
		InitializeComponent();
        SetPickers();
    }

    //pre-determined values for card: Type, Tribe, Attribute
    private readonly List<string> CardTypes = new List<string>()
    {
        //--Main Deck Types--
        "Effect Monster",
        "Flip Effect Monster",
        "Flip Tuner Effect Monster",
        "Gemini Monster",
        "Normal Monster",
        "Normal Tuner Monster",
        "Pendulum Effect Monster",
        "Pendulum Effect Ritual Monster",
        "Pendulum Flip Effect Monster",
        "Pendulum Normal Monster",
        "Pendulum Tuner Effect Monster",
        "Ritual Effect Monster",
        "Ritual Monster",
        "Spell Card",
        "Spirit Monster",
        "Toon Monster",
        "Trap Card",
        "Tuner Monster",
        "Union Effect Monster",
        //--Extra Deck Types--
        "Fusion Monster",
        "Link Monster",
        "Pendulum Effect Fusion Monster",
        "Synchro Monster",
        "Synchro Pendulum Effect Monster",
        "Synchro Tuner Monster",
        "XYZ Monster",
        "XYZ Pendulum Effect Monster",
    };

    private readonly Dictionary<string, List<string>> CardTribes = new Dictionary<string, List<string>>
    {
        {
        "Monster Tribes",
        [
            "Aqua",
            "Beast",
            "Beast-Warrior",
            "Creator-God",
            "Cyberse",
           "Dinosaur",
            "Divine-Beast",
            "Dragon",
            "Fairy",
            "Fiend",
            "Fish",
            "Insect",
            "Machine",
            "Plant",
            "Psychic",
            "Pyro",
           "Reptile",
           "Rock",
            "Sea Serpent",
           "Spellcaster",
           "Thunder",
            "Warrior",
           "Winged Beast",
           "Wyrm",
           "Zombie"
            ]
        },
        {
        "Spell Tribes",
        [
            "Normal",
            "Field",
            "Equip",
            "Continuous",
            "Quick-Play",
            "Ritual"
        ]
        },
        {
        "Trap Tribes",
        [
            "Normal",
            "Continuous",
            "Counter"
        ]
        }
    };

    private readonly List<string> CardAttributes = new List<string>()
    {
        "dark",
        "divine",
        "earth",
        "fire",
        "light",
        "water",
        "wind"
    };

    private List<string> CardArchetypes = new List<string>();

    private async Task SetPickers()
    {
        if (IsMonsterCard)
        {
        }
        else
        {
        }
    }

    private async Task RetrieveArchetypes()
    {
        if (CardArchetypes.Count() == 0)
        {
            CardArchetypes = await RequestHandler.GetArchetypes();
            picker_Archetype.ItemsSource = null;
            picker_Archetype.ItemsSource = await RequestHandler.GetArchetypes();
        }
    }

    private Dictionary<string, string> PackParameters()
    {
        return new Dictionary<string, string>();
    }

    private void button_levelMinus_Clicked(object sender, EventArgs e)
    {

    }

    private void button_levelPlus_Clicked(object sender, EventArgs e)
    {

    }


    // Prevents both or neither checkboxes being checked
    private void checkbox_Monster_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (checkbox_Monster.IsChecked == true)
        {
            checkbox_Spell.IsChecked = false;
            IsMonsterCard = true;
        }
        else if (checkbox_Monster.IsChecked == false && checkbox_Spell.IsChecked == false)
        {
            checkbox_Monster.IsChecked = true;
            IsMonsterCard = true;
        }
    }

    private void checkbox_Spell_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (checkbox_Spell.IsChecked == true)
        {
            checkbox_Monster.IsChecked = false;
            IsMonsterCard = false;
        }
        else if (checkbox_Monster.IsChecked == false && checkbox_Spell.IsChecked == false)
        {
            checkbox_Spell.IsChecked = true;
            IsMonsterCard = false;
        }
    }

    //Navigation
    private async void button_Go_Clicked(object sender, EventArgs e)
    {
        APIReqeustHandler reqeustHandler = new APIReqeustHandler();

        List<Card> searchResults = await reqeustHandler.SendRequest(PackParameters());
        if (searchResults == null)
        {
            //critical problem
            //display error, throw exception
        }
        await Navigation.PushModalAsync(new SearchResults(searchResults));
    }
}