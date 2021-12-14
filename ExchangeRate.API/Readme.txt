To run this API:

   Clone it from https://github.com/pavlekukric/ExchangeRate

NOTE: Date format should be: yyyy-MM-dd

Method 1 (Integration test):
1. In ExchangeRateControllerTest, just run Returns_Data_With_Valid_Request test and inspect response
   

Method 2 (postman):
1. Run API locally
2. From Postman - New HTTP Request . 
3. Enter https://localhost:44358/api/ExchangeRate/ as an address
4. Select POST method
5. Body -> Row -> JSON enter request body palyload. Example:

   {"Dates":["2021-02-01","2018-02-15"],"BaseCurrency":"SEK","TargetCurrency":"NOK"}

Method 3 (Azure API endpoint):
1. From Postman - New HTTP Request . 
2. Enter https://exchangerateapi-pk.azurewebsites.net/api/ExchangeRate/ as an address
3. Select POST method
4. Body -> Row -> JSON enter request body palyload. Example:

   {"Dates":["2021-02-01","2018-02-15"],"BaseCurrency":"SEK","TargetCurrency":"NOK"} 


TODO:
Validate currency

Unit tests

Additional Integration tests

Logging

Cashing 
    Since historical currency is immutable it make sense to add caching 
    Also, add all currencies into internal system in order to pre-validate BaseCurrency and TargetCurrency before hitting the API

Encapsulate validation and logging into separate "decorated" services

Additional error handling to inform the consumer with more details about error (i.e which date is 'problematic')

Investigation about throttling needed. Based on this limit we should execute calls against the https://exchangerate.host/ in batch.

All https://exchangerate.host/ API endpoints references should be places inside configuration file 


Other...

