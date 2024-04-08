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
    }
}
