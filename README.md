
# QuickMapping

QuickMapping is a lightweight mapping library for .NET projects. This repository is open for contributions and feedback as it is a new project and may have some bugs or issues. 

## Installation

You can install QuickMapping via NuGet Package Manager or by using the .NET CLI.

### Using NuGet Package Manager

1. Open your project in Visual Studio.
2. Go to the **Solution Explorer**.
3. Right-click on your project and select **Manage NuGet Packages**.
4. Search for `QuickMapping` in the **Browse** tab.
5. Click **Install** to add the package to your project.

### Using .NET CLI

Open a terminal or command prompt and run the following command:

```
dotnet add package QuickMapping --version 1.0.3
```
## Getting Started
In the `Program.cs` file, add QuickMapping to the service collection:
```
using QuickMapping.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddQuickMapping();

var app = builder.Build();
```

## Usage

```
public class User(int id, string fullname, int age)
{
    public int Id { get; set; } = id;
    public string Fullname { get; set; } = fullname;
    public int Age { get; set; } = age;
}

public class UserViewModel()
{
    public string Fullname { get; set; } = null!;
}

var michael = new User(1, "Michael Jordon", 38);
var userVM = _mapper.Map<User, UserViewModel>(michael, 1);
```
## Contributing
We welcome contributions from the community! If you find any bugs or have suggestions for improvements, please open an issue or submit a pull request. Here’s how you can contribute:

1.  Fork the repository.
2.  Create a new branch (`git checkout -b feature-[branchname]`).
3.  Make your changes.
4.  Commit your changes (`git commit -am '[feature description]'`).
5.  Push to the branch (`git push origin feature-[branchname]`).
6.  Open a pull request on GitHub.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Contact
For any questions or further assistance, please contact us via the GitHub Issues page or email us at hasandivarciuk@hotmail.com
