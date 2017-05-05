// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateVmHandler.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The date view model handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Infrastrucure.DateVmBase
{
    /// <summary>
    ///     The date view model handler. Describes events, that have been invoked when the DateVm need the new view model.
    /// </summary>
    /// <param name="sender">
    ///     The sender.
    /// </param>
    /// <param name="newDateVm">
    ///     The new date view model 
    /// </param>
    public delegate void DateVmHandler(IDateVm sender, DateVm newDateVm);
}