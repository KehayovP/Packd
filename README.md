# Welcome to Packd

## What is Packd?
Packd is a web application that allows the user to create a list of items when going on a vacation. Its purpose is to suggest a list of categories and items that the user can choose from and potentially decide to add to their list. Should the user want to bring other categories of items and items with them, they could simply create their own category and add the desired items to it. They can also add items to the suggested default categories, once imported to their personal list. Then, the user can set an item in a list as "Packed" or "Not Packed" by clicking the checkbox next to it.

## Initial Setup
Execute the Packd_init.sql script located in DatabaseScrpits folder to create the database, necessary stored procedures and import initial data.

## Ideas for future development
- Initial List Creation form that the user could complete providing more information about the vacation (example: country, exact dates) and have a more targeted suggested default items. Example, if the weather forecast is to rain during this period, a targeted list for relative items would be present in the initial List Creation Phase. To achieve that, API requests could be made to provide the necessary data.
- Functionality permitting to copy an already existing list so that the user can have it as a template for a similar vacation list that he/she might be up to.
- Functionality permitting to compare two lists so that the user can have ideas for items from previous vacations that could be imported to the upcoming one.
- Users will be able to create an account and log in to have their own lists. This will require changes to the database and to the already implemented functionalities in order to take the user into consideration.

## Technologies and approaches used
- Database First approach
- ASP.NET Core MVC
- MS SQL SERVER
- Entity Framework Core
- C#
- Linq
- HTML
- CSS
- Bootstrap
- JavaScript
- jQuery