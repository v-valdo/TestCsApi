// Global settings
Globals = Obj(new
{
    debugOn = true,
    detailedAclDebug = false,
    aclOn = true,
    isSpa = true,
    port = 3001,
    serverName = "Ironboy's Minimal API Server",
    frontendPath = Path.Combine("..", "Frontend"),
    sessionLifeTimeHours = 2
});

Server.Start();