using System;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MemoryGame2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer timer;
        Board board;
        Card clickedCard;
        Image clickedImage;
        Image secondImage;
        Button buttonClicked;
        int size = 4;
        public MainPage()
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0,500);
            this.InitializeComponent();
        }
        private void StartGame(object sender, RoutedEventArgs e)
        {
            board = new Board(size); 
            for (int i = 0; i < size; i++)
            {
                gameGrid.RowDefinitions.Add(new RowDefinition());
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition());

                for (int j = 0; j < size; j++)
                {
                    Card card = board.GetCard((i * size) + j);
                    Button btn = new Button();
                    btn.HorizontalAlignment = HorizontalAlignment.Stretch;
                    btn.VerticalAlignment = VerticalAlignment.Stretch;
                    btn.Margin = new Thickness(10);
                    btn.Click += Btn_Click;
                    gameGrid.Children.Add(btn);
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                }
            }
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;//btn that is pressed
            int col = Grid.GetColumn(btn);//collonm of btn
            int row = Grid.GetRow(btn);//row of btn
            Card card = board.GetCard((row * size) + col); //card according to col n row
            Image img = new Image();// making new picture
            img.Source = new BitmapImage(new Uri(card.ImageSource)); // the picture
            gameGrid.Children.Add(img);// adding picture to grid
            Grid.SetRow(img, row);// defining the pic row
            Grid.SetColumn(img, col);
            //Checking
            if(clickedCard != null) //if there is already an open image
            {
                if (clickedCard.ImageSource == card.ImageSource) //check if pair
                {
                    card.FLipped = true;
                    btn.IsEnabled = false;
                }
                else
                {
                    card = null;
                    clickedCard = null; //Close Images
                    secondImage = img;
                    timer.Start();
                }
            }
            else
            {
                clickedCard = card;
                clickedImage = img;
                clickedCard.FLipped = true;
                btn.IsEnabled = false; //locking the click of the image
                buttonClicked = btn;
            }
        }
        private void Timer_Tick(object sender, object e) //איפוס
        {
            gameGrid.Children.Remove(secondImage);
            gameGrid.Children.Remove(clickedImage);
            buttonClicked.IsEnabled = true;
            timer.Stop();
            //var messageDialog = new MessageDialog("You win. Want to try again?");
        }
    }
}

