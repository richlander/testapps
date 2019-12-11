using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using static System.Console;

namespace versioninfo
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("**.NET Core info**");
            WriteLine($"{nameof(Environment.Version)}: {Environment.Version}");
            WriteLine($"{nameof(RuntimeInformation.FrameworkDescription)}: {RuntimeInformation.FrameworkDescription}");
            WriteLine($"CoreCLR Build: {((AssemblyInformationalVersionAttribute[])typeof(object).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute),false))[0].InformationalVersion.Split('+')[0]}");
            WriteLine($"CoreCLR Hash: {((AssemblyInformationalVersionAttribute[])typeof(object).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false))[0].InformationalVersion.Split('+')[1]}");
            WriteLine($"CoreFX Build: {((AssemblyInformationalVersionAttribute[])typeof(Uri).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute),false))[0].InformationalVersion.Split('+')[0]}");
            WriteLine($"CoreFX Hash: {((AssemblyInformationalVersionAttribute[])typeof(Uri).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false))[0].InformationalVersion.Split('+')[1]}");
            WriteLine();
            WriteLine("**Environment info**");
            WriteLine($"{nameof(Environment.OSVersion)}: {Environment.OSVersion}");
            WriteLine($"{nameof(RuntimeInformation.OSDescription)}: {RuntimeInformation.OSDescription}");
            WriteLine($"{nameof(RuntimeInformation.OSArchitecture)}: {RuntimeInformation.OSArchitecture}");
            WriteLine($"{nameof(Environment.ProcessorCount)}: {Environment.ProcessorCount}");
            WriteLine();

            if(RuntimeInformation.OSDescription.StartsWith("Linux") && Directory.Exists("/sys/fs/cgroup"))
            {
                WriteLine("**CGroup info**");
                WriteLine($"cfs_quota_us: {System.IO.File.ReadAllLines("/sys/fs/cgroup/cpu/cpu.cfs_quota_us")[0]}");
                WriteLine($"memory.limit_in_bytes: {System.IO.File.ReadAllLines("/sys/fs/cgroup/memory/memory.limit_in_bytes")[0]}");
                WriteLine($"memory.usage_in_bytes: {System.IO.File.ReadAllLines("/sys/fs/cgroup/memory/memory.usage_in_bytes")[0]}");

            }
        }
    }
}
