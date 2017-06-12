// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FadeTriggerAction.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The fade trigger action.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Views.MarkupExtensions.TriggerActions
{
    using Xamarin.Forms;

    /// <summary>
    /// Class, that provides an ability to use simple opacity animation in markup
    /// </summary>
    public class FadeTriggerAction : TriggerAction<VisualElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FadeTriggerAction"/> class.
        /// </summary>
        public FadeTriggerAction()
        {
        }

        /// <summary>
        /// Gets or sets value, that indicates which value the animation begins with.
        /// </summary>
        public double From { get; set; } = 0;

        /// <summary>
        /// Gets or sets value, that indicates which value the animation ends with.
        /// </summary>
        public double To { get; set; } = 1;

        /// <summary>
        /// Gets or sets the animation length.
        /// </summary>
        public uint Length { get; set; } = 280;

        /// <summary>
        /// The invoke.
        /// </summary>
        /// <param name="visual">
        /// The visual.
        /// </param>
        protected override void Invoke(VisualElement visual)
        {
            visual.Opacity = this.From;
            visual.FadeTo(this.To, this.Length);
            visual.Scale = this.From;
            visual.ScaleTo(this.To, this.Length);
        }
    }
}