using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace Task1
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Note> Notes { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Notes = new ObservableCollection<Note>();
            BindingContext = this;
        }

        public void AddNewNote(string title, string details, bool isTask)
        {
            Notes.Add(new Note { Title = title, Details = details, IsTask = isTask });
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Выберите тип", "Отмена", null, "Заметка", "Задача");

            if (action == "Заметка")
            {
                await Navigation.PushAsync(new AddNotePage(this, isTask: false));
            }
            else if (action == "Задача")
            {
                await Navigation.PushAsync(new AddNotePage(this, isTask: true));
            }
        }


        public async void OnUpdateNoteClicked(Note note)
        {
            await Navigation.PushAsync(new EditNotePage(this, note));
        }

        public void OnDeleteNoteClicked(Note note)
        {
            Notes.Remove(note);
        }

        private async void NoteItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedNote = (Note)e.Item;
            await Navigation.PushAsync(new EditNotePage(this, selectedNote));
        }
    }
}
