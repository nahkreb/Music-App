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



    private bool isPlaying = false; // Müziðin çalýp çalmadýðýný izlemek için bir deðiþken

    private async void PlayAndPauseButton_Clicked(object sender, EventArgs e)
    {


        if (SelectedSongLabel.Text == "Sezen Aksu - Ben de Yoluma Giderim")
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("audio.m4a"));

            if (isPlaying)
            {
                // Müzik çalýyorsa, oynatýcýyý durdur
                player.Pause();
                isPlaying = false;

            }
            else
            {
                // Müzik çalmýyorsa, oynatýcýyý baþlat
                player.Play();
                isPlaying = true;

                var defaultMusicDuration = TimeSpan.FromSeconds(player.Duration); // Video süresini saniye cinsinden al
                Lbl_MusicDuration.Text = defaultMusicDuration.ToString(@"mm\:ss"); // Dakika: Saniye formatýnda göster



            }
        }
        else
        {
            await DisplayAlert("Hata", "Bu Þarký Malesef Bulunamamaktadýr. Lütfen Baþka Bir Þarký Seçin", "Tamam");
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