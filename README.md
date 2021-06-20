# Pierre's Treats

#### Epicodus Code Review: Authentication and Authorization in C#

#### By Shannon Lee

#### _Table of Contents_

1. [Description](#description)
2. [Technologies Used](#technologies)
3. [Setup/Installation Requirements](#setup)
4. [Known Bugs](#bugs)
5. [License](#license)
6. [Contact Information](#contact)


## Description <a id="description"></a>

This is a web application made using C#, .NET5, MySQL, and Entity for a fictional bakery with various treats and flavors. This project demonstrates understanding of Database basics, many-to-many relationships, and use of Identity in C# MVC projects for authentication and authorization.

## Technologies Used <a id="technologies"></a>

* C#
* .NET 5
* MSBuild
* MSTest
* Entity
* Identity
* MySQL
* git


## Setup/Installation Requirements <a id="setup"></a>

Setup requirements
* Make sure that .NET Software Development Kit 5 and MySQL have been installed to your local machine.

Installation
* Clone this repository to your machine `$ git clone https://github.com/shanole/PierresTreats.Solution`
* In the terminal, navigate to the project directory `$ cd Factory.Solution/PierresTreats`
* Create `appsettings.json` file in `/PierresTreats` directory with the following code:
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=shannon_lee;uid=root;pwd=<YOUR PASSWORD HERE>;"
  }
}
```
* Create local database from migration with `dotnet ef database update`
* Compile code by running command `$ dotnet build`
* Run program with command `$ dotnet run` to open webpage on your preferred browser at `http://localhost:5000`

## Known Bugs <a id="bugs"></a>
* None known at this time. If you find one, please don't hesitate to contact me about it!

## License <a id="license"></a>
*[MIT](https://choosealicense.com/licenses/mit/)*

Copyright (c) 2021 Shannon Lee

## Contact Information <a id="contact"></a>
**_Shannon Lee [mailto](mailto:shannonleehj@gmail.com)_**