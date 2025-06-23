namespace ygo_mobile;

public partial class AdvancedSearchpage : ContentPage
{ 
    private readonly APIReqeustHandler RequestHandler = new APIReqeustHandler();
    public AdvancedSearchpage()
	{
		InitializeComponent();

        RetrieveArchetypes();
        if (CardArchetypes.Count == 0)
        {
            picker_Archetype.IsEnabled = false;
        }
        preference_language.ItemsSource = new List<string>() {"English", "Italian", "French", "German", "Portuguese"};
        preference_language.SelectedItem = Preferences.Get("Language", "English");
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
            label_LevelVal.Text = "not specified";

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
            label_LevelVal.Text = "not specified";

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
        Dictionary<string, string> packedParameters = new Dictionary<string, string>();

        //Universal parameters
        if (entry_cardName.Text != "" && entry_cardName.Text != string.Empty && entry_cardName.Text != null)
        {
            packedParameters.Add("fname", entry_cardName.Text.Replace(" ", "%20"));
        }
        if (picker_Tribe.SelectedItem != null)
        {
            packedParameters.Add("race", picker_Tribe.SelectedItem.ToString().Replace(" ", "%20"));
        }
        if (picker_Archetype.SelectedItem != null)
        {
            packedParameters.Add("archetype", picker_Archetype.SelectedItem.ToString().Replace(" ", "%20"));
        }

        string language = preference_language.SelectedItem.ToString();
        switch (language)
        {
            case "English":
                break;

            case "French":
                packedParameters.Add("language", "fr");
                break;

            case "German":
                packedParameters.Add("language", "de");
                break;

            case "Italian":
                packedParameters.Add("language", "it");
                break;

            case "Portuguese":
                packedParameters.Add("language", "pt");
                break;
        }
        
        if (checkbox_Monster.IsChecked == true)
        {
            //Monster-specific parameters
            if (picker_Type.SelectedItem != null)
            {
                packedParameters.Add("type", picker_Type.SelectedItem.ToString().Replace(" ", "%20"));
            }
            if (picker_Attribute.SelectedItem != null)
            {
                packedParameters.Add("attribute", picker_Attribute.SelectedItem.ToString().Replace(" ", "%20"));
            }
            if (int.TryParse(label_LevelVal.Text, out int value))
            {
                packedParameters.Add("level", label_LevelVal.Text);
            }
        }

        if (checkbox_Spell.IsChecked)
        {
            packedParameters.Add("type", "spell%20card");
        }
        if (checkbox_Trap.IsChecked)
        {
            packedParameters.Add("type", "trap%20card");
        }


        return packedParameters;
    }

    //EVENTS

    private void button_levelMinus_Clicked(object sender, EventArgs e)
    {
        button_levelPlus.IsEnabled = true;
        if (label_LevelVal.Text == "0")
        {
            label_LevelVal.Text = "not specified";
            button_levelMinus.IsEnabled = false;
            return;
        }
        if (int.TryParse(label_LevelVal.Text, out int value))
        {
            label_LevelVal.Text = (value - 1).ToString();
        }
    }

    private void button_levelPlus_Clicked(object sender, EventArgs e)
    {
        if (label_LevelVal.Text == "not specified")
        {
            label_LevelVal.Text = "1";
            return;
        }
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
    private void preference_language_SelectedIndexChanged(object sender, EventArgs e)
    {
        Preferences.Set("Language", preference_language.SelectedItem.ToString());
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

        Dictionary<string, string> parameters = PackParameters();
        if (parameters.Count == 0 || parameters == null)
        {
            return;
        }

        icon_loading.IsRunning = true;
        icon_loading.IsVisible = true;

        List<Card> searchResults = null;
        try
        {
            searchResults = await reqeustHandler.SendRequest(parameters);
        }
        catch
        {
            await DisplayAlert("Error","failed to connect to API, are you connected to the internet?", "OK");
            return;
        }
        if (searchResults != null)
        {
            return;
        }

        await Navigation.PushModalAsync(new SearchResults(searchResults));
        icon_loading.IsRunning = false;
        icon_loading.IsVisible = false;
    }

    private void button_Clear_Clicked(object sender, EventArgs e)
    {
        entry_cardName.Text = null;
        picker_Tribe.SelectedItem = null;
        picker_Archetype.SelectedItem = null;

        picker_Type.SelectedItem = null;
        picker_Attribute.SelectedItem = null;
        label_LevelVal.Text = "not specified";
    }
}