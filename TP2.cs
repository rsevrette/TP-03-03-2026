using System;
using System.Collections.Generic;

	/* 1/ On affiche Alice car c est une struct ainsi on copie personne p1 dans p2, et modifier p2 ne veut pas dire modifier p1, ainsi on affiche p1 qui retourne Alice
       2/ On affiche True parce que l’élément de la liste n’est pas modifié : on a seulement modifié une copie du livre, pas le livre original dans la liste.
	   3/ Avec une class, on affiche False : copie et élément de la liste pointent vers le même objet, donc modifier la copie modifie aussi l’original.
	   4/ Ecrire livre.Pages = -200 n'est pas cohérent car on peut pas avoir un livre avec un nombre de pages négatif
	   5/ 
	*/
	

public class Program
{
    class Livre 
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

        Livre l1 = new Livre();
        l1.Titre = "Livre A";
        l1.Auteur = "jacques";
        l1.Annee = 2010;
        l1.Pages = 1;
        l1.EstDisponible = true;
        Livres.Add(l1);

        Livre l2 = new Livre();
        l2.Titre = "Livre B";
        l2.Auteur = "ouill";
        l2.Annee = 2;
        l2.Pages = 999999;
        l2.EstDisponible = true;
        Livres.Add(l2);

        Livre l3 = new Livre();
        l3.Titre = "Livre C";
        l3.Auteur = "la fripouille";
        l3.Annee = 55;
        l3.Pages = 80;
        l3.EstDisponible = false;
        Livres.Add(l3);

        Livre copie = Livres[0];
        copie.EstDisponible = false;

        Console.WriteLine(Livres[0].EstDisponible);
    }
}


