using retrospring_win_universal.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            /* === USER
            UserObject result = JsonParser.getUserProfile(1);
            debugTextBlock.Text = result.screen_name.ToString();
            /*/

            /* === PUBLIC TIMELINE
            TimelineObject result = JsonParser.getPublicTimeline();
            debugTextBlock.Text = result.count.ToString();
            /*/

            /* === QUESTION
            QuestionObject result = JsonParser.getQuestion(1);
            debugTextBlock.Text = result.question;
            /*/

            //* === ANSWER
            AnswerObject result = JsonParser.getAnswer(1);
            debugTextBlock.Text = result.answer;
            //*/
        }
    }
}
