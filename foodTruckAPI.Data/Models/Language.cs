using System;
using System.Collections.Generic;

namespace foodTruckAPI.Data.Models
{
    public partial class Language
    {
        public Language()
        {
            FilmLanguage = new HashSet<Film>();
            FilmOriginalLanguage = new HashSet<Film>();
        }

        public byte LanguageId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Film> FilmLanguage { get; set; }
        public virtual ICollection<Film> FilmOriginalLanguage { get; set; }
    }
}
