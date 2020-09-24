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
        public DbSet<Artist> Artists { get; set; }
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
            builder.Entity<Artist>()
                .Property(a => a.Id)
                .HasDefaultValueSql("newid()");

            builder.Entity<Album>()
                .Property(a => a.Id)
                .HasDefaultValueSql("newid()");

            builder.Entity<Song>()
                .Property(a => a.Id)
                .HasDefaultValueSql("newid()");

            builder.Entity<BandMember>()
                .Property(a => a.Id)
                .HasDefaultValueSql("newid()");

            builder.Entity<Artist>()
                .HasMany<Album>(ar => ar.Albums)
                .WithOne(al => al.Artist)
                .HasForeignKey(al => al.ArtistId);

            builder.Entity<Artist>()
                .HasMany<Song>(a => a.Songs)
                .WithOne(s => s.Artist)
                .HasForeignKey(s => s.ArtistId);

            builder.Entity<Artist>()
                .HasMany<BandMember>(a => a.Members)
                .WithOne(b => b.Artist)
                .HasForeignKey(b => b.ArtistId);

            builder.Entity<Album>()
                .HasMany<Song>(a => a.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(s => s.AlbumId);
        }

    }
}
