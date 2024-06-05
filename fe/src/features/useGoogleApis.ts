import { calendar_v3 } from "googleapis";
import { useEffect, useState } from "react";

const DISCOVERY_DOC =
  "https://www.googleapis.com/discovery/v1/apis/calendar/v3/rest";

export const useGoogleApis = () => {
  const [calendar, setCalendar] = useState<calendar_v3.Calendar | null>(null);

  useEffect(() => {
    gapi.load("client", async () => {
      await gapi.client.init({
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

  return { gapi, calendar };
};
