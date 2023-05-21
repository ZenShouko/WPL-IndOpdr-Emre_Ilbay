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
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
        public DataTable DataTable { get; set; }

        public BaseResult()
        {
            Errors = new List<string>();
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}
