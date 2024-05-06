namespace WebApp;
using Xunit;
using Xunit.Abstractions;
public class UtilsTest
{
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
    [Theory]
    [InlineData("fuck you, you shit", "happy bunnies", "happy bunnies you, you happy bunnies")]
    [InlineData("asshole, i dont like you bitch", "flowers", "flowers, i dont like you flowers")]
    public void TestRemoveBadWords(string badText, string replacement, string niceText)
    {
        Assert.Equal(niceText, Utils.RemoveBadWords(badText, replacement));
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
        // WILL take 5-10 min if no users added due to encryption
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

    // method 3.5
    [Fact]
    public void TestEncryption()
    {
        Random rnd = new();
        Arr passwordsInDb = SQLQuery("select password from users");

    }
}