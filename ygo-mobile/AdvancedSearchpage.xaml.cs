namespace ygo_mobile;

public partial class AdvancedSearchpage : ContentPage
{ 
    private readonly APIReqeustHandler RequestHandler = new APIReqeustHandler();
    public AdvancedSearchpage()
	{
		InitializeComponent();

        RetrieveArchetypes();
        picker_Attribute.ItemsSource = CardAttributes;


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
        "Spirit Monster",
        "Toon Monster",
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

    /// <summary>
    /// Sets itemsources and enables/disables UI elements based on which card type is selected
    /// </summary>
    private void SetItemSources()
    {
        picker_Type.ItemsSource = CardTypes;
        picker_Tribe.ItemsSource = null;
        if (checkbox_Monster.IsChecked)
        {
            picker_Type.IsEnabled = true;
            picker_Attribute.IsEnabled = true;

            button_levelPlus.IsEnabled = true;
            button_levelMinus.IsEnabled = false;

            picker_Tribe.ItemsSource = CardTribes["Monster Tribes"];
        }
        else if (checkbox_Spell.IsChecked)
        {
            picker_Type.IsEnabled = false;
            picker_Type.SelectedItem = null;
            picker_Attribute.IsEnabled = false;
            picker_Attribute.SelectedItem = null;

            button_levelPlus.IsEnabled = false;
            button_levelMinus.IsEnabled = false;
            label_LevelVal.Text = "0";

            picker_Tribe.ItemsSource = CardTribes["Spell Tribes"];
        }
        else if (checkbox_Trap.IsChecked)
        {
            picker_Type.IsEnabled = false;
            picker_Type.SelectedItem = null;
            picker_Attribute.IsEnabled = false;
            picker_Attribute.SelectedItem = null;

            button_levelPlus.IsEnabled = false;
            button_levelMinus.IsEnabled = false;
            label_LevelVal.Text = "0";

            picker_Tribe.ItemsSource = CardTribes["Trap Tribes"];
        }
    }

    /// <summary>
    /// API call to retrive archetypes and set archetype picker
    /// </summary>
    /// <returns></returns>
    private async Task RetrieveArchetypes()
    {
        if (CardArchetypes.Count() == 0)
        {
            picker_Archetype.ItemsSource = null;
            picker_Archetype.ItemsSource = await RequestHandler.GetArchetypes();
        }
    }

    /// <summary>
    /// retrives user entered data and converts to dictionary format for API call.
    /// </summary>
    /// <returns>A dictionary where key = paramter type and value = user entered data</returns>
    private Dictionary<string, string> PackParameters()
    {
        return new Dictionary<string, string>();
    }

    //EVENTS

    private void button_levelMinus_Clicked(object sender, EventArgs e)
    {
        button_levelPlus.IsEnabled = true;
        if (label_LevelVal.Text == "0")
        {
            return;
        }
        if (int.TryParse(label_LevelVal.Text, out int value))
        {
            label_LevelVal.Text = (value - 1).ToString();
            if ((value - 1) == 0)
            {
                button_levelMinus.IsEnabled = false;
            }
        }
    }

    private void button_levelPlus_Clicked(object sender, EventArgs e)
    {
        if (int.TryParse(label_LevelVal.Text, out int value))
        {
            button_levelMinus.IsEnabled = true;
            label_LevelVal.Text = (value + 1).ToString();
            if ((value + 1) == 12)
            {
                button_levelPlus.IsEnabled = false;
            }
        }
    }

    // Prevents both or neither checkboxes being checked
    private void checkbox_Monster_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (checkbox_Monster.IsChecked == true)
        {
            checkbox_Spell.IsChecked = false;
            checkbox_Trap.IsChecked = false;
            SetItemSources();
        }
        else if (checkbox_Monster.IsChecked == false && checkbox_Spell.IsChecked == false && checkbox_Trap.IsChecked == false)
        {
            checkbox_Monster.IsChecked = true;
        }
    }

    private void checkbox_Spell_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (checkbox_Spell.IsChecked == true)
        {
            checkbox_Monster.IsChecked = false;
            checkbox_Trap.IsChecked = false;
            SetItemSources();
        }
        else if (checkbox_Monster.IsChecked == false && checkbox_Spell.IsChecked == false && checkbox_Trap.IsChecked == false)
        {
            checkbox_Spell.IsChecked = true;
        }
    }

    private void checkbox_Trap_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (checkbox_Trap.IsChecked == true)
        {
            checkbox_Monster.IsChecked = false;
            checkbox_Spell.IsChecked = false;
            SetItemSources();
        }
        else if (checkbox_Monster.IsChecked == false && checkbox_Spell.IsChecked == false && checkbox_Trap.IsChecked == false)
        {
            checkbox_Spell.IsChecked = true;
        }
    }

    //Navigation

    private async void button_back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();

    }

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