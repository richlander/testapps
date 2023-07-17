using static System.Console;
using System.CommandLine;
using System.Runtime.ExceptionServices;
using System.Diagnostics;

var directory = new Argument<DirectoryInfo>("directory");
var ignore = new Option<List<string>>("--ignore")
{
    Description = "substrings to ignore"
};
var platform = new Option<string>("--platform");

var rootCommand = new RootCommand("Sample app for System.CommandLine");
rootCommand.AddOption(ignore);
rootCommand.AddOption(platform);
rootCommand.AddArgument(directory);


rootCommand.SetHandler((ignore, platform, directory) => 
    { 
        App(directory, platform, ignore);
    },
    ignore, platform, directory);

return await rootCommand.InvokeAsync(args);

void App(DirectoryInfo dir, string? platform, List<string>? ignore)
{
    const string DOCKERFILE = "Dockerfile";

    if (!dir.Exists)
    {
        return;
    }

    foreach (var file in dir.EnumerateFiles())
    {
        if (!file.Name.StartsWith(DOCKERFILE))
        {
            WriteLine($"Not a Dockerfile: {file.Name}");
            continue;
        }
        
        if (ignore is not null && IsMatch(file.Name, ignore))
        {
            WriteLine($"Skip: {file.Name}");
            continue;
        }

        WriteLine($"Build: {file.Name}");
        BuildDockerfile(file, platform);
    }

    PrintImages();
}

bool IsMatch(string target, List<string> ignoreWords)
{
    foreach (var word in ignoreWords)
    {
        if (target.Contains(word))
        {
            return true;
        }
    }

    return false;
}

void BuildDockerfile(FileInfo file, string? platform)
{
    var parent = file.Directory?.FullName ?? throw new Exception($"Cannot find parent directory of {file.FullName}");
    var platformArg = platform is null ? string.Empty : $"--platform {platform}";
    string args = $"build --pull {platformArg} -t {file.Name.ToLowerInvariant()} -f {file.FullName} {file.Directory.FullName}";
    var command = Process.Start("docker", args);
    command.WaitForExit();
}

void PrintImages()
{
    string args = $"images --filter=reference=dockerfile*";
    var command = Process.Start("docker", args);
    command.WaitForExit();
}
