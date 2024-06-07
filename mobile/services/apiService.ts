import axios from "axios";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { UserTypeResponse } from "@/types";

const API_BASE_URL = "https://nutritrack.azurewebsites.net";

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

interface SignInResponse {
  token: string;
  userId: string;
}

api.interceptors.request.use(
  async (config) => {
    const token = await AsyncStorage.getItem("token");
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);

export const signIn = async (
  email: string,
  password: string
): Promise<SignInResponse> => {
  try {
    const response = await api.post<SignInResponse>("/Identity/login", {
      email,
      password,
    });

    const typeResponse = await api.get<UserTypeResponse>(
      "/Users/" + response.data.userId
    );

    const isAdmin = typeResponse.data.userType
      ? typeResponse.data.userType?.role === 0
      : false;

    await AsyncStorage.setItem("token", response.data.token);
    await AsyncStorage.setItem("userId", response.data.userId);
    await AsyncStorage.setItem("isAdmin", JSON.stringify(isAdmin));

    return response.data;
  } catch (error: any) {
    throw error.response ? error.response.data : new Error("Network error");
  }
};

export default api;
