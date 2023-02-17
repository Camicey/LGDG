public class Carte
{

    public string? Statut {get; set;}
    public string? Role {get; set;}
    public string Nom {get; set;}
    public double PM { get; set; }
    public int PV { get; set; }
    public int? PVar {get; set;}
    public int PA { get; set; }
    

    public Carte(string nom, string role, double pM, int pV, int pA)
    {
        if (role == "Stratege") Statut = "Decouvert";
        else Statut = "Cache";
        Role = role;
        Nom = nom;
        PM = pM;
        PV = pV;
        PA = pA;
        PVar = pV;
    }
    public Carte(string nom)
    {
        Statut = "Decouvert";
        Nom = nom;
        PA = 0;
        PV = 0;
        PVar = 0;
        PM = 0;
    }

/*
    public override string ToString()
    {
        string decrire = "";

        if (Statut == "Decouvert")
        {
            decrire = $"Cette carte {Nom} a {PM} PM, {PVar} PV et {PA} PA ";
        }
        else 
            decrire = "Cette carte est cachée";
        return decrire;
    }

*/

    public override string ToString()
    {

        string decrire = "\n" + $"Cette carte {Nom} a {PM} PM, {PVar} PV et {PA} PA " + "\n";

        return decrire;
    }


    public void Attaquer(int degat)
    {
        PVar = PVar - degat;
        Statut = "Decouvert";
    }

    public void Soigner(int soin)
    {
        PVar = PVar + soin;
    }


}