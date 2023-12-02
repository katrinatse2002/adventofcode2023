So I said I was going to learn C#... Let's see how long I last.

### Instructions for myself
Create a new project for every day's solution:
```bash
dotnet new console -n day_<xx>
```

Run each day's solution:
```bash
cd day_<xx>
dotnet run
```

Add config with following format to launch.json to make debugger work:
```bash
{
    "name": "C#: day_<xx>",
    "type": "dotnet",
    "request": "launch",
    "projectPath": "${workspaceFolder}\\day_<xx>\\day_<xx>.csproj",
    "launchConfigurationId": "TargetFramework=;day_<xx>"
}
```
