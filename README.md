# ParkingGarage OOP System Design
This is a sample Object Oriented and System Design of a Parking Garage application. It is meant to give an overview of how a parking garage reservation system could
be implemented. A user interface could display a list of available parking spaces, describing where the space is located and what type of car (compact, full, truck, etc.) the space is designed for, and allow a customer to reserve that space. 


![Screenshot 2022-11-13 172756](https://user-images.githubusercontent.com/62074171/201561217-82428218-81d4-441b-b17e-88337c7249f4.png)

BRD

![Screenshot 2022-11-20 150231](https://user-images.githubusercontent.com/62074171/202931384-c4b60599-84d2-45dd-b261-cde5c457d198.png)



The flow will involve a user interface performing different steps to allow a reservation to be made. 
Step 1 will utilize a Parking Space API in which the user interface will reach out to the API with a GET call, which will then call the Parking Spaces database table and return a collection of parking spaces to the user interface. The API can be used to either return all parking spaces and the interface can then display them as open or closed, or the API can filter the open spaces and only return those, leaving less work for the user interface. 
Step 2 involves making a reservation and processing a payment. After displaying the parking spaces the user will then be allowed to make a reservation by selecting the space, entering their car related information, and their payment information. This will be done via a POST request, the reservation service will ensure the parking space is open, the database can perform transaction locking while the payment is processed, ensuring no other customers try to reserve this parking spot. If the payment is successfully processed, the reservation service will then add the reservation details into the database and mark the space as closed. 


![Screenshot 2022-11-20 172057](https://user-images.githubusercontent.com/62074171/202940637-987fdbde-51fd-4188-99ad-63fe83a48d22.png)
