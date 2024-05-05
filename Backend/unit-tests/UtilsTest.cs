namespace WebApp;
using Xunit;
using Xunit.Abstractions;
public class UtilsTest
{
    // The following lines are needed to get 
    // output to the Console to work in xUnit tests!
    // (also needs the using Xunit.Abstractions)
    // Note: You need to use the following command line command 
    // dotnet test --logger "console;verbosity=detailed"
    // for the logging to work
    private readonly ITestOutputHelper output;
    public UtilsTest(ITestOutputHelper output)
    {
        this.output = output;
    }

    // METOD 1 
    [Theory]
    [InlineData("testPassword1234", false)]
    [InlineData("testPassword1234%", true)]
    [InlineData("testPa!", false)]

    public void TestIsPasswordStrongEnough(string password, bool result)
    {
        Assert.Equal(Utils.IsPasswordStrongEnough(password), result);
    }

    // metod 2
    [Fact]
    public void TestRemoveBadWords()
    {
        string badText = "fuck you, you shit";
        string replacement = "happy bunnies";
        string goodText = "happy bunnies you, you happy bunnies";
        Assert.Equal(goodText, Utils.RemoveBadWords(badText, replacement));
    }

    // METOD 3
    [Fact]
    public void TestCreateMockUsers()
    {
        // Read all mock users from the JSON file
        var read = File.ReadAllText(FilePath("json", "mock-users.json"));
        Arr mockUsers = JSON.Parse(read);
        // Get all users from the database
        Arr usersInDb = SQLQuery("SELECT email FROM users");
        Arr emailsInDb = usersInDb.Map(user => user.email);
        // Only keep the mock users not already in db
        Arr mockUsersNotInDb = mockUsers.Filter(
            mockUser => !emailsInDb.Contains(mockUser.email)
        );
        // Get the result of running the method in our code
        var result = Utils.CreateMockUsers();
        // Assert that the CreateMockUsers only return
        // newly created users in the db
        output.WriteLine($"The test expected that {mockUsersNotInDb.Length} users should be added.");
        output.WriteLine($"And {result.Length} users were added.");
        output.WriteLine("The test also asserts that the users added " +
            "are equivalent (the same) to the expected users!");
        Assert.Equivalent(mockUsersNotInDb, result);
        output.WriteLine("The test passed!");
    }
}