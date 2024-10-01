using System;
using System.IO;

using System;
using System.IO;

int nbnodes = 0;
char[,] matrix = new char[100, 100]; // On s’autorise 100 nœuds maximum
string myfile = "quatre.txt"; // Par exemple, en plaçant le fichier un.txt dans le dossier /bin/debug

// Vérifier si le fichier existe
if (File.Exists(myfile))
{
    // Création d'une instance de StreamReader pour permettre la lecture du fichier
    using (StreamReader monStreamReader = new StreamReader(myfile))
    {
        string ligne = monStreamReader.ReadLine();
        if (ligne != null)
        {
            nbnodes = Convert.ToInt32(ligne); // Lire le nombre de nœuds du graphe
        }

        // Initialiser la matrice à '0'
        for (int i = 0; i < nbnodes; i++)
        {
            for (int j = 0; j < nbnodes; j++)
            {
                matrix[i, j] = '0'; // Initialiser à « 0 »
            }
        }

        // Lire les relations
        while ((ligne = monStreamReader.ReadLine()) != null) // Tant qu’il reste des lignes dans le fichier
        {
            int x = Convert.ToInt32(ligne); // Lire la coordonnée x
            ligne = monStreamReader.ReadLine();
            if (ligne == null) break; // Vérification de sécurité
            int y = Convert.ToInt32(ligne); // Lire la coordonnée y
            ligne = monStreamReader.ReadLine();
            if (ligne == null) break; // Vérification de sécurité

            // Assigner 'd' ou 'b' à la matrice
            matrix[x, y] = ligne[0]; // On s'attend à ce que ce soit « d » ou « b »
        }
    } // Fermeture automatique du StreamReader
}
else
{
    Console.WriteLine("Le fichier n'existe pas.");
}


// char[,] matrix = new char[3, 3];
// matrix[0, 1] = 'b';
// matrix[1, 2] = 'b';


void AfficherMatrice(char[,] matrice)
{
    for (int i = 0; i < matrice.GetLength(0); i++)
    {
        for (int j = 0; j < matrice.GetLength(1); j++)
        {
            if (matrice[i, j] == 'b' || matrice[i, j] == 'd')
            {
                Console.Write(matrice[i, j] + " "); // Affiche les caractères sur la même ligne
            }
            else
            {
                Console.Write('0' + " ");
            }
        }
        Console.WriteLine(); // Passe à la ligne suivante après chaque ligne de la matrice
    }
}
// AfficherMatrice(matrix);

bool IsExtremityGoingDown(int n, char[,] matrix)
{
    int cptb = 0;
    int cptd = 0;

    // Compter les 'b' et 'd' dans la ligne n
    for (int i = 0; i < nbnodes; i++)
    {
        if (matrix[n, i] == 'b') cptb++;
        if (matrix[n, i] == 'd') cptd++;
    }

    int cptb2 = 0;
    int cptd2 = 0;

    // Compter les 'b' et 'd' dans la colonne n
    for (int i = 0; i < nbnodes; i++)
    {
        if (matrix[i, n] == 'b') cptb2++;
        if (matrix[i, n] == 'd') cptd2++;
    }

    // Vérifier la condition
    return ((cptb == 1) && (cptd == 0) && (cptb2 == 0) && (cptd2 == 0));
}

// Console.WriteLine(IsExtremityGoingDown(1, matrix));

bool ExtremiteGauche(int n, char[,] matrix)
{
    int cptb = 0;
    int cptd = 0;

    // Compter les 'b' et 'd' dans la ligne n
    for (int i = 0; i < nbnodes; i++)
    {
        if (matrix[n, i] == 'b') cptb++;
        if (matrix[n, i] == 'd') cptd++;
    }

    int cptb2 = 0;
    int cptd2 = 0;

    // Compter les 'b' et 'd' dans la colonne n
    for (int i = 0; i < nbnodes; i++)
    {
        if (matrix[i, n] == 'b') cptb2++;
        if (matrix[i, n] == 'd') cptd2++;
    }
    return ((cptd == 1) && (cptb == 0) && (cptb2 == 0) && (cptd2 == 0));
}

int CompteExtremiteDown(char[,] matrix)
{
    int cpt = 0;
    for (int i = 0; i < nbnodes; i++)
    {
        if (IsExtremityGoingDown(i, matrix)) cpt++;
    }
    return cpt;
}

void TrouverChiffre(char[,] matrix)
{
    if (CompteExtremiteDown(matrix) == 2)
    {
        Console.WriteLine("It's a 4");
    }
    //Pour le 5

}
// TrouverChiffre(matrix);