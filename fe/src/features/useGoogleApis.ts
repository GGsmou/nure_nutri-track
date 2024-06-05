import { calendar_v3 } from "googleapis";
import load from "load-script";
import { useEffect, useState } from "react";
import { clientId } from "../utils/consts";

const DISCOVERY_DOC =
  "https://www.googleapis.com/discovery/v1/apis/calendar/v3/rest";

export const useGoogleApis = () => {
  const [calendar, setCalendar] = useState<calendar_v3.Calendar | null>(null);
  useEffect(() => {
    load("https://apis.google.com/js/api.js", async () => {
      gapi.load("client", async () => {
        await gapi.client.init({
          clientId: clientId,
          discoveryDocs: [DISCOVERY_DOC],
        });

        gapi.client.setToken({
          access_token: "<ACCESS_TOKEN>",
        });

        setCalendar(
          gapi.client[
            "calendar" as unknown as keyof typeof gapi.client
          ] as unknown as calendar_v3.Calendar,
        );
      });
    });
  });

  return { gapi, calendar };
};
