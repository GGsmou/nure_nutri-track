import { useMutation } from "react-query";

export const useCreateEvent = () => {
  return useMutation(
    (data: {
      startDate: string;
      endDate: string;
      summary: string;
      description: string;
    }) => {
      return fetch(
        "https://googleapis.com/calendar/v3/calendars/primary/events",
        {
          method: "POST",
          headers: {
            Authorization: `Bearer ${"AUTH_TOKEN" || ""}`,
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            end: { date: data.endDate },
            start: { date: data.startDate },
            summary: data.summary,
            description: data.description,
          }),
        },
      );
    },
  );
};
