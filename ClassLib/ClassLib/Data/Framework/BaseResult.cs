using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Data.Framework
{
    public abstract class BaseResult
    {
<<<<<<< HEAD
        private List<string> errors = new List<string>();

        public DataTable DataTable { get; set; }

        public bool Succeeded { get; set; }

        public IEnumerable<string> Errors => errors;

        public void AddError(string error)
        {
            errors.Add(error);
=======
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
        public DataTable DataTable { get; set; }
        public void AddError(string error)
        {
            Errors.Add(error);
>>>>>>> a778a54c9f46b127167b54fe319c5ea68c060329
        }
    }
}
