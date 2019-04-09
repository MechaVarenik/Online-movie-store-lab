using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MOVIES_DAL
{
    public class Movie
    {
        [HiddenInput]
        public int MovieId { get; set; } // id фильма

        [Required(ErrorMessage = "Введите название фильма")]
        [Display(Name = "Название")]
        public string MovieName { get; set; } // название

        [Required(ErrorMessage = "Введите слоган")]
        [Display(Name = "Слоган")]
        public string Description { get; set; } // описание

        [Required]
        [Display(Name = "Цена")]
        [Range(minimum: 1, maximum: 1000)]
        public int Price { get; set; } // цена

        [Required]
        [Display(Name = "Группа")]
        public string GroupName { get; set; } // жанр

        [ScaffoldColumn(false)]
        public byte[] Image { get; set; } // данные изображения

        [ScaffoldColumn(false)]
        public string MimeType { get; set; } // Mime - тип данных изображения
    }
}
