using CE205_HW3.libs;

namespace CE205_HW3
{
    public partial class Form1 : Form
    {

        private Microsoft.Msagl.Drawing.Graph _graphObject;

        private const int _MAX_RANDOM = 10;
        private const int _MIN_RANDOM = 5;

        int[,] _graphArray;

        // Instantiate random number generator.  
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private void ArrayToGraph(int[,] graphArray, ref Microsoft.Msagl.Drawing.Graph graphObject)
        {
            for (int i = 0; i < graphArray.GetLength(0); i++)
            {
                for (int j = 0; j < graphArray.GetLength(1); j++)
                {

                    if (graphArray[i, j] > 0)
                    {
                        string fromNode = Util.GetNodeLetter(i);
                        string toNode = Util.GetNodeLetter(j);
                        string weight = graphArray[i, j].ToString();
                        graphObject.AddEdge(fromNode, weight, toNode).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                    }
                }
            }
        }

        private void ResetGraph()
        {
            _graphObject = new Microsoft.Msagl.Drawing.Graph("graph");

            ArrayToGraph(_graphArray, ref _graphObject);

            gViewer1.Graph = _graphObject;

            gViewer1.Refresh();
        }

        private void RandomGraphGenerate()
        {
            //int[][] a = new int[2][4];  // Two rows and four columns.

            //a[0][0] a[0][1] a[0][2] a[0][3]
            //a[1][0] a[1][1] a[1][2] a[1][3]

            int vertexSize = RandomNumber(_MIN_RANDOM, _MAX_RANDOM);

            _graphArray = new int[vertexSize, vertexSize];

            //rows
            for (int i = 0; i < _graphArray.GetLength(0); i++)
            {
                //columns
                for (int j = i; j < _graphArray.GetLength(1) - i; j++)
                {

                    if (i == j)
                        continue;

                    int weight = RandomNumber(0, 10);

                    _graphArray[i, j] = weight;
                    _graphArray[j, i] = weight;
                }
            }

            //_graphArray = new int[,] { { 0, 2, 0, 6, 0 },
            //                          { 2, 0, 3, 8, 5 },
            //                          { 0, 3, 0, 0, 7 },
            //                          { 6, 8, 0, 0, 9 },
            //                          { 0, 5, 7, 9, 0 } };

            ResetGraph();
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //_graphObject.AddEdge("A", "B");
            //_graphObject.AddEdge("B", "C");
            //_graphObject.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            //_graphObject.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            //_graphObject.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            //Microsoft.Msagl.Drawing.Node c = _graphObject.FindNode("C");
            //c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            //c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            ////bind the graph to the viewer 
            //gViewer1.Graph = _graphObject;

            //gViewer1.Refresh();
        }

        private void btnRandomGraphGenerate_Click(object sender, EventArgs e)
        {
            RandomGraphGenerate();

        }
        private void btnSolve_Click(object sender, EventArgs e)
        {
            if(rdBtnMstAlgorithm.Checked)
            {

                ResetGraph();

                //MST Algorithm
                MST mst = new MST();

                mst.primMST(_graphArray,chkBoxClearNodes.Checked,ref _graphObject);

                gViewer1.Graph = _graphObject;

                gViewer1.Refresh();

            }
            else if(rdBtnBfsAlgorithm.Checked)
            {
                MessageBox.Show("50 points if you implement","Good Luck",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
            else if(rdBtnDfsAlgorithm.Checked)
            {
                MessageBox.Show("50 points if you implement", "Good Luck", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rdBtnSccAlgorithm.Checked)
            {
                MessageBox.Show("50 points if you implement", "Good Luck", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rdBtnTopologicalOrder.Checked)
            {
                MessageBox.Show("50 points if you implement", "Good Luck", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnResetGraph_Click(object sender, EventArgs e)
        {
            ResetGraph();
        }


    }
}