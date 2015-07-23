using retrospring_win_universal.Web;
using retrospring_win_universal.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            /* === USER
            UserObject result = JsonParser.getUserProfile(1);
            debugTextBlock.Text = result.screen_name.ToString();
            /*/

            //* === PUBLIC TIMELINE
            TimelineObject result = JsonParser.getPublicTimeline();
            debugTextBlock.Text = "Loaded public timeline.";
            
            timelineListView.DataContext = result.answers;
            //*/

            /* === QUESTION
            QuestionObject result = JsonParser.getQuestion(1);
            debugTextBlock.Text = result.question;
            /*/

            /* === ANSWER
            AnswerObject result = JsonParser.getAnswer(1);
            debugTextBlock.Text = result.answer;
            /*/

            /* === FOLLOWER
            FollowerObject result = JsonParser.getUserFollower(1);
            debugTextBlock.Text = result.count.ToString();
            /*/

            /* === FOLLOWING
            FollowingObject result = JsonParser.getUserFollowing(1);
            debugTextBlock.Text = result.count.ToString();
            /*/
        }
    }
}
