using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace micropcgame.Presentation.Fenetre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class C_SELECTION_FOURNISSEUR : Window
    {
        public C_SELECTION_FOURNISSEUR()
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

        private void ME_Acadia_Loaded(object sender, RoutedEventArgs e)
        {
            // Récupérer la bordure parent du MediaElement
            var mediaElement = sender as MediaElement;
            var border = mediaElement.Parent as Border;

            if ( border != null )
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var cornerRadius = border.CornerRadius.TopLeft; // Prend le rayon de coin du style de bordure
                    var adjustedRadius = cornerRadius + 6; // Ajuste le rayon des coins (ajuste la valeur selon tes besoins)

                    // Crée un RectangleGeometry avec un rayon de coin ajusté
                    var clipGeometry = new RectangleGeometry
                    {
                        RadiusX = adjustedRadius,
                        RadiusY = adjustedRadius,
                        Rect = new Rect(0, 0, border.ActualWidth, border.ActualHeight)
                    };

                    // Applique le clip au MediaElement
                    mediaElement.Clip = clipGeometry;

                    // Met à jour le RectangleGeometry lorsque la taille de la bordure change
                    border.SizeChanged += (s, ev) =>
                    {
                        clipGeometry.Rect = new Rect(0, 0, border.ActualWidth, border.ActualHeight);
                    };
                }), System.Windows.Threading.DispatcherPriority.Loaded);
            }

            ME_Acadia.Play();
        }

        private void ME_Acadia_MediaEnded(object sender, RoutedEventArgs e)
        {
            // Réinitialiser la position de lecture au début de la vidéo
            ME_Acadia.Position = TimeSpan.Zero;

            // Rejouer la vidéo
            ME_Acadia.Play();
        }

        private void ME_JensMobile_Loaded(object sender, RoutedEventArgs e)
        {
            // Récupérer la bordure parent du MediaElement
            var mediaElement = sender as MediaElement;
            var border = mediaElement.Parent as Border;

            if ( border != null )
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var cornerRadius = border.CornerRadius.TopLeft; // Prend le rayon de coin du style de bordure
                    var adjustedRadius = cornerRadius + 6; // Ajuste le rayon des coins (ajuste la valeur selon tes besoins)

                    // Crée un RectangleGeometry avec un rayon de coin ajusté
                    var clipGeometry = new RectangleGeometry
                    {
                        RadiusX = adjustedRadius,
                        RadiusY = adjustedRadius,
                        Rect = new Rect(0, 0, border.ActualWidth, border.ActualHeight)
                    };

                    // Applique le clip au MediaElement
                    mediaElement.Clip = clipGeometry;

                    // Met à jour le RectangleGeometry lorsque la taille de la bordure change
                    border.SizeChanged += (s, ev) =>
                    {
                        clipGeometry.Rect = new Rect(0, 0, border.ActualWidth, border.ActualHeight);
                    };
                }), System.Windows.Threading.DispatcherPriority.Loaded);
            }

            ME_JensMobile.Play();
        }

        private void ME_JensMobile_MediaEnded(object sender, RoutedEventArgs e)
        {
            // Réinitialiser la position de lecture au début de la vidéo
            ME_JensMobile.Position = TimeSpan.Zero;

            // Rejouer la vidéo
            ME_JensMobile.Play();
        }

        private void ME_Acadia_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Stop les video 
            ME_Acadia.Stop();
            ME_JensMobile.Stop();

            // Ouvre la fenetre pour les devis acadia 
            var Creation_Devis_Acadia = new C_CREATION_DEVIS_ACADIA();
            Creation_Devis_Acadia.Show();

            // Ferme la fenetre C_SELECTION_FOURNISSEUR
            this.Close();

        }

        private void ME_JensMobile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Stop les video 
            ME_Acadia.Stop();
            ME_JensMobile.Stop();

            // Ouvre la fenetre pour les devis acadia 
            var Creation_Devis_Jens_Mobile = new C_CREATION_DEVIS_JENS_MOBILE();
            Creation_Devis_Jens_Mobile.Show();

            // Ferme la fenetre C_SELECTION_FOURNISSEUR
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Ajuster_Taille_Fenetre_Avec_Marge();
        }

        private void Ajuster_Taille_Fenetre_Avec_Marge()
        {
            double largeur = 800; // Largeur fixe
            double hauteur = 450; // Hauteur fixe

            var screenLargeur = SystemParameters.PrimaryScreenWidth;
            var screenHauteur = SystemParameters.PrimaryScreenHeight;

            // Calculer la position centrée avec marges
            double left = ( screenLargeur - largeur ) / 2;
            double top = ( screenHauteur - hauteur ) / 2;

            // Appliquer les dimensions et la position
            this.Width = largeur;
            this.Height = hauteur;
            this.Left = Math.Max(0, left); // Ne pas dépasser le bord gauche
            this.Top = Math.Max(0, top); // Ne pas dépasser le bord supérieur

            // Optionnel : Éviter de dépasser les bords de l'écran
            if ( this.Left + this.Width > screenLargeur )
            {
                this.Left = screenLargeur - this.Width;
            }
            if ( this.Top + this.Height > screenHauteur )
            {
                this.Top = screenHauteur - this.Height;
            }
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