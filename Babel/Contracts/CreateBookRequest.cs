using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Babel.Web.Contracts
{
    public class CreateBookRequest
    {
        public int Id { get; set; }
        public string NoVolumen { get; set; }
        public string Descripcion { get; set; }
    }
}
