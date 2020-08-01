Solution design details
===========================
The solution is implemented using the Onion/Clean architecuture.

I tried to start with DDD for this practice, but the problem is too simple for a DDD, and thus, implemented using Clean architecture.

API is the outermost layer, which is dependent on application core layer at compile time. Infrastructure layer is also dependent on the application core layer as it should be. Database implementation is independent of the application core.


I have used internal IOC container for this exercise, otherwise I would be replacing it with Autofac.
Automapper is configured, and working well.