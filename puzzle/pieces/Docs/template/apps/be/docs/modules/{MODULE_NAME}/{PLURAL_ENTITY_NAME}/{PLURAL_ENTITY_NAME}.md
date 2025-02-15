## <Endpoint Name>

### Description:

Provide a brief description of what the endpoint does.

---

### URL:

`<Base URL>/<Endpoint Path>`

---

### Method:

`GET | POST | PUT | DELETE | PATCH`

---

### Parameters:

#### Query Parameters:

| Parameter Name | Type     | Required | Description                    |
|----------------|----------|----------|--------------------------------|
| `paramName`    | `string` | Yes      | <Describe the parameter here.> |

#### Path Parameters:

| Parameter Name | Type     | Description                           |
|----------------|----------|---------------------------------------|
| `id`           | `string` | A unique identifier for the resource. |

---

### Request Body:

```json
<Include an example request body if the endpoint supports POST or PUT methods.>
```

---

### Response:

#### Success Response:

**HTTP Status Code:** `200 OK`

```json
<Insert example response for a successfully processed request.>
```

#### Error Responses:

| HTTP Status Code | Description                               |
|------------------|-------------------------------------------|
| `400`            | BadRequest. Invalid input or data format. |
| `401`            | Unauthorized. Invalid or missing token.   |
| `404`            | NotFound. Resource does not exist.        |
| `500`            | Internal Server Error.                    |

---

### Constraints
- User must be logged

### More example calls

#### Get all by ....

`<Base URL>/<Endpoint Path>?params`

### Configuration

Example configuration.

### Affected files

Write files that were included in the prompt.

apps/be/.../SomeClass.cs
