using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einstien
{
    //House number 1..5
    enum Color
    {
        Red,
        Green,
        White,
        Yellow,
        Blue,
    }
    enum Animal
    {
        Dog,
        Bird,
        Cat,
        Horse,
        Fish,
    }
    enum Drink
    {
        Tea,
        Coffee,
        Milk,
        Beer,
        Water,
    }
    enum Сigarette
    {
        Pallmall,
        Dunhill,
        Marlboro,
        Winfield,
        Rothmans,
    }
    enum Nationality
    {
        Norway,
        German,
        English,
        Sweden,
        Datch,
    }/*
    class House
    {
        public HouseColor house_color;
        public Animal animal;
        public Drink drink;
        public Sigarete sigarete;
        public Nationality nationality;
    }*/

    class Program
    {
        static void Main(string[] args)
        {
            var p = new Permutations();

            //var test123 = p.Create(new List<int> { 1, 2, 3 });

            var drink_permutations = p.Create<Drink>();
            var color_permutations = p.Create<Color>();
            var animal_permutations = p.Create<Animal>();
            var cigarette_permutations = p.Create<Сigarette>();
            var nationality_permutations = p.Create<Nationality>();

            int i = 0;
            //int total = 0;
            // cigarettes - 7 checks
            // nationalities -6 checks
            // colors - 6
            // drinks - 5
            // animals -4

            //drink_permutations = new List<List<Drink>> { new List<Drink> { Drink.Water, Drink.Tea, Drink.Milk, Drink.Coffee, Drink.Beer } };
            //color_permutations = new List<List<Color>> { new List<Color> { Color.Yellow, Color.Blue, Color.Red, Color.Green, Color.White } };
            //nationality_permutations = new List<List<Nationality>> { new List<Nationality> { Nationality.Norway, Nationality.Datch, Nationality.English, Nationality.German, Nationality.Sweden } };
            //animal_permutations = new List<List<Animal>> { new List<Animal> { Animal.Cat, Animal.Horse, Animal.Bird, Animal.Fish, Animal.Dog } };
            //cigarette_permutations = new List<List<Сigarette>> { new List<Сigarette> { Сigarette.Dunhill, Сigarette.Marlboro, Сigarette.Pallmall, Сigarette.Rothmans, Сigarette.Winfield } };

            foreach (var cigarettes in cigarette_permutations)
            {
                System.Console.WriteLine(i++);
                foreach (var nationalities in nationality_permutations)
                {
                    // 9. Norway is in the first house
                    if (0 != nationalities.IndexOf(Nationality.Norway))
                        continue;

                    // 14. German - Rothmans
                    if (nationalities.IndexOf(Nationality.German) != cigarettes.IndexOf(Сigarette.Rothmans))
                        continue;

                    foreach (var colors in color_permutations)
                    {
                        // 1. English in Red house
                        if (nationalities.IndexOf(Nationality.English) != colors.IndexOf(Color.Red))
                            continue;

                        // 4. Green house is to the left of the while
                        if ((colors.IndexOf(Color.Green) + 1) != colors.IndexOf(Color.White))
                            continue;

                        // 8. Yellow - Dunhill
                        if (colors.IndexOf(Color.Yellow) != cigarettes.IndexOf(Сigarette.Dunhill))
                            continue;

                        // 13. Norway is near Blue
                        if ((nationalities.IndexOf(Nationality.Norway) + 1 != colors.IndexOf(Color.Blue)) &&
                            (nationalities.IndexOf(Nationality.Norway) != colors.IndexOf(Color.Blue) + 1))
                            continue;

                        foreach (var drinks in drink_permutations)
                        {
                            // 7
                            if (2 != drinks.IndexOf(Drink.Milk))
                                continue;

                            // 3
                            if (nationalities.IndexOf(Nationality.Datch) != drinks.IndexOf(Drink.Tea))
                                continue;

                            // 5
                            if (colors.IndexOf(Color.Green) != drinks.IndexOf(Drink.Coffee))
                                continue;

                            // 12
                            if (cigarettes.IndexOf(Сigarette.Winfield) != drinks.IndexOf(Drink.Beer))
                                continue;

                            // 15
                            if ((cigarettes.IndexOf(Сigarette.Marlboro) + 1 != drinks.IndexOf(Drink.Water)) &&
                                (cigarettes.IndexOf(Сigarette.Marlboro) != drinks.IndexOf(Drink.Water) + 1))
                                continue;

                            foreach (var animals in animal_permutations)
                            {
                                // 2. Sweden holds dog
                                if (nationalities.IndexOf(Nationality.Sweden) != animals.IndexOf(Animal.Dog))
                                    continue;

                                // 6
                                if (cigarettes.IndexOf(Сigarette.Pallmall) != animals.IndexOf(Animal.Bird))
                                    continue;

                                // 10
                                if ((cigarettes.IndexOf(Сigarette.Marlboro) + 1 != animals.IndexOf(Animal.Cat)) &&
                                    (cigarettes.IndexOf(Сigarette.Marlboro) != animals.IndexOf(Animal.Cat) + 1))
                                    continue;

                                // 11
                                if ((cigarettes.IndexOf(Сigarette.Dunhill) + 1 != animals.IndexOf(Animal.Horse)) &&
                                    (cigarettes.IndexOf(Сigarette.Dunhill) != animals.IndexOf(Animal.Horse) + 1))
                                    continue;


                                System.Console.WriteLine(string.Join(" ", drinks));
                                System.Console.WriteLine(string.Join(" ", colors));
                                System.Console.WriteLine(string.Join(" ", animals));
                                System.Console.WriteLine(string.Join(" ", cigarettes));
                                System.Console.WriteLine(string.Join(" ", nationalities));
                            }
                        }
                    }
                }
            }
            //System.Console.WriteLine("Total checks: " + total);
        }
    }
}
