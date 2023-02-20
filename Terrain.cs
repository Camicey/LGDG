public class Terrain
{
    Carte rien0 = new Carte("Place 0    ");
    Carte rien1 = new Carte("Place 1    ");
    Carte rien2 = new Carte("Place 2    ");
    public Carte[] banc {get; set;}

    //public Carte Stratege {get; set;}

    public Terrain()
    {
        banc = new Carte[3];
        banc[0] = rien0;
        banc[1] = rien1;
        banc[2] = rien2;
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
        decrire = decrire + $"    {banc[1].Nom}     {banc[2].Nom}     " + "\n"+ "\n";
        decrire = decrire + $"             {banc[0].Nom}        " + "\n";
        return decrire;
    }

    public string Inverse()
    {
        string decrire = "";

        decrire = "\n";
        decrire = decrire + $"             {banc[0].Nom}        " + "\n \n";
        decrire = decrire + $"    {banc[1].Nom}     {banc[2].Nom}     " + "\n";
        
        return decrire;
    }
}