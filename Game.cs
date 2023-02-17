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
        J1.Ajouter(cartesDispo[2]);
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
        joueur.Tapis.Stratege =  joueur.dansMain[carteEnAttente - 1]; //On place le stratège sur le terrain
        joueur.dansMain.Remove(joueur.Tapis.Stratege); //Retirons le stratège de sa main
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


    public string Choix(Joueur joueur) 
    {
        string intraState = "Jouer";
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
                //Deplace une carte
                break;

            case "Attaquer":
                Console.WriteLine($"Quel carte est responsable de l'attaque ?");
                int carte1 = Convert.ToInt32(Console.ReadLine()!);
                Console.WriteLine($"Quel carte {""} attaque-t-elle ?");
                int carte2 = Convert.ToInt32(Console.ReadLine()!);
                //Attaque(carte1,carte2);
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

    

    /*
    void Attaque(int attaquant, int attaque)
    {
        
        int degat = carteAttaquant.PA;
        carteAttaquee.Attaquer(degat);

        if (carteAttaquee.PV >= 0)
        {
            Console.WriteLine($"La carte {CarteAttaquee} a encore {CarteAttaquee.PV} PV et elle réplique !");
            carteAttaquant.Attaquer(carteAttaquee.PA);
            Console.WriteLine($"La carte {CarteAttaquant} possède {CarteAttaquant.PV} PV maintenant.");
        }
        else CarteAttaquee va dans pioche des morts
        

    }
    */

    void Placer(int carteAttente, int placeTerrain, Joueur J)
    {
        J.Tapis.banc[placeTerrain] = J.dansMain[carteAttente - 1];
        J.Retirer(J.dansMain[carteAttente - 1]);
    }


    void RetirerCarte(int placeTerrain, Joueur J)
    {
        
        if (placeTerrain == 0) 
        {
            J.Ajouter(J.Tapis.banc[placeTerrain]); //Ajouter la carte dans sa main
            Console.WriteLine($"Vous avez retiré la carte {J.Tapis.banc[placeTerrain].Nom}");
            J.Tapis.banc[placeTerrain] = cartesDispo[0] ;
        }
        else 
        {
            J.Ajouter(J.Tapis.banc[placeTerrain]);
            Console.WriteLine($"Vous avez retiré la carte {J.Tapis.banc[placeTerrain].Nom} \n");
            J.Tapis.banc[placeTerrain] = cartesDispo[1];
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
            Console.WriteLine("Voulez vous les informations de votre stratège ? (O/N)");
            string ouiNon = Console.ReadLine()!;
            if (ouiNon == "O") Console.WriteLine(joueur.Tapis.Stratege);
            else 
            { 
                Console.WriteLine(joueur.Tapis);
                int placeTerrainInfo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(joueur.Tapis.banc[placeTerrainInfo]);
            }
            
        }
        
        
    }



    
}