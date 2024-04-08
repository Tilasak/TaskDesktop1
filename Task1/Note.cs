namespace Task1
{
    public class Note
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDateTime { get; }  // Новое свойство для хранения времени и даты создания

        public Note()
        {
            Title = string.Empty;
            Details = string.Empty;
            CreationDateTime = DateTime.Now;  // Инициализация времени и даты создания
        }
    }
}
