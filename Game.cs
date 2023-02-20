public class Game
{
    public Joueur J1 {get; set;}
    public Joueur J2 {get;set;}

    public Terrain T1 {get; set;}
    public Terrain T2 {get;set;}
    public List<Carte> dansMain {get; set;}
    public List<Carte> cartesDispo {get; set;}

    public int carteEnAttente {get; set;}
    
    public Game(Joueur j1, Joueur j2)
    {
        J1 = j1;
        J2 = j2;
        T1 = J1.Tapis;
        T2 = J2.Tapis;
        dansMain = new List<Carte>();
        cartesDispo = new List<Carte>();
        carteEnAttente = -1;
    }


    public override string ToString()
    {
        string decrire = "";
        return decrire;
    }
    
    public void InitialiserCartes()
    {
        //Je crée les cartes vides
        cartesDispo.Add(new Carte("Place 0 "));
        cartesDispo.Add(new Carte("Place 1 "));
        cartesDispo.Add(new Carte("Place 2 "));
        cartesDispo.Add(new Carte("Ji Ling", "Stratege", 4, 10, 20));
        cartesDispo.Add(new Carte("Sol", "Attaque", 3, 30, 10));
        cartesDispo.Add(new Carte("Sosara", "Attaque", 3,10,25));
        cartesDispo.Add(new Carte("Vivalie", "Stratege", 3, 30, 5));
        cartesDispo.Add(new Carte("Lié", "Attaque", 2, 15, 15));
        cartesDispo.Add(new Carte ("Siana", "Attaque", 1, 20,20));
    }

    public void Distribuer() //On distribue les cartes au hasard, Non finie
    {
        //On distribue les cartes au hasard
        
        J1.Ajouter(cartesDispo[6]);
        J1.Ajouter(cartesDispo[7]);
        J1.Ajouter(cartesDispo[8]);
        J2.Ajouter(cartesDispo[3]);
        J2.Ajouter(cartesDispo[4]);
        J2.Ajouter(cartesDispo[5]);
        
    }

    public void Commencer(Joueur joueur) //On fait les terrains avec stratège
    {
        Console.WriteLine(joueur);

        //Donner la possibilité au joueur de voir ses cartes et de choisir quand choisir son stratège

        Console.WriteLine($"Joueur 1, qui sera ton stratège ? Marque la place du personnage");
        carteEnAttente = Convert.ToInt32(Console.ReadLine()); //On lit le numéro qu'on nous donne
        joueur.Tapis.banc[0]=  joueur.dansMain[carteEnAttente - 1]; //On place le stratège sur le terrain
        joueur.dansMain.Remove(joueur.Tapis.banc[0]); //Retirons le stratège de sa main
        Console.WriteLine(joueur.Tapis);

        //Joueur 1 choisit son stratège, enlève le stratège de sa main et le place sur le terrain

    }

    /*
    void Commencer2() //Le début du joueur 2
    {
        Console.WriteLine(J2);
        Console.WriteLine($"Joueur 2, qui sera ton stratège ? Marque la place du personnage");
        carteEnAttente = Convert.ToInt32(Console.ReadLine());
        T2.Stratege = J2.dansMain[carteEnAttente - 1];
        J2.dansMain.Remove(T2.Stratege);
        Console.WriteLine(T2);
    }
    */


    public string Choix(Joueur joueur, Joueur adversaire) 
    {
        string intraState = "Jouer";

        JeVeuxVoir(joueur,adversaire);

        Console.WriteLine($"Vous êtes face à un choix joueur {joueur.Nom}, que voulez faire ?");
        Console.WriteLine($"- Placer une carte (Placer)"); 
        Console.WriteLine($"- Retirer une carte (Retirer)"); 
        Console.WriteLine($"- Déplacer une carte (Deplacer)"); 
        Console.WriteLine($"- Faire attaquer une carte (Attaquer)");
        Console.WriteLine($"- Voir les information d'une carte (Info)");
        Console.WriteLine($"- Finir votre tour (Fin)");

        Console.Write($"Vous avez PM, Votre action : ");
        string action = Console.ReadLine()!;

        switch(action)
        {
            case "Placer":
                Placement(joueur); //Ca marche
                break;

            case "Retirer":
                Console.WriteLine(joueur.Tapis);
                Console.WriteLine($"Quel est le placement de la carte que tu veux retirer ?");
                int carteRetire = Convert.ToInt32(Console.ReadLine()!);
                RetirerCarte(carteRetire, joueur);
                break;

            case "Deplacer":
                Console.WriteLine($"Veux tu opérer à un échange de carte ?");
                string echange = Console.ReadLine()!;
                Deplacer(joueur, adversaire, echange);
                break;

            case "Attaquer":
                
                Attaque(joueur, adversaire);
                break;

            case "Info":
                //Information sur le personnage
                Console.WriteLine($"Voulez vous avoir des informations sur les personnages de votre plateau ou de votre main ?");
                string MainOuPlateau = Console.ReadLine()!;
                switch(MainOuPlateau) 
                {
                    case "Main":
                        AvoirDesInfos(joueur, "Main");
                        break;
                    case "Plateau":
                        AvoirDesInfos(joueur, "Plateau");
                        break;

                    default:
                        break;
                }
                break;

            case "Fin":
                intraState = "Stop";
                break;

            default : 
                Console.WriteLine($"Je n'ai pas compris ce que vous voulez faire");
                break;
        }

        return intraState;

    }


    public void Placement(Joueur joueur) // Pour placer les cartes, tout fonctionnel. Il manque les avertissements juste
    {

            Console.WriteLine(joueur);
            carteEnAttente = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(joueur.Tapis);
            int placeTerrain = Convert.ToInt32(Console.ReadLine());
            
            if (carteEnAttente != -1 && placeTerrain != -1) 
            {
                Placer(carteEnAttente, placeTerrain, joueur);
                Console.WriteLine(joueur.Tapis);
            }
                
    }

    

    
    void Attaque(Joueur J, Joueur Adverse)
    {
        Carte carteAttaquant = cartesDispo[0];
        Carte carteVictime = cartesDispo[0];
        int attaquant = 0;
        int victime = 0;
        string ouiNon = "N";
        
        JeVeuxVoir(J, Adverse);

        while (carteAttaquant == cartesDispo[0])
        {
            Console.WriteLine($"Quel carte est responsable de l'attaque ?");
            attaquant = Convert.ToInt32(Console.ReadLine()!);
            Console.Write("La carte attaquant est sur la ligne adverse ? (O/N) ");
            ouiNon = Console.ReadLine()!;
            if (J.Tapis.banc[attaquant].Perso == "Non") Console.WriteLine("Il n'y a personne ici");  
            else if (ouiNon == "N") carteAttaquant = J.Tapis.banc[attaquant];
            else  carteAttaquant = Adverse.Tapis.banc[attaquant];
        }
        
        while (carteVictime == cartesDispo[0])
        {
            Console.WriteLine($"Quel carte {carteAttaquant} attaque-t-elle ?");
            victime = Convert.ToInt32(Console.ReadLine()!);
            Console.Write("La carte attaquée est sur la ligne adverse ? (O/N) ");
            ouiNon = Console.ReadLine()!;
            if (ouiNon == "O")  carteVictime = Adverse.Tapis.banc[victime];
            else  carteVictime = J.Tapis.banc[victime];
        }
        carteVictime.Attaquer(carteAttaquant.PA);

        if (carteVictime.PVar > 0)
        {
            Console.WriteLine();
            Console.WriteLine($"La carte {carteAttaquant.Nom} inflige {carteAttaquant.PA} dégât à {carteVictime.Nom}");
            Console.WriteLine($"La carte {carteVictime.Nom} a encore {carteVictime.PVar} PV et elle réplique !");
            carteAttaquant.Attaquer(carteVictime.PA);
            Console.WriteLine($"La carte {carteAttaquant.Nom} ne possède que {carteAttaquant.PVar} PV.");
        }
        else 
        {
            Console.WriteLine($"La carte {carteAttaquant.Nom} inflige {carteAttaquant.PA} dégât à {carteVictime.Nom}");
            Console.WriteLine();
            Console.WriteLine($"Le personnage {carteVictime.Nom} est mort");
            Console.WriteLine();
            if (ouiNon == "N")  J.Tapis.banc[victime] = cartesDispo[victime];
            else Adverse.Tapis.banc[victime] = cartesDispo[victime];
            

        }
        

    }


    void Placer(int carteAttente, int placeTerrain, Joueur J)
    {
        J.Tapis.banc[placeTerrain] = J.dansMain[carteAttente - 1];
        J.Retirer(J.dansMain[carteAttente - 1]);
    }


    void RetirerCarte(int placeTerrain, Joueur J)
    {
        if (J.Tapis.banc[placeTerrain].Nom == cartesDispo[placeTerrain].Nom) Console.WriteLine($"Vous n'avez aucune carte ici");
        else 
        { 
            J.Ajouter(J.Tapis.banc[placeTerrain]); //Ajouter la carte dans sa main
            Console.WriteLine();
            Console.WriteLine($"Vous avez retiré la carte {J.Tapis.banc[placeTerrain].Nom}");
            Console.WriteLine();
            J.Tapis.banc[placeTerrain] = cartesDispo[placeTerrain] ; // Pour remplacer la carte avec Place 0/1
        }
    }

    void Deplacer(Joueur J, Joueur adversaire, string choix)
    {
        if (choix == "O") // A la question "Pour un échange"
        {
            Console.WriteLine(J.Tapis);
            Console.Write("Qui voulez vous échanger ?   ");
            int echange1 = Convert.ToInt32(Console.ReadLine());
            int echange2 = Convert.ToInt32(Console.ReadLine());
            Carte retenir = J.Tapis.banc[echange2];
            J.Tapis.banc[echange2] = J.Tapis.banc[echange1];
            J.Tapis.banc[echange1] = retenir; 
        }
        else 
        {
            Console.WriteLine(J.Tapis);
            Console.Write("Qui voulez vous déplacer ?   ");
            int persoABouger = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Sur les lignes adverses ? (O/N) ");
            string adverses = Console.ReadLine()!;
            if (adverses == "O") 
            {
                Console.WriteLine(adversaire.Tapis.Inverse()); //Ecrire le plateau à l'enver
                Console.WriteLine($"Où voulez vous déplacer {J.Tapis.banc[persoABouger].Nom} ?");
                int ouBougerLePerso = Convert.ToInt32(Console.ReadLine());
                adversaire.Tapis.banc[ouBougerLePerso] = J.Tapis.banc[persoABouger]; //On met le perso là où il est sensé être
                J.Tapis.banc[persoABouger] = cartesDispo[persoABouger]; //On effface la trace du perso

                JeVeuxVoir(J, adversaire);
                
            }
            else
            {
                Console.WriteLine(J.Tapis);
                Console.WriteLine($"Où voulez vous déplacer {J.Tapis.banc[persoABouger].Nom} ?");
                int ouBougerLePerso = Convert.ToInt32(Console.ReadLine());
                J.Tapis.banc[ouBougerLePerso] = J.Tapis.banc[persoABouger];
                J.Tapis.banc[persoABouger] = cartesDispo[persoABouger]; 

                Console.WriteLine(J.Tapis);
            }
            
            
        }
    }

    void AvoirDesInfos(Joueur joueur, string choix)
    {
        if (choix == "Main")
        {
            Console.WriteLine(joueur);
            int carteInfo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(joueur.dansMain[carteInfo - 1]);
        }
        if (choix == "Plateau")
        {
                Console.WriteLine(joueur.Tapis);
                int placeTerrainInfo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(joueur.Tapis.banc[placeTerrainInfo]);
            
        }
        
        
    }

    public void JeVeuxVoir(Joueur J, Joueur adversaire) //Le visuel est important
    {
        Console.WriteLine();
        Console.WriteLine(adversaire.Tapis.Inverse());
        Console.WriteLine(J.Tapis);
        Console.WriteLine();
    }



    
}