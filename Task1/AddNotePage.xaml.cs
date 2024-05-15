using Microsoft.Maui.Controls;

namespace Task1
{
    public partial class AddNotePage : ContentPage
    {
        private MainPage _mainPage;

        public AddNotePage(MainPage mainPage, bool isTask)
        {
            InitializeComponent();
            _mainPage = mainPage;
          
            // Проверяем, является ли создаваемая запись задачей
            if (isTask)
            {
                Title = "Добавить задачу";
                TitleEntry.Placeholder = "Введите заголовок задачи";
                DetailsEditor.Placeholder = "Введите описание задачи";
                IsTaskSwitch.IsVisible = true;  // Показать переключатель только если выбран тип "задача"
                IsTaskSwitch.Margin = new Thickness(20, 0, 20, 0);  // Установить отступы, чтобы сдвинуть переключатель ниже
            }
            else
            {
                Title = "Добавить заметку";
                TitleEntry.Placeholder = "Введите заголовок заметки";
                DetailsEditor.Placeholder = "Введите содержание заметки";
                IsTaskSwitch.IsVisible = false;  // Скрыть переключатель, если выбран тип "заметка"
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            string title = TitleEntry.Text;
            string details = DetailsEditor.Text;
            bool isTask = IsTaskSwitch.IsVisible ? IsTaskSwitch.IsToggled : false;  // Проверка, является ли создаваемая запись задачей

            _mainPage.AddNewNote(title, details, isTask);

            await Navigation.PopAsync();
        }
    }
}
