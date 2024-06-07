import React, { useState } from "react";
import {
  StyleSheet,
  SafeAreaView,
  TextInput,
  TouchableOpacity,
  Text,
  View,
  Alert,
} from "react-native";
import { signIn } from "../services/apiService";
import { router } from "expo-router";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useTheme } from "@react-navigation/native";

const SignInScreen = () => {
  const { colors } = useTheme();

  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [loading, setLoading] = useState<boolean>(false);

  const handleSignIn = async () => {
    setLoading(true);
    try {
      await signIn(email, password);

      Alert.alert("Sign In Success", `Welcome!`);

      const isAdmin = JSON.parse(
        (await AsyncStorage.getItem("isAdmin")) || "false"
      );

      if (isAdmin) {
        router.replace("/admindashboard");
      } else {
        router.replace("/statistics");
      }
    } catch (error: any) {
      Alert.alert("Sign In Failed", error.message || "An error occurred");
    } finally {
      setLoading(false);
    }
  };

  const handleReset = () => {
    setEmail("");
    setPassword("");
  };

  return (
    <SafeAreaView style={styles.container}>
      <TextInput
        style={[styles.input, { color: colors.text }]}
        placeholder="Email"
        onChangeText={setEmail}
        autoComplete="email"
        value={email}
        keyboardType="email-address"
        autoCapitalize="none"
      />

      <TextInput
        style={[styles.input, { color: colors.text }]}
        placeholder="Password"
        onChangeText={setPassword}
        value={password}
        autoComplete="password"
        secureTextEntry
      />

      <View style={styles.buttons}>
        <TouchableOpacity
          style={styles.submitButton}
          onPress={handleSignIn}
          disabled={!email || !password || loading}
          activeOpacity={0.8}
        >
          <Text style={styles.buttonText}>
            {loading ? "Signing In..." : "Sign In"}
          </Text>
        </TouchableOpacity>

        <TouchableOpacity
          style={styles.resetButton}
          onPress={handleReset}
          disabled={!email || !password || loading}
          activeOpacity={0.8}
        >
          <Text style={styles.buttonText}>Reset</Text>
        </TouchableOpacity>
      </View>
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  container: {
    justifyContent: "flex-start",
    alignItems: "center",
    marginTop: 120,
    paddingHorizontal: 20,
  },
  logo: {
    fontSize: 24,
    fontWeight: "bold",
  },
  input: {
    width: "100%",
    height: 40,
    borderWidth: 1,
    borderColor: "#ccc",
    borderRadius: 8,
    paddingHorizontal: 12,
    marginBottom: 16,
  },
  submitButton: {
    height: 40,
    backgroundColor: "#007AFF",
    justifyContent: "center",
    alignItems: "center",
    borderRadius: 8,
    flex: 1,
    minWidth: 100,
  },
  resetButton: {
    height: 40,
    backgroundColor: "#ff2c4f",
    justifyContent: "center",
    alignItems: "center",
    borderRadius: 8,
    flex: 1,
    minWidth: 100,
  },
  buttonText: {
    color: "#fff",
    fontWeight: "bold",
  },
  buttons: {
    flexDirection: "row",
    gap: 20,
    marginTop: 50,
  },
});

export default SignInScreen;
