using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

[Command(Description ="Programm description", Name ="Test App")]
[HelpOption("-?|--help")]
public class Program
{
    [Required]
    [Option("-n|--name", CommandOptionType.SingleValue, Description = "Name")]
    public string Name { get; set; }

    [Option("-d|--debug", CommandOptionType.SingleOrNoValue, Description = "Debug")]
    public bool Debug { get; set; }

    [Option("-p|--phone", CommandOptionType.MultipleValue, Description = "Phones")]
    public string[] Phones { get; set; }

    public static void Main(string[] args) 
        => CommandLineApplication.Execute<Program>(args);

    public void OnExecute()
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Debug: " + Debug);
        if (Phones != null)
        {
            Console.WriteLine("Phones: " + string.Join(" ", Phones));
        }
        else
        {
            Console.WriteLine("Phones empty");
        }
    }
}
