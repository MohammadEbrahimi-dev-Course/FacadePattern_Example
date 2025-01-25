Here is a `README.md` file for your project:
# Facade Design Pattern in C#

This project demonstrates the implementation of the **Facade Design Pattern** in C#. The Facade Pattern provides a unified interface to a set of interfaces in a subsystem. It simplifies the interaction with complex systems by creating a higher-level interface that makes the system easier to use.

---

## Project Structure

The project is structured as follows:

### 1. **Entities**
   - Contains the core entities of the application: `Product`, `Customer`, and `Order`.
   - These classes represent the data models used in the application.

### 2. **Services**
   - **`ProductService`**: Handles operations related to `Product`.
   - **`CustomerService`**: Handles operations related to `Customer`.
   - **`OrderService`**: Handles operations related to `Order`.
   - These services interact with the fake database to fetch and manipulate data.

### 3. **Facade Service**
   - **`OrderFacade`**: Acts as a unified interface that simplifies order placement and retrieval. 
   - Internally uses `ProductService`, `CustomerService`, and `OrderService`.

### 4. **Endpoints**
   - **`EndPointsWithFacade`**: Implements order-related operations (`Place Order`, `Get Orders`) using the facade.
   - **`EndPointsWithOutFacade`**: Implements the same operations without the facade, demonstrating the complexity it simplifies.

---

## Features

### 1. Place Order
   - Allows customers to place an order for a product.
   - Validates whether the customer and product exist before creating the order.

### 2. Get Orders
   - Fetches the list of orders with detailed information about the customer and product.

---

## Why Use the Facade Pattern?

### Without Facade:
- Direct calls to multiple services increase code complexity.
- Developers need to understand the implementation details of each service.

### With Facade:
- A single `OrderFacade` simplifies the interaction between services.
- Encapsulates the complexity of coordinating `ProductService`, `CustomerService`, and `OrderService`.

---

## How to Run the Project

### Prerequisites:
- .NET 6.0 or higher.
- Visual Studio or any C# IDE.

### Steps:
1. Clone the repository:
   ```bash
   git clone <repository-url>

2. Navigate to the project directory.
3. Run the application:
   ```bash
   dotnet run
   ```
4. Use Swagger UI to test the endpoints:
   - Access Swagger at: `https://localhost:<port>/swagger`.

---

## API Endpoints

### 1. **With Facade**

- **POST /api/facade/**  
  Place an order.  
  **Query Parameters**:  
  - `customerId` (int)  
  - `productId` (int)  
  - `quantity` (int)  

- **GET /api/facade/**  
  Get the list of orders.

---

### 2. **Without Facade**

- **POST /api/withoutfacade/**  
  Place an order without using the facade.  
  **Query Parameters**:  
  - `customerId` (int)  
  - `productId` (int)  
  - `quantity` (int)  

- **GET /api/withoutfacade/**  
  Get the list of orders without using the facade.

---

## Example Requests

### Place Order (With Facade)
**POST /api/facade?customerId=1&productId=1&quantity=2**

**Response**:
```json
"Order placed successfully!"
```

### Get Orders (With Facade)
**GET /api/facade**

**Response**:
```json
[
  {
    "id": 1,
    "productId": 1,
    "customerId": 1,
    "quantity": 2,
    "customer": {
      "id": 1,
      "name": "John Doe"
    },
    "product": {
      "id": 1,
      "name": "Laptop",
      "price": 1000.0
    }
  }
]
```

---

## Technologies Used

- **C#**
- **ASP.NET Core Minimal API**
- **Swagger** for API documentation

---

## Resources

### Video Tutorials:
- [YouTube: بررسی Facade Design Pattern و موارد استفاده از آن](https://youtu.be/M8yx6_1BhF0?si=msTaW_hHeFR2bjfs)

---

## Credits
Develop By [AliCharper](https://github.com/AliCharper)
Refactor by **Mohammad**.  
Feel free to reach out for feedback or collaboration!
```
