using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace OwinMiddleWareConsoleApp
{

    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class StronglyTypedMiddlewareClass : OwinMiddleware
    {
        public StronglyTypedMiddlewareClass(OwinMiddleware next) : base (next)
        {
            Console.WriteLine("StronglyTypedMiddlewareClass instantiated.");
        }

        public async override Task Invoke(IOwinContext context)
        {
            Console.WriteLine("StronglyTypedMiddlewareClass was invoked");
            await Next.Invoke(context);
        }
    }



    public class MiddlewareClass
    {
        private AppFunc _next;
        private MiddleWareDependency _dependency;


 

        public MiddlewareClass (AppFunc next, MiddleWareDependency dependency)
        {
            Console.WriteLine("MiddlewareClass instantiated.");
            _next = next;
            _dependency = dependency;
        }

        public async Task Invoke(IDictionary<string , object> environment)
        {
            Console.WriteLine("Middleware class invoked.");
            await _next.Invoke(environment);
        }
    }


    public class AnotherMiddlewareClass
    {
        private AppFunc _next;
        private MiddleWareDependency _dependency;



        public void Initialize(AppFunc next)
        {
            this._next = next;
        }



        public AnotherMiddlewareClass(MiddleWareDependency dependency)
        {
            Console.WriteLine("MiddlewareClass instantiated.");
            
            _dependency = dependency;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            Console.WriteLine("Middleware class invoked.");
            await _next.Invoke(environment);
        }
    }

    public class MiddleWareDependency
    {

        public MiddleWareDependency()
        {
            Console.WriteLine("MiddleWareDependency Constructor called");
        }

        public void DependencyMethod()
        {
            Console.WriteLine("MiddleWareDependency method was called");
        }

    }
}
