using EntityFrameworkPlayers;

bool userWantsToContinue = true;
while (userWantsToContinue)
{
	Console.WriteLine("Seleziona un'opzione: ");
	Console.WriteLine("1. Inserisci un team");
	Console.WriteLine("2. Inserisci un giocatore");
	Console.WriteLine("3. Trova il giocatore per nome");
	Console.WriteLine("4. Modifica il nome e/o cognome");
	Console.WriteLine("5. Cancella un giocatore");
	Console.WriteLine("6. Esci");

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

			// Creo il giocatore
			Player newPlayer = new Player(playerNameChosen, playerSurnameChosen);
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
			}
				break;
		case 4:
			break;
		case 5:
			Console.WriteLine("Ok, va bene, buonagiornata!");
			userWantsToContinue = false;
			break;
	}
}
