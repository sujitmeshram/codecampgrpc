using Grpc.Net.Client;
using AdderService;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Set up channels for both services
        var adderChannel = GrpcChannel.ForAddress("https://localhost:7199");
        var stringChannel = GrpcChannel.ForAddress("https://localhost:7201");

        var adderClient = new  ServiceAdder.ServiceAdderClient(adderChannel);
        var stringClient = new ServiceString.ServiceStringClient(stringChannel);

        // Get input from user
        Console.WriteLine("Enter two integers to add:");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        // Call the AdderService
        var addResponse = await adderClient.AddAsync(new AddRequest { A = a, B = b });
        Console.WriteLine($"Addition result: {addResponse.Result}");

        // Get string input from user
        Console.WriteLine("Enter two strings to concatenate:");
        string str1 = Console.ReadLine();
        string str2 = Console.ReadLine();

        // Call the StringService
        var concatResponse = await stringClient.ConcatenateAsync(new ConcatenateRequest { Str1 = str1, Str2 = str2 });
        Console.WriteLine($"Concatenation result: {concatResponse.Result}");
        Console.ReadKey();
    }
}
