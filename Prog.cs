/*


int gagnant = 1;


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
int joueur = 1;
Joueur QuiJoue;

//Je créer les joueurs et les terrains pour tout le monde
Terrain T0 = new Terrain();
Terrain T1 = new Terrain();
Terrain T2 = new Terrain();

Joueur LaMort = new Joueur("La Mort", 0, T0);
Joueur J1 = new Joueur("Camille", 1, T1);
Joueur J2 = new Joueur("Nicolas", 2, T2);

Game P = new Game(J1, J2); // Ton jeu est initialisé

P.InitialiserCartes(); //Crée les cartes et les mets dans un tableau
P.Distribuer(); 
P.Commencer(J1); //Stratège joueur 1

while (state == "Jouer")
{
    intraState = "Jouer";
    tour++;
    if (tour % 2 == 0) QuiJoue = J2;
        else QuiJoue = J1;

    while (intraState == "Jouer")
        intraState = P.Choix(QuiJoue);
    Console.WriteLine();
}





