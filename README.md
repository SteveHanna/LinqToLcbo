# LinqToLcbo

LinqToLcbo is a custom Linq Provider that allows querying the LCBO for products, stores, and inventories. Internally, queries translate into Web service calls sent to the [LCBO API](http://lcboapi.com). For detailed API information please check the [LCBO API Documentation] (http://http://lcboapi.com/docs/about).

## Sample Code: Query for products with filter & sorting

'''c#
	var lcbo = new LcboDataSource();
	
	var products = from product in data.Products
                    where product.SearchQuery == "heineken" && !product.IsDiscontinued
					orderby product.Price
                    select product;
	
	//Or using lambda expression
	
	var products = lcbo.Products.Where(o => !o.IsDiscontinued && o.SearchQuery == "heineken").OrderBy(o=>o.Price);
	
	foreach (Product p in products)
		Console.WriteLine(p.Name);
'''