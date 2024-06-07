import { useMutation } from "react-query";
import { useNavigate } from "react-router-dom";
import { authService } from "../utils/authService";
import { clientId } from "../utils/consts";
import { useSignIn, useSignUp } from "./useAuth";
import { useGoogleApis } from "./useGoogleApis";

const SCOPES = "email profile https://www.googleapis.com/auth/calendar.events";

export const useGoogleAuth = () => {
  const { gapi } = useGoogleApis();
  const { mutateAsync: signIn } = useSignIn();
  const { mutateAsync: signUp } = useSignUp();
  const { mutateAsync: getGoogleUser } = useMutation((accessToken: string) => {
    return fetch(
      `https://oauth2.googleapis.com/tokeninfo?access_token=${accessToken}`,
    ).then((res) => res.json());
  });

  const navigate = useNavigate();
  const tokenClient = google.accounts.oauth2.initTokenClient({
    client_id: clientId,
    scope: SCOPES,
    callback: async (res) => {
      authService.setGoogleToken(res.access_token);
      const { email }: { email?: string } = await getGoogleUser(
        res.access_token,
      );
      if (!email) return;

      try {
        const authInfo = await signIn({ email, password: email });
        authService.setAuthInfo(authInfo);
        navigate("/");
      } catch (e) {
        await signUp({ email, username: email, password: email });
        const authInfo = await signIn({ email, password: email });
        authService.setAuthInfo(authInfo);
        navigate("/new-user");
      }
    },
  });

  const authCallback = async () => {
    if (gapi.client.getToken() === null) {
      tokenClient.requestAccessToken({ prompt: "consent" });
    } else {
      tokenClient.requestAccessToken({ prompt: "" });
    }
  };

  return authCallback;
};
