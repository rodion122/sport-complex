# APIs part

## APIs:
* All APIs contain documentation where you can find the returned status codes and controller descriptions.
* If you will use swagger web ui, then by clicking on the <b>Authorization</b> button you can add your jwt for automatic insertion into the request where it will be required.

<br/>

## Remarks
 * All APIs and the WebUI write data both to the console and to a text file that is located in each individual project (using [serilog](https://serilog.net/)).
 * The Web UI architecture is built in such a way that by changing the dependencies for services and authorization, you can use both a monolithic architecture (as in the second task) and a distributed one (using web services)

<br/>

# Presentation layer part
</br>

## Testing
<b>To perform integration tests, you must:</b>
* You need to publish project "SportComplex.Database" giving it the name "teststmdb".
* After completing the previous step, all integration tests should work correctly.

</br>

## Description of the Presentation layer:
For the application to work, you need to publish the project "SportComplex.Database", giving it the name "tmdb", the application also stores the information it needs in cookies (please do not disable them).
After successful publication of the database, you will have access to the minimum required amount of data to check the health of the application.

<b>There are several roles that can: </b>:
* Not authorize:
  * Register and login into system;
  * View all published events and theirs tickets availability (the layout map is not available, but if there is still free seat, a corresponding message will be displayed for the user);
* User:
  * Purchase tickets;
  * See purchase history;
  * See cart;
  * Top up or view balance (amount of USD);
  * Can add amount to his balance from profile; 
* Event manager:
  * <b>CRUD</b> operations on event entity;
* Layout manager:
  * Manage users (delete and change roles);
  * Setup venue; 

The application has accounts for all roles by default (when combining several roles with the user role, it is impossible to make a purchase). Below is a list of standard accounts:
|<b>Role</b> | <b>Email</b> | <b>Password</b> |
| -- | -- | -- |
|Event manager|eventmanager@mail.ru|1q2W3e_
|Layout manager|layoutmanager@mail.ru|1q2W3e_
|User|user@gmail.ru|1q2W3e_
|All roles (for one user)|allroles@mail.ru|1q2W3e_

<b>About purchases flow:</b>
* An authorized user can select any number of tickets available for sale for any current event. When adding tickets to the cart, their status will change to "received", the seats  will be marked in green on the map. The user will have 20 minutes of free time from the moment of adding the last product to the cart. If the user does not buy tickets, they automatically change the status to "empty". If the user decides to buy tickets, the seats change the status to "unavailable" and are added to the purchase history.
* The only currency used on the site is USD.

</br></br>
# Data access layer part

</br>

## Testing 
<b>What to run the tests you need to do</b>:
 * You need to publish the project "SportComplex.Database" and make a name for the database.
 * After that, you need to find the file "appsettings.json" in the project "SportComplex.IntegrationTests" and insert the database name into the "connctionString" section in the "correctConnectionString" key.

## Description of the Data access layer:
On the data access layer (further DAL), the patter Repository was used with asynchronous <b>CRUD</b> operations for each entity. The implementations of the "Repository" contain sql-code with queries to the database (except for the `Event` entity, because the task needs to be implemented: Creating/Removal/Updating using stored procedures).

<b>Additional:</b>
* A custom exception `DataAccessException` was created on the DAL, it serves as a wrapper for more specific errors specific to the storage we are working with: database/text files/ serialized files, etc. This approach will allow the business logic layer, or any other layer that will work with this DAL, to expect only one exception associated with interaction with a specific storage.   

## Description of the business logic layer:
The project used [anemic model](https://habr.com/ru/post/346016/), therefore, on the business logic layer (further BLL), DTOs objects of the domain (without behavior) and managers - classes that are engaged in servicing each entity were created. Additionally, the `Constants` class was created, which contains constants that can be found in different managers.

<b>Detailed description of managers:</b>

  * <b>`SeatManager`:</b> Implements all <b>CRUD</b> operations for the `Seat` entity. Additionally, it implements `DeleteSeatsByAreaIdAsync` - deleting all seats by area id. It also checks:
    * uniqueness of the current `Seat` in the `Area`.
    * the existence of the `Area` where the given `Seat`is located.
    * the presence of events planned in the future for this seat (if they exist, any changes (Create/Delete/Update) of this `Seat` are impossible).
    * checking `Row` and `Number` for negative numbers.
    * checking `Row` and `Number` for being in the `Area` range (no more than `CoorX/Y`).
    * when updating/deleting the existence of an object in the repository.
  
  * <b>`AreaManager`:</b> Implements all <b>CRUD</b> operations for the `Area` entity. Additionally, it implements `DeleteAreasByLayoutId` - deleting all areas by layout id. It also checks:
    * uniqueness of the description of `Area` in `Layout`.
    * `CoordX/Y` for negative numbers.
    * the presence of events planned in the future for this `Area` (if they exist, any changes (Create/Delete/Update) of this `Area` are impossible).
    * the existence of a `Layout`, where the given area is located.
    * when updating/deleting the existence of an object in the repository.
    * when deleting, the presence of dependent objects (`Seat`).
    * when updating, it is not possible to change the layout id.
    
  * <b>`LayoutManager`:</b> Implements all <b>CRUD</b> operations for the `Layout` entity. Additionally implements `GetAllCompleteAsync` - returns a `Layout` collection in which each `Area` has at least one `Seat`. It also checks:
    * the `Name` field indicates uniqueness in the current `Venue`.
    * fields of the string type are empty
    * string type fields for exceeding the allowed size.
    * the existence of a `Venue` where this layout is located.
    * the presence of events planned in the future for this `Layout` (if they exist, any changes (Create/Delete/Update) of this `Layout` are impossible).
    * when deleting, the presence of dependent objects (`Area`).
    
  * <b>`VenueManager`:</b> Implements all <b>CRUD</b> operations for the `Venue` entity. It also checks:
    * the `Name` field for uniqueness.
    * fields of the string type are empty
    * string type fields for exceeding the allowed size.
    * when deleting, the presence of dependent objects (`Layout`).
    * when updating/deleting the existence of an object in the repository.
  
  * <b>`EventSeatManager`:</b> Implements UpdatState/GetAll/GetById for the `EventSeat` entity. Additionally, it implements `UpdateStateForManySeats` - updating the state for the seats collection. It also checks:
    * change any fields (except `State`).
    * the existence of this `EventSeat` in the repository.
    * when buying a seat, check for the availability of the set price and the readiness of the event for sale.
    * when updating the seats collection, checks for the equivalent state of seats
    * when updating the seats collection, checks for the equivalence of the event for all seats.
    * when deleting an event, checks whether it is certified or not ready for sale.
    * when deleting an event, checks for all current `EventSeats`: the state must be equal to "Unavailable"

  * <b>`EventAreaManager`:</b> Implements UpdatPrice/GetAll/GetById for the `EventArea` entity. It also checks:
    * the existence of this `EventArea` in the repository.
    * change any fields (except `Price`).
    * `Price` for validity.
    * when deleting the price, check for all current `EventSeats`: the price should be equal to "Unavailable".
 
  * <b>`EventManager`:</b> Implements all <b>CRUD</b> operations for the `Event` entity. Additionally implements `GetAllEventsReadyForSaleAsync` - returns a collection of events that are ready for sale. It also checks:
    * the creation date and the end date for validity.
    * the inability to create multiple events at the same time on the same `Layout`.
    * checking the event for the presence of at least one seat.
    * fields of the string type are empty
    * string type fields for exceeding the allowed size.
    * when deleting an event, the dependent data must be deleted: `EventArea` and `EventSeats`.
    * when creating an event, copies of `Area` and `Seat` from the current `Layout` must be created.
    * when deleting an event, they must be completed or be unavailable.

<b>Additional:</b>
* Two custom exceptions were created on BLL: `ValidationException` and `BusinessLogicException`. The first exception is thrown in cases when the data is not valid. The second exception is thrown in situations when an item cannot be found in the storage. Also `BusinessLogicException` is a wrapper for `DataAccessException` because the view layer should not know about the existence of the DAL and the exceptions associated with it.
* For convenience, [AutoMapper](https://docs.automapper.org/en/stable/Getting-started.html) was used on BLL. For this reason, an additional class `BusinessLogisMapperProfile` was created - a class that stores the necessary instructions for mapping.

## Testing 
<b>What to run the tests you need to do</b>:
 * You need to publish the project "SportComplex.Database" and make a name for the database.
 * After that, you need to find the file "appsettings.json" in the project "SportComplex.IntegrationTests" and insert the database name into the connctionString section in the correctConnectionString key.

