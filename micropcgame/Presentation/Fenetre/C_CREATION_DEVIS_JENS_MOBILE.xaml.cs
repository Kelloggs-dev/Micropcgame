using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace micropcgame.Presentation.Fenetre
{
    /// <summary>
    /// Logique d'interaction pour C_CREATION_DEVIS_JENS_MOBILE.xaml
    /// </summary>
    public partial class C_CREATION_DEVIS_JENS_MOBILE : Window
    {
        public C_CREATION_DEVIS_JENS_MOBILE()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        private void BTN_Close_Window_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BTN_Minimize_Windows_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Mouve_Window_By_Mouse(object sender, MouseButtonEventArgs e)
        {
            if ( e.ChangedButton == MouseButton.Left )
            {
                DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Ajuster_Taille_Fenetre_Avec_Marge();
        }

        private void Ajuster_Taille_Fenetre_Avec_Marge()
        {
            double marge = 30; // Marge en pixels

            // Obtenir les dimensions de l'écran
            var screenLargeur = SystemParameters.PrimaryScreenWidth;
            var screenHauteur = SystemParameters.PrimaryScreenHeight;

            // Calculer la taille de la fenêtre
            this.Left = marge;
            this.Top = marge;
            this.Width = screenLargeur - 2 * marge;
            this.Height = screenHauteur - 2 * marge;
        }

        private void BTN_Back_Windows_Click(object sender, RoutedEventArgs e)
        {
            var Selection_Fournisseur = new C_SELECTION_FOURNISSEUR();
            Selection_Fournisseur.Show();

            this.Close();
        }

        private void BTN_Fullscreen_Click(object sender, RoutedEventArgs e)
        {
            if ( WindowState == WindowState.Normal )
            {
                // Passer en plein écran
                this.WindowState = WindowState.Maximized;

            } else
            {
                // Quitter le plein écran
                this.WindowState = WindowState.Normal;

                // Ajuster la taille de la fenêtre avec une marge
                Ajuster_Taille_Fenetre_Avec_Marge();
            }
        }

    }
}
