using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AspNetRunContext : DbContext
    {
        public AspNetRunContext(DbContextOptions<AspNetRunContext> options) : base(options)
        {

        }
    }
}
