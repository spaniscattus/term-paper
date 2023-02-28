using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;

namespace Pyatnawki
{
   

        internal class GameLogic
        {

            public Point[,] points;
            public int[,] pole;
            public int maxX;
            public int maxY;



            public int[,] GameMap(int x, int y)
            {
                int[,] pole = new int[x, y];
                int c = 1;
                for (int j = 0; j < y; j++)
                {
                    for (int i = 0; i < x; i++)
                    {
                        pole[i, j] = c;
                        c++;
                    }
                }
                pole[x - 1, y - 1] = 0;
                return pole;
            }
            public int MoveCell(Button button, int x, int y, int clics)
            {
                if (x != maxX && y != maxY)
                {
                    if (pole[x, y + 1] == 0)
                    {
                        MoveSmooth(button, x, y + 1);
                        (pole[x, y + 1], pole[x, y]) = (pole[x, y], pole[x, y + 1]);
                        clics++;
                        return clics;
                    }
                    if (pole[x, Math.Abs(y - 1)] == 0)
                    {
                        MoveSmooth(button, x, Math.Abs(y - 1));
                        (pole[x, Math.Abs(y - 1)], pole[x, y]) = (pole[x, y], pole[x, Math.Abs(y - 1)]);
                        clics++;
                        return clics;

                    }
                    if (pole[x + 1, y] == 0)
                    {
                        MoveSmooth(button, x + 1, y);
                        (pole[x + 1, y], pole[x, y]) = (pole[x, y], pole[x + 1, y]);
                        clics++;
                        return clics;
                    }
                    if (pole[Math.Abs(x - 1), y] == 0)
                    {
                        MoveSmooth(button, Math.Abs(x - 1), y);
                        (pole[Math.Abs(x - 1), y], pole[x, y]) = (pole[x, y], pole[Math.Abs(x - 1), y]);
                        clics++;
                        return clics;
                    }
                }
                else if (x == maxX && y != maxY)
                {
                    if (pole[x, y + 1] == 0)
                    {
                        MoveSmooth(button, x, y + 1);
                        (pole[x, y + 1], pole[x, y]) = (pole[x, y], pole[x, y + 1]);
                        clics++;
                        return clics;
                    }
                    if (pole[x, Math.Abs(y - 1)] == 0)
                    {
                        MoveSmooth(button, x, Math.Abs(y - 1));
                        (pole[x, Math.Abs(y - 1)], pole[x, y]) = (pole[x, y], pole[x, Math.Abs(y - 1)]);
                        clics++;
                        return clics;
                    }
                    if (pole[Math.Abs(x - 1), y] == 0)
                    {
                        MoveSmooth(button, Math.Abs(x - 1), y);
                        (pole[Math.Abs(x - 1), y], pole[x, y]) = (pole[x, y], pole[Math.Abs(x - 1), y]);
                        clics++;
                        return clics;

                    }
                }
                else if (x != maxX && y == maxY)
                {
                    if (pole[x, Math.Abs(y - 1)] == 0)
                    {
                        MoveSmooth(button, x, Math.Abs(y - 1));
                        (pole[x, Math.Abs(y - 1)], pole[x, y]) = (pole[x, y], pole[x, Math.Abs(y - 1)]);
                        clics++;
                        return clics;
                    }
                    if (pole[x + 1, y] == 0)
                    {
                        MoveSmooth(button, x + 1, y);
                        (pole[x + 1, y], pole[x, y]) = (pole[x, y], pole[x + 1, y]);
                        clics++;
                        return clics;
                    }
                    if (pole[Math.Abs(x - 1), y] == 0)
                    {
                        MoveSmooth(button, Math.Abs(x - 1), y);
                        (pole[Math.Abs(x - 1), y], pole[x, y]) = (pole[x, y], pole[Math.Abs(x - 1), y]);
                        clics++;
                        return clics;
                    }

                }
                else
                {
                    if (pole[x, Math.Abs(y - 1)] == 0)
                    {
                        MoveSmooth(button, x, Math.Abs(y - 1));
                        (pole[x, Math.Abs(y - 1)], pole[x, y]) = (pole[x, y], pole[x, Math.Abs(y - 1)]);
                        clics++;
                        return clics;
                    }
                    if (pole[Math.Abs(x - 1), y] == 0)
                    {
                        MoveSmooth(button, Math.Abs(x - 1), y);
                        (pole[Math.Abs(x - 1), y], pole[x, y]) = (pole[x, y], pole[Math.Abs(x - 1), y]);
                        clics++;
                        return clics;
                    }

                }
            
                return clics;
            

            }
            public void MoveSmooth(Button button, int x, int y)
            {
                int speed = 25;
                int timer = 1;
                if (button.Left < points[x, y].X)
                {
                    while (button.Left < points[x, y].X) { button.Left += speed; Thread.Sleep(timer); }
                    button.Location = points[x, y];
                    return;
                }
                if (button.Left > points[x, y].X)
                {
                    while (button.Left > points[x, y].X) { button.Left -= speed; Thread.Sleep(timer); }
                    button.Location = points[x, y];
                    return;
                }
                if (button.Top < points[x, y].Y)
                {
                    while (button.Top < points[x, y].Y) { button.Top += speed; Thread.Sleep(timer); }
                    button.Location = points[x, y];
                    return;
                }
                if (button.Top > points[x, y].Y)
                {
                    while (button.Top > points[x, y].Y) { button.Top -= speed; Thread.Sleep(timer); }
                    button.Location = points[x, y];
                    return;
                }

            }
            public void ShuffleGame(Button[,] button, int x, int y)
            {
                Random random = new Random();

                int fx = x - 1;
                int fy = y - 1;

                for (int i = 0; i < y * y; i++)
                {
                    for (int j = 0; j < x * x; j++)
                    {

                        int mover = random.Next(1, 5);
                        switch (mover)
                        {
                            case 1:
                                {
                                    if (fy > 0)
                                    {
                                        (button[fx, fy].Text, button[fx, fy - 1].Text) = (button[fx, fy - 1].Text, button[fx, fy].Text);
                                        fy -= 1;
                                    }

                                    break;
                                }
                            case 2:
                                {
                                    if (fy < y - 1)
                                    {
                                        (button[fx, fy].Text, button[fx, fy + 1].Text) = (button[fx, fy + 1].Text, button[fx, fy].Text);
                                        fy += 1;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    if (fx > 0)
                                    {
                                        (button[fx, fy].Text, button[fx - 1, fy].Text) = (button[fx - 1, fy].Text, button[fx, fy].Text);
                                        fx -= 1;
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    if (fx < x - 1)
                                    {
                                        (button[fx, fy].Text, button[fx + 1, fy].Text) = (button[fx + 1, fy].Text, button[fx, fy].Text);
                                        fx += 1;
                                    }
                                    break;
                                }

                        }

                    }
                }

                for (int i = 0; i < y; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        pole[j, i] = int.Parse(button[j, i].Text);
                        if (button[j, i].Text != "0") button[j, i].Visible = true; else button[j, i].Visible = false;

                    }
                }

            }


            public void EndGame(System.Windows.Forms.Timer timer, Form game)
            {
                int index = 1;
                int count = 1;
                for (int i = 0; i < maxY + 1; i++)
                {
                    for (int j = 0; j < maxX + 1; j++)
                    {
                        if (pole[j, i] == index) count++;
                        index++;
                    }
                }
                if (count == (maxX + 1) * (maxY + 1))
                {
                    timer.Stop();

                }
            }

        }
    }
