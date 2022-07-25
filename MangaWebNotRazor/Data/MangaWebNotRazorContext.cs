using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MangaWebNotRazor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MangaWebNotRazor.Data
{
    public class MangaWebNotRazorContext : IdentityDbContext<MangaUser>
    {
        public MangaWebNotRazorContext (DbContextOptions<MangaWebNotRazorContext> options)
            : base(options)
        {
        }

        public DbSet<MangaUser> User { get; set; } = default!;
    }
}
