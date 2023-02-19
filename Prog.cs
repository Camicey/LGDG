/*


int gagnant = 1;

int joueur = 1;
string action = "";

int attaquant;
int attaque;

Carte Attaquant;
Carte Attaque;
*/

//Mes petites variables
string state = "Jouer";
string intraState = "Jouer";
int tour = 0;

Joueur QuiJoue;
Joueur QuiJouePas;

//Je créer les joueurs et les terrains pour tout le monde
Terrain T0 = new Terrain();
Terrain T1 = new Terrain();
Terrain T2 = new Terrain();

Joueur LaMort = new Joueur("La Mort", 0, T0);
Joueur J1 = new Joueur("Camille", 1, T1);
Joueur J2 = new Joueur("Nicolas", 2, T2);

Game G = new Game(J1, J2); // Ton jeu est initialisé

G.InitialiserCartes(); //Crée les cartes et les mets dans un tableau
G.Distribuer(); 
G.Commencer(J1); //Stratège joueur 1
G.Commencer(J2);

while (state == "Jouer")
{
    QuiJoue = J1;
    QuiJouePas = J2;
    intraState = "Jouer";

    tour++;

    if (tour % 2 == 0) 
    {
        QuiJoue = J2;
        QuiJouePas = J1;
    }

    while (intraState == "Jouer") intraState = G.Choix(QuiJoue, QuiJouePas);
    
    Console.WriteLine();
}





