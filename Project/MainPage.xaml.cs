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

using Windows.Media.SpeechRecognition;
using Windows.Storage;
using Windows.UI.Popups;
using System.Threading.Tasks;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Project
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
        
        TicTacToe ticTacToe = new TicTacToe();
        private void Tic(object sender, RoutedEventArgs e)
        {
            myPanel.Visibility = Visibility.Collapsed;
            myInstructions.Visibility = Visibility.Collapsed;
            Display.Visibility = Visibility.Visible;
            ticTacToe.New(Display);
        }
        Connect4 connect4 = new Connect4();
        private void Connect(object sender, RoutedEventArgs e)
        {
            myPanel.Visibility = Visibility.Collapsed;
            Display.Visibility = Visibility.Visible;
            myInstructions.Visibility = Visibility.Collapsed;
            connect4.New(Display);
        }
        private void HowTo(object sender, RoutedEventArgs e)
        {
            myPanel.Visibility = Visibility.Collapsed;
            Display.Visibility = Visibility.Collapsed;
            myInstructions.Visibility = Visibility.Visible;
        }
        private void Homep(object sender, RoutedEventArgs e)
        {
            Display.Visibility = Visibility.Collapsed;
            myPanel.Visibility = Visibility.Visible;
            myInstructions.Visibility = Visibility.Collapsed;
        }
    }
}
