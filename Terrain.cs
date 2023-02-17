public class Terrain
{
    Carte rien0 = new Carte("Place 0 ");
    Carte rien1 = new Carte("Place 1    ");
    public Carte[] banc {get; set;}

    public Carte Stratege{get; set;}

    public Terrain()
    {
        banc = new Carte[2];
        banc[0] = rien0;
        banc[1] = rien1;
        
        Stratege = rien0;
    }

    public void Ajouter (Carte card, int position)
    {
        banc[position] = card;
    }

    public void Retirer (Carte card, int position)
    {
        if (position == 1) banc[position] = rien1;
        else banc[position] = rien0;
    }

    public override string ToString()
    {
        string decrire = "";

        decrire = "\n";
        decrire = decrire + $"    {banc[0].Nom}     {banc[1].Nom}     " + "\n"+ "\n";
        decrire = decrire + $"          {Stratege.Nom}        " + "\n";
        return decrire;
    }


}