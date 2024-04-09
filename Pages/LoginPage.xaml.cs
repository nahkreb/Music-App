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

        // Kullanýcý adý ve þifre kontrolü
        if (kullaniciAdi == "admin" && sifre == "1234")
        {
            // Baþarýlý giriþ, bir sonraki sayfaya yönlendirme
            Navigation.PushAsync(new MainPage());

            // Baþarýlý giriþ, oturum bilgilerini sakla
            SecureStorage.SetAsync("KullaniciAdi", kullaniciAdi);
            SecureStorage.SetAsync("Sifre", sifre);
        }
        else
        {
            // Hatalý giriþ
            KullaniciAdiEntry.Text="";
            SifreEntry.Text = "";
            DisplayAlert("Hata", "Kullanýcý adý veya þifre hatalý!", "Tamam");
        }
    }
}