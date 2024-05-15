using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Task1
{
    public partial class MainPage : ContentPage
    {
        // Создаем коллекцию для хранения заметок
        public ObservableCollection<Note> Notes { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Notes = new ObservableCollection<Note>();
            // Устанавливаем источник данных для привязки на MainPage
            BindingContext = this;
        }

        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            // Переход на страницу для добавления и сохранения заметок
            await Navigation.PushAsync(new AddNotePage(this));
        }

        // Добавление новой заметки в коллекцию и автоматическое уведомление об изменениях
        public void AddNewNote(string title, string details)
        {
            Notes.Add(new Note { Title = title, Details = details });
        }

        // Метод для обновления существующей заметки
        public async void OnUpdateNoteClicked(Note note)
        {
            // Создаем новую страницу для редактирования заметки и передаем в нее выбранную заметку
            await Navigation.PushAsync(new EditNotePage(this, note));
        }

        // Метод для удаления заметки из коллекции
        public void OnDeleteNoteClicked(Note note)
        {
            // Удаляем выбранную заметку из коллекции
            Notes.Remove(note);
        }
        private async void NoteItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedNote = (Note)e.Item;
            await Navigation.PushAsync(new EditNotePage(this, selectedNote));
        }


    }
}
