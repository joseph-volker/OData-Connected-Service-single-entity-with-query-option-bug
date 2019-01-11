This repo demonstrates a bug with the OData Connected Service version 0.3.0 extension for Visual Studio 2017. The generated client code generates an incorrect URL for single entity queries with query options.

For example, I want to get a single entity from the Person controller. I want to use the GET Persons(personId) method. I also want to include this persons friends, so I add the $expand(Friends) query option.

The expected generated path is "/People('russellwhyte')?$expand=Friends".
The actual generated path is "/People?$expand=Friends('russellwhyte')"
