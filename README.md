# HotChocolate Issue Demo

...

## Steps to reproduce

1. Get auth token

Run this query:

```graphql
query { auth }
```

which will return something like that:

```json
{
  "data": {
    "auth": "<JWT>"
  }
}
```

2. Query some data with the auth token from the previous step

```graphql
query {
  colors {
    name
    hex
  }
}
```

with `Authorization: Bearer <JWT>` as header.

In the **Before**-Project, wich runs on version `13.0.0-rc.7`, you will get some data.

In the **After**-Project, which runs with version `13.0.0` you will get this:

```json
{
  "errors": [
    {
      "message": "The current user is not authorized to access this resource.",
      "extensions": {
        "code": "AUTH_NOT_AUTHORIZED"
      }
    }
  ]
}
```
