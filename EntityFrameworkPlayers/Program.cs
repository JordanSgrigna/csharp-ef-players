using EntityFrameworkPlayers;

bool userWantsToContinue = true;
while (userWantsToContinue)
{
	Console.WriteLine("Seleziona un'opzione: ");
	Console.WriteLine("1. Inserisci un team");
	Console.WriteLine("2. Inserisci un giocatore");
	Console.WriteLine("3. Trova il giocatore per nome");
	Console.WriteLine("4. Trova il giocatore per ID");
	Console.WriteLine("5. Modifica il nome e cognome");
	Console.WriteLine("6. Cancella un giocatore");
	Console.WriteLine("7. Esci");

	int userAnswer = int.Parse(Console.ReadLine());

	switch (userAnswer)
	{
		case 1:
			break;
		case 2:
			Console.Write("Aggiungi il nome del giocatore da aggiungere: ");
			string playerNameChosen = Console.ReadLine();

			Console.Write("Aggiungi il cognome del giocatore da aggiungere: ");
			string playerSurnameChosen = Console.ReadLine();

			Console.WriteLine("Inserisci l'id del team a cui appartiene il giocatore: ");
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
			Console.Write("Scrivi il nome dei giocatori che vuoi cercare: ");
			string playerNameToSearch = Console.ReadLine();

			using (PlayerContext db = new PlayerContext())
			{
				List<Player> playersToFind = db.Player.Where(playerScansionato => playerScansionato.PlayerName.Contains(playerNameToSearch)).ToList<Player>();
				foreach(Player playerScansionato in playersToFind)
				{
					Console.WriteLine(playerScansionato.ToString());
				}
			}
			break;

		case 4:
			Console.Write("Scrivi l'id del giocatore che vuoi cercare: ");
			int playerIdToSearch = int.Parse(Console.ReadLine());

			using (PlayerContext db = new PlayerContext())
			{
				Player playerToFindWithId = db.Player.Where(playerScans => playerScans.PlayerId.Equals(playerIdToSearch)).First();
				Console.WriteLine(playerToFindWithId.ToString());
			}
			break;

		case 5:
			Console.WriteLine("Scrivi l'id del giocatore di cui vuoi cambiare nome e cognome");
			int playerIdToChange = int.Parse(Console.ReadLine());

			using (PlayerContext db = new PlayerContext())
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
			break;

		case 6:
			Console.Write("Scrivi l'id del giocatore che vuoi cancellare: ");
			int playerIdToDelete = int.Parse(Console.ReadLine());

			using (PlayerContext db = new PlayerContext())
			{
				Player playerToDelete = db.Player.Where(playerScan => playerScan.PlayerId.Equals(playerIdToDelete)).First();

				Console.WriteLine("Ok, hai rimosso il giocatore");
				db.Player.Remove(playerToDelete);
				db.SaveChanges();

			}
			break;

		case 7:
			Console.WriteLine("Ok, va bene, buonagiornata!");
			userWantsToContinue = false;
			break;
	}
}
