namespace oop_mini_project
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] file = ReadFile("values.csv");
            List<Person> people = new List<Person>();
            people = GetPeople(file);
            PrintPeople(people);
            Console.ReadKey();
        }

        static string[] ReadFile(string path)
        {
            string[] fileOutput = System.IO.File.ReadAllLines(path);
            return fileOutput;
        }
        static List<Person> GetPeople(string[] file)
        {
            Dictionary<int, List<string>> file_items = new Dictionary<int, List<string>>();
            List<Person> people = new List<Person>();

            for (int i = 0; i < file.Length; i++) file_items.Add(i, GetItem(file[i]));


            for (int i = 1; i < file.Length; i++)
            {
                //Person p;
                string firstname = "", lastname = "", occupation = "";
                int age = 0;

                for (int j= 0; j< file_items[0].Count(); j++)
                {
                    switch (file_items[0][j])
                    {
                        case "firstname":
                            firstname = file_items[i][j];
                            break;
                        case "lastname":
                            lastname = file_items[i][j];
                            break;
                        case "occupation":
                            occupation = file_items[i][j];
                            break;
                        case "age":
                            age = int.Parse(file_items[i][j]);
                            break;
                        default:
                            Console.WriteLine($"header {file_items[0][j]} is an invalid header");
                            break;
                    }
                }

                Person p = new Person(firstname, lastname, occupation, age);
                people.Add(p);

            }

            return new List<Person>(people);
        }
        static List<String> GetItem(string line)
            {
                string current_word = "";
                List<string> items = new List<string>();
                foreach (char w in line)
                {
                    if (w == ',')
                    {
                        if (current_word != "")
                        {
                            items.Add(current_word);
                            current_word = "";

                        }
                    }
                    else
                    {
                        current_word += w.ToString();
                    }
                }
                if (current_word != "") items.Add(current_word);
                return new List<String>(items);
            }

        static void PrintPeople(List<Person> people)
        {
            foreach (Person person in people)
            {
                Console.WriteLine($"{person. Firstname} {person.Lastname} is {person.Age.ToString()} years old and work as a(n) {person.Occupation}");
            }
        }
        
    }
}