using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
   public interface ISportsMock
    {
        IQueryable<Sport> Sports { get; }
        Sport Save(Sport sport);
        void Delete(Sport sport);
    }
}
