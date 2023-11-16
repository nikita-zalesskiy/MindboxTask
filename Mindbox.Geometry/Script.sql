SELECT p.ProductName, c.CategoryName
FROM Product p
LEFT JOIN ProductCategory pc
	ON pc.ProductId = p.ProductId
LEFT JOIN Category c
	ON c.CategoryId = pc.CategoryId