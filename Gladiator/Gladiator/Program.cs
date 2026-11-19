using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int health1, health2, armor1, armor2, attack1, attack2, kicks, flag;

            Console.Write("Введите показатель здоровья для первого гладиатора: ");
            health1 = int.Parse(Console.ReadLine());
            Console.Write("Введите показатель здоровья для второго гладиатора: ");
            health2 = int.Parse(Console.ReadLine());
            Console.Write("Введите показатель брони для первого гладиатора в процентах: ");
            armor1 = int.Parse(Console.ReadLine());
            Console.Write("Введите показатель брони для второго гладиатора в процентах: ");
            armor2 = int.Parse(Console.ReadLine());

            Console.WriteLine();

            kicks = 0;

            while (true)
            {
                kicks++;
                Console.Clear();
                Console.WriteLine($"--- РАУНД {kicks} ---");

                attack1 = rnd.Next(0, armor2);
                attack2 = rnd.Next(0, armor1);

                Console.WriteLine($"Случ. урон второго гладиатора: {attack2}");
                Console.WriteLine($"Наненсённый урон первому: {attack2 - attack2 * armor1 / 100}");
                health1 = health1 - (attack2 - attack2 * armor1 / 100);
                Console.WriteLine($"Здоровье первого: {health1}");

                Console.WriteLine();

                Console.WriteLine($"Случ. урон первого: {attack1}");
                Console.WriteLine($"Наненсённый урон второму: {attack1 - attack1 * armor2 / 100}");
                health2 = health2 - (attack1 - attack1 * armor2 / 100);
                Console.WriteLine($"Здоровье второго: {health2}");
                
                System.Threading.Thread.Sleep(5000);

                if ((health2 <= 0) && (health1 <= 0))
                {
                    flag = 0;
                    break;
                }
                if (health2 <= 0)
                {
                    flag = 1;
                    break;
                }
                if (health1 <= 0)
                {
                    flag = 2;
                    break;
                }
            }
            Console.Clear();

            if (flag == 0)
            {
                Console.WriteLine($"Проиграли оба гладиатора, ударов наненсено {kicks}");
            }

            if (flag == 1)
            {
                Console.WriteLine($"Победил первый гладиатор, ударов наненсено {kicks}");
            }
            if (flag == 2)
            {
                Console.WriteLine($"Победил второй гладиатор, ударов наненсено {kicks}");
            }
        }
    }
}
