// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Main.cs" company="Akvelon">
//   Philipp Ranzhin Application
// </copyright>
// <summary>
//   The entry point of iOS application
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.iOS
{
    using UIKit;

    /// <summary>
    ///     The application.
    /// </summary>
    public class Application
    {
        // This is the main entry point of the application.
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}