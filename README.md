This repo showcases a bug in the handling of json parsing in fusion

instructions:
  * run the aspire project
  * navigate to http://localhost:5057/graphql (or whatever url/port aspire gave the gateway)
  * run this query
```
query {
  foo(
    barInput: "One Two Three"
  ) {
    fooDescription
    fooId
    fooName
  }
}
```

Notice that you get a ServerParseError:

the validation object in "extensions" is being set to : "validationFailures\":[}}] which is invalid json

