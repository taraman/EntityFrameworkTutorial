<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Lazy Eager Explicit Loading</title>
		<style type="text/css">
			body {
				font-family: Arial;
				font-size: 14px;
			}
		</style>
	</head>
	<body>
		
		<h2>Lazy and Eager Loading</h2>
		<div style="margin: 0 0 0 20px">
			<b>Lazy Loading vs. Eager Loading</b><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/LazyLoading">Lazy Loading (Immediate Execution)</a><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/EagerLoading">Eager Loading (Immediate Execution)</a><br/><br/><br/>
			
			
			<b>Eager Loading Cases</b><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/EagerLoadingWithLessIncludes">Eager Loading With Less Includes</a><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/EagerLoadingWithExactIncludes">Eager Loading With Exact Includes</a><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/EagerLoadingWithMoreIncludes">Eager Loading With More Includes</a><br/><br/><br/>
			

			<b>Best Practices: Lazy Loading with Deferred Execution to combine/extend multiple queries</b><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/LazyLoadingDeferredExecution?getSuppliers=true">Lazy Loading with Deferred Execution (get suppliers)</a><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/LazyLoadingDeferredExecution?getSuppliers=false">Lazy Loading with Deferred Execution (get categories)</a><br/><br/><br/>
			

			<b>Using Iteration with Deffered Execution</b><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/LazyLoadingWithForeach">Problem: Lazy Loading, Iteration using Foreach loop (Deffered Execution)</a><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/EagerLoadingForeach">Fixing: Eager Loading, Iteration using Foreach loop (Deffered Execution)</a><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/LazyLoadingLinqExpression">Better Fixing: Lazy Loading, Iteration using Linq Expression (Deffered Execution)</a><br/><br/><br/>

			
			<b>Queries that return a singleton value are executed immediately</b><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/LazyLoadingSingletonValue">Lazy Loading: return a singleton value</a><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/EagerLoadingSingletonValue">Eager Loading: return a singleton value</a><br/><br/><br/>
			
			
			<b>Using Find() method and FirstOrDefault() method</b><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/UsingFindMethod">Using Find() Method</a><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/UsingFirstOrDefault">Using FirstOrDefault() method</a><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/FindVersusFirstOrDefault">Find() method Versus FirstOrDefault() method</a><br/><br/><br/>
		</div>
		
		<h2>Explicit Loading</h2>
		<div style="margin: 0 0 0 20px">
			<b>Lazy Loading vs. Eager Loading</b><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/ExplicitlyLoadingForSingleEntity">Explicitly Loading For Single Entity</a><br/>
			<a target="_blank" href="/LazyEagerExplicitLoading/ExplicitlyLoadingForManyEntities">Explicitly Loading For Many Entities</a><br/><br/><br/>
		</div>

	</body>
</html>
