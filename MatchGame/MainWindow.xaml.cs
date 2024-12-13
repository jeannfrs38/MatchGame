using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    DispatcherTimer timer = new DispatcherTimer();
    int tenthsOfSecondsElapsed;
    int matchesFound;

    public List<string> animals;
    public MainWindow ()
    {
      
      InitializeComponent();
      timer.Interval = TimeSpan.FromSeconds(.1);
      timer.Tick += Timer_Tick;
      
      SetAnimals();
    }

    private void Timer_Tick (object sender, EventArgs e)
    {
      tenthsOfSecondsElapsed++;
      TimeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
      if (matchesFound == 8) 
      {
        timer.Stop();
        TimeTextBlock.Text = TimeTextBlock.Text + " - Play Again?";
      }
    }

    public void SetAnimals()
    {
      animals = new List<string>() {
          "🦄", "🦄",
          "👾", "👾",
          "👹", "👹",
          "😃", "😃",
          "🤖", "🤖",
          "🐷", "🐷",
          "👻", "👻",
          "👽", "👽"
        };

      Random random = new Random();

      foreach (TextBlock items in MainGrid.Children.OfType<TextBlock>())
      {
        var index = random.Next(0, animals.Count);
        string animalEmoji = animals[index];
        items.Text = animalEmoji;
        animals.RemoveAt(index);
      }


    }
    TextBlock lastTextBlockCliked;
    bool findingMatch = false;
    private void TextBlock_MouseDown (object sender, MouseButtonEventArgs e)
    {
      TextBlock textblock = sender as TextBlock;
      if (findingMatch == false)
      {
        textblock.Visibility = Visibility.Hidden;
        lastTextBlockCliked = textblock;
        findingMatch = true;
      }

      else if (textblock.Text == lastTextBlockCliked.Text)
      {
        textblock.Visibility = Visibility.Hidden;
        findingMatch = false;
        matchesFound += 1;
      }

      else 
      {
        lastTextBlockCliked.Visibility = Visibility.Visible;
        findingMatch = false;
      }
    }

    private void TimeTextBlock_MouseDown (object sender, MouseButtonEventArgs e)
    {
      if (matchesFound == 8) 
      {
        SetAnimals();
      }
    }
  }
}
