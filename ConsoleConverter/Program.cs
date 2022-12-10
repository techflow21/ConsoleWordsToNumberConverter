namespace ConsoleConverter
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("\n\tEnter words to convert to number\n\tFormat: eighteen billion fifteen million three thousand five hundred sixty two): ");

                var strNumber = Console.ReadLine();

                long rtnNumber = WordsToNumbers.ConvertToNumbers(strNumber);

                Console.WriteLine("Number is {0}", rtnNumber);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}