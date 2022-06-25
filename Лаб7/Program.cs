using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace laba7_9_
{

    class HashTable<Key, Value> where Key : new() where Value : new()
    {

        public HashTable(int s)
        {
          nodes = new Entry<Key, Value>[s];
            loadness = 0;
            size = 0;
            capacity = s;
        }

        public double loadness { get; set; }
        public int size { get; set; }
        static public int capacity { get; set; }
        public Entry<Key, Value>[]  nodes { get; set; }

        public void InsertEntry(Entry<Key, Value> entr)
        {
            int ind = entr.key.GetHashCode();
            ind = getHash(ind);
            if (nodes[ind] == null)
            {
                nodes[ind] = entr;
                loadness++;
                size++;
            }
            else
            {
                entr.Next = nodes[ind];
                nodes[ind] = entr;
                size++;
            }

        }

        public Entry<Key, Value> FindValue (Entry<Key, Value> entr)
        {
            
            int index = entr.key.GetHashCode();
            index = getHash(index);
            Entry<Key, Value> current = nodes[index];
            while (current != null)
            {
                if (current.key.Equals(entr.key))
                {
                    entr.value = current.value;
                    return entr;
                }
                current = current.Next;
            }
            return entr;
        }

        public void RemoveEntry(Entry<Key, Value> entr)
        {
            entr = FindValue(entr);
      
                int index = entr.key.GetHashCode();
                index = getHash(index);
                Entry<Key, Value> current = nodes[index];
                int position = 0;
                while (current != null)
                {
                    if (current.key.Equals(entr.key))
                        break;
                    position++;
                    current = current.Next;
                }
                RemoveAtPos(index, position);

        }

        public void RemoveAtPos(int index, int position)
        {
            if (position == 0)
            {
                nodes[index] = nodes[index].Next;
                size--;
                loadness--;
                return;
            }
            else
            { 
                Entry<Key, Value> current = nodes[index];
                int pos = 0;

                while (pos != position - 1)
                {
                    current = current.Next;
                    pos++;
                }
                current.Next = current.Next.Next;
                size--;
              
            }
        }

        public HashTable<Key, Value> Rehashing()
        {
            int new_size = capacity * 2;
            new_size = NearPrime(new_size);

            HashTable<Key, Value> res = new HashTable<Key, Value>(new_size);
            foreach (var node in nodes)
            {
                if (node != null)
                {
                    Entry<Key, Value> elem = node;
                    while (elem != null)
                    {
                        Entry<Key, Value> curr = elem.Next;
                        elem.Next = null;
                        res.InsertEntry(elem);
                        elem = curr;
                    }
                }
                
            }
            return res;
        }

        public HashTable<Key, Value> NeedRehash(HashTable<Key, Value> table, int ind)
        {
            if (size/capacity==1)
            {
                table = Rehashing();
                WriteLine($"У процесі вставки відбулося перегешування {ind} таблиці. Тепер її розмір " + capacity);
            }
            return table;
        }

        public int NearPrime(int n)
        {
            int n1 = n, n2 = n;
            bool b = false;
            int step = 1;
            while (!b)
            {
                n1 += step;
                b = IsItPrime(n1);
                step++;
            }
            b = false;
            step = 1;
            while (!b)
            {
                n2 = n2 + step;
                b = IsItPrime(n1);
                step++;
            }
            if (n - n2 > n1 - n)
                return n1;
            else return n2;
        }

        public bool IsItPrime(int n)
        {

            for (int i = 2; i <= Math.Sqrt(n) + 1; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int getHash(int index)
        {
            index = index % capacity;
            return index;
        }
    }

    class Key1
    {
        public string doi;

        public override int GetHashCode()
        {
            string str = doi;
            int hash = 0;
            str.Replace('.', '0');
            str.Replace('/', '0');
            foreach (var elem in str)
            {
                    hash += Convert.ToInt32(elem);
            }
            return hash;
        }

        public override bool Equals(object ob)
        {
            Key1 key = ob as Key1;
            if (key.doi == doi)
                return true;
            else return false;
        }


    }

    class Entry<Key, Value> where Key : new() where Value : new()
    {
        public Key key { get; set; } = new Key();
        public Value value { get; set; } = new Value();
        public Entry<Key, Value> Next { get; set; } = null;
    }
 
    class Value1
    {
        public string Title { get; set; }
       public LinkedList author { get; set; } = new LinkedList();
        public string journalName { get; set; }
        public int yearOfPublishing { get; set; }
        public int numberOFCiting { get; set; }
    }

    class Key2
    {
        public string authorName;

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (char elem in authorName)
            {
                hash += Convert.ToInt32(elem);
            }
            return hash;
        }

        public override bool Equals(object ob)
        {
            Key2 k = ob as Key2;
            if (k.authorName == authorName)
                return true;
            else return false;
        }
    }

    class Value2
    {
        public int HIndex { get; set; } = -1;
    }

    class LinkedList
    {
        public string Data { get; set; }
        public LinkedList Next { get; set; } = null;
    }

    class Program
    {
        public static char[] letters = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray();

        static void Main(string[] args)
        {
            HashTable<Key1, Value1> table1 = new HashTable<Key1, Value1>(3);
            HashTable<Key2, Value2> table2 = new HashTable<Key2, Value2>(3);
            OutputEncoding = System.Text.Encoding.Unicode;

            while (true)
            {
                try
                {
                    Write("оберіть:\n1 - заповнити таблицю контрольними значеннями\n" +
                        "2 - додати нову статтю\n" +
                        "3 - видалити елемент\n" +
                        "4 - вивести дані про статтю за ключем\n" +
                        "5 - відобразити дані основної геш-таблиці\n" +
                        "6 - дізнатися, чому дорівнює індекс Гірша у певного автора" +
                         "\nExit - завершити роботу: ");
                    string s = ReadLine();
                    if (s == "1")
                    {
                        (table2, table1) = Paste_Kontrol(table2, table1);
                        WriteLine("Значення вставлені успішно");
                    }
                    else if (s == "2")
                    {
                        Entry<Key1, Value1> entry = new Entry<Key1, Value1>();
                        Write("Введіть назву статті: ");
                        entry.value.Title = ReadLine();
                        Write("Введіть назву журналу: ");
                        entry.value.journalName = ReadLine();
                        Write("Введіть рік публікації: ");
                        entry.value.yearOfPublishing = Convert.ToInt32(ReadLine());
                        entry.key.doi = Make_Doi(entry.value.yearOfPublishing);
                        LinkedList authors = new LinkedList();
                        Write("Введіть кількість авторів: ");
                        int count = Convert.ToInt32(ReadLine());
                        Write($"Введіть ім'я 1 автора: ");
                        authors.Data = ReadLine();
                        LinkedList current = authors;
                        for (int i = 2; i<=count; i++)
                        {
                            Write($"Введіть ім'я {i} автора: ");
                            current.Next = new LinkedList();
                            current = current.Next;
                            current.Data = ReadLine();
                        }
                        entry.value.author = authors;
                        Write("Введіть кількість цитувань: ");
                        entry.value.numberOFCiting = Convert.ToInt32(ReadLine());
                        table1 = table1.NeedRehash(table1, 1);
                        table1.InsertEntry(entry);
                        

                        current = authors;
                        while (current!=null)
                        {
                            Entry<Key2, Value2> entry2 = new Entry<Key2, Value2>();
                            entry2.key.authorName = current.Data;
                            entry2 = table2.FindValue(entry2);
                            int HIndex = Make_HIndex( table1, current.Data);
                            if (entry2.value.HIndex != -1)
                            {
                                int ind = entry2.key.GetHashCode();
                                ind = table2.getHash(ind);
                                Entry<Key2, Value2> curr = table2.nodes[ind];
                                while (curr != null)
                                {
                                    if (curr.key.authorName == current.Data)
                                    {
                                        curr.value.HIndex = HIndex;
                                        break;
                                    }
                                    curr = curr.Next;
                                }
                            }
                            else
                            {
                                entry2.key.authorName = current.Data;
                                entry2.value.HIndex = HIndex;
                                table2 = table2.NeedRehash(table2, 2);
                                table2.InsertEntry(entry2);
                               
                            }
                            current = current.Next;
                        }    
                        
                        WriteLine("Значення вставлено успішно під ключем "+entry.key.doi);
                    }
                    else if (s == "3")
                    {
                        Entry<Key1, Value1> entr = new Entry<Key1, Value1>();
                        Write("Введіть код статті: ");

                        entr.key.doi = ReadLine();
                        entr = table1.FindValue(entr);
                        if (entr.value.Title != null)
                        {
                            table1.RemoveEntry(entr);
                            LinkedList current = entr.value.author;
                            while (current != null)
                            {
                                List <int> count = AuthorsCiting(table1, current.Data);
                                
                                Entry<Key2, Value2> e = new Entry<Key2, Value2>();
                                e.key.authorName = current.Data;
                                if (count.Count == 0)
                                {
                                    table2.RemoveEntry(e);
                                }
                                else
                                {
                                    int hearsh = Make_HIndex(table1, current.Data);
                                    int ind = e.key.GetHashCode();
                                    ind = table2.getHash(ind);
                                    Entry<Key2, Value2> curr = table2.nodes[ind];
                                    while (curr != null)
                                    {
                                        if (curr.key.authorName == current.Data)
                                        {
                                            curr.value.HIndex = hearsh;
                                            break;
                                        }
                                        curr = curr.Next;
                                    }
                                }
                                current = current.Next;
                            }
                            Write("Видалення пройшло успішно\n");
                        }  
                        else Write("Такої статті не існує\n");
                    }
                    else if (s == "4")
                    {
                    Entry<Key1, Value1> entr = new Entry<Key1, Value1>();
                    Write("Введіть код статті: ");
                    entr.key.doi = ReadLine();
                    entr = table1.FindValue(entr);
                        if (entr.value.Title != null)
                    {
                        Write($"\nНазва статті - {entr.value.Title}\nНазва журналу - {entr.value.journalName}\n" +
                            $"Рік видавництва - {entr.value.yearOfPublishing}\nКількість цитувань - {entr.value.numberOFCiting}\n" +
                            $"Автори: ");
                        LinkedList current = entr.value.author;
                        while (current!=null)
                        {
                            Write($"{current.Data}, ");
                            current = current.Next;
                        }    
                    }
                    }
                    else if (s == "5")
                    {
                    int counter = 1;
                        foreach (var elem in table1.nodes)
                    {
                        if (elem != null)
                        {
                            Write($"\n Елементи під індексом {counter}:\n");
                            var curr = elem;
                            while (curr!=null)
                            {
                                Write($"\nКод статті - {curr.key.doi}\nНазва статті - {curr.value.Title}\nНазва журналу - {curr.value.journalName}\n" +
                                   $"Рік видавництва - {curr.value.yearOfPublishing}\nКількість цитувань - {curr.value.numberOFCiting}\n" +
                                   $"Автори: ");
                                LinkedList current = curr.value.author;
                                while (current != null)
                                {
                                    Write($"{current.Data}\n");
                                    current = current.Next;
                                }
                                curr = curr.Next;
                            }
                        }
                        counter++;
                    }
                    }
                    else if (s == "6")
                    {
                        Entry<Key2, Value2> entry2 = new Entry<Key2, Value2>();
                        WriteLine("Введіть ім'я автора: ");
                        entry2.key.authorName = ReadLine();
                        entry2 = table2.FindValue(entry2);
                        Console.WriteLine("Індекс цього автора = "+entry2.value.HIndex);
                    }
                    else if (s == "Exit")
                        Environment.Exit(0);
                    else WriteLine("Переревірте правильність введених даних");
                    WriteLine("\n");
                }

                catch
                {
                    WriteLine("Переревірте правильність введених даних\n");
                }
            }
        }

        public static (HashTable<Key2, Value2> table2, HashTable<Key1, Value1> table1)
            Paste_Kontrol(HashTable<Key2, Value2> table2, HashTable<Key1, Value1> table1)
        {

            List<List<string>> kontrol = new List<List<string>>();
            List<string> new_kontr = new List<string>() {"Review of the series 'Stranger Things'", "Spectator", "2022", "Harry Potter,Ronald Weasley", "5" };
            kontrol.Add(new_kontr);
            new_kontr = new List<string>() { "Adsorption and carbon", "Ecology", "2005", "Ketty Perry,Selena Gomez", "3" };
            kontrol.Add(new_kontr);
            new_kontr = new List<string>() { "Fashion spring-summer 2002", "Vogue", "2002", "Steve Jobs", "8"};
            kontrol.Add(new_kontr);
            new_kontr = new List<string>() { "All about dogs and how they do whatever they want to do", "Zoology", "2019", "Ketty Perry", "7" };
            kontrol.Add(new_kontr);
            new_kontr = new List<string>() { "How to cook popcorn", "The darkest places in the Universe", "2022", "Karyna Salnykova", "10" };
            kontrol.Add(new_kontr);
            new_kontr = new List<string>() { "Apple: how it started", "Fruits", "2008", "Steve Jobs", "2" };
            kontrol.Add(new_kontr);

            foreach (var elem in kontrol)
            {
                Entry<Key1, Value1> entry1 = new Entry<Key1, Value1>();
              
                entry1.value.Title = elem[0];
                entry1.value.journalName = elem[1];
                entry1.value.yearOfPublishing= Convert.ToInt32(elem[2]);
                entry1.key.doi = Make_Doi(entry1.value.yearOfPublishing);
                entry1.value.numberOFCiting = Convert.ToInt32(elem[4]);
                string[] authors = elem[3].Split(',');
                LinkedList author = new LinkedList();
                author.Data = authors[0];
                LinkedList curr = author;
                for (int i =1; i<authors.Length; i++)
                {
                    curr.Next = new LinkedList();
                    curr = curr.Next;
                    curr.Data = authors[i];
                }
                entry1.value.author = author;
                table1 = table1.NeedRehash(table1, 1);
                table1.InsertEntry(entry1);

                LinkedList current = author;
                while (current != null)
                {

                    Entry<Key2, Value2> entr = new Entry<Key2, Value2>();
                    entr.key.authorName = current.Data;
                     entr = table2.FindValue(entr);
                    int HIndex = Make_HIndex( table1, current.Data);
                    if (entr.value.HIndex != -1)
                    {
                        int ind = entr.key.GetHashCode();
                        ind = table2.getHash(ind);
                        Entry<Key2, Value2> currr = table2.nodes[ind];
                        while (currr != null)
                        {
                            if (currr.key.authorName == current.Data)
                            {
                                currr.value.HIndex = HIndex;
                                break;
                            }
                            currr = currr.Next;
                        }
                    }
                    else
                    {
                        entr.key.authorName = current.Data;
                        entr.value.HIndex = HIndex;
                        table2 = table2.NeedRehash(table2, 2);
                        table2.InsertEntry(entr);
                    }
                    current = current.Next;
                }
            }

            return (table2, table1);
        }

        static int Make_HIndex (HashTable<Key1, Value1> table, string name)
        {
            List<int> index = AuthorsCiting(table, name);
             index.Sort();
            int counter = 1;
           int Hindex = 1;
                for(int j = index.Count - 1; j >= 0; j--)
                {
                    if(counter <= index[j])
                    {
                        Hindex = counter;
                    }
                    counter++;
                }
            return Hindex;
        }

        static List<int> AuthorsCiting(HashTable<Key1, Value1> table, string name)
        {
            List<int> index = new List<int>();

            foreach (var elem in table.nodes)
            {
                if (elem != null)
                {
                    LinkedList aut = new LinkedList();
                    Entry<Key1, Value1> entr = elem;
                    while (entr != null)
                    {
                        aut = entr.value.author;
                        while (aut != null)
                        {
                            if (aut.Data == name)
                            {
                                index.Add(entr.value.numberOFCiting);
                                break;
                            }
                            aut = aut.Next;
                        }
                        entr = entr.Next;
                    }
                }
            }
            return index;
        }

        static string Make_Doi(int year)
        {
            Random rnd = new Random();
            string doi = "";
            string letts = "";
            letts += letters[rnd.Next(letters.Length)];
            letts+= letters[rnd.Next(letters.Length)];
            doi += rnd.Next(10, 100)+"."+rnd.Next(10000, 100000)+"/"+letts+"."+year+"."+rnd.Next(10, 100)+"."+ rnd.Next(0, 10);
            return doi;
        }
    }
}
