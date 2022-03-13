﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KVendasWeb.Models;

namespace KVendasWeb.Data
{
    public class KVendasWebContext : DbContext
    {
        public KVendasWebContext (DbContextOptions<KVendasWebContext> options)
            : base(options)
        {
        }

        public DbSet<KVendasWeb.Models.Departament> Departament { get; set; }
    }
}