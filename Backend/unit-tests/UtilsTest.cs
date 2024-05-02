namespace WebApp;
using Xunit;
public class UtilsTest
{
    // [Fact]
    // public void TestIntSum()
    // {
    //     // Arrange
    //     // Act
    //     // Assert

    //     Assert.Equal(5, Utils.SumInts(1, 4));
    //     Assert.Equal(-3, Utils.SumInts(6, -9));
    // }

    // METOD 1 
    [Fact]
    public void TestIsPasswordStrongEnough()
    {
        string password = "testPassword1345%";
        Assert.True(Utils.IsPasswordStrongEnough(password));
    }

    // METOD 2
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