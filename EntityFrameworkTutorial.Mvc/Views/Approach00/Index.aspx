<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Title</title>
		<style type="text/css">
			body {
				font-family: Arial;
				font-size: 14px;
			}
			
		</style>
	</head>
	<body>
		<h2>Generic Repository</h2>
		<div style="margin: 0 0 0 20px">
			<b>Get All Products</b><br/>
			<a target="_blank" href="/Approach00/GetAllProducts">Get All Products</a><br/>
			<a target="_blank" href="/Approach00/GetAllProductsWithCategories">Get All Products With Categories</a><br/>
			<a target="_blank" href="/Approach00/GetAllProductsOrdredByProductName">Get All Products Ordred By ProductName</a><br/>
			<a target="_blank" href="/Approach00/GetAllProductsWithCategoriesOrdredByProductName">Get All Products With Categories Ordred By ProductName</a><br/><br/><br/>
			
			<b>Get Second 10 Products Ordred By Product Name</b><br/>
			<a target="_blank" href="/Approach00/GetSecond10ProductsOrdredByProductName">Get Second 10 Products</a><br/>
			<a target="_blank" href="/Approach00/GetSecond10ProductsWithCategoriesOrdredByProductName">Get Second 10 Products With Categories</a><br/><br/><br/>
			
	
			<b>Get Products With Condition</b><br/>
			<a target="_blank" href="/Approach00/GetProductsWithCondition">Get Products With Condition</a><br/>
			<a target="_blank" href="/Approach00/GetProductsWithConditionWithCategories">Get Products With Condition With Categories</a><br/>
			<a target="_blank" href="/Approach00/GetProductsWithConditionOrdredByProductName">Get Products With Condition Ordred By ProductName</a><br/>
			<a target="_blank" href="/Approach00/GetProductsWithConditionWithCategoriesOrdredByProductName">Get Products With Condition With Categories Ordred By Produc tName</a><br/><br/><br/>
			

			<b>Get Second 10 Products With Condition Ordred By Product Name</b><br/>
			<a target="_blank" href="/Approach00/GetSecond10ProductsWithConditionOrdredByProductName">Get Second 10 Products</a><br/>
			<a target="_blank" href="/Approach00/GetSecond10ProductsWithConditionWithCategoriesOrdredByProductName">Get Second 10 Products With Categories</a><br/><br/><br/>
			
			
			<b>Get By Key</b><br/>
			<a target="_blank" href="/Approach00/GetProductUsingPredicate">Get Product Using Predicate</a><br/>
			<a target="_blank" href="/Approach00/GetProductUsingFind">Get Product Using Find</a><br/>
			<a target="_blank" href="/Approach00/GetOrderDetailUsingFind">Get Order Detail Using Find</a><br/><br/><br/>


			<b>Insert</b><br/>
			<a target="_blank" href="/Approach00/Insert">Insert</a><br/>
			<a target="_blank" href="/Approach00/InsertAndCommit">Insert And Commit</a><br/><br/><br/>
		

			<b>Update</b><br/>
			<a target="_blank" href="/Approach00/Update">Update</a><br/>
			<a target="_blank" href="/Approach00/UpdateAndCommit">Update And Commit</a><br/><br/><br/>
			

			<b>Delete</b><br/>
			<a target="_blank" href="/Approach00/Delete">Delete</a><br/>
			<a target="_blank" href="/Approach00/DeleteAndCommit">Delete And Commit</a><br/>
			<a target="_blank" href="/Approach00/DeleteManyProducts">Delete Many Products</a><br/><br/><br/>
			
			
			<b>Using Entity Repository</b><br/>
			<a target="_blank" href="/Approach00/GetProductsBySupplierId">Get Products By Supplier Id</a><br/><br/><br/>
		
		</div>
	</body>
</html>
