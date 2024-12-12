using System;
using System.Collections.Generic;
using System.Linq;
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
    public List<string> animals;
    public MainWindow ()
    {
      
      InitializeComponent();
      SetAnimals();
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
      }

      else 
      {
        lastTextBlockCliked.Visibility = Visibility.Visible;
        findingMatch = false;
      }
    }
  }
}
