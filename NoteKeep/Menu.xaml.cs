using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace NoteKeep;

public partial class Menu : Shell
{

    public List<Model.Note> test = App.SQLworker.Query<Model.Note>("SELECT * FROM Note");

	public Menu()
	{
		InitializeComponent();

        ICommand refreshCommand = new Command(() =>
        {
            Device.InvokeOnMainThreadAsync(() =>
            {
                note_items.ItemsSource = App.SQLworker.Query<Model.Note>("SELECT * FROM Note");
            });

            refresh_view.IsRefreshing = false;
        });
        refresh_view.Command = refreshCommand;

        //Вывод всех заметок на экран
        note_items.ItemTemplate = new DataTemplate(() =>
        {

            StackLayout all_item = new StackLayout();
            Label title = new Label()
            {
                FontFamily = "Vernada",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                MaxLines = 1,
                LineBreakMode = LineBreakMode.TailTruncation
            };

            Label text = new Label()
            {
                FontFamily = "Vernada",
                FontSize = 16,
                MaxLines = 1,
                LineBreakMode = LineBreakMode.TailTruncation,
                Margin = new Thickness(5, 5, 5, 5)
            };

            Label id_costil = new Label()
            {
                IsVisible = false
            };
            id_costil.SetBinding(Label.TextProperty, "id");
            title.SetBinding(Label.TextProperty, "title");
            text.SetBinding(Label.TextProperty, "text");


            all_item.Children.Add(id_costil);
            all_item.Children.Add(title);
            all_item.Children.Add(new BoxView()
            {
                HeightRequest = 2,
                HorizontalOptions = LayoutOptions.Fill
            });
            all_item.Children.Add(text);

            ICommand delete = new Command(() =>
            {
                App.SQLworker.Query<Model.Note>($"DELETE FROM Note WHERE id = {id_costil.Text}");
                note_items.ItemsSource = App.SQLworker.Query<Model.Note>("SELECT * FROM Note");
            });

            SwipeItem delete_swipe = new SwipeItem
            {
                Text = "Удалить",
                BackgroundColor = Colors.IndianRed,
                Command = delete
            };

            List<SwipeItem> swipe_items = new List<SwipeItem> { delete_swipe };

            SwipeView swipe_item = new SwipeView()
            {
                RightItems = new SwipeItems(swipe_items)
            };

            swipe_item.Content = new Frame()
            {
                Content = all_item,
                BorderColor = Colors.WhiteSmoke,
                Margin = new Thickness(6, 6, 6, 6)
            };

            return swipe_item;

        });
        
       
        note_items.ItemsSource = App.SQLworker.Query<Model.Note>("SELECT * FROM Note");
    }

    private async void AddNote(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new NoteWork());
        
        Console.WriteLine($"/ / / / / / / / / / / / kek / / / / / / / / / / /");
        refresh_view.IsRefreshing = true;
    }

    

}


