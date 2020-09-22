using DotnetApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Contexts
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<BandMember> BandMembers { get; set; }

        public MusicDbContext()
        {
        }

        public MusicDbContext(DbContextOptions<MusicDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //if (!options.IsConfigured)
            //{
            //    var builder = new ConfigurationBuilder();
            //    builder.AddUserSecrets<Program>();

            //    var connectionString = Configuration[];

            //    options.UseSqlServer();
            //}
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Album>()
                .HasOne(al => al.Artist)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(al => al.ArtistId);

            //builder.Entity<Song>()
            //    .HasOne<Artist>(s => s.Artist)
            //    .WithMany(ar => ar.Songs)
            //    .HasForeignKey(s => s.ArtistId);

            builder.Entity<Song>()
                .HasOne<Album>(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId);

            builder.Entity<BandMember>()
                .HasOne<Artist>(a => a.Artist)
                .WithMany(b => b.Members)
                .HasForeignKey(b => b.ArtistId);
        }

    }
}
