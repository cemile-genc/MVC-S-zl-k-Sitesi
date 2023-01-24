using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete
{
    public class Context : DbContext //ilk olarak kırmızı çizgiyle gelir. popup tıkla using system.entity de.
    {
        public DbSet<About> Abouts { get; set; } //About classı farklı bir katmanda.
                                                     //bunu burada kullanabilmek için bu katmanın reference sekmesine gir.
                                                     //add reference de. ve aboutun içinde bulunduğu katmanın ismini seç
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        //Abouts , Categories, Contacts, Contents, Headings, Writers , Image
        //SQL e yansıyacak tablo isimleri.

    }
}
