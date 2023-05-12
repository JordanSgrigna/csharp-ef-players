using EntityFrameworkPlayers;
using Microsoft.EntityFrameworkCore;

bool userWantsToContinue = true;
while (userWantsToContinue)
{
	Console.WriteLine("Seleziona un'opzione: ");
	Console.WriteLine("1. Inserisci un team");
	Console.WriteLine("2. Inserisci un giocatore");
	Console.WriteLine("3. Trova il giocatore per nome e cognome");
	Console.WriteLine("4. Trova il giocatore per ID");
	Console.WriteLine("5. Modifica il nome e cognome di un giocatore");
	Console.WriteLine("6. Cancella un giocatore");
	Console.WriteLine("7. Scopri i giocatori di un team");
	Console.WriteLine("8. Esci");

	int userAnswer = int.Parse(Console.ReadLine());

	switch (userAnswer)
	{
		case 1:
			Console.Write("Inserisci il nome del team da aggiungere: ");
			string teamNameChosen = Console.ReadLine();

			Console.Write("Inserisci la città di provenienza del team: ");
			string teamCityChosen = Console.ReadLine();

			Console.Write("Inserisci l'allenatore del team da aggiungere: ");
			string teamCoachChosen = Console.ReadLine();

			Console.Write("Inserisci il colore del team: ");
			string teamColorChosen = Console.ReadLine();

			Team newTeam = new Team(teamNameChosen, teamCityChosen, teamCoachChosen, teamColorChosen);

			using (PlayerContext db = new PlayerContext())
			{
				db.Add(newTeam);
				db.SaveChanges();
			}
			break;

		case 2:
			Console.Write("Aggiungi il nome del giocatore da aggiungere: ");
			string playerNameChosen = Console.ReadLine();

			Console.Write("Aggiungi il cognome del giocatore da aggiungere: ");
			string playerSurnameChosen = Console.ReadLine();

			Console.Write("Inserisci l'id del team a cui appartiene il giocatore: ");
			int teamId = int.Parse(Console.ReadLine());

			// Creo il giocatore
			Player newPlayer = new Player(playerNameChosen, playerSurnameChosen, teamId);
			// Apro il db
			using (PlayerContext db = new PlayerContext())
			{
				// Aggiungo il giocatore
				db.Add(newPlayer);
				// Salvo le modifiche fatte
				db.SaveChanges();
			}

			Console.WriteLine(newPlayer.ToString());
			break;

		case 3:
			Console.Write("Scrivi il nome dei giocatore che vuoi cercare: ");
			string playerNameToSearch = Console.ReadLine();

			Console.Write("Scrivi il cognome del giocatore che vuoi cercare: ");
			string playerSurnameToSearch = Console.ReadLine();

			using (PlayerContext db = new PlayerContext())
			{
				if (db.Player.Where(player => player.PlayerName == playerNameToSearch && player.PlayerSurname == playerSurnameToSearch).Any())
				{
					Player playerToFind = db.Player.Where(playerScansionato => playerScansionato.PlayerName == playerNameToSearch && playerScansionato.PlayerSurname == playerSurnameToSearch).Include(player => player.Team).First();
					Console.WriteLine(playerToFind.ToString());
				}
				else
				{
					Console.WriteLine("Non esiste nessuno giocatore con quel nome e cognome!");
				}

			}
			break;

		case 4:
			Console.Write("Scrivi l'id del giocatore che vuoi cercare: ");
			int playerIdToSearch = int.Parse(Console.ReadLine());

			using (PlayerContext db = new PlayerContext())
			{
				if (db.Player.Where(player => player.PlayerId == playerIdToSearch).Any())
				{
					Player playerToFindWithId = db.Player.Where(playerScans => playerScans.PlayerId.Equals(playerIdToSearch)).Include(player => player.Team).First();

					Console.WriteLine("Ecco il giocatore richiesto: ");
					Console.WriteLine(playerToFindWithId.ToString());
				}
				else
				{
					Console.WriteLine("Non esiste nessun giocatore con quell'ID");
				}
			}
			break;

		case 5:
			Console.WriteLine("Scrivi l'id del giocatore di cui vuoi cambiare nome e cognome");
			int playerIdToChange = int.Parse(Console.ReadLine());

			using (PlayerContext db = new PlayerContext())
			{
				if (db.Player.Where(player => player.PlayerId == playerIdToChange).Any())
				{
					Player playerToUpdate = db.Player.Where(playerScan => playerScan.PlayerId.Equals(playerIdToChange)).First();
					Console.WriteLine(playerToUpdate.ToString());

					Console.WriteLine("In cosa vuoi cambiare il suo nome? ");
					string replacingName = Console.ReadLine();

					playerToUpdate.PlayerName = replacingName;

					Console.WriteLine("In cosa vuoi cambiare il suo cognome? ");
					string replacingSurname = Console.ReadLine();

					playerToUpdate.PlayerSurname = replacingSurname;

					db.SaveChanges();
				}
				else
				{
					Console.WriteLine("Non esiste un giocatore con questo id");
				}
			}
			break;

		case 6:
			Console.Write("Scrivi l'id del giocatore che vuoi cancellare: ");
			int playerIdToDelete = int.Parse(Console.ReadLine());

			using (PlayerContext db = new PlayerContext())
			{
				if (db.Player.Where(player => player.PlayerId == playerIdToDelete).Any())
				{
					Player playerToDelete = db.Player.Where(playerScan => playerScan.PlayerId.Equals(playerIdToDelete)).First();

					db.Player.Remove(playerToDelete);
					db.SaveChanges();
					Console.WriteLine("Ok, hai rimosso il giocatore");
				}
				else
				{
					Console.WriteLine("Non esistono giocatori con quell'ID");
				}


			}
			break;

		case 7:
			Console.WriteLine("Scrivi l'id del team di cui vuoi sapere i giocatori");
			int teamIdToPrint = int.Parse(Console.ReadLine());

			using (PlayerContext db = new PlayerContext())
			{
				if (db.Team.Where(team => team.TeamID == teamIdToPrint).Any())
				{
					Team teamToPrint = db.Team.Where(teamScan => teamScan.TeamID.Equals(teamIdToPrint)).First();
					Console.WriteLine(teamToPrint.ToString());
				}
				else
				{
					Console.WriteLine("Non esiste un team con quell'ID");
				}
			}
			break;
		case 8:
			Console.WriteLine("Ok, va bene, buonagiornata!");
			userWantsToContinue = false;
			break;
	}
}
