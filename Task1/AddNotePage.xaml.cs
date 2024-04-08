using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Task1
{
    public partial class AddNotePage : ContentPage
    {
        private MainPage mainPage; // Добавляем поле для MainPage

        public AddNotePage(MainPage mainPage)
        {
            InitializeComponent();
            this.mainPage = mainPage; // Инициализируем поле MainPage
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Получение заголовка и текста заметки
            string title = TitleEntry.Text;
            string details = DetailsEditor.Text;

            // Сохранение заметки в хранилище/базу данных
            // Например: NoteStorage.SaveNote(title, details);

            // Обновление главного экрана с новой заметкой
            mainPage.AddNewNote(title, details);

            // Возврат на главный экран
            await Navigation.PopAsync();
        }
    }
}
