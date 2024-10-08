using nfind;

namespace NFind
{
     public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length==0)
            {
                Console.WriteLine("FIND: Parameter format not correct");
                return;
            }
            var findOptions = BuiltOptions(args);

            var source = LineSourceFactory.CreateInstance(findOptions.Path, findOptions.ShipOfflineFiles);
            foreach (var file in source) 
            {
                ProcessSource(file, findOptions);
            }
        }

        private static void ProcessSource(ILineSource file, FindOptions findOptions)
        {
            var stringComparison = findOptions.IsCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            file = new FilterLineSource(file,
                (line)=> findOptions.FindDontContains ? !line.Text.Contains(findOptions.StringToFind, stringComparison) : line.Text.Contains(findOptions.StringToFind, stringComparison)
            );
            Console.WriteLine($"---------- {file.Name.ToUpper()}");
            try
            {
                file.Open();
                var line = file.ReadLine();
                while (line != null)
                {
                    Print(line,findOptions.ShowLineNumber);
                    line = file.ReadLine();
                }
            }
            finally { file.Close(); }
        }

        private static void Print(Line line, bool printLinrNumber)
        {
            if (printLinrNumber)
            {
                Console.WriteLine($"[{line.LineNumber}], {line.Text}");
            }
            else
            {
                Console.WriteLine($"{line.Text}");
            }
        }

        public static FindOptions BuiltOptions(string[] args)
        {
            var options = new FindOptions();
            foreach (var arg in args) {
                if (arg == "/v")
                {
                    options.FindDontContains = true;
                }
                else if (arg == "/c")
                {
                    options.CountMode = true;
                }
                else if (arg == "/n")
                {
                    options.ShowLineNumber = true;
                }
                else if (arg == "/i")
                {
                    options.IsCaseSensitive = true;
                }
                else if (arg == "/off" || arg == "/offline")
                {
                    options.ShipOfflineFiles = true;
                }
                else if (arg == "/?")
                {
                    options.HelpMode = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(options.StringToFind))
                    {
                        options.StringToFind = arg;
                    }
                    else if (string.IsNullOrEmpty(options.Path))
                    {
                        options.Path = arg;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
            }
            return options;
        }
    }
}
