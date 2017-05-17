// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileHelper.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the IFileHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.DataBase.Interfaces
{
    /// <summary>
    /// The FileHelper interface. Describes objects, that can get actual file path in current case
    /// </summary>
    public interface IFileHelper
    {
        /// <summary>
        /// Gets actual database file path in current case.
        /// </summary>
        /// <param name="filename">
        /// The filename.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetDateBasePath(string filename);
    }
}
