import {
  DarkTheme,
  DefaultTheme,
  ThemeProvider,
} from "@react-navigation/native";
import { useFonts } from "expo-font";
import { Stack } from "expo-router";
import * as SplashScreen from "expo-splash-screen";
import { useEffect } from "react";
import "react-native-reanimated";
import * as Notifications from "expo-notifications";
import {
  requestNotificationPermissions,
  scheduleDailyNotification,
  cancelAllScheduledNotifications,
} from "../services/notifications";

import { useColorScheme } from "@/hooks/useColorScheme";
import { Platform } from "react-native";

SplashScreen.preventAutoHideAsync();

const isPhone = Platform.OS === "android" || Platform.OS === "ios";

if (isPhone) {
  Notifications.setNotificationHandler({
    handleNotification: async () => ({
      shouldShowAlert: true,
      shouldPlaySound: true,
      shouldSetBadge: false,
    }),
  });
}

export default function RootLayout() {
  const colorScheme = useColorScheme();
  const [loaded] = useFonts({
    SpaceMono: require("../assets/fonts/SpaceMono-Regular.ttf"),
  });

  useEffect(() => {
    if (!isPhone) {
      return;
    }

    cancelAllScheduledNotifications().then(() => {
      const setupNotifications = async () => {
        await requestNotificationPermissions();

        await scheduleDailyNotification(10, 0, "morning");
        await scheduleDailyNotification(14, 0, "afternoon");
        await scheduleDailyNotification(18, 0, "evening");
      };

      setupNotifications();
    });

    const subscription = Notifications.addNotificationResponseReceivedListener(
      (response) => {
        console.log(response);
      }
    );

    return () => {
      subscription.remove();
    };
  }, []);

  useEffect(() => {
    if (loaded) {
      SplashScreen.hideAsync();
    }
  }, [loaded]);

  if (!loaded) {
    return null;
  }

  return (
    <ThemeProvider value={colorScheme === "dark" ? DarkTheme : DefaultTheme}>
      <Stack screenOptions={{ title: "NutriTrack" }}>
        <Stack.Screen name="index" options={{ headerShown: false }} />
        <Stack.Screen name="signin" options={{ headerTitle: "Sign In" }} />
        <Stack.Screen
          name="statistics"
          options={{ headerTitle: "Statistics" }}
        />
        <Stack.Screen
          name="admindashboard"
          options={{ headerTitle: "Admin Dashboard" }}
        />
      </Stack>
    </ThemeProvider>
  );
}
