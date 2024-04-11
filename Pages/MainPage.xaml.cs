using Plugin.Maui.Audio;


namespace MusicApp.Pages;

public partial class MainPage : ContentPage
{

    private readonly IAudioManager audioManager;

    public MainPage()
    {
        InitializeComponent();
        this.audioManager = new AudioManager();
        SelectedSongLabel.Text = "Sezen Aksu - Ben de Yoluma Giderim";

    }



    private bool isPlaying = false; // M�zi�in �al�p �almad���n� izlemek i�in bir de�i�ken

    private async void PlayAndPauseButton_Clicked(object sender, EventArgs e)
    {


        if (SelectedSongLabel.Text == "Sezen Aksu - Ben de Yoluma Giderim")
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("audio.m4a"));

            if (isPlaying)
            {
                // M�zik �al�yorsa, oynat�c�y� durdur
                player.Pause();
                isPlaying = false;

            }
            else
            {
                // M�zik �alm�yorsa, oynat�c�y� ba�lat
                player.Play();
                isPlaying = true;

                var defaultMusicDuration = TimeSpan.FromSeconds(player.Duration); // Video s�resini saniye cinsinden al
                Lbl_MusicDuration.Text = defaultMusicDuration.ToString(@"mm\:ss"); // Dakika: Saniye format�nda g�ster



            }
        }
        else
        {
            await DisplayAlert("Hata", "Bu �ark� Malesef Bulunamamaktad�r. L�tfen Ba�ka Bir �ark� Se�in", "Tamam");
        }
    }


    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is string selectedSong)
        {
            SelectedSongLabel.Text = selectedSong;
        }
    }
}