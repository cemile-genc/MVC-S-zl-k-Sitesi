using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        // KEY kullanırken ilk olarak Entity Framework indir,
        //sonra yan tarafta çıkan pop up ile.DataAnnotations; kur.
        [Key]
        public int AboutId { get; set; }

        [StringLength(1000)] //uzunluk belirtir. hangi kod üzerindeyse o kod için geçerlidir
        public string AboutDetails1 { get; set; }

        [StringLength(1000)]
        public string AboutDetails2 { get; set; }

        [StringLength(100)]
        public string AboutImage1 { get; set; }

        [StringLength(100)]
        public string AboutImage2 { get; set; }



    }
}
