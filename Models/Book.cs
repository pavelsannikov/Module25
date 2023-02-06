using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Module25.Models
{
    /// <summary>
    /// Считаю, что не нужно отводить под жанр целую таблицу. Достаточно столбца в "Книгах"
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public string Genre { get; set; }
        public int WriterId { get; set; }
        // Навигационное свойство
        public Writer Writer { get; set; }
    }
}
