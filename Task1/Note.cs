namespace Task1
{
    public class Note
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDateTime { get; }
        public bool IsTask { get; set; }  // Новое свойство для указания типа (заметка или задача)
        public bool IsCompleted
        {
            get
            {
                if (IsTask)
                {
                    return _isCompleted;
                }
                else
                {
                    return false;  // Для заметок всегда возвращать false
                }
            }
            set
            {
                if (IsTask)
                {
                    _isCompleted = value;
                }
                // Ничего не делать для заметок
            }
        }

        private bool _isCompleted;

        public Note()
        {
            Title = string.Empty;
            Details = string.Empty;
            CreationDateTime = DateTime.Now;
            IsTask = false;  // Инициализировать как заметку по умолчанию
            IsCompleted = false;  // Инициализировать как незавершенную по умолчанию
        }
    }

}
