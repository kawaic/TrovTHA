# Trov Take Home Assignment
### By Ka-Wai Chan

The assignment was implemented using Asp.net Web API framework using Visual Studio 2015.

The following additional libraries were used: 

    * Unity for dependency injection
    * RhinoMock for mocking interfaces
    * Owin TestServer for in memory hosting

Questions to consider

    1. How do we know if a user is authenticated?  Using a token exchange system, the client will authenticate with the server are receive a token and use that on following requests to indicate that it has been authenticated.  IP address and other information can be used to prevent man in the middle attacks if needed.
    2. Is it always possible to buy an item?  No, the item could be removed, or if there is not enough inventory to fullfil the purchased, a HTTP 400 response with a reason phrase is used to communicate this.

### Deliverables

1. A system that can process the two API requests via HTTP
    * GET api/inventories - can be used to retrieve the current inventory of items
    * POST api/purchases - can be used to buy an item after authentication

2. Appropriate tests (unit, integration, etc)
    * There are a total of 27 automated tests
    * 18 unit tests covering domain, controllers and repositories.
    * 9 integration tests (TrovTHA.Tests/Integration), tests are performed against Owin test server allowing for in memory testing of a full http request and inspection of response.  Aspects covered in the tests include routing, authentication, data marshalling, persistence and error handling.


3. A quick explanation of:
    * a. choice of data format. Include one example of a request and response
        * json and xml data format was chosen as it allows for a broad range of clients to use the api, the formatter can be set using the Content-Type request header     
    * b. what authentication mechanism was chosen, and why 
        * token based authentication was chosen, since the Gilded Rose is expanding and this can scale to the cloud or multiple server farms.

        * sample request :
          * GET api/inventories
        * sample JSON format response : 
```
[{"Item":{"Name":"Apple","Description":"Gala apple.","Price":1.0,"DomainId":"1"},"NumberInStock":10,"ReOrderLevel":2,"Location":"Online","DomainId":"1"},{"Item":{"Name":"Orange","Description":"Sunkist orange.","Price":1.0,"DomainId":"2"},"NumberInStock":5,"ReOrderLevel":2,"Location":"Online","DomainId":"2"},{"Item":{"Name":"Ice Cream","Description":"Chocolate ice cream.","Price":5.0,"DomainId":"3"},"NumberInStock":1,"ReOrderLevel":2,"Location":"Online","DomainId":"3"},{"Item":{"Name":"Carton of Eggs","Description":"A dozen eggs.","Price":1.0,"DomainId":"4"},"NumberInStock":0,"ReOrderLevel":0,"Location":"Online","DomainId":"4"}]
```
