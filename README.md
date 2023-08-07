# _Factory_

#### By _**Thomas Bakken**_

#### _A web application for a factory to manage engineers and machines._

## Technologies Used

* _.NET_
* _C#_
* _MySQL_
* _Entity Framework Core_

## Description

_A website for a factory to manage engineers and machines. The user can view and create both engineers and machines. A database is used to store information about engineers and machines. An engineer can work on many machines and a machine can have many qualified engineers._

## Setup/Installation Requirements

* _Install .NET SDK 6_
* _Install MySQL Server_
* _Clone the repository_
* _In the bash command line:_
  * _Navigate to the top-level directory_
  * _Create appsettings.json with: touch appsettings.json_
    * _Open the file in a text editor and copy the following line_
      * _\{"ConnectionStrings": \{"DefaultConnection": "Server=localhost;Port=3306;database=\[DB_NAME\];uid=\[USERNAME\];pwd=\[PASSWORD\];"\}\}_
    * _Replace \[DB_NAME\] with a database name_
    * _Replace \[USERNAME\] with your MySQL username_
    * _Replace DB_NAME with your MySQL password_
  * _Enter command: dotnet restore Factory_
  * _Initialize database with: dotnet ef database update_
  * _Run application with command: dotnet run --project Factory_


## Known Bugs

* _Submitting an empty name results in error_

## License

_MIT_

Copyright (c) _8/7/2023_ _Thomas Bakken_