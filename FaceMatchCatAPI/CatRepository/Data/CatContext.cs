using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class CatContext : DbContext
    {
        public virtual DbSet<Cat> Cats { get; set; }

        public CatContext(DbContextOptions<CatContext> options) : base(options)
        {
        }
    }
}
