# DECISIONS.md

## 1. What did AI generate for you, and what did you write or modify yourself?

I used ChatGPT and claude as an assistant during development, primarily for:

- Converting C# DTOs into TypeScript interfaces.
- Answering Angular syntax questions related to Signals and the new control flow (`@for`, `@if`).
- helps me in HTML and CSS layouts for the Track List and Track Details pages.
- Explaining framework-specific errors and suggesting possible fixes.
- Providing guidance on Git, GitHub, and README documentation.

The application architecture, business logic, and implementation were completed by me, including:

- Clean Architecture project structure.
- Entity Framework Core configuration and migrations.
- Repository and service implementations.
- Track filtering logic.
- JWT authentication and authorization.
- API endpoints.
- Input validation.
- Angular services, routing, and component integration.
- Debugging and integrating the generated code into the project.

I reviewed and modified AI-generated code before using it in the project.

---

## 2. What security issues did you find (or introduce) in the AI-generated code? How did you handle them?

During development I reviewed AI-generated suggestions before applying them.

Some issues I considered included:

- Ensuring JWT-protected endpoints require authentication instead of leaving sensitive operations public.
- Validating all user input on the server side rather than relying only on frontend validation.
- Ensuring Entity Framework queries use parameterized SQL through LINQ to avoid SQL injection.
- Returning appropriate error messages without exposing internal exception details.
- Ensuring that protected API endpoints require JWT authentication instead of being publicly accessible.

Any generated code that did not follow these practices was modified before being used.

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

This allowed the correct GUID to be passed to the backend API and fixed the issue when loading track details.
