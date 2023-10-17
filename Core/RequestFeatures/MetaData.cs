using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RequestFeatures
{
    public class MetaData
    {
        public int CurrentPage { get; set; }   // Mevcut sayfa 
        public int PageSize { get; set; }      // Bir sayfada ki veri sayısı
        public int TotalPage { get; set; }     // Toplam sayfa
        public int TotalCount { get; set; }    // Toplam veri

        public bool HasPrevious => CurrentPage > 1;   // Öncesinde sayfa varmı
        public bool HasNextPage => CurrentPage < TotalPage;     // Sonrasında sayfa varmı
    }
}
