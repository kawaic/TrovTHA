# Trov Take Home Assignment
### By Ka-Wai Chan

### Deliverables
1. A system that can process the two API requests via HTTP
    * GET api/inventories can be used to retrieve the current inventory
    * POST api/purchases can be used to buy an item after authentication

2. Appropriate tests (unit, integration, etc)
    * There are a total of 27 automated tests
    * 9 integration tests, 18 unit tests

3. A quick explanation of:
    * a. choice of data format. Include one example of a request and response
        * json and xml data format was chosen as it would allow a broad range of clients to use the api, formatter can be set using the Content-Type request header        
	* request : GET api/inventories
	* response : [{"Item":{"Name":"Apple","Description":"Gala apple.","Price":1.0,"DomainId":"1"},"NumberInStock":10,"ReOrderLevel":2,"Location":"Online","DomainId":"1"},{"Item":{"Name":"Orange","Description":"Sunkist orange.","Price":1.0,"DomainId":"2"},"NumberInStock":5,"ReOrderLevel":2,"Location":"Online","DomainId":"2"},{"Item":{"Name":"Ice Cream","Description":"Chocolate ice cream.","Price":5.0,"DomainId":"3"},"NumberInStock":1,"ReOrderLevel":2,"Location":"Online","DomainId":"3"},{"Item":{"Name":"Carton of Eggs","Description":"A dozen eggs.","Price":1.0,"DomainId":"4"},"NumberInStock":0,"ReOrderLevel":0,"Location":"Online","DomainId":"4"}]

    * b. what authentication mechanism was chosen, and why 