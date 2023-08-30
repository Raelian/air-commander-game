using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AirCommander
{
    public partial class BattlePage : UserControl
    {
        Button[,] buttonsArray;
        Grid[] grids;
        List<String> playerGridList;
        int lastPlaneHit = -1;
        int planeOne = 0;
        int planeTwo = 0;
        bool planeGotHit = false;
        int misses = 1;

        public BattlePage()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.grids = new Grid[2];
            this.buttonsArray = new Button[2, 100];
            this.playerGridList = new List<String>();
        }

        public void arrangeGrid(Button[,] arr, byte num)
        {
            byte gridX = 40;
            byte gridY = 40;
            byte col = 1;
            byte row = 2;
            byte i = 0;
            byte j = 0;
            byte k = 1;
            String[] x = new String[10]
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"
            };

            while (i < 100)
            {
                arr[num, i] = new Button();
                arr[num, i].Tag = "player" + x[j] + k;
                arr[num, i].Text = x[j] + k.ToString();
                arr[num, i].Width = 40;
                arr[num, i].Height = 40;
                arr[num, i].Font = new Font("Ariel", 8, FontStyle.Bold);
                arr[num, i].BackColor = Color.White;
                arr[num, i].FlatStyle = FlatStyle.Flat;
                arr[num, i].FlatAppearance.BorderSize = 1;
                arr[num, i].FlatAppearance.BorderColor = Color.Black;
                arr[num, i].FlatAppearance.MouseOverBackColor = Color.Lime;
                arr[num, i].FlatAppearance.MouseDownBackColor = Color.Yellow;
                arr[num, i].Cursor = Cursors.Hand;
                arr[num, i].Location = new Point(gridX * col, gridY * row);
                arr[num, i].Click += new System.EventHandler(clickGrid);
                col++;
                j++;
                if (num == 0) playerPanel.Controls.Add(arr[num, i]); //if 0 add to player panel
                else if (num == 1) enemyPanel.Controls.Add(arr[num, i]); //if 1 add to enemy panel
                i++;
                if (col == 11)
                {
                    col = 1;
                    j = 0;
                    k++;
                    row++;
                }
            }
        }

        public void revealEnemyPlanes()
        {
            for(byte i = 0; i < 10; i++)
            {
                changeGridColorHit(grids[1].getPlane(0).getBodyPart(i), 0, 1);
                changeGridColorHit(grids[1].getPlane(1).getBodyPart(i), 1, 1);
            }
        }

        private void clickGrid(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String name = btn.Parent.Name;
            String x = convertX(btn.Text.Substring(0, 1));
            String y = convertY(btn.Text.Substring(1));

            if (name.Equals("playerPanel"))
            {
                if (grids[0].getPlane(0).getBodyLength() < 2) setPlayerPlanes(0, x, y, 0);
                else if (grids[0].getPlane(1).getBodyLength() < 2) setPlayerPlanes(0, x, y, 1);
            }
            else if (name.Equals("enemyPanel"))
            {
                checkForHit(x, y, 1, "Player");
                Thread.Sleep(500);
                if(checkWinConditions() == -1) enemyTurn();
                if(checkWinConditions() != -1)endGame(checkWinConditions());
            } 
        }

        public void endGame(int num)
        {
            if (num == 0) MessageBox.Show("Enemy wins!");
            else if (num == 1) MessageBox.Show("Player wins!");
            updateBattleLog("Game over!");
            enemyPanel.Enabled = false;
            revealEnemyPlanes();
        }

        public int checkWinConditions()
        {
            if (!grids[0].getPlane(0).getStatus() && !grids[0].getPlane(1).getStatus())
            {
                return 0;
            }
            else if(!grids[1].getPlane(0).getStatus() && !grids[1].getPlane(1).getStatus())
            {
                return 1;
            }
            return -1;
        }

        public void enemyTurn()
        {
            bool repeatedRoll = false;
            String x = "";
            String y = "";
            String enemyRoll = "0";
            while (!repeatedRoll)
            {
                int hitDice = new Random().Next(0, 9);
                int killDice = new Random().Next(0, 4);
                int missDice = new Random().Next(0, 3);
                int bodyDice = new Random().Next(1, 9);
                int randHit = new Random().Next(3, 6);
                if (misses % randHit == 0 && grids[0].getPlane(0).getStatus() == true)
                {
                    enemyRoll = grids[0].getPlane(0).getBodyPart(bodyDice);
                    misses++;
                }
                else if(misses % randHit == 0 && grids[0].getPlane(1).getStatus() == true)
                {
                    enemyRoll = grids[0].getPlane(1).getBodyPart(bodyDice);
                    misses++;
                }
                else if((planeOne > 2 && killDice >= 2) && grids[0].getPlane(0).getStatus())
                {
                    enemyRoll = grids[0].getPlane(0).getBodyPart(0);
                }
                else if ((planeTwo > 2 && killDice >= 2) && grids[0].getPlane(1).getStatus())
                {
                    enemyRoll = grids[0].getPlane(1).getBodyPart(0);
                }
                else if((lastPlaneHit == 0 || lastPlaneHit == 1) && hitDice > 3)
                {
                    enemyRoll = grids[0].getPlane(lastPlaneHit).getBodyPart(bodyDice);
                }
                else if((lastPlaneHit == 0 || lastPlaneHit == 1) && hitDice <= 3)
                {
                    String temp = grids[0].getPlane(lastPlaneHit).getBodyPart(bodyDice);
                    String tempX = temp.Substring(0, 1);
                    String tempY = temp.Substring(1);
                    int randX = new Random().Next(0, 2);
                    int randY = new Random().Next(0, 2);
                    if (missDice == 0) enemyRoll = (Int16.Parse(tempX) + randX).ToString() + Int16.Parse(tempY).ToString();
                    else if (missDice == 1) enemyRoll = Int16.Parse(tempX).ToString() + (Int16.Parse(tempY) + randY).ToString();
                    else if (missDice == 2) enemyRoll = (Int16.Parse(tempX) - randX).ToString() + Int16.Parse(tempY).ToString();
                    else enemyRoll = Int16.Parse(tempX).ToString() + (Int16.Parse(tempY) + randY).ToString();
                }
                else
                {
                    enemyRoll = new Random().Next(0, 99).ToString();
                }

                if (enemyRoll.Length == 1)
                {
                    y = enemyRoll;
                    x = "0";
                }
                else
                {
                    x = enemyRoll.Substring(0, 1);
                    y = enemyRoll.Substring(1);
                }
                repeatedRoll = checkForRepeat(convertXY(x + y), 0);
            } 
            checkForHit(x, y, 0, "Enemy");
        }

        public bool checkForRepeat(String xy, byte num)
        {
            for (byte i = 0; i < buttonsArray.GetLength(1); i++)
            {
                if (buttonsArray[num, i].Text.Equals(xy) && !playerGridList.Contains(xy))
                {
                    playerGridList.Add(xy);
                    return true;
                }
            }
            return false;
        }


        public void checkForHit(String x, String y, byte num, String name)
        {
            bool check = checkGrid(x, y, num);
            updateBattleLog(name + " calls " + convertXY(x + y));
            short planeNum = -1;
            String planeStatus = "";
            if (check)
            {
                for(byte i = 0; i < 2; i++)
                {
                    if (grids[num].getPlane(i).checkForBodyPart(x + y)) planeNum = i;
                }

                if(grids[num].getPlane(planeNum).getStatus())
                {
                    if (grids[num].getPlane(planeNum).getBodyPart(0).Equals(x + y))
                    {
                        planeStatus = "killed";
                    }
                    else
                    {
                        planeStatus = "hit";
                    }
                }
                else
                {
                    planeStatus = "wreckage";
                }

            }

            if (planeStatus.Equals("wreckage"))
            {
                updateBattleLog(name + " hit a " + planeStatus + "!");
                changeGridColorHit(x + y, planeNum, num);
            }
            else if (planeStatus.Equals("hit"))
            {
                updateBattleLog(name + " scored a " + planeStatus + "!");
                changeGridColorHit(x + y, planeNum, num);
                if (name.Equals("Enemy"))
                {
                    lastPlaneHit = planeNum;
                    planeGotHit = true;
                    if (planeNum == 0) planeOne++;
                    else if(planeNum == 1) planeTwo++;
                }
            }
            else if (planeStatus.Equals("killed"))
            {
                updateBattleLog(name + " " + planeStatus + " an enemy plane!");
                grids[num].getPlane(planeNum).setStatusDead();
                changeGridColorHit(x + y, planeNum, num);
                markHead(x + y, num);
                if (name.Equals("Enemy"))
                {
                    lastPlaneHit = -1;
                    planeGotHit = false;
                    for(int i = 0; i < 10; i++)
                    {
                        playerGridList.Add(grids[0].getPlane(num).getBodyPart(i));
                    }
                }
                MessageBox.Show(name + " destroyed a plane!");
            }
            else
            {
                updateBattleLog(name + " missed!");
                changeGridColorMissed(x + y, num);
                if (name.Equals("Enemy")) misses++;
            }

            if(name.Equals("Player"))disableGrid(x, y, 1);
        }

        public void disableGrid(String x, String y, int num)
        {
            String tempX = convertX(Int16.Parse(x));
            String tempY = convertY(Int16.Parse(y));
            for (byte i = 0; i < buttonsArray.GetLength(1); i++)
            {
                if (buttonsArray[num, i].Text.Equals(convertXY(x + y))) buttonsArray[num, i].Enabled = false;
            }
        }

        public String convertXY(String xy)
        {
            String str1 = convertX(Int16.Parse(xy.Substring(0, 1)));
            String str2 = convertY(Int16.Parse(xy.Substring(1))); 
            return str1 + str2;
        }

        public String convertX(String x)
        {
            switch(x.ToUpper())
            {
                case "A":
                    return "0";
                case "B": 
                    return "1";
                case "C": 
                    return "2";
                case "D": 
                    return "3";
                case "E":
                    return "4";
                case "F":
                    return "5";
                case "G":
                    return "6";
                case "H":
                    return "7";
                case "I":
                    return "8";
                case "J":
                    return "9";
            }
            return "0";
        }

        public String convertX(int x)
        {
            switch (x)
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "E";
                case 5:
                    return "F";
                case 6:
                    return "G";
                case 7:
                    return "H";
                case 8:
                    return "I";
                case 9:
                    return "J";
            }
            return "X";
        }

        public String convertY(String y)
        {
            return (Int16.Parse(y) - 1).ToString();
        }

        public String convertY(short y)
        {
            return (y + 1).ToString();
        }


        public bool checkGrid(String x, String y, byte num)
        {
            return grids[num].getGridStatus(Int16.Parse(x), Int16.Parse(y));

        }

        public void setGridTrue(String x, String y, byte num)
        {
            grids[num].setGridStatusTrue(Int16.Parse(x), Int16.Parse(y));
        }

        public void setGridFalse(String x, String y, byte num)
        {
            grids[num].setGridStatusFalse(Int16.Parse(x), Int16.Parse(y));
        }


        public void changeGridColorBlank(String coord, byte num)
        {
            for (byte i = 0; i < buttonsArray.GetLength(1); i++)
            {
                if (buttonsArray[num, i].Text.Equals(convertXY(coord))) buttonsArray[num, i].BackColor = Color.White;
            }
        }

        public void markHead(String coord, byte num)
        {
            for (byte i = 0; i < buttonsArray.GetLength(1); i++)
            {
                if (buttonsArray[num, i].Text.Equals(convertXY(coord)))
                {
                    buttonsArray[num, i].Text = "X";     
                }
            }
        }

        public void changeGridColorHit(String coord, short planeNum, byte num)
        {
            for (byte i = 0; i < buttonsArray.GetLength(1); i++)
            {
                if (buttonsArray[num, i].Text.Equals(convertXY(coord)))
                {
                    if(planeNum == 0) buttonsArray[num, i].BackColor = Color.DarkRed;
                    else if(planeNum == 1) buttonsArray[num, i].BackColor = Color.DarkOrange;
                }
            }
        }

        public void changeGridColorMissed(String coord, byte num)
        {
            for (byte i = 0; i < buttonsArray.GetLength(1); i++)
            {
                if (buttonsArray[num, i].Text.Equals(convertXY(coord))) buttonsArray[num, i].BackColor = Color.Yellow;
            }
        }

        public bool checkPlaneLength(short head, short tail)
        {
            if (Math.Abs(head - tail) == 3 || Math.Abs(head - tail) == 30) return true;
            else return false;
        }

        public void changeGridColorAlive(String coord, byte colorType, byte num)
        {
            for (byte i = 0; i < buttonsArray.GetLength(1); i++)
            {
                if (buttonsArray[num, i].Text.Equals(convertXY(coord)))
                {
                    if(colorType == 0) buttonsArray[num, i].BackColor = Color.Teal;
                    else if(colorType == 1) buttonsArray[num, i].BackColor = Color.LightBlue;
                }
            }
        }

        public void setEnemyPlanes()
        {
            while(grids[1].getPlane(0).getBodyLength() < 2 || grids[1].getPlane(1).getBodyLength() < 2)
            {
                String xy = new Random().Next(0, 99).ToString();
                String x = "";
                String y = "";
                byte num = 1;
                byte planeNum = 0;
                if (grids[1].getPlane(0).getBodyLength() > 2) planeNum = 1;
                if (xy.Length == 1)
                {
                    y = xy;
                    x = "0";
                }
                else
                {
                    x = xy.Substring(0, 1);
                    y = xy.Substring(1);
                }

                if(grids[num].getPlane(planeNum).getBodyLength() == 1)
                {
                    String[] tailArr = new String[2];
                    String head = grids[num].getPlane(planeNum).getBodyPart(0);
                    tailArr = placePlaneTail(head.Substring(0, 1), head.Substring(1));
                    x = tailArr[0];
                    y = tailArr[1];
                }

                if(!checkGrid(x, y, num))
                {
                    if (!grids[num].getPlane(0).checkForBodyPart(x + y) && !grids[num].getPlane(1).checkForBodyPart(x + y))
                    {
                        grids[num].getPlane(planeNum).setBodyPart(x + y);
                        setGridTrue(x, y, num);
                        //changeGridColorAlive(x + y, planeNum);

                        if (grids[num].getPlane(planeNum).getBodyLength() == 2)
                        {

                            bool check = checkPlaneCollision(grids[num].getPlane(planeNum).getBodyPart(0), grids[num].getPlane(planeNum).getBodyPart(1), num, planeNum);
                            if (check)
                            {
                                String[] arr = new String[10];
                                arr = shapePlaneBody(grids[num].getPlane(planeNum).getBodyPart(0), grids[num].getPlane(planeNum).getBodyPart(1));
                                for (byte i = 2; i < arr.Length; i++)
                                {
                                    grids[num].getPlane(planeNum).setBodyPart(arr[i]);
                                    setGridTrue(arr[i].Substring(0, 1), arr[i].Substring(1), num);
                                    //changeGridColorAlive(arr[i], planeNum);
                                    if (planeNum == 0) Console.WriteLine("Plane 1 body in");
                                    else Console.WriteLine("Plane 2 body in");
                                    Console.WriteLine(arr[i]);
                                }
                                if (planeNum == 0)
                                {
                                    updateBattleLog("First plane has been created successfully.");
                                }
                                if (planeNum == 1)
                                {
                                    updateBattleLog("Second plane has been created succesfully.");
                                    Thread.Sleep(100);
                                    updateBattleLog("Battle begins.");
                                    updateBattleLog("Player can make the first call (ex: H5)");
                                }
                            }
                            else
                            {
                                setGridFalse(grids[num].getPlane(planeNum).getBodyPart(0).Substring(0, 1), grids[num].getPlane(planeNum).getBodyPart(0).Substring(1), num);
                                setGridFalse(grids[num].getPlane(planeNum).getBodyPart(1).Substring(0, 1), grids[num].getPlane(planeNum).getBodyPart(1).Substring(1), num);
                                //changeGridColorBlank(grids[num].getPlane(planeNum).getBodyPart(0), num);
                                //changeGridColorBlank(grids[num].getPlane(planeNum).getBodyPart(1), num);
                                grids[num].getPlane(planeNum).deleteBody();
                            }
                        }
                    }
                }
            }
        }

        public String[] placePlaneTail(String x, String y)
        {
            short tempHead = Int16.Parse(x + y);
            List<String> arrTails = new List<String>();
            String[] arr = new String[2];
            short intX = Int16.Parse(x);
            short intY = Int16.Parse(y);
            arrTails.Add(x + (intY - 3).ToString());
            arrTails.Add(x + (intY + 3).ToString());
            arrTails.Add((intX - 3).ToString() + y);
            arrTails.Add((intX + 3).ToString() + y);
            int maxRange = arrTails.Count();
            
            while (arr[0] == null && arr[0] == null)
            {
                int random = new Random().Next(0, maxRange);
                if (arrTails[random].Length == 2 && Int16.Parse(arrTails[random]) > 0)
                {
                    arr[0] = arrTails[random].Substring(0, 1);
                    arr[1] = arrTails[random].Substring(1);
                }
            }
            return arr;
        }
        
        public void setPlayerPlanes(byte num, String x, String y, byte planeNum)
        {
            if (!checkGrid(x, y, num))
            {
                if (!grids[num].getPlane(0).checkForBodyPart(x + y) && !grids[num].getPlane(1).checkForBodyPart(x + y))
                {
                    grids[num].getPlane(planeNum).setBodyPart(x + y);
                    setGridTrue(x, y, num);
                    changeGridColorAlive(x + y, planeNum, num);//num might be wrong

                    if (grids[num].getPlane(planeNum).getBodyLength() == 2)
                    {
                        bool check = checkPlaneCollision(grids[num].getPlane(planeNum).getBodyPart(0), grids[num].getPlane(planeNum).getBodyPart(1), num, planeNum);
                        if (check)
                        {
                            String[] arr = new String[10];
                            arr = shapePlaneBody(grids[num].getPlane(planeNum).getBodyPart(0), grids[num].getPlane(planeNum).getBodyPart(1));
                            for(byte i = 2; i < arr.Length; i++)
                            {
                                grids[num].getPlane(planeNum).setBodyPart(arr[i]);
                                setGridTrue(arr[i].Substring(0, 1), arr[i].Substring(1), num);
                                changeGridColorAlive(arr[i], planeNum, num);//num might be wrong
                            }
                            if (planeNum == 0)
                            {
                                updateBattleLog("First plane has been created successfully.");
                                if(num == 0) updateBattleLog("Pick two more grids for your second plane (ex: C1 for the head, C4 for the tail)");
                            }
                            if (planeNum == 1)
                            {
                                playerPanel.Enabled = false;
                                enemyPanel.Enabled = true;
                                updateBattleLog("Second plane has been created succesfully.");
                                Thread.Sleep(1500);
                                if (num == 0)
                                {
                                    updateBattleLog("Enemy combatant will now place their own planes.");
                                    changePhaseTxt("Enemy phase");
                                    setEnemyPlanes();
                                }
                                if (num == 1)
                                {
                                    updateBattleLog("The battle begins.");
                                    updateBattleLog("Choose an enemy grid and deliver the first strike!");
                                }
                            }
                        }
                        else
                        {
                            if(num == 0)MessageBox.Show("Coordinates are not correct, please try again.");
                            setGridFalse(grids[num].getPlane(planeNum).getBodyPart(0).Substring(0, 1), grids[num].getPlane(planeNum).getBodyPart(0).Substring(1), num);
                            setGridFalse(grids[num].getPlane(planeNum).getBodyPart(1).Substring(0, 1), grids[num].getPlane(planeNum).getBodyPart(1).Substring(1), num);
                            changeGridColorBlank(grids[num].getPlane(planeNum).getBodyPart(0), num);
                            changeGridColorBlank(grids[num].getPlane(planeNum).getBodyPart(1), num);
                            grids[num].getPlane(planeNum).deleteBody();
                        }
                    }
                }
            }
            else
            {
                if(num == 0)MessageBox.Show("Grid square is already occupied, please pick another.");
            }
        }

        public String[] shapePlaneBody(String head, String tail)
        {
            short headX = Int16.Parse(head.Substring(0, 1));
            short headY = Int16.Parse(head.Substring(1));
            short tailX = Int16.Parse(tail.Substring(0, 1));
            short tailY = Int16.Parse(tail.Substring(1));

            String[] arr = new String[10];
            arr[0] = head;
            arr[1] = tail;

            if (headX == tailX)
            {
                short v = 1;
                if (headY > tailY) v *= -1;
                arr[2] = headX.ToString() + (headY + v).ToString();
                arr[3] = (headX - 1).ToString() + (headY + v).ToString();
                arr[4] = (headX - 2).ToString() + (headY + v).ToString();
                arr[5] = (headX + 1).ToString() + (headY + v).ToString();
                arr[6] = (headX + 2).ToString() + (headY + v).ToString();
                if (v < 0) v--;
                else if (v > 0) v++;
                arr[7] = headX.ToString() + (headY + v).ToString();
                if (v < 0) v--;
                else if (v > 0) v++;
                arr[8] = (headX - 1).ToString() + (headY + v).ToString();
                arr[9] = (headX + 1).ToString() + (headY + v).ToString();
            }
            else if (headY == tailY)
            {
                short h = 1;
                if (headX > tailX) h *= -1;
                arr[2] = (headX + h).ToString() + headY.ToString();
                arr[3] = (headX + h).ToString() + (headY + 1).ToString();
                arr[4] = (headX + h).ToString() + (headY + 2).ToString();
                arr[5] = (headX + h).ToString() + (headY - 1).ToString();
                arr[6] = (headX + h).ToString() + (headY - 2).ToString();
                if (h < 0) h--;
                else if (h > 0) h++;
                arr[7] = (headX + h).ToString() + headY.ToString();
                if (h < 0) h--;
                else if (h > 0) h++;
                arr[8] = (headX + h).ToString() + (headY - 1).ToString();
                arr[9] = (headX + h).ToString() + (headY + 1).ToString();
            }

            return arr;
        }

        public bool checkPlaneCollision(String head, String tail, int num, int planeNum)
        {
            if (!checkPlaneLength(Int16.Parse(grids[num].getPlane(planeNum).getBodyPart(0)), Int16.Parse(grids[num].getPlane(planeNum).getBodyPart(1)))) return false;

            String[] arr = new String[10];
            arr = shapePlaneBody(head, tail);
            
            for(byte i = 2; i < arr.Length; i++)
            {
                if (arr[i].Length > 2) return false;
            }

            if(planeNum == 1)
            {
                for(byte i = 0; i < arr.Length; i++)
                {
                    if(grids[num].getPlane(0).checkForBodyPart(arr[i])) return false;
                }
            }
            return true;
        }
        
        private void updateBattleLog(String txt)
        {
            this.battleLog.AppendText(txt + "\r\n");
        }

        private void changePhaseTxt(String txt)
        {
            this.battlePhaseText.Text = txt;
        }

        private void BattlePage_Load(object sender, EventArgs e)
        {
            //get desktop resolution
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            //position screen and resize based on resolution
            this.Location = new Point(0, 0);
            this.Size = new Size(width, height);
            this.battleStartBtn.Location = new Point(width / 2 - this.battleStartBtn.Size.Width / 2, height - 370);
            this.battleBackBtn.Location = new Point(width / 2 - this.battleBackBtn.Size.Width / 2, height - 200);
            //phase text
            this.battlePhaseText.Location = new Point(width / 2 - this.battlePhaseText.Size.Width / 2, 40);
            this.battlePhaseText.BackColor = Color.Transparent;
            //player panel
            this.playerPanel.Location = new Point(width / 5 - this.playerPanel.Size.Width / 2, height / 10);
            //player title
            this.playerLabel.Location = new Point(this.playerPanel.Width / 2 - this.playerLabel.Width / 2, 10);
            //player grid array
            arrangeGrid(buttonsArray, 0);
            grids[0] = new Grid();
            this.playerPanel.Enabled = false;
            //enemy panel
            this.enemyPanel.Location = new Point(width - (width / 5) - this.enemyPanel.Size.Width / 2, height / 10);
            //enemy title
            this.enemyLabel.Location = new Point(this.enemyPanel.Width / 2 - this.enemyLabel.Width / 2, 10);
            //enemy grid array
            arrangeGrid(buttonsArray, 1);
            grids[1] = new Grid();
            this.enemyPanel.Enabled = false;
            //battle log
            this.battleLog.Location = new Point(width / 2 - this.battleLog.Size.Width / 2, height / 2 - this.battleLog.Size.Height - 10);
            updateBattleLog("Welcome to Air Commander!");
            updateBattleLog("Press start button to begin.");
            //make sure it starts off as invisible until called on
            this.Visible = false;
        }

        private void battleBackBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void battleStartBtn_Click(object sender, EventArgs e)
        {
            changePhaseTxt("Planning phase");
            updateBattleLog("Pick two grids for your first plane (ex: E5 for head, E8 for tail)");
            this.playerPanel.Enabled = true;
            this.battleStartBtn.Enabled = false;
        }
    }
}
