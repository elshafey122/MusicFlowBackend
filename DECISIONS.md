# DECISIONS.md

## 1. What did AI generate for you, and what did you write or modify yourself?

I used ChatGPT and Claude as development assistants throughout the project. They helped me generate initial code, explain framework behavior, troubleshoot issues, and improve documentation. All AI-generated code was reviewed, tested, and modified before being integrated into the project.

### AI-assisted work

- Converting C# DTOs into TypeScript interfaces.
- Explaining Angular Signals and the new control flow syntax (`@if`, `@for`).
- Assisting with HTML and CSS layouts for the Track List and Track Details pages.
- Explaining framework-specific errors and suggesting possible fixes.
- Providing guidance on Git, GitHub, and project documentation (README.md).

### Implemented and modified by me

#### Backend

- Designed and implemented the Clean Architecture project structure.
- Configured Entity Framework Core and created database migrations.
- Implemented repositories, services, and business logic.
- Developed the required API endpoints.
- Implemented JWT authentication and authorization.
- Added input validation and meaningful error responses.
- Seeded the database with artists, tracks, DSPs, and users.
- Integrated and tested all backend components.

#### Frontend

- Implemented Angular routing.
- Developed the Register and Login pages.
- Integrated JWT authentication with the backend.
- Implemented Angular services for API communication.
- Built the Track List and Track Details pages.
- Added filtering by track status.
- Connected frontend components with backend endpoints.
- Debugged and integrated AI-generated suggestions into the final application.

Although AI accelerated development, I reviewed every generated suggestion, modified it where necessary, and ensured it matched the project's requirements before using it.

---

## 2. What security issues did you find (or introduce) in the AI-generated code? How did you handle them?

During development, I reviewed AI-generated code before integrating it into the project.

While reviewing the generated code, I verified that:

- Protected API endpoints required JWT authentication.
- User input was validated on the backend instead of relying only on frontend validation.
- Entity Framework Core LINQ queries were used instead of raw SQL, reducing the risk of SQL injection.
- API responses did not expose unnecessary implementation details through exception messages.

Whenever an AI-generated suggestion did not align with these security practices or the project's architecture, I modified it before using it.

---

## 3. One thing the AI got wrong that you had to fix

One issue involved retrieving the track ID from the Angular route.

The AI-generated code treated the route parameter as a number:

```typescript
this.trackId = Number(this.route.snapshot.paramMap.get('id'));
```

However, the application uses GUIDs as track identifiers, so converting the route parameter to a number resulted in `NaN`.

I corrected the implementation by treating the route parameter as a string:

```typescript
this.trackId = this.route.snapshot.paramMap.get('id')!;
```

This allowed the correct GUID to be passed to the backend API and fixed the issue when loading the track details.
