.NET Developer Practium for Vee Harwell

Overview:
- Built with Visual Studio 2013
- Code structure has a menu processor class library project, a menu processor MSTest unit test project, and a console application project that consumes the menu processor
- There is a batch file (build.cmd) at the same level as the solution file that will build the project and run the unit tests from the command line.
- Unit tests include the examples given in the Practium documentation, plus my development tests are included below those to show the use of TDD to build the solution

Assumptions:
- For the command line build, I have an assumption that msbuild and mstest should be in the path and configured.   My testing for this build was done using a VS2013 developer command prompt.
- In the command build file I did make one environment change to avoid a platform error I was receiving on my laptop (not a true development machine).  Just wanted to make sure that was stated.
- Just used a batch file for the command line build, did not want to run the risk of using a build framework and having to include the dependencies for that in the solution.
- Just kept the namespaces for the project a single name namespaces, for the sake of simplicity.

If there are any questions or if you have any problems accessing the project, please feel free to reach out to me at vharwell@hotmail.com or 815-603-3010

Thanks!