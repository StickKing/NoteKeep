using System;
using SQLite;

namespace NoteKeep
{
	public struct Model
	{
        //Класс, таблица Заметки
        [Table("Note")]
        public class Note
        {
            [PrimaryKey, AutoIncrement]
            public int id { get; set; }
            //Заголовок
            public string title { get; set; }
            //Тело заметки
            public string text { get; set; }

            //Конструктор
            /*public Note(string title, string text)
			{
				this.title = title;
				this.text = text;
			}*/

            //Метод получающий данные
            public (string, string) Get()
            {
                return (this.title, this.text);
            }

            //Метод записывающий данные
            public async void Set(string title, string text)
            {
                this.title = title;
                this.text = text;
                App.SQLworker.Insert(this);
            }

        }
    }
}

