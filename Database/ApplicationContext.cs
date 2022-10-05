using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Pokemons>? Pokemons { get; set; }
        public DbSet<Regions>? Regions { get; set; }
        public DbSet<PokemonTypes>? PokemonTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API

            #region tables
            modelBuilder.Entity<Pokemons>().ToTable("Pokemons");
            modelBuilder.Entity<Regions>().ToTable("Regions");
            modelBuilder.Entity<PokemonTypes>().ToTable("PokemonTypes");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Pokemons>().HasKey(pokemon => pokemon.Id);
            modelBuilder.Entity<Regions>().HasKey(region => region.Id);
            modelBuilder.Entity<PokemonTypes>().HasKey(pokemonTypes => pokemonTypes.Id);
            #endregion

            #region relationships
            modelBuilder.Entity<Regions>()
                .HasMany<Pokemons>(region => region.Pokemons)
                .WithOne(pokemon => pokemon.Regions)
                .HasForeignKey(pokemon => pokemon.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PokemonTypes>()
                .HasMany<Pokemons>(pokemonTypes => pokemonTypes.Pokemons)
                .WithOne(pokemon => pokemon.PokemonTypes)
                .HasForeignKey(pokemon => pokemon.PrimaryTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PokemonTypes>()
                .HasMany<Pokemons>(pokemonTypes => pokemonTypes.Pokemons)
                .WithOne(pokemon => pokemon.PokemonTypes)
                .HasForeignKey(pokemon => pokemon.SecondaryTypeId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region "property configurations"

            #region pokemons
             modelBuilder.Entity<Pokemons>()
                .Property(pokemon => pokemon.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Pokemons>()
                .Property(pokemon => pokemon.ImagePath)
                .IsRequired();

            modelBuilder.Entity<Pokemons>()
                .Property(pokemon => pokemon.RegionId)
                .IsRequired();

            modelBuilder.Entity<Pokemons>()
                .Property(pokemon => pokemon.PrimaryTypeId)
                .IsRequired();
            #endregion

            #region regions
             modelBuilder.Entity<Regions>()
                .Property(region => region.Name)
                .IsRequired()
                .HasMaxLength(100);
            #endregion

            #region pokemonTypes
            modelBuilder.Entity<PokemonTypes>()
               .Property(pokemonTypes => pokemonTypes.Name)
               .IsRequired()
               .HasMaxLength(100);
            #endregion

            #endregion
        }

    }
}
