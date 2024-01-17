using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PokerAdmin.Models;

namespace PokerAdmin.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<PokerAdmin.Models.Oras> Oras { get; set; } = default!;
    public DbSet<PokerAdmin.Models.Club> Club { get; set; } = default!;
    public DbSet<PokerAdmin.Models.Jucator> Jucator { get; set; } = default!;
    public DbSet<PokerAdmin.Models.Sesiune> Sesiune { get; set; } = default!;
}

