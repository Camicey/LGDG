public class Joueur
{
    public string Nom {get; set;}
    public int Num {get;set;}
    public Terrain Tapis {get;set;}
    public List<Carte> dansMain {get; set;}
    
    public Joueur(string nom, int num, Terrain terrain)
    {
        Num = num;
        Nom = nom;
        Tapis = terrain;
        dansMain = new List<Carte>();
    }

    public void Ajouter (Carte card)
    {
        dansMain.Add(card);
    }

    public void Retirer (Carte card)
    {
        dansMain.Remove(card);
    }

    public override string ToString()
    {
        string decrire = "";
        Console.WriteLine($"Voici les cartes que toi, joueur {Num} tu as dans ta main");
        foreach (Carte card in dansMain)
        {
            decrire = decrire + card.Nom + ", ";
        }
        return decrire;
    }
    
}