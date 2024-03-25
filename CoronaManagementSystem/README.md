# Welcome to the Corona Management System for Health Funds!

## System Description

The Corona Management System for Health Funds was developed to streamline the management of COVID-19 related information among members of health funds. This system provides comprehensive features for tracking vaccination records, managing member data, and monitoring pandemic-related data.

## Table of Contents
- [System Features](#system-features)
- [System Architecture](#system-architecture)
- [Data Protection](#data-protection)
- [Requirements](#requirements)
- [Installation Instructions](#installation-instructions)
- [Screenshots](#screenshots)
- [Contact Us](#contact-us)

## System Features

- **Advanced Database:** Stores personal records of health fund members, including personal details and COVID-19 related data.
- **Member Management:** Ability to add, edit, and delete existing members of the health fund.
- **Vaccination Tracking:** Documentation and management of COVID-19 vaccination processes for each member.
- **Pandemic Data Management:** Recording and managing data on positive cases, recoveries, and relevant event dates.

## System Architecture

The application follows a client-server architecture, with a client-side application interacting with server-side APIs, which in turn interacts with a database to store and retrieve information. Here's how the various components of the system interact:

### Client-Side Application:

- Developed in HTML, CSS, and JavaScript, the client-side application is responsible for presenting the user interface (UI) to the end-users.
- It communicates with the server-side APIs, to perform CRUD (Create, Read, Update, Delete) operations and retrieve data via HTTP requests (GET, POST, PUT, DELETE) over the network.

### Server-Side APIs:

- The server-side APIs, developed in .NET using Entity Framework, act as an intermediary between the client-side application and the SQL Server database.
- They handle incoming HTTP requests from the client-side application and execute corresponding logic.
- Server-side APIs interact with the SQL Server database to perform database operations such as inserting, querying, updating, and deleting data.

### Database:

- The database stores the application's data in a structured format.
- It consists of tables to organize data.
- Entity Framework is used for communication between the server-side APIs and the SQL Server database.

### Schematic View of Information in the Database:

-  User Table: Stores information about registered users and information related to their COVID-19 details.
- Vaccinations Table: Stores information about different types of vaccinations available.
- User Vaccinations Table: Represents the association between users and their vaccinations.

Access to vaccine list information (addition, deletion, etc.) is done through the Swagger user interface.

## Data Protection

The system uses a SQL Server database to store data, ensuring data integrity and preventing foot faults.

## Requirements

- .NET Framework 4.7.2 or higher
- SQL Server
- Web browser with support for HTML5 and CSS3

## Installation Instructions

1. Download the code files from GitHub.
2. Install the required development environment.
3. Start the server and the database.
4. Launch the client on a web browser.
5.Contact SWAGGER to add vaccines.

## Screenshots

Homepage:
![image](https://github.com/noa1020/Corona_management-system/assets/146897162/e2c3a1cf-9656-46b3-99f8-fa5e646c3693)

Statistics on Covid19:
![image](https://github.com/noa1020/Corona_management-system/assets/146897162/af54f70b-2b7b-4813-bf97-895a501dd9ef)

Adding new member:
![image](https://github.com/noa1020/Corona_management-system/assets/146897162/08f9e94b-6703-4784-b0e1-6512fc8e954e)
![image](https://github.com/noa1020/Corona_management-system/assets/146897162/1bd13119-617c-481a-8bb2-f5077fd2c777)
![image](https://github.com/noa1020/Corona_management-system/assets/146897162/a1e69fec-d349-4ad7-afcf-633b51521a18)


Basic member information:

![image](https://github.com/noa1020/Corona_management-system/assets/146897162/05c35799-61df-4c78-b773-806c0b126859)

Edit member details:

![image](https://github.com/noa1020/Corona_management-system/assets/146897162/2a65bc1c-adbb-49ec-8c51-8edfc6cade11)

Member Covid19 details:

![image](https://github.com/noa1020/Corona_management-system/assets/146897162/04aa9568-f8f9-49dd-9893-eca5e4944be0)

Editing a particular vaccine:

![image](https://github.com/noa1020/Corona_management-system/assets/146897162/62ccc57f-5772-4429-ab1e-f190d21bcf3e)

Edit/add a sick or recovery day:

![image](https://github.com/noa1020/Corona_management-system/assets/146897162/65be2c54-57cd-42b9-8aef-93a89e141b13)

Add vaccination:

![image](https://github.com/noa1020/Corona_management-system/assets/146897162/7b72d59d-3942-4e64-a2cb-53b7c5dcea8e)


## Contact Us

For any questions or further assistance, please contact us via email: Noa0533181648@gmail.com or through our social media profiles.
