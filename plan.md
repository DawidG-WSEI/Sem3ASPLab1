# Project Plan

## Foundations

- Clean architecture template based on [Jason Taylor’s CleanArchitecture](https://github.com/jasontaylordev/CleanArchitecture)
- Useful things to check:  
- - Onion architecture
- - Swagger
- - ASP.NET core web api
- - JWT

---

## Main Entities

- **Song**: id, title, artistId, listenedTimes, createdAt, updatedAt
- **Artist**: id, name, centsPerThousandListeners, createdAt, updatedAt
- **Listener**: id, name, favouriteSongsIds, createdAt, updatedAt

---

## Layers

- [x] Domain (Done – entities, logic)
- [x] Application (use cases, interfaces, DTOs, handlers)
- [x] Infrastructure (Implement interfaces, DB, JWT, etc.)
- [x] WebAPI (Controllers, endpoints, middleware)
- [x] Unit tests (commands & queries)
- [ ] WebApplicationAdmin (UI)

---

## REST API (Spotify Domain)

- [x] Song CRUD endpoints
- [x] Artist CRUD endpoints
- [x] Listener CRUD endpoints
- [x] Middleware for HTTP status codes and error handling
- [x] JWT authentication  
- [ ] and role-based authorization
- [x] EF InMemory database setup
- [x] Swagger/OpenAPI docs -> `/api`
- [x] Unit tests of core logic
- [x] cURL script to test API endpoints

---

## Razor Pages Admin Panel or other stack

- [ ] Song list (with filtering by artist/user)
- [ ] Song detail/edit/delete
- [ ] Artist list/add/edit/delete (only matching ID or admin)
- [ ] User list/add/edit/delete (admin only)
- [ ] Role-based access (admin, listener, artist)
- [ ] Login page (JWT-based)
- [ ] Integrate with REST API

---
