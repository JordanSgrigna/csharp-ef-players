using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPlayers
{
	public class Team
	{
		[Key]
		public int TeamID { get; set; }
		[Column("team_name")]
		public string Name { get; set; }
		[Column("team_city")]
		public string City { get; set; }
		[Column("team_coach")]
		public string Coach { get; set; }
		[Column("team_color")]
		public string Color { get; set; }

		List<Player> Players { get; set; }


		public Team(string name, string city, string coach, string color)
		{
			Name = name;
			City = city;
			Coach = coach;
			Color = color;
			Players = new List<Player>();
		}
	}
}
