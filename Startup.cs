using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OwinMiddleWareConsoleApp.Startup))]

namespace OwinMiddleWareConsoleApp
{
    /// <summary>
    ///  Source: http://benfoster.io/blog/how-to-write-owin-middleware-in-5-different-steps
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            app.Use(typeof(StronglyTypedMiddlewareClass));
            app.Use(typeof(MiddlewareClass), new MiddleWareDependency());

            //the above line for dependency injection can also be done like this below - 
            MiddleWareDependency dep = new MiddleWareDependency();
            AnotherMiddlewareClass amw = new AnotherMiddlewareClass(dep);
            app.Use(amw);

            //MiddlewareClass mw = new MiddlewareClass(null, dep);// this doesnt work: Check this link for answers: http://stackoverflow.com/questions/30152602/passing-in-a-parameter-to-appfunc
            //app.Use(mw);

        }
    }
}
