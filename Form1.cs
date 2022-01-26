using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeterminantCalculator
{
    public partial class Form1 : Form
    {
        const int INPUT_FIELD_WIDTH = 40;
        const int INPUT_FIELD_HEIGHT = 26;
        const int DEFUALT_TOP_MARGIN = 50;
        const int PADDING = 10;
        public Panel elementsPanel;
        public TextBox[,] elementsTextBoxes;
        public Button calculateButton;
        public Label resultLabel;
        public double[,] elements;
        public int matrixSize;
        public Form1()
        {
            InitializeComponent();

            for (int i = 2; i <= 10; ++i)
            {
                sizeSelector.Items.Add(i);
            }
            sizeSelector.SelectedItem = 3;
        }

        private void SizeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            matrixSize = (int)sizeSelector.SelectedItem;
            Controls.Remove(elementsPanel);
            Controls.Remove(calculateButton);
            Controls.Remove(resultLabel);
            Controls.Remove(elementsPanel);
            elementsTextBoxes = new TextBox[matrixSize, matrixSize];
            if (matrixSize > 2)
            {
                this.Size = new Size(
                matrixSize * INPUT_FIELD_WIDTH + (matrixSize + 3) * PADDING,
                (matrixSize + 5) * INPUT_FIELD_HEIGHT + (matrixSize + 1) * PADDING + DEFUALT_TOP_MARGIN
                );
            }
            else
            {
                this.Size = new Size(
                3 * INPUT_FIELD_WIDTH + (3 + 3) * PADDING,
                (3 + 5) * INPUT_FIELD_HEIGHT + (3 + 1) * PADDING + DEFUALT_TOP_MARGIN
                );
            }
            elementsPanel = new Panel
            {
                Size = new Size(
                        matrixSize * INPUT_FIELD_WIDTH + (matrixSize + 1) * PADDING,
                        matrixSize * INPUT_FIELD_HEIGHT + (matrixSize + 1) * PADDING
                ),
                Location = new Point(0, DEFUALT_TOP_MARGIN)
            };
            Controls.Add(elementsPanel);

            //Debug.WriteLine(matrixSize);
            elements = new double[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; ++i)
            {
                for (int j = 0; j < matrixSize; ++j)
                {
                    TextBox t = new TextBox
                    {

                        Font = new Font("Microsoft Sans Serif", 12),
                        Text = "0",
                        Size = new Size(INPUT_FIELD_WIDTH, INPUT_FIELD_HEIGHT),
                        Location = new Point(
                            PADDING * (j + 1) + INPUT_FIELD_WIDTH * j,
                            PADDING * (i + 1) + INPUT_FIELD_HEIGHT * i)
                    };
                    elementsTextBoxes[i, j] = t;
                    t.KeyPress += ElementTextBox_KeyPress;

                    t.Leave += ElementTextBox_Leave;
                    Debug.WriteLine(t.Location);
                    elementsPanel.Controls.Add(t);
                }
            }
            calculateButton = new Button
            {
                Size = new Size(100, 26),
                Text = "Calculate",
                Location = new Point(this.Size.Width - 130, this.Size.Height - 130)
            };
            calculateButton.Click += CalculateButtonClick;
            Controls.Add(calculateButton);

            resultLabel = new Label
            {
                Size = new Size(100, 26),
                Location = new Point(this.Size.Width - 130, this.Size.Height - 94),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleCenter
            };
            
            Controls.Add(resultLabel);
        }

        private void ElementTextBox_Leave(object sender, EventArgs e)
        {
            if((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "0";
            }
        }

        private void CalculateButtonClick(object sender, EventArgs e)
        {
            for(int i = 0; i < matrixSize; ++i)
            {
                for (int j = 0; j < matrixSize; ++j)
                {
                    elements[i, j] = double.Parse(elementsTextBoxes[i, j].Text);
                }
            }
            double determinant = MatrixMethods.Determinant(elements);
            resultLabel.Text = determinant.ToString();
        }
        private void ElementTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.Contains('.')))
            {
                e.Handled = true;
            }
        }
    }
}
