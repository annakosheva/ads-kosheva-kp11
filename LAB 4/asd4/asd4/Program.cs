using System;
using System.Collections.Generic;

namespace asd4
{
    public class DLNode
    {
        public int data;
        public DLNode next;
        public DLNode prev;

        public DLNode(int _data)
        {
            data = _data;
            next = null;
            prev = null;
        }
    }

    public class TwoLinkedList
    {
        public DLNode head;

        public TwoLinkedList()
        {
            head = null;
        }

        public void AddFirst(int data)
        {
            DLNode newNode = new DLNode(data);
            if(head != null)
            {
                head.prev = newNode;
                newNode.next = head;
                head = newNode;
            }
            else
            {
                head = newNode;
            }
        }

        public void AddLast(int data)
        {
            DLNode newNode = new DLNode(data);
            if(head == null)
            {
                AddFirst(data);
            }
            else
            {
                DLNode tail = GetTail();
                tail.next = newNode;
                newNode.prev = tail;
            }
        }

        public void AddAtPosition(int data, int pos)
        {
            if (pos == 0)
            {
                AddFirst(data);
            }
            else
            {
                DLNode newNode = new DLNode(data);
                try
                {
                    DLNode element = GetAtPosition(pos);
                    element.prev.next = newNode;
                    newNode.prev = element.prev;
                    element.prev = newNode;
                    newNode.next = element;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void DeleteFirst()
        {
            if(head != null)
            {
                if(head.next != null)
                {
                    head = head.next;
                    head.prev = null;
                }
                else
                {
                    head = null;
                }
            }
        }

        public void DeleteLast()
        {
            if (head != null)
            {
                DLNode tail = GetTail();
                if(tail.prev == null)
                {
                    DeleteFirst();
                }
                else
                {
                    tail = tail.prev;
                    tail.next = null;
                }
            }
        }

        public void DeleteAtPosition(int pos)
        {
            try
            {
                DLNode element = GetAtPosition(pos);
                if (element.prev == null)
                    DeleteFirst();
                else if (element.next == null)
                    DeleteLast();
                else
                {
                    element.prev.next = element.next;
                    element.next.prev = element.prev;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public void Print()
        {
            DLNode currentObj = head;
            while (currentObj != null)
            {
                Console.Write(currentObj.data + " ");
                currentObj = currentObj.next;
            }
            Console.WriteLine();
        }

        public void CustomFunction(int data)
        {
            if (data % 2 == 0)
                AddFirst(data);
            else
                AddLast(data);
        }

        private DLNode GetTail()
        {
            DLNode currentObj = head;
            while(currentObj.next != null)
            {
                currentObj = currentObj.next;
            }
            return currentObj;
        }

        private DLNode GetAtPosition(int pos)
        {
            DLNode currenjObj = head;
            int currentPos = 0;
            if(pos == 0 && head == null)
                throw new Exception("Position is more than list length.");
            while (currentPos != pos)
            {
                if (currenjObj != null)
                    currenjObj = currenjObj.next;
                else
                    throw new Exception("Position is more than list length.");
                currentPos++;
            }
            return currenjObj;
        }
    }

    class Program
    {
        private static void PrintOptions()
        {
            Console.WriteLine("Choose option:");
            Console.WriteLine("1 - Add First");
            Console.WriteLine("2 - Add Last");
            Console.WriteLine("3 - Add At Position");
            Console.WriteLine("4 - Delete First");
            Console.WriteLine("5 - Delete Last");
            Console.WriteLine("6 - Delete At Position");
            Console.WriteLine("7 - Print");
            Console.WriteLine("8 - Custom Function");
            Console.WriteLine("9 - Quit");
        }

        private static int ReadOption()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        private static int InputFirstParameter()
        {
            Console.WriteLine("Input first parameter:");
            return ReadOption();
        }

        private static int InputSecondParameter()
        {
            Console.WriteLine("Input second parameter:");
            return ReadOption();
        }

        static void Main(string[] args)
        {
            TwoLinkedList twoLinkedList = new TwoLinkedList();
            PrintOptions();
            int option = ReadOption();
            while (option != 9)
            {
                if(option == 1)
                {
                    Console.WriteLine();
                    int value = InputFirstParameter();
                    twoLinkedList.AddFirst(value);
                    twoLinkedList.Print();
                }
                else if(option == 2)
                {
                    Console.WriteLine();
                    int value = InputFirstParameter();
                    twoLinkedList.AddLast(value);
                    twoLinkedList.Print();
                }
                else if(option == 3)
                {
                    Console.WriteLine();
                    int value1 = InputFirstParameter();
                    int value2 = InputSecondParameter();
                    twoLinkedList.AddAtPosition(value1, value2);
                    twoLinkedList.Print();
                }
                else if(option == 4)
                {
                    Console.WriteLine();
                    twoLinkedList.DeleteFirst();
                    twoLinkedList.Print();
                }
                else if(option == 5)
                {
                    Console.WriteLine();
                    twoLinkedList.DeleteLast();
                    twoLinkedList.Print();
                }
                else if(option == 6)
                {
                    Console.WriteLine();
                    int value = InputFirstParameter();
                    twoLinkedList.DeleteAtPosition(value);
                    twoLinkedList.Print();
                }
                else if(option == 7)
                {
                    Console.WriteLine();
                    twoLinkedList.Print();
                }
                else if(option == 8)
                {
                    Console.WriteLine();
                    int value = InputFirstParameter();
                    twoLinkedList.CustomFunction(value);
                    twoLinkedList.Print();
                }
                PrintOptions();
                option = ReadOption();
            }
        }
    }
}
