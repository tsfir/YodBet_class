using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static YodBet_class.Program;

namespace YodBet_class
{
    internal class Program
    {
        public class Node<T>
        {
            private T value;
            private Node<T> next;
            public Node(T value)
            {
                this.value = value;
                this.next = null;
            }
            public Node(T value, Node<T> next)
            {
                this.value = value;
                this.next = next;
            }

            public T GetValue()
            {
                return this.value;
            }
            public Node<T> GetNext()
            {
                return this.next;
            }

            public void SetValue(T value)
            {
                this.value = value;
            }
            public void SetNext(Node<T> next)
            {
                this.next = next;

            }
            public bool HasNext()
            {
                return this.next != null;
            }
            public string ToString()
            {
                return "" + this.value.ToString();
            }
        }


        public class StringNode
        {

            private string value;
            private StringNode next;

            public StringNode(string x)
            {
                this.value = x;
                this.next = null;
            }
            public StringNode(string x, StringNode next)
            {
                this.value = x;
                this.next = next;
            }
            public string GetValue()
            {
                return (this.value);
            }
            public StringNode GetNext()
            {
                return (this.next);
            }
            public bool hasNext()
            {
                return (this.next != null);
            }
            public void SetValue(string x)
            {
                this.value = x;
            }
            public void SetNext(StringNode next)
            {
                this.next = next;
            }
            public String toString()
            {
                return (" " + this.value);
            }
        }


        public class Bead
        {
            private string color;
            private Bead nextBead;

            public Bead(string color)
            {
                this.color = color;
                this.nextBead = null;
            }

            public Bead(string color, Bead nextBead)
            {
                this.color = color;
                this.nextBead = nextBead;
            }

            public string GetColor()
            {
                return this.color;
            }

            public Bead GetNextBead()
            {
                return this.nextBead;
            }

            public void SetNextBead(Bead nextBead)
            {
                this.nextBead = nextBead;
            }
        }

        static int ListLength(Node<int> head)
        {
            int count = 0;
            Node<int> pos = head;
            while (pos != null)
            {
                count++;
                pos = pos.GetNext();
            }
            return count;
        }

        static int SumList(Node<int> head)
        {
            Node<int> pos = head;
            int sum = 0;
            while (pos != null)
            {
                sum = sum+pos.GetValue();
                pos = pos.GetNext();
            }
            return sum;
        }


        public static int Peola(Node<int> head)
        {
            // פעולה אם מספר האיברים אי זוגי מחזיר את הערך של החוליה מרכזית
            // אחרת את סכום השרשרת
            Node<int> pos = head;
            Node<int> posFast = head;
            int sum = 0;

            while (posFast!=null)
            {
                sum = sum+posFast.GetValue();
                posFast = posFast.GetNext();
                if (posFast == null)
                    return pos.GetValue();
                sum = sum + posFast.GetValue();
                posFast = posFast.GetNext();
                pos = pos.GetNext();
            }
            return sum;
        }

        public static bool IsUp(Node<int> start)
        {
            Node<int> pos = start;
            while((pos.GetNext() != null) && (pos.GetNext().GetValue() != -999))
            {
                if (pos.GetValue() > pos.GetNext().GetValue())
                    return false;
                pos = pos.GetNext();
            }
            return true;
        }

        static Node<int> FindValue(Node<int> head, int valueToSearch)
        {
            Node<int> pos = head;
            while (pos != null)
            {
                if (pos.GetValue() == valueToSearch)
                    return pos;
                pos = pos.GetNext();
            }
            return null;
        }

        public static bool IsDown(Node<int> start)
        {
            Node<int> pos = start;
            while ((pos.GetNext() != null) && (pos.GetNext().GetValue() != -999))
            {
                if (pos.GetValue() < pos.GetNext().GetValue())
                    return false;
                pos = pos.GetNext();
            }
            return true;
        }
        // פעולה המקבלת חולית ראש של רשימה
        // ומחזירה כמה תתי רשימות עולות ממש או יורדות ממש יש ברשימה
        // יוצאת מתוך הנחה שהערך של החוליה האחרונה הוא -999 כמסיימת תת רשימה
        public static int CountUpDown_29(Node<int> start)
        {
            Node<int> pos = start;
            int count = 0;
            while (pos!=null)
            {
                if (IsDown(pos) || IsUp(pos)) count++;
                pos = FindValue(pos,-999).GetNext();
            }
            return count;
        }


        static int CountValue(Node<int> head, int valueToSearch)
        {
            Node<int> pos = head;
            int count = 0;
            while (pos != null)
            {
                if (pos.GetValue() == valueToSearch)
                    count++;
                pos = pos.GetNext();
            }
            return count;
        }

        // פעולה המקבלת רשימה של ציונים (0-100(
        // ומחזירה רשימה של שכיחות יחסים
        public static Node<double> Histograma(Node<int> start)
        {

            int totalAmountStudent = ListLength(start);
            int count = CountValue(start, 0);
            Node<double> startHistograma = new Node<double>((double)count/totalAmountStudent);
            Node<double> LastHistograma = startHistograma;

            for (int i = 1;i<=100;i++)
            {
                count = CountValue(start, i); // פעולה שסופרת כמה פעמים מופיע ערך בפעולה
                Node<double> newNode = new Node<double>((double)count / totalAmountStudent);
                LastHistograma.SetNext(newNode);
                LastHistograma = newNode;
            }

            return startHistograma;
        }

        public static void PrintChain(Bead firstBead)
        {
            Bead pos = firstBead;  
            while ((pos != null) && (firstBead != pos.GetNextBead()))
            {
                Console.Write(pos.GetColor() + "--");
                pos = pos.GetNextBead();  
            }
            if (pos!=null)
                Console.Write(pos.GetColor() + "--");
            Console.WriteLine("end");
        }

        public static int BeadLength(Bead firstBead)
        {
            Bead pos = firstBead;
            int counter = 0;
            while (pos != null)
            {
                pos = pos.GetNextBead();
                counter++;
            }
            return counter;
        }

        public static Boolean BeadCompare(Bead firstBead1, Bead firstBead2)
        {
            Bead pos1 = firstBead1;
            Bead pos2 = firstBead2;
            if (BeadLength(firstBead1) != BeadLength(firstBead2)) return false;
            while (pos1!=null)
            {
                if (pos1.GetColor() != pos2.GetColor())  return false;
                pos1 = pos1.GetNextBead();
                pos2 = pos2.GetNextBead();
            }
            return true;
        }

        public static void ConnectBead(Bead firstBead1, Bead firstBead2)
        {
            Bead pos1 = firstBead1;
            while (pos1.GetNextBead() != null)
            {
                pos1 = pos1.GetNextBead();
            }
            pos1.SetNextBead(firstBead2);
        }


        static void Main(string[] args)
        {

            Bead b1 = new Bead("red");
            Bead b2 = new Bead("blue", b1);
            Bead b3 = new Bead("gray", b2);
            Bead circleChain = new Bead("green", b3);
            //b1.SetNextBead(circleChain);
            PrintChain(circleChain);

            //Bead chain = new Bead("red", new Bead("green", new Bead("blue")));
            Bead chain = new Bead("green", new Bead("gray", new Bead("blue", new Bead("red"))));
            PrintChain(chain);

            Console.WriteLine(BeadCompare(chain, circleChain));

            ConnectBead(circleChain, chain);
            PrintChain(circleChain);



            //Node<int> head = new Node<int>(10);
            //Node<int> node2 = new Node<int>(10);
            //Node<int> node3 = new Node<int>(20);
            //Node<int> node4 = new Node<int>(20);
            //Node<int> node5 = new Node<int>(20);
            //Node<int> node6 = new Node<int>(30);
            //Node<int> node7 = new Node<int>(90);
            //Node<int> node8 = new Node<int>(90);
            //head.SetNext(node2);
            //node2.SetNext(node3);
            //node3.SetNext(node4);
            //node4.SetNext(node5);
            //node5.SetNext(node6);
            //node6.SetNext(node7);
            //node7.SetNext(node8);

            //Console.WriteLine(Peola(head));
            //Console.WriteLine(CountUpDown_29(head));

            //Node<double> hist = Histograma(head);
            //Node<double> pos = hist;
            //for (int i = 0; i <= 100; i++) { 
            //    Console.WriteLine(i + "-" + pos.GetValue());
            //    pos = pos.GetNext();
            //}



            ////---------------------------------
            //// Creating List
            ////---------------------------------
            //StringNode head = new StringNode("First Node");
            //StringNode node2 = new StringNode("Second Node");
            //StringNode node3 = new StringNode("Third Node");
            //StringNode node4 = new StringNode("Forth Node");

            //head.SetNext(node2);
            //node2.SetNext(node3);
            //node3.SetNext(node4);


            ////---------------------------------
            //// Print the values for all nodes
            ////---------------------------------

            //StringNode current = head;
            //while (current != null)
            //{
            //    Console.WriteLine(current.GetValue());
            //    current = current.GetNext();
            //}

            ////---------------------------------
            //// Insert 5 nodes to the list after head
            ////---------------------------------

            //current = head;
            //for (int loop = 0; loop < 5; loop++)
            //{
            //    Console.WriteLine("Enter Node Value");
            //    string node_value = Console.ReadLine();
            //    StringNode new_node = new StringNode(node_value);
            //    current.SetNext(new_node);
            //    current = new_node;
            //}

            Console.ReadLine();
        }
    }
}
