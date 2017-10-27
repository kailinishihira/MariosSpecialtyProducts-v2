## Mario's Specialty Food Products

### Kaili Nishihira

#### _Web app for Mario's Specialty Food Products, 10.27.17_


## Description

* All products have a name, cost and country of origin.
* All reviews have an author, content body (between 50-250 characters) and rating (between 1-5).
* The landing page includes the three most recently added products and the three products with the most reviews.
* The site includes a products section with a list of the tasty products that Mario sells. Each product is click-able with a detail view.
* Admins are able to add, update and delete new products.
* Anonymous users are not able to add new products.
* Admins are able to delete comments by any user.
* Users are able to click an individual product to see its detail page, including its average rating.
* Users are able to add a review to a product.
* The products detail page uses AJAX to add a new review.

_Styling inspired by [Eataly](https://www.eataly.com/)._

## Setup/Installation Requirements

* _Download and install [.NET Core 1.1 SDK](https://www.microsoft.com/net/download/core)_
* _Download and install [Mono](http://www.mono-project.com/download/)_
* _Download and install [MAMP](https://www.mamp.info/en/)_
* _Download and install [Visual Studio 2017](https://www.visualstudio.com/)_
* _Clone repository_

### Setup/Installation for Database
* In your terminal, navigate from the Solution folder to the project folder, MariosSpecialtyProducts
* Enter `dotnet restore` in your terminal
* Enter `dotnet ef database udpate` in your terminal

##### Import data from the Cloned Repository
* _Click 'Open start page' in MAMP_
* _Under 'Tools', select 'phpMyAdmin'_
* _Click 'Import' tab_
* _Choose database file (from cloned repository folder)_
* _Click 'Go'_

## Technologies Used
* _C#_
* _.NET_
* _MVC_
* _Entity Framework_
* _[Bootstrap](http://getbootstrap.com/getting-started/)_
* _[MySQL](https://www.mysql.com/)_
* _AJAX_
* _jQuery_


### License

Copyright (c) 2017 **_Kaili Nishihira_**

*Licensed under the [MIT License](https://opensource.org/licenses/MIT)*
