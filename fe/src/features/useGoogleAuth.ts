import { authService } from "../utils/authService";
import { clientId } from "../utils/consts";
import { useGoogleApis } from "./useGoogleApis";

const SCOPES = "email profile https://www.googleapis.com/auth/calendar.events";

export const useGoogleAuth = () => {
  const { gapi } = useGoogleApis();
  const tokenClient = google.accounts.oauth2.initTokenClient({
    client_id: clientId,
    scope: SCOPES,
    callback: (res) => {
      authService.setGoogleToken(res.access_token);
    },
  });

  const authCallback = () => {
    if (gapi.client.getToken() === null) {
      tokenClient.requestAccessToken({ prompt: "consent" });
    } else {
      tokenClient.requestAccessToken({ prompt: "" });
    }
  };

  return authCallback;
};
