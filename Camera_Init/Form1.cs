// Touts les namespaces utilisés pour ce code.
// Un namespace est une boîte à outil dans lequel tout le code nécessaire sera retrouvé.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using AForge.Imaging;


// Le nom du namespace privé qui a été créé.
namespace Camera_Init
{
    // Classe d'objet partielle déclarée sous type de Form
    // Un Form est tout ce qui est élément graphique du code (boutons, retour vidéo, fenêtre, etc.)
    public partial class Form1 : Form
    {

        // Initialisation du Form pour le créer lors du lancement du code.
        public Form1()
        {
            // méthode pour initialiser l'application
            InitializeComponent();
        }

        // Création d'objets variables de deux types:

        //FilterInfoColletion: "variable de type informations sur la collection du filtre" le filtre qui va chercher pour trouver l'appareil de capture vidéo.
        //VideoCaptureDevice: "variable de type Appareil de capture vidéo" la caméra utilisée pour l'execution du code.
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;


        // défintion d'une méthode privée sans valeur retourner et qui prend comme argument un objet qui va être utilisé comme messager et une variable de type NouvelleFrameParEvenement nommé eventArgs (le détecteur d'un évenement)
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // On accede à la variable Image dans la classe de CameraFeedBack
            CameraFeedBack.Image = (Bitmap)eventArgs.Frame.Clone();
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Initialisation du filtre de la collecte d'informations
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cboCamera.Items.Add(filterInfo.Name);
            }
            cboCamera.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
            {
                videoCaptureDevice.Stop();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void FrameCapture_Click(object sender, EventArgs e)
        {
            Bitmap resim = new Bitmap(CameraFeedBack.Image);

            EuclideanColorFiltering filter = new EuclideanColorFiltering();
            // set center color and radius
            filter.CenterColor = new RGB(245, 245, 220);
            filter.Radius = 250;
            // apply the filter
            
            //filter.ApplyInPlace(resim);

            CameraFeedBack.Image = resim;
            Color x = resim.GetPixel(300, 300);

            videoCaptureDevice.Stop();
            GetMostUsedColor(resim);

            labelColor();
            ColorDetection();



        }


        


        public static List<Color> TenMostUsedColors { get; private set; }
        public static List<int> TenMostUsedColorIncidences { get; private set; }

        public static Color MostUsedColor { get; private set; }
        public static int MostUsedColorIncidence { get; private set; }

        private static int pixelColor;

        private static Dictionary<int, int> dctColorIncidence;

        public static void GetMostUsedColor(Bitmap theBitMap)
        {
            TenMostUsedColors = new List<Color>();
            TenMostUsedColorIncidences = new List<int>();

            MostUsedColor = Color.Empty;
            MostUsedColorIncidence = 0;

            // does using Dictionary<int,int> here
            // really pay-off compared to using
            // Dictionary<Color, int> ?

            // would using a SortedDictionary be much slower, or ?

            dctColorIncidence = new Dictionary<int, int>();

            // this is what you want to speed up with unmanaged code
            for (int row = 0; row < theBitMap.Size.Width; row++)
            {
                for (int col = 0; col < theBitMap.Size.Height; col++)
                {
                    pixelColor = theBitMap.GetPixel(row, col).ToArgb();

                    if (dctColorIncidence.Keys.Contains(pixelColor))
                    {
                        dctColorIncidence[pixelColor]++;
                    }
                    else
                    {
                        dctColorIncidence.Add(pixelColor, 1);
                    }
                }
            }

            // note that there are those who argue that a
            // .NET Generic Dictionary is never guaranteed
            // to be sorted by methods like this
            var dctSortedByValueHighToLow = dctColorIncidence.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            // this should be replaced with some elegant Linq ?
            foreach (KeyValuePair<int, int> kvp in dctSortedByValueHighToLow.Take(10))
            {
                TenMostUsedColors.Add(Color.FromArgb(kvp.Key));
                TenMostUsedColorIncidences.Add(kvp.Value);
            }

            MostUsedColor = Color.FromArgb(dctSortedByValueHighToLow.First().Key);
            MostUsedColorIncidence = dctSortedByValueHighToLow.First().Value;
        }

        

        private void labelColor()
        {
            labelColorResult.Text = MostUsedColor.ToString();
        }

        Color black = Color.Black;

        private void ColorDetection()
        {
            if(MostUsedColor == black)
            {
                label1.Text = "BLACK DETECTED";
            }
            else
            {
                label1.Text = "BLACK NOT DETECTED";
            }
        }
        
    }

}
