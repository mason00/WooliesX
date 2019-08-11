# WooliesX

## Publish URL
https://masonazuretest20190809110703.azurewebsites.net

## Q1
Demo the Azure setup, publish basic API endpoint.

## Q2
Demo  LINQ  order by, recommended sort requires an API call to get external data, then more LINQ to sort.

## Q3
Interesting one, limited question description seems to let challenger find out what's the data structure and business logic to calculate the lowest special price.

To find out what data is posted to my API during testing, I added some log to save the posted object and found it in the Azure application log.

Even with the data and answer, the business logic is still vague. Trying to figure it out, but finally gave up. You can still find some clue in my unfinished code. Many loop or LINQ to look up the object in different collections.

Code structure
Basically follow simple Controller/Service/Model layer, demo abstraction via interface and dependency injection. Added one simple unit tests to show some basic understanding.

## Q3 last try
I get one right, guess that's the simple one.
Trolley total (14) returned correctly.

For the hard one, the return result seems wired. I checked posted data, the prices are all integer, not sure why it returns number
with a point, decimal.
Calculated trolley totals don't match. Provided Total: 154. Expected Total: 157.85810507501413.
