using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPlayers
{
	public class Player
	{
		// PROPERTIES
		[Key]
		public int PlayerId { get; set; }
		[Column("player_name")]
		public string PlayerName { get; set; }
		[Column("player_surname")]
		public string PlayerSurname { get; set; }
		[Column("player_score")]
		public int PlayerScore { get; set; }
		[Column("player_number_of_games_played")]
		public int NumberOfGamesPlayed { get; set; }
		[Column("player_number_of_games_won")]
		public int NumberOfGamesWon { get; set; }

		// CONSTRUCTOR
		public Player(string playerName, string playerSurname)
		{
			Random rnd = new Random();
			this.PlayerName = playerName;
			this.PlayerSurname = playerSurname;
			PlayerScore = rnd.Next(11);
			NumberOfGamesPlayed = rnd.Next(1, 101);
			NumberOfGamesWon = rnd.Next(1, NumberOfGamesPlayed + 1);
		}

	}

}

