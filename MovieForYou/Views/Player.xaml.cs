using System;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MovieForYou.Views
{
    /// <summary>
    /// Логика взаимодействия для Player.xaml
    /// </summary>
    public partial class Player : UserControl
    {
        public Player(string str)
        {
            InitializeComponent();
            this.webBrowser.ShowYouTubeVideo(str);
        }

        //public Player()
        //{
        //    InitializeComponent();
        //    string path = this.Tag.ToString();
        //    this.webBrowser.ShowYouTubeVideo(path);
        //}
    }
    
    public static class WebBrowserExtensions
    {
        private static string GetYouTubeVideoPlayerHTML(string videoCode)
        {
            var sb = new StringBuilder();

            const string YOUTUBE_URL = @"http://www.youtube.com/v/";

            sb.Append("<html>");
            sb.Append("    <head>");
            sb.Append("        <meta name=\"viewport\" content=\"width=device-width; height=device-height;\">");
            sb.Append("    </head>");
            sb.Append("    <body marginheight=\"0\" marginwidth=\"0\" leftmargin=\"0\" topmargin=\"0\" style=\"overflow-y: hidden\">");
            sb.Append("        <object width=\"100%\" height=\"100%\">");
            sb.Append("            <param name=\"movie\" value=\"" + YOUTUBE_URL + videoCode + "?version=3&amp;rel=0\" />");
            sb.Append("            <param name=\"allowFullScreen\" value=\"true\" />");
            sb.Append("            <param name=\"allowscriptaccess\" value=\"always\" />");
            sb.Append("            <embed src=\"" + YOUTUBE_URL + videoCode + "?version=3&amp;rel=0\" type=\"application/x-shockwave-flash\"");
            sb.Append("                   width=\"100%\" height=\"100%\" allowscriptaccess=\"always\" allowfullscreen=\"true\" />");
            sb.Append("        </object>");
            sb.Append("    </body>");
            sb.Append("</html>");

            return sb.ToString();
        }

        public static void ShowYouTubeVideo(this WebBrowser webBrowser, string videoCode)
        {
            if (webBrowser == null) throw new ArgumentNullException("webBrowser");

            webBrowser.NavigateToString(GetYouTubeVideoPlayerHTML(videoCode));
        }
    }
}
