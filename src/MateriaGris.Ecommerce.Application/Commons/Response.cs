using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaGris.Ecommerce.Application.Commons
{
    //indica que es una clase generica con <T>
    public class Response<T>
    {
        public T  Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
