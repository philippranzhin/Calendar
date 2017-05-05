// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppDelegate.cs" company="">
//   
// </copyright>
// <summary>
//   The app delegate.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.iOS
{
    using Foundation;

    using UIKit;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;

    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    /// <summary>
    ///     The app delegate.
    /// </summary>
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        /// <summary>
        /// The finished launching.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();
            this.LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}