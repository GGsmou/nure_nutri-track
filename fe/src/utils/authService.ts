export const authService = {
  setAuthInfo({ token, userId }: { token: string; userId: string }) {
    localStorage.setItem("token", token);
    localStorage.setItem("userId", userId);
  },
  setGoogleToken(access_token: string) {
    localStorage.setItem("googleToken", access_token);
  },
  getAuthInfo() {
    return {
      token: localStorage.getItem("token"),
      userId: localStorage.getItem("userId"),
    };
  },
  getGoogleToken() {
    return localStorage.getItem("googleToken");
  },
  removeAuthInfo() {
    localStorage.removeItem("token");
    localStorage.removeItem("userId");
  },
  removeGoogleToken() {
    localStorage.removeItem("googleToken");
  },
};
