using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoditasAssignment.Data.Infrastructure
{
    public class Response<T> where T : class
    {
        #region Properties
        public int Status { get; set; }
        public T Record { get; set; }
        public string Message { get; set; }

        #endregion
    }
}