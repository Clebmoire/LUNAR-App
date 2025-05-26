using System;
using Microsoft.Maui.Controls;
using UniApp.Services;


namespace UniApp
{
    public partial class Destination : ContentPage
    {
        public static Destination Instance { get; private set; }
        public Destination()
        {
            InitializeComponent();
            Instance = this;
        }

        public async void Arrival()
        {
            // Navigate to Arrival page
            await Navigation.PushAsync(new Arrival());
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (Instance == this)
                Instance = null;
        }

        public async Task NavigateWithUnity(string destinationPage, string destinationName)
        {
            Console.WriteLine($"[DEBUG] NavigateWithUnity called: {destinationName}");

#if ANDROID
    if (!string.IsNullOrEmpty(Qr.SelectedStartPoint))
    {
        Console.WriteLine($"[DEBUG] Launching Unity with message: {destinationName}");
        DependencyService.Get<IUnityLauncher>()?.LaunchUnity(destinationName);
        return;
    }
    else
    {
        Console.WriteLine("[DEBUG] Qr.SelectedStartPoint is null or empty");
    }
#endif

            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await Task.Delay(500);
                if (Shell.Current != null)
                {
                    Console.WriteLine($"[DEBUG] Navigating to: {destinationPage}");
                    await Shell.Current.GoToAsync(destinationPage);
                }
                else
                {
                    Console.WriteLine("[DEBUG] Shell.Current is null");
                }
            });
        }

        private async void Accounting(object sender, EventArgs e) => await NavigateWithUnity("Accounting", "Accounting");
        private async void NextQr(object sender, EventArgs e) => await NavigateWithUnity("Qr", "Qr");
        private async void C(object sender, EventArgs e) => await NavigateWithUnity("CBuilding", "CBuilding");
        private async void CMO(object sender, EventArgs e) => await NavigateWithUnity("CMO", "CMO");
        private async void Canteen(object sender, EventArgs e) => await NavigateWithUnity("Canteen", "Canteen");
        private async void CECA(object sender, EventArgs e) => await NavigateWithUnity("CECA", "CECA");
        private async void Clinic(object sender, EventArgs e) => await NavigateWithUnity("Clinic", "Clinic");
        private async void Jurgens(object sender, EventArgs e) => await NavigateWithUnity("Jurgens", "Jurgens");
        private async void Fpark(object sender, EventArgs e) => await NavigateWithUnity("FriendshipPark", "FriendshipPark");
        private async void Guidance(object sender, EventArgs e) => await NavigateWithUnity("Guidance", "Guidance");
        private async void Highschool(object sender, EventArgs e) => await NavigateWithUnity("Highschool", "Highschool");
        private async void J(object sender, EventArgs e) => await NavigateWithUnity("Jbuilding", "Jbuilding");
        private async void LH1(object sender, EventArgs e) => await NavigateWithUnity("LH1", "LH1");
        private async void LH2(object sender, EventArgs e) => await NavigateWithUnity("LH2", "LH2");
        private async void Lib2(object sender, EventArgs e) => await NavigateWithUnity("LIB2", "LIB2");
        private async void Lib3(object sender, EventArgs e) => await NavigateWithUnity("LIB3", "LIB3");
        private async void N(object sender, EventArgs e) => await NavigateWithUnity("Nbuilding", "Nbuilding");
        private async void Op(object sender, EventArgs e) => await NavigateWithUnity("Openstage", "Openstage");
        private async void OSAS(object sender, EventArgs e) => await NavigateWithUnity("Osas", "Osas");
        private async void Chapel(object sender, EventArgs e) => await NavigateWithUnity("Chapel", "Chapel");
        private async void CIT(object sender, EventArgs e) => await NavigateWithUnity("CIT", "CIT");
        private async void ElemLib(object sender, EventArgs e) => await NavigateWithUnity("ElemLib", "ElemLib");
        private async void GPE(object sender, EventArgs e) => await NavigateWithUnity("GPE", "GPE");
        private async void Gym(object sender, EventArgs e) => await NavigateWithUnity("Gym", "Gym");
        private async void HsFaculty(object sender, EventArgs e) => await NavigateWithUnity("HsFaculty", "HsFaculty");
        private async void HsPrincipal(object sender, EventArgs e) => await NavigateWithUnity("HsPrincipal", "HsPrincipal");
        private async void IDQA(object sender, EventArgs e) => await NavigateWithUnity("IDQA", "IDQA");
        private async void EMC(object sender, EventArgs e) => await NavigateWithUnity("EMC", "EMC");
        private async void SSC(object sender, EventArgs e) => await NavigateWithUnity("SSC", "SSC");
        private async void SaceDean(object sender, EventArgs e) => await NavigateWithUnity("SaceDean", "SaceDean");
        private async void SaceProgramChair(object sender, EventArgs e) => await NavigateWithUnity("SaceProgramChair", "SaceProgramChair");
        private async void SupplyOffice(object sender, EventArgs e) => await NavigateWithUnity("SupplyOffice", "SupplyOffice");
        private async void Registrar(object sender, EventArgs e) => await NavigateWithUnity("Registrar", "Registrar");
        private async void URIO(object sender, EventArgs e) => await NavigateWithUnity("URIO", "URIO");
        private async void VpAcad(object sender, EventArgs e) => await NavigateWithUnity("VpAcad", "VpAcad");
        private async void N6(object sender, EventArgs e) => await NavigateWithUnity("N6", "N6");
    }
}
