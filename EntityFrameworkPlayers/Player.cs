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
		public int GamesPlayed { get; set; }
		[Column("player_number_of_games_won")]
		public int GamesWon { get; set; }
		public int TeamId { get; set; }
		public Team Team { get; set; }

		// CONSTRUCTOR
		public Player(string playerName, string playerSurname, int teamId)
		{
			Random rnd = new Random();
			this.PlayerName = playerName;
			this.PlayerSurname = playerSurname;
			PlayerScore = rnd.Next(11);
			GamesPlayed = rnd.Next(1, 101);
			GamesWon = rnd.Next(1, GamesPlayed + 1);
			TeamId = teamId;
		}

		//METHODS
		public override string ToString()
		{
			string infoString = "ID: " + PlayerId + ", Nome: " + PlayerName + ", Cognome: " + PlayerSurname + ", Score: " + PlayerScore + ", Partite Giocate: " + GamesPlayed + ", Partite Vinte: " + GamesWon;
			return infoString;
		}

	}

}

