# LinqToLcbo

LinqToLcbo is a custom Linq Provider that allows querying the LCBO for products, stores, and inventories. Internally, queries translate into Web service calls sent to the [LCBO API](http://lcboapi.com). For detailed API information please check the [LCBO API Documentation] (http://http://lcboapi.com/docs/about).

## Query for products

```c#
	var lcbo = new LcboDataSource();
	
	var products = from product in data.Products
                    where product.SearchQuery == "heineken" && !product.IsDiscontinued
					orderby product.Price
                    select product;
	
	//Alternatively using lambda expression
	
	var products = lcbo.Products
		.Where(o => !o.IsDiscontinued && o.SearchQuery == "heineken")
		.OrderBy(o=>o.Price);
	
	foreach (Product p in products)
		Console.WriteLine(p.Name);
```