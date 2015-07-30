using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Media;


namespace TwoZeroFourEight
{

    /// <summary>
    /// 2048 Game
    /// </summary>
    ///        

    public partial class MainWindow : Window
    {

        public Label[,] labels { get; set; }
        public int[,] intsar = new int[4, 4];
        static List<int> intListItems = new List<int>();
        Random rand = new Random();
       
        public MainWindow()
        {
            InitializeComponent();
            labels = new Label[4, 4]{ 
                                {tb00,tb10,tb20,tb30},
                                {tb01,tb11,tb21,tb31},
                                {tb02,tb12,tb22,tb32},
                                {tb03,tb13,tb23,tb33},
                              };

        }


        private void BindArrayToLabel()
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (intsar[i, j] != 0)
                    {
                        labels[i, j].Content = intsar[i, j];
                    }
                    else
                    {
                        labels[i, j].Content = "";
                    }
                }
            }

        }


        public void SetInitials()
        {
            intListItems.Clear();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (intsar[i, j] == 0)
                    {
                        intListItems.Add(i * 4 + j + 1);
                    }
                }
            }

            if (intListItems.Count > 0)
            {

                int chiSoHinh = intListItems[rand.Next(0, intListItems.Count - 1)];
                int i0 = (chiSoHinh - 1) / 4;
                int j0 = (chiSoHinh - 1) - i0 * 4;
                int NgauNhien = rand.Next(1, 10);
                if (NgauNhien == 1 || NgauNhien == 2 || NgauNhien == 3 || NgauNhien == 4 || NgauNhien == 5 || NgauNhien == 6)
                {
                    intsar[i0, j0] = 2;
                }
                else
                {
                    intsar[i0, j0] = 4;
                }

            }
            setColors();
        }
        public void setColors()
        {
            BindArrayToLabel();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if (intsar[i, j] == 0)
                    {
                        labels[i, j].Background = Brushes.SkyBlue;
                    }
                    if (intsar[i, j] == 2)
                    {
                        labels[i, j].Background = Brushes.DarkKhaki;
                        labels[i, j].Foreground = Brushes.GreenYellow;
                    }
                    if (intsar[i, j] == 4)
                    {
                        labels[i, j].Background = Brushes.DarkGray;
                        labels[i, j].Foreground = Brushes.White;
                    }
                    if (intsar[i, j] == 8)
                    {
                        labels[i, j].Background = Brushes.Indigo;
                        labels[i, j].Foreground = Brushes.White;
                    }
                    if (intsar[i, j] == 16)
                    {
                        labels[i, j].Background = Brushes.Black;
                        labels[i, j].Foreground = Brushes.White;
                    }
                    if (intsar[i, j] == 32)
                    {
                        labels[i, j].Background = Brushes.Yellow;
                        labels[i, j].Foreground = this.Background;
                    }
                    if (intsar[i, j] == 64)
                    {
                        labels[i, j].Background = Brushes.Green;
                        labels[i, j].Foreground = Brushes.White;
                    }
                    if (intsar[i, j] == 128)
                    {
                        labels[i, j].Background = Brushes.Olive;
                        labels[i, j].Foreground = Brushes.White;
                    }
                    if (intsar[i, j] == 256)
                    {
                        labels[i, j].Background = Brushes.Gold;
                        labels[i, j].Foreground = Brushes.White;
                    }
                    if (intsar[i, j] == 512)
                    {
                        labels[i, j].Background = Brushes.DarkOrange;
                        labels[i, j].Foreground = Brushes.White;
                    }
                    if (intsar[i, j] == 1024)
                    {
                        labels[i, j].Background = Brushes.Orange;
                        labels[i, j].Foreground = this.Background;
                    }
                    if (intsar[i, j] == 2048)
                    {
                        labels[i, j].Background = Brushes.OrangeRed;
                        labels[i, j].Foreground = this.Background;
                    }
                    if (intsar[i, j] == 4096)
                    {
                        labels[i, j].Background = Brushes.Navy;
                        labels[i, j].Foreground = this.Background;

                    }
                    if (intsar[i, j] == 8192)
                    {
                        labels[i, j].Background = Brushes.Maroon;
                        labels[i, j].Foreground = Brushes.Yellow;
                    }
                }
            }

        }

        public bool checkStart
        {
            get
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (intsar[i, j] == 0)
                        {
                            return false;
                        }
                        for (int k = j + 1; k < 4; k++)
                        {
                            if (intsar[i, j] != 0)
                            {
                                if (intsar[i, j] == intsar[i, k])
                                {
                                    return false;
                                }
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (intsar[j, i] == 0)
                        {
                            return false;
                        }
                        for (int k = j + 1; k < 4; k++)
                        {
                            if (intsar[k, i] != 0)
                            {
                                if (intsar[j, i] == intsar[k, i])
                                {
                                    return false;
                                }
                                break;
                            }
                        }
                    }
                }
                return true;
            }
        }


        public void UpKey()
        {
            bool upKeyCan = true;
            bool areEqual = false;
            bool canProc = false;

            for (int i = 0; i < 4; i++)
            {
                int iNndx = 0;
                for (int j = 0; j < 4; j++)
                {
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (intsar[k, i] != 0)
                        {
                            if (intsar[k, i] == intsar[j, i])
                            {
                                areEqual = true;
                            }
                            break;
                        }
                    }
                    if (intsar[j, i] == 0)
                    {
                        iNndx++;
                    }
                    else
                    {
                        for (int m = j; m >= 0; m--)
                        {
                            if (intsar[m, i] == 0)
                            {
                                canProc = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool ktra = true;

                            for (int k = j + 1; k < 4; k++)
                            {
                                if (intsar[k, i] != 0)
                                {
                                    if (intsar[j, i] == intsar[k, i])
                                    {
                                        upKeyCan = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + intsar[j, i] * 2).ToString();
                                        canProc = true;
                                        ktra = false;
                                        intsar[j, i] = intsar[j, i] * 2;
                                        if (iNndx != 0)
                                        {
                                            intsar[j - iNndx, i] = intsar[j, i];
                                            intsar[j, i] = 0;

                                        }
                                        intsar[k, i] = 0;
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (ktra == true && iNndx != 0)
                            {
                                upKeyCan = false;
                                intsar[j - iNndx, i] = intsar[j, i];
                                intsar[j, i] = 0;

                            }
                        }
                        else
                        {
                            if (iNndx != 0)
                            {
                                upKeyCan = false;
                                intsar[j - iNndx, i] = intsar[j, i];
                                intsar[j, i] = 0;

                            }
                        }


                    }
                }
            }
            if (upKeyCan == false && areEqual == true)
            {
                 System.Media.SystemSounds.Hand.Play();;
            }
            if (upKeyCan == false && areEqual == false)
            {
                System.Media.SystemSounds.Exclamation.Play();
            }
            if (canProc == true)
            {
                SetInitials();
            }
        }
        public void DownKey()
        {
            bool downKeyCan = true;
            bool areEqual = false;
            bool canProc = false;

            for (int i = 0; i < 4; i++)
            {
                int iNndx = 0;
                for (int j = 3; j >= 0; j--)
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (intsar[k, i] == 0)
                        {
                            if (intsar[k, i] == intsar[j, i])
                            {
                                areEqual = true;
                            }
                            break;
                        }
                    }
                    if (intsar[j, i] == 0)
                    {
                        iNndx++;
                    }
                    else
                    {
                        for (int m = j + 1; m <= 3; m++)
                        {
                            if (intsar[m, i] == 0)
                            {
                                canProc = true;
                                break;
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            bool ktra = true;

                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (intsar[k, i] != 0)
                                {
                                    if (intsar[j, i] == intsar[k, i])
                                    {
                                        downKeyCan = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + (intsar[j, i] * 2)).ToString();
                                        canProc = true;
                                        ktra = false;
                                        intsar[j, i] = intsar[j, i] * 2;
                                        if (iNndx != 0)
                                        {
                                            intsar[j + iNndx, i] = intsar[j, i];
                                            intsar[j, i] = 0;

                                        }
                                        intsar[k, i] = 0;
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (ktra == true && iNndx != 0)
                            {
                                downKeyCan = false;
                                intsar[j + iNndx, i] = intsar[j, i];
                                intsar[j, i] = 0;

                            }
                        }
                        else
                        {
                            if (iNndx != 0)
                            {
                                downKeyCan = false;
                                intsar[j + iNndx, i] = intsar[j, i];
                                intsar[j, i] = 0;

                            }
                        }


                    }
                }
            }
            if (downKeyCan == false && areEqual == true)
            {
                 System.Media.SystemSounds.Hand.Play();;
            }
            if (downKeyCan == false && areEqual == false)
            {
                System.Media.SystemSounds.Exclamation.Play();
            }
            if (canProc == true)
            {
                SetInitials();
            }
        }
        public void LeftKey()
        {
            bool LeftKeyCan = true;
            bool areEqual = false;
            bool canProc = false;

            for (int i = 0; i < 4; i++)
            {
                int iNndx = 0;
                for (int j = 0; j < 4; j++)
                {

                    for (int k = j + 1; k < 4; k++)
                    {
                        if (intsar[i, k] != 0)
                        {
                            if (intsar[i, j] == intsar[i, k])
                            {
                                areEqual = true;
                            }
                            break;
                        }
                    }
                    if (intsar[i, j] == 0)
                    {
                        iNndx++;
                    }
                    else
                    {
                        for (int m = j - 1; m >= 0; m--)
                        {
                            if (intsar[i, m] == 0)
                            {
                                canProc = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool ktra = true;

                            for (int k = j + 1; k < 4; k++)
                            {
                                if (intsar[i, k] != 0)
                                {

                                    if (intsar[i, j] == intsar[i, k])
                                    {
                                        LeftKeyCan = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + (intsar[i, j] * 2)).ToString();
                                        canProc = true;
                                        ktra = false;
                                        intsar[i, j] = intsar[i, j] * 2;
                                        if (iNndx != 0)
                                        {
                                            intsar[i, j - iNndx] = intsar[i, j];
                                            intsar[i, j] = 0;

                                        }
                                        intsar[i, k] = 0;
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (ktra == true && iNndx != 0)
                            {
                                LeftKeyCan = false;
                                intsar[i, j - iNndx] = intsar[i, j];
                                intsar[i, j] = 0;

                            }
                        }
                        else
                        {
                            if (iNndx != 0)
                            {
                                LeftKeyCan = false;
                                intsar[i, j - iNndx] = intsar[i, j];
                                intsar[i, j] = 0;

                            }
                        }


                    }
                }
            }
            if (LeftKeyCan == false && areEqual == true)
            {
                System.Media.SystemSounds.Hand.Play();

            }
            if (LeftKeyCan == false && areEqual == false)
            {
                System.Media.SystemSounds.Exclamation.Play();
            }
            if (canProc == true)
            {
                SetInitials();
            }
        }
        public void RightKey()
        {
            bool rightKeyCan = true;
            bool areEqual = false;
            bool canProc = false;

            for (int i = 0; i < 4; i++)
            {
                int iNndx = 0;
                for (int j = 3; j >= 0; j--)
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (intsar[i, k] != 0)
                        {
                            if (intsar[i, k] == intsar[i, j])
                            {
                                areEqual = true;
                            }
                            break;
                        }
                    }
                    if (intsar[i, j] == 0)
                    {
                        iNndx++;
                    }
                    else
                    {
                        for (int m = j + 1; m < 4; m++)
                        {
                            if (intsar[i, m] == 0)
                            {
                                canProc = true;
                                break;
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            bool ktra = true;

                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (intsar[i, k] != 0)
                                {


                                    if (intsar[i, j] == intsar[i, k])
                                    {
                                        rightKeyCan = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + (intsar[i, j] * 2)).ToString();
                                        canProc = true;
                                        ktra = false;
                                        intsar[i, j] = intsar[i, j] * 2;
                                        if (iNndx != 0)
                                        {
                                            intsar[i, j + iNndx] = intsar[i, j];
                                            intsar[i, j] = 0;

                                        }
                                        intsar[i, k] = 0;
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (ktra == true && iNndx != 0)
                            {
                                rightKeyCan = false;
                                intsar[i, j + iNndx] = intsar[i, j];
                                intsar[i, j] = 0;

                            }
                        }
                        else
                        {
                            if (iNndx != 0)
                            {
                                rightKeyCan = false;
                                intsar[i, j + iNndx] = intsar[i, j];
                                intsar[i, j] = 0;

                            }
                        }
                    }
                }
            }
            if (rightKeyCan == false && areEqual == true)
            {
                 System.Media.SystemSounds.Hand.Play();;
            }
            if (rightKeyCan == false && areEqual == false)
            {
                System.Media.SystemSounds.Exclamation.Play();
            }
            if (canProc == true)
            {
                SetInitials();
            }
        }



        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.KeyDown += new KeyEventHandler(Window_KeyDown);
            lblScore.Text = "0";

            lblGameOver.Visibility = Visibility.Hidden;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    intsar[i, j] = 0;
                }
            }
            SetInitials();
            SetInitials();
            SetInitials();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetInitials();
            SetInitials();
            SetInitials();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (!checkStart)
            {
                if (e.Key == Key.Up)
                {
                    UpKey();

                }
                if (e.Key == Key.Down)
                {
                    DownKey();

                }
                if (e.Key == Key.Left)
                {
                    LeftKey();

                }
                if (e.Key == Key.Right)
                {
                    RightKey();

                }
            }
            else
            {
                lblGameOver.Text = "[[Game Over]]";

                lblGameOver.Visibility = Visibility.Visible;

                this.KeyDown -= new KeyEventHandler(Window_KeyDown);

            }
        }
    }
}
