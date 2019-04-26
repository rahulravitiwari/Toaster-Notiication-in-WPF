using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Core;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace TosterNotify
{
    public class ToasterNotification
    {

        #region Initialization
        Notifier notifier;
        private NotificationUI NotificationUI = null;
        #endregion
        #region Enums
        enum ToasterSize
        {
            Three = 3,
            Five = 5,
            Fourteen = 14,
            Ten = 10
        }
        #endregion


        public ToasterNotification()
        {
            NotificationUI = new NotificationUI();

        }

        #region Show Notificatin Method
        /// <summary>
        /// This method is used for show the toaster notification
        /// </summary>
        /// <param name="currentWindow"></param>
        /// <param name="notification"></param>
        public void ShowUINotification(Window currentWindow, NotificationUI notification)
        {
            try
            {
                notifier = new Notifier(cfg =>
                {
                    cfg.PositionProvider = new WindowPositionProvider(parentWindow: currentWindow, corner: Corner.TopRight,
                    offsetX: Convert.ToInt32(ToasterSize.Ten), offsetY: Convert.ToInt32(ToasterSize.Ten));
                    cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(Convert.ToInt32(ToasterSize.Three)),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(Convert.ToInt32(ToasterSize.Five)));
                    cfg.Dispatcher = Application.Current.Dispatcher;
                });
                MessageOptions messageOptions = new MessageOptions();
                messageOptions.FontSize = Convert.ToInt32(ToasterSize.Fourteen);
                messageOptions.UnfreezeOnMouseLeave = true;
                if (notification.MessageType == "warning")
                {
                    notifier.ShowWarning(notification.Message, messageOptions);
                }
                else if (notification.MessageType == "success")
                {
                    notifier.ShowSuccess(notification.Message, messageOptions);
                }
                else if (notification.MessageType == "error")
                {
                    notifier.ShowError(notification.Message, messageOptions);
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region AssignModelValue In Notification
        /// <summary>
        /// Method to display toaster notification
        /// </summary>
        /// <param name="CurrentWindow"></param>
        /// <param name="MessageType"></param>
        /// <param name="Message"></param>
        public void SetNotificationModel(Window CurrentWindow, string MessageType, string Message)
        {
            NotificationUI.OffsetX = 10;
            NotificationUI.OffsetY = 10;
            NotificationUI.MessageType = MessageType;
            NotificationUI.Message = Message;
            ShowUINotification(CurrentWindow, NotificationUI);
        }
        #endregion
    }



}

