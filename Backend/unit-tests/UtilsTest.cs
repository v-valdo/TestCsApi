namespace WebApp;
public class UtilsTest(xLog output)
{
    // METOD 1 
    [Theory]
    [InlineData("testPassword1234", false)]
    [InlineData("testPassword1234%", true)]
    [InlineData("testPa!", false)]
    [InlineData("testÄrens!1234", true)]
    public void TestIsPasswordStrongEnough(string password, bool result)
    {
        Assert.Equal(Utils.IsPasswordStrongEnough(password), result);
    }

    // metod 2
    [Theory]
    [InlineData("fuck you, you shit", "happy bunnies", "happy bunnies you, you happy bunnies")]
    [InlineData("asshole, i dont like you bitch", "flowers", "flowers, i dont like you flowers")]
    [InlineData("fucking FUCKER, i dont like your doorknob", "---", "--- ---, i dont like your doorknob")]

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

        output.WriteLine("checks that users added are equivalent to the expected users");
        Assert.Equivalent(mockUsersNotInDb, result);
        output.WriteLine("Test Passed");
    }

    // method 3.5 -- tests 10 encryptions of passwords
    [Fact]
    public void TestPasswordGenerationAndEncryption()
    {
        Arr users = SQLQuery("select email, password from users limit 10");
        foreach (var user in users)
        {
            string passswordBeforeEncryption = Utils.GeneratePasswordFromEmail(user.email);
            output.WriteLine("before encr: " + passswordBeforeEncryption);
            string encryptedPassword = Password.Encrypt(passswordBeforeEncryption);
            Assert.True(Password.Verify(passswordBeforeEncryption, encryptedPassword));
        }
    }

    // method 4
    // [Fact(Skip = "improveTime")] // to skip!
    [Fact]
    public void TestRemoveMockUsers()
    {
        var read = File.ReadAllText(FilePath("json", "mock-users.json"));
        Arr mockUsers = JSON.Parse(read);
        var removedMockUsers = Utils.RemoveMockUsers();

        Arr removedMockUserEmails = removedMockUsers.Map(user => user.email);

        Arr remainingUsersInDb = SQLQuery("select email from users");

        foreach (var user in removedMockUsers)
        {
            Assert.DoesNotContain(user.email, remainingUsersInDb.Map(u => u.email));
        }

        Assert.Equivalent(mockUsers, removedMockUsers);

        output.WriteLine($"{removedMockUsers.Length} mock users removed from db");
        output.WriteLine("test passed");

        // add users back
        Utils.CreateMockUsers();
    }

    // method 5
    [Fact]
    public void TestCountDomainsFromUserEmails()
    {
        var emails = SQLQuery("select email from users");
        Dictionary<string, int> uniqueEmails = new();

        foreach (var emailRow in emails)
        {
            string email = Utils.RetrieveEmailDomain(emailRow["email"]);
            if (!uniqueEmails.ContainsKey(email))
            {
                uniqueEmails[email] = 1;
            }
            else
            {
                uniqueEmails[email]++;
            }
        }

        var emailCounter = Utils.CountDomainsFromUserEmails();
        output.WriteLine("uniqueEmails Length " + uniqueEmails.Count());
        output.WriteLine("emailCounter Length " + emailCounter.GetKeys().Length);
        // output.WriteLine(emailCounter.GetEntries().ToString());

        // check if values are equal
        // Assert.Equal(uniqueEmails.Values, emailCounter.GetValues());

        // check if keys are equal
        Assert.Equal(uniqueEmails.Keys, emailCounter.GetKeys());
        // check if values are equal
        Assert.Equal(Arr(uniqueEmails.Values), emailCounter.GetValues());
    }

    // method 5.5
    [Fact]
    public void TestRetrieveEmailDomain()
    {
        string username = "iAmAUser";
        string domain = "iAmADomain.com";
        Assert.Equal(domain, Utils.RetrieveEmailDomain(username + "@" + domain));
    }
}