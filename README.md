# WooliesX

## Publish URL
https://masonazuretest20190809110703.azurewebsites.net

## Q1
Demo the Azure setup, publish basic API end point.

## Q2
Demo linq order by, recommaned sort requires an API call to get external data, then more linq to sort.

## Q3
Interesting one, limited question descripition seems to let chanllenger to find out what's the data structure and business logic
to calculate lowest special price.

To find out what data is posted to my API during testing, I added some log to save the posted object and found it in
Azure application log.

Even with the data and answer, the business logic is still in vague. Trying to figure it out, but finally gave up. You can still
find some clue in my unfinished code. Many loop or linq to look up object in different collections.

## Code structure
Basically follows simple Controller/Service/Model layer, demo abstraction via interface and dependency injection.
Added one simple unit tests to show some basic understanding.
