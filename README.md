# EBook-Website
The application is called E-Books and intends to sell multiple books with a wide range of book genres 
such as fantasy fiction, Biographies, and Personal finance to name a few. With Some of the books that 
can be purchased on the E-Books being Can’t Hurt Me by David Goggins and Lord of The Rings by J.R.R. 
Tolkien to name a few. The application consists of multiple pages both for customers and the admin 
of the page, with the admin being able to login and view and edit orders, books, and book genres. 
While some of the customer pages allow the user to register and sign in and search for books available 
on the website, along with a cart page and order page for the user to complete their transaction.
The website has also been designed to be as professional as possible with media responsiveness being 
implemented as much as possible while also implementing stripe to the website which allows for the 
customer to view checkout purchases made on the E-Books website. Lastly SQL server management 
has also been implemented into the code to allow for data such as customer details, books, book 
genres, cart etc. to be saved on the database through appsettings.json

# Website Features & Functionality
1) Website Navigation:
   - Implemented a dark navigation bar using Layout.cshtml.
   - Enhanced navigation bar appearance with CSS.
2) Search Box:
   - Implemented a search box on the home page using CSS classes and C# in HomeController.cs.
3) Cart Functionality:
   - Customers can add books to the shopping cart.
   - Implemented quantity selection for each book in the cart.
   - Users can increase or decrease the quantity of books in the cart.
   - Subtotal amount updates dynamically.
4) User Authentication:
   - Implemented customer login and registration.
   - User details are stored in the database (Microsoft SQL Server).
   - Cart contents are saved and remembered for logged-in users.
5) Admin Page:
   - Admin login functionality.
   - Admin can add, edit, and delete multiple books and book genres.
   - Admin can view and edit orders, books, and book genres.
6) Pages for Customers:
   - Home Page:
     - Displays a variety of book genres and available books.
     - Uses a foreach loop for book genres.
     - Utilizes CSS for layout and styling.
   - Checkout Page:
     - Prompts users to add details for name, number, and address.
     - Utilizes ModelOnly class for form validation.
     - Implements Stripe for payment processing.
7) Admin Pages:
   - Creating Book Genres & Book List
   - Editing Book Genres/Book List
   - Details of Book Genres/Book List
   - Deleting of Book Genres/Book List
  
8) Manage Orders:
   - Admin can view and manage orders
   - Order details include time of purchase, name, phone, address, and order status.
