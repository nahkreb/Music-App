namespace MusicApp.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        string kullaniciAdi = KullaniciAdiEntry.Text;
        string sifre = SifreEntry.Text;

        // Kullan�c� ad� ve �ifre kontrol�
        if (kullaniciAdi == "admin" && sifre == "1234")
        {
            // Ba�ar�l� giri�, bir sonraki sayfaya y�nlendirme
            Navigation.PushAsync(new MainPage());

            // Ba�ar�l� giri�, oturum bilgilerini sakla
            SecureStorage.SetAsync("KullaniciAdi", kullaniciAdi);
            SecureStorage.SetAsync("Sifre", sifre);
        }
        else
        {
            // Hatal� giri�
            KullaniciAdiEntry.Text="";
            SifreEntry.Text = "";
            DisplayAlert("Hata", "Kullan�c� ad� veya �ifre hatal�!", "Tamam");
        }
    }
}