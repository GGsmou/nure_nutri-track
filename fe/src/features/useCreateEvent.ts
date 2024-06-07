import { useMutation } from "react-query";
import { useGoogleApis } from "./useGoogleApis";

export const useCreateEvent = () => {
  const { calendar } = useGoogleApis();

  return useMutation(
    async (data: {
      startDate: string;
      endDate: string;
      summary: string;
      description: string;
    }) => {
      return calendar?.events.insert({
        calendarId: "primary",
        resource: {
          end: { date: data.endDate },
          start: { date: data.startDate },
          summary: data.summary,
          description: data.description,
        },
      });
    },
  );
};
