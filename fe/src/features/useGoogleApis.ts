import { useEffect, useState } from "react";
import { authService } from "../utils/authService";

const DISCOVERY_DOC =
  "https://www.googleapis.com/discovery/v1/apis/calendar/v3/rest";

export const useGoogleApis = () => {
  const [calendar, setCalendar] = useState<typeof gapi.client.calendar | null>(
    null,
  );

  useEffect(() => {
    gapi.load("client", async () => {
      await gapi.client.init({
        discoveryDocs: [DISCOVERY_DOC],
      });

      gapi.client.setToken({
        access_token: authService.getGoogleToken() || "",
      });

      setCalendar(gapi.client.calendar);
    });
  });

  return { gapi, calendar };
};
