using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamagochi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            init_game();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void init_game()
        {
            new Settings();
            init_scale(lblEatCar, lblEatMax, Settings.eat);
            init_scale(lblSleepCar, lblSleepMax, Settings.sleep);
            init_scale(lblClearCar, lblClearMax, Settings.clear);
            init_scale(lblHPCar, lblHPMax, Settings.HP);
            init_scale(lblHappyCar, lblHappyMax, Settings.happy);
        }

        private void init_scale(Label lbl_car, Label lbl_max, Scale scale)
        {
            lbl_car.Text = scale.current_value.ToString();
            lbl_max.Text = scale.max_value.ToString();
        }

        private Scale add_value(int add_value, Scale scale)
        {
            scale.current_value += add_value;
            if (scale.current_value >scale.max_value)
            {
                scale.current_value = scale.max_value;
            }
            return scale;
        }

        private Scale dif_value(int dif_value, Scale scale)
        {
            scale.current_value -= dif_value;
            if(scale.current_value < 0)
            {
                scale.current_value = 0;
            }
            return scale;
        }

        private bool is_die()
        {
            int cur_life = (int)(0.25 * Settings.eat.current_value +
                0.25 * Settings.sleep.current_value +
                0.25 * Settings.clear.current_value +
                0.25 * Settings.happy.current_value);
            Settings.HP.current_value = cur_life;

            if (Settings.HP.current_value == 0
                || Settings.eat.current_value == 0
                || Settings.sleep.current_value == 0
                || Settings.happy.current_value == 0
                || Settings.clear.current_value == 0)
            {
                return true;
            }

            return false;
        }
        private void get_scales()
        {
            lblClearCar.Text = Settings.clear.current_value.ToString();
            lblEatCar.Text = Settings.eat.current_value.ToString();
            lblHappyCar.Text = Settings.happy.current_value.ToString();
            lblHPCar.Text = Settings.HP.current_value.ToString();
            lblSleepCar.Text = Settings.sleep.current_value.ToString();
        }

        private bool eating()
        {
            Settings.eat = add_value(Settings.add, Settings.eat);
            Settings.clear = dif_value(Settings.dif, Settings.clear);
            Settings.sleep = dif_value(Settings.dif, Settings.clear);

            //bool is_dead = is_die();
            //return is_dead;

            return is_die();
        }


        private void game_over_actions()
        {
            pbImage.BackgroundImage = Properties.Resources.die;
            lblGameOver.Visible = true;
            btnClear.Enabled = false;
            btnEat.Enabled = false;
            btnHappy.Enabled = false;
            btnSleep.Enabled = false;
        }

        private void btnEat_Click(object sender, EventArgs e)
        {
            bool is_die = eating();
            get_scales();
            if (is_die)
            {
                game_over_actions();
            }

        }

        private void btnSleep_Click ( object sender, EventArgs e)
        {
            bool is_die = eating();
            get_scales();
            if(is_die)
            {
                game_over_actions();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            bool is_die = eating();
            get_scales();
            if (is_die)
            {
                game_over_actions();
            }
        }
    }
}
