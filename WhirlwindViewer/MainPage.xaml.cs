using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace WhirlwindViewer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        IList<ImageSource> images;
               public MainPage()
        {
            InitializeComponent();            
        }

       public void onNextButtonClicked(object sender, EventArgs e)
        {
            var dog = GetRandomDogImage();
            var url = dog.Result.Message;
            photoViewer.Source = ImageSource.FromUri(url);
        }

        private async Task<RandomDogMessage> GetRandomDogImage()
        {
            var client = new HttpClient();
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri("https://dog.ceo/api/breeds/image/random");

                var response = await client.GetAsync(request.RequestUri);
                var responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RandomDogMessage>(responseBody);
            }
        }

    }
}
