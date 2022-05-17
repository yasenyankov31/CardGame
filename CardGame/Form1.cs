using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Form1 : Form
    {
        private List<Color> colors =new List<Color>{Color.Red, Color.Red , Color.Green, Color.Green,
            Color.Blue, Color.Blue, Color.Cyan, Color.Cyan, Color.Orange, Color.Orange,Color.Yellow,Color.Yellow,Color.Purple,Color.Purple,Color.Pink,Color.Pink }.OrderBy(a => Guid.NewGuid()).ToList();
        public Image card = Properties.Resources.aviator_blue_back__2_;


        public List<Button> selectedButtons = new List<Button>();
        public int done = 8;

        public Form1()
        {
            InitializeComponent();
            PrepareCards();
        }
        private void CardClickEvent(Button button)
        {
            if (button.Name != "done" && !selectedButtons.Any(x => x.Name == button.Name))
            {

                if (done == 1)
                {
                    button17.Visible = true;
                    label1.Visible = true;
                }

                if (selectedButtons.Count == 2)
                {
                    var colors = selectedButtons.Select(x => x.BackColor).ToList();
                    if (!(colors.Count > 0 && !colors.Any(x => x != colors.First())))
                    {
                        selectedButtons.Select(x => { x.Image = card; return x; }).ToList();
                        selectedButtons.Clear();

                    }
                    else
                    {
                        selectedButtons.Select(x => { x.Name = "done"; return x; }).ToList();
                        selectedButtons.Clear();
                        CardClickEvent(button);
                        done--;

                    }

                }
                else
                {
                    selectedButtons.Add(button);
                    button.Image = null;
                }


            }

        }

        public void PrepareCards()
        {
            List<Button> buttons = this.Controls.OfType<Button>().ToList();
            buttons.Remove(buttons.First());
            int i = 0;
            foreach (var button in buttons)
            {
                button.Image = card;
                button.BackColor= colors[i];
                button.Click += (sender, args) => CardClickEvent(button);
                i++;

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            PrepareCards();
            button17.Visible = false;
            label1.Visible = false;
        }
    }
}
