using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPlayers
{
	public class PlayerContext : DbContext
	{
		// MODELS
		public DbSet<Player> Player { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Players;Integrated Security=True;TrustServerCertificate=True");
		}
	}
}
