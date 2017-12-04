# CompanyDbWebAPI
Web API project to give access to CRUD functionalities on the solution database

It is hosted on IIS and a separate port from its two client applications MainIntranetApp and CompanyDbUpdate.

The project also defines the solution’s database using Entity framework code-first. Thus migrations are always done from here and domain classes and their relationships mirroring the solution’s database are defined here.

