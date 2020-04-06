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
            ticTacToe.New(Display);
        }
        Connect4 connect4 = new Connect4();
        private void Connect(object sender, RoutedEventArgs e)
        {
            connect4.New(Display);
        }
        
    }

}

/*
//create a speech recognizer object - listens
private SpeechRecognizer speechRecognizer;

public MainPage()
{
    this.InitializeComponent();
    this.Loaded += MainPage_Loaded;
}

private async void MainPage_Loaded(object sender, RoutedEventArgs e)
{
    speechRecognizer = new SpeechRecognizer();
    speechRecognizer.Timeouts.BabbleTimeout = TimeSpan.FromSeconds(0);
    speechRecognizer.Timeouts.InitialSilenceTimeout = TimeSpan.FromSeconds(5);
    speechRecognizer.Timeouts.EndSilenceTimeout = TimeSpan.FromSeconds(0.5);

    // load grammar file here
    var grammarFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///grammar.xml"));
    //adds constraints to the speechrecognizer
    speechRecognizer.Constraints.Add(new SpeechRecognitionGrammarFileConstraint(grammarFile));
    var result = await speechRecognizer.CompileConstraintsAsync();
    if (result.Status == SpeechRecognitionResultStatus.Success)
    {
        while (true)
        {
            //listen in to the user
            SpeechRecognitionResult srr = await speechRecognizer.RecognizeAsync();
            //get commands
            string myCommand = srr.SemanticInterpretation.Properties["command"].Single();
            string ruleID = srr.RulePath[0];
            var messageDialog = new Windows.UI.Popups.MessageDialog(myCommand, "User Said This " + ruleID);
            await messageDialog.ShowAsync();
        }
    }
}
}
}
*/
