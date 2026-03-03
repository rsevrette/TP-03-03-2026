using System;
using System.Collections.Generic;

public class Program
{
    struct Livre
	{
		public string Titre;
		public string Auteur;
		public int Annee;
		public int Pages;
		public bool EstDisponible;      
	}

    
    static void Main(string[] args)
    {
        List<Livre> Livres = new List<Livre>();
        
		Livre l1;
		l1.Titre = "Livre A";
		l1.Auteur = "jacques";
		l1.Annee = 2010;
		l1.Pages = 1;
		l1.EstDisponible = true;
		Livres.Add(l1);

		Livre l2;
		l2.Titre = "Livre B";
		l2.Auteur = "ouill";
		l2.Annee = 2;
		l2.Pages = 999999;
		l2.EstDisponible = true;
		Livres.Add(l2);

		Livre l3;
		l3.Titre = "Livre C";
		l3.Auteur = "la fripouille";
		l3.Annee = 55;
		l3.Pages = 80;
		l3.EstDisponible = false;
		Livres.Add(l3);

        
        int choix = 0;
        while (choix != 9)
		{
			Console.WriteLine("\nMenu :");
			Console.WriteLine("1. Afficher tous les livres");
			Console.WriteLine("2. Afficher les livres disponibles");
			Console.WriteLine("3. Afficher les livres avec +300 pages");
			Console.WriteLine("4. Afficher les livres publiés après 2000");
			Console.WriteLine("5. Afficher le total des pages");
			Console.WriteLine("6. Afficher le total des livres dispo");
			Console.WriteLine("7. Rechercher un livre par titre");
			Console.WriteLine("8. emprunter un livre");
			Console.WriteLine("9. Quitter");

			choix = int.Parse(Console.ReadLine());

			switch (choix)
			{
				case 1:
					afficherLivre(Livres);
					break;

				case 2:
					afficherLivredispo(Livres);
					break;

				case 3:
					afficherLivrePage(Livres);
					break;

				case 4:
					afficherLivreAnnee(Livres);
					break;

				case 5:
					TotalPages(Livres);
					break;
				
				case 6:
					TotalLivreDispo(Livres);
					break;
					
				case 7:
					RechercherLivre(Livres);
					break;
					
				case 8:
					emprunter(Livres);
					break;

				case 9:
					Console.WriteLine("Au revoir !");
					break;
					
				default:
					Console.WriteLine("Option invalide.");
					break;
			}
		}
    }
    
    static void afficherLivre(List<Livre> livres){
        foreach(var l in livres)
        {        
            Console.WriteLine(l.Auteur + ", " + l.Annee + ", " + l.Pages + ", " + l.EstDisponible);
        }
	}
	
	static void afficherLivredispo(List<Livre> livres){
		foreach(var l in livres)
        {       
			if (l.EstDisponible == true) {
				Console.WriteLine(l.Auteur + ", " + l.Annee + ", " + l.Pages + ", " + l.EstDisponible);
			}
        }
	}
	static void afficherLivrePage(List<Livre> livres){
		foreach(var l in livres)
        {       
			if (l.Pages >= 300) {
				Console.WriteLine(l.Auteur + ", " + l.Annee + ", " + l.Pages + ", " + l.EstDisponible);
			}
        }
	}
	static void afficherLivreAnnee(List<Livre> livres){
		foreach(var l in livres)
        {       
			if (l.Annee >= 2000) {
				Console.WriteLine(l.Auteur + ", " + l.Annee + ", " + l.Pages + ", " + l.EstDisponible);
			}
        }
	}
	static void TotalPages(List<Livre> livres){
		int somme = 0;
		foreach(var l in livres)
		{        
			somme += l.Pages;
		}
		Console.WriteLine("Total des pages : " + somme);
	}
	static void TotalLivreDispo(List<Livre> livres){
		int somme = 0;
		foreach(var l in livres)
		{        
			if (l.EstDisponible == true)
			{
				somme += 1;
			}
		}
		Console.WriteLine("Total de livre dispo : " + somme);
	}
	static void RechercherLivre(List<Livre> livres)
	{
		Console.WriteLine("Entrez le titre du livre recherché :");
		string titreRecherche = Console.ReadLine();

		bool trouve = false;

		foreach (var l in livres)
		{
			if (l.Titre == titreRecherche)
			{
				Console.WriteLine("\nLivre trouvé :");
				Console.WriteLine("Titre : " + l.Titre);
				Console.WriteLine("Auteur : " + l.Auteur);
				Console.WriteLine("Année : " + l.Annee);
				Console.WriteLine("Pages : " + l.Pages);
				Console.WriteLine("Disponibilité : " + (l.EstDisponible ? "Disponible" : "Emprunté"));
				trouve = true;
			}
		}

		if (!trouve)
		{
			Console.WriteLine("Livre introuvable");
		}
	}
	static void emprunter(List<Livre> livres)
	{
		Console.WriteLine("Entrez le titre du livre à emprunter :");
		string titre = Console.ReadLine();

		bool trouve = false;

		for (int i = 0; i < livres.Count; i++)
		{
			if (livres[i].Titre == titre)
			{
				trouve = true;

				if (livres[i].EstDisponible)
				{
					Livre temporaires = livres[i];
					temporaires.EstDisponible = false;
					livres[i] = temporaires;   

					Console.WriteLine("Livre emprunté avec succès !");
					return;
				}
				else
				{
					Console.WriteLine("Ce livre est déjà emprunté.");
					return;
				}
			}
		}
		if (!trouve)
			Console.WriteLine("Livre introuvable.");
	}
}

/*

1/Une struct est un type qui contient directement ses données.Quand on la copie, on obtient une nouvelle valeur indépendante.
2/Une List est une collection qui peut grandir et qui permet de stocker plusieurs éléments du même type, comme une liste de livres.
3/foreach sert à parcourir tous les éléments d’une collection (comme une List) un par un, facilement.
4/Parce qu’une struct est copiée entièrement quand on l’affecte à une autre variable. Chaque copie est indépendante.

*/