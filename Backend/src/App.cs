// Global settings
Globals = Obj(new
{
    debugOn = true,
    detailedAclDebug = false,
    aclOn = false,
    isSpa = true,
    port = 3001,
    serverName = "Valles Server",
    frontendPath = Path.Combine("..", "Frontend"),
    sessionLifeTimeHours = 2
});

//Server.Start();
//new UtilsTest().TestCreateMockUsers();

// var badWordsFromFile = File.ReadAllText(Path.Combine("json", "bad-words.json"));
// Arr badWords = JSON.Parse(badWordsFromFile);
// Console.WriteLine(badWords.ToString());

string test = WebApp.Utils.RemoveBadWords("fuck you you fucking whore ass motherfucker", "nice bunnies");
Console.WriteLine(test);