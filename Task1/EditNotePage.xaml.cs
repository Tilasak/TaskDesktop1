using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public partial class EditNotePage : ContentPage
    {
        private MainPage _mainPage;
        private Note? _note; // Добавляем ? после типа, чтобы сделать его допускающим значения NULL


        public EditNotePage(MainPage mainPage, Note note)
        {
            InitializeComponent();
            _mainPage = mainPage;
            _note = note;
            // Устанавливаем заголовок и содержание заметки в поля редактирования
            TitleEntry.Text = _note?.Title; // Добавляем проверку на null
            DetailsEditor.Text = _note?.Details; // Добавляем проверку на null
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_note != null)
            {
                // Вызываем метод удаления заметки из главной страницы
                _mainPage.OnDeleteNoteClicked(_note);
                // Возвращаемся на главную страницу
                Navigation.PopAsync();
            }
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            if (_note != null)
            {
                // Обновляем заголовок и содержаниеранной заметки
                _note.Title = TitleEntry.Text;
                _note.Details = DetailsEditor.Text;
                // Возвращаемся на главную страницу
                Navigation.PopAsync();
            }
        }
    }
}
