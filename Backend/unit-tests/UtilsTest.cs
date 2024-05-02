namespace WebApp;
using Xunit;
public class UtilsTest
{
    // METOD 1 
    [Fact]
    public void TestIsPasswordStrongEnough()
    {
        string badPassword = "testPassword1234";
        string goodPassword = "testPassword1345%";
        Assert.True(Utils.IsPasswordStrongEnough(goodPassword));
        Assert.False(Utils.IsPasswordStrongEnough(badPassword));
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
    // [Fact]
    // public void TestCreateMockUsers()
    // {
    //     var read = File.ReadAllText(Path.Combine("json", "mock-users.json"));
    //     Arr usersFromFile = JSON.Parse(read);
    //     // gets all users from db
    //     Arr usersInDb = SQLQuery("select email from users");
    //     Arr emailsInDb = usersInDb.Map(user => user.email);
    //     // only keeps mockusers NOT already in db
    //     Arr mockUsersNotInDb = usersFromFile.Filter(
    //         u => !emailsInDb.Contains(u.email));

    //     // Assert create mockusers ONLY returns newly created users in db
    //     var result = Utils.CreateMockUsers();
    //     // Log("calculated by test", mockUsersNotInDb);
    //     // Log("reported by method", result);

    //     // assert same length
    //     Assert.Equal(mockUsersNotInDb.Length, result.Length);

    //     // check equivalency
    //     for (int i = 0; i < result.Length; i++)
    //     {
    //         Assert.Equivalent(mockUsersNotInDb[i], result[i]);
    //     }
    // }
}