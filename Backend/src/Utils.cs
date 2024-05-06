using Xunit;

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
    public static string RemoveBadWords(string badText, string niceWord)
    {
        var badWordsFromFile = File.ReadAllText(Path.Combine("json", "bad-words.json"));
        Arr badWords = JSON.Parse(badWordsFromFile);

        string niceText = Regex.Replace(badText, "\\b" + string.Join("\\b|\\b", badWords) + "\\b", niceWord);

        return niceText;
    }

    // METOD 3
    public static Arr CreateMockUsers()
    {
        // Read all mock users from the JSON file
        var read = File.ReadAllText(FilePath("json", "mock-users.json"));
        Arr mockUsers = JSON.Parse(read);
        Arr successFullyWrittenUsers = Arr();

        foreach (var user in mockUsers)
        {
            // check if user already in database
            // had to create an anonymous object for passing in user.email 
            var existingUser = SQLQueryOne(
               @"select * from users where email = $email",
            user);

            if (existingUser == null)
            {
                // if user null, encrypt pw
                user.password = GeneratePasswordFromEmail(user.email) + "1";
                if (!IsPasswordStrongEnough(user.password))
                {
                    user.password = "InsecurePassword";
                }
                else
                {
                    user.password = Password.Encrypt(user.password);
                }
                var result = SQLQueryOne(
                    @"INSERT INTO users(firstName,lastName,email,password)
                VALUES($firstName, $lastName, $email, $password)
            ", user);

                // If we get an error from the DB then we haven't added
                // the mock users, if not we have so add to the successful list
                if (!result.HasKey("error"))
                {
                    // The specification says return the user list without password
                    user.Delete("password");
                    successFullyWrittenUsers.Push(user);
                }
            }
            else
            {
                // User already exists, add to successful list without encryption
                user.Delete("password");
                successFullyWrittenUsers.Push(user);
            }
        }
        return successFullyWrittenUsers;
    }

    public static string GeneratePasswordFromEmail(string email)
    {
        return char.ToUpper(email[0]) + email.Substring(1);
    }

    // metod 4
    public static Arr RemoveMockUsers()
    {
        var read = File.ReadAllText(FilePath("json", "mock-users.json"));
        Arr mockUsers = JSON.Parse(read);
        Arr removedMockUsers = Arr();

        foreach (var user in mockUsers)
        {
            var result = SQLQueryOne(
                @"delete from users where firstName = $firstName and lastName = $lastName",
                user);

            if (!result.HasKey("error"))
            {
                user.Delete("password");
                removedMockUsers.Push(user);
            }
        }
        // return w/o pw
        return removedMockUsers;
    }

    // method 5
    public static Arr CountDomainsFromUserEmails()
    {
        return Arr();
    }
}