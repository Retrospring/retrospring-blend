using retrospring_win_universal.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using retrospring_win_universal.Data.DataObjects;
using retrospring_win_universal.Common;
using retrospring_win_universal.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace retrospring_win_universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            AnswersObject tl = await DataLoader.DeserializeAndLoad<AnswersObject>("public_timeline.xml");
            timelineView.DataContext = tl;
        }

        private async void action_RefreshTimeline(object sender, RoutedEventArgs e)
        {
            prgringLoading.IsActive = true;

            AnswersObject tl = await JsonConnector.GetPublicTimeline();

            prgringLoading.IsActive = false;

            timelineView.DataContext = tl;

            await DataLoader.SerializeAndSave<AnswersObject>(tl, "public_timeline.xml");

            debugTextBlock.Text = "Timeline loaded. (Count: " + tl.Count + ")";
        }

        private void Hyperlink_Click(Windows.UI.Xaml.Documents.Hyperlink sender, Windows.UI.Xaml.Documents.HyperlinkClickEventArgs args)
        {
            //TODO
            Frame.Navigate(typeof(UserDetailPage), null);
        }

        private void timelineView_ItemClick(object sender, ItemClickEventArgs e)
        {
            AnswerObject answerObj = (AnswerObject) e.ClickedItem;
            debugTextBlock.Text = "Should be switching pages to answer";
            Frame.Navigate(typeof(AnswerDetailPage), answerObj);
        }
    }
}
