using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Abstract
{
    //Bu yeni bir yöntemdir. Burada yazılan T istenilen verini tipini belirtir. 
    //Bu şekilde tüm tablolar üzerinde işlem yapabiliriz. 
    public interface IRepository <T>
    {
        List<T> List ();

        T Get(Expression<Func<T, bool>> filter); //Tek değer döndüreceği için bu şekilde tanım yapıyoruz
        void İnsert (T p);
        void Delete (T p);
        void Update(T p);

        List<T> List(Expression<Func<T,bool>> filter); // Birden fazla değer döndüreceği için liste halinde çekmesini istiyoruz
                                                       // filtreleme yapar.

    }
}
