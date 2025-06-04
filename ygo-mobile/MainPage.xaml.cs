namespace ygo_mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void button_navigate_search_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AdvancedSearchpage());
        }
    }
}
