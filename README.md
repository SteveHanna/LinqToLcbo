# LinqToLcbo

LinqToLcbo is a custom LINQ Provider that allows querying the LCBO for products, stores, and inventories. Internally, queries translate into Web service calls sent to the [LCBO API](http://lcboapi.com). For detailed API information please see the [LCBO API Documentation] (http://http://lcboapi.com/docs/about).

## Query for products

```c#
	var lcbo = new LcboDataSource();
	
	var products = lcbo product in data.Products
                    where product.SearchQuery == "heineken" && !product.IsDiscontinued
					orderby product.Price
                    select product;
	
	//Alternatively using lambda expressions
	var products = lcbo.Products
		.Where(o => !o.IsDiscontinued && o.SearchQuery == "heineken")
		.OrderBy(o=>o.Price);
	
	foreach (Product p in products)
		Console.WriteLine(p.Name);
```

## Query for stores then products

```c#
	var lcbo = new LcboDataSource();
	
	var stores = (from s in lcbo.Stores
                        where s.Geolocation == "Spadina"
                        orderby s.Distance
                        select s).ToList();

	var products = from p in stores[0].Products
				   where p.SearchQuery == "heineken"
				   select p;
	
	//Alternatively using lambda expressions
	var stores = lcbo.Stores.Where(o => o.Geolocation == "Spadina").OrderBy(o => o.Distance).ToList();
	var products = stores[0].Products.Where(o => o.SearchQuery == "heineken");
	
	foreach (Product p in products)
		Console.WriteLine(p.Name);
```

### Query for a product's inventory at specific store

```c#
	var lcbo = new LcboDataSource();
	
	 Inventory inventoryAtKing = (from i in lcbo.Inventories
								  where i.ProductId == 18 && i.StoreId == 511
								  select i).Single();
					
	//Alternatively using lambda expressions
	Inventory inventoryAtKing = lcbo.Inventories.Single(o => o.StoreId == 511 && o.ProductId == 18);
	
	Console.WriteLine(inventoryAtKing.Quantity);
```

## Not your average LINQ Provider

This project is an exercise in demonstrating the flexibility of LINQ. Since LINQ works as a language pattern (like foreach), implementing IQueryable<T> is not necessary. Instead, this project only implements a subset of the Standard Query Operators to provide a rich compiler enforced query syntax.