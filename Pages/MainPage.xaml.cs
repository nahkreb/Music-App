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

    private async void PlayAndPauseButton_Clicked(object sender, EventArgs e)
    {
        if (SelectedSongLabel.Text == "Sezen Aksu - Ben de Yoluma Giderim")
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("audio.m4a"));

            player.Play();
        }
        else
        {
            DisplayAlert("Hata", "Bu Þarký Malesef Bulunamamaktadýr.Lütfen Baþka Bir Þarký Seçin", "Tamam");

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