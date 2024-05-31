export const authService = {
  setAuthInfo({ token, userId }: { token: string; userId: string }) {
    localStorage.setItem("token", token);
    localStorage.setItem("userId", userId);
  },
  getAuthInfo() {
    return {
      token: localStorage.getItem("token"),
      userId: localStorage.getItem("userId"),
    };
  },
  removeAuthInfo() {
    localStorage.removeItem("token");
    localStorage.removeItem("userId");
  },
};
