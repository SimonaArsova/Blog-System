using BlogSystem.Data.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data
{
    public class SaveContext : ISaveContext
    {
        private readonly DbContext context;

        public SaveContext(DbContext context)
        {
            Guard.WhenArgument(context, "DbContext").IsNull().Throw();

            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
