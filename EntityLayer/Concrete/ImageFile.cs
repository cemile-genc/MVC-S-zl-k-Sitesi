using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ImageFile
    {
        [Key]
        public int ImageId { get; set; }
        [StringLength(1000)] //uzunluk belirtir. hangi kod üzerindeyse o kod için geçerlidir
        public string ImageName { get; set; }
        [StringLength(1000)] //uzunluk belirtir. hangi kod üzerindeyse o kod için geçerlidir
        public string ImagePath { get; set; }
    }
}
