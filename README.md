This repo demonstrates a bug with the Microsoft.OData.Client library. DataServiveQuery<T>.GetKeyPath generates an incorrect key path when the keyString passed to it contains query options.

For example, I want to get a single entity from the Person controller. The key for the person I want is 'russellwhyte'. I want to use the GET /People('russellwhyte') method. I also want to include this persons friends, so I add the $expand(Friends) query option.

The expected generated key path is "/People('russellwhyte')?$expand=Friends".
The actual generated key path is "/People?$expand=Friends('russellwhyte')"
