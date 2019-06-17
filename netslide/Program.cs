using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace netslide
{
    public class Node
    {
        public static int counter = -1;
        public int id;
        public Node Parent;
        public int[] state = new int[8];
        public List<Node> children;

        public Node(int[] state, Node Parent)
        {
            counter++;
            this.id = counter;
            this.Parent = Parent;
            for (int i = 0; i < 8; i++)
            {
                this.state[i] = state[i];
            }
            this.children = new List<Node>();
        }

        public Node(int[] state)
        {
            for (int i = 0; i < 8; i++)
            {
                this.state[i] = state[i];
            }
        }

        public override string ToString()
        {
            if (this.Parent == null)
                return "Az " + id + "-jű elemnek az értéke: " + this.state[0] + this.state[1]
                    + this.state[2] + this.state[3] + this.state[4] + this.state[5] + this.state[6] + this.state[7] + " Szülő: null" + " | Gyerekei száma: " + this.children.Count;
            else
                return "Az " + id + "-jű elemnek az értéke: " + this.state[0] + this.state[1]
                    + this.state[2] + this.state[3] + this.state[4] + this.state[5] + this.state[6] + this.state[7] + " Szülő(" + this.Parent.id + ") gyerekeinek száma: " + this.Parent.children.Count + " | Gyerekei száma: " + this.children.Count;
        }

        static int level = 1;

        Boolean inner_walls = false;
        static int maxlevel = 5;

        public void Difficulty(int[] walls)
        {
            for (int i = 0; i < 8; i++)
            {
                if (walls[i] != 0)
                {
                    inner_walls = true;
                    break;
                }
            }
            if (inner_walls)
                maxlevel = 9;
            else
                maxlevel = 11;
        }

        public Node BuildTree()
        {
            Node child;
            int[] squares = new int[8];
            int temp, temp1;

            for (int j = 0; j < 8; j++)
            {
                squares[j] = this.state[j];
            }
            temp = squares[0];
            temp1 = squares[1];
            squares[0] = squares[2];
            squares[1] = temp;
            squares[2] = temp1;
            if (level == maxlevel)
            {
                this.children.Add(null);
                return null;
            }
            else
            {
                if (level > 1)
                {
                    if (!(squares.SequenceEqual(this.Parent.state)) && !(squares.SequenceEqual(this.state)))
                    {
                        child = new Node(squares, this);
                        this.children.Add(child);
                        level++;
                        child.BuildTree();
                        level--;
                    }
                }
                else
                {
                    child = new Node(squares, this);
                    this.children.Add(child);
                    level++;
                    child.BuildTree();
                    level--;
                }
            }

            for (int j = 0; j < 8; j++)
            {
                squares[j] = this.state[j];
            }
            temp = squares[2];
            temp1 = squares[1];
            squares[2] = squares[0];
            squares[1] = temp;
            squares[0] = temp1;
            if (level == maxlevel)
            {
                this.children.Add(null);
                return null;
            }
            else
            {
                if (level > 1)
                {
                    if (!(squares.SequenceEqual(this.Parent.state)) && !(squares.SequenceEqual(this.state)))     //második
                    {
                        child = new Node(squares, this);
                        this.children.Add(child);
                        level++;
                        child.BuildTree();
                        level--;
                    }
                }
                else
                {
                    child = new Node(squares, this);
                    this.children.Add(child);
                    level++;
                    child.BuildTree();
                    level--;
                }
            }

            for (int j = 0; j < 8; j++)
            {
                squares[j] = this.state[j];
            }
            temp = squares[2];
            temp1 = squares[4];
            squares[2] = squares[7];
            squares[4] = temp;
            squares[7] = temp1;
            if (level == maxlevel)
            {
                this.children.Add(null);
                return null;
            }
            else
            {
                if (level > 1)
                {
                    if (!(squares.SequenceEqual(this.Parent.state)) && !(squares.SequenceEqual(this.state)))
                    {
                        child = new Node(squares, this);
                        this.children.Add(child);
                        level++;
                        child.BuildTree();
                        level--;
                    }
                }
                else
                {
                    child = new Node(squares, this);
                    this.children.Add(child);
                    level++;
                    child.BuildTree();
                    level--;
                }
            }

            for (int j = 0; j < 8; j++)
            {
                squares[j] = this.state[j];
            }
            temp = squares[7];
            temp1 = squares[4];
            squares[7] = squares[2];
            squares[4] = temp;
            squares[2] = temp1;
            if (level == maxlevel)
            {
                this.children.Add(null);
                return null;
            }
            else
            {
                if (level > 1)
                {
                    if (!(squares.SequenceEqual(this.Parent.state)) && !(squares.SequenceEqual(this.state)))
                    {
                        child = new Node(squares, this);
                        this.children.Add(child);
                        level++;
                        child.BuildTree();
                        level--;
                    }
                }
                else
                {
                    child = new Node(squares, this);
                    this.children.Add(child);
                    level++;
                    child.BuildTree();
                    level--;
                }
            }

            for (int j = 0; j < 8; j++)
            {
                squares[j] = this.state[j];
            }
            temp = squares[5];
            temp1 = squares[6];
            squares[5] = squares[7];
            squares[6] = temp;
            squares[7] = temp1;
            if (level == maxlevel)
            {
                level--;
                this.children.Add(null);
                return null;
            }
            else
            {
                if (level > 1)
                {
                    if (!(squares.SequenceEqual(this.Parent.state)) && !(squares.SequenceEqual(this.state)))
                    {
                        child = new Node(squares, this);
                        this.children.Add(child);
                        level++;
                        child.BuildTree();
                        level--;
                    }
                }
                else
                {
                    child = new Node(squares, this);
                    this.children.Add(child);
                    level++;
                    child.BuildTree();
                    level--;
                }
            }

            for (int j = 0; j < 8; j++)
            {
                squares[j] = this.state[j];
            }
            temp = squares[7];
            temp1 = squares[6];
            squares[7] = squares[5];
            squares[6] = temp;
            squares[5] = temp1;
            if (level == maxlevel)
            {
                this.children.Add(null);
                return null;
            }
            else
            {
                if (level > 1)
                {
                    if (!(squares.SequenceEqual(this.Parent.state)) && !(squares.SequenceEqual(this.state)))
                    {
                        child = new Node(squares, this);
                        this.children.Add(child);
                        level++;
                        child.BuildTree();
                        level--;
                    }
                }
                else
                {
                    child = new Node(squares, this);
                    this.children.Add(child);
                    level++;
                    child.BuildTree();
                    level--;
                }
            }

            for (int j = 0; j < 8; j++)
            {
                squares[j] = this.state[j];
            }
            temp = squares[0];
            temp1 = squares[3];
            squares[0] = squares[5];
            squares[3] = temp;
            squares[5] = temp1;
            if (level == maxlevel)
            {
                this.children.Add(null);
                return null;
            }
            else
            {
                if (level > 1)
                {
                    if (!(squares.SequenceEqual(this.Parent.state)) && !(squares.SequenceEqual(this.state)))
                    {
                        child = new Node(squares, this);
                        this.children.Add(child);
                        level++;
                        child.BuildTree();
                        level--;
                    }
                }
                else
                {
                    child = new Node(squares, this);
                    this.children.Add(child);
                    level++;
                    child.BuildTree();
                    level--;
                }
            }

            for (int j = 0; j < 8; j++)
            {
                squares[j] = this.state[j];
            }
            temp = squares[5];
            temp1 = squares[3];
            squares[5] = squares[0];
            squares[3] = temp;
            squares[0] = temp1;
            if (level == maxlevel)
            {
                this.children.Add(null);
                return null;
            }
            else
            {
                if (level > 1)
                {
                    if (!(squares.SequenceEqual(this.Parent.state)) && !(squares.SequenceEqual(this.state)))
                    {
                        child = new Node(squares, this);
                        this.children.Add(child);
                        level++;
                        child.BuildTree();
                        level--;
                    }
                }
                else
                {
                    child = new Node(squares, this);
                    this.children.Add(child);
                    level++;
                    child.BuildTree();
                    level--;
                }
            }
            return this;
        }

        public static Node PerfectNode = null;
        public static int keresesi_lepesek = 0;

        public int getLepesek()
        {
            return keresesi_lepesek;
        }
        public Node SolveIt(Boolean wall_around, int middle, int[] walls)
        {
            keresesi_lepesek++;
            int[] squares = new int[8];
            int cost = 0;

            for (int i = 0; i < squares.Length; i++)
            {
                squares[i] = this.state[i];
            }

            int m = middle;

            if (wall_around)
            {
                //Bal fent
                if (walls[0] == 0)
                {
                    if (squares[0] == 1 || squares[0] == 2 || squares[0] == 5)
                        cost++;
                }
                if (walls[0] == 1)
                {
                    if (squares[0] == 2)
                        cost++;
                }
                if (walls[0] == 2)
                {
                    if (squares[0] == 1)
                        cost++;
                }
                //Jobb fent
                if (walls[1] == 0)
                {
                    if (squares[2] == 2 || squares[2] == 3 || squares[2] == 6)
                        cost++;
                }
                if (walls[1] == 1)
                {
                    if (squares[2] == 2)
                        cost++;
                }
                if (walls[1] == 2)
                {
                    if (squares[2] == 3)
                        cost++;
                }
                //Bal lent
                if (walls[2] == 0)
                {
                    if (squares[5] == 0 || squares[5] == 1 || squares[5] == 4)
                        cost++;
                }
                if (walls[2] == 1)
                {
                    if (squares[5] == 0)
                        cost++;
                }
                if (walls[2] == 2)
                {
                    if (squares[5] == 1)
                        cost++;
                }
                //Jobb lent
                if (walls[3] == 0)
                {
                    if (squares[7] == 0 || squares[7] == 3 || squares[7] == 7)
                        cost++;
                }
                if (walls[3] == 1)
                {
                    if (squares[7] == 0)
                        cost++;
                }
                if (walls[3] == 2)
                {
                    if (squares[7] == 3)
                        cost++;
                }
                //--------------Fent középen
                if (walls[0] == 0 || walls[0] == 2)
                {
                    if (walls[1] == 0 || walls[1] == 2)
                    {
                        if (walls[6] == 0 && (m == 0 || m == 4 || m == 7 || m == 8 || m == 9 || m == 11 || m == 12))
                        {
                            if (squares[1] == 2 || squares[1] == 5 || squares[1] == 6 || squares[1] == 10)
                                cost++;
                        }
                        else
                        {
                            if (squares[1] == 1 || squares[1] == 3 || squares[1] == 13)
                                cost++;
                        }
                    }

                    if (walls[1] == 1)
                    {
                        if (walls[6] == 0 && (m == 0 || m == 4 || m == 7 || m == 8 || m == 9 || m == 11 || m == 12))
                        {
                            if (squares[1] == 2 || squares[1] == 6)
                                cost++;
                        }
                        else
                        {
                            if (squares[1] == 3)
                                cost++;
                        }
                    }
                }

                if (walls[0] == 1)
                {
                    if (walls[1] == 0 || walls[1] == 2)
                    {
                        if (walls[6] == 0 && (m == 0 || m == 4 || m == 7 || m == 8 || m == 9 || m == 11 || m == 12))
                        {
                            if (squares[1] == 2 || squares[1] == 5)
                                cost++;
                        }
                        else
                        {
                            if (squares[1] == 1)
                                cost++;
                        }
                    }

                    if (walls[1] == 1)
                    {
                        if (walls[6] == 0 && (m == 0 || m == 4 || m == 7 || m == 8 || m == 9 || m == 11 || m == 12))
                        {
                            if (squares[1] == 2)
                                cost++;
                        }
                        else
                        {
                            cost = 99;
                        }
                    }
                }

                //Jobb közép
                if (walls[1] == 0 || walls[1] == 1)
                {
                    if (walls[3] == 0 || walls[3] == 1)
                    {
                        if (walls[5] == 0 && (m == 1 || m == 4 || m == 5 || m == 8 || m == 9 || m == 10 || m == 13))
                        {
                            if (squares[4] == 3 || squares[4] == 6 || squares[4] == 7 || squares[4] == 11)
                                cost++;
                        }
                        else
                        {
                            if (squares[4] == 0 || squares[4] == 2 || squares[4] == 12)
                                cost++;
                        }
                    }
                    if (walls[3] == 2)
                    {
                        if (walls[5] == 0 && (m == 1 || m == 4 || m == 5 || m == 8 || m == 9 || m == 10 || m == 13))
                        {
                            if (squares[4] == 3 || squares[4] == 7)
                                cost++;
                        }
                        else
                        {
                            if (squares[4] == 0)
                                cost++;
                        }
                    }
                }

                if (walls[1] == 2)
                {
                    if (walls[3] == 0 || walls[3] == 1)
                    {
                        if (walls[5] == 0 && (m == 1 || m == 4 || m == 5 || m == 8 || m == 9 || m == 10 || m == 13))
                        {
                            if (squares[4] == 3 || squares[4] == 6)
                                cost++;
                        }
                        else
                        {
                            if (squares[4] == 2)
                                cost++;
                        }
                    }
                    if (walls[3] == 2)
                    {
                        if (walls[5] == 0 && (m == 1 || m == 4 || m == 5 || m == 8 || m == 9 || m == 10 || m == 13))
                        {
                            if (squares[4] == 3)
                                cost++;
                        }
                        else
                        {
                            cost = 99;
                        }
                    }
                }

                //Lent közép
                if (walls[2] == 0 || walls[2] == 2)
                {
                    if (walls[3] == 0 || walls[3] == 2)
                    {
                        if (walls[7] == 0 && (m == 2 || m == 5 || m == 6 || m == 9 || m == 10 || m == 11 || m == 12))
                        {
                            if (squares[6] == 0 || squares[6] == 4 || squares[6] == 7 || squares[6] == 8)
                                cost++;
                        }
                        else
                        {
                            if (squares[6] == 1 || squares[6] == 3 || squares[6] == 13)
                                cost++;
                        }
                    }
                    if (walls[3] == 1)
                    {
                        if (walls[7] == 0 && (m == 2 || m == 5 || m == 6 || m == 9 || m == 10 || m == 11 || m == 12))
                        {
                            if (squares[6] == 0 || squares[6] == 7)
                                cost++;
                        }
                        else
                        {
                            if (squares[6] == 3)
                                cost++;
                        }
                    }
                }
                if (walls[2] == 1)
                {
                    if (walls[3] == 0 || walls[4] == 2)
                    {
                        if (walls[7] == 0 && (m == 2 || m == 5 || m == 6 || m == 9 || m == 10 || m == 11 || m == 12))
                        {
                            if (squares[6] == 0 || squares[6] == 4)
                                cost++;
                        }
                        else
                        {
                            if (squares[6] == 1)
                                cost++;
                        }
                    }
                    if (walls[3] == 1)
                    {
                        if (walls[7] == 0 && (m == 2 || m == 5 || m == 6 || m == 9 || m == 10 || m == 11 || m == 12))
                        {
                            if (squares[6] == 0)
                                cost++;
                        }
                        else
                        {
                            cost = 99;
                        }
                    }
                }
                //Bal közép
                if (walls[0] == 0 || walls[0] == 1)
                {
                    if (walls[2] == 0 || walls[2] == 1)
                    {
                        if (walls[4] == 0 && (m == 3 || m == 6 || m == 7 || m == 8 || m == 10 || m == 11 || m == 13))
                        {
                            if (squares[3] == 1 || squares[3] == 4 || squares[3] == 5 || squares[3] == 9)
                                cost++;
                        }
                        else
                        {
                            if (squares[3] == 0 || squares[3] == 2 || squares[3] == 12)
                                cost++;
                        }
                    }
                    if (walls[2] == 2)
                    {
                        if (walls[4] == 0 && (m == 3 || m == 6 || m == 7 || m == 8 || m == 10 || m == 11 || m == 13))
                        {
                            if (squares[3] == 1 || squares[3] == 4)
                                cost++;
                        }
                        else
                        {
                            if (squares[3] == 0)
                                cost++;
                        }
                    }
                }

                if (walls[0] == 2)
                {
                    if (walls[2] == 0 || walls[2] == 1)
                    {
                        if (walls[4] == 0 && (m == 3 || m == 6 || m == 7 || m == 8 || m == 10 || m == 11 || m == 13))
                        {
                            if (squares[3] == 1 || squares[3] == 5)
                                cost++;
                        }
                        else
                        {
                            if (squares[3] == 2)
                                cost++;
                        }
                    }
                    if (walls[2] == 2)
                    {
                        if (walls[4] == 0 && (m == 3 || m == 6 || m == 7 || m == 8 || m == 10 || m == 11 || m == 13))
                        {
                            if (squares[3] == 1)
                                cost++;
                        }
                        else
                        {
                            cost = 99;
                        }
                    }
                }

                if (!inner_walls)
                {
                    //Hurkok kezelése
                    if ((squares[1] == 6 || squares[1] == 10) && (squares[3] == 4 || squares[3] == 9) && (squares[0] == 5))
                        cost--;
                    if ((squares[1] == 5 || squares[1] == 10) && (squares[4] == 7 || squares[4] == 11) && (squares[2] == 6))
                        cost--;
                    if ((squares[3] == 5 || squares[3] == 9) && (squares[6] == 7 || squares[6] == 8) && (squares[5] == 4))
                        cost--;
                    if ((squares[4] == 6 || squares[4] == 11) && (squares[6] == 4 || squares[6] == 8) && (squares[7] == 7))
                        cost--;

                    //Dobozok kezelése
                    if (squares[0] == 5 && (squares[1] == 0 || squares[1] == 1 || squares[1] == 2 || squares[3] == 1 || squares[3] == 2 || squares[3] == 3))
                        cost--;
                    if (squares[2] == 6 && (squares[1] == 0 || squares[1] == 2 || squares[1] == 3 || squares[4] == 1 || squares[4] == 2 || squares[4] == 3))
                        cost--;
                    if (squares[5] == 4 && (squares[3] == 0 || squares[3] == 1 || squares[3] == 3 || squares[6] == 0 || squares[6] == 1 || squares[6] == 2))
                        cost--;
                    if (squares[7] == 7 && (squares[4] == 0 || squares[4] == 1 || squares[4] == 3 || squares[6] == 0 || squares[6] == 2 || squares[6] == 3))
                        cost--;
                }
            }

            if (cost == 8)
            {
                PerfectNode = new Node(this.state);
                return this;
            }
            else
            {
                if (!this.children.Contains(null) && PerfectNode == null)
                {
                    this.children[0].SolveIt(wall_around, middle, walls);
                    if (this.children.Count > 1)
                        this.children[1].SolveIt(wall_around, middle, walls);
                    if (this.children.Count > 2)
                        this.children[2].SolveIt(wall_around, middle, walls);
                    if (this.children.Count > 3)
                        this.children[3].SolveIt(wall_around, middle, walls);
                    if (this.children.Count > 4)
                        this.children[4].SolveIt(wall_around, middle, walls);
                    if (this.children.Count > 5)
                        this.children[5].SolveIt(wall_around, middle, walls);
                    if (this.children.Count > 6)
                        this.children[6].SolveIt(wall_around, middle, walls);
                    if (this.children.Count > 7)
                        this.children[7].SolveIt(wall_around, middle, walls);
                }
            }

            return PerfectNode == null ? null : PerfectNode;
        }

        public void NewGame()
        {
            counter = 0;
            id = 0;
            this.id = 0;
            PerfectNode = null;
            inner_walls = false;
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
