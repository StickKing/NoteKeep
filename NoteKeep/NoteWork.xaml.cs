using static Android.Provider.ContactsContract.CommonDataKinds;
using static NoteKeep.Model;

namespace NoteKeep;

public partial class NoteWork : ContentPage
{
	public NoteWork()
	{
		InitializeComponent();

    }

    async void Button_Clicked(Object sender, EventArgs e)
    {
        //Возвращаемся на страницу заметок
        await Navigation.PopAsync();
        Model.Note note = new Model.Note();
        note.Set(title_note.Text, text_note.Text);
    }


    protected override bool OnBackButtonPressed()
    {

        //await Navigation.PopAsync(true);
        if (title_note.Text != "" && text_note.Text != "")
        {
            //Создаём нову заметку
            Model.Note note = new Model.Note();
            note.Set(title_note.Text, text_note.Text);
        }

        base.OnBackButtonPressed();
        return false;

    }
}
