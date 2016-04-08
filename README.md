# Capitalizer

Capitalization Styles Converter

Add namespace :

 ```c#
	using Capitalizer;
```

Usage :

 * Camel Case TO Pascal Case
 
 ```c#
	"camelCase".ToPascalCase() // result : "CamelCase"
```

 * Camel Case TO Pascal Case (Using text prefix)
 
 ```c#
	"_camelCase".ToPascalCase(Prefix.UnderScore) // result : "CamelCase"
```

 * Camel Case TO Pascal Case (Using result prefix)
 
 ```c#
	"camelCase".ToPascalCase(Prefix.None, Prefix.UnderScore) // result : "_CamelCase"
```

 * Pascal Case TO Camel Case
 
 ```c#
	"PascalCase".ToCamelCase() // result : "pascalCase"
```

 * Pascal Case TO Camel Case (Using text prefix)
 
 ```c#
	"_PascalCase".ToCamelCase(Prefix.UnderScore) // result : "pascalCase"
```

 * Pascal Case TO Camel Case (Using result prefix)
 
 ```c#
	"CamelCase".ToCamelCase(Prefix.None, Prefix.UnderScore) // result : "_camelCase"
```

 * Text Case TO Pascal Case
 
 ```c#
	"Pascal Case".ToPascalCase() // result : "PascalCase"
```

 * Text Case TO Camel Case
 
 ```c#
	"Camel Case".ToCamelCase() // result : "camelCase"
```

### Nuget Install

 ```powershell#
	Install-Package Capitalizer
```
