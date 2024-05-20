// Global settings
Globals = Obj(new
{
    debugOn = true,
    detailedAclDebug = false,
    aclOn = true,
    isSpa = true,
    port = 3001,
    serverName = "Valles Mini-API",
    frontendPath = FilePath("..", "Frontend"),
    sessionLifeTimeHours = 2
});
// output obj w/ unique domains + count
//Log(WebApp.Utils.CountDomainsFromUserEmailsW());

// WebApp.Utils.CreateMockUsers();
Server.Start();