using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.ML;
using Point = OpenCvSharp.Point;

namespace WinformOpenCV
{
    public partial class MLP : Form
    {
        private const int V = 1;

        public MLP()
        {
            InitializeComponent();
        }

        private void MLP_Load(object sender, EventArgs e)
        {
            ANN_MLP bp = ANN_MLP.Create();
            int[] value0 = { 0, 0 };
            int[] value1 = { 1, 1 };
            int[,] labels = new int[,] { { 0, 0 }, { 0, 0 }, { 1, 1 }, { 1, 1 } };
            Mat labelsMat = new Mat(4, 2, MatType.CV_32FC1, labels);
            int[,] trainingData = new int[4, 2] { { 186, 80 }, { 185, 81 }, { 160, 50 }, { 161, 48 } };

            Mat layerSizes = new Mat<int>(1, 4, new[] { 2, 2, 2, 2 });
            bp.SetLayerSizes(layerSizes);
            bp.SetActivationFunction(ANN_MLP.ActivationFunctions.SigmoidSym);
            bp.SetTrainMethod(ANN_MLP.TrainingMethods.BackProp, param1: 0.1, 0.1);
            Mat mat =new Mat(4,2, MatType.CV_32FC1);
            bp.Train(labelsMat, SampleTypes.RowSample, mat);
            Mat sample= new Mat<int>(1, 2, new[] { 184,79 });
            Mat response= new Mat(1, 2, MatType.CV_32FC1);
            bp.Predict(sample, response);
            Point minLoc = new Point();
            Point maxLoc = new Point();
            Cv2.MinMaxLoc(response, out minLoc, out maxLoc);
            if (maxLoc.X==0)
            {

            }
        }
    }
}
