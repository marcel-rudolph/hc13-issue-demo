# HotChocolate Issue Demo

...

## Steps to reproduce

1. Get auth token

```graphql
query { auth }
```

Return something like this:

```json
{
  "data": {
    "auth": "<JWT>"
  }
}
```

2. Use the output from step 1 in Authorization header

```graphql
query {
  colors { name hex }
}
```

with `Authorization: Bearer <JWT>` as header.

For before version 13 (here `13.0.0-rc.7`) you will get some data. But starting with version 13 you will get this:

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
