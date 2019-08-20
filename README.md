# Pierre's Sweet and Savory Treats

#### _Admin tool to add flavors, and treats for Pierre's shop - August 16, 2019_

#### _By **Erik Irgens**_

## Description

This app is intended to serve as a utlity for Pierre's Sweet and Savory Treats to manage a list of flavors - through the addition of a flavor on a form page - and treats for each perspective flavor through a page dedicated to add treats for easy viewing and correlation of information. It uses relational database structure, in which Falvors and Treats are in a many-to-many relationship, and uses user authentication to verify the correct user is viewing, editing, deleting, or creating items.

### Specs

### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
| **App allows for User Account Creation** | Username, Email, Password | Account is created with credentials |
| **App authenticates user is logged in** | VISIT PAGE | Account is Verified as Logged In |
| **App takes Flavor creation input and displays a link to Flavor's page** | NAME | NAME(link) |
| **Flavor page allows for navigation to its own Treats page** | NAME | NAME(link) - > LIST OF TREATS |
| **Flavor page allows for treat creation and input** | TREAT INFORMATION | NAME(link) -> LIST OF TREATS - > TREAT PAGE|
| **App compares logged in user to created item's user** | Try to visit EDIT/DELETE for an item | Account is Verified as Logged In and compared to original user |


## Setup/Installation Requirements

1. Clone this repository:
    ```
    $ git clone https://github.com/erik-t-irgens/Pierre-s-Sweet-and-Savory-Treats
    ```
2. Restore the application (in the PierresSweets directory within the root folder)
    ```
    $ dotnet restore
    ```
3. Create a database using command line while IN THE PROJECT FOLDER (/PierresSweets):
    ```
    $ dotnet ef database update
    ```
4. Run the application using:
    ```
    $ dotnet run

    ```
4. Visit the application via web browser:
    ```
    localhost:5000/
    ```
## Known Bugs
* No known bugs at this time.

## Technologies Used
* C# / .NET

## Support and contact details

_Please contact Erik Irgens with questions and comments._

### License

*GNU GPLv3*

Copyright (c) 2019 **_Erik Irgens_**
