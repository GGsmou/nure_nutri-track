import React, { useEffect } from "react";
import { View, ActivityIndicator, StyleSheet } from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { router } from "expo-router";

const InitialScreen: React.FC = () => {
  useEffect(() => {
    const checkToken = async () => {
      try {
        const token = await AsyncStorage.getItem("token");
        const isAdmin = JSON.parse(
          (await AsyncStorage.getItem("isAdmin")) || "false"
        );

        if (token && !isAdmin) {
          router.replace("/statistics");
        } else if (token && isAdmin) {
          router.replace("/admindashboard");
        } else {
          router.replace("/signin");
        }
      } catch (error) {
        console.error("Failed to check token:", error);
        router.replace("/signin");
      }
    };

    checkToken();
  }, [router]);

  return (
    <View style={styles.container}>
      <ActivityIndicator size="large" color="#0000ff" />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
  },
});

export default InitialScreen;
