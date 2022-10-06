using System;
using System.Diagnostics;

namespace DeWPF
{
    // Un objet de hasard
    public class ObjetHasard : IObjetHasard
    {
        protected static readonly Random rnd = new Random();

        public string Nom { get; }

        public Face[] Faces { get; }

        public int NbFaces => Faces.Length;

        public ObjetHasard(string nom, int nbFaces)
        {
            Nom = nom;
            Faces = new Face[nbFaces];
            CreerFaces();
        }

        protected virtual void CreerFaces()
        {
            int valeur;
            for (valeur = 1; valeur <= NbFaces; valeur++)
            {
                Faces[valeur-1] = new Face(valeur, valeur.ToString());
            }
            Debug.Assert(valeur == NbFaces + 1);
        }

        public Face Lancer()
        {
            return Faces[rnd.Next(NbFaces)];
        }
    }
}
