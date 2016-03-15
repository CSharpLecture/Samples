using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a nice guy
            NiceGuy m = new NiceGuy();
            //Create a bad guy
            BadGuy b = new BadGuy(3);

            //Let each of them use their own implementation of the Hero-warcry
            m.warCry();
            b.warCry();

            //set the strength with a property
            m.Strength = 4;
            //test the fallback 
            m.Strength = -10;

            //the old fashioned way of doing properties in e.g. C++
            m.setStrength(4);

            //cast the niceguy to its interface
            ((IHaveAwesomeWeapon)m).useThisAwesomeWeapon();

            //let him save the princess
            m.savePrincess();

            //let the niceguy attack the bad guy with the Hero-attack-method
            m.attack(b);
            //let him jump
            m.jump();

            //use the new implementation of badguys attack
            b.attack(m);

            //Explicitly use the Hero-attack method of bad guy
            ((Hero)b).attack(m);


            //generic swap method - finds value of T by itself
            swap(ref m, ref m);

            //swap(ref b, ref b); //does not work because of where T : new()
           

        }

        //generic swap method for heros . . . will only work for niceguy as badguys does not have a default constructor
        public static void swap<T>(ref T a, ref T b) where T : Hero, new()
        {
            T t = a;
            a = b;
            b = t;
            T nt = new T(); //just for demo purposes
        }
        

    }

    //abstract class Hero
    abstract class Hero
    {
        int HP;
        public readonly string name; //can only be set in the constructor of this class

        //not so good. Start with it but change it to the lower case (Strength) as soon as needed.
        public int X { get; set; }

        //field for the property
        int strength;

        //property
        public int Strength
        {
            get //to get the value int s = this.Strength
            {
                return strength;
            }
            set //to set the value this.Strength = 5;
            {
                if (value > 0) //a boundary condition to be fullfilled before setting the value
                    strength = value;
                else //fallback
                    Console.WriteLine("Nope, no values smaller 0 allowed");
            }
        }

        //only for demo how it was done in languages without properties
        public void setStrength(int value)
        {
            strength = value; 
        }

        //constructor 1
        public Hero(int HP)
        {
            this.HP = HP;
            this.Strength = 5;
        }
        //constructor 2
        public Hero(string s)
        {
            this.name = s;
        }

        //constructor 3
        public Hero(int HP, string n)
        {
            this.HP = HP;
            name = n;
        }
        //attack method which can already be used in child-classes
        public virtual void attack(Hero b)
        {
            Console.WriteLine(this.name + " attacks "+ b.name);
        }
        //abstract method which HAS TO BE implemented in child class
        public abstract void warCry();

        //some other method
        public virtual void savePrincess()
        {
            Console.WriteLine(this.name + "saves the princess.");
        }

    }

    //Nice guy, inherits from Hero and interface IHaveAwesomeWeapon
    class NiceGuy : Hero, IHaveAwesomeWeapon
    {
        //additionally to usual behaviour he can jump
        bool jumping;

        //constructor 1 - calling base constructor 3
        public NiceGuy(int hp, bool jmp) : base(hp, "NiceGuy")
        {
            jumping = jmp;
        }
        //default/empty constructor - calling base constructor 3 
        public NiceGuy() : this(3,true)
        {
           
        }

        //additional jump method
        public void jump()
        {
            Console.WriteLine("NiceGuy is jumping");
            jumping = !jumping;
        }

        //implementation of the Hero warcry
        public override void warCry()
        {
            Console.WriteLine("NiceGuy!");
        }
        //implementation of the interface
        public void useThisAwesomeWeapon()
        {
            Console.WriteLine("Awesome booster in use");
        }
    }

    //Badguy - nevertheless a hero
    class BadGuy : Hero
    {
        //no default constructor provided - only this one
        public BadGuy(int HP) : base(HP, "BadGuy")
        {
           
        }
        //has another attack method which is NEW.
        //it doesnot override the hero method, which means we can also use this one when casting badguy to hero
        public new void attack(Hero b)
        {
            base.attack(b);
            Console.WriteLine("Muhahaha this was BadGuy");
        }

        //implementation of the warcry
        public override void warCry()
        {
            Console.WriteLine("BadGuy!");
        }

        //test function - look at BabyBadGuy and remove the virtual keyword
        public virtual void test()
        {
            ;
        }
    }

    //just to prove the point that the virtual keyword is needed to override a function
    class BabyBadGuy : BadGuy
    {
        public BabyBadGuy() : base(1)
        {

        }
        public override void test()
        {
            base.test();
        }
    }

    //a demo of an interface
    internal interface IHaveAwesomeWeapon
    {
        void useThisAwesomeWeapon();
    }

}
