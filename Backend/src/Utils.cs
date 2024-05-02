namespace WebApp;
public static class Utils
{

    // Exempelmetod för Testning
    public static int SumInts(int a, int b)
    {
        return a + b;
    }

    // METOD 1
    public static bool IsPasswordStrongEnough(string password)
    {
        return
        password.Length >= 8 &&
        password.Any(char.IsDigit) &&
        password.Any(p => !char.IsLetterOrDigit(p)) &&
        password.Any(char.IsLower) &&
        password.Any(char.IsUpper);
    }

    // METOD 2
    public static string RemoveBadWords(string text)
    {
        string textToCheck = text.ToLower();
        // JSON.Parse(
        return "VeryBadWord";
    }

    // METOD 3
    public static Arr CreateMockUsers()
    {
        var read = File.ReadAllText(Path.Combine("json", "mock-users.json"));
        Arr usersFromFile = JSON.Parse(read);
        Arr successFullyWrittenUsers = Arr();
        foreach (var user in usersFromFile)
        {
            user.password = "12345678";
            var result = SQLQueryOne(@"
            insert into users(firstName, lastName, email, password)
            values($firstName, $lastName, $email, $password)
            ", user);
            // if query gives error, then mock users havent been added
            // if not we have - and add to successful list
            if (!result.HasKey("error"))
            {
                // specs asks for user list w/o password
                user.Delete("password");
                successFullyWrittenUsers.Push(user);
            }
        }
        return successFullyWrittenUsers;
    }
}