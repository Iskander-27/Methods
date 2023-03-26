using System;

class MainClass
{
    public static void Main(string[] args)
    {
        EnterUser();
    }

    static (string name, string lastname, int age, string[] petcount, string[] favcolor) EnterUser()
    {
        (string name, string lastname, int age, string[] petcount, string[] favcolor) User;

        Console.WriteLine("Введите имя");
        User.name = Console.ReadLine();

        Console.WriteLine("Введите фамилию");
        User.lastname = Console.ReadLine();

        string age;
        int intage;

        do
        {
            Console.WriteLine("Введите возраст цифрами");
            age = Console.ReadLine();
        }
        while (CheckNum(age, out intage));

        User.age = intage;

        Console.WriteLine("Есть ли питомец?(да/нет)");
        string pet = Console.ReadLine();

        string num;
        int intnum;

        if (pet == "Да" || pet == "да")
        {
            do
            {
                Console.WriteLine("Введите количество питомцев");
                num = Console.ReadLine();
            }
            while (CheckNum(num, out intnum));
            User.petcount = CreateArrayPets(intnum);
        }
        else
        {
            User.petcount = null;
        }

        string colorcount;
        int intcolor;

        do
        {
            Console.WriteLine("Введите количество любимых цветов");
            colorcount = Console.ReadLine();
        }
        while (CheckNum(colorcount, out intcolor));

        User.favcolor = ShowColor(intcolor);

        TheEnd(in User.name, in User.lastname, in User.age, in User.petcount,in User.favcolor);

        return User;
    }

    static bool CheckNum(string number, out int cornumber)
    {
        if (int.TryParse(number, out int intnum))
        {
            if (intnum > 0)
            {
                cornumber = intnum;
                return false;
            }
        }
        {
            cornumber = 0;
            return true;
        }
    }

    static string[] CreateArrayPets(int intnum)
    {
        var array = new string[intnum];
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Введите кличку животного номер {0}", i + 1);
            array[i] = Console.ReadLine();
        }

        return array;
    }

    static string[] ShowColor(int intnum)
    {
        var array = new string[intnum];
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Введите свой любимый цвет номер {0}", i + 1);
            array[i] = Console.ReadLine();
        }

        return array;
    }

    static void TheEnd(in string name, in string lastname, in int age, in string[] petcount, in string[] favcolor)
    {
        Console.WriteLine("Имя: {0}", name);
        Console.WriteLine("Фамилия: {0}", lastname);
        Console.WriteLine("Возраст: {0}", age);
        if (petcount != null)
        {
            Console.WriteLine("Есть животные:");
            foreach(var pet in petcount)
            {
                Console.WriteLine(pet);
            }
        }
        else
        {
            Console.WriteLine("Животные отсутствуют");
        }
        Console.WriteLine("Любимые цвета:");
        foreach(var color in favcolor)
        {
            Console.WriteLine(color);
        }
    }
}