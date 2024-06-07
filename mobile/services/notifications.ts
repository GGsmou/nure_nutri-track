import * as Notifications from "expo-notifications";

export const requestNotificationPermissions = async () => {
  const { status: existingStatus } = await Notifications.getPermissionsAsync();
  let finalStatus = existingStatus;

  if (existingStatus !== "granted") {
    const { status } = await Notifications.requestPermissionsAsync();
    finalStatus = status;
  }

  if (finalStatus !== "granted") {
    alert("Failed to get push token for push notification!");
    return;
  }
};

export const scheduleDailyNotification = async (
  hour: number,
  minute: number,
  identifier: string
) => {
  await Notifications.scheduleNotificationAsync({
    content: {
      title: "Hydration Reminder",
      body: "Time to drink some water!",
      sound: true,
    },
    trigger: {
      hour,
      minute,
      repeats: true,
    },
  });
};

export const cancelAllScheduledNotifications = async () => {
  await Notifications.cancelAllScheduledNotificationsAsync();
};
