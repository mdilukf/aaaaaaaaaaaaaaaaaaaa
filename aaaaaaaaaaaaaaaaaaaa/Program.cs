using System;
using System.Collections.Generic;
using System.Threading;

public delegate void MethodContainer();
class Lampa
{
    public bool sostojanie = false;
    public int number;
    public event MethodContainer Peregarela;

    public void PeregorelLamp()
    {
        if (sostojanie)
        {
            Console.WriteLine("Я перегорела");
            sostojanie = false;
            Peregarela();
        }
        
    }
    
    public void TokOn()
    {
        if(sostojanie)
        {
            Console.WriteLine("Я загорелась");
        }      
        
    }
    public void TokOff()
    {
        if (sostojanie)
        {
            Console.WriteLine("Я потухла");
        }
    }
}
class Kluch
{
    public bool sostoianie = false;
    public int number;
    public event MethodContainer On;
    public event MethodContainer Off;

    public void KluchOn()
    {
        if (!sostoianie)
        {
            Console.WriteLine("Я замкнут");
            sostoianie = true;
            On();
        }
        
       
    }
    public void KluchOff()
    {
        if (sostoianie)
        {
            Console.WriteLine("Я не замкнут");
            sostoianie = false;
            Off();
        }
       
        
    }
}

class Zepi
{
    public bool sostLamp1;
    public bool sostLamp2;
    public bool sostLamp3;
    public bool sostKluch1;
    public bool sostKluch2;


    public event MethodContainer TokOffOneKontur; 
    public event MethodContainer TokOnOneKontur;
    public event MethodContainer TokOffTwoKontur;
    public event MethodContainer TokOnTwoKontur;

    public void KluchOneOn()
    {
        if (sostKluch1 && sostLamp1 && sostLamp3 && sostKluch2)
        {
            
                Console.WriteLine("Во мне есть ток");
                TokOnOneKontur();
            
        }
        if (sostKluch1)
        {
            if (sostLamp2)
            {
                Console.WriteLine("Во мне есть ток");
                TokOnOneKontur();
            }
        }


    }
    public void KluchTwoOnKonturOne()
    {
        if (sostKluch2)
        {
            if (sostLamp1 && sostLamp3 && sostKluch1)
            {
                Console.WriteLine("Во мне есть ток");
                TokOnOneKontur();
            }


        }


    }
    public void KluchOneOff()
    {
        if (!sostKluch1)
        {
            if (sostLamp1 && sostLamp3 && sostKluch2)
            {
                Console.WriteLine("Во мне нету тока");
                TokOffOneKontur();
            }

        }
        if (!sostKluch1)
        {
            if (sostLamp2)
            {
                Console.WriteLine("Во мне нету тока");
                TokOffOneKontur();
            }
        }


    }
    public void KluchTwoOffKonturOne()
    {
        if (!sostKluch2)
        {
            if (sostLamp1 && sostLamp3 && sostKluch1)
            {
                Console.WriteLine("Во мне нету тока");
                TokOffOneKontur();
            }


        }


    }
    
    public void PeregorelLamp1()
    {
        sostLamp1 = false;
        if (sostKluch1 && sostLamp3 && sostKluch2)
        {
            Console.WriteLine("Во мне нету тока");
            TokOffOneKontur();
        }
        

    }
    public void PeregorelLamp2()
    {
        sostLamp1 = false;
        if (sostKluch1)
        {
            Console.WriteLine("Во мне нету тока");
            TokOffTwoKontur();
        }
        

    }
    public void PeregorelLamp3()
    {
        sostLamp1 = false;
        if (sostKluch1 && sostLamp1 && sostKluch2)
        {
            Console.WriteLine("Во мне нету тока");
            TokOffOneKontur();
        }


    }
}

class Program
{
    static void Main(string[] args)
    {
        Lampa lampa1 = new Lampa();
        Lampa lampa2 = new Lampa();
        Lampa lampa3 = new Lampa();
        Kluch kluch1 = new Kluch();
        Kluch kluch2 = new Kluch();
        Zepi zepi = new Zepi();

        lampa1.Peregarela += zepi.PeregorelLamp1;
        lampa2.Peregarela += zepi.PeregorelLamp2;
        lampa3.Peregarela += zepi.PeregorelLamp3;

        kluch1.On += zepi.KluchOneOnKonturOne;
        kluch1.Off += zepi.KluchOneOffKonturOne;
        kluch2.On += zepi.KluchOneOnKonturOne;
        kluch2.Off += zepi.KluchOneOffKonturOne;

        zepi.TokOffOneKontur += lampa1.TokOff;
        zepi.TokOffOneKontur += lampa3.TokOff;

        zepi.TokOnOneKontur += lampa1.TokOn;
        zepi.TokOnOneKontur += lampa3.TokOn;

        zepi.TokOffTwoKontur += lampa2.TokOff;
        zepi.TokOnTwoKontur += lampa2.TokOn;

        Console.WriteLine("Выберите пункт:");
        Console.WriteLine("1 - лампа 1 работает");
        Console.WriteLine("2 - лампа 2 работает");
        Console.WriteLine("3 - лампа 3 работает");
        Console.WriteLine("4 - лампа 1 не работает");
        Console.WriteLine("5 - лампа 2 не работает");
        Console.WriteLine("6 - лампа 3 не работает");
        Console.WriteLine("7 - лампа 1 перегорела");
        Console.WriteLine("8 - лампа 2 перегорела");
        Console.WriteLine("9 - лампа 3 перегорела");
        Console.WriteLine("0 - выход из цепи");
        int n = int.Parse(Console.ReadLine());

        while (n != 0)
        {
            if (n == 1)
            {
                zepi.sostKluch1.sostoianie = true;
                zepi.sostKluch2.sostoianie = true;
                zepi.sostLamp1.sostojanie = true;
                zepi.sostLamp2.sostojanie = true;
                zepi.sostLamp3.sostojanie = true;
                zepi.sostKluch1.KluchOn();
                zepi.sostKluch2.KluchOn();
            }
            if (n == 2)
            {
                zepi.sostKluch1.sostoianie = true;
                zepi.sostKluch2.sostoianie = true;
                zepi.sostLamp1.sostojanie = true;
                zepi.sostLamp2.sostojanie = true;
                zepi.sostLamp3.sostojanie = true;
                zepi.sostKluch1.KluchOn();
                zepi.sostKluch2.KluchOn();
            }
            if (n == 3)
            {
                zepi.sostKluch1.sostoianie = true;
                zepi.sostKluch2.sostoianie = true;
                zepi.sostLamp1.sostojanie = true;
                zepi.sostLamp2.sostojanie = true;
                zepi.sostLamp3.sostojanie = true;
                zepi.sostKluch1.KluchOn();
                zepi.sostKluch2.KluchOn();
            }
            if (n == 4)
            {
                zepi.sostLamp1.sostojanie = true;
                zepi.sostLamp2.sostojanie = true;
                zepi.sostLamp3.sostojanie = true;
                if (!zepi.sostKluch1.sostoianie)
                {
                    zepi.sostKluch1.KluchOff();
                }
                if (!zepi.sostKluch2.sostoianie)
                {
                    zepi.sostKluch2.KluchOff();
                }
            }
            if (n == 5)
            {
                zepi.sostLamp1.sostojanie = true;
                zepi.sostLamp2.sostojanie = true;
                zepi.sostLamp3.sostojanie = true;
                if (!zepi.sostKluch1.sostoianie)
                {
                    zepi.sostKluch1.KluchOff();
                }
                if (!zepi.sostKluch2.sostoianie)
                {
                    zepi.sostKluch2.KluchOff();
                }
            }
            if (n == 6)
            {
                zepi.sostLamp1.sostojanie = true;
                zepi.sostLamp2.sostojanie = true;
                zepi.sostLamp3.sostojanie = true;
                if (!zepi.sostKluch1.sostoianie)
                {
                    zepi.sostKluch1.KluchOff();
                }
                if (!zepi.sostKluch2.sostoianie)
                {
                    zepi.sostKluch2.KluchOff();
                }
            }
            if (n == 7)
            {
                zepi.sostLamp1.sostojanie = false;
                zepi.sostLamp2.sostojanie = true;
                zepi.sostLamp3.sostojanie = true;
                zepi.PeregorelLamp1();
            }
            if (n == 8)
            {
                zepi.sostLamp1.sostojanie = true;
                zepi.sostLamp2.sostojanie = false;
                zepi.sostLamp3.sostojanie = true;
                zepi.PeregorelLamp2();

            }
            if (n == 9)
            {
                zepi.sostLamp1.sostojanie = true;
                zepi.sostLamp2.sostojanie = true;
                zepi.sostLamp3.sostojanie = false;
                zepi.PeregorelLamp3();
            }
            Console.WriteLine("Выберите пункт:");
            Console.WriteLine("1 - лампа 1 работает");
            Console.WriteLine("2 - лампа 2 работает");
            Console.WriteLine("3 - лампа 3 работает");
            Console.WriteLine("4 - лампа 1 не работает");
            Console.WriteLine("5 - лампа 2 не работает");
            Console.WriteLine("6 - лампа 3 не работает");
            Console.WriteLine("7 - лампа 1 перегорела");
            Console.WriteLine("8 - лампа 2 перегорела");
            Console.WriteLine("9 - лампа 3 перегорела");
            Console.WriteLine("0 - выход из цепи");
            n = int.Parse(Console.ReadLine());
        }

        Console.ReadLine();

    }

}