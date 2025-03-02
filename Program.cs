internal class Program
{
    private struct Pokemon
    {
        private int _idx;
        public int Idx => _idx;
        private string _name;
        public string Name => _name;
        private string _type1;
        public string Type1 => _type1;
        private string _type2;
        public string Type2 => _type2;
        private int _hp;
        public int Hp => _hp;
        private int _atk;
        public int Atk => _atk;
        private int _def;
        public int Def => _def;
        private int _specialAtk;
        public int SpecialAtk => _specialAtk;
        private int _specialDef;
        public int SpecialDef => _specialDef;
        private int _speed;
        public int Speed => _speed;
        
        public Pokemon(int idx, string name, string type1, string type2, int hp, int atk, int def, int specialAtk, int specialDef, int speed)
        {
            _idx = idx;
            _name = name;
            _type1 = type1;
            _type2 = type2;
            _hp = hp;
            _atk = atk;
            _def = def;
            _specialAtk = specialAtk;
            _specialDef = specialDef;
            _speed = speed;
        }
    }

    private static Pokemon[] _pokemons = null!;

    private const int NULL = -1;
    private static int _cursor = 0;
    private static string _prefix = "";

    private static int _width = 5;
    private static int _height = 5;

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 200'000]

        _pokemons = new Pokemon[n];
        for (int i = 0; i < _pokemons.Length; ++i) // max tc = 200'000
        {
            string[] tokens = Console.ReadLine()!.Split();

            _pokemons[i] = new(i + 1,
                              tokens[0],
                              tokens[1],
                              tokens[2],
                              int.Parse(tokens[3]),
                              int.Parse(tokens[4]),
                              int.Parse(tokens[5]),
                              int.Parse(tokens[6]),
                              int.Parse(tokens[7]),
                              int.Parse(tokens[8]));
        }

        int q = int.Parse(Console.ReadLine()!); // [1, 200'000]

        for (int i = 0; i < q; ++i) // max tc = 200'000
        {
            string[] tokens = Console.ReadLine()!.Split();

            string command = tokens[0];

            if (command == "sort")
            {
                Sort(tokens[1], tokens[2] == "asc");
            }
            else if (command == "filter")
            {
                if (tokens[1] == "name")
                {
                    string prefix = tokens[2];
                    if (prefix == "BLANK")
                    {
                        _prefix = "";
                    }
                    else
                    {
                        _prefix = prefix;
                    }
                }
                else // if (tokens[1] == "type")
                {
                    
                }
            }
        }
    }

    private static void Sort(string key, bool asc)
    {
        if (key == "idx")
        {
            if (asc)
            {
                Array.Sort(_pokemons, (a, b) => a.Idx.CompareTo(b.Idx));
            }
            else
            {
                Array.Sort(_pokemons, (a, b) => b.Idx.CompareTo(a.Idx));
            }
        }
        else if (key == "hp")
        {
            if (asc)
            {
                Array.Sort(_pokemons, (a, b) => a.Hp.CompareTo(b.Hp));
            }
            else
            {
                Array.Sort(_pokemons, (a, b) => b.Hp.CompareTo(a.Hp));
            }
        }
        else if (key == "atk")
        {
            if (asc)
            {
                Array.Sort(_pokemons, (a, b) => a.Atk.CompareTo(b.Atk));
            }
            else
            {
                Array.Sort(_pokemons, (a, b) => b.Atk.CompareTo(a.Atk));
            }
        }
        else if (key == "def")
        {
            if (asc)
            {
                Array.Sort(_pokemons, (a, b) => a.Def.CompareTo(b.Def));
            }
            else
            {
                Array.Sort(_pokemons, (a, b) => b.Def.CompareTo(a.Def));
            }
        }
        else if (key == "special_atk")
        {
            if (asc)
            {
                Array.Sort(_pokemons, (a, b) => a.SpecialAtk.CompareTo(b.SpecialAtk));
            }
            else
            {
                Array.Sort(_pokemons, (a, b) => b.SpecialAtk.CompareTo(a.SpecialAtk));
            }
        }
        else if (key == "special_def")
        {
            if (asc)
            {
                Array.Sort(_pokemons, (a, b) => a.SpecialDef.CompareTo(b.SpecialDef));
            }
            else
            {
                Array.Sort(_pokemons, (a, b) => b.SpecialDef.CompareTo(a.SpecialDef));
            }
        }
        else // if (key == "speed")
        {
            if (asc)
            {
                Array.Sort(_pokemons, (a, b) => a.Speed.CompareTo(b.Speed));
            }
            else
            {
                Array.Sort(_pokemons, (a, b) => b.Speed.CompareTo(a.Speed));
            }
        }
    }
}