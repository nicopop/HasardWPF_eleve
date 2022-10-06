using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Piece piece;
        private readonly De6 de6;

        private readonly Dictionary<int, Lancer> _lancers;

        public MainWindow()
        {
            InitializeComponent();

            PieceMonnaie.MouseLeftButtonDown += OnPieceMonnaieLeftButtonDown;
            De6Faces.MouseLeftButtonDown += OnDe6FacesLeftButtonDown;

            piece = new Piece();
            de6 = new De6();

            _lancers = new Dictionary<int, Lancer>();
        }

        private void OnPieceMonnaieLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _lancers[_lancers.Count + 1] = new Lancer(piece, piece.Lancer());
            MonnaieLbl.Content = _lancers[_lancers.Count].Face.Nom;

            Debug.Assert((string)MonnaieLbl.Content == "pile" || (string)MonnaieLbl.Content == "face");
            AfficherLancers();
        }

        private void OnDe6FacesLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _lancers[_lancers.Count + 1] = new Lancer(de6, de6.Lancer());
            De6Lbl.Content = _lancers[_lancers.Count].Face.Nom;

            AfficherLancers();
        }

        private void AfficherLancers()
        {
            string lancersStr = "";
            int maxvalue = 0;
            int comptede = 0;
            int comptepiece = 0;
            int comptePile = 0;
            int compteFace = 0;
            foreach (KeyValuePair<int, Lancer> element in _lancers)
            {
                lancersStr += $"Lancer {element.Key}: {element.Value.Objet.Nom} -> {element.Value.Face.Nom}\n";
                if(element.Value.Objet.Nom == "Dé 6") 
                { 
                    comptede++;
                    if (element.Value.Face.Valeur == element.Value.Objet.NbFaces)
                    {
                        maxvalue++;
                    }
                } 
                else if(element.Value.Objet.Nom == "Pièce")
                { 
                    comptepiece++; 
                    if(element.Value.Face.Nom == "pile") { comptePile++; } else { compteFace++; }
                }
            }
            //Si apres 10 lancer on a pas eu max ya peutetre un problème (le 10 peut etre changer)
            if(comptede > 10)
            {
                Debug.Assert(maxvalue > 0);
            }
            if(comptepiece > 10)
            {
                Debug.Assert(comptePile > 0 && compteFace > 0);
            }
            LancersTB.Text = lancersStr;
        }
    }
}
