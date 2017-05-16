// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventToCommandBehavior.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The event to command behavior.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Views.MarkupExtensions.Behaviors
{
    using System;
    using System.Reflection;
    using System.Windows.Input;

    using Xamarin.Forms;

    /// <summary>
    ///     The event to command behavior. Prrovides ability to convert event to command
    /// </summary>
    public class EventToCommandBehavior : BehaviorBase<View>
    {
        /// <summary>
        ///     The event name property.
        /// </summary>
        public static readonly BindableProperty EventNameProperty = BindableProperty.Create(
            "EventName",
            typeof(string),
            typeof(EventToCommandBehavior),
            null,
            propertyChanged: OnEventNameChanged);

        /// <summary>
        ///     The command parameter property.
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            "CommandParameter",
            typeof(object),
            typeof(EventToCommandBehavior),
            null);

        /// <summary>
        ///     The command property.
        /// </summary>
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            "Command",
            typeof(ICommand),
            typeof(EventToCommandBehavior),
            null);

        /// <summary>
        ///     The input converter property.
        /// </summary>
        public static readonly BindableProperty InputConverterProperty = BindableProperty.Create(
            "Converter",
            typeof(IValueConverter),
            typeof(EventToCommandBehavior),
            null);

        /// <summary>
        ///     The event handler.
        /// </summary>
        private Delegate eventHandler;

        /// <summary>
        ///     Gets or sets the command.
        /// </summary>
        public ICommand Command
        {
            get
            {
                return (ICommand)this.GetValue(CommandProperty);
            }

            set
            {
                this.SetValue(CommandProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the command parameter.
        /// </summary>
        public object CommandParameter
        {
            get
            {
                return this.GetValue(CommandParameterProperty);
            }

            set
            {
                this.SetValue(CommandParameterProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the converter.
        /// </summary>
        public IValueConverter Converter
        {
            get
            {
                return (IValueConverter)this.GetValue(InputConverterProperty);
            }

            set
            {
                this.SetValue(InputConverterProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the event name.
        /// </summary>
        public string EventName
        {
            get
            {
                return (string)this.GetValue(EventNameProperty);
            }

            set
            {
                this.SetValue(EventNameProperty, value);
            }
        }

        /// <summary>
        /// The on attached to.
        /// </summary>
        /// <param name="bindable">
        /// The bindable.
        /// </param>
        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);
            this.RegisterEvent(this.EventName);
        }

        /// <summary>
        /// The on detaching from.
        /// </summary>
        /// <param name="bindable">
        /// The bindable.
        /// </param>
        protected override void OnDetachingFrom(View bindable)
        {
            this.DeregisterEvent(this.EventName);
            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        /// The on event name changed.
        /// </summary>
        /// <param name="bindable">
        /// The bindable.
        /// </param>
        /// <param name="oldValue">
        /// The old value.
        /// </param>
        /// <param name="newValue">
        /// The new value.
        /// </param>
        private static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            EventToCommandBehavior behavior = (EventToCommandBehavior)bindable;
            if (behavior.AssociatedObject == null)
            {
                return;
            }

            string oldEventName = (string)oldValue;
            string newEventName = (string)newValue;

            behavior.DeregisterEvent(oldEventName);
            behavior.RegisterEvent(newEventName);
        }

        /// <summary>
        /// The deregister event.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <exception cref="ArgumentException">
        /// <typeparam name="exception"></typeparam> 
        /// </exception>
        private void DeregisterEvent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            if (this.eventHandler == null)
            {
                return;
            }

            EventInfo eventInfo = this.AssociatedObject.GetType().GetRuntimeEvent(name);
            if (eventInfo == null)
            {
                throw new ArgumentException($"EventToCommandBehavior: Can't de-register the '{this.EventName}' event.");
            }

            eventInfo.RemoveEventHandler(this.AssociatedObject, this.eventHandler);
            this.eventHandler = null;
        }

        /// <summary>
        /// The on event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        private void OnEvent(object sender, object eventArgs)
        {
            if (this.Command == null)
            {
                return;
            }

            object resolvedParameter;
            if (this.CommandParameter != null)
            {
                resolvedParameter = this.CommandParameter;
            }
            else if (this.Converter != null)
            {
                resolvedParameter = this.Converter.Convert(eventArgs, typeof(object), null, null);
            }
            else
            {
                resolvedParameter = eventArgs;
            }

            if (this.Command.CanExecute(resolvedParameter))
            {
                this.Command.Execute(resolvedParameter);
            }
        }

        /// <summary>
        /// The register event.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <exception cref="ArgumentException">
        /// <typeparam name="exception"></typeparam>
        /// </exception>
        private void RegisterEvent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            EventInfo eventInfo = this.AssociatedObject.GetType().GetRuntimeEvent(name);
            if (eventInfo == null)
            {
                throw new ArgumentException($"EventToCommandBehavior: Can't register the '{this.EventName}' event.");
            }

            MethodInfo methodInfo = typeof(EventToCommandBehavior).GetTypeInfo().GetDeclaredMethod("OnEvent");
            this.eventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            eventInfo.AddEventHandler(this.AssociatedObject, this.eventHandler);
        }
    }
}