using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }



        [StringLength(50)]
        public string WriterName { get; set; }


        [StringLength(50)]
        public string WriterSurname { get; set; }


        [StringLength(500)]
        public string WriterAbout { get; set; }

            

        [StringLength(250)]
        public string  WriterImage { get; set; }


        [StringLength(100)]
        public string WriterMail { get; set; }  
        
        [StringLength(100)]
        public string WriterTitle { get; set; }
        public bool WriterStatus { get; set; }


        [StringLength(20)]
        public string WriterPassword { get; set; }



        //Heading ile Writer İlişkilendirmesi
        public ICollection<Heading> Headings { get; set;}
        //Headings denilmesinin sebebi: 
        //Heading bir class ismi
        //Headings veritabanında görünecek olan tablonun ismi



        //Content ile Writer İlişkilendirmesi
        public ICollection<Content> Contents { get; set; }

    }

}
