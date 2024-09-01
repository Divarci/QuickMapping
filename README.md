
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
dotnet add package QuickMapping --version 1.0.5
```
## Getting Started
In the `Program.cs` file, add QuickMapping to the service collection:
(Default case sensitive option is `true` )
```
using QuickMapping.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddQuickMapping();

var app = builder.Build();
```

If you would like to **add Case sensitive** false options:
```
using QuickMapping.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddQuickMapping(opt =>
{
    opt.IsSensitiveCase = true;
});

var app = builder.Build();
```


## Usage
**Preparation**
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
```
Create **NEW** instance of object
```
var userVM = _mapper.Map<User, UserViewModel>(michael, 1);
```
Use **EXISTING** instance of object
```
var request = new UserViewModel() { Fullname = "Jackie Chan" };
var jackie = _mapper.Map(michael,request);
```
Use **MapTo** IQueryable Extension
```
var dbData= _repository.GetAll(); // IQueryable<Data>
var query = dbData.MapTo<Data,DataViewModel>(3, options) //IQueryable<DataViewModel>
```
## Unsupported Typed

Dictionary and Key-Value Pairs are unsupported and will be available V1.0.7

## What will be available V1.0.7 

1- Dictionary and Key-Value Pairs mapping
2- Type conversion options

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Contact
For any questions or further assistance, please contact us via the GitHub Issues page or email us at hasandivarciuk@hotmail.com
