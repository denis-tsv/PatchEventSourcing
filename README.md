# PatchEventSourcing
We can't use JsonPatchDocument<T> in Event Sourcing because we need not only to update entity, but create events too.
PatchProperty<T> allows to split two cases: 
1. Property doesn't specified in HTTP request. In this case no vaidation and no entity change 
2. Property specified in HTTP request. In this case property validated and entity changed with event generation.

Product entity has requred property Name and optional Description. If Name specified in request then it will be validated and 400 status will be returned if Name id null of empty. But if Name not specified in request then it will not be validated.