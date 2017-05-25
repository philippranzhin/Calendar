// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DroidFileHelper.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the DroidFileHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Akvelon.Calendar.Droid;

using Xamarin.Forms;

[assembly: Dependency(typeof(DroidFileHelper))]

namespace Akvelon.Calendar.Droid
{
    using System;
    using System.IO;

    using Database.DataBase.Interfaces;

    /// <summary>
    /// The droid file helper.
    /// </summary>
    public class DroidFileHelper : IFileHelper
    {
        /// <summary>
        /// The path.
        /// </summary>
        private string path;

        /// <summary>
        /// The get date base path.
        /// </summary>
        /// <param name="filename">
        /// The filename.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetDateBasePath(string filename)
        {
            if (this.path != null)
            {
                return this.path;
            }

                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                string finalPath = Path.Combine(documentsPath, filename);

                this.path = finalPath;

                return this.path;
        }
    }
}