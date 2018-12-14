# product-api

API is documented using Swagger - you can access documentation page via `https://localhost:5001/swagger`. Basic unit tests are covered by `Product.Api.UniTests` project - of course It might be considered to be extended - firstly by adding tests covering other parts of the source, then by adding integration tests, especially when storage would be replaced with something "persistent" (for now it is in-memory collection).
Security might be assured by introducing authentication via JWT token. It would mean that there should be introduced some endpoint performing token generation; then `ProductsController` might be decorated with `[Authorize]` attribute, what would enforce authorization; finally out-of-the box JWT authorization should be configured in `Startup.cs`.

