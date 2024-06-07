import { useMutation } from "react-query";
import { useNavigate } from "react-router-dom";
import { authService } from "../utils/authService";

export const useLogout = () => {
  const navigate = useNavigate();
  return useMutation({
    mutationKey: "user",
    mutationFn: async () => {
      //await fetchAbstract("identity/logout", "post");
      authService.removeAuthInfo();
      authService.removeGoogleToken();
      navigate("/auth");
      return;
    },
  });
};
