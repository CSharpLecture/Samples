using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //create one Horde
            TrollHorde Umpas = new TrollHorde(11, "Umpas");
            Umpas[3].roar();

            //go through with foreach
            foreach (Troll t in Umpas)
                t.roar();
            //use a LINQ request
            Umpas.Where(x => x.Name == "Umpas-Troll #4").Select(x => { x.roar(); return 0; }).ToList(); ;

            //create another Horde
            var Olas = new TrollHorde(5, "Olas");

            //add the two Hordes
            var BattleRaid = Olas.Concat(Umpas);

            //go through the union
            foreach (Troll t in BattleRaid)
                t.roar();

            Console.ReadKey();
        }
    }

    //a simple Troll
    class Troll
    {
        public string Name;
        public void roar()
        {
            Console.WriteLine(Name + " roared furiously!");
        }
    }

    //a Trollhorde - here we want to be able to use foreach and LINQ
    class TrollHorde : IEnumerable<Troll> //we inherit from IEnumerble<Troll> as we want to iterate through trolls
    {
        public Troll[] Horde; //internal array of trolls

        //constructor
        public TrollHorde(int a, string breed)
        {
            Horde = new Troll[a];
            for (int i = 0; i < Horde.Length; i++)
                Horde[i] = new Troll() { Name = breed.ToString() + "-Troll #" + i.ToString() };
        }

        //make an indexer
        public Troll this[int index]
        {
            get { return Horde[index]; }
            set { Horde[index] = value; }
        }

        //use yield statement
        public IEnumerator<Troll> GetEnumerator()
        {
            //this function returns an Ienumerator<Troll>
            return getEnumForTrolls();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return getEnumForTrolls();
        }
        //this "builds" the enumerator for us
        public IEnumerator<Troll> getEnumForTrolls()
        {
            for (int i = 0; i < Horde.Length; i++)
                yield return Horde[i]; //we simply go through the array. Yield takes care of the rest
        }

        //different implementation using another class for the Enumerator to show the difference in code
        //use IEnumerator<Troll> below
        /*public IEnumerator<Troll> GetEnumerator()
        {
            return new TrollCounter(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new TrollCounter(this);
        }*/
    }


    //full blown with IEnumerator - yield implementation is much easier! See above
    /*class TrollCounter : IEnumerator<Troll>
    {
        private TrollHorde trollHorde;
        private int cnt = -1;
        public TrollCounter(TrollHorde trollHorde)
        {
            // TODO: Complete member initialization
            this.trollHorde = trollHorde;
        }
        public Troll Current
        {
            get { return trollHorde.Horde[cnt]; }
        }

        public void Dispose()
        {
            cnt = 0;
        }

        object IEnumerator.Current
        {
            get { return trollHorde.Horde[cnt]; }
        }

        public bool MoveNext()
        {
            return cnt++ < trollHorde.Horde.Length-1;
        }

        public void Reset()
        {
            cnt = 0;
        }
    }
    */

    //just for dumping purposes
    static class ext
    {
        public static void Dump(this object o)
        {
            Console.WriteLine(o.ToString());
            if (o is IEnumerable)
            {
                foreach (var oElem in ((IEnumerable)o))
                    Console.WriteLine(oElem.ToString());
            }
        }
    }
}
