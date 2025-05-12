namespace ygo_mobile;

public partial class advanced_searchpage : ContentPage
{
	public advanced_searchpage()
	{
		InitializeComponent();
        CardArchetypes = RecieveArchetypes();
	}

    //pre-determined values for card: Type, Tribe, Attribute
    private readonly List<string> CardKinds = new List<string>()
    {
        "Monster",
        "Spell",
        "Trap"
    };

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

    private List<string> RecieveArchetypes()
    {
        if (CardArchetypes.Count() == 0)
        {
            APIReqeustHandler requestHandler = new APIReqeustHandler();
            return requestHandler.GetArchetypes();
        }
        return CardArchetypes;
    }
}