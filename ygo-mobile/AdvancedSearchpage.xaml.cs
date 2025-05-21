namespace ygo_mobile;

public partial class advanced_searchpage : ContentPage
{
    private readonly APIReqeustHandler RequestHandler = new APIReqeustHandler();
    public advanced_searchpage()
	{
		InitializeComponent();
        SetPickers();
    }

    //pre-determined values for card: Type, Tribe, Attribute
    private readonly List<string> CardType = new List<string>()
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
        //--Other Types--
        "Skill Card",
        "Token"
    };

    private readonly List<String> CardTribe = new List<string>()
    { 
        //--Monster Tribes--
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
        "Zombie",
        //--Spell Tribes--
        "Normal",
        "Field",
        "Equip",
        "Continuous",
        "Quick-Play",
        "Ritual",
        //--Trap Tribes--
        "Normal",
        "Continuous",
        "Counter"
    };

    private readonly List<string> CardAttribute = new List<string>()
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
        await RetrieveArchetypes();
        picker_Type.ItemsSource = CardType;
        picker_Tribe.ItemsSource = CardTribe;
        picker_Attribute.ItemsSource = CardAttribute;
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

    private void button_levelMinus_Clicked(object sender, EventArgs e)
    {

    }

    private void button_levelPlus_Clicked(object sender, EventArgs e)
    {

    }

    private void checkbox_Monter_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }

    private void checkbox_Spell_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }

    private void checkbox_Trap_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }
}