//////////////////////////////////////////////////////////////////////
// Constants
//////////////////////////////////////////////////////////////////////
const string PROJECT_NAME = "Core";
const string PROJECT_SOLUTION = PROJECT_NAME + ".sln";
const string PROJECT_DIRECTORY_API = "./src/Api/" + PROJECT_NAME + ".Api";
const string PROJECT_DIRECTORY_DOMAIN = "./src/Domain/" + PROJECT_NAME + ".Domain";
const string PROJECT_DIRECTORY_COMMANDS = "./src/Commands/" + PROJECT_NAME + ".Commands";
const string PROJECT_DIRECTORY_QUERYS = "./src/Querys/" + PROJECT_NAME + ".Querys";
const string PROJECT_DIRECTORY_INFRA_IOC = "./src/Infra.Ioc/" + PROJECT_NAME + ".InfraIoc";
const string PROJECT_DIRECTORY_REPOSITORYS = "./src/Repositorys/" + PROJECT_NAME + ".Repositorys";
const string TEST_PROJECT_DIRECTORY = "./tests/" + PROJECT_NAME;
const string TEST_PROJECT_DIRECTORY_UNIT = TEST_PROJECT_DIRECTORY + ".Tests.Unit";
const string TEST_PROJECT_DIRECTORY_INTEGRATION = TEST_PROJECT_DIRECTORY + ".Tests.Integration";
const string TEST_PROJECT_DIRECTORY_API = TEST_PROJECT_DIRECTORY + ".Tests.Api";

//////////////////////////////////////////////////////////////////////
// Arguments
//////////////////////////////////////////////////////////////////////
var target = Argument("target", "Run");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .WithCriteria(c => HasArgument("rebuild"))
    .Does(() =>
{
    CleanDirectory($"{PROJECT_DIRECTORY_API}/bin/{configuration}");
    CleanDirectory($"{PROJECT_DIRECTORY_DOMAIN}/bin/{configuration}");
    CleanDirectory($"{PROJECT_DIRECTORY_COMMANDS}/bin/{configuration}");
    CleanDirectory($"{PROJECT_DIRECTORY_COMMANDS}.Abstractions/bin/{configuration}");
    CleanDirectory($"{PROJECT_DIRECTORY_QUERYS}/bin/{configuration}");
    CleanDirectory($"{PROJECT_DIRECTORY_QUERYS}.Abstractions/bin/{configuration}");
    CleanDirectory($"{PROJECT_DIRECTORY_REPOSITORYS}/bin/{configuration}");
    CleanDirectory($"{PROJECT_DIRECTORY_INFRA_IOC}/bin/{configuration}");    
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreBuild("Core.sln", new DotNetCoreBuildSettings
    {
        Configuration = configuration
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest("Core.sln", new DotNetCoreTestSettings
    {
        Configuration = configuration,
        NoBuild = true
    });
});

Task("Run")		
	.IsDependentOn("Test")	
	.Does(() =>
	{						
		DotNetCoreRun(PROJECT_DIRECTORY_API, "--args", new DotNetCoreRunSettings
		{         
			Configuration = configuration,
            NoBuild = true
		});				
	});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);